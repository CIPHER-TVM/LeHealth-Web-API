using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class UserPermissionService:IUserPermissionService
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

        public List<UserGroupModel> getUserGroups()
        {
            return userpermissionmanager.getUserGroups();
        }
        public List<UserGroupModel> getUserGroupsonBranch(int branchId)
        {
            return userpermissionmanager.getUserGroupsonBranch(branchId);
        }

        public string SaveUserGroup(UserGroupModel obj)
        {
            return userpermissionmanager.SaveUserGroup(obj);
        }
        public string SaveUser(UserModel obj)
        {
            return userpermissionmanager.SaveUser(obj);
        }

        public List<UserModel> GetUsers()
        {
            return userpermissionmanager.GetUsers();
        }

        public UserModel GetUser(Int32 id)
        {
            return userpermissionmanager.GetUser(id);
        }

        public List<HospitalModel> GetUserBranches(Int32 id)
        {
            return userpermissionmanager.GetUserBranches(id);
        }

        public List<MapLocationModel> GetUserLocations(Int32 userId)
        {
            List <MapLocationModel> obj= userpermissionmanager.GetUserLocations(userId);
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
    }
}
