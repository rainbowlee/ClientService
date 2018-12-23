using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 全局公共数据
    /// </summary>
    [ProtoContract]
    public class GlobalLogicParam
    {
        /// <summary>
        /// 数据类型组
        /// </summary>
        [ProtoMember(1)]
        public string ServiceType;
       
        /// <summary>
        /// 数据key
        /// </summary>
        [ProtoMember(2)]
        public string ParamName = "";

        /// <summary>
        /// 数据value
        /// </summary>
        [ProtoMember(3)]
        public string ParamValue;
    }

    /// <summary>
    ///从gs到db的GM数据体
    ///
    /// </summary>
    [ProtoContract]
    public class GlobalGMData
    {


        /// <summary>
        /// 执行的方法
        /// </summary>
        [ProtoMember(1)]
        public string MethonName;

        /// <summary>
        /// 方法的参数
        /// </summary>
        [ProtoMember(2)]
        public string[] MethonParams;

        /// <summary>
        /// roleID
        /// </summary>
        [ProtoMember(3)]
        public int RoleID;


    }

}
