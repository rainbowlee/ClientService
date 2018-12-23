using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

public enum DailyBuyLimitTypes
{
  CanNotBuy = 0,//资格不够购买
  CanBuy = 1,//可以购买
  AlreadyBuy = 2,//已经进行了购买
}
//using GameServer.Logic.DailyBuyLimit;
namespace Server.Data.DailyBuyLimit
{
    /// <summary>
    /// 每日限购数据
    /// </summary>
      [ProtoContract]
    public class DailyBuyLimitData
    {
          /// <summary>
          /// 玩家ID
          /// </summary>
          [ProtoMember(1)]
          public int roleId;
          /// <summary>
          /// 购买日期天
          /// </summary>
          [ProtoMember(2)]
          public int dayId;
          /// <summary>
          /// 购买状态
          /// </summary>
          [ProtoMember(3)]
          public List<int> stateList;

          /// <summary>
          /// 获取领取状态
          /// </summary>
          /// <param name="index"></param>
          /// <returns></returns>
          public DailyBuyLimitTypes getSate(int index)
          {
              AddStateList(index);
              return (DailyBuyLimitTypes)stateList[index];
          }

          /// <summary>
          /// 扩容数组
          /// </summary>
          /// <param name="index"></param>
          private void AddStateList(int index)
          {
              if (index >= stateList.Count)
              {
                  for (int i = stateList.Count; i <= index; i++)
                  {
                      stateList.Add((int)DailyBuyLimitTypes.CanBuy);
                  }
              }

          }
          /// <summary>
          /// 更新数据
          /// </summary>
          /// <param name="index"></param>
          /// <param name="state"></param>
          public void updateState(int index, DailyBuyLimitTypes state)
          {
              AddStateList(index);
              stateList[index] = ((int)state);
          }

          public void init(int roleID, int dayID) 
          {
              roleId = roleID;
              dayId = dayID;
              stateList = new List<int>();
          }

          public void clearState()
          {
              stateList.Clear();
          }

    }
}
