using System.Collections.Generic;

namespace Server.Data.Kuafu
{
    /// <summary>
    /// 跨服玩家属性数据
    /// </summary>
    public class ClientOtherProperties
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int roleID { set; get; }

        /// <summary>
        /// 当前角色的VIPLevel
        /// </summary>
        public int vipLevel { set; get; }
        /// <summary>
        /// 当前角色的总点数
        /// </summary>
        public int TotalPropPoint { set; get; }
        /// <summary>
        /// 玩家力量
        /// </summary>
        public int PropStrength { set; get; }
        /// <summary>
        /// 玩家神识
        /// </summary>
        public int PropIntelligence { set; get; }
        /// <summary>
        /// 玩家身法
        /// </summary>
        public int PropDexterity { set; get; }
        /// <summary>
        /// 玩家体魄
        /// </summary>
        public int PropConstitution { set; get; }
        /// <summary>
        /// 是否检查属性设置
        /// </summary>
        public int nVerifyBuffProp { set; get; }
        /// <summary>
        /// 玩家的图鉴属性
        /// </summary>
        public Dictionary<int, int> _PictureJudgeReferTypeInfo {set;get;}

        /// <summary>
        /// 玩家的图鉴标识信息
        /// </summary>
        public List<ulong> PictureJudgeFlagsUlong { set; get; }
        /// <summary>
        /// 玩家所在联盟的等级
        /// </summary>
        public int LeagueQiLevel { set; get; }
    }
}
