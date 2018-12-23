using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 其他设置请求对象
    /// </summary>
    [ProtoContract]
    public class ExtraSettingRequestData
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;
        /// <summary>
        /// 请求操作类型
        /// 1.表示请求打开GM面板
        /// </summary>
        [ProtoMember(2)]
        public int OperateType = 0;
    }
}
