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

        public UserGroupModel getUserGroup(Int32 id)
        {

            return userpermissionmanager.getUserGroup(id);
        }

        public List<UserGroupModel> getUserGroups(int branchId)
        {
            return userpermissionmanager.getUserGroups(branchId);
        }
        public UserPermissionGroups getUserGroupsonBranch(int branchId, int userId)
        {
            return userpermissionmanager.getUserGroupsonBranch(branchId, userId);
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

        public MapUserGroupModel getUserGrouponUser(int userId)
        {
            MapUserGroupModel obj = userpermissionmanager.getUserGrouponUser(userId);

            return obj;
        }

        public string SaveUsermenu(UserMenuModel obj)
        {
            return userpermissionmanager.SaveUsermenu(obj);
        }
    }
}
