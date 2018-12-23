using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.Caiji
{
    /// <summary>
    /// 采集数据
    /// </summary>
     [ProtoContract]
    public class CaijiData
    {
        /// <summary>
        /// 副本地图的ID
        /// </summary>
        [ProtoMember(1)]
        public int FuBenID;

        /// <summary>
        /// 日期ID
        /// </summary>
        [ProtoMember(2)]
        public int DayID;

        /// <summary>
        /// 今日采集个数
        /// </summary>
        [ProtoMember(3)]
        public int GetNum;

        /// <summary>
        /// 最大可以采集数据
        /// </summary>
        [ProtoMember(4)]
        public int MaxGetNum;
    }
}
