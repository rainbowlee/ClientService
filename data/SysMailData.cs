using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 邮件项数据
    /// </summary>
    [ProtoContract]
    public class SysMailData
    {
        /// <summary>
        /// MailID
        /// </summary>
        [ProtoMember(1)]
        public int MailID = 0;
       
        /// <summary>
        /// 邮件主题
        /// </summary>
        [ProtoMember(2)]
        public string Subject = "";

        /// <summary>
        /// 内容,最多字符数由程序内部控制字符
        /// </summary>
        [ProtoMember(3)]
        public string Content = "";

        /// <summary>
        /// YinLiang
        /// </summary>
        [ProtoMember(4)]
        public int YinLiang = 0;

        /// <summary>
        /// TongQian
        /// </summary>
        [ProtoMember(5)]
        public int TongQian = 0;

        /// <summary>
        /// YuanBao
        /// </summary>
        [ProtoMember(6)]
        public int YuanBao = 0;

        /// <summary>
        /// Goods
        /// </summary>
        [ProtoMember(7)]
        public string Goods = "";

        /// <summary>
        /// Reward
        /// </summary>
        [ProtoMember(8)]
        public string Params = "";
    }
}
