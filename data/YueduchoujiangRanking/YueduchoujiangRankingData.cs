using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 月度抽奖排行数据类
    /// </summary>
    [ProtoContract]
    public class YueduchoujiangRankingData
    {
        /// <summary>
        /// 玩家名字
        /// </summary>
        [ProtoMember(1)]
        public string roleName;

        /// <summary>
        /// 抽奖次数
        /// </summary>
        [ProtoMember(2)]
        public int choujiangCnt;

        /// <summary>
        /// 角色ID信息
        /// </summary>
        [ProtoMember(3)]
        public int rid;


    }
}
