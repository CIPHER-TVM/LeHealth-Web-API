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

        public UserGroupModel getUserGroup(int id)
        {

            return userpermissionmanager.getUserGroup(id);
        }

        public List<UserGroupModel> getUserGroups()
        {
            return userpermissionmanager.getUserGroups();
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

        public UserModel GetUser(int id)
        {
            return userpermissionmanager.GetUser(id);
        }

        public List<HospitalModel> GetUserBranches(int id)
        {
            return userpermissionmanager.GetUserBranches(id);
        }

        public List<MapLocationModel> GetUserLocations(int userId)
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
    }
}
