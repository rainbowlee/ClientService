﻿using System.Collections.Generic;
using ProtoBuf;

namespace Server.Data
{
	/// <summary>
	/// 副本通关奖励数据
	/// </summary>
	[ProtoContract]
	public class FuBenTongGuanData
	{
		/// <summary>
		/// 副本的ID
		/// </summary>
		[ProtoMember(1)]
		public int FuBenID;

		/// <summary>
		/// 总得分
		/// </summary>
		[ProtoMember(2)]
		public int TotalScore;

		/// <summary>
		/// 击杀数
		/// </summary>
		[ProtoMember(3)]
		public int KillNum;

		/// <summary>
		/// 击杀得分
		/// </summary>
		[ProtoMember(4)]
		public int KillScore;

		/// <summary>
		/// 击杀满分值
		/// </summary>
		[ProtoMember(5)]
		public int MaxKillScore;

		/// <summary>
		/// 通关时间
		/// </summary>
		[ProtoMember(6)]
		public int UsedSecs;

		/// <summary>
		/// 通关时间得分
		/// </summary>
		[ProtoMember(7)]
		public int TimeScore;

		/// <summary>
		/// 通关时间满分值
		/// </summary>
		[ProtoMember(8)]
		public int MaxTimeScore;


		/// <summary>
		/// 死亡次数
		/// </summary>
		[ProtoMember(9)]
		public int DieCount;

		/// <summary>
		/// 死亡得分
		/// </summary>
		[ProtoMember(10)]
		public int DieScore;

		/// <summary>
		/// 四亡次数满分值
		/// </summary>
		[ProtoMember(11)]
		public int MaxDieScore;

		/// <summary>
		/// 抽奖物品列表
		/// </summary>
		[ProtoMember(12)]
		public List<int> GoodsIDList;

		/// <summary>
		/// 抽奖物品列表
		/// </summary>
		[ProtoMember(13)]
		public int AwardExp;

		/// <summary>
		/// 抽奖物品列表
		/// </summary>
		[ProtoMember(14)]
		public int AwardJinBi;

        /// <summary>
        /// 星魂奖励
        /// </summary>
        [ProtoMember(15)]
        public int AwardXingHun = 0;

		/// <summary>
		/// 奖品个数
		/// 抽奖物品列表中前GoodsCount个物品为奖品,总是1
		/// </summary>
		//[ProtoMember(15)]
		//public int GoodsCount;

	}
}
