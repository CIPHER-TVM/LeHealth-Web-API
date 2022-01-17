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
        UserGroupModel getUserGroup(int id);
        string SaveUser(UserModel obj);
        List<UserModel> GetUsers();
        UserModel GetUser(int id);
    }
}
