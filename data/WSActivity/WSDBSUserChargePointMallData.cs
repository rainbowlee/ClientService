using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class WSDBSUserChargePointMallData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [ProtoMember(1, IsRequired = true)]
        public int ErroCode = 1;
        /// <summary>
        /// 购买次数Dic
        /// </summary>
        [ProtoMember(2, IsRequired = true)]
        public Dictionary<int, int> BuyTimesDic = new Dictionary<int, int>();
    }
}
