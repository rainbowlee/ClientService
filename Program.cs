using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
  /*
   实际上并未使用加密
  //clientside---->serverside
  //receivedata:
  //rawdata
  //datahelper.sort 位加密
  
  //serverside---->clientside
  */
  public class GameManager
  {
    public static bool IsTcpCrypt = false;
  };

  class Program
  {
    static void Main(string[] args)
    {
      if(args.Length >4)
      {
        string Channel = args[0];
        string ip = args[1];
        int threadNum = Convert.ToInt32(args[2]);
        int threadClinetNum = Convert.ToInt32(args[3]);
        int addClinetMillSeconds = Convert.ToInt32(args[4]);

        ClientService.Instance.m_Channel = Channel;
        ClientService.Instance.m_Ip = ip;
        ClientService.Instance.m_MaxThreads = threadNum;
        ClientService.Instance.m_ThreadClientNum = threadClinetNum;
        ClientService.Instance.m_AddClientMillSecond = addClinetMillSeconds;
      }

      ClientService.Instance.Start();
      ClientService.Instance.Loop();
      ClientService.Instance.Stop();
    }
  }
}
