using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
	/// <summary>
	/// 增加一个怪物
	/// </summary>
	[ProtoContract]
	public class AddShouHuMonsterData
	{
		/// <summary>
		/// 当前的角色ID
		/// </summary>
		[ProtoMember(1)]
		public int Type = 0; // 0 npc 1 小怪 2 大怪 3 禁怪

		/// <summary>
		/// 当前的角色ID
		/// </summary>
		[ProtoMember(2)]
		public int RoleID = 0;

		/// <summary>
		/// 当前的生命值
		/// </summary>
		[ProtoMember(3)]
		public double LifeV = 0;

		/// <summary>
		/// 当前的生命值
		/// </summary>
		[ProtoMember(4)]
		public double MaxLifeV = 0;

		/// <summary>
		/// 扩展ID
		/// </summary>
		[ProtoMember(5)]
		public int ExtensionID = 0;

		/// <summary>
		/// 怪物头像展示名称或者URl路径
		/// </summary>
		[ProtoMember(6)]
		public string ImageUrl = "";

		/// <summary>
		/// x位置
		/// </summary>
		[ProtoMember(7)]
		public double X = 0;

		/// <summary>
		/// y
		/// </summary>
		[ProtoMember(8)]
		public double Y = 0;
	}

	/// <summary>
	/// 删除一个怪物
	/// </summary>
	[ProtoContract]
	public class RemoveShouHuMonsterData
	{
		/// <summary>
		/// 当前的角色ID
		/// </summary>
		[ProtoMember(1)]
		public int RoleID = 0;
	}

	/// <summary>
	/// 更新一个怪物
	/// </summary>
	[ProtoContract]
	public class UpdateShouHuMonsterData
	{
		/// <summary>
		/// 当前的角色ID
		/// </summary>
		[ProtoMember(1)]
		public int RoleID = 0;
		/// <summary>
		/// 更新类型
		/// </summary>
		[ProtoMember(2)]
		public int Type = 0;
		/// <summary>
		/// 当前的生命值
		/// </summary>
		[ProtoMember(3)]
		public double LifeV = 0;
	}

	/// <summary>
	/// 守护通知消息
	/// </summary>
	[ProtoContract]
	public class ShouHuMsgData
	{
		/// <summary>
		///	npcmsg
		/// </summary>
		[ProtoMember(1)]
		public List<int> npcMsgs = null;

		/// <summary>
		/// systip
		/// </summary>
		[ProtoMember(2)]
		public int sysTip = 0;
	}
}