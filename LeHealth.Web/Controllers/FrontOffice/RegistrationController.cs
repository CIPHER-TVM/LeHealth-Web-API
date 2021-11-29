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

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> logger;
        private readonly IRegistrationService registrationService;
       
        //private readonly IFileUploadService fileUploadService; 
        //public RegistrationController(ILogger<RegistrationController> _logger, IRegistrationService _registrationService,IFileUploadService _fileUploadService)
        public RegistrationController(ILogger<RegistrationController> _logger, IRegistrationService _registrationService)
        {
            logger = _logger;
            registrationService = _registrationService;
            //fileUploadService = _fileUploadService;
           
        }

        ////START
        ////FileTesting
        //[HttpPost]
        //[Route("FileTesting")]
        //public ResponseDataModel<IEnumerable<PatientModel>> FileTesting(AAASampleFileUploadTest fileob)
        //{
        //    List<PatientModel> patientList = new List<PatientModel>();
        //    try
        //    {
        //       // string asdf = fileUploadService.SaveFile(fileob); 
        //        var response = new ResponseDataModel<IEnumerable<PatientModel>>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Response = patientList
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<IEnumerable<PatientModel>>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }

        //        };
        //    }
        //    finally
        //    {
        //    }
        //}
        ////END

       

        //NEW API STARTS
        [Route("GetSalutation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SalutationModel>> GetSalutation()
        {
            List<SalutationModel> salutationList = new List<SalutationModel>();
            try
            {
                salutationList = registrationService.GetSalutation();
                var response = new ResponseDataModel<IEnumerable<SalutationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = salutationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SalutationModel>>()
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

        [Route("GetGender")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GenderModel>> GetGender()
        {
            List<GenderModel> genderList = new List<GenderModel>();
            try
            {
                genderList = registrationService.GetGender();
                var response = new ResponseDataModel<IEnumerable<GenderModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = genderList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GenderModel>>()
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

        [Route("GetKinRelation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<KinRelationModel>> GetKinRelation()
        {
            List<KinRelationModel> kinRelationList = new List<KinRelationModel>();
            try
            {
                kinRelationList = registrationService.GetKinRelation();
                var response = new ResponseDataModel<IEnumerable<KinRelationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = kinRelationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<KinRelationModel>>()
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

        //NEW API ENDS
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
            }
        }


        [HttpPost]
        [Route("GetMaritalStatus")]
        public ResponseDataModel<IEnumerable<MaritalStatusModel>> GetMaritalStatus()
        {
            List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();
            try
            {
                maritalStatusList = registrationService.GetMaritalStatus();
                var response = new ResponseDataModel<IEnumerable<MaritalStatusModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = maritalStatusList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MaritalStatusModel>>()
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
        [HttpPost]
        [Route("GetCommunicationType")]
        public ResponseDataModel<IEnumerable<CommunicationTypeModel>> GetCommunicationType()
        {
            List<CommunicationTypeModel> communicationTypeList = new List<CommunicationTypeModel>();
            try
            {
                communicationTypeList = registrationService.GetCommunicationType();
                var response = new ResponseDataModel<IEnumerable<CommunicationTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = communicationTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CommunicationTypeModel>>()
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
            string message = "";
            try
            {
                PatientRegModel patientDetail = JsonConvert.DeserializeObject<PatientRegModel>(obj.PatientJson);
                patientDetail.PatientDocs = obj.PatientDocs;
                patientDetail.PatientPhoto = obj.PatientPhoto;
                string registrationDetail = registrationService.InsertPatient(patientDetail);
                ErrorResponse er = new ErrorResponse();
                var isNumeric = int.TryParse(registrationDetail, out int n);
                if (isNumeric == true)
                {
                    message = registrationDetail;
                    er.Message = "success";
                }
                else
                {
                    message = "error";
                    er.Message = registrationDetail;
                }
                er.Code = "";

                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message,
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
                // registrationDetail.Clear();

            }
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
                //  consultationList.Clear();
                // dispose can be managed here
            }
        }

        [Route("SaveReRegistration")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientModel>> SaveReRegistration(PatientModel patientDetail)
        {
            string msg = "";
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
                // registrationDetail.Clear();
                // dispose can be managed here
            }
        }


        [Route("BlockPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> BlockUnblockPatient(PatientModel patient)
        {
            try
            {
                string msg = "";
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
                // consultationList.Clear();
                // dispose can be managed here
            }
        }
        [Route("UnblockPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> UnblockPatient(PatientModel patient)
        {
            try
            {
                string msg = "";
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
                // consultationList.Clear();
                // dispose can be managed here
            }
        }



    }
}
