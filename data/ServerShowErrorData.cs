using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Server.Data
{
    [ProtoContract]
    public class ServerShowErrorData 
    {
        /// <summary>
        /// //错误码窗体类型
        /// 1,仅仅闪出提示，不阻塞游戏
        /// 2，弹窗，点击确定后 ，关闭弹窗。
        /// 3，弹窗，点击确定后，客户端强退
        /// </summary>
        [ProtoMember(1)]
        public int type;
        /// <summary>
        /// 错误码内容
        /// </summary>
        [ProtoMember(2)]
        public string errorMsg;
        /// <summary>
        /// 错误码数字
        /// </summary>
        [ProtoMember(3)]
        public int errorCode;
    }
}

