using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using GameServer.Logic;
namespace Server.Data
{


    /// <summary>
    /// 七天活动 Boss击杀
    /// </summary>
    public class Day7KillBossData
    {
        /// <summary>
        /// 所有的boss数据
        /// </summary>
        public List<KillBossData> list = new List<KillBossData>();

        /// <summary>
        /// 取得killBossData
        /// </summary>
        /// <param name="bossKey"></param>
        /// <returns></returns>
        public KillBossData getBossData(String bossKey)
        {
            foreach (KillBossData data in list)
            {
                if (data.BossKey.Equals(bossKey))
                {
                    return data;
                }

            }
            return null;
        }


    }

    public class KillBossData
    {
        /// <summary>
        /// 
        /// </summary>
        public const int REWARD_STATE_NONE = 1, REWARD_STATE_REWARD = 2, REWARD_STATE_OVER = 3;
        /// <summary>
        /// boss id
        /// </summary>
        public String BossKey;


        /// <summary>
        /// 击杀者
        /// </summary>
        public int KillerRoleId;

        /// <summary>
        /// 击杀者名字
        /// </summary>
        public String killRoleName;

        /// <summary>
        /// 奖励状态
        /// </summary>
        public int RewardState = 1;

        //是否可以领取奖励
        public Boolean canGetReward()
        {
            return RewardState < REWARD_STATE_OVER;
        }

    }

    /// <summary>
    /// 充值单天数据
    /// </summary>
    [ProtoContract]
    public class ChargeDayData
    {

        /// <summary>
        /// 领取状态 1是充值不到，不能领取，2，是可以领取，3是已经领取
        /// </summary>
        public const int REWARD_STATE_NONE = 1, REWARD_STATE_REWARD = 2, REWARD_STATE_OVER = 3;


        /// <summary>
        /// 天数
        /// </summary>
        [ProtoMember(1)]
        public int day = 0;


        /// <summary>
        /// 领取了奖励状态
        /// </summary>
        [ProtoMember(2)]
        public int RewardState = 1;

        /// <summary>
        /// 最大的充值额度
        /// </summary>
        [ProtoMember(3)]
        public int maxChargeMoney = 0;


        /// <summary>
        /// 是否领取过
        /// </summary>
        /// <returns></returns>
        public bool hasRewarded()
        {
            return RewardState == REWARD_STATE_OVER;
        }
    }

    /// <summary>
    /// 7天登录数据
    /// </summary>
    [ProtoContract]
    public class Day7LoginData
    {
        /// <summary>
        /// 7天活动数据
        /// </summary>
        [ProtoMember(1)]
        public List<LoginDayData> days = new List<LoginDayData>();


        /// <summary>
        /// 账号id
        /// </summary>
        [ProtoMember(2)]
        public int roleId;

        public LoginDayData getLoginDay(int day)
        {
            return getLoginDayData(days, day);
        }

        public void init(int now)
        {
            foreach (LoginDayData data in getLoginDayDatas())
            {
                if (data.day < now)
                {
                    if (data.RewardState == LoginDayData.REWARD_STATE_NONE)
                    {
                        data.RewardState = LoginDayData.REWARD_STATE_OVER;
                    }
                }
            }


        }


        public List<LoginDayData> getLoginDayDatas()
        {
            return days;
        }

        public static LoginDayData getLoginDayData(List<LoginDayData> list, int day)
        {
            foreach (LoginDayData data in list)
            {
                if (data.day == day)
                {
                    return data;
                }
            }

            return null;
        }

    }
    /// <summary>
    /// 取得某天数据
    /// </summary>
    /// <param name="list"></param>
    /// <param name="day"></param>
    /// <returns></returns>

    /// <summary>
    /// 连续登录
    /// </summary>
    [ProtoContract]
    public class LoginDayData
    {
        /// <summary>
        /// 领取状态 1未领取，2，已领取，3已过期
        /// </summary>
        public const int REWARD_STATE_NONE = 1, REWARD_STATE_REWARD = 2, REWARD_STATE_OVER = 3;
        /// <summary>
        /// 天数
        /// </summary>
        [ProtoMember(1)]
        public int day = 0;


        /// <summary>
        /// 领取了奖励状态
        /// </summary>
        [ProtoMember(2)]
        public int RewardState = 1;


        /// <summary>
        /// 是否领取过
        /// </summary>
        /// <returns></returns>
        public bool hasRewarded()
        {
            return RewardState == REWARD_STATE_OVER;
        }

    }

}
