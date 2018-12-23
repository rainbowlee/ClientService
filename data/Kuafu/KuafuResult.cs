using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.Kuafu
{
    /// <summary>
    /// 跨服战斗结果数据
    /// </summary>
    [ProtoContract]
    public class KuafuResult
    {
        /// <summary>
        /// 城池ID
        /// </summary>
        [ProtoMember(1)]
        public int CurCityID = 0;

        /// <summary>
        /// 占领当前城池的所有者的城池ID
        /// </summary>
        [ProtoMember(2)]
        public int OwnerCityID = 0;

        /// <summary>
        /// 占据curCity的所有者的服务器的ID
        /// </summary>
        [ProtoMember(3)]
        public int OwnerServerID = 0;

        /// <summary>
        /// 针对占据者的描述
        /// </summary>
        [ProtoMember(4)]
        public string OwnerDescription = "";

        /// <summary>
        /// 增加了国王的名字信息
        /// </summary>
        [ProtoMember(5)]
        public string KingName = "";

        /// <summary>
        /// 服务器名称
        /// </summary>
        [ProtoMember(6)]
        public string OwnerServerName = "";
        /// <summary>
        /// 国王战力值
        /// </summary>
        [ProtoMember(7)]
        public long KingCombat = 0;
        /// <summary>
        /// 联盟战力值
        /// </summary>
        [ProtoMember(8)]
        public long BhCombat = 0;

        /// <summary>
        /// 占据当前城池的联盟的名称
        /// </summary>
        [ProtoMember(9)]
        public string BhName = "";
    }
}
