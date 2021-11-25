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

        //NEW API STARTS
        [Route("GetSalutation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SalutationModel>> GetSalutation()
        {
            List<SalutationModel> professionList = new List<SalutationModel>();
            try
            {
                professionList = registrationService.GetSalutation();
                var response = new ResponseDataModel<IEnumerable<SalutationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
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
            List<GenderModel> professionList = new List<GenderModel>();
            try
            {
                professionList = registrationService.GetGender(); 
                var response = new ResponseDataModel<IEnumerable<GenderModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
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
            List<KinRelationModel> professionList = new List<KinRelationModel>();
            try
            {
                professionList = registrationService.GetKinRelation(); 
                var response = new ResponseDataModel<IEnumerable<KinRelationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
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
                //  consultationList.Clear();
                // dispose can be managed here
            }
        }


        [HttpPost]
        [Route("GetMaritalStatus")]
        public ResponseDataModel<IEnumerable<MaritalStatusModel>> GetMaritalStatus()
        {
            List<MaritalStatusModel> patientList = new List<MaritalStatusModel>();
            try
            {
                patientList = registrationService.GetMaritalStatus();
                var response = new ResponseDataModel<IEnumerable<MaritalStatusModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
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
        [Route("GetRegsteredDataById")]
        public ResponseDataModel<IEnumerable<PatientModel>> GetRegsteredDataById(PatientModel patientId)
        {
            List<PatientModel> patientList = new List<PatientModel>();
            try
            {
                patientList = registrationService.GetRegsteredDataById(patientId.PatientId);
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
