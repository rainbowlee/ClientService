using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Server.Data
{
    [ProtoContract]
    public class ElementMsgData
    {
        /// <summary>
        /// 1 整理背包
        /// 2 佩戴卸下元素
        /// 3 提炼
        /// 4 吞噬元素
        /// </summary>
        [ProtoMember(1)]
        public int operateCode = 0;
        /// <summary>
        /// 错误码  
        /// 1  成功
        /// -1 不可佩戴同种类型道具
        /// -2 佩戴时 发现已经带满
        /// -3 提炼元素时 元素精华不足
        /// -4 提炼元素时 钻石不足
        /// -5 背包空间不足
        /// -6 升级元素  不可以自己吃自己
        /// </summary>
        [ProtoMember(2)]
        public int errorCode = 1;
        /// <summary>
        /// 当前Element列表
        /// </summary>
        [ProtoMember(3)]
        public List<ElementCData> elements;
        /// <summary>
        /// 抽奖获取的Element列表
        /// </summary>
        [ProtoMember(4)]
        public List<ElementCData> elementsGet;
        /// <summary>
        /// 提炼元素之后奖池的等级
        /// </summary>
        [ProtoMember(5)]
        public int ElementGetLevel = 1;

        /// <summary>
        /// 元素之心粉末
        /// </summary>
        [ProtoMember(6)]
        public int ElementDust = 1;
    }


    [ProtoContract]
    public class ElementCData
    {
        /// <summary>
        /// 数据库流水ID
        /// </summary>
        [ProtoMember(1)]
        public int Id;

        /// <summary>
        /// 物品ID
        /// </summary>
        [ProtoMember(2)]
        public int GoodsID;

        /// <summary>
        /// 品阶
        /// </summary>
        [ProtoMember(3)]
        public int exp;

        /// <summary>
        /// 等级
        /// </summary>
        [ProtoMember(4)]
        public int Level;

        /// <summary>
        /// 装备Index
        /// </summary>
        [ProtoMember(5)]
        public int UsingIndex;

        /// <summary>
        /// 背包位置
        /// </summary>
        [ProtoMember(6)]
        public int BagIndex;


    }

}