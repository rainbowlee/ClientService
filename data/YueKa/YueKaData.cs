using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data.YueKa
{
	//TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
	//TimeSpan ts2 = new TimeSpan(DateTime.Now.AddDays(-2).AddHours(-1).Ticks );
	//TimeSpan ts = ts2.Subtract(ts1);
	//ts.days 天数


	//月卡道具记录
	[ProtoContract]
	public class YueKaDataItem
	{
		/// <summary>
		/// 月卡db ID
		/// </summary>
		[ProtoMember(1)]
		public int yueKaDbId;

		/// <summary>
		/// 玩家ID
		/// </summary>
		[ProtoMember(2)]
		public int roleId;

		/// <summary>
		/// 开始使用tick
		/// </summary>
		[ProtoMember(3)]
		public long openTick;

		/// <summary>
		/// 获得时间tick
		/// </summary>
		[ProtoMember(4)]
		public long obtainTick;

		/// <summary>
		/// 上次获取道具tick
		/// </summary>
		[ProtoMember(5)]
		public long lastGetItemTick;

		/// <summary>
		/// 月卡配置表数据
		/// </summary>
		[ProtoMember(6)]
		public int yueKaId;
	}

	//月卡数据
	[ProtoContract]
	public class YueKaData
	{
		/// <summary>
		/// 玩家ID
		/// </summary>
		[ProtoMember(1)]
		public int roleId;

		/// <summary>
		/// 月卡项目列表
		/// </summary>
		[ProtoMember(2)]
		public List<YueKaDataItem> yueDataItems;
	}

	//server-->dbserver
	//月卡
	[ProtoContract]
	public class YueKaAddData
	{
		/// <summary>
		/// 玩家ID
		/// </summary>
		[ProtoMember(1)]
		public int roleId;

		/// <summary>
		/// 月卡ID
		/// </summary>
		[ProtoMember(2)]
		public int yueKaId;

		/// <summary>
		/// 获得时间tick
		/// </summary>
		[ProtoMember(3)]
		public long obtainTick;

	}

	//server-->dbserver
	//月卡
	[ProtoContract]
	public class YueKaUpdateData
	{
		/// <summary>
		/// 玩家ID
		/// </summary>
		[ProtoMember(1)]
		public int roleId;

		/// <summary>
		/// 月卡ID
		/// </summary>
		[ProtoMember(2)]
		public int yueKaDBId;

		/// <summary>
		/// opcode
		/// </summary>
		[ProtoMember(3)]
		public int opcode; //操作码 0 更新ticks 1 删除

		/// <summary>
		/// opentick
		/// </summary>
		[ProtoMember(4)]
		public long openTick;

		/// <summary>
		/// lastgetitemtick
		/// </summary>
		[ProtoMember(5)]
		public long lastGetItemTick;
	}

	[ProtoContract]
	public class YueKaResultData
	{
		/// <summary>
		/// 玩家ID
		/// </summary>
		[ProtoMember(1)]
		public int roleId;

		/// <summary>
		/// 月卡ID
		/// </summary>
		[ProtoMember(2)]
		public int yueKaDBId;

		/// <summary>
		/// resultcode
		/// </summary>
		[ProtoMember(3)]
		public int code;

	}
}
