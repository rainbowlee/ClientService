using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameFramework;

namespace ClientService
{
  internal sealed class ServiceThread : MyServerThread
  {
    internal ServiceThread( string name)
      : base("ServiceThread:" + name)
    {
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
  }
}
