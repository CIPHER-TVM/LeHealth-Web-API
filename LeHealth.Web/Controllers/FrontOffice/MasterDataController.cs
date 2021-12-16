using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/MasterData")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly ILogger<MasterDataController> logger;
        private readonly IMasterDataService masterdataService;
        public MasterDataController(ILogger<MasterDataController> _logger, IMasterDataService _masterdataService)
        {
            logger = _logger;
            masterdataService = _masterdataService;
        }
        [Route("GetProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProffessionModel>> GetProfession()
        {
            List<ProffessionModel> professionList = new List<ProffessionModel>();
            try
            {
                professionList = masterdataService.GetProfession();
                var response = new ResponseDataModel<IEnumerable<ProffessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProffessionModel>>()
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
                // dispose can be managed here
            }
        }

        [Route("GetAppType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AppTypeModel>> GetAppType()
        {
            List<AppTypeModel> professionList = new List<AppTypeModel>();
            try
            {
                professionList = masterdataService.GetAppType();
                var response = new ResponseDataModel<IEnumerable<AppTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AppTypeModel>>()
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

        [Route("GetDepartments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartments()
        {
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            try
            {
                departmentList = masterdataService.GetDepartments();
                var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = departmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DepartmentModel>>()
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
                // departmentList.Clear();

            }
        }
        [Route("GetReligion")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ReligionModel>> GetReligion()
        {
            List<ReligionModel> religionList = new List<ReligionModel>();
            try
            {
                religionList = masterdataService.GetReligion();
                var response = new ResponseDataModel<IEnumerable<ReligionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = religionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ReligionModel>>()
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
                // departmentList.Clear();

            }
        }
        //Zone Management Start

        [Route("GetAllZones")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetAllZones()
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();
            try
            {
                zoneList = masterdataService.GetAllZone();
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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
                // departmentList.Clear();

            }
        }

        [Route("GetZoneById/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetZoneById(int zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();
            try
            {
                zoneList = masterdataService.GetZoneById(zoneId);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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
                // departmentList.Clear();

            }
        }

        [Route("InsertZone")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> InsertZone(ZoneModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertZone(zone);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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

        [Route("UpdateZone")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> UpdateZone(ZoneModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.UpdateZone(zone);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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

        [Route("DeleteZone/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> DeleteZone(int zoneId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteZone(zoneId);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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
