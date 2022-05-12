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
        /// <summary>
        /// For getting list of all patients in a hospital branch
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAllPatient/{BranchId}")]
        public ResponseDataModel<IEnumerable<AllPatientModel>> GetAllPatient(int BranchId)
        {
            //try
            //{
                List<AllPatientModel> patientList = new List<AllPatientModel>();
                patientList = registrationService.GetAllPatient(BranchId);
                var response = new ResponseDataModel<IEnumerable<AllPatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            //}
            //catch (Exception ex)
            //{
            //    logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
            //    return new ResponseDataModel<IEnumerable<AllPatientModel>>()
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
        /// <summary>
        /// Save new patient details,Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="patientDetail"></param>
        ///  All details regarding patient
        /// <returns>
        /// Success or failure status
        /// </returns>


        [HttpPost]
        [Route("InsertPatientRegistration")]
        public ResponseDataModel<IEnumerable<PatientModel>> InsertPatientRegistration([FromForm] PatientRequestModel obj)
        {
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
        /// <summary>
        /// API For Uploading a patient's documents
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>success or reason for failure</returns>
        [HttpPost]
        [Route("UploadPatientDocuments")]
        public ResponseDataModel<string> UploadPatientDocuments([FromForm] PatientRequestModel obj)
        {
            try
            {
                PatientRegModel patientDetail = JsonConvert.DeserializeObject<PatientRegModel>(obj.PatientJson);
                patientDetail.PatientDocs = obj.PatientDocs;
                patientDetail.PatientPhoto = obj.PatientPhoto;
                string registrationDetail = registrationService.UploadPatientDocuments(patientDetail);
                ErrorResponse er = new ErrorResponse();
                var response = new ResponseDataModel<string>()
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
            finally
            {
            }
        }
        [HttpPost]
        [Route("GetRegisteredDataById")]
        public ResponseDataModel<IEnumerable<PatientModel>> GetRegisteredDataById(PatientModel patient)
        {
            //Check API Working before deleting code
            //// IServiceCollection services = new ServiceCollection();
            //// services.AddControllers()
            ////.AddJsonOptions(options =>
            ////{
            ////    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            ////});
            //// services.AddCors(c =>
            //// {
            ////     c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //// });
            try
            {
                List<PatientModel> patientList = new List<PatientModel>();
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
        /// <summary>
        /// Searching patient data in patient list with a number of filters like name etc.
        /// </summary>
        /// <param name="patientDetails"></param>
        /// <returns>Patient list</returns>
        [Route("SearchPatientInList")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AllPatientModel>> SearchPatientInList(PatientSearchModel patientDetails)
        {
            try
            {
                List<AllPatientModel> patientList = new List<AllPatientModel>();
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
        /// <summary>
        /// For getting access information of uploaded files of a patient. 
        /// </summary>
        /// <param name="patientDetails">patientDetails.PatientId is primary key of patient's table</param>
        /// <returns></returns>
        [Route("ViewPatientFiles")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AllPatientModel>> ViewPatientFiles(PatientModel patientDetails)
        {
            try
            {
                List<AllPatientModel> patientList = new List<AllPatientModel>();

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
        public ResponseDataModel<string> SaveReRegistration(PatientModel patientDetail)
        {
            try
            {
                string msg = string.Empty;
                string registrationDetail = registrationService.SaveReRegistration(patientDetail);
                if (registrationDetail == "Saved Successfully")
                {
                    msg = "success";
                }
                else
                {
                    msg = registrationDetail;
                }
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = msg
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            finally
            {
            }
        }
        /// <summary>
        /// For blocking a patient. A blocked patient can't
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>success or reason for failure</returns>

        [Route("BlockPatient")]
        [HttpPost]
        public ResponseDataModel<string> BlockUnblockPatient(PatientModel patient)
        {
            try
            {
                string msg = string.Empty;
                msg = registrationService.BlockPatient(patient);

                var response = new ResponseDataModel<string>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            finally
            {
            }
        }
        /// <summary>
        /// Remove specific file of patient
        /// </summary>
        /// <param name="rlm">rlm.Id is file's unique id</param>
        /// <returns>success or reason for failure</returns>
        [Route("DeletePatRegFiles")]
        [HttpPost]
        public ResponseDataModel<string> DeletePatRegFiles(RegDocLocationModel rlm)
        {
            try
            {
                string msg = string.Empty;
                msg = registrationService.DeletePatRegFiles(rlm.Id);
                var response = new ResponseDataModel<string>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            finally
            {
            }
        }

        /// <summary>
        /// Unblock a blocked patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>success or reason for failure</returns>

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
