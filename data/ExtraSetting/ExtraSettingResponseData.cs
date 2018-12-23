using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 其他设置的响应类
    /// </summary>
    [ProtoContract]
    public class ExtraSettingResponseData
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;
        /// <summary>
        /// 响应的操作类型
        /// 1.表示请求打开GM面板
        /// 
        /// </summary>
        [ProtoMember(2)]
        public int OperateType = 0;
        /// <summary>
        /// 响应结果
        /// true表示响应成功
        /// false表示响应请求失败
        /// </summary>
        [ProtoMember(3)]
        public bool Status = false;
    }
}
