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
      ClientService.Instance.Start();
      ClientService.Instance.Loop();
      ClientService.Instance.Stop();
    }
  }
}
