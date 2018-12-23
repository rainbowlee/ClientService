using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ProtoBuf;

namespace Server.Data
{
    [ProtoContract]
    public class WSJewelHoleData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [ProtoMember(1)]
        public int ErroCode = 1;
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(2)]
        public int RoleID;
        /// <summary>
        /// ID(武器部位ID)
        /// </summary>
        [ProtoMember(3)]
        public int ID;
        /// <summary>
        /// 已经打开的孔下标
        /// </summary>
        [ProtoMember(4)]
        public int OpenIndex;
        /// <summary>
        /// 已经连接的下标
        /// </summary>
        [ProtoMember(5)]
        public int LinkIndex;
        /// <summary>
        /// 镶嵌在孔上的宝石ID
        /// </summary>
        [ProtoMember(6)]
        public Dictionary<int, int> GoodsID = new Dictionary<int,int>();
    }
}
