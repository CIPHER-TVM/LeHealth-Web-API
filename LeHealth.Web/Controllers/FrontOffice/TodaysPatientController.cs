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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        /// To get list of all Departments. A controller class. Step One in code execution flow
        /// </summary>
        /// <returns>
        /// Department list as JSON
        /// </returns>
        [Route("GetDepartments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartments()
        {
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            try
            {
                departmentList = hospitalsService.GetDepartments();
                var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = departmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DepartmentModel>>()
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
               // departmentList.Clear();
                // dispose can be managed here
            }
        }
        /// <summary>
        /// To get list of Doctors belongs to specific department.Controller class . Step One in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns>
        /// Consultant list as JSON
        /// </returns>
        [Route("GetConsultant/{deptId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultant(int deptId)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            try
            {
                consultantList = hospitalsService.GetConsultant(deptId);
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
               // consultantList.Clear();
                // dispose can be managed here
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
            List<Appointments> appointmentList = new List<Appointments>();
            try
            {
                appointmentList = hospitalsService.GetAppointments(appointment);
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
               // appointmentList.Clear();
                // dispose can be managed here
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
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
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
              //  consultationList.Clear();
                // dispose can be managed here
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
        [Route("InsertUpdateAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> InsertUpdateAppointment(Appointments appointments)
        {
            List<Appointments> consultationList = new List<Appointments>();
            try
            {
                consultationList = hospitalsService.InsertUpdateAppointment(appointments);
                var response = new ResponseDataModel<IEnumerable<Appointments>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultationList
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
               // consultationList.Clear();
                // dispose can be managed here
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
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
                consultationList = hospitalsService.InsertUpdateConsultation(consultations);
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
               // consultationList.Clear();
                // dispose can be managed here
            }
        }
        [HttpPost]
        [Route("GetCountry")]
        public ResponseDataModel<IEnumerable<CountryModel>> GetCountry(CountryModel countryDetails)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            try
            {
                countryList = todaysPatientService.GetCountry(countryDetails);
                var response = new ResponseDataModel<IEnumerable<CountryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = countryList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CountryModel>>()
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
               // countryList.Clear();
                // dispose can be managed here
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
        [Route("InsertPatientRegistration")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientModel>> InsertPatientRegistration(PatientModel patientDetail)
        {
            List<PatientModel> registrationDetail = new List<PatientModel>();
            try
            {
                registrationDetail = todaysPatientService.InsertPatient(patientDetail);
                var response = new ResponseDataModel<IEnumerable<PatientModel>>()
                {
                    Status = HttpStatusCode.OK,
                    //  Response = consultationList
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
                registrationDetail.Clear();
                // dispose can be managed here
            }
        }
    }
}
