using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IUserPermissionService
    {
        string SaveUserGroup(UserGroupModel obj);
        List<UserGroupModel> getUserGroups(int branchId);
        UserGroupModel getUserGroup(Int32 id);
        string SaveUser(UserModel obj);
        List<UserModel> GetUsers(int branchId);
        UserModel GetUser(Int32 id);
        List<HospitalModel> GetUserBranches(Int32 id);
        List<MapLocationModel> GetUserLocations(Int32 userId);
        string MapLocation(MapLocationModel obj);
        string MapUserGroup(MapUserGroupModel obj);
        UserPermissionGroups getUserGroupsonBranch(int branchId, int userId);
        MapUserGroupModel getUserGrouponUser(int userId);
        List<UserGroupBranchModel> GetUserGroupBranches(int userId);
        string SaveUsermenu(UserMenuModel obj);
    }
}
