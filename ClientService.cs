using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

      for(int i = 0; i < m_ServiceThreads.Length; ++i)
      {
        m_ServiceThreads[i] = new ServiceThread(i.ToString());
        m_ServiceThreads[i].Init();
        m_ServiceThreads[i].Start();
      }
    }

    public void Stop()
    {
      LogSys.Stop();

      for (int i = 0; i < m_ServiceThreads.Length; ++i)
      {
        m_ServiceThreads[i].Stop();
      }
    }


    private void SecondsLogic()
    {
      Client client = new Client();
      client.Connect("223.111.148.246",4403);
      //client.Connect("127.0.0.1", 4403);
      client.SendLogin();
      LogSys.Log(LOG_TYPE.DEBUG, "test SecondsLogic");
    }

    public void Loop()
    {
      while(true)
      {
        if (m_LastTimeTick + TimeSpan.TicksPerSecond <= DateTime.Now.Ticks)
        {
          m_LastTimeTick = DateTime.Now.Ticks;
          SecondsLogic();
        }

        Thread.Sleep(500);
      }
    }

    private long m_LastTimeTick =0;
    ServiceThread[] m_ServiceThreads = new ServiceThread[10];
  }
}
