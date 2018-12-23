using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Server.Data
{
    /// <summary>
    /// 元素之心升级Config
    /// </summary>
    public class ElementHeartLevelConfig
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int Level = 0;

        /// <summary>
        /// 最大经验
        /// </summary>
        public int NeedExp = 0;

    }

    /// <summary>
    /// 抽奖位数配置
    /// </summary>
    public class RefineTypeCfg
    {
        /// <summary>
        /// 默认档次
        /// </summary>
        public static int DEFAULT_TYPE = 1;

        /// <summary>
        /// id
        /// </summary>
        public int ID;

        /// <summary>
        /// 最小转生限制
        /// </summary>
        public int MinZhuanSheng;

        /// <summary>
        /// 最小转生下的等级限制
        /// </summary>
        public int MinLevel;


        /// <summary>
        /// 粉尘cost
        /// </summary>
        public int RefineCost;

        /// <summary>
        /// 钻石cost
        /// </summary>
        public int ZuanShiCost;

        /// <summary>
        /// 成功概率
        /// </summary>
        public double SuccessRate;

        /// <summary>
        /// 成功进阶
        /// </summary>
        public int RefineLevel;
    }

    /// <summary>
    /// 抽取配置
    /// </summary>
    public class RefineCfg
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID;
        
        /// <summary>
        /// 对应的GoodsID
        /// </summary>
        public int GoodsID;

        /// <summary>
        /// 数量
        /// </summary>
        public int Num;

        /// <summary>
        /// 概率区间头
        /// </summary>
        public int StartValues;

        /// <summary>
        /// 概率区间尾
        /// </summary>
        public int EndValues;


        /// <summary>
        /// 所属档次
        /// </summary>
        public int TypeID;


    }


}
