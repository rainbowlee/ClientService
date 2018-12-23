using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using GameServer.Logic;

namespace Server.Data
{
    [ProtoContract]
    public class RoleTimePeriodBuyLimit
    {
        /// <summary>
          /// 玩家ID
          /// </summary>
          [ProtoMember(1)]
          public int roleId;
          /// <summary>
          /// 购买的期数
          /// </summary>
          [ProtoMember(2)]
          public int TimeId;
          /// <summary>
          /// 购买次数列表
          /// </summary>
          [ProtoMember(3)]
          public List<int> buyNumList;

          /// <summary>
          /// 获取购买次数
          /// </summary>
          /// <param name="index"></param>
          /// <returns></returns>
          public int getBuyNum(int index)
          {
              AddStateList(index, 0);
              return buyNumList[index];
          }

          /// <summary>
          /// 扩容数组
          /// </summary>
          /// <param name="index"></param>
          private void AddStateList(int index, int buyNum)
          {
              if (index >= buyNumList.Count)
              {
                  for (int i = buyNumList.Count; i <= index; i++)
                  {
                      buyNumList.Add(buyNum);
                  }
              }
          }
          /// <summary>
          /// 更新数据
          /// </summary>
          /// <param name="index"></param>
          /// <param name="state"></param>
          public void updateState(int index, int buyNum)
          {
              AddStateList(index, buyNum);
              buyNumList[index] = buyNum;
          }
    }
}
