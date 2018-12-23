using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
  //roleList += string.Format("{0}${1}${2}${3}${4}${5}|",
  //     dbUserInfo.ListRoleIDs[i], dbUserInfo.ListRoleSexes[i], dbUserInfo.ListRoleOccups[i], dbUserInfo.ListRoleNames[i], dbUserInfo.ListRoleLevels[i], dbUserInfo.ListRoleChangeLifeCount[i]);

  public class Role
  {
    public int RoleId;
    public int RoleSex;
    public int RoleOccup;
    public string RoleName;
    public int RoleLevel;
    public int RoleChangeCount;
  }
}
