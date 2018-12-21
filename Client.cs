using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Server.Protocol;

namespace ClientService
{
  public class Client
  {
    static int sGuid = 0;
    public Client()
    {
      m_Guid = ++sGuid;
    }

    public void SetServer(string ip, int port)
    {
      m_Ip = ip;
      m_Port = port;
    }

    public void Connect(string ip, int port)
    {
      SetServer(ip, port);
      m_TcpClient = new TcpClient();
      m_TcpClient.Connect(ip, port);
      m_TcpClient.SendTimeout = 20;
      m_TcpClient.ReceiveTimeout = 100000;
      m_TcpClient.ReceiveBufferSize = 64 * 1024;
      m_TcpClient.SendBufferSize = 64 * 1024;
    }

    public bool Connected
    {
      get
      {
        return m_TcpClient != null && m_TcpClient.Connected;
      }
    }

    public void SendMessageAndRecv()
    {
      if (Connected == false) return;
      m_TcpClient.SendTimeout = 20;
      m_TcpClient.ReceiveTimeout = 20;
      m_TcpClient.NoDelay = true;
      NetworkStream stream = m_TcpClient.GetStream();
    }

    public void SendLogin()
    {
      NetworkStream stream = m_TcpClient.GetStream();

      //string userID = fields[0];
      //string userName = fields[1];
      //string userToken = fields[2];
      //int randKey = Convert.ToInt32(fields[3]);
      //int verSign = Convert.ToInt32(fields[4]);
      //int userIsAdult = Convert.ToInt32(fields[5]);

      //string channel = fields[6]; // 渠道标识，例如360，小米
      //string deviceId = fields[7];// 设备唯一标识

      //string appId = fields[8];
      //string version = fields[9];
      m_StringBuilder.Clear();

      m_StringBuilder.Append("Id_" + m_Guid.ToString())
                      .Append(":")
                      .Append("Name_" + m_Guid.ToString())
                      .Append(":")
                      .Append("Token_" + m_Guid.ToString())
                      .Append(":")
                      .Append(m_Guid.ToString())
                      .Append(":")
                      .Append(((int)TCPCmdProtocolVer.VerSign))
                      .Append(":")
                      .Append(1.ToString())
                      .Append(":")
                      .Append("base")
                      .Append(":")
                      .Append("xxtxddasssssa")
                      .Append(":")
                      .Append("appid")
                      .Append(":")
                      .Append("version");

      string str = m_StringBuilder.ToString();
      //byte[] datas = System.Text.Encoding.UTF8.GetBytes(str);
      //tcpOutPacket.FinalWriteData(datas,0, datas.Length);
      //TCPOutPacket tcpOutPacket = TCPOutPacket.MakeTCPOutPacket(str, 100);
      //SendPacket(tcpOutPacket);

      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
      SendBytes(100, bytes);
      Receive();
    }
    
    private void ReceiveCallBack(IAsyncResult result)
    {
      NetworkStream stream = m_TcpClient.GetStream();
      int code = stream.EndRead(result);
      LogSys.Log(LOG_TYPE.ERROR, "ReceiveCallBack code={0} bytes={1}", code, DataHelper.Bytes2HexString(m_ReadBytes));
      m_TcpInPacket.TCPCmdPacketEvent += TCPCmdPacketEventHandler;
      m_TcpInPacket.WriteData(m_ReadBytes, 0, code);
    }

    public bool TCPCmdPacketEventHandler(object sender, int doType)
    {
      TCPInPacket inPacket = sender as TCPInPacket;
      LogSys.Log(LOG_TYPE.ERROR, "cmdid={0} bytes={1}", inPacket.PacketCmdID, DataHelper.Bytes2HexString(inPacket.GetPacketBytes()));
      return true;
    }

    public void Receive()
    {
      NetworkStream stream = m_TcpClient.GetStream();
      stream.BeginRead(m_ReadBytes, 0, m_ReadBytes.Length, ReceiveCallBack, this);
      //int bytes = stream.Read(m_ReadBytes, 0, m_ReadBytes.Length);
      //if (bytes > 0)
      //  m_TcpInPacket.WriteData(m_ReadBytes, 0, m_ReadBytes.Length);
    }

