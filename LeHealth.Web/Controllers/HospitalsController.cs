using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeHealth.Entity.ViewModel;
using LeHealth.Service.ServiceInterface;
using LeHealth.Entity.DataModel;
using System.Data;

namespace LeHealth.Catalogue.API.Controllers
{


    [Route("api/Hospitals")]
    [ApiController]

    public class HospitalsController : ControllerBase
    {
        private readonly ILogger<HospitalsController> logger;
        private readonly IHospitalsService hospitalsService;

        public HospitalsController(ILogger<HospitalsController> _logger, IHospitalsService _hospitalsService)
        {
            logger = _logger;
            hospitalsService = _hospitalsService;
        }

        /// <summary>
        /// To get list of hospitals .
        /// branches=hospitals
        /// </summary>
        /// <returns>
        /// List of Hospitals
        /// </returns>

        [Route("GetUserHospitals")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserHospitals()
        {
            try
            {
                var hospitals = hospitalsService.GetUserHospitals();
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals
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
            finally
            {
                // dispose can be managed here
            }
        }
    
       
    }
}
