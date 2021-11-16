using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using System.Net;
using Microsoft.AspNetCore.Authorization;



namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> logger;
        private readonly IRegistrationService registrationService;
        public RegistrationController(ILogger<RegistrationController> _logger, IRegistrationService _registrationService)
        {
            logger = _logger;
            registrationService = _registrationService;
        }

        [Route("GetProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProffessionModel>> GetProfession()
        {
            List<ProffessionModel> professionList = new List<ProffessionModel>();
            try
            {
                professionList = registrationService.GetProfession();
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



        [Route("GetRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> GetRateGroup(RateGroupModel rgroup)
        {
            List<RateGroupModel> rategroupList = new List<RateGroupModel>();
            try
            {
                rategroupList = registrationService.GetRateGroup(rgroup.RGroupId);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = rategroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RateGroupModel>>()
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

        [HttpPost]
        [Route("GetAllPatient")]
        public ResponseDataModel<IEnumerable<AllPatientModel>> GetAllPatient()
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            try
            {
                patientList = registrationService.GetAllPatient();
                var response = new ResponseDataModel<IEnumerable<AllPatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AllPatientModel>>()
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
