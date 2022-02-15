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
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

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
            }
        }



      
        /// <summary>
        /// Save new patient details,Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="patientDetail"></param>
        ///  All details regarding patient
        /// <returns>
        /// Success or failure status
        /// </returns>
        ///  



        [HttpPost]
        [Route("InsertPatientRegistration")]
        public ResponseDataModel<IEnumerable<PatientModel>> InsertPatientRegistration([FromForm] PatientRequestModel obj)
        {
            string message = string.Empty;
            try
            {
                PatientRegModel patientDetail = JsonConvert.DeserializeObject<PatientRegModel>(obj.PatientJson);
                patientDetail.PatientDocs = obj.PatientDocs;
                patientDetail.PatientPhoto = obj.PatientPhoto;
                List<PatientRegModel> registrationDetail = registrationService.InsertPatient(patientDetail);
                ErrorResponse er = new ErrorResponse();
                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Response = registrationDetail,
                    Status = HttpStatusCode.OK,
                    Message = registrationDetail[0].ErrorMessage,
                    ErrorMessage = er
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientModel>>()
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
        [Route("UploadPatientDocuments")]
        public ResponseDataModel<IEnumerable<PatientModel>> UploadPatientDocuments([FromForm] PatientRequestModel obj)
        {
            string message = string.Empty;
            try
            {
                PatientRegModel patientDetail = JsonConvert.DeserializeObject<PatientRegModel>(obj.PatientJson);
                patientDetail.PatientDocs = obj.PatientDocs;
                patientDetail.PatientPhoto = obj.PatientPhoto;
                string registrationDetail = registrationService.UploadPatientDocuments(patientDetail);
                ErrorResponse er = new ErrorResponse();
                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Response = null,
                    Status = HttpStatusCode.OK,
                    Message = registrationDetail,
                    ErrorMessage = er
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientModel>>()
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
        [Route("ValidateHL7")]
        public string ValidateHL7()
        {
            string body = string.Empty;
            using (var reader = new StreamReader(Request.Body))
            {
                body = reader.ReadToEndAsync().Result;//.ReadToEnd().ToString(); 
            }
            string registrationDetail = registrationService.ValidateHL7(body);
            return registrationDetail;
        }



        [HttpPost]
        [Route("GetRegisteredDataById")]
        public ResponseDataModel<IEnumerable<PatientModel>> GetRegisteredDataById(PatientModel patient)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.PropertyNamingPolicy = null;
           });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            List<PatientModel> patientList = new List<PatientModel>();
            try
            {
                patientList = registrationService.GetRegisteredDataById(patient.PatientId);
                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientModel>>()
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

        [Route("SearchPatientInList")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AllPatientModel>> SearchPatientInList(PatientSearchModel patientDetails)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            try
            {
                patientList = registrationService.SearchPatientInList(patientDetails);
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
            }
        }

        [Route("ViewPatientFiles")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AllPatientModel>> ViewPatientFiles(PatientModel patientDetails)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            try
            {
                patientList = registrationService.ViewPatientFiles(patientDetails.PatientId);
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
            }
        }



        [Route("SaveReRegistration")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientModel>> SaveReRegistration(PatientModel patientDetail)
        {
            string msg = string.Empty;
            try
            {
                string registrationDetail = registrationService.SaveReRegistration(patientDetail);
                if (registrationDetail == "Saved Successfully")
                {
                    msg = "success";
                }
                else
                {
                    msg = registrationDetail;
                }
                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = msg
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientModel>>()
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


        [Route("BlockPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> BlockUnblockPatient(PatientModel patient)
        {
            try
            {
                string msg = string.Empty;
                msg = registrationService.BlockPatient(patient);

                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultationModel>>()
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

        [Route("DeletePatRegFiles")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<String>> DeletePatRegFiles(RegDocLocationModel rlm)
        {
            try
            {
                string msg = string.Empty;
                msg = registrationService.DeletePatRegFiles(rlm.Id);

                var response = new ResponseDataModel<IEnumerable<String>>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<String>>()
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



        [Route("UnblockPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> UnblockPatient(PatientModel patient)
        {
            try
            {
                string msg = string.Empty;
                msg = registrationService.UnblockPatient(patient);

                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultationModel>>()
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
