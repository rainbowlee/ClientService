using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace Server.Data.WSXianMaiChongZhu
{
    [ProtoContract]
    public class WSRoleXianMaiChongZhuExtraData
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(1)]
        public int RoleID = 0;
        /// <summary>
        /// 仙脉ID
        /// </summary>
        [ProtoMember(2)]
        public int Extrapropertyid = 0; 
    }
}
