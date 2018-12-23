using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Server.Data
{
    [ProtoContract]
    public class BangHuiLiBaoData
    {
        [ProtoMember(1)]
        public int OperateType;  //操作类型： 1，查询   2，分配礼包提交    3，领取礼包
        [ProtoMember(2)]
        public int IsKingBanghui; //是不是国王帮 0否  1是
		[ProtoMember(3)]
		public int IsSendGift;//是否已经分发礼包 0:未，1：已经分发
        [ProtoMember(4)]
        public int BanghuiLiBaoState;   //当前帮会礼包类型    0，无，  1，修身   2，养性
        [ProtoMember(5)]
        public int IsKing;//是否是国王：0，不是；1，是国王
        [ProtoMember(6)]
        public List<BangHuiFenPeiData> fenPeiList;   //国王分配的名单
        [ProtoMember(7)]
        public int errorCode;  //错误码 
    }
    [ProtoContract]
    public class BangHuiFenPeiData
    {
        [ProtoMember(1)]
        public int id;  //群成员ID
        [ProtoMember(2)]
        public int LiBaoType;  // 1修身  2养性
    }
}


