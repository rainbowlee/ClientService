using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Platform.Forward
{
    /// <summary>
    /// 聊天类型
    /// </summary>
    [ProtoContract]
    public enum GMChatClass
    {
        /// <summary>
        /// 文字或者表情
        /// </summary>
        [ProtoEnum]
        TextOrSymbol = 0,
        /// <summary>
        /// 语音
        /// </summary>
        [ProtoEnum]
        Voice = 1
    }
    /// <summary>
    /// 聊天范围
    /// </summary>
    [ProtoContract]
    public enum GMChatType
    {
        /// <summary>
        /// 世界聊天
        /// </summary>
        [ProtoEnum]
        Toword = 1,
        /// <summary>
        /// 单用户
        /// </summary>
        [ProtoEnum]
        ToUser = 2,
        /// <summary>
        /// 组队
        /// </summary>
        [ProtoEnum]
        ToTeam = 3,
        /// <summary>
        /// 帮会聊天
        /// </summary>
        [ProtoEnum]
        ToFaction = 4
    }

    [ProtoContract]
    public class GMChatPlayer
    {
        [ProtoMember(1,IsRequired = true)]
        public string puid = "";
        [ProtoMember(2,IsRequired = true)]
        public string roleId = "";
        [ProtoMember(3,IsRequired = true)]
        public string roleName = "";
        [ProtoMember(4,IsRequired = true)]
        public int vipLevel = 0;
        [ProtoMember(5,IsRequired = true)]
        public int level = 1;
    }


    [ProtoContract]
    public class GMChatLeague
    {
        [ProtoMember(1,IsRequired=true)]
        public string name = "";
        [ProtoMember(2,IsRequired=true)]
        public string id = "";
        [ProtoMember(3,IsRequired=true)]
        public int userCount = 0;
    }


    [ProtoContract]
    public class GMChatTeam
    {
        [ProtoMember(1,IsRequired=true)]
        public string name = "";
        [ProtoMember(2,IsRequired=true)]
        public string id = "";
        [ProtoMember(3,IsRequired=true)]
        public int userCount = 0;
    }

    /// <summary>
    /// 陪聊PB
    /// </summary>
    [ProtoContract]
    public class GMChatMessage
    {
        /// <summary>
        /// 服务器ID
        /// </summary>
        [ProtoMember(1,IsRequired=true)]
        public string serverId = "";
        /// <summary>
        /// 用户在线数
        /// </summary>
        [ProtoMember(2)]
        public int onlineCount = 0;
        /// <summary>
        /// 消息类型
        /// </summary>
        [ProtoMember(3,IsRequired=true)]
        public GMChatType type = GMChatType.ToUser;
        /// <summary>
        /// 发送人
        /// </summary>
        [ProtoMember(4,IsRequired=true)]
        public GMChatPlayer fromPlayer;
        /// <summary>
        /// 发送给好友时填写
        /// </summary>
        [ProtoMember(5)]
        public GMChatPlayer toPlayer;
        /// <summary>
        /// 联盟消息
        /// </summary>
        [ProtoMember(6)]
        public GMChatLeague toLeague;
        /// <summary>
        /// Team消息
        /// </summary>
        [ProtoMember(7)]
        public GMChatTeam toTeam;
        /// <summary>
        /// 消息发送时间
        /// </summary>
        [ProtoMember(8,IsRequired=true)]
        public long time = 0L;
        /// <summary>
        /// 聊天内容
        /// </summary>
        [ProtoMember(9,IsRequired=true)]
        public string content = "";
        /// <summary>
        /// 语音url
        /// </summary>
        [ProtoMember(10,IsRequired=true)]
        public string voiceUrl="";
        /// <summary>
        /// 聊天类型
        /// </summary>
        [ProtoMember(11,IsRequired=true)]
        public GMChatClass chatClass = GMChatClass.TextOrSymbol;
        /// <summary>
        /// 语音时长
        /// </summary>
        [ProtoMember(12)]
        public float clipTime;
        /// <summary>
        /// 语音文本
        /// </summary>
        [ProtoMember(13)]
        public string voiceText="";
    }
}
