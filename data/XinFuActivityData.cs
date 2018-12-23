using System;
using System.Net;
using System.Collections.Generic;
using ProtoBuf;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Server.Data
{

    [ProtoContract]
    public enum ActivitStates
    {

        STATE_SUCC = 1,//成功
        STATE_ACT_CLOSE = -1,//活动关闭
        STATE_ACT_Rewarded = -2//已经领取奖励

    }

    /// <summary>
    /// 玩家扮演的角色的数据定义
    /// </summary>
    [ProtoContract]
    public class XinFuActivityData
    {
        /// <summary>
        /// 当前的活动ID
        /// </summary>
        [ProtoMember(1)]
        public int AcitivityID = 0;
        /// <summary>
        /// 当前的进行天数
        /// </summary>
        [ProtoMember(2)]
        public int CurrentProcessDay = -1;
        /// <summary>
        /// 当前活动的状态码
        /// </summary>
        [ProtoMember(3)]
        public int ActivityStateCode = 0;
        [ProtoMember(4)]
        public ActivityOfDayConditon activityOfDayCondition = null;
        [ProtoMember(5)]
        public ActivityOfDayRanking activityOfDayRanking = null;
        [ProtoMember(6)]
        public ActivityOfDeadLineCondition activityOfDeadLineCondition = null;
        [ProtoMember(7)]
        public ActivityOfDeadLineRanking activityOfDeadLineRanking = null;
        [ProtoMember(8)]
        public ActivityOfDayTask activityOfDayTask = null;
        [ProtoMember(9)]
        public ActivityOfBindingPlayer activityOfBindingPlayer = null;
        //[ProtoMember(10)]
        //public List<WSDailyTaskActivity> wsDailyTaskActivity = null;
    }
    /// <summary>
    /// 当天 条件领取   如每日登陆和每日充值
    /// </summary>
    [ProtoContract]
    public class ActivityOfDayConditon
    {
        /// <summary>
        /// 累计参与天数
        /// </summary>
        [ProtoMember(1)]
        public int ContinuePartInDays;

        /// <summary>
        /// 是否可以获取最终大奖  条件不足 或者 领取过 为false
        /// </summary>
        [ProtoMember(2)]
        public int CanGetFinalGift = 0;
        /// <summary>
        /// 每天的领取状态
        /// </summary>
        [ProtoMember(3)]
        public List<XinFuActivityItemData> ItemStateList;
    }
    /// <summary>
    /// 当天 排行领取  如 劲爆返利
    /// </summary>
    [ProtoContract]
    public class ActivityOfDayRanking
    {
        /// <summary>
        /// 活动当前的数值  比如 累计充值数额
        /// </summary>
        [ProtoMember(1)]
        public int ContinueActivityValue;
        /// <summary>
        /// 活动排名
        /// </summary>
        [ProtoMember(2)]
        public int RankingPos;
        /// <summary>
        /// 是否可以获取当天大奖  条件不足 或者 领取过 为false
        /// </summary>
        [ProtoMember(3)]
        public int CanGetCurrentGift = -1;
        /// <summary>
        /// 当前的可领取时间 时间单位（秒 毫秒）由服务器定
        /// </summary>
        [ProtoMember(4)]
        public long LeftTime;
        ///// <summary>
        ///// 排行榜的数据
        ///// </summary>
        //[ProtoMember(5)]
        //public HuoDongPaiHangData RankData;

    }
    /// <summary>
    /// 活动截止 条件领取  如 连续充值和连续登陆等
    /// </summary>
    [ProtoContract]
    public class ActivityOfDeadLineCondition
    {
        /// <summary>
        /// 当前 活动数值
        /// </summary>
        [ProtoMember(1)]
        public int CurrentActivityValue;
        /// <summary>
        /// 是否可以获取最终大奖  条件不足 或者 领取过 为false
        /// </summary>
        [ProtoMember(2)]
        public int CanGetFinalGift = -1;
    }

    /// <summary>
    /// 活动截止 排行领取 如 充值达人 和实力排行
    /// </summary>
    [ProtoContract]
    public class ActivityOfDeadLineRanking
    {
        /// <summary>
        /// 当前 活动数值
        /// </summary>
        [ProtoMember(1)]
        public int CurrentActivityValue;
        /// <summary>
        /// 活动排名
        /// </summary>
        [ProtoMember(2)]
        public int RankingPos;
        /// <summary>
        /// 是否可以获取最终大奖  条件不足 或者 领取过 为false
        /// </summary>
        [ProtoMember(3)]
        public int CanGetFinalGift = -1;
        /// <summary>
        /// 当前的可领取时间 时间单位（秒 毫秒）由服务器定
        /// </summary>
        [ProtoMember(4)]
        public long LeftTime;

        ///// <summary>
        ///// 排行榜的数据
        ///// </summary>
        //[ProtoMember(5)]
        //public HuoDongPaiHangData RankData;
    }

       /// <summary>
    /// 日常任务  如 玩家任务 记录当天杀怪和进入副本次数
    /// </summary>
    [ProtoContract]
    public class ActivityOfDayTask
    {
        /// <summary>
        /// 任务完成列表
        /// </summary>
       [ProtoMember(1)]
       public List<int> CurrentComplete = null;
        /// <summary>
        /// 活动Item 领取状态
        /// </summary>
       [ProtoMember(2)]
       public List<XinFuActivityItemData> ItemStateList;
    }
    /// <summary>
    /// 绑定玩家任务 如 boss首杀
    /// </summary>
    [ProtoContract]
    public class ActivityOfBindingPlayer
    {
        /// <summary>
        /// 活动Item 领取状态
        /// </summary>
        [ProtoMember(1)]
        public List<XinFuActivityItemDataBindPlayer> ItemStateList = new List<XinFuActivityItemDataBindPlayer>();
    }
    /// <summary>
    /// 绑定玩家的活动Item
    /// </summary>
    [ProtoContract]
    public class XinFuActivityItemDataBindPlayer
    {
        /// <summary>
        /// itemID
        /// </summary>
        [ProtoMember(1)]
        public int itemID = -1;
        /// <summary>
        /// 当前的状态
        /// </summary>
        [ProtoMember(2)]
        public int itemState = -1;
        /// <summary>
        /// 当前item 需要的value 比如 当天的充值数额
        /// </summary>
        [ProtoMember(3)]
        public int itemValue = 0;
        /// <summary>
        /// 当前奖励可领取人 boss首杀 这类
        /// </summary>
        [ProtoMember(4)]
        public int itemOwnerRoleId = 0;

        /// <summary>
        /// 当前奖励可领取人的名字 boss首杀 这类
        /// </summary>
        [ProtoMember(5)]
        public string itemOwnerRoleName = "";


    }
    /// <summary>
    /// 活动Item
    /// </summary>
    [ProtoContract]
    public class XinFuActivityItemData
    {
        /// <summary>
        /// itemID
        /// </summary>
        [ProtoMember(1)]
        public int itemID = -1;
        /// <summary>
        /// 当前的状态
        /// </summary>
        [ProtoMember(2)]
        public int itemState = -1;
        /// <summary>
        /// 当前item 需要的value 比如 当天的充值数额  当前活动剩余数量(一折返利)
        /// </summary>
        [ProtoMember(3)]
        public int itemValue = 0;
        /// <summary>
        /// 需要两个条件值的 可以通过这里给
        /// </summary>
        [ProtoMember(4)]
        public int itemValue2 = 0;
    }
    [ProtoContract]
    public class XinFuActivityItemDataWithTimeLimit
    {
        /// <summary>
        /// itemID
        /// </summary>
        [ProtoMember(1)]
        public int itemID = -1;
        /// <summary>
        /// 当前的状态
        /// </summary>
        [ProtoMember(2)]
        public int itemState = -1; // 0未领取 1可领取 2 未领取
        /// <summary>
        /// 当前item 需要的value 比如 当天的充值数额  当前活动剩余数量(一折返利)
        /// </summary>
        [ProtoMember(3)]
        public int itemValue = 0;
        /// <summary>
        /// 每日任务 需要两个条件值
        /// </summary>
        [ProtoMember(4)]
        public int itemValue2 = 0; 
        /// <summary>
        /// 倒计时限制类型的item
        /// </summary>
        [ProtoMember(5)]
        public long TimeLimit = 0; 
    }
    /// <summary>
    /// 无双每日任务活动[zhanglin 2015/11/2]
    /// </summary>
    [ProtoContract]
    public class WSDailyTaskActivity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;
        /// <summary>
        /// 天数序号
        /// </summary>
        [ProtoMember(2)]
        public int DaySequence = 0;
        /// <summary>
        /// 任务集合
        /// </summary>
        [ProtoMember(3)]
        public List<WSDailyTask> Tasks;
    }
    /// <summary>
    /// 无双每日任务活动任务项[zhanglin 2015/11/2]
    /// </summary>>
    [ProtoContract]
    public class WSDailyTask
    {
        /// <summary>
        /// 每日任务活动ID
        /// </summary>
        [ProtoMember(1)]
        public int DailyActiveID = 0;
        /// <summary>
        /// 进度
        /// </summary>
        [ProtoMember(2)]
        public int Schedule = 0;
        /// <summary>
        /// 完成状态 1 未完成，2已完成, 3已领取
        /// </summary>
        [ProtoMember(3)]
        public int State = 0;
    }
}
