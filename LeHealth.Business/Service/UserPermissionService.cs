using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionManager userpermissionmanager;
        public UserPermissionService(IUserPermissionManager _userpermissionmanager)
        {
            userpermissionmanager = _userpermissionmanager;
        }

        public UserGroupModel GetUserGroup(Int32 id)
        {

            return userpermissionmanager.GetUserGroup(id);
        }

        public List<UserGroupModel> GetUserGroups(int branchId)
        {
            return userpermissionmanager.GetUserGroups(branchId);
        }
        public UserPermissionGroups GetUserGroupsonBranch(int branchId, int userId)
        {
            return userpermissionmanager.GetUserGroupsonBranch(branchId, userId);
        }

        public string SaveUserGroup(UserGroupModel obj)
        {
            return userpermissionmanager.SaveUserGroup(obj);
        }
        public string SaveUser(UserModel obj)
        {
            return userpermissionmanager.SaveUser(obj);
        }

        public List<UserModel> GetUsers(Int32 branchId)
        {
            return userpermissionmanager.GetUsers(branchId);
        }

        public UserModel GetUser(Int32 id)
        {
            return userpermissionmanager.GetUser(id);
        }

        public List<HospitalModel> GetUserBranches(Int32 id)
        {
            return userpermissionmanager.GetUserBranches(id);
        }
        public List<UserGroupBranchModel> GetUserGroupBranches(Int32 id)
        {
            return userpermissionmanager.GetUserGroupBranches(id);
        }

        public List<MapLocationModel> GetUserLocations(Int32 userId)
        {
            List<MapLocationModel> obj = userpermissionmanager.GetUserLocations(userId);
            obj.ForEach(a =>
            {
                a.LocationIds = new List<string>(a.Locationstring.Split(","));
            });
            return obj;
        }

        public string MapLocation(MapLocationModel obj)
        {
            return userpermissionmanager.MapLocation(obj);
        }
        public string MapUserGroup(MapUserGroupModel obj)
        {
            return userpermissionmanager.MapUserGroup(obj);
        }

        public MapUserGroupModel GetUserGrouponUser(int userId)
        {
            MapUserGroupModel obj = userpermissionmanager.GetUserGrouponUser(userId);

            return obj;
        }
        public string SaveUsermenu(UserMenuModel obj)
        {
            return userpermissionmanager.SaveUsermenu(obj);
        }
    }
}
