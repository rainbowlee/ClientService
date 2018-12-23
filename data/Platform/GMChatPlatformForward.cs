using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Platform.Forward
{
    /// <summary>
    /// 消息类型PB
    /// </summary>
    [ProtoContract]
    public enum GMChatErrorCode
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoEnum]
        SUCCESS = 0,
        /// <summary>
        /// 
        /// </summary>
        [ProtoEnum]
        PACK_ERROR = 1,
        /// <summary>
        /// 内部错误
        /// </summary>
        [ProtoEnum]
        SYS_BUYS = 2
    }

    [ProtoContract]
    public class GMChatHeadMeta
    {
        [ProtoContract]
        public enum Type 
        {
            /// <summary>
            /// 
            /// </summary>
            [ProtoEnum]
            REQUEST = 0,
            /// <summary>
            /// 
            /// </summary>
            [ProtoEnum]
            RESPONESE = 1,
        }
        [ProtoMember(1)]
        public Type type;
        [ProtoMember(2,IsRequired=true)]
        public long sequence_id = 0;
        /// <summary>
        /// 消息类型
        /// </summary>
        [ProtoMember(3,IsRequired=true)]
        public string method = "GameChat";

        [ProtoMember(50)]
        public string appId;
        [ProtoMember(51)]
        public string userIp;
        [ProtoMember(52,IsRequired=true)]
        public long callTime = 0;
        [ProtoMember(53)]
        public string receiveIp="";
        [ProtoMember(54)]
        public int receivePort = 0;

        [ProtoMember(100)]
        public bool failed;
        [ProtoMember(101)]
        public int errorCode;
        [ProtoMember(102)]
        public string reason;

    }


    [ProtoContract]
    public class GMChatResponse
    {

    }
}
