﻿using System;
using System.Net;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Ink;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;
using System.Collections.Generic;
using ProtoBuf;
using Server.Data.Caiji;
using Server.Data.DailyBuyLimit;
using Server.Data.YueKa;

namespace Server.Data
{
    /// <summary>
    /// 玩家扮演的角色的数据定义
    /// </summary>
    [ProtoContract]
    public class RoleDataEx
    {
        /// <summary>
        /// 当前的角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;

        /// <summary>
        /// 当前的角色ID
        /// </summary>
        [ProtoMember(2)]
        public string RoleName = "";

        /// <summary>
        /// 当前角色的性别
        /// </summary>
        [ProtoMember(3)]
        public int RoleSex = 0;

        /// <summary>
        /// 角色职业
        /// </summary>
        [ProtoMember(4)]
        public int Occupation = 0;

        /// <summary>
        /// 角色级别
        /// </summary>
        [ProtoMember(5)]
        public int Level = 1;

        /// <summary>
        /// 角色所属的帮派
        /// </summary>
        [ProtoMember(6)]
        public int Faction = 0;

        /// <summary>
        /// 绑定金币
        /// </summary>
        [ProtoMember(7)]
        public int Money1 = 0;

        /// <summary>
        /// 非绑定金币
        /// </summary>
        [ProtoMember(8)]
        public int Money2 = 0;

        /// <summary>
        /// 当前的经验
        /// </summary>
        [ProtoMember(9)]
        public long Experience = 0;

        /// <summary>
        /// 当前的PK模式
        /// </summary>
        [ProtoMember(10)]
        public int PKMode = 0;

        /// <summary>
        /// 当前的PK值
        /// </summary>
        [ProtoMember(11)]
        public int PKValue = 0;

        /// <summary>
        /// 所在的地图的编号
        /// </summary>
        [ProtoMember(12)]
        public int MapCode = 0;

        /// <summary>
        /// 当前所在的位置X坐标
        /// </summary>
        [ProtoMember(13)]
        public int PosX = 0;

        /// <summary>
        /// 当前所在的位置Y坐标
        /// </summary>
        [ProtoMember(14)]
        public int PosY = 0;

        /// <summary>
        /// 当前的方向
        /// </summary>
        [ProtoMember(15)]
        public int RoleDirection = 0;

        /// <summary>
        /// 当前的生命值
        /// </summary>
        [ProtoMember(16)]
        public int LifeV = 0;

        /// <summary>
        /// 当前的魔法值
        /// </summary>
        [ProtoMember(17)]
        public int MagicV = 0;

        /// <summary>
        /// 已经完成的任务列表
        /// </summary>
        [ProtoMember(18)]
        public List<OldTaskData> OldTasks = null;

        /// <summary>
        /// 当前的头像
        /// </summary>
        [ProtoMember(19)]
        public int RolePic = 0;

        /// <summary>
        /// 当前背包的页数(总个数 - 1)
        /// </summary>
        [ProtoMember(20)]
        public int BagNum = 0;

        /// <summary>
        /// 任务数据
        /// </summary>
        [ProtoMember(21)]
        public List<TaskData> TaskDataList = null;

        /// <summary>
        /// 物品数据
        /// </summary>
        [ProtoMember(22)]
        public List<GoodsData> GoodsDataList = null;

        /// <summary>
        /// 称号
        /// </summary>
        [ProtoMember(23)]
        public string OtherName = "";

        /// <summary>
        /// 主快捷面板的映射
        /// </summary>
        [ProtoMember(24)]
        public string MainQuickBarKeys = "";

        /// <summary>
        /// 辅助快捷面板的映射
        /// </summary>
        [ProtoMember(25)]
        public string OtherQuickBarKeys = "";

        /// <summary>
        /// 登录的次数
        /// </summary>
        [ProtoMember(26)]
        public int LoginNum = 0;

        /// <summary>
        /// 充值的钱数
        /// </summary>
        [ProtoMember(27)]
        public int UserMoney = 0;

        /// <summary>
        /// 剩余的自动挂机时间
        /// </summary>
        [ProtoMember(28)]
        public int LeftFightSeconds = 0;

        /// <summary>
        /// 好友列表
        /// </summary>
        [ProtoMember(29)]
        public List<FriendData> FriendDataList = null;

        /// <summary>
        /// 坐骑数据列表
        /// </summary>
        [ProtoMember(30)]
        public List<HorseData> HorsesDataList = null;

