using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IUserPermissionService
    {
        String SaveUserGroup(UserGroupModel obj);
        List<UserGroupModel> getUserGroups();
        UserGroupModel getUserGroup(int id);
        String SaveUser(UserModel obj);
        List<UserModel> GetUsers();
        UserModel GetUser(int id);
        List<HospitalModel> GetUserBranches(int id);
        List<MapLocationModel> GetUserLocations(int userId);
        String MapLocation(MapLocationModel obj);
    }
}
