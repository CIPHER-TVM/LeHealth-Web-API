using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers
{
    [Route("api/ServiceOrder")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly ILogger<ServiceOrderController> logger;
        private readonly IServiceOrderService serviceorderService;
        public ServiceOrderController(ILogger<ServiceOrderController> _logger, IServiceOrderService _serviceOrderService)
        {
            logger = _logger;
            serviceorderService = _serviceOrderService;
        }
        [HttpPost]
        [Route("GetItemsGroup/{groupId}")]
        public ResponseDataModel<IEnumerable<GroupModel>> GetItemsGroup(int groupId)
        {
            try
            {
                List<GroupModel> itemGroupList = new List<GroupModel>();
                itemGroupList = serviceorderService.GetItemsGroup(groupId);
                var response = new ResponseDataModel<IEnumerable<GroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GroupModel>>()
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
        /// <summary>
        /// API for getting service items in a package
        /// </summary>
        /// <param name="packId">Package Id</param>
        /// <returns>Service item list</returns>
        [HttpPost]
        [Route("GetPackageItem/{packId}")]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetPackageItem(int packId)
        {
            
            try
            {
                List<ItemsByTypeModel> itemGroupList = new List<ItemsByTypeModel>();
                itemGroupList = serviceorderService.GetPackageItem(packId);
                var response = new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
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
        /// <summary>
        /// API for saving a service item
        /// </summary>
        /// <param name="asm">Service item Details</param>
        /// <returns>success or failure to return</returns>
        [Route("InsertService")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> InsertService(AvailableServiceModel asm)
        {
            try
            {
                string message = string.Empty;
                message = serviceorderService.InsertService(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// API for saving a service item
        /// </summary>
        /// <param name="asm">Service item Details</param>
        /// <returns>success or failure to return</returns>
        [Route("InsertServiceNew")]
        [HttpPost]
        public ResponseDataModel<ServiceInsertResponse> InsertServiceNew(ServiceInsertInputModel siim)
        {
            try
            {
                ServiceInsertResponse groups = new ServiceInsertResponse();

                groups = serviceorderService.InsertServiceNew(siim);
                var response = new ResponseDataModel<ServiceInsertResponse>()
                {
                    Status = HttpStatusCode.OK,
                    Response = groups
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ServiceInsertResponse>()
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
        /// <summary>
        /// API for canclling a service order
        /// </summary>
        /// <param name="asm">Service order Id</param>
        /// <returns>Success or reason for failure</returns>
        [Route("CancelServiceOrder")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> CancelServiceOrder(AvailableServiceModel asm)
        {
            try
            {
                string message = string.Empty;
                message = serviceorderService.CancelServiceOrder(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// API for services with filter GroupId,Patient Id, and branch Id
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAvailableService")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetAvailableService(AvailableServiceModel asm)
        {
            try
            {
                List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
                itemGroupList = serviceorderService.GetAvailableService(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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

        /// <summary>
        /// API For getting profile list
        /// </summary>
        /// <param name="pm">if profile id is zero then returns all profile names. else returns specific profile details</param>
        /// <returns>Profile list</returns>

        [HttpPost]
        [Route("GetProfile")]
        public ResponseDataModel<IEnumerable<ProfileModel>> GetProfile(ProfileModel pm)
        {
           
            try
            {
                List<ProfileModel> profileList = new List<ProfileModel>();
                profileList = serviceorderService.GetProfile(pm);
                var response = new ResponseDataModel<IEnumerable<ProfileModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = profileList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfileModel>>()
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


        /// <summary>
        /// API For Getting service items in profile
        /// </summary>
        /// <param name="pm">Profile id</param>
        /// <returns>Returns service items</returns>
        [HttpPost]
        [Route("GetProfileItem")]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetProfileItem(ProfileModel pm)
        {
            try
            {
                List<ItemsByTypeModel> profileItemList = new List<ItemsByTypeModel>();

                profileItemList = serviceorderService.GetProfileItem(pm);
                var response = new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = profileItemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
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
        /// <summary>
        /// API FOr getting latest consultation details of a patient
        /// </summary>
        /// <param name="asm">Consultant Id And patient id</param>
        /// <returns>Latest consultation data</returns>
        [HttpPost]
        [Route("GetLastConsultation")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetLastConsultation(AvailableServiceModel asm)
        {
            try
            {
                List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
                itemGroupList = serviceorderService.GetLastConsultation(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// Search service data
        /// </summary>
        /// <param name="asm">Search Data in LH_Service Table</param>
        /// <returns>Service list</returns>
        [HttpPost]
        [Route("GetServicesOrderByDate")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetServicesOrderByDate(AvailableServiceModel asm)
        {
            try
            {
                List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();

                itemGroupList = serviceorderService.GetServicesOrderByDate(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// Get service data on page load.
        /// </summary>
        /// <param name="asm">Data in LH_Service Table</param>
        /// <returns>List of service data as per filter conditions </returns>
        [HttpPost]
        [Route("GetServicesOrderLoad")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetServicesOrderLoad(AvailableServiceModel asm)
        {
            
            try
            {
                List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
                itemGroupList = serviceorderService.GetServicesOrderLoad(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// Get service order's itemdetails 
        /// </summary>
        /// <param name="cm">Data in  LH_ServiceDet Table</param>
        /// <returns>Item Data list</returns>
        [HttpPost]
        [Route("GetServicesOrderDetailById/{sid}")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetServicesOrderDetailById(int sid)
        {
            try
            {
                List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
                itemGroupList = serviceorderService.GetServicesOrderDetailById(sid);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        /// <summary>
        /// Get service group list
        /// </summary>
        /// <param name="asm">Data in LH_ServiceGroup Table</param>
        /// <returns>Service group list</returns>
        [HttpPost]
        [Route("GetServicesGroups")]
        public ResponseDataModel<IEnumerable<ServiceGroupModel>> GetServicesGroups()
        {
            try
            {
                List<ServiceGroupModel> serviceGroups = new List<ServiceGroupModel>();

                serviceGroups = serviceorderService.GetServicesGroups();

                var response = new ResponseDataModel<IEnumerable<ServiceGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = serviceGroups
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ServiceGroupModel>>()
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
    }
}
