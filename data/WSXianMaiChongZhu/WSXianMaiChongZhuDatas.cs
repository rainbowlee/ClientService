using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data.WSXianMaiChongZhu
{
    /// <summary>
    /// 我欲封天角色仙脉重铸数据
    /// </summary>
    [ProtoContract]
    public class WSXianMaiChongZhuDatas
    {
        [ProtoMember(1,IsRequired=true)]
        public Dictionary<int, WSXianMaiChongZhuData> DataDic = new Dictionary<int,WSXianMaiChongZhuData>();

        [ProtoMember(2,IsRequired=true)]
        public Dictionary<int, double> PropertysDic = new Dictionary<int, double>();
    }
}
