using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using GameServer.Server;
using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class GemOreCarKillData
    {
        /// <summary>
        /// 击杀者ID
        /// </summary>
        [ProtoMember(1)]
        public int  KillerRoleID =0;

        /// <summary>
        /// 通关奖励
        /// </summary>
        [ProtoMember(2)]
        public List<GoodsData> Goods= new List<GoodsData>();

        /// <summary>
        /// 击杀奖励
        /// </summary>
        [ProtoMember(3)]
        public List<GoodsData> Goods2 = new List<GoodsData>();


    }
}
