using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers.UserPermission
{
    [Route("api/UserPermission")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly ILogger<UserPermissionController> logger;
        private readonly IUserPermissionService permissionservice;
        public UserPermissionController(ILogger<UserPermissionController> _logger, IUserPermissionService _permissionservice)
        {
            logger = _logger;
            permissionservice = _permissionservice;
        }

        

        [HttpPost]
        [Route("SaveUserGroup")]
        public ResponseDataModel<string> SaveUserGroup(UserGroupModel obj)
        {
            try
            {
                string retval = permissionservice.SaveUserGroup(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("SaveUsermenu")]
        public ResponseDataModel<string> SaveUsermenu(UserMenuModel obj)
        {
            try
            {
                string retval = permissionservice.SaveUsermenu(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

        [HttpPost]
        [Route("getUserGroupsonBranch/{BranchId}/{UserId}")]
        public ResponseDataModel<UserPermissionGroups> getUserGroupsonBranch(int BranchId,int UserId)
        {
            UserPermissionGroups groups = new UserPermissionGroups();
            try
            {
                groups = permissionservice.getUserGroupsonBranch(BranchId, UserId);
                var response = new ResponseDataModel<UserPermissionGroups>()
                {
                    Status = HttpStatusCode.OK,
                    Response = groups
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<UserPermissionGroups>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }

        [HttpPost]
        [Route("getUserGroups")]
        public ResponseDataModel<IEnumerable<UserGroupModel>> getUserGroups()
        {
            List<UserGroupModel> groups = new List<UserGroupModel>();
            try
            {
                groups = permissionservice.getUserGroups();
                var response = new ResponseDataModel<IEnumerable<UserGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = groups
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<UserGroupModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        [HttpPost]
        [Route("getUserGroup")]
        public ResponseDataModel<UserGroupModel> getUserGroup([FromBody] int Id)
        {
            UserGroupModel group = new UserGroupModel();
            try
            {
                group = permissionservice.getUserGroup(Id);
                var response = new ResponseDataModel<UserGroupModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = group
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<UserGroupModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        [HttpPost]
        [Route("SaveUser")]
        public ResponseDataModel<string> SaveUser(UserModel obj)
        {
            try
            {
                string retval = permissionservice.SaveUser(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

        [HttpPost]
        [Route("GetUsers")]
        public ResponseDataModel<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                List<UserModel> retval = permissionservice.GetUsers();
                var response = new ResponseDataModel<IEnumerable<UserModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<IEnumerable<UserModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("GetUser")]
        public ResponseDataModel<UserModel> GetUser([FromBody] int Id)
        {
            try
            {
                UserModel retval = permissionservice.GetUser(Id);
                var response = new ResponseDataModel<UserModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<UserModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("MapLocation")]
        public ResponseDataModel<string> MapLocation(MapLocationModel obj)
        {
            try
            {
                string retval = permissionservice.MapLocation(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [HttpPost]
        [Route("MapUserGroup")]
        public ResponseDataModel<string> MapUserGroup(MapUserGroupModel obj)
        {
            try
            {
                string retval = permissionservice.MapUserGroup(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = retval,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserPermissionController", "SaveUserGroup()");

                return new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [Route("GetUserBranches")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserBranches([FromBody] int UserId)
        {
            try
            {
                List<HospitalModel> hospitals = permissionservice.GetUserBranches(UserId);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserHospitals()");

                return new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }
        [Route("getUserGrouponUser")]
        [HttpPost]
        public ResponseDataModel<MapUserGroupModel> getUserGrouponUser([FromBody] int UserId)
        {
            try
            {
                MapUserGroupModel locations = permissionservice.getUserGrouponUser(UserId);
                var response = new ResponseDataModel<MapUserGroupModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = locations,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserpermissionController", "GetUserLocations()");

                return new ResponseDataModel<MapUserGroupModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

        [Route("GetUserLocations")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MapLocationModel>> GetUserLocations([FromBody] int UserId)
        {
            try
            {
                List<MapLocationModel> locations = permissionservice.GetUserLocations(UserId);
                var response = new ResponseDataModel<IEnumerable<MapLocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = locations,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserpermissionController", "GetUserLocations()");

                return new ResponseDataModel<IEnumerable<MapLocationModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

        [Route("GetUserMappedGroups")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MapLocationModel>> GetUserMappedGroups([FromBody] int UserId)
        {
            try
            {
                List<MapLocationModel> locations = permissionservice.GetUserLocations(UserId);
                var response = new ResponseDataModel<IEnumerable<MapLocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = locations,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UserpermissionController", "GetUserLocations()");

                return new ResponseDataModel<IEnumerable<MapLocationModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }

    }
}
