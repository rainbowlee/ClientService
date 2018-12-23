using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 精灵移动数据封装类
    /// </summary>
    [ProtoContract]
    public class DeviceAndRoleInfoData
    {
        //private static SpriteMoveData instance = new SpriteMoveData();
        public DeviceAndRoleInfoData() { }
        [ProtoMember(1)]
        public string puid = "";

        [ProtoMember(2)]
        public int roleID = 0;

        [ProtoMember(3)]
        public string roleName = "";

        [ProtoMember(4)]
        public int roleLevel = 0;
        /// <summary>
        /// 钻石
        /// </summary>
        [ProtoMember(5)]
        public int roleDiamond = 0;
        /// <summary>
        /// 绑钻
        /// </summary>
        [ProtoMember(6)]
        public int roleBindDiamond= 0;
        /// <summary>
        /// 金币
        /// </summary>
        [ProtoMember(7)]
        public int roleGold = 0;
        /// <summary>
        /// 绑钻
        /// </summary>
        [ProtoMember(8)]
        public int roleBindGold = 0;
        [ProtoMember(9)]
        public string IMEI = "";
        [ProtoMember(10)]
        public string mac = "";
        [ProtoMember(11)]
        public string systemtype = "";
        [ProtoMember(12)]
        public string lang = "";
        [ProtoMember(13)]
        public string phoneVersion = "";
        [ProtoMember(14)]
        public string model = "";
        [ProtoMember(15)]
        public string bundleId = "";
        [ProtoMember(16)]
        public int roleVipLevel = 0;
		[ProtoMember(17)]
		public int roleZoneID = 0;
    }
}