        /// <summary>
        /// 当前骑乘的坐骑数据库ID
        /// </summary>
        [ProtoMember(31)]
        public int HorseDbID = 0;

        /// <summary>
        /// 宠物数据列表
        /// </summary>
        [ProtoMember(32)]
        public List<PetData> PetsDataList = null;

        /// <summary>
        /// 当前放出的宠物的数据库ID
        /// </summary>
        [ProtoMember(33)]
        public int PetDbID = 0;

        /// <summary>
        /// 角色的内力值
        /// </summary>
        [ProtoMember(34)]
        public int InterPower = 0;

        /// 角色的经脉数据
        /// </summary>
        [ProtoMember(35)]
        public List<JingMaiData> JingMaiDataList = null;

        /// <summary>
        /// 点将积分
        /// </summary>
        [ProtoMember(36)]
        public int DJPoint = 0;

        /// <summary>
        /// 点将总的比赛场次
        /// </summary>
        [ProtoMember(37)]
        public int DJTotal = 0;

        /// <summary>
        /// 点将获胜的场次
        /// </summary>
        [ProtoMember(38)]
        public int DJWincnt = 0;

        /// <summary>
        /// 总的在线秒数
        /// </summary>
        [ProtoMember(39)]
        public int TotalOnlineSecs = 0;

        /// <summary>
        /// 防止沉迷在线秒数
        /// </summary>
        [ProtoMember(40)]
        public int AntiAddictionSecs = 0;

        /// <summary>
        /// 上次离线时间
        /// </summary>
        [ProtoMember(41)]
        public long LastOfflineTime = 0;

        /// <summary>
        ///  本次闭关的开始时间
        /// </summary>
        [ProtoMember(42)]
        public long BiGuanTime = 0;

        /// <summary>
        ///  系统绑定的银两
        /// </summary>
        [ProtoMember(43)]
        public int YinLiang = 0;

        /// <summary>
        /// 技能数据列表
        /// </summary>
        [ProtoMember(44)]
        public List<SkillData> SkillDataList = null;

        /// <summary>
        ///  从别人冲脉获取的经验值(累加)
        /// </summary>
        [ProtoMember(45)]
        public int TotalJingMaiExp = 0;

        /// <summary>
        ///  从别人冲脉获取的经验的次数
        /// </summary>
        [ProtoMember(46)]
        public int JingMaiExpNum = 0;

        /// <summary>
        /// 注册时间
        /// </summary>
        [ProtoMember(47)]
        public long RegTime = 0;

        /// <summary>
        /// 上一次的坐骑ID
        /// </summary>
        [ProtoMember(48)]
        public int LastHorseID = 0;

        /// <summary>
        /// 出售中的物品数据
        /// </summary>
        [ProtoMember(49)]
        public List<GoodsData> SaleGoodsDataList = null;

        /// <summary>
        /// 缺省的技能ID
        /// </summary>
        [ProtoMember(50)]
        public int DefaultSkillID = -1;

        /// <summary>
        /// 自动补血喝药的百分比
        /// </summary>
        [ProtoMember(51)]
        public int AutoLifeV = 0;

        /// <summary>
        /// 自动补蓝喝药的百分比
        /// </summary>
        [ProtoMember(52)]
        public int AutoMagicV = 0;

        /// <summary>
        /// Buffer的数据列表
        /// </summary>
        [ProtoMember(53)]
        public List<BufferData> BufferDataList = null;

        /// <summary>
        /// 跑环的数据列表
        /// </summary>
        [ProtoMember(54)]
        public List<DailyTaskData> MyDailyTaskDataList = null;

        /// <summary>
        /// 每日冲穴的次数数据
        /// </summary>
        [ProtoMember(55)]
        public DailyJingMaiData MyDailyJingMaiData = null;

        /// <summary>
        /// 自动增加熟练度的被动技能ID
        /// </summary>
        [ProtoMember(56)]
        public int NumSkillID = 0;

        /// <summary>
        /// 随身仓库数据
        /// </summary>
        [ProtoMember(57)]
        public PortableBagData MyPortableBagData = null;

        /// <summary>
        /// 活动送礼相关数据
        /// </summary>
        [ProtoMember(58)]
        public HuodongData MyHuodongData = null;

        /// <summary>
        /// 副本数据
        /// </summary>
        [ProtoMember(59)]
        public List<FuBenData> FuBenDataList = null;

        /// <summary>
        /// 已经完成的主线任务的ID
        /// </summary>
        [ProtoMember(60)]
        public int MainTaskID = 0;

