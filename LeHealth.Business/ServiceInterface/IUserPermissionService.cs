﻿using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IUserPermissionService
    {
        string SaveUserGroup(UserGroupModel obj);
        List<UserGroupModel> getUserGroups();
        UserGroupModel getUserGroup(int id);
        string SaveUser(UserModel obj);
        List<UserModel> GetUsers();
        UserModel GetUser(int id);
        List<HospitalModel> GetUserBranches(int id);
        List<MapLocationModel> GetUserLocations(int userId);
        string MapLocation(MapLocationModel obj);
        string MapUserGroup(MapUserGroupModel obj);
        List<UserGroupModel> getUserGroupsonBranch(int branchId);
        MapUserGroupModel getUserGrouponUser(int userId);
    }
}