    public void SendBytes(int cmdId, byte[] datas)
    {
      NetworkStream stream = m_TcpClient.GetStream();
      //if (GameManager.IsTcpCrypt && !tcpOutPacket.IsCrypted)
      //{
      //  //加密
      //  int beginIndex = 6;
      //  int srcDataLength = tcpOutPacket.PacketDataSize - beginIndex;
      //  byte[] data = tcpOutPacket.GetPacketBytes();

      //  int CountAfterPadding = NewCrypt.Padding(data, beginIndex, srcDataLength);
      //  if (CountAfterPadding < 0)
      //  {
      //    throw new Exception("blowfish padding error.");
      //  };
      //  NewCrypt.getInstance().crypt(data, beginIndex, CountAfterPadding);
      //  tcpOutPacket.setPacketDataSize(CountAfterPadding);


      //  tcpOutPacket.IsCrypted = true;
      //  //end 加密
      //}


      byte[] newBytes = new byte[datas.Length + 5];
      long millseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMinute;
      byte[] millsecondBytes = BitConverter.GetBytes(millseconds);

      DataHelper.CopyBytes(newBytes, 1, millsecondBytes, 0, millsecondBytes.Length);
      DataHelper.CopyBytes(newBytes, 5, datas, 0, datas.Length);


      CRC32 crc32 = new CRC32();
      crc32.update(newBytes, 1, newBytes.Length - 1);
      uint cc = crc32.getValue() % 255;
      uint cc2 = (uint)(cmdId % 255);
      int cc3 = (int)(cc ^ cc2 ^ 0x80);

      //byte[] ccBytes = BitConverter.GetBytes(cc);
      //DataHelper.CopyBytes(newBytes, 0, ccBytes, 0, 1);
      newBytes[0] = (byte)cc3;
      TCPOutPacket newTcpOutPacket = new TCPOutPacket();
      newTcpOutPacket.PacketCmdID = (Int16)cmdId;
      newTcpOutPacket.FinalWriteData(newBytes, 0, newBytes.Length);

      DataHelper.SortBytes(newTcpOutPacket.GetPacketBytes(), 0, newTcpOutPacket.GetPacketBytes().Length);
      stream.Write(newTcpOutPacket.GetPacketBytes(), 0, newTcpOutPacket.GetPacketBytes().Length);
      LogSys.Log(LOG_TYPE.ERROR, "msg data={0}", DataHelper.Bytes2HexString(newTcpOutPacket.GetPacketBytes()));
    }


    public void SendPacket(TCPOutPacket tcpOutPacket)
    {
      NetworkStream stream = m_TcpClient.GetStream();
      //if (GameManager.IsTcpCrypt && !tcpOutPacket.IsCrypted)
      //{
      //  //加密
      //  int beginIndex = 6;
      //  int srcDataLength = tcpOutPacket.PacketDataSize - beginIndex;
      //  byte[] data = tcpOutPacket.GetPacketBytes();

      //  int CountAfterPadding = NewCrypt.Padding(data, beginIndex, srcDataLength);
      //  if (CountAfterPadding < 0)
      //  {
      //    throw new Exception("blowfish padding error.");
      //  };
      //  NewCrypt.getInstance().crypt(data, beginIndex, CountAfterPadding);
      //  tcpOutPacket.setPacketDataSize(CountAfterPadding);


      //  tcpOutPacket.IsCrypted = true;
      //  //end 加密
      //}



      DataHelper.SortBytes(tcpOutPacket.GetPacketBytes(), 0, tcpOutPacket.GetPacketBytes().Length);
      byte[] newBytes = new byte[tcpOutPacket.GetPacketBytes().Length+5];
      int millseconds = (int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
      byte[] millsecondBytes = BitConverter.GetBytes(millseconds);

      DataHelper.CopyBytes(newBytes, 1, millsecondBytes, 0, millsecondBytes.Length);
      DataHelper.CopyBytes(newBytes, 5, tcpOutPacket.GetPacketBytes(), 0, tcpOutPacket.GetPacketBytes().Length);


      CRC32 crc32 = new CRC32();
      crc32.update(newBytes, 1, newBytes.Length - 1);
      uint cc = crc32.getValue() % 255;
      uint cc2 = (uint)(tcpOutPacket.PacketCmdID % 255);
      int cc3 = (int)(cc ^ cc2 ^ 0x80);

      byte[] ccBytes = BitConverter.GetBytes(cc);
      DataHelper.CopyBytes(newBytes, 0, ccBytes, 0, 1);

      TCPOutPacket newTcpOutPacket = new TCPOutPacket();
      newTcpOutPacket.PacketCmdID = tcpOutPacket.PacketCmdID;
      newTcpOutPacket.FinalWriteData(newBytes,0, newBytes.Length);
      stream.Write(newTcpOutPacket.GetPacketBytes(),0, newTcpOutPacket.GetPacketBytes().Length);
      LogSys.Log(LOG_TYPE.ERROR, "msg data={0}", DataHelper.Bytes2HexString(tcpOutPacket.GetPacketBytes()) );
    }

    string  m_Ip;
    int m_Port;
    TcpClient m_TcpClient;
    StringBuilder m_StringBuilder =  new StringBuilder();
    byte[] m_ReadBytes = new byte[1024];
    private int m_Guid;
    TCPInPacket m_TcpInPacket = new TCPInPacket();
  }
}
