using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    //推广data
    [ProtoContract]
    public class TuiGuangData
    {
        /// <summary>
        /// 操作类型 1查询 2成为邀请员  3,注入他人的邀请码 4 领取奖励 
        /// </summary>
        [ProtoMember(1)]
        public int oprateType = 0;
        /// <summary>
        /// 是否是邀请员
        /// </summary>
        [ProtoMember(2)]
        public bool isHasRole = false;
        /// <summary>
        /// 自己的推广码
        /// </summary>
        [ProtoMember(3)]
        public String tuiGuanCode = "-1";

        /// <summary>
        /// 别人的推广码
        /// </summary>
        [ProtoMember(4)]
        public String OtherGuiGuangCode = "-1";
        /// <summary>
        /// 可获取的绑定钻石
        /// </summary>
        [ProtoMember(5)]
        public int bindingDiamond = 0;
        /// <summary>
        /// 操作错误码  1为成功 剩下的后端定
        /// </summary>
        [ProtoMember(6)]
        public int errorCode = 1;

        /// <summary>
        /// 推广员id
        /// </summary>
        [ProtoMember(7)]
        public int tgRoleID = 0;

    }

}
   
