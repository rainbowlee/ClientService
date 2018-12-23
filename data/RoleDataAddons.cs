using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 玩家bi附加data
    /// </summary>
    [ProtoContract]
    public class RoleDataAddons
    {
        /// <summary>
        /// 当前的PuID,渠道标识唯一ID
        /// </summary>
        [ProtoMember(1)]
        public string PuID = "";

        /// <summary>
        /// 当前角色的设备ID
        /// </summary>
        [ProtoMember(2)]
        public string DeviceId = "";

        /// <summary>
        /// 用户注册时的Ip地址
        /// </summary>
        [ProtoMember(3)]
        public string FirstLoginIp = "";

        /// <summary>
        /// 角色最后登录时间
        /// </summary>
        [ProtoMember(4)]
        public string LastLoginTime = "";

        /// <summary>
        /// 角色最后登录IP
        /// </summary>
        [ProtoMember(5)]
        public string LastLoginIp = "";

        /// <summary>
        /// 手机操作系统
        /// </summary>
        [ProtoMember(6)]
        public string Osversion = "";

        /// <summary>
        /// 设备型号
        /// </summary>
        [ProtoMember(7)]
        public string Phonetype = "";

        /// <summary>
        /// 系统语言
        /// </summary>
        [ProtoMember(8)]
        public string Language = "";

        /// <summary>
        /// 系统类型
        /// </summary>
        [ProtoMember(9)]
        public string Phoneos = "";

        /// <summary>
        /// 注册时的服务器ID
        /// </summary>
        [ProtoMember(10)]
        public string Server = "";

        /// <summary>
        /// 新手引导
        /// </summary>
        [ProtoMember(11)]
        public int Tutoriastep = 0;

        /// <summary>
        /// VIP等级
        /// </summary>
        [ProtoMember(12)]
        public int VipLevel = 0;

        /// <summary>
        /// 渠道
        /// </summary>
        [ProtoMember(13)]
        public string Channel = "";

        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(14)]
        public int Rid = 0;

		/// <summary>
		/// idfa
		/// </summary>
		[ProtoMember(15)]
		public string Idfa = "";
    }
}
