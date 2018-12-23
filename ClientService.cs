using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.CodeDom;
using System.Collections;
using System.Collections.Concurrent;

namespace ClientService
{
  public class ClientService
  {
    private static ClientService s_Instance;

    public static ClientService Instance
    {
      get
      {
        if (s_Instance == null)
          s_Instance = new ClientService();

        return s_Instance;
      }
    }

    public void Start()
    {
      LogSys.Start();

      m_ServiceThreads = new ServiceThread[m_MaxThreads];
      LogSys.Log(LOG_TYPE.INFO, "start");
      for (int i = 0; i < m_ServiceThreads.Length; ++i)
      {
        m_ServiceThreads[i] = new ServiceThread(i.ToString());
        m_ServiceThreads[i].Init();
        m_ServiceThreads[i].Start();
      }
    }

    public void Stop()
    {
      LogSys.Log(LOG_TYPE.INFO, "stop");

      LogSys.Stop();

      for (int i = 0; i < m_ServiceThreads.Length; ++i)
      {
        m_ServiceThreads[i].Stop();
      }
    }


    private void SecondsLogic()
    {
      //Client client = new Client();
      ////client.Connect("223.111.148.246",4403);
      //client.Connect("127.0.0.1", 4403);
      //client.SendLogin();

      for (int i = 0; i < m_ServiceThreads.Length; ++i)
        m_ServiceThreads[i].QueueAction(m_ServiceThreads[i].AddOne);

      LogSys.Log(LOG_TYPE.DEBUG, "test SecondsLogic");
    }

    public void Loop()
    {
      while (true)
      {
        if (m_LastTimeTick + TimeSpan.TicksPerMillisecond * m_AddClientMillSecond <= DateTime.Now.Ticks)
        {
          m_LastTimeTick = DateTime.Now.Ticks;
          //LogSys.Log(LOG_TYPE.INFO, "tick logic");
          SecondsLogic();
        }

        if (m_LastTimeTickShwoStatics + TimeSpan.TicksPerSecond <= DateTime.Now.Ticks)
        {
          m_LastTimeTickShwoStatics = DateTime.Now.Ticks;
          LogSys.Log(LOG_TYPE.INFO, "client service cur clientnum={0}", m_ClientNum);
        }

        Thread.Sleep(5);
      }
    }

    public void AddClient()
    {
      Interlocked.Increment(ref m_ClientNum);
    }


    public void RemoveClient()
    {
      Interlocked.Decrement(ref m_ClientNum);
    }
    public string m_Channel = "base";
    public long m_TickInterval = 10 * TimeSpan.TicksPerMillisecond;
    public string m_Ip = "223.111.148.246";
    //public string m_Ip = "127.0.0.1";
    public int m_Port = 4403;
    private int m_ClientNum;
    private long m_LastTimeTick = 0;
    private long m_LastTimeTickShwoStatics = 0;
    public long m_MaxThreads = 10;
    public int m_ThreadClientNum = 50;
    public long m_AddClientMillSecond = 10;
    ServiceThread[] m_ServiceThreads = null;
  }
}
