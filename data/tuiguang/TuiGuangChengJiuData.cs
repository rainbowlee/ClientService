using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Server.Data
{
    //推广成就data
    [ProtoContract]
    public class TuiGuangChengJiuData
    {
        /// <summary>
        /// 操作类型  0查询   1领取
        /// </summary>
        [ProtoMember(1)]
        public int operateType = 0;

        [ProtoMember(2)]
        public List<TuiGuangItemData> tuiGuangItem;
        /// <summary>
        /// 获取奖励的ID（客户端发给服务器）
        /// </summary>
        [ProtoMember(3)]
        public int GetAwardID = 0;
        /// <summary>
        /// 操作错误码  1为成功 剩下的后端定
        /// </summary>
        [ProtoMember(4)]
        public int errorCode = 1;

        public void addItem(TuiGuangItemData item)
        {
            if (tuiGuangItem == null)
            {
                tuiGuangItem = new List<TuiGuangItemData>();
            }
            tuiGuangItem.Add(item);
        }

        public TuiGuangItemData getItemData(int ID)
        {
            TuiGuangItemData item = null;
            if (tuiGuangItem == null)
            {
                tuiGuangItem = new List<TuiGuangItemData>();
                item = new TuiGuangItemData{
                    Id = ID
                };
                tuiGuangItem.Add(item);
                return item;
            }
            foreach (TuiGuangItemData item2 in tuiGuangItem)
            {
                if (item2.Id == ID)
                {
                    return item2;
                }
            }
            item = new TuiGuangItemData
            {
                Id = ID
            };
            tuiGuangItem.Add(item);
            return item;
        }
    
    }
    //推广Item数据
    [ProtoContract]
    public class TuiGuangItemData
    {
        /// <summary>
        /// 表中ID
        /// </summary>
        [ProtoMember(1)]
        public int Id = 0;
        /// <summary>
        /// Item状态   1领取了   2未领取
        /// </summary>
        [ProtoMember(2)]
        public int state = 0;
        /// <summary>
        /// 当前完成次数
        /// </summary>
        [ProtoMember(3)]
        public int nowCount = 0;
    }
}

