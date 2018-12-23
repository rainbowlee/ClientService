using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.Kuafu
{
    /// <summary>
    /// 地块关联关系数据
    /// </summary>
    [ProtoContract]
    public class BlockRelation
    {
        /// <summary>
        /// 较小的块的ID
        /// </summary>
        [ProtoMember(1)]
        public int firstBlockId = 0;

        /// <summary>
        /// 相邻的块的ID
        /// </summary>
        [ProtoMember(2)]
        public int secondBlockId = 0;
    }
}