        /// <summary>
        /// 当前的PK点
        /// </summary>
        [ProtoMember(61)]
        public int PKPoint = 0;

        /// <summary>
        /// 最高连斩数
        /// </summary>
        [ProtoMember(62)]
        public int LianZhan = 0;

        /// <summary>
        /// 角色每日数据
        /// </summary>
        [ProtoMember(63)]
        public RoleDailyData MyRoleDailyData = null;

        /// <summary>
        /// 杀BOSS的总个数
        /// </summary>
        [ProtoMember(64)]
        public int KillBoss = 0;

        /// <summary>
        /// 押镖的数据
        /// </summary>
        [ProtoMember(65)]
        public YaBiaoData MyYaBiaoData = null;

        /// <summary>
        /// 角斗场荣誉称号开始时间
        /// </summary>
        [ProtoMember(66)]
        public long BattleNameStart = 0;

        /// <summary>
        /// 角斗场荣誉称号
        /// </summary>
        [ProtoMember(67)]
        public int BattleNameIndex = 0;

        /// <summary>
        /// 充值TaskID
        /// </summary>
        [ProtoMember(68)]
        public int CZTaskID = 0;

        /// <summary>
        /// 角斗场称号次数
        /// </summary>
        [ProtoMember(69)]
        public int BattleNum = 0;

        /// <summary>
        /// 英雄逐擂的层数
        /// </summary>
        [ProtoMember(70)]
        public int HeroIndex = 0;

        /// <summary>
        /// 区ID
        /// </summary>
        [ProtoMember(71)]
        public int ZoneID = 0;

        /// <summary>
        /// 联盟名称
        /// </summary>
        [ProtoMember(72)]
        public string BHName = "";

        /// <summary>
        /// 被邀请加入联盟时是否验证
        /// </summary>
        [ProtoMember(73)]
        public int BHVerify = 0;

        /// <summary>
        /// 联盟职务
        /// </summary>
        [ProtoMember(74)]
        public int BHZhiWu = 0;

        /// <summary>
        /// 联盟每日贡日ID1
        /// </summary>
        [ProtoMember(75)]
        public int BGDayID1 = 0;

        /// <summary>
        /// 联盟每日铜钱帮贡
        /// </summary>
        [ProtoMember(76)]
        public int BGMoney = 0;

        /// <summary>
        /// 联盟每日贡日ID2
        /// </summary>
        [ProtoMember(77)]
        public int BGDayID2 = 0;

        /// <summary>
        /// 联盟每日道具帮贡
        /// </summary>
        [ProtoMember(78)]
        public int BGGoods = 0;

        /// <summary>
        /// 联盟帮贡
        /// </summary>
        [ProtoMember(80)]
        public int BangGong = 0;

        /// <summary>
        /// 是否皇后
        /// </summary>
        [ProtoMember(81)]
        public int HuangHou = 0;

        /// <summary>
        /// 自己在排行中的位置字典
        /// </summary>
        [ProtoMember(82)]
        public Dictionary<int, int> PaiHangPosDict = null;

        /// <summary>
        /// 劫镖的日ID
        /// </summary>
        [ProtoMember(83)]
        public int JieBiaoDayID = 0;

        /// <summary>
        /// 劫镖的日次数
        /// </summary>
        [ProtoMember(84)]
        public int JieBiaoDayNum = 0;

        /// <summary>
        /// 上次的mailID
        /// </summary>
        [ProtoMember(85)]
        public int LastMailID = 0;

        /// <summary>
        /// vip日数据
        /// </summary>
        [ProtoMember(86)]
        public List<VipDailyData> VipDailyDataList = null;

        /// <summary>
        /// 杨公宝库积分日数据
        /// </summary>
        [ProtoMember(87)]
        public YangGongBKDailyJiFenData YangGongBKDailyJiFen = null;

        /// <summary>
        /// 单次奖励记录标志位
        /// </summary>
        [ProtoMember(88)]
        public long OnceAwardFlag = 0;

        /// <summary>
        ///  系统绑定的钻石
        /// </summary>
        [ProtoMember(89)]
        public int Gold = 0;

        /// <summary>
        /// 已经使用的物品限制列表
        /// </summary>
        [ProtoMember(90)]
        public List<GoodsLimitData> GoodsLimitDataList = null;

        /// <summary>
        /// 角色参数字典
        /// </summary>
        [ProtoMember(91)]
        public Dictionary<string, RoleParamsData> RoleParamsDict = null;

