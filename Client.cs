using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Server.Protocol;
using Server.Data;
using GameFramework;
namespace ClientService
{
  public enum ClientStatus
  {
    None = 0,
    Login,
    RoleList,
    CreateRole,
    InitGame,
    PlayGame,
    Req1,
    Logout,
    Max,
  };

  public class Client
  {
    static int ZoneId = 1;
    static int sGuid = 0;
    public ServiceThread Thread;
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
      m_StartTick = DateTime.Now.Ticks;
      m_TcpInPacket.TCPCmdPacketEvent -= TCPCmdPacketEventHandler;
      m_TcpInPacket.TCPCmdPacketEvent += TCPCmdPacketEventHandler;
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
      LogSys.Log(LOG_TYPE.ERROR, "SendLogin");
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
                      .Append(ClientService.Instance.m_Channel)
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
    

    private void RoleList()
    {

      if(string.IsNullOrEmpty(m_UserId) == true)
      {
        return;
      }
      LogSys.Log(LOG_TYPE.ERROR, "RoleList");
      m_StringBuilder.Clear();

      m_StringBuilder.Append(m_UserId)
                      .Append(":")
                      .Append(ZoneId.ToString());

      string str = m_StringBuilder.ToString();

      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
      SendBytes((int)TCPGameServerCmds.CMD_ROLE_LIST, bytes);
    }

    private void CreateRole()
    {
      if (string.IsNullOrEmpty(m_UserId) == true)
      {
        return;
      }
      LogSys.Log(LOG_TYPE.ERROR, "CreateRole");
      /*

                            string userID = fields[0];
                      string userName = fields[0];//ChenYongcun 临时将玩家的userName替换为userId
                      int sex = Convert.ToInt32(fields[2]);
                      int occup = Convert.ToInt32(fields[3]);
                      string rolename = fields[4].Split('$')[0];
                      int zoneID = Convert.ToInt32(fields[5]);
                      

                      string userID = fields[0];
                      //string userName = fields[1];  2015.07.24临时关闭掉
                      //int sex = Convert.ToInt32(fields[2]);
                      //int occup = Convert.ToInt32(fields[3]);
                      string[] nameAndPingTaiID = fields[4].Split('$');
                      int zoneID = Convert.ToInt32(fields[5]);
                      string deviceId = fields[6];
                      string channel = fields[11];



                              string puid = userID;// puId实际就是用户ID
                        string device_id = fields[6];//  设备ID
                        string first_login_ip = "";//客户端IP
                        string last_login_ip = "";// 上次登录IP
                        string osversion = fields[7];//    系统版本
                        string phonetype = fields[8];//   设备型号
                        int tutoriastep = 0; //  新手引导最后步骤
                        string phoneos = fields[9]; // fileds[9]; 系统类型
                        string language = fields[10]; // fields[10]; 手机语言设置
                        string channel = fields[11];// fields[11] 用来的来源渠道
                        string idfa = fields.Length >=13 ? fields[12] : string.Empty;// fields[12] idfa 广告平台标识
             */

      m_StringBuilder.Clear();

      m_StringBuilder.Append(m_UserId)
                      .Append(":")
                      .Append(m_UserId)
                      .Append(":")
                      .Append(1)
                      .Append(":")
                      .Append(2)
                      .Append(":")
                      .Append("Role" + m_Guid.ToString())
                      .Append(":")
                      .Append(ZoneId.ToString())
                      .Append(":")
                      .Append("deviceId" + m_Guid.ToString())
                      .Append(":")
                      .Append(string.Empty)
                      .Append(":")
                      .Append(string.Empty)
                      .Append(":")
                      .Append(string.Empty)
                      .Append(":")
                      .Append(string.Empty)
                      .Append(":")
                      .Append("base")
                      .Append(":")
                      .Append(string.Empty);

      string str = m_StringBuilder.ToString();

      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
      SendBytes((int)TCPGameServerCmds.CMD_CREATE_ROLE, bytes);
    }

    private void InitGame()
    {
      LogSys.Log(LOG_TYPE.ERROR, "InitGame");

      if (string.IsNullOrEmpty(m_UserId) == true)
      {
        return;
      }

      m_StringBuilder.Clear();

      m_StringBuilder.Append(m_UserId)
                      .Append(":")
                      .Append(m_RoleList[0].RoleId);

      string str = m_StringBuilder.ToString();

      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
      SendBytes((int)TCPGameServerCmds.CMD_INIT_GAME, bytes);
    }


    private void PlayGame()
    {
      LogSys.Log(LOG_TYPE.ERROR, "PlayGame");

      if (string.IsNullOrEmpty(m_UserId) == true)
      {
        return;
      }

      m_StringBuilder.Clear();

      m_StringBuilder.Append(m_RoleList[0].RoleId);

      string str = m_StringBuilder.ToString();

      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
      SendBytes((int)TCPGameServerCmds.CMD_PLAY_GAME, bytes);
    }

