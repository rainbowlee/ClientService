using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 充值配置
    /// </summary>
    [ProtoContract]
    public class ChongZhiConfigItem
    {

        public static String BASE_CHANNEL = "ANDROID";

        //	  <ChongZhi ID="1" Icon="1" RMB="6" ZuanShi="60" FirstBindZuanShi="60" 
        //productId="com.com4loves.qmws.mi.product01" productName="60" />

        /// <summary>
        ///商品id
        /// </summary>
        [ProtoMember(1)]
        public String productId=null;

        
        /// <summary>
        /// 商品名称
        /// </summary>
        [ProtoMember(2)]
        public String productName=null;


        /// <summary>
        /// 标示id
        /// </summary>
        [ProtoMember(3)]
        public int ID = 0;


        /// <summary>
        /// 图片icon
        /// </summary>
        [ProtoMember(4)]
        public int Icon = 0;


        /// <summary>
        /// 首次充值
        /// </summary>
        [ProtoMember(5)]
        public int FirstBindZuanShi = 0;


        /// <summary>
        /// 对应的人民币价格
        /// </summary>
        [ProtoMember(6)]
        public int RMB = 0;

        /// <summary>
        /// 类型
        /// </summary>
        [ProtoMember(7)]
        public int Type = -1;


        /// <summary>
        /// 钻石数量
        /// </summary>
        [ProtoMember(8)]
        public int ZuanShi = 0;

		/// <summary>
		/// 是否现金购买显示
		/// </summary>
		[ProtoMember(9)]
		public int IsShow = 0;

	}
}
