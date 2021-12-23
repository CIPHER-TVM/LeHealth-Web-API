using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/MasterData")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly ILogger<MasterDataController> logger;
        private readonly IMasterDataService masterdataService;
        public MasterDataController(ILogger<MasterDataController> _logger, IMasterDataService _masterdataService)
        {
            logger = _logger;
            masterdataService = _masterdataService;
        }
        //Profession Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// profid=Primary key of LH_Profession Table, Returns all if profid=0
        /// </summary>
        /// <returns>
        /// returns List of Professions as JSON
        /// </returns>
        [Route("GetProfession/{profid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProfessionModel>> GetProfession(int profid)
        {
            List<ProfessionModel> professionList = new List<ProfessionModel>();
            try
            {
                professionList = masterdataService.GetProfession(profid);
                var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfessionModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProfessionModel>> InsertUpdateProfession(ProfessionModel Profession)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertUpdateProfession(Profession);
                var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfessionModel>>()
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
        /// Deleting Profession,ProfessionId Is Primary Key Of LH_Profession table
        /// Active Status To Zero soft delete
        /// </summary>
        /// <returns>
        /// returns Success or reason of failure
        /// </returns>
        [Route("DeleteProfession/{ProfessionId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProfessionModel>> DeleteProfession(int ProfessionId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteProfession(ProfessionId);
                var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfessionModel>>()
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

        //Profession management ends

        //Consent Management starts

        /// <summary>
        /// To get list of all consents and some patient details to display in consent print form
        /// PatientId=Primary key of LH_Patient Table
        /// </summary>
        /// <returns>
        /// returns List of Consent content,Patient detail as JSON
        /// </returns>
        [Route("GetConsentPreviewConsent")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentPreviewModel>> GetConsentPreviewConsent(ConsentPreviewModel consentDetails)
        {
            List<ConsentPreviewModel> patientList = new List<ConsentPreviewModel>();
            try
            {
                patientList = masterdataService.GetConsentPreviewConsent(consentDetails.PatientId);
                var response = new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = patientList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
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
        /// To get list of all Consent content Or Consent content Detail of Input parameter. 
        /// profid=Primary key of LH_PatConsent Table, Returns all if consentId=0
        /// </summary>
        /// <returns>
        /// returns List of ConsentContent as JSON
        /// </returns>
        [Route("GetConsent/{ConsentId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentContentModel>> GetConsent(int consentId)
        {
            List<ConsentContentModel> consentList = new List<ConsentContentModel>(); 
            try
            {
                consentList = masterdataService.GetConsent(consentId);
                var response = new ResponseDataModel<IEnumerable<ConsentContentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentContentModel>>()
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
        /// To Save or update Consent Content . if ContentId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateConsent")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentContentModel>> InsertUpdateConsent(ConsentContentModel Consent)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertUpdateConsent(Consent);
                var response = new ResponseDataModel<IEnumerable<ConsentContentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentContentModel>>()
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
        /// Deleting ConsentContent,ConsentId Is Primary Key Of LH_PatConsent table
        /// Active Status To Zero soft delete
        /// </summary>
        /// <returns>
        /// returns Success or reason of failure
        /// </returns>
        [Route("DeleteConsent/{ConsentId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentPreviewModel>> DeleteConsent(int ConsentId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteConsent(ConsentId);
                var response = new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
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


        //Consent Management ends
        //Country management starts
        /// <summary>
        /// To get list of all Country Or Country Detail of Input parameter. 
        /// id=Primary key of LH_Country Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of Country as JSON
        /// </returns>
        [HttpPost]
        [Route("GetCountry/{Id}")]
        public ResponseDataModel<IEnumerable<CountryModel>> GetCountry(int Id)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            try
            {
                countryList = masterdataService.GetCountry(Id);
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
            }
        }

        /// <summary>
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateCountry")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CountryModel>> InsertUpdateCountry(CountryModel Country)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertUpdateCountry(Country);
                var response = new ResponseDataModel<IEnumerable<CountryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
            }
        }

        /// <summary>
        /// Deleting Country,CountryId Is Primary Key Of LH_Country table
        /// Active Status To Zero soft delete
        /// </summary>
        /// <returns>
        /// returns Success or reason of failure
        /// </returns>
        [Route("DeleteCountry/{CountryId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CountryModel>> DeleteCountry(int CountryId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteCountry(CountryId);
                var response = new ResponseDataModel<IEnumerable<CountryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
            }
        }



        //Hospital Management Starts
        /// <summary>
        /// To get list of hospitals . A controller class. Step One in code execution flow
        /// branches=hospitals
        /// </summary>
        /// <returns>
        /// returns List of Hospitals as JSON
        /// </returns>

        [Route("GetUserHospitals/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserHospitals(int id)
        {
            try
            {
                var hospitals = masterdataService.GetUserHospitals(id);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserHospitals()");

                return new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
        }


        /// <summary>
        /// To Save or update Hospital . if HospitalId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateUserHospital")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> InsertUpdateHospital([FromForm] HospitalRequestModel obj)
        {
            string message = "";
            try
            {
                HospitalRegModel hospitalDetail = JsonConvert.DeserializeObject<HospitalRegModel>(obj.HospitalJson);
                hospitalDetail.LogoFile = obj.Logo;
                hospitalDetail.ReportLogoFile = obj.ReportLogo;
                message = masterdataService.InsertUpdateUserHospitals(hospitalDetail);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<HospitalModel>>()
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
        /// Deleting Hospital,HospitalId Is Primary Key Of LH_Hospital table
        /// Active Status To Zero soft delete
        /// </summary>
        /// <returns>
        /// returns Success or reason of failure
        /// </returns>

        [Route("DeleteHospital/{HospitalId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> DeleteHospital(int HospitalId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteUserHospital(HospitalId);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<HospitalModel>>()
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


        //Hospital Management Ends


        
        //Department Management starts
        [Route("GetDepartments/{DeptId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartments(int DeptId)
        {
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            try
            {
                departmentList = masterdataService.GetDepartments(DeptId);
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
            }
        }

        [Route("InsertUpdateDepartment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> InsertUpdateDepartment( DepartmentModel obj)
        {
            string message = "";
            try
            {
             
                message = masterdataService.InsertUpdateDepartment(obj);
                var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
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


            }
        }

        [Route("DeleteDepartment/{DeptId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> DeleteDepartment(int DeptId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteDepartment(DeptId);
                var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            }
        }

        [Route("GetReligion")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ReligionModel>> GetReligion()
        {
            List<ReligionModel> religionList = new List<ReligionModel>();
            try
            {
                religionList = masterdataService.GetReligion();
                var response = new ResponseDataModel<IEnumerable<ReligionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = religionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ReligionModel>>()
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
        //Zone Management Start

        [Route("GetAllZones")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetAllZones()
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();
            try
            {
                zoneList = masterdataService.GetAllZone();
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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

        [Route("GetZoneById/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetZoneById(int zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();
            try
            {
                zoneList = masterdataService.GetZoneById(zoneId);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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

        [Route("InsertZone")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> InsertZone(ZoneModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertZone(zone);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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


        [Route("DeleteZone/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> DeleteZone(int zoneId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteZone(zoneId);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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


        //RegSchemes CRUD STARTS
        [Route("GetAllRegSchemes")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> GetAllRegSchemes()
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();
            try
            {
                regSchemeList = masterdataService.GetAllRegScheme();
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = regSchemeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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

        [Route("GetRegSchemeById/{schemeId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> GetRegSchemeById(int schemeId)
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();
            try
            {
                regSchemeList = masterdataService.GetRegSchemeById(schemeId);
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = regSchemeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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

        [Route("InsertRegScheme")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> InsertRegScheme(RegSchemeModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertRegScheme(zone);
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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

        [Route("UpdateRegScheme")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> UpdateRegScheme(RegSchemeModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.UpdateRegScheme(zone);
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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

        [Route("DeleteRegScheme/{regSchemeId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> DeleteRegScheme(int regSchemeId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteRegScheme(regSchemeId);
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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


        //CRUD RateGroup
        [Route("GetAllRateGroups")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> GetAllRateGroups()
        {
            List<RateGroupModel> RateGroupList = new List<RateGroupModel>();
            try
            {
                RateGroupList = masterdataService.GetAllRateGroup();
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = RateGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            }
        }

        [Route("GetRateGroupById/{schemeId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> GetRateGroupById(int schemeId)
        {
            List<RateGroupModel> rateGroupList = new List<RateGroupModel>();
            try
            {
                rateGroupList = masterdataService.GetRateGroupById(schemeId);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = rateGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
            }
        }

        [Route("InsertRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> InsertRateGroup(RateGroupModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertRateGroup(zone);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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


            }
        }

        [Route("UpdateRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> UpdateRateGroup(RateGroupModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.UpdateRateGroup(zone);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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


            }
        }

        [Route("DeleteRateGroup/{RateGroupId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> DeleteRateGroup(int RateGroupId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteRateGroup(RateGroupId);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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


            }
        }

        //Operator CRUD
        [Route("GetAllOperators")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> GetAllOperators()
        {
            List<OperatorModel> OperatorList = new List<OperatorModel>();
            try
            {
                OperatorList = masterdataService.GetAllOperator();
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = OperatorList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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

        [Route("GetOperatorById/{operatorId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> GetOperatorById(int operatorId)
        {
            List<OperatorModel> zoneList = new List<OperatorModel>();
            try
            {
                zoneList = masterdataService.GetOperatorById(operatorId);
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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

        [Route("InsertOperator")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> InsertOperator(OperatorModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertOperator(zone);
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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

        [Route("UpdateOperator")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> UpdateOperator(OperatorModel zone)
        {
            string message = "";
            try
            {
                message = masterdataService.UpdateOperator(zone);
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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

        [Route("DeleteOperator/{OperatorId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> DeleteOperator(int OperatorId)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteOperator(OperatorId);
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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

        //Lead Agent Starts
        //Get Referenced by Doctor DDL Data
        [Route("GetLeadAgent/{la}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LeadAgentModel>> GetLeadAgent(int la)
        {
            List<LeadAgentModel> leadAgentList = new List<LeadAgentModel>();
            try
            {
                leadAgentList = masterdataService.GetLeadAgent(la);
                var response = new ResponseDataModel<IEnumerable<LeadAgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = leadAgentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LeadAgentModel>>()
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

        [Route("InsertUpdateLeadAgent")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LeadAgentModel>> InsertUpdateLeadAgent(LeadAgentModel la)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertUpdateLeadAgent(la);
                var response = new ResponseDataModel<IEnumerable<LeadAgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LeadAgentModel>>()
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

        [Route("DeleteLeadAgent/{la}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LeadAgentModel>> DeleteLeadAgent(int la)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteLeadAgent(la);
                var response = new ResponseDataModel<IEnumerable<LeadAgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LeadAgentModel>>()
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

        [Route("GetCompany/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CompanyModel>> GetCompany(int Id)
        {
            List<CompanyModel> companyList = new List<CompanyModel>();
            try
            {
                companyList = masterdataService.GetCompany(Id);
                var response = new ResponseDataModel<IEnumerable<CompanyModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = companyList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CompanyModel>>()
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

        [Route("InsertUpdateCompany")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CompanyModel>> InsertUpdateCompany(CompanyModel la)
        {
            string message = "";
            try
            {
                message = masterdataService.InsertUpdateCompany(la);
                var response = new ResponseDataModel<IEnumerable<CompanyModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CompanyModel>>()
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

        [Route("DeleteCompany/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CompanyModel>> DeleteCompany(int Id)
        {
            string message = "";
            try
            {
                message = masterdataService.DeleteCompany(Id);
                var response = new ResponseDataModel<IEnumerable<CompanyModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CompanyModel>>()
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


        [Route("GetAppType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AppTypeModel>> GetAppType()
        {
            List<AppTypeModel> appTypeList = new List<AppTypeModel>();
            try
            {
                appTypeList = masterdataService.GetAppType();
                var response = new ResponseDataModel<IEnumerable<AppTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AppTypeModel>>()
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
