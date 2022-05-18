using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/TodaysPatient")]
    [ApiController]
    public class TodaysPatientController : ControllerBase
    {
        private readonly ILogger<TodaysPatientController> logger;
        private readonly IHospitalsService hospitalsService;
        private readonly ITodaysPatientService todaysPatientService;

        /// <summary>
        /// Initialisation of logger,hospital service,patient service objects
        /// </summary>
        public TodaysPatientController(ILogger<TodaysPatientController> _logger, IHospitalsService _hospitalsService, ITodaysPatientService _todaysPatientService)
        {
            logger = _logger;
            hospitalsService = _hospitalsService;
            todaysPatientService = _todaysPatientService;
        }
        /// <summary>
        /// To get list of Doctors belongs to specific department.Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns>
        /// Consultant list as JSON
        /// </returns>
        [Route("GetConsultant")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultant(ConsultantByDeptModel cd)
        {
            try
            {
                List<ConsultantModel> consultantList = new List<ConsultantModel>();
                consultantList = todaysPatientService.GetConsultant(cd);
                var response = new ResponseDataModel<IEnumerable<ConsultantModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantModel>>()
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
        /// API for checking appointment validity
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>

        [Route("AppoinmentValidCheck")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<String>> AppoinmentValidCheck(AppoinmentValidCheckModel ap)
        {
            try
            {
                string IsValid = string.Empty;
                IsValid = todaysPatientService.AppoinmentValidCheck(ap);
                var response = new ResponseDataModel<IEnumerable<String>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = null,
                    Message = IsValid
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
        /// <summary>
        /// API for getting consultation of a patient
        /// </summary>
        /// <param name="cd"></param>
        /// <returns>Consultation data</returns>
        [Route("GetConsultationByPatientId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationByPatientIdModel>> GetConsultationByPatientId(ConsultationModel cd)
        {
            try
            {
                List<ConsultationByPatientIdModel> consultantionList = new List<ConsultationByPatientIdModel>();
                consultantionList = todaysPatientService.GetConsultationByPatientId(cd);
                var response = new ResponseDataModel<IEnumerable<ConsultationByPatientIdModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultationByPatientIdModel>>()
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
        /// API for getting Consultation data of a Consultation by its Id Primary key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Consultation data</returns>

        [Route("GetConsultationDataById/{Id}")]
        [HttpPost]
        public ResponseDataModel<PatientConsultationModel> GetConsultationDataById(Int32 Id)
        {
            try
            {
                PatientConsultationModel consultantionList = new PatientConsultationModel();
                consultantionList = todaysPatientService.GetConsultationDataById(Id);
                var response = new ResponseDataModel<PatientConsultationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<PatientConsultationModel>()
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
        /// API For getting registration data of a patient
        /// </summary>
        /// <param name="cd">patient id</param>
        /// <returns>Patient registration details</returns>
        [Route("GetPatRegByPatientId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatRegByPatientIdModel>> GetPatRegByPatientId(ConsultationModel cd)
        {
            try
            {
                List<PatRegByPatientIdModel> patientRegistrationDataList = new List<PatRegByPatientIdModel>();
                patientRegistrationDataList = todaysPatientService.GetPatRegByPatientId(cd);
                var response = new ResponseDataModel<IEnumerable<PatRegByPatientIdModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientRegistrationDataList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatRegByPatientIdModel>>()
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
        /// API for getting schemerate of a consultant's scheme
        /// </summary>
        /// <param name="cisr"></param>
        /// <returns>scheme details</returns>
        [Route("GetConsultantItemSchemeRate")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GetConsultantItemSchemeRateModel>> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr)
        {
            try
            {
                List<GetConsultantItemSchemeRateModel> schemeRateList = new List<GetConsultantItemSchemeRateModel>();
                schemeRateList = todaysPatientService.GetConsultantItemSchemeRate(cisr);
                var response = new ResponseDataModel<IEnumerable<GetConsultantItemSchemeRateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = schemeRateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GetConsultantItemSchemeRateModel>>()
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
        /// Get consultanr details by department id
        /// </summary>
        /// <param name="deptId">Department Id</param>
        /// <returns>consultanr details list</returns>
        [Route("GetConsultantByArray")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultantByArray(DepartmentIdModel deptId)
        {
            try
            {
                List<ConsultantModel> consultantList = new List<ConsultantModel>();
                ConsultantByDeptModel cm = new ConsultantByDeptModel();
                List<ConsultantModel> templist = new List<ConsultantModel>();
                templist = todaysPatientService.GetConsultants(deptId);
                consultantList.AddRange(templist);
                var response = new ResponseDataModel<IEnumerable<ConsultantModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantModel>>()
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
        /// To get list of all Appoinments. Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>
        /// Appoinment list as json
        /// </returns>
        [Route("GetAppointments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> GetAppointments(AppointmentModel appointment)
        {
            try
            {
                List<Appointments> appointmentList = new List<Appointments>();
                appointmentList = todaysPatientService.GetAppointments(appointment);
                var response = new ResponseDataModel<IEnumerable<Appointments>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentList
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
        /// Get appointment details
        /// </summary>
        /// <param name="appointment">Appointment id</param>
        /// <returns>appointment details</returns>

        [Route("GetAllAppointments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> GetAllAppointments(AppointmentModel appointment)
        {
            try
            {
                List<SearchAppointmentModel> appointmentSearch = new List<SearchAppointmentModel>();
                appointmentSearch = todaysPatientService.GetAllAppointments(appointment);
                var response = new ResponseDataModel<IEnumerable<SearchAppointmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentSearch
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
        /// Get details of appointment by appointmentId from database,Step one in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns>Appointment details</returns>
        [Route("GetAppointmentById")]
        [HttpPost]
        public ResponseDataModel<SearchAppointmentModel> GetAppointmentById(AppointmentModel appointment)
        {
            try
            {
                SearchAppointmentModel appointmentSearch = new SearchAppointmentModel();
                appointmentSearch = todaysPatientService.GetAppointmentById(appointment);
                var response = new ResponseDataModel<SearchAppointmentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentSearch
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SearchAppointmentModel>()
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
        //Reg Scheme DDL
        //Registration Page Top Left
        /// <summary>
        /// API for canceling an appointment
        /// </summary>
        /// <param name="appointment">Appointment Id</param>
        /// <returns></returns>
        [Route("DeleteAppointment")]
        [HttpPost]
        public ResponseDataModel<AppointmentModel> DeleteAppointment(AppointmentModel appointment)
        {
            try
            {
                AppointmentModel responseData = new AppointmentModel();
                string appResponse = todaysPatientService.DeleteAppointment(appointment);
                var response = new ResponseDataModel<AppointmentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = null,
                    Message = appResponse
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<AppointmentModel>()
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
        /// API For Updating appointment status
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Success or reason for failure</returns>
        [Route("UpdateAppointmentStatus")]
        [HttpPost]
        public ResponseDataModel<AppointmentModel> UpdateAppointmentStatus(AppointmentModel appointment)
        {
            try
            {
                AppointmentModel responseData = new AppointmentModel();
                string appResponse = todaysPatientService.UpdateAppointmentStatus(appointment);
                var response = new ResponseDataModel<AppointmentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = null,
                    Message = appResponse
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<AppointmentModel>()
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
        /// To get list of all consultations. Controller class . Step One in code execution flow
        /// </summary>
        /// <returns>
        /// Consultation list as JSON
        /// </returns>
        [Route("GetConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> GetConsultation(ConsultantModel consultation)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                consultationList = hospitalsService.GetConsultation(consultation);
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
        /// API For searching patients with patient name, register number etc
        /// </summary>
        /// <param name="patientDetails">Patient details class</param>
        /// <returns>Patient details</returns>
        [Route("SearchPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientListModel>> SearchPatient(PatientSearchModel patientDetails)
        {
            try
            {
                List<PatientListModel> patientList = new List<PatientListModel>();
                patientList = todaysPatientService.SearchPatient(patientDetails);
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
        /// API for getting patient details with register number
        /// </summary>
        /// <param name="patientDetails">Register number</param>
        /// <returns>Patient details</returns>
        [Route("GetPatientByRegNo")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientListModel>> GetPatientByRegNo(PatientSearchModel patientDetails)
        {
            try
            {
                List<PatientListModel> patientList = new List<PatientListModel>();
                patientList = todaysPatientService.GetPatientByRegNo(patientDetails.RegNo);
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
        /// API for displaying appointment, consultation count in front office
        /// </summary>
        /// <param name="CM"></param>
        /// <returns></returns>
        [Route("GetFrontOfficeProgressBars")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FrontOfficePBarModel>> GetFrontOfficeProgressBars(ConsultationModel CM)
        {
            List<FrontOfficePBarModel> patientList = new List<FrontOfficePBarModel>();
            try
            {

                FrontOfficePBarModel asdf = new FrontOfficePBarModel();
                asdf = todaysPatientService.GetFrontOfficeProgressBars(CM);
                patientList.Add(asdf);
                var response = new ResponseDataModel<IEnumerable<FrontOfficePBarModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
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
        /// <summary>
        /// API for getting schemes available under a consultant
        /// </summary>
        /// <param name="consultant">Consultant ID</param>
        /// <returns>Scheme details</returns>
        [Route("GetSchemeByConsultant")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SchemeModel>> GetSchemeByConsultant(ConsultantModel consultant)
        {
            try
            {
                List<SchemeModel> schemeList = new List<SchemeModel>();
                schemeList = todaysPatientService.GetSchemeByConsultant(consultant);
                string msg = string.Empty;
                if (schemeList.Count > 0)
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Empty";
                }
                var response = new ResponseDataModel<IEnumerable<SchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = schemeList,
                    Message = msg
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SchemeModel>>()
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
        /// Save new Appointment,Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="appointments"></param>
        /// All details regarding new appoinments
        /// <returns>
        /// Success or failure status
        /// </returns>
        [Route("InsertAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> InsertAppointment(Appointments appointments)
        {
            try
            {
                string appointment = string.Empty;
                appointment = hospitalsService.InsertAppointment(appointments);
                var response = new ResponseDataModel<IEnumerable<Appointments>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = appointment
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
        /// API for updating appointment
        /// </summary>
        /// <param name="appointments">Appointment details</param>
        /// <returns>Success or reason for failure</returns>
        [Route("UpdateAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> UpdateAppointment(Appointments appointments)
        {
            try
            {
                string appointmentret = hospitalsService.UpdateAppointment(appointments);
                var response = new ResponseDataModel<IEnumerable<Appointments>>()
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
        /// Save new Consultation ,Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="consultations"></param>
        ///  All details regarding new consultation
        /// <returns>
        /// Success or failure status
        /// </returns>
        [Route("InsertUpdateConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> InsertUpdateConsultation(ConsultationModel consultations)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                string msg = string.Empty;
                consultationList = todaysPatientService.InsertUpdateConsultation(consultations);
                if (consultationList[0].RetVal > 0)
                {
                    msg = "Success";
                }
                else
                {
                    msg = consultationList[0].RetDesc;
                }
                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Message = msg,
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
        /// API for updating symptoms in a consultation
        /// </summary>
        /// <param name="consultations">Sympoms, consultation Id</param>
        /// <returns>Success or reason for failure</returns>
        [Route("UpdateConsultationSymptoms")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> UpdateConsultationSymptoms(ConsultationModel consultations)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                string msg = string.Empty;
                consultationList = todaysPatientService.UpdateConsultationSymptoms(consultations);
                if (consultationList[0].RetDesc == "Saved Successfully")
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Failure " + consultationList[0].RetDesc;
                }
                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Message = msg,
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
        /// API for cancelling a consiltation
        /// </summary>
        /// <param name="consultations">Consultation Id</param>
        /// <returns>Success or reason for failure</returns>
        [Route("CancelConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> CancelConsultation(ConsultationModel consultations)
        {
            try
            {
                string msg = string.Empty;
                msg = todaysPatientService.CancelConsultation(consultations);
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
        /// <summary>
        /// API For postponing an appointment
        /// </summary>
        /// <param name="app">APpointmentId</param>
        /// <returns>Success or reason for failure</returns>
        [Route("PostponeAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<String>> PostponeAppointment(Appointments app)
        {
            try
            {
                string msg = string.Empty;
                msg = todaysPatientService.PostponeAppointment(app);
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
        /// <summary>
        /// API for getting registered scheme's amount of a patient
        /// </summary>
        /// <param name="cm">patient id</param>
        /// <returns>Scheme data</returns>
        [HttpPost]
        [Route("GetRegSchmAmtOfPatient")]
        public ResponseDataModel<IEnumerable<ConsultRateModel>> GetRegSchmAmtOfPatient(ConsultationModel cm)
        {
            try
            {
                List<ConsultRateModel> schemeAmtList = new List<ConsultRateModel>();
                schemeAmtList = todaysPatientService.GetRegSchmAmtOfPatient(cm);
                var response = new ResponseDataModel<IEnumerable<ConsultRateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = schemeAmtList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultRateModel>>()
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
        /// API for getting sponsor's list of a patient
        /// </summary>
        /// <param name="patientId">Patient's Id</param>
        /// <returns>Sponsor details</returns>
        [HttpPost]
        [Route("GetSponsorListByPatientId/{patientId}")]
        public ResponseDataModel<IEnumerable<SponsorModel>> GetSponsorListByPatientId(Int32 patientId)
        {
            try
            {
                List<SponsorModel> sponsorList = new List<SponsorModel>();
                sponsorList = todaysPatientService.GetSponsorListByPatientId(patientId);
                var response = new ResponseDataModel<IEnumerable<SponsorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorModel>>()
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
        /// API for Search appointment details
        /// </summary>
        /// <param name="appointment">Appointment search filters</param>
        /// <returns>appointment details</returns>
        [HttpPost]
        [Route("SearchAppointment")]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> SearchAppointment(AppointmentModel appointment)
        {
            try
            {
                List<SearchAppointmentModel> appointmentList = new List<SearchAppointmentModel>();
                appointmentList = todaysPatientService.SearchAppointment(appointment);
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

        [HttpPost]
        [Route("GetAppNumber")]
        public ResponseDataModel<IEnumerable<GetAppNoModel>> GetAppNumber(GetAppNumberIPModel gan)
        {
            try
            {
                List<GetAppNoModel> appNumberList = new List<GetAppNoModel>();
                appNumberList = todaysPatientService.GetAppNumber(gan);
                var response = new ResponseDataModel<IEnumerable<GetAppNoModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appNumberList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GetAppNoModel>>()
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
        [Route("GetRecentConsultationData")]
        public ResponseDataModel<IEnumerable<RecentConsultationModel>> GetRecentConsultationData()
        {
            try
            {
                List<RecentConsultationModel> recentConsultationList = new List<RecentConsultationModel>();
                recentConsultationList = todaysPatientService.GetRecentConsultationData();
                var response = new ResponseDataModel<IEnumerable<RecentConsultationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recentConsultationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RecentConsultationModel>>()
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
        [Route("GetAppTime")]
        public ResponseDataModel<IEnumerable<GetAppTimeModel>> GetAppTime(GetAppNumberIPModel gan)
        {
            try
            {
                List<GetAppTimeModel> apptimeList = new List<GetAppTimeModel>();
                apptimeList = todaysPatientService.GetAppTime(gan);
                var response = new ResponseDataModel<IEnumerable<GetAppTimeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = apptimeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GetAppTimeModel>>()
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
        [Route("GetScheduleData")]
        public ResponseDataModel<IEnumerable<SheduleGetDataModel>> GetScheduleData(GetScheduleInputModel gan)
        {
            try
            {
                List<SheduleGetDataModel> appointmentList = new List<SheduleGetDataModel>();
                appointmentList = todaysPatientService.GetScheduleData(gan);
                var response = new ResponseDataModel<IEnumerable<SheduleGetDataModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appointmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SheduleGetDataModel>>()
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
        [Route("GetAllConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> GetAllConsultation()
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                consultationList = hospitalsService.GetAllConsultation();
                var response = new ResponseDataModel<IEnumerable<ConsultationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultationList
                };
                var asdf = response.Response;
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

        [Route("SearchConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> SearchConsultation(ConsultationModel consultation)
        {
            try
            {
                List<ConsultationModel> consultationList = new List<ConsultationModel>();
                consultationList = hospitalsService.SearchConsultation(consultation);
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
        [Route("GetNewTokenNumber")]
        public ResponseDataModel<IEnumerable<TokenModel>> GetNewTokenNumber(ConsultationModel cm)
        {
            try
            {
                List<TokenModel> tokenNumberList = new List<TokenModel>();
                tokenNumberList = todaysPatientService.GetNewTokenNumber(cm);
                var response = new ResponseDataModel<IEnumerable<TokenModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = tokenNumberList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TokenModel>>()
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
        [Route("GetConsultRate")]
        public ResponseDataModel<IEnumerable<ConsultRateModel>> GetConsultRate(ConsultationModel cm)
        {
            try
            {
                List<ConsultRateModel> consultRateList = new List<ConsultRateModel>();
                consultRateList = todaysPatientService.GetConsultRate(cm);
                var response = new ResponseDataModel<IEnumerable<ConsultRateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultRateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultRateModel>>()
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
        /// Get Details of patient
        /// </summary>
        /// <param name="patientId">Primary key of LH_Patient Table</param>
        /// <returns>patient details</returns>
        [HttpPost]
        [Route("GetPatient")]
        public ResponseDataModel<IEnumerable<PatientModel>> GetPatient(PatientModel cm)
        {
            try
            {
                List<PatientModel> patientList = new List<PatientModel>();
                patientList = todaysPatientService.GetPatient(cm.PatientId);
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
        /// For changing a consultation from normal to urgent
        /// </summary>
        /// <param name="consultations"></param>
        /// <returns></returns>
        [Route("SetUrgentConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<String>> SetUrgentConsultation(ConsultationModel consultations)
        {
            try
            {
                string Message = string.Empty;
                string queryresponse = todaysPatientService.SetUrgentConsultation(consultations);
                ErrorResponse er = new ErrorResponse();
                if (queryresponse != "success")
                {
                    Message = "error";
                    er.Message = queryresponse;
                }
                else
                {
                    Message = "success";
                }
                var response = new ResponseDataModel<IEnumerable<String>>()
                {
                    Message = Message,
                    Status = HttpStatusCode.OK,
                    ErrorMessage = er
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<String>>()
                {
                    Message = "error",
                    Status = HttpStatusCode.InternalServerError,
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
