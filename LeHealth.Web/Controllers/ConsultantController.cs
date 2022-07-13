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

        [Route("SearchConsultationById")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> SearchConsultationById(ConsultationModel consultation)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                consultationList = consultantService.SearchConsultationById(consultation);
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
        [Route("SearchAppointmentByConsultantId")]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> SearchAppointmentByConsultantId(SearchAppointmentModel appointment)
        {
            try
            {
                List<SearchAppointmentModel> appointmentList = new List<SearchAppointmentModel>();
                appointmentList = consultantService.SearchAppointmentByConsultantId(appointment);
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
        /// <summary>
        /// Get Patient details using ConsultantId
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>List of Patient details</returns>

        [Route("SearchPatientByConsultantId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantPatientModel>> SearchPatientByConsultantId(PatientSearchModel patient)
        {

            try
            {
                List<ConsultantPatientModel> patientList = new List<ConsultantPatientModel>();
                patientList = consultantService.SearchPatientByConsultantId(patient);
                var response = new ResponseDataModel<IEnumerable<ConsultantPatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantPatientModel>>()
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
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> InsertUpdateConsultant([FromForm] ConsultantRequestModel obj)
        {
            try
            {
                string message = string.Empty;
                ConsultantRegModel consultantDetail = JsonConvert.DeserializeObject<ConsultantRegModel>(obj.ConsultantJson);

                consultantDetail.PhotoFile = obj.SignaturePhoto;
                message = consultantService.InsertUpdateConsultant(consultantDetail);
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
        /// <summary>
        /// API for getting all consultant's list by consultant type 
        /// </summary>
        /// <param name="consultantType">Type of consultant</param>
        /// <returns>Consultant list</returns>
        [Route("GetAllConsultants")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> GetAllConsultants(ConsultantMasterModel consultant)
        {

            try
            {
                List<ConsultantMasterModel> consultantList = new List<ConsultantMasterModel>();
                consultantList = consultantService.GetAllConsultants(consultant);
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

            try
            {
                string message = string.Empty;
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
        [Route("DeleteConsultantService")]
        [HttpPost]
        public ResponseDataModel<string> DeleteConsultantService(ConsultantItemModel ci)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultantService(ci);
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
        [Route("GetConsultantServices/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantServiceModel>> GetConsultantServices(int consultantId)
        {
            try
            {
                List<ConsultantServiceModel> consultantServices = new List<ConsultantServiceModel>();

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
        public ResponseDataModel<string> InsertConsultantDrugs(List<ConsultantDrugModel> consultantDrugs)
        {
            try
            {

                string message = string.Empty;
                var dupes = consultantDrugs.GroupBy(x => new { x.DrugId })
                   .Where(x => x.Skip(1).Any());
                int count = dupes.Count();
                if (count == 0)
                {
                    //dupes.First().Count()
                    message = consultantService.InsertConsultantDrugs(consultantDrugs);
                }
                else
                {
                    message = "Same Drug has added multiple times";
                }
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
        [Route("UpdateConsultantDrugs")]
        [HttpPost]
        public ResponseDataModel<string> UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            try
            {
                string appointmentret = consultantService.UpdateConsultantDrugs(consultantDrug);
                var response = new ResponseDataModel<string>()
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
        [Route("GetConsultantDrugs")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> GetConsultantDrugs(ConsultantDrugModel consultant)
        {
            try
            {
                List<ConsultantDrugModel> consultantDrugs = new List<ConsultantDrugModel>();

                consultantDrugs = consultantService.GetConsultantDrugs(consultant);
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
        [Route("InsertConsultantDiseases")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseModel>> InsertConsultantDiseases(DiseaseModel disease)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertConsultantDiseases(disease);
                var response = new ResponseDataModel<IEnumerable<DiseaseModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseModel>>()
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
        [Route("GetDiseaseSymptoms/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseSymptomModel>> GetDiseaseSymptoms(int diseaseId)
        {
            try
            {
                List<DiseaseSymptomModel> diseaseSymptoms = new List<DiseaseSymptomModel>();
                diseaseSymptoms = consultantService.GetDiseaseSymptoms(diseaseId);
                var response = new ResponseDataModel<IEnumerable<DiseaseSymptomModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = diseaseSymptoms
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseSymptomModel>>()
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
        [Route("GetDiseaseSigns/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseSignModel>> GetDiseaseSigns(int diseaseId)
        {
            try
            {
                List<DiseaseSignModel> diseaseSigns = new List<DiseaseSignModel>();
                diseaseSigns = consultantService.GetDiseaseSigns(diseaseId);
                var response = new ResponseDataModel<IEnumerable<DiseaseSignModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = diseaseSigns
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseSignModel>>()
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
        [Route("GetDiseaseICD/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseICDModel>> GetDiseaseICD(int diseaseId)
        {
            try
            {
                List<DiseaseICDModel> diseaseSigns = new List<DiseaseICDModel>();
                diseaseSigns = consultantService.GetDiseaseICD(diseaseId);
                var response = new ResponseDataModel<IEnumerable<DiseaseICDModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = diseaseSigns
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseICDModel>>()
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
        [Route("DeleteDiseaseICD/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteDiseaseICD(int diseaseId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteDiseaseICD(diseaseId);
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
        [Route("DeleteDiseaseSymptom/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteDiseaseSymptom(int diseaseId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteDiseaseSymptom(diseaseId);
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
        [Route("DeleteDiseaseSign/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteDiseaseSign(int diseaseId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteDiseaseSign(diseaseId);
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
        [Route("BlockDisease")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> BlockDisease(DiseaseModel disease)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.BlockDisease(disease);
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
        [Route("UnblockDisease")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> UnblockDisease(DiseaseModel disease)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.UnblockDisease(disease);

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
        /// <summary>
        /// Get appointment listing of a consultant in a specific date
        /// </summary>
        /// <param name="appointment">ConsultantId,Appointment Date,Department Id, Branch Id</param>
        /// <returns></returns>
        [Route("GetMyAppointments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> GetMyAppointments(AppointmentModel appointment)
        {
            try
            {
                List<Appointments> appointmentsList = new List<Appointments>();
                appointmentsList = consultantService.GetMyAppointments(appointment);
                var response = new ResponseDataModel<IEnumerable<Appointments>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<Appointments>>()
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
        /// Get consultation listing of a consultant in a specific date
        /// </summary>
        /// <param name="appointment">ConsultantId, Date,Department Id, Branch Id</param>
        /// <returns></returns>
        [Route("GetMyConsultations")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> GetMyConsultations(ConsultantModel consultant)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                consultationList = consultantService.GetMyConsultations(consultant);
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

        /// <summary>
        /// Save Or update schedul data
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [Route("InsertUpdateSchedule")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ScheduleModel>> InsertUpdateSchedule(ScheduleModel schedule)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertUpdateSchedule(schedule);
                var response = new ResponseDataModel<IEnumerable<ScheduleModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ScheduleModel>>()
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
        [Route("GetSchedules")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ScheduleModel>> GetSchedules(ScheduleModelAll schedule)
        {

            try
            {
                List<ScheduleModel> sheduletList = new List<ScheduleModel>();
                sheduletList = consultantService.GetSchedules(schedule);
                var response = new ResponseDataModel<IEnumerable<ScheduleModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sheduletList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ScheduleModel>>()
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

        [Route("DeleteSchedule/{scheduleId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteSchedule(int scheduleId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteSchedule(scheduleId);

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

        [Route("InsertUpdateTimer")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TimerModel>> InsertUpdateTimer(TimerModel timer)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertUpdateTimer(timer);
                var response = new ResponseDataModel<IEnumerable<TimerModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TimerModel>>()
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
        [Route("InsertConsultantItem")]
        [HttpPost]
        public ResponseDataModel<string> InsertConsultantItem(ConsultantItemModel timer)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertConsultantItem(timer);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
        [Route("GetServicesOrderLoadByConsultantId")]
        public ResponseDataModel<IEnumerable<AvailableServiceModel>> GetServicesOrderLoadByConsultantId(AvailableServiceModel availableService)
        {

            try
            {
                List<AvailableServiceModel> availableServices = new List<AvailableServiceModel>();
                availableServices = consultantService.GetServicesOrderLoadByConsultantId(availableService);
                var response = new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = availableServices
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AvailableServiceModel>>()
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
        [Route("GetConsultantServicesItems")]
        public ResponseDataModel<IEnumerable<ConsultantItemModel>> GetConsultantServicesItems(AvailableServiceModel availableService)
        {
            try
            {
                List<ConsultantItemModel> availableServices = new List<ConsultantItemModel>();
                availableServices = consultantService.GetConsultantServicesItems(availableService);
                var response = new ResponseDataModel<IEnumerable<ConsultantItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = availableServices
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantItemModel>>()
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

        [Route("GetFrontOfficeProgressBarsByConsultantId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FrontOfficePBarModel>> GetFrontOfficeProgressBarsByConsultantId(AppointmentModel appointment)
        {
            List<FrontOfficePBarModel> frontOfficePBarList = new List<FrontOfficePBarModel>();
            try
            {

                FrontOfficePBarModel frontOfficePBar = new FrontOfficePBarModel();
                frontOfficePBar = consultantService.GetFrontOfficeProgressBarsByConsultantId(appointment);
                frontOfficePBarList.Add(frontOfficePBar);
                var response = new ResponseDataModel<IEnumerable<FrontOfficePBarModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = frontOfficePBarList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<FrontOfficePBarModel>>()
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
        [Route("GetFrontOfficeProgressBarByConsultantId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FrontOfficeProgressBarModel>> GetFrontOfficeProgressBarByConsultantId(AppointmentModel appointment)
        {
            List<FrontOfficeProgressBarModel> frontOfficePBarList = new List<FrontOfficeProgressBarModel>();
            try
            {

                FrontOfficeProgressBarModel frontOfficePBar = new FrontOfficeProgressBarModel();
                frontOfficePBar = consultantService.GetFrontOfficeProgressBarByConsultantId(appointment);
                frontOfficePBarList.Add(frontOfficePBar);
                var response = new ResponseDataModel<IEnumerable<FrontOfficeProgressBarModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = frontOfficePBarList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<FrontOfficeProgressBarModel>>()
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

        [Route("GetICDBySymptomSign")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ICDModel>> GetICDBySymptomSign(SymptomSignModel ss)
        {

            try
            {
                List<ICDModel> frontOfficePBarList = new List<ICDModel>();
                frontOfficePBarList = consultantService.GetICDBySymptomSign(ss);
                var response = new ResponseDataModel<IEnumerable<ICDModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = frontOfficePBarList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ICDModel>>()
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

        [Route("GetDiseaseDetailsById/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseModel>> GetDiseaseDetailsById(int diseaseId)
        {
            List<DiseaseModel> frontOfficePBarList = new List<DiseaseModel>();
            try
            {

                DiseaseModel frontOfficePBar = new DiseaseModel();
                frontOfficePBar = consultantService.GetDiseaseDetailsById(diseaseId);
                frontOfficePBarList.Add(frontOfficePBar);
                var response = new ResponseDataModel<IEnumerable<DiseaseModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = frontOfficePBarList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseModel>>()
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

        [Route("GetDiseaseByConsultantId/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DiseaseModel>> GetDiseaseByConsultantId(int consultantId)
        {
            try
            {
                List<DiseaseModel> diseaseSigns = new List<DiseaseModel>();
                diseaseSigns = consultantService.GetDiseaseByConsultantId(consultantId);
                var response = new ResponseDataModel<IEnumerable<DiseaseModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = diseaseSigns
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DiseaseModel>>()
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

        [Route("GetConsultantDrugsById")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> GetConsultantDrugsById(ConsultantDrugModel cdm)
        {
            try
            {
                List<ConsultantDrugModel> consultantDrugs = new List<ConsultantDrugModel>();

                consultantDrugs = consultantService.GetConsultantDrugsById(cdm);
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

        [Route("GetConsultantBaseCost")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemRateDetailModel>> GetConsultantBaseCost(ConsultantBaseCostModelAll cbcm)
        {
            try
            {
                List<ItemRateDetailModel> consultantDrugs = new List<ItemRateDetailModel>();
                consultantDrugs = consultantService.GetConsultantBaseCost(cbcm);
                var response = new ResponseDataModel<IEnumerable<ItemRateDetailModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantDrugs
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemRateDetailModel>>()
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
        [Route("GetConsultantBaseCosts")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemRateDetailModel>> GetConsultantBaseCosts(ConsultantBaseCostModelAll cbcm)
        {
            try
            {
                List<ItemRateDetailModel> consultantDrugs = new List<ItemRateDetailModel>();
                consultantDrugs = consultantService.GetConsultantBaseCosts(cbcm);
                var response = new ResponseDataModel<IEnumerable<ItemRateDetailModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantDrugs
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemRateDetailModel>>()
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
        [Route("InsertUpdateConsultantBaseCost")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateConsultantBaseCost(ConsultantBaseCostModelAll ServiceItem)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertUpdateConsultantBaseCost(ServiceItem);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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

        [Route("GetConsultantItemByType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantItemModel>> GetConsultantItemByType(ConsultantItemModel cbcm)
        {
            try
            {
                string message = string.Empty;
                List<ConsultantItemModel> consultantDrugs = new List<ConsultantItemModel>();
                consultantDrugs = consultantService.GetConsultantItemByType(cbcm);
                if (consultantDrugs.Count == 0)
                {
                    message = "Empty";
                }
                else
                {
                    message = "Success";
                }
                var response = new ResponseDataModel<IEnumerable<ConsultantItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message,
                    Response = consultantDrugs
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantItemModel>>()
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



        [Route("InsertConsultantSketch")]
        [HttpPost]
        public ResponseDataModel<string> InsertConsultantSketch(SketchModelAll obj)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertConsultantSketch(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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

        [Route("GetConsultantSketch")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SketchModel>> GetConsultantSketch(SketchModelAll sketch)
        {
            try
            {
                List<SketchModel> consultantDrugs = new List<SketchModel>();
                consultantDrugs = consultantService.GetConsultantSketch(sketch);
                var response = new ResponseDataModel<IEnumerable<SketchModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantDrugs
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SketchModel>>()
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


        [Route("InsertConsultantMarking")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMarkingModel>> InsertConsultantMarking(ConsultantMarkingModel obj)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertUpdateConsultantMarking(obj);
                var response = new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
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

        [Route("GetConsultantMarkings")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMarkingModel>> GetConsultantMarkings(ConsultantMarkingModel consultantId)
        {

            try
            {
                List<ConsultantMarkingModel> consultantMarkings = new List<ConsultantMarkingModel>();
                consultantMarkings = consultantService.GetConsultantMarkings(consultantId);
                var response = new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantMarkings
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
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
        [Route("DeleteConsultantMarkings/{markId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteConsultantMarkings(int markId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultantMarkings(markId);

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
        [Route("GetConsultantMarkingsById/{markId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMarkingModel>> GetConsultantMarkingsById(int markId)
        {

            try
            {
                List<ConsultantMarkingModel> consultantMarkings = new List<ConsultantMarkingModel>();
                consultantMarkings = consultantService.GetConsultantMarkingsById(markId);
                var response = new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantMarkings
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMarkingModel>>()
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
        [Route("DeleteConsultantDisease/{diseaseId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteConsultantDisease(int diseaseId)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultantDisease(diseaseId);

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
        [Route("GetConsultantById/{consultantId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> GetConsultantById(int consultantId)
        {
            List<ConsultantMasterModel> frontOfficePBarList = new List<ConsultantMasterModel>();
            //try
            //{

            ConsultantMasterModel frontOfficePBar = new ConsultantMasterModel();
            frontOfficePBar = consultantService.GetConsultantById(consultantId);
            frontOfficePBarList.Add(frontOfficePBar);
            var response = new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
            {
                Status = HttpStatusCode.OK,
                Response = frontOfficePBarList
            };
            return response;
            //}
            //catch (Exception ex)
            //{
            //    logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
            //    return new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
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

        [Route("InsertUpdateConsultantTimeSchedule")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantTimeScheduleMaster>> InsertUpdateConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            try
            {
                string message = string.Empty;
                message = consultantService.InsertUpdateConsultantTimeSchedule(timeScheduleMaster);
                var response = new ResponseDataModel<IEnumerable<ConsultantTimeScheduleMaster>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantTimeScheduleMaster>>()
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
        [Route("GetConsultantTimeSchedule")]
        [HttpPost]
        public ResponseDataModel<ConsultantTimeScheduleMaster> GetConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            List<ConsultantTimeScheduleMaster> timeSchedulers = new List<ConsultantTimeScheduleMaster>();
            try
            {

                ConsultantTimeScheduleMaster timeSchedule = new ConsultantTimeScheduleMaster();
                timeSchedule = consultantService.GetConsultantTimeSchedule(timeScheduleMaster);
                timeSchedulers.Add(timeSchedule);
                var response = new ResponseDataModel<ConsultantTimeScheduleMaster>()
                {
                    Status = HttpStatusCode.OK,
                    Response = timeSchedule
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ConsultantTimeScheduleMaster>()
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
        [Route("DeleteConsultant/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteConsultant(int id)
        {
            try
            {
                string msg = string.Empty;
                msg = consultantService.DeleteConsultant(id);
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



    }
}
