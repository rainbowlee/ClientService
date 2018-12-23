using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{

    public class KY<K,V>
    {
        /// <summary>
        /// 属性key
        /// </summary>
        public K Key;

        /// <summary>
        /// 属性value
        /// </summary>
        public V Value;
    }
    /// <summary>
    /// 精灵等级奇缘配置
    /// </summary>
    public class JingLingLevelSuitConfig
    {
        /// <summary>
        /// 等级.
        /// </summary>

        public int Level;
        
        /// <summary>
        /// 属性组合
        /// </summary>
        public List<KY<int, Double>> Attrs = new List<KY<int, Double>>();

    }

    /// <summary>
    /// 天赋奇缘奖励配置
    /// </summary>
    public class JingLingTianfuAwardConfig
    {
        /// <summary>
        /// 天赋总数
        /// </summary>

        public int TianFuNum;

        /// <summary>
        /// 属性组合
        /// </summary>
        public List<KY<int, Double>> Attrs = new List<KY<int, Double>>();

    }

    /// <summary>
    /// 
    /// </summary>
    public class JingLingCallConfig
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID;

        /// <summary>
        /// goodid
        /// </summary>
        public int GoodsID;

        /// <summary>
        /// 数量
        /// </summary>
        public int Num;

        /// <summary>
        /// 卓越id
        /// </summary>
        public int ZhuoYueFallID;

        /// <summary>
        /// 开始
        /// </summary>
        public int StartValues;

        /// <summary>
        /// end
        /// </summary>
        public int EndValues;
    }

    /// <summary>
    /// 组合奇缘配置
    /// </summary>
    public class JingLingGroupPropertyConfig
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 成员列表
        /// </summary>
        public List<KY<int, Double>> JingLingGoods = new List<KY<int, Double>>();

        /// <summary>
        /// 属性列表
        /// </summary>
        public List<KY<int, Double>> Attrs = new List<KY<int, Double>>();

        /// <summary>
        /// 是否存在过goodsid
        /// </summary>
        /// <param name="goodsID"></param>
        /// <returns></returns>
        public bool hasGoodsID(int goodsID)
        {
            foreach (KY<int, Double> ky in JingLingGoods)
            {
                if (ky.Key == goodsID)
                {
                    return true;
                }
            }
            return false;
        }

    }



}
