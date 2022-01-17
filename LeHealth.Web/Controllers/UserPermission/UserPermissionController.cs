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
        
    }
}
