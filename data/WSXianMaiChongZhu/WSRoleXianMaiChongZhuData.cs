using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data.WSXianMaiChongZhu
{
    /// <summary>
    /// 我欲封天角色仙脉重铸数据
    /// </summary>
    [ProtoContract]
    public class WSRoleXianMaiChongZhuData
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;
        /// <summary>
        /// 仙脉ID
        /// </summary>
        [ProtoMember(2)]
        public int XianMaiID = 0;
        /// <summary>
        /// 天罡ID
        /// </summary>
        [ProtoMember(3)]
        public int TianGangID = 0;
        /// <summary>
        /// 天罡属性ID
        /// </summary>
        [ProtoMember(4)]
        public int TianGangPropertyID = 0;
        /// <summary>
        /// 临时的天罡ID
        /// </summary>
        [ProtoMember(5)]
        public int TempTianGangID = 0;
        /// <summary>
        /// 临时的天罡属性ID
        /// </summary>
        [ProtoMember(6)]
        public int TempTianGangPropertyID = 0;
    }
}
