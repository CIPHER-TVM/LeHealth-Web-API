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
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> logger;
        private readonly ILocationService locationservice;
        public LocationController(ILogger<LocationController> _logger, ILocationService _locationservice)
        {
            logger = _logger;
            locationservice = _locationservice;
        }
        [HttpPost]
        [Route("Save")]
        public ResponseDataModel<string> Save(LocationModel obj)
        {
            try
            {
                var location = locationservice.Save(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = location,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "LocationController", "Save()");

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
        [Route("GetLocations")]
        public ResponseDataModel<IEnumerable<LocationModel>> GetLocations([FromBody] int HospitalId)
        {
            List<LocationModel> Location = new List<LocationModel>();
            try
            {
                Location = locationservice.GetLocations(HospitalId);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Location
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LocationModel>>()
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
        [Route("GetLocationTypes")]
        public ResponseDataModel<IEnumerable<LocationType>> GetLocationTypes()
        {
            List<LocationType> Location = new List<LocationType>();
            try
            {
                Location = locationservice.GetLocationTypes();
                var response = new ResponseDataModel<IEnumerable<LocationType>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Location
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LocationType>>()
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
        [Route("GetLocationById")]
        public ResponseDataModel<LocationModel> GetLocationById([FromBody] int LocationId)
        {
            LocationModel Location = new LocationModel();
            try
            {
                Location = locationservice.GetLocationById(LocationId);
                var response = new ResponseDataModel<LocationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Location
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<LocationModel>()
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
