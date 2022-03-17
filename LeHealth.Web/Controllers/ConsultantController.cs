﻿using LeHealth.Service.ServiceInterface;
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

namespace LeHealth.Base.API.Controllers
{
    [Route("api/Consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        /// <summary>
        /// initialization
        /// </summary>
        private readonly ILogger<ConsultantController> logger;
        private readonly IConsultantService consultantService;

        public ConsultantController(ILogger<ConsultantController> _logger, IConsultantService _consultantService)
        {
            logger = _logger;
            consultantService = _consultantService;

        }

        [Route("SearchConsultationById/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> SearchConsultation(int consultantId)
        {
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
                consultationList = consultantService.SearchConsultationById(consultantId);
                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultationList
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


        [HttpPost]
        [Route("SearchAppointmentByConsultantId/{consultantId}")]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> SearchAppointmentByConsultantId(int consultantId)
        {
            List<SearchAppointmentModel> appointmentList = new List<SearchAppointmentModel>();
            try
            {
                appointmentList = consultantService.SearchAppointmentByConsultantId(consultantId);
                var response = new ResponseDataModel<IEnumerable<SearchAppointmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SearchAppointmentModel>>()
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

        [Route("SearchPatientByConsultantId/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientListModel>> SearchPatientByConsultantId(int consultantId)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();
            try
            {
                patientList = consultantService.SearchPatientByConsultantId(consultantId);
                var response = new ResponseDataModel<IEnumerable<PatientListModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientListModel>>()
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
        /// To Save or update Consultant .
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateConsultant")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> InsertUpdateConsultant(ConsultantMasterModel consultant)
        {
            string message = string.Empty;
            try
            {
                message = consultantService.InsertUpdateConsultant(consultant);
                var response = new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
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

        [Route("GetAllConsultants/{consultantType}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> GetAllConsultants(int consultantType)
        {
            List<ConsultantMasterModel> consultantList = new List<ConsultantMasterModel>();
            try
            {
                consultantList = consultantService.GetAllConsultants(consultantType);
                var response = new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
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

        [Route("InsertConsultantService")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantServiceModel>> InsertConsultantService(ConsultantServiceModel consultant)
        {
            string message = string.Empty;
            try
            {
                message = consultantService.InsertConsultantService(consultant);
                var response = new ResponseDataModel<IEnumerable<ConsultantServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantServiceModel>>()
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
        [Route("DeleteConsultantService/{serviceId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteConsultantService(int serviceId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultantService(serviceId);

                var response = new ResponseDataModel<IEnumerable<string>>()
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

        [Route("GetConsultantServices/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantServiceModel>> GetConsultantServices(int consultantId)
        {
            List<ConsultantServiceModel> consultantServices = new List<ConsultantServiceModel>();
            try
            {
                consultantServices = consultantService.GetConsultantServices(consultantId);
                var response = new ResponseDataModel<IEnumerable<ConsultantServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantServices
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantServiceModel>>()
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

        [Route("InsertConsultantDrugs")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> InsertConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            string message = string.Empty;
            try
            {
                message = consultantService.InsertConsultantDrugs(consultantDrug);
                var response = new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
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
        [Route("GetConsultantDrugs/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> GetConsultantDrugs(int consultantId)
        {
            List<ConsultantDrugModel> consultantDrugs = new List<ConsultantDrugModel>();
            try
            {
                consultantDrugs = consultantService.GetConsultantDrugs(consultantId);
                var response = new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantDrugs
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
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
        [Route("DeleteConsultantDrug/{drugId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteConsultantDrug(int drugId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultantDrug(drugId);

                var response = new ResponseDataModel<IEnumerable<string>>()
                {
                    Message = msg,
                    Status = HttpStatusCode.OK
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<string>>()
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

        [Route("UpdateConsultantDrugs")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            try
            {
                string appointmentret = consultantService.UpdateConsultantDrugs(consultantDrug);
                var response = new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = appointmentret,
                    Response = null
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
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
