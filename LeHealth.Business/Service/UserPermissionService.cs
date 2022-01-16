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
    }
}
