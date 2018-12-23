using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class UserBetaTestReward
    {
        /// <summary>
        /// 是否执行了查询：0，没有；1：查询过了
        /// </summary>
        [ProtoMember(1)]
        public int IsQuery = 0;

        /// <summary>
        /// 玩家的奖励领取状态
        /// </summary>
        [ProtoMember(2)]
        public int RewardStatus = 0;

        /// <summary>
        /// 用来兑换为vip的奖励数，此数值用来充当玩家的充值额度
        /// </summary>
        [ProtoMember(3)]
        public int RewardVipPoint = 0;

        /// <summary>
        /// 账号ID
        /// </summary>
        [ProtoMember(4)]
        public string UserId = "";

        /// <summary>
        /// 内测返回的钱数
        /// </summary>
        [ProtoMember(5)]
        public int RewardMoney = 0;

        /// <summary>
        /// 当前登陆的玩家ID
        /// </summary>
        [ProtoMember(6)]
        public int RoleId = 0;

        /// <summary>
        /// 区ID数据
        /// </summary>
        [ProtoMember(7)]
        public int ZoneId = 0;
    }
}
