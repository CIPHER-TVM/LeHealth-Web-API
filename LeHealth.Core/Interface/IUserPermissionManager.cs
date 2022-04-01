using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IUserPermissionManager
    {
        string SaveUserGroup(UserGroupModel obj);
        List<UserGroupModel> getUserGroups();
        UserGroupModel getUserGroup(Int32 id);
        string SaveUser(UserModel obj);
        List<UserModel> GetUsers();
        UserModel GetUser(Int32 id);
        List<HospitalModel> GetUserBranches(Int32 id);
        List<MapLocationModel> GetUserLocations(Int32 userId);
        string MapLocation(MapLocationModel obj);
        string MapUserGroup(MapUserGroupModel obj);
        UserPermissionGroups getUserGroupsonBranch(int branchId, int userId);
      MapUserGroupModel getUserGrouponUser(int userId);
        string SaveUsermenu(UserMenuModel obj);
    }
}
