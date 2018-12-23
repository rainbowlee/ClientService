using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 操作OP
    /// </summary>
    public enum JINGLING_OP
    {
        NONE,
        ADD,
        UPDATE,
        REMOVE
    }
    /// <summary>
    /// 精灵操作传输数据
    /// </summary>
    [ProtoContract]
    public class JingLingOPData
    {

        [ProtoMember(1)]
        public JINGLING_OP OP = 0;

        [ProtoMember(2)]
        public JingLingData data;

    }





    /// <summary>
    /// 精灵数据
    /// </summary>
    [ProtoContract]
    public class JingLingData
    {
        /// <summary>
        /// 精灵的数据库ID
        /// </summary>
        [ProtoMember(1)]
        public int ID = 0;

        /// <summary>
        /// 精灵ID
        /// </summary>
        [ProtoMember(2)]
        public int GoodsID = 0;

        /// <summary>
        /// 精灵等级
        /// </summary>
        [ProtoMember(3)]
        public int Level = 1;

        /// <summary>
        /// 是否使用
        /// </summary>
        [ProtoMember(4)]
        public int Using = 0;

        /// <summary>
        /// 角色Rid
        /// </summary>
        [ProtoMember(5)]
        public int Rid = 0;

        /// <summary>
        /// 天赋属性
        /// </summary>
        [ProtoMember(6)]
        public int ExcellenceProperty = 0;

    }
}

