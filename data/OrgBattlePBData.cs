using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using GameServer.Server;
using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    class OrgBattlePBData
    {
        /// <summary>
        /// 势力名字
        /// </summary>
        [ProtoMember(1)]
        public string  OrgName  = "";

        /// <summary>
        /// 存活人数
        /// </summary>
        [ProtoMember(2)]
        public int ActiveSum = 0;

        /// <summary>
        /// 参加人数
        /// </summary>
        [ProtoMember(3)]
        public int JoinSum = 0;
    }
}
