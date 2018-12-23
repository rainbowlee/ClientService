using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
	//Leaguage 请求db服务器时，gs发送的数据
	[ProtoContract]
	public class LeagueActivityDataReq
	{
		/// <summary>
		/// 帮会id
		/// </summary>
		[ProtoMember(1)]
		public int factionId;

		/// <summary>
		/// 活动id
		/// </summary>
		[ProtoMember(2)]
		public int activityType;
	}

	[ProtoContract]
	public class LeagueActivityQueryData
	{
		/// <summary>
		/// 帮会id
		/// </summary>
		[ProtoMember(1)]
		public int factionId;

		/// <summary>
		/// 活动id
		/// </summary>
		[ProtoMember(2)]
		public int activityType;

		/// <summary>
		/// 活动level
		/// </summary>
		[ProtoMember(3)]
		public int activityLevel;

		/// <summary>
		/// openday
		/// </summary>
		[ProtoMember(4)]
		public int openDay;

		/// <summary>
		/// 结果
		/// </summary>
		[ProtoMember(5)]
		public int result;

		/// <summary>
		/// 存在数据与否
		/// </summary>
		[ProtoMember(6)]
		public int hasData;

		/// <summary>
		/// timecost
		/// </summary>
		[ProtoMember(7)]
		public int timecost;
	}

	[ProtoContract]
	public class LeagueActivityOpenReq
	{
		/// <summary>
		/// 帮会id
		/// </summary>
		[ProtoMember(1)]
		public int factionId;

		/// <summary>
		/// 活动id
		/// </summary>
		[ProtoMember(2)]
		public int activityType;

		/// <summary>
		/// openday
		/// </summary>
		[ProtoMember(3)]
		public int openday;

		/// <summary>
		/// roleId 做权限判断，存在判断
		/// </summary>
		[ProtoMember(4)]
		public int roleId;
	}

	//公会活动结果
	[ProtoContract]
	public class LeagueActivityResultReq
	{
		/// <summary>
		/// 帮会id
		/// </summary>
		[ProtoMember(1)]
		public int factionId;

		/// <summary>
		/// 活动id
		/// </summary>
		[ProtoMember(2)]
		public int activityType;

		/// <summary>
		/// openday
		/// </summary>
		[ProtoMember(3)]
		public int result;

		/// <summary>
		/// openday
		/// </summary>
		[ProtoMember(4)]
		public int level;

		/// <summary>
		/// timecost
		/// </summary>
		[ProtoMember(5)]
		public int timecost;
	}

	[ProtoContract]
	public class LeagueActivityUpdateData
	{
		/// <summary>
		/// 返回值
		/// </summary>
		[ProtoMember(1)]
		public int code;

		/// <summary>
		/// 帮会id
		/// </summary>
		[ProtoMember(2)]
		public int factionId;

		/// <summary>
		/// 活动id
		/// </summary>
		[ProtoMember(3)]
		public int activityType;

		/// <summary>
		/// 活动level
		/// </summary>
		[ProtoMember(4)]
		public int level;

		/// <summary>
		/// 活动result
		/// </summary>
		[ProtoMember(5)]
		public int result;

		/// <summary>
		/// timecost
		/// </summary>
		[ProtoMember(6)]
		public int timecost;
	}
}
