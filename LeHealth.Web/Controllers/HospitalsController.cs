using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using LeHealth.Entity.ViewModel;
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

        /// <summary>
        /// Initialisation of logger,hospital service objects

        /// </summary>
        public HospitalsController(ILogger<HospitalsController> _logger, IHospitalsService _hospitalsService)
        {
            logger = _logger;
            hospitalsService = _hospitalsService;
        }

        /// <summary>
        /// To get list of hospitals . A controller class. Step One in code execution flow
        /// branches=hospitals
        /// </summary>
        /// <returns>
        /// returns List of Hospitals as JSON
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

        [Route("GetTabOrder")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TabOrderModel>> GetTabOrder(FormNameModel formname)
        {
            List<TabOrderModel> mandatoryList = new List<TabOrderModel>();
            try
            {
                mandatoryList = hospitalsService.GetTabOrder(formname.Formname);
                var response = new ResponseDataModel<IEnumerable<TabOrderModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = mandatoryList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TabOrderModel>>()
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
                //  consultationList.Clear();
                // dispose can be managed here
            }
        }

    }
}
