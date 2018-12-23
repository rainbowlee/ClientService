using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 提炼数据
    /// </summary>
    [ProtoContract]
    public class RefineData
    {
        [ProtoMember(1)]
        public int Rid;

        /// <summary>
        /// 元素之心粉尘
        /// </summary>
        [ProtoMember(2)]
        public int ElementDust = 0;

        /// <summary>
        /// 提炼位置数据
        /// </summary>
        [ProtoMember(3)]
        public int RefinePos = 1;

        /// <summary>
        /// 灵晶
        /// </summary>
        [ProtoMember(4)]
        public int LingJing;

        /// <summary>
        /// 精灵积分
        /// </summary>
        [ProtoMember(5)]
        public int JingLingJiFen;

        /// <summary>
        /// 精灵免费抽取上去时间
        /// </summary>
        [ProtoMember(6)]
        public long FreeJingLingCall;


    }

    /// <summary>
    /// 元素之心
    /// </summary>
    [ProtoContract]
    public class ElementHeartData
    {
        /// <summary>
        /// 元素之心ID
        /// </summary>
        [ProtoMember(1)]
        public int ID = 0;

        /// <summary>
        /// goodID
        /// </summary>
        [ProtoMember(2)]
        public int GoodsID;

        /// <summary>
        /// rid
        /// </summary>
        [ProtoMember(3)]
        public int Rid;

        /// <summary>
        /// 等级
        /// </summary>
        [ProtoMember(4)]
        public int Level = 1;

        /// <summary>
        /// 经验
        /// </summary>
        [ProtoMember(5)]
        public int Exp;

        /// <summary>
        /// 背包位置
        /// </summary>
        [ProtoMember(6)]
        public int BagIndex;

        /// <summary>
        /// 是否佩戴
        /// </summary>
        [ProtoMember(7)]
        public int Using;

        public ElementCData getElmentCData()
        {
            ElementCData data = new ElementCData
            {
                Id = this.ID,
                GoodsID = this.GoodsID,
                Level = this.Level,
                exp = this.Exp,
                BagIndex = this.BagIndex,
                UsingIndex = this.Using
            };
            return data;
        }

    }

}
