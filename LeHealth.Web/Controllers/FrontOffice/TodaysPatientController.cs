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
        /// To get list of all Departments. A controller class. Step One in code execution flow
        /// </summary>
        /// <returns>
        /// Department list as JSON
        /// </returns>

        //ZONE MANAGEMENT END

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
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            try
            {
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

        [Route("AppoinmentValidCheck")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> AppoinmentValidCheck(AppoinmentValidCheckModel ap)
        {
            string IsValid = "";
            try
            {
                IsValid = todaysPatientService.AppoinmentValidCheck(ap); 
                var response = new ResponseDataModel<IEnumerable<string>>()
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

        [Route("GetConsultationByPatientId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationByPatientIdModel>> GetConsultationByPatientId(ConsultationModel cd)
        {
            List<ConsultationByPatientIdModel> consultantionList = new List<ConsultationByPatientIdModel>();
            try
            {
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

        [Route("GetPatRegByPatientId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatRegByPatientIdModel>> GetPatRegByPatientId(ConsultationModel cd)
        {
            List<PatRegByPatientIdModel> patientRegistrationDataList = new List<PatRegByPatientIdModel>();
            try
            {
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



        [Route("GetStateByCountryId/{countryId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<StateModel>> GetStateByCountryId(int countryId)
        {
            List<StateModel> stateList = new List<StateModel>();
            try
            {
                stateList = todaysPatientService.GetStateByCountryId(countryId);
                var response = new ResponseDataModel<IEnumerable<StateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = stateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<StateModel>>()
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
        [Route("GetNumber/{numid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GetNumberModel>> GetNumber(String numid)
        {
            List<GetNumberModel> numberList = new List<GetNumberModel>();
            try
            {
                numberList = todaysPatientService.GetNumber(numid);
                var response = new ResponseDataModel<IEnumerable<GetNumberModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = numberList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GetNumberModel>>()
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


        [Route("GetConsultantItemSchemeRate")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GetConsultantItemSchemeRateModel>> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr)
        {
            List<GetConsultantItemSchemeRateModel> schemeRateList = new List<GetConsultantItemSchemeRateModel>();
            try
            {
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

        [Route("GetConsultantByArray")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultantByArray(DepartmentIdModel deptId)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            try
            {
                for (int i = 0; i < deptId.Departments.Length; i++)
                {
                    ConsultantByDeptModel cm = new ConsultantByDeptModel();
                    cm.DeptId = Convert.ToInt32(deptId.Departments[i]);
                    cm.ShowExternal = false;
                    List<ConsultantModel> templist = new List<ConsultantModel>();
                    templist = todaysPatientService.GetConsultant(cm);
                    consultantList.AddRange(templist);
                }

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

            }
        }



        [Route("GetAllAppointments")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> GetAllAppointments(AppointmentModel appointment)
        {
            List<SearchAppointmentModel> appointmentSearch = new List<SearchAppointmentModel>();
            try
            {
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




        [Route("GetAppointmentById")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> GetAppointmentById(AppointmentModel appointment) 
        {
            List<SearchAppointmentModel> appointmentSearch = new List<SearchAppointmentModel>();
            try
            {
                appointmentSearch = todaysPatientService.GetAppointmentById(appointment);
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
        //Reg Scheme DDL
        //Registration Page Top Left
        [Route("GetItemsByType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetItemsByType(ItemsByTypeModel ibtm)
        {
            List<ItemsByTypeModel> itemsList = new List<ItemsByTypeModel>();
            try
            {
                itemsList = todaysPatientService.GetItemsByType(ibtm);
                var response = new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
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

        
        
      


        [Route("DeleteAppointment")]
        [HttpPost]
        public ResponseDataModel<AppointmentModel> DeleteAppointment(AppointmentModel appointment)
        {

            AppointmentModel responseData = new AppointmentModel();
            try
            {
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
                //  consultationList.Clear();

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

            }
        }


        [Route("SearchPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientListModel>> SearchPatient(PatientSearchModel patientDetails)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();
            try
            {
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
                //  consultationList.Clear();

            }
        }


        [Route("GetPatientByRegNo")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientListModel>> GetPatientByRegNo(PatientSearchModel patientDetails)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();
            try
            {
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
                //  consultationList.Clear();

            }
        }

        [Route("GetFrontOfficeProgressBars")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FrontOfficePBarModel>> GetFrontOfficeProgressBars(ConsultationModel CM)
        {
            List<FrontOfficePBarModel> patientList = new List<FrontOfficePBarModel>();
            try
            {

                FrontOfficePBarModel asdf = new FrontOfficePBarModel();
                asdf = todaysPatientService.GetFrontOfficeProgressBars(CM.ConsultDate);
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
                //  consultationList.Clear();

            }
        }

        [Route("GetSavingSchemaMandatory")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MandatoryFieldsModel>> GetSavingSchemaMandatory(FormNameModel formname)
        {
            List<MandatoryFieldsModel> mandatoryList = new List<MandatoryFieldsModel>();
            try
            {
                mandatoryList = todaysPatientService.GetSavingSchemaMandatory(formname.Formname);
                var response = new ResponseDataModel<IEnumerable<MandatoryFieldsModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = mandatoryList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MandatoryFieldsModel>>()
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

            }
        }

        [Route("GetSchemeByConsultant")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SchemeModel>> GetSchemeByConsultant(ConsultantModel consultant)
        {
            List<SchemeModel> schemeList = new List<SchemeModel>();
            try
            {
                schemeList = todaysPatientService.GetSchemeByConsultant(consultant.ConsultantId);
                string msg = "";
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
                //  consultationList.Clear();

            }
        }

        [Route("GetVisaType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VisaTypeModel>> GetVisaType()
        {
            List<VisaTypeModel> visaTypeList = new List<VisaTypeModel>();
            try
            {
                visaTypeList = todaysPatientService.GetVisaType();
                var response = new ResponseDataModel<IEnumerable<VisaTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = visaTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VisaTypeModel>>()
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
        [Route("InsertUpdateAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<Appointments>> InsertUpdateAppointment(Appointments appointments)
        {
            List<Appointments> appointmentList = new List<Appointments>();
            try
            {
                appointmentList = hospitalsService.InsertUpdateAppointment(appointments);
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
                    Message=appointmentret,
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
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
                string msg = "";
                consultationList = todaysPatientService.InsertUpdateConsultation(consultations);
                if (consultationList[0].RetVal > 0)
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

        [Route("CancelConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> CancelConsultation(ConsultationModel consultations)
        {
            try
            {
                string msg = "";
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

        [Route("PostponeAppointment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> PostponeAppointment(Appointments app)
        {
            try
            {
                string msg = "";
                msg = todaysPatientService.PostponeAppointment(app);

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

            }
        }

        [HttpPost]
        [Route("GetRegSchmAmtOfPatient")]
        public ResponseDataModel<IEnumerable<ConsultRateModel>> GetRegSchmAmtOfPatient(ConsultationModel cm)
        {
            List<ConsultRateModel> schemeAmtList = new List<ConsultRateModel>();
            try
            {
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
                // countryList.Clear();

            }
        }



        [HttpPost]
        [Route("GetSponsorListByPatientId/{patientId}")]
        public ResponseDataModel<IEnumerable<SponsorModel>> GetSponsorListByPatientId(int patientId)
        {
            List<SponsorModel> sponsorList = new List<SponsorModel>();
            try
            {
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
                // countryList.Clear();

            }
        }



        [HttpPost]
        [Route("SearchAppointment")]
        public ResponseDataModel<IEnumerable<SearchAppointmentModel>> SearchAppointment(AppointmentModel appointment)
        {
            List<SearchAppointmentModel> appointmentList = new List<SearchAppointmentModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }

        [HttpPost]
        [Route("GetAppNumber")]
        public ResponseDataModel<IEnumerable<GetAppNoModel>> GetAppNumber(GetAppNumberIPModel gan)
        {
            List<GetAppNoModel> appNumberList = new List<GetAppNoModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }

        [HttpPost]
        [Route("GetRecentConsultationData")]
        public ResponseDataModel<IEnumerable<RecentConsultationModel>> GetRecentConsultationData()
        {
            List<RecentConsultationModel> recentConsultationList = new List<RecentConsultationModel>();
            try
            {
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
            List<GetAppTimeModel> apptimeList = new List<GetAppTimeModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }


        [HttpPost]
        [Route("GetScheduleData")]
        public ResponseDataModel<IEnumerable<SheduleGetDataModel>> GetScheduleData(GetScheduleInputModel gan)
        {
            List<SheduleGetDataModel> appointmentList = new List<SheduleGetDataModel>();
            try
            {
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
                //  consultationList.Clear();

            }
        }






        [Route("GetAllConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> GetAllConsultation()
        {
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
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
                //  consultationList.Clear();

            }
        }

        [Route("SearchConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationModel>> SearchConsultation(ConsultationModel consultation)
        {
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
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
                //  consultationList.Clear();

            }
        }

        [HttpPost]
        [Route("GetNewTokenNumber")]
        public ResponseDataModel<IEnumerable<TokenModel>> GetNewTokenNumber(ConsultationModel cm)
        {
            List<TokenModel> tokenNumberList = new List<TokenModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }

        [HttpPost]
        [Route("GetActiveSymptoms")]
        public ResponseDataModel<IEnumerable<SymptomModel>> GetActiveSymptoms()
        {
            List<SymptomModel> activeSymptomsList = new List<SymptomModel>();
            try
            {
                activeSymptomsList = todaysPatientService.GetActiveSymptoms();
                var response = new ResponseDataModel<IEnumerable<SymptomModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = activeSymptomsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SymptomModel>>()
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

            }

        }

        [HttpPost]
        [Route("GetConsultRate")]
        public ResponseDataModel<IEnumerable<ConsultRateModel>> GetConsultRate(ConsultationModel cm)
        {
            List<ConsultRateModel> consultRateList = new List<ConsultRateModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }

        [HttpPost]
        [Route("GetPatient")]
        public ResponseDataModel<IEnumerable<PatientModel>> GetPatient(PatientModel cm)
        {
            List<PatientModel> patientList = new List<PatientModel>();
            try
            {
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
                //  consultationList.Clear();

            }

        }


        [Route("SetUrgentConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> SetUrgentConsultation(ConsultationModel consultations)
        {
            string Message = "";
            try
            {
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
                var response = new ResponseDataModel<IEnumerable<string>>()
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
                return new ResponseDataModel<IEnumerable<string>>()
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

//[HttpPost]
//[Route("SendAddPatientInformation")]
//public string SendAddPatientInformation()
//{
//    //List<AllPatientModel> patientList = new List<AllPatientModel>();
//    try
//    {
//        string patientList = todaysPatientService.SendAddPatientInformation(5);
//        return "";
//    }
//    catch (Exception ex)
//    {
//        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
//        return "";
//    }
//    finally
//    {
//        //  consultationList.Clear();
//        
//    }
//}

