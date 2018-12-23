using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameFramework;

namespace ClientService
{
  public class ServiceThread : MyServerThread
  {
    static int AddCountOneTime =1;
    internal ServiceThread( string name)
      : base("ServiceThread:" + name)
    {
    }

    internal void AddOne()
    {
      if (m_Clients.Count > ClientService.Instance.m_ThreadClientNum)
      {
        LogSys.Log(LOG_TYPE.WARN, ConsoleColor.Yellow, " Thread{0} is {1} clients", System.Threading.Thread.CurrentThread.ManagedThreadId,ClientService.Instance.m_ThreadClientNum);
        return;
      }


      for( int i = 0; i < AddCountOneTime; ++i)
      {
        Client client = new Client();
        client.Thread = this;
        //client.Connect("223.111.148.246",4403);
        client.Connect(ClientService.Instance.m_Ip, ClientService.Instance.m_Port);
        client.SendLogin();

        AddClient(client);
      }
    }


    internal void Init()
    {
    }

    protected override void OnStart()
    {
    }
    protected override void OnTick()
    {
    }


    internal void RemoveClient(Client client)
    {
      string staticsLog = client.GetStatisData();

      if (m_Clients.ContainsKey(client.Guid))
        m_Clients.Remove(client.Guid);

      LogSys.Log(LOG_TYPE.INFO, "client end static guid={0} data={1} clients={2}", client.Guid, staticsLog, m_Clients.Count);
      ClientService.Instance.RemoveClient();
    }

    internal void AddClient(Client client)
    {
      m_Clients.Add(client.Guid, client);

      ClientService.Instance.AddClient();
    }

    private Dictionary<int, Client> m_Clients = new Dictionary<int, Client>();
  }
}
