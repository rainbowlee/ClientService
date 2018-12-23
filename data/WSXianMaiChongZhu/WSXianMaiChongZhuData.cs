using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;


namespace Server.Data.WSXianMaiChongZhu
{
    /// <summary>
    /// 我欲封天仙脉功能
    /// </summary>
    [ProtoContract]
    public class WSXianMaiChongZhuData
    {
        /// <summary>
        /// 星脉ID
        /// </summary>
        [ProtoMember(1, IsRequired = true)]
        public int XianMaiID = -1;

        /// <summary>
        /// 星ID，用来表示 诸如天罡星，天杀星，天狼星等等.....
        /// </summary>
        [ProtoMember(2, IsRequired = true)]
        public int TianGangID = -1;
        /// <summary>
        /// 临时附加属性的数值ID。客户端从表里面读对应的值，然后显示
        /// </summary>
        [ProtoMember(3, IsRequired = true)]
        public double DecreaseInjurePercentValue = -1;
        /// <summary>
        /// 减免伤害职业
        /// </summary>
        [ProtoMember(4, IsRequired = true)]
        public int DescresInjureOccupation = -1;

        /// <summary>
        /// 零时星ID，用来表示 诸如天罡星，天杀星，天狼星等等.....
        /// 与StarIdentifyingID的区别是用作羡慕重铸
        /// </summary>
        [ProtoMember(5, IsRequired = true)]
        public int TempTianGangID = -1;
        /// <summary>
        /// 零时附加属性的数值ID。客户端从表里面读对应的值，然后显示
        /// 与StarValueIdentifyingID的区别是用作仙脉重铸
        /// </summary>
        [ProtoMember(6, IsRequired = true)]
        public double TempDecreaseInjurePercentValue = -1;
        /// <summary>
        /// 减免伤害职业
        /// </summary>
        [ProtoMember(7, IsRequired = true)]
        public int TempDescresInjureOccupation = -1;
        /// <summary>
        /// 错误码表示方式
        /// </summary>
        [ProtoMember(8, IsRequired = true)]
        public int ErroCode = 1;
    }
}
