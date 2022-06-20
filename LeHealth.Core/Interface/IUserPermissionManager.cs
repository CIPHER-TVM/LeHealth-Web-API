using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IUserPermissionManager
    {
        string SaveUserGroup(UserGroupModel obj);
        List<UserGroupModel> GetUserGroups(int branchId);
        UserGroupModel GetUserGroup(Int32 id);
        string SaveUser(UserModel obj);
        List<UserModel> GetUsers(Int32 branchId);
        List<UserModel> GetUnAssignedUsers(Int32 branchId); 
        UserModel GetUser(Int32 id);
        List<HospitalModel> GetUserBranches(Int32 id);
        List<UserGroupBranchModel> GetUserGroupBranches(Int32 id);
        List<MapLocationModel> GetUserLocations(Int32 userId);
        string MapLocation(MapLocationModel obj);
        string MapUserGroup(MapUserGroupModel obj);
        UserPermissionGroups GetUserGroupsonBranch(int branchId, int userId);
        MapUserGroupModel GetUserGrouponUser(int userId);
        string SaveUsermenu(UserMenuModel obj);
    }
}
