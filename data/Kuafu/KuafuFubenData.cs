using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.Kuafu
{
    [ProtoContract]
    public class KuafuFubenData
    {
        /// <summary>
        /// 副本编号
        /// </summary>
        [ProtoMember(1)]
        public int FubenSequenceID;
        /// <summary>
        /// 在同一个战斗副本中的报名数据
        /// </summary>
        [ProtoMember(2)]
        public List<KuaFuRegisterData> RegisterDatas;
    }
}
