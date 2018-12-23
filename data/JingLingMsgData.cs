using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 精灵客户端协议
    /// </summary>
    [ProtoContract]
    public class JingLingMsgData
    {
        [ProtoMember(1)]
        public int ErrorCode = 1;

        /// <summary>
        /// 0不处理，1入库，2出库，3升级，4出战
        /// </summary>
        [ProtoMember(2)]
        public int Type = 0;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public List<JingLingCData> data;
    }
    /// <summary>
    /// 精灵数据
    /// </summary>
    [ProtoContract]
    public class JingLingCData
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
        public int Level= 1;

        /// <summary>
        /// 是否使用
        /// </summary>
        [ProtoMember(4)]
        public int Using = 0;

        /// <summary>
        /// 天赋属性
        /// </summary>
        [ProtoMember(5)]
        public int ExcellenceInfo = 0;

    }
}

