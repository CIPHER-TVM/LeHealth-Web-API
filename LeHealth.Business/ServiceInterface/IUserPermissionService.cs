using LeHealth.Entity.DataModel;
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
    }
}