    private void ReceiveCallBack_Thread(IAsyncResult result)
    {
      Client state = (Client)result.AsyncState;
      NetworkStream stream = m_TcpClient.GetStream();
      int code = stream.EndRead(result);
      LogSys.Log(LOG_TYPE.ERROR, ConsoleColor.Blue, "ReceiveCallBack bytes={0} threadid={1} threadpool={2}", code, System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentThread.IsThreadPoolThread);
      //LogSys.Log(LOG_TYPE.ERROR, "ReceiveCallBack code={0} bytes={1}", code, DataHelper.Bytes2HexString(m_ReadBytes));

      if (code > 0)
      {
        bool returnValue = m_TcpInPacket.WriteData(m_ReadBytes, 0, code);
        if (returnValue == true)
          Receive();
        else
        {
          LogSys.Log(LOG_TYPE.ERROR, "ReceiveCallBack writeDate error");
          Close();
        }
      }
      else
      {
        LogSys.Log(LOG_TYPE.ERROR, "ReceiveCallBack close");
        Close();
      }
    }

    private void ReceiveCallBack(IAsyncResult result)
    {
      Thread.QueueAction(ReceiveCallBack_Thread, result);
    }


    void Close()
    {
      LogSys.Log(LOG_TYPE.ERROR, "Client close guid={0}", m_Guid);
      m_TcpClient.Close();

      Thread.RemoveClient(this);
      //ClientService.Instance.
    }

    private void ChangeStatus(ClientStatus clientStatus)
    {
      long curTick = DateTime.Now.Ticks;
      long mills = (curTick - m_SendMsgTick) / TimeSpan.TicksPerMillisecond;
      m_CostMills[(int)clientStatus] = mills;
    }

