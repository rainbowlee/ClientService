using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class WSJewelHoleDBData
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID;
        /// <summary>
        /// 默认开启配置
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<int, int> OpenDic = new Dictionary<int, int>();
    }
}
