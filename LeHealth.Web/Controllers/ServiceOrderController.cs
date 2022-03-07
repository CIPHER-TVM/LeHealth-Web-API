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
            List<GroupModel> itemGroupList = new List<GroupModel>();
            try
            {
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
        [HttpPost]
        [Route("GetPackageItem/{packId}")]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetPackageItem(int packId)
        {
            List<ItemsByTypeModel> itemGroupList = new List<ItemsByTypeModel>();
            try
            {
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

        [Route("InsertService")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> InsertService(AvailableServiceModel asm)
        {
            string message = string.Empty;
            try
            {
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

        [Route("CancelServiceOrder")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> CancelServiceOrder(AvailableServiceModel asm)
        {
            string message = string.Empty;
            try
            {
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

        [HttpPost]
        [Route("GetAvailableService")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetAvailableService(AvailableServiceModel asm)
        {
            List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
            try
            {
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


        [HttpPost]
        [Route("GetProfile")]
        public ResponseDataModel<IEnumerable<ProfileModel>> GetProfile(ProfileModel pm)
        {
            List<ProfileModel> profileList = new List<ProfileModel>();
            try
            {
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

        [HttpPost]
        [Route("GetProfileItem")]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetProfileItem(ProfileModel pm)
        {
            List<ItemsByTypeModel> profileItemList = new List<ItemsByTypeModel>();
            try
            {
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
        [HttpPost]
        [Route("GetLastConsultation")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetLastConsultation(AvailableServiceModel asm)
        {
            List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
            try
            {
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
        [HttpPost]
        [Route("GetServicesOrderByDate")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetServicesOrderByDate(AvailableServiceModel asm)
        {
            List<AvailableServiceModel> itemGroupList = new List<AvailableServiceModel>();
            //try
            //{
                itemGroupList = serviceorderService.GetServicesOrderByDate(asm);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemGroupList
                };
                return response;
            //}
            //catch (Exception ex)
            //{
            //    logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
            //    return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
            //    {
            //        Status = HttpStatusCode.InternalServerError,
            //        Response = null,
            //        ErrorMessage = new ErrorResponse()
            //        {
            //            Message = ex.Message
            //        }

            //    };
            //}
            //finally
            //{
            //}
        }
        
        [HttpPost]
        [Route("GetServicesGroups")]
        public ResponseDataModel<IEnumerable<ServiceGroupModel>> GetServicesGroups()
        {
            List<ServiceGroupModel> serviceGroups = new List<ServiceGroupModel>();
            try
            {
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