        /// <summary>
        ///  是否永久禁言
        /// </summary>
        [ProtoMember(92)]
        public int BanChat = 0;

        /// <summary>
        ///  是否永久禁止登陆
        /// </summary>
        [ProtoMember(93)]
        public int BanLogin = 0;

        // MU项目增加字段 [11/30/2013 LiaoWei]
        /// <summary>
        ///  新人标记：注意本词拼写错误，应该是Fresh!
        /// </summary>
        [ProtoMember(94)]
        public int IsFlashPlayer = 0;

        // MU项目增加字段 [12/10/2013 LiaoWei]
        /// <summary>
        /// 转生计数
        /// </summary>
        [ProtoMember(95)]
        public int ChangeLifeCount = 0;

        // MU项目增加字段 [12/10/2013 LiaoWei]
        /// <summary>
        /// 被崇拜计数
        /// </summary>
        [ProtoMember(96)]
        public int AdmiredCount = 0;

        // MU项目增加字段 [12/17/2013 LiaoWei]
        /// <summary>
        /// 战斗力
        /// </summary>
        [ProtoMember(97)]
        public int CombatForce = 0;

        // MU项目增加字段 [3/3/2014 LiaoWei]
        /// <summary>
        /// 自动分配属性点
        /// </summary>
        [ProtoMember(98)]
        public int AutoAssignPropertyPoint = 0;

        // MU项目增加字段 [4/23/2014 LiaoWei]
        /// <summary>
        /// 推送ID
        /// </summary>
        [ProtoMember(99)]
        public string PushMessageID = "";

        /// <summary>
        /// 翅膀数据列表
        /// </summary>
        [ProtoMember(100)]
        public WingData MyWingData = null;

        /// <summary>
        /// 角色图鉴提交信息 [5/17/2014 LiaoWei]
        /// </summary>
        [ProtoMember(101)]
        public Dictionary<int, int> RolePictureJudgeReferInfo = null;

        /// <summary>
        /// 角色星座信息 [8/1/2014 LiaoWei]
        /// </summary>
        [ProtoMember(102)]
        public Dictionary<int, int> RoleStarConstellationInfo = null;

        /// <summary>
        /// VIP等级
        /// </summary>
        [ProtoMember(103)]
        public int VIPLevel = 0;

        /// <summary>
		/// <summary>        /// 玩家附加信息数据
        /// </summary>
        [ProtoMember(106)]
        public RoleDataAddons MyRoleDataAddons= null;

        /// <summary>
        /// 采集数据
        /// </summary>
        [ProtoMember(107)]
        public List<CaijiData> CaijiDataList = null;

        /// <summary>
        /// 杀角色的总个数
        /// </summary>
        [ProtoMember(108)]
        public int KillRole = 0;

        /// <summary>
        /// 玩家的每日限购数据信息
        /// </summary>
        [ProtoMember(109)]
        public DailyBuyLimitData MyDailyBuyLimitData;

        /// <summary>
        /// 玩家共享的用户数据，用来做封测的返还使用
        /// </summary>
        [ProtoMember(110)]
        public UserBetaTestReward MyUserBetaTestReward = null;

        /// <summary>
        /// 玩家的联盟技能列表
        /// </summary>
        [ProtoMember(111)]
        public List<SkillData> MyLeagueSkillList = null;
        /// <summary>
        /// 元素之心粉尘
        /// </summary>
        [ProtoMember(112)]
        public RefineData RefineData;

        /// <summary>
        /// 精灵数据
        /// </summary>
        [ProtoMember(113)]
        public List<JingLingData> JingLingDatas;
        /// <summary>
        /// 元素之心数据队列
        /// </summary>
        [ProtoMember(114)]
        public List<ElementHeartData> ElementHeartDataList;

        /// <summary>
        /// 师徒数据
        /// </summary>
        [ProtoMember(115)]
        public SchoolData MySchoolData;

		/// <summary>
		/// 玩家的月卡数据
		/// </summary>
		[ProtoMember(116)]
		public YueKaData MyYueKaData
		{
			set;
			get;
		}
        /// <summary>
		/// 玩家的法宝数据
		/// </summary>
        [ProtoMember(117)]
        public TrumpData MyTrumpData;

        /// <summary>
        /// 新增加的玩家期间限购活动数据对象
        /// </summary>
        [ProtoMember(118)]
        public RoleTimePeriodBuyLimit MyTimePeriodBuyLimit;
    }
}
