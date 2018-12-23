using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class WSJewelHolesInfoData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [ProtoMember(1)]
        public int ErroCode;
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(2)]
        public int RoleID;
        /// <summary>
        /// 操作类型
        /// </summary>
        [ProtoMember(3)]
        public int OperIndex;
        /// <summary>
        /// 提升的总战斗力
        /// </summary>
        [ProtoMember(4)]
        public int TotalCombace;
        /// <summary>
        /// 属性
        /// </summary>
        [ProtoMember(5)]
        public Dictionary<int,double> TotalPropertys = new Dictionary<int,double>();
        /// <summary>
        /// key 装备位置ID，value 数据对象
        /// </summary>
        [ProtoMember(6)]
        public Dictionary<int, WSJewelHoleData> DataDic = new Dictionary<int,WSJewelHoleData>();
    }
}
