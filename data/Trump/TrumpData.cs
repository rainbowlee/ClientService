using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 法宝数据
    /// </summary>
    [ProtoContract]
    public class TrumpData
    {
        /// <summary>
        /// 法宝的数据库ID
        /// </summary>
        [ProtoMember(1)]
        public int DbID = 0;

        /// <summary>
        /// 法宝当前最高阶数
        /// </summary>
        [ProtoMember(2)]
        public int MaxTrumpID = 0;

        /// <summary>
        /// 当前穿戴的法宝阶数，0为没有穿戴
        /// </summary>
        [ProtoMember(3)]
        public int  UsingTrumpID = 0;

        /// <summary>
        /// 升星的等级数
        /// </summary>
        [ProtoMember(4)]
        public int StarLevel = 0;

        /// <summary>
        /// 升星经验值
        /// </summary>
        [ProtoMember(5)]
        public int StarExp = 0;

        /// <summary>
        /// 本次进阶成功前失败的次数
        /// </summary>
        [ProtoMember(6)]
        public int  BlessExp = 0;

        /// <summary>
        /// 是否在封印状态封印,0在，1不在
        /// </summary>
        [ProtoMember(7)]
        public int IsLiftSeal = 0;

    }
}