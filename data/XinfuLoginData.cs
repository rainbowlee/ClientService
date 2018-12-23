using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Server.Data
{
    /// <summary>
    /// 新服7日活动 限时VIP购买 item数据
    /// </summary>
    [ProtoContract]
    public class XinfuLoginData
    {
      [ProtoMember(1)]
       public List<XinfuLoginItemData> itemData; 
    }
    [ProtoContract]
    public class XinfuLoginItemData
    {
        [ProtoMember(1)]
        public int ItemID = 0;  //表ID
        [ProtoMember(2)]
        public int day = -1; //第几天
        [ProtoMember(3)]
        public string GoodsStr = "";
        [ProtoMember(4)]
        public int state = -1;   // 0不可领取  1可领取 2已领取
    }
    
}

