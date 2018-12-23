using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Data;

namespace Server.Data 
{
    public class XianmaiDailyAward
    {
        public int id;
        public int eventType;
        public int awardMaijue;
        public List<GoodsData> awardGoodsList;
        public string monsterInfoStr;
        public string msg;
        public int weight;
    }
}