    public bool TCPCmdPacketEventHandler(object sender, int doType)
    {
      TCPInPacket inPacket = sender as TCPInPacket;
      //LogSys.Log(LOG_TYPE.ERROR, "cmdid={0} bytes={1}", inPacket.PacketCmdID, DataHelper.Bytes2HexString(inPacket.GetPacketBytes()));

      try
      {
        switch ((TCPGameServerCmds)inPacket.PacketCmdID)
        {
          case TCPGameServerCmds.CMD_LOGIN_ON:
            {
              string cmdData = new System.Text.UTF8Encoding().GetString(inPacket.GetPacketBytes(), 0, inPacket.PacketDataSize);
              string[] fields = cmdData.Split(':');
              //LogManager.WriteLog(LogTypes.Info, string.Format("登录指令参数, CMD={0}, Client={1}, Recv={2}", (TCPGameServerCmds)nID, Global.GetSocketRemoteEndPoint(socket), cmdData));
              //if (fields.Length < 10)
              //{
              //  LogManager.WriteLog(LogTypes.Error, string.Format("指令参数个数错误, CMD={0}, Client={1}, Recv={2}", (TCPGameServerCmds)nID, Global.GetSocketRemoteEndPoint(socket), fields.Length));
              //  return TCPProcessCmdResults.RESULT_FAILED;
              //}
              ChangeStatus(ClientStatus.Login);
              int randomKey = Convert.ToInt32(fields[0]);
              string userID = fields[1];
              LogSys.Log(LOG_TYPE.ERROR, "CMD_LOGIN_ON err={0} userID={1}", randomKey, userID);
              if (randomKey <=0)
              {
                Close();
                break;
              }
              m_UserId = userID;
              m_RandomKey = randomKey;

              if (string.IsNullOrEmpty(m_UserId) == false)
              {
                RoleList();
              }
              break;
            }
          case TCPGameServerCmds.CMD_ROLE_LIST:
            {
              string cmdData = new System.Text.UTF8Encoding().GetString(inPacket.GetPacketBytes(), 0, inPacket.PacketDataSize);
              string[] fields = cmdData.Split(':');

              int roleCount = Convert.ToInt32(fields[0]);
              LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_ROLE_LIST, cmdData);
              string[] roleList = fields[1].Split('|');
              //roleList += string.Format("{0}${1}${2}${3}${4}${5}|",
              //     dbUserInfo.ListRoleIDs[i], dbUserInfo.ListRoleSexes[i], dbUserInfo.ListRoleOccups[i], dbUserInfo.ListRoleNames[i], dbUserInfo.ListRoleLevels[i], dbUserInfo.ListRoleChangeLifeCount[i]);

              ChangeStatus(ClientStatus.RoleList);


              for (int i = 0; i < m_RoleList.Length; i++)
                m_RoleList[i] = null;

              int count = 0;
              for (int i = 0; i < roleList.Length; ++i)
              {
                string strRole = roleList[i];
                string[] roleSubFields = strRole.Split('$');

                if (roleSubFields.Length >= 5)
                {
                  Role role = new Role();
                  role.RoleId = Convert.ToInt32(roleSubFields[0]);
                  role.RoleSex = Convert.ToInt32(roleSubFields[1]);
                  role.RoleOccup = Convert.ToInt32(roleSubFields[2]);
                  role.RoleName = roleSubFields[3];
                  role.RoleLevel = Convert.ToInt32(roleSubFields[4]);
                  role.RoleChangeCount = Convert.ToInt32(roleSubFields[5]);

                  m_RoleList[i] = role;
                  count++;                  
                }
              }

              if (count > 0)
                InitGame();
              else
                CreateRole();

              break;
            }
          case TCPGameServerCmds.CMD_CREATE_ROLE:
            {
              string cmdData = new System.Text.UTF8Encoding().GetString(inPacket.GetPacketBytes(), 0, inPacket.PacketDataSize);
              string[] fields = cmdData.Split(':');
              string[] roleSubFields = fields[1].Split('$');
              ChangeStatus(ClientStatus.CreateRole);
              int code = Convert.ToInt32(fields[0]);
              LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_CREATE_ROLE, cmdData);
              if (code == 1)
              {
                if (roleSubFields.Length >= 5)
                {
                  Role role = new Role();
                  role.RoleId = Convert.ToInt32(roleSubFields[0]);
                  role.RoleSex = Convert.ToInt32(roleSubFields[1]);
                  role.RoleOccup = Convert.ToInt32(roleSubFields[2]);
                  role.RoleName = roleSubFields[3];
                  role.RoleLevel = Convert.ToInt32(roleSubFields[4]);
                  role.RoleChangeCount = Convert.ToInt32(roleSubFields[5]);

                  for (int i = 0; i < m_RoleList.Length; i++)
                  {
                    if (m_RoleList[i] == null)
                    {
                      m_RoleList[i] = role;
                      InitGame();
                      break;
                    }
                  }
                }
              }
              break;
            }

          case TCPGameServerCmds.CMD_INIT_GAME:
            {
              LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_INIT_GAME,0);
              //var roleData = DataHelper.BytesToObject<RoleData>(inPacket.GetPacketBytes(), 0, inPacket.PacketDataSize);

              //if(roleData != null)
              //{
              //  LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_INIT_GAME, roleData.RoleID);
              //}
              ChangeStatus(ClientStatus.InitGame);
              if (inPacket.PacketDataSize > 100)
              {
                PlayGame();
              }
              break;
            }
          case TCPGameServerCmds.CMD_PLAY_GAME:
            {
              string cmdData = new System.Text.UTF8Encoding().GetString(inPacket.GetPacketBytes(), 0, inPacket.PacketDataSize);
              string[] fields = cmdData.Split(':');
              ChangeStatus(ClientStatus.PlayGame);

              LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_PLAY_GAME, cmdData);
              if (fields != null && fields.Length >=1)
              {
                LogSys.Log(LOG_TYPE.ERROR, "msg = {0} cmd={1}", TCPGameServerCmds.CMD_PLAY_GAME, cmdData);
              }
              break;
            }
          default:
            {
              LogSys.Log(LOG_TYPE.ERROR, "msg = {0} bytes={1}", (TCPGameServerCmds)inPacket.PacketCmdID, inPacket.PacketDataSize);
              break;
            }
        }
      }
      catch (Exception ex)
      {
        LogSys.Log(LOG_TYPE.ERROR, "msg = {0} exception={1}", (TCPGameServerCmds)inPacket.PacketCmdID, ex.Message);
      }
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


      m_SendMsgTick = DateTime.Now.Ticks;
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


    public int Guid
    {
      get { return m_Guid; }
    }

    public string GetStatisData()
    {
      //StringBuilder strBuilder = 
      //for( int i = 0; i < (int)ClientStatus.Max; ++i)
      //{
      //  long cost = m_CostMills[i];

      //}

      string str = string.Join("_", m_CostMills);
      return str;
    }

    public long GetCostMill(ClientStatus clientStatus)
    {
      return m_CostMills[(int)clientStatus];
    }

    string  m_Ip;
    int m_Port;
    TcpClient m_TcpClient;
    StringBuilder m_StringBuilder =  new StringBuilder();
    byte[] m_ReadBytes = new byte[1024];
    private int m_Guid;
    TCPInPacket m_TcpInPacket = new TCPInPacket();

    private int m_RandomKey;
    private string m_UserId;

    private ClientStatus m_ClientStatus = ClientStatus.None;
    private Role[] m_RoleList = new Role[3];

    private long m_SendMsgTick = 0;
    private long m_StartTick = 0;
    private long[] m_CostMills = new long[(int)ClientStatus.Max]; 
  }
}
