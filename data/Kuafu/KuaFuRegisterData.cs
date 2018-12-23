using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.Kuafu
{
    [ProtoContract]
    public class KuaFuRegisterData
    {
        /// <summary>
        /// 攻击者ServerID
        /// </summary>
        [ProtoMember(1)]
        public int AttackServerID = 0;
        /// <summary>
        /// 被攻击的ServerID
        /// </summary>
        [ProtoMember(2)]
        public int BeAttackServerID = 0;
        /// <summary>
        /// 攻击者服务器名字
        /// </summary>
        [ProtoMember(3)]
        public string AttackerServerName = "";
        /// <summary>
        /// 攻击者国王角色ID
        /// </summary>
        [ProtoMember(4)]
        public int AttakerKingRoleID = 0;
        /// <summary>
        /// 攻击者国王名字
        /// </summary>
        [ProtoMember(5)]
        public string AtttackerKingName = "";
        /// <summary>
        /// 本次报名选择攻击的城池ID
        /// </summary>
        [ProtoMember(6)]
        public int TargetCityID = 0;
        /// <summary>
        /// 副本序号
        /// </summary>
        [ProtoMember(7)]
        public int FubenSequenceID = 0;
        /// <summary>
        /// 参加跨服战的帮会ID
        /// </summary>
        [ProtoMember(8)]
        public int KuafuBanghuiID = 0;
        /// <summary>
        /// 帮会名称
        /// </summary>
        [ProtoMember(9)]
        public string AttackerBanghuiName = "";
        /// <summary>
        /// 跨服战战斗结果，是否胜利
        /// </summary>
        [ProtoMember(10)]
        public int BattleResult = 0;
        /// <summary>
        /// 占有者城池
        /// </summary>
        [ProtoMember(11)]
        public int OwnerCityID = 0;
    }
}
