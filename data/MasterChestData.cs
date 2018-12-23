using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 师徒相关xml数据，推送到客户端
    /// </summary>
    [ProtoContract]
    public class MasterData
    {
        /// <summary>
        /// 师父数据
        /// </summary>
        [ProtoMember(1)]
        public RoleData MasterRoleData = null;

        /// <summary>
        /// 徒弟列表
        /// </summary>
        [ProtoMember(2)]
        public MasterListAnApprenticeData ApprenticeListData = null;

        /// <summary>
        /// 宝箱列表
        /// </summary>
        [ProtoMember(3)]
        public MasterListChestData ListChestData = null;

        /// <summary>
        /// 时间 计数
        /// </summary>
        [ProtoMember(4)]
        public MasterCountData masterCountData = null;


        /// <summary>
        /// 类型区分
        /// </summary>
        [ProtoMember(5)]
        public int type = 1;
    }

    [ProtoContract]
    public class MasterCountData
    {
        /// <summary>
        /// 拜师倒计时
        /// </summary>
        [ProtoMember(1)]
        public int remainTime = 0;

        /// <summary>
        /// 收徒倒计时
        /// </summary>
        [ProtoMember(2)]
        public int remainAnTime = 0;

        /// <summary>
        /// 传功总次数
        /// </summary>
        [ProtoMember(3)]
        public int passTotalCount = 0;

        /// <summary>
        /// 提醒师父传功倒计时
        /// </summary>
        [ProtoMember(4)]
        public int passRemainTime = 0;

        /// <summary>
        /// 每天传功次数
        /// </summary>
        [ProtoMember(5)]
        public int dayPassTotalCount = 0;

        /// <summary>
        /// 错误码
        /// </summary>
        [ProtoMember(6)]
        public int ErrorCode = 1;

        /// <summary>
        /// 叛逃惩罚时间
        /// </summary>
        [ProtoMember(7)]
        public int LeavelPunishTime = 0;



    }

    /// <summary>
    /// 宝箱Msg
    /// </summary>
    [ProtoContract]
    public class MasterListChestData
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        [ProtoMember(1)]
        public int ErrorCode = 1;
        /// <summary>
        /// 宝箱列表
        /// </summary>
        [ProtoMember(2)]
        public List<MasterChestData> _ListChestData = null;

        [ProtoMember(3)]
        public long Exp= 1;


    }

    /// <summary>
    /// 徒弟列表
    /// </summary>
    [ProtoContract]
    public class MasterListAnApprenticeData
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        [ProtoMember(1)]
        public int ErrorCode = 1;
        /// <summary>
        /// 徒弟列表
        /// </summary>
        [ProtoMember(2)]
        public List<MasterAnApprenticeData> _MasterAnApprenticeData = new List<MasterAnApprenticeData>();

        /// <summary>
        /// 师傅获得经验
        /// </summary>
        [ProtoMember(3)]
        public long Exp = 0;

        /// <summary>
        /// 传功总次数
        /// </summary>
        [ProtoMember(4)]
        public long passTotalCount = 0;


    }

    /// <summary>
    /// 查找列表
    /// </summary>
    [ProtoContract]
    public class MasterFindListData
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        [ProtoMember(1)]
        public int ErrorCode = 1;
        /// <summary>
        /// 查找人员列表
        /// </summary>
        [ProtoMember(2)]
        public List<MasterListData> _MasterListData = null;
    }

    /// <summary>
    /// 传功宝箱数据
    /// </summary>
    [ProtoContract]
    public class MasterChestData
    {
        /// <summary>
        /// 宝箱类型
        /// </summary>
        [ProtoMember(1)]
        public int type;

        /// <summary>
        /// 宝箱的位置
        /// </summary> 
        [ProtoMember(2)]
        public int position;

        /// <summary>
        /// 宝箱的打开剩余时间
        /// </summary> 
        [ProtoMember(3)]
        public int lastTime;

        /// <summary>
        /// 宝箱是否打开
        /// </summary>
        [ProtoMember(4)]
        public bool isUnLock;

        /// <summary>
        /// 宝箱可获得经验
        /// </summary>
        [ProtoMember(5)]
        public long exp;

        /// <summary>
        /// 宝箱图标
        /// </summary>
        [ProtoMember(6)]
        public string spriteName;
    }

    /// <summary>
    /// 徒弟数据
    /// </summary>
    [ProtoContract]
    public class MasterAnApprenticeData
    {
        /// <summary>
        /// 对方的ID
        /// </summary>
        [ProtoMember(1)]
        public int OtherRoleID;

        /// <summary>
        /// 对方的名称
        /// </summary>
        [ProtoMember(2)]
        public string OtherRoleName;

        /// <summary>
        /// 对方的等级
        /// </summary>
        [ProtoMember(3)]
        public int OtherLevel;

        /// <summary>
        /// 对方的职业
        /// </summary>
        [ProtoMember(4)]
        public int Occupation;

        /// <summary>
        /// 对方的在线状态
        /// </summary>
        [ProtoMember(5)]
        public int OnlineState;

        // MU 新增字段 朋友的转生级别 [1/10/2014 LiaoWei]
        /// <summary>
        /// 朋友转生级别
        /// </summary>
        [ProtoMember(6)]
        public int ChangeLifeLev;

        /// <summary>
        /// 朋友战斗力 MU 新增字段 [3/15/2014 LiaoWei] 
        /// </summary>
        [ProtoMember(7)]
        public int CombatForce;

        /// <summary>
        /// 传功次数
        /// </summary>
        [ProtoMember(8)]
        public int PassCount;

 
    }

    /// <summary>
    /// 查找数据
    /// </summary>
    [ProtoContract]
    public class MasterListData
    {
        public int index;
        public int checkIndex;

        /// <summary>
        /// 对方的ID
        /// </summary>
        [ProtoMember(1)]
        public int roleID;

        /// <summary>
        /// 对方的职业
        /// </summary>
        [ProtoMember(2)]
        public int Occupation;

        /// <summary>
        /// 对方的名字
        /// </summary>
        [ProtoMember(3)]
        public string RoleName;

        /// <summary>
        /// 对方的等级
        /// </summary>
        [ProtoMember(4)]
        public int Level;

        /// <summary>
        /// 对方转生级别
        /// </summary>
        [ProtoMember(5)]
        public int ChangeLifeLev;

        /// <summary>
        /// 对方的战力
        /// </summary>
        [ProtoMember(6)]
        public int CombatForce;
    }
}
