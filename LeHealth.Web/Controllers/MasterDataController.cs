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
        [Route("GetGender")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GenderModel>> GetGender()
        {
            List<GenderModel> genderList = new List<GenderModel>();
            try
            {
                genderList = masterdataService.GetGender();
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
            }
        }

        [Route("GetKinRelation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<KinRelationModel>> GetKinRelation()
        {
            List<KinRelationModel> kinRelationList = new List<KinRelationModel>();
            try
            {
                kinRelationList = masterdataService.GetKinRelation();
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
            }
        }

        [HttpPost]
        [Route("GetMaritalStatus")]
        public ResponseDataModel<IEnumerable<MaritalStatusModel>> GetMaritalStatus()
        {
            List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();
            try
            {
                maritalStatusList = masterdataService.GetMaritalStatus();
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
            }
        }

        [HttpPost]
        [Route("GetCommunicationType")]
        public ResponseDataModel<IEnumerable<CommunicationTypeModel>> GetCommunicationType()
        {
            List<CommunicationTypeModel> communicationTypeList = new List<CommunicationTypeModel>();
            try
            {
                communicationTypeList = masterdataService.GetCommunicationType();
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
        public ResponseDataModel<IEnumerable<ProfessionModel>> GetProfession(Int32 profid)
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
            string message = string.Empty;
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


        //Profession management ends
        [Route("InsertUpdateMenuGroupMap")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MenuGroupModel>> InsertUpdateMenuGroupMap(MenuGroupModel mgm)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateMenuGroupMap(mgm);
                var response = new ResponseDataModel<IEnumerable<MenuGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MenuGroupModel>>()
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


        //Sponsor Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsor/{sponsorid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorMasterModel>> GetSponsor(Int32 sponsorid)
        {
            List<SponsorMasterModel> professionList = new List<SponsorMasterModel>();
            try
            {
                professionList = masterdataService.GetSponsor(sponsorid);
                var response = new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
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
        [Route("InsertUpdateSponsor")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorMasterModel>> InsertUpdateSponsor(SponsorMasterModel Sponsor)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateSponsor(Sponsor);
                var response = new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
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


        //Sponsor management ends


        //Sponsor Type Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsorType/{sponsortypeid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorTypeModel>> GetSponsorType(Int32 sponsortypeid)
        {
            List<SponsorTypeModel> professionList = new List<SponsorTypeModel>();
            try
            {
                professionList = masterdataService.GetSponsorType(sponsortypeid);
                var response = new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
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
        [Route("InsertUpdateSponsorType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorTypeModel>> InsertUpdateSponsorType(SponsorTypeModel Sponsor)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateSponsorType(Sponsor);
                var response = new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
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

        //Sponsor Type management ends

        //Sponsor Form Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsorForm/{sponsorformid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorFormModel>> GetSponsorForm(Int32 sponsorformid)
        {
            List<SponsorFormModel> sponsorFormList = new List<SponsorFormModel>();
            try
            {
                sponsorFormList = masterdataService.GetSponsorForm(sponsorformid);
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorFormList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorFormModel>>()
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
        [Route("InsertUpdateSponsorForm")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorFormModel>> InsertUpdateSponsorForm(SponsorFormModel Sponsor)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateSponsorForm(Sponsor);
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorFormModel>>()
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


        //Sponsor Form management ends

        //City Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetCity/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CityModel>> GetCity(Int32 id)
        {
            List<CityModel> cityList = new List<CityModel>();
            try
            {
                cityList = masterdataService.GetCity(id);
                var response = new ResponseDataModel<IEnumerable<CityModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cityList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CityModel>>()
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
        [Route("InsertUpdateCity")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CityModel>> InsertUpdateCity(CityModel City)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateCity(City);
                var response = new ResponseDataModel<IEnumerable<CityModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CityModel>>()
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
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetVitalSign/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignModel>> GetVitalSign(Int32 id)
        {
            List<VitalSignModel> vitalSignList = new List<VitalSignModel>();
            try
            {
                vitalSignList = masterdataService.GetVitalSign(id);
                var response = new ResponseDataModel<IEnumerable<VitalSignModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = vitalSignList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignModel>>()
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
        [Route("InsertUpdateVitalSign")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignModel>> InsertUpdateVitalSign(VitalSignModel vitalSign)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateVitalSign(vitalSign);
                var response = new ResponseDataModel<IEnumerable<VitalSignModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignModel>>()
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
        //City management ends

        [Route("InsertUpdateSymptom")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SymptomModel>> InsertUpdateSymptom(SymptomModel Symptom)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateSymptom(Symptom);
                var response = new ResponseDataModel<IEnumerable<SymptomModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
            }
        }


        //Consent Management starts

        /// <summary>
        /// To get list of all consents and some patient details to display in consent print form
        /// PatientId=Primary key of LH_Patient Table
        /// </summary>
        /// <returns>
        /// returns List of Consent content,Patient detail as JSON
        /// </returns>
        [Route("GetConsentPreviewContent")]
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
        public ResponseDataModel<IEnumerable<ConsentContentModel>> GetConsent(Int32 consentId)
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
            string message = string.Empty;
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
        public ResponseDataModel<IEnumerable<CountryModel>> GetCountry(Int32 Id)
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
            string message = string.Empty;
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

        //State Management Starts
        /// <summary>
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetState/{Id}")]
        public ResponseDataModel<IEnumerable<StateModel>> GetState(Int32 Id)
        {
            List<StateModel> stateList = new List<StateModel>();
            try
            {
                stateList = masterdataService.GetState(Id);
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

        /// <summary>
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateState")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<StateModel>> InsertUpdateState(StateModel State)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateState(State);
                var response = new ResponseDataModel<IEnumerable<StateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
        //State Management Ends

        //Salutation Management Starts
        /// <summary>
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetSalutation/{Id}")]
        public ResponseDataModel<IEnumerable<SalutationModel>> GetSalutation(Int32 Id)
        {
            List<SalutationModel> stateList = new List<SalutationModel>();
            try
            {
                stateList = masterdataService.GetSalutation(Id);
                var response = new ResponseDataModel<IEnumerable<SalutationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = stateList
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
            }
        }

        /// <summary>
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateSalutation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SalutationModel>> InsertUpdateSalutation(SalutationModel State)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateSalutation(State);
                var response = new ResponseDataModel<IEnumerable<SalutationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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
            }
        }


        //Salutation Management Ends

        /// <summary>
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetBodyPart/{Id}")]
        public ResponseDataModel<IEnumerable<BodyPartModel>> GetBodyPart(Int32 Id)
        {
            List<BodyPartModel> stateList = new List<BodyPartModel>();
            try
            {
                stateList = masterdataService.GetBodyPart(Id);
                var response = new ResponseDataModel<IEnumerable<BodyPartModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = stateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BodyPartModel>>()
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

        [Route("InsertUpdateBodyPart")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<BodyPartModel>> InsertUpdateBodyPart(BodyPartModel State)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateBodyPart(State);
                var response = new ResponseDataModel<IEnumerable<BodyPartModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BodyPartModel>>()
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
        //BodyPart Management Ends


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
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserHospitals(Int32 id)
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
        [Route("GetUserSpecificHospitals/{UserId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserSpecificHospitals(Int32 UserId)
        {
            try
            {
                List<HospitalModel> hospitals = masterdataService.GetUserSpecificHospitals(UserId);
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
        [Route("GetUserSpecificHospitalLocations/{UserId}/{Branch}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LocationModel>> GetUserSpecificHospitalLocations(Int32 UserId, Int32 Branch)
        {
            try
            {
                List<LocationModel> hospitals = masterdataService.GetUserSpecificHospitalLocations(UserId, Branch);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserSpecificHospitalLocations()");

                return new ResponseDataModel<IEnumerable<LocationModel>>()
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
            string message = string.Empty;
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



        //Hospital Management Ends
        [Route("ConsentFormDataSave")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentFormDataSaveModel>> ConsentFormDataSave([FromForm] ConsentFormSaveRequestModel obj)
        {
            string message = string.Empty;
            try
            {
                ConsentFormRegModel hospitalDetail = JsonConvert.DeserializeObject<ConsentFormRegModel>(obj.ConsentJson);
                hospitalDetail.SignFile = obj.Sign;
                message = masterdataService.ConsentFormDataSave(hospitalDetail);
                var response = new ResponseDataModel<IEnumerable<ConsentFormDataSaveModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentFormDataSaveModel>>()
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



        //Department Management starts
        /// <summary>
        /// To get list of all Departments Or Departments Detail of Input parameter. 
        /// DeptId=Primary key of LH_Department Table, Returns all if DeptId=0
        /// </summary>
        /// <returns>
        /// returns List of Departments as JSON
        /// </returns>

        [Route("GetDepartment/{DeptId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartments(Int32 DeptId)
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

        /// <summary>
        /// To Save or update department . if DeptId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateDepartment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> InsertUpdateDepartment(DepartmentModel obj)
        {
            string message = string.Empty;
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
        //Department Management completed
        /// <summary>
        /// To get list of all Departments Or Departments Detail of Input parameter. 
        /// DeptId=Primary key of LH_Department Table, Returns all if DeptId=0
        /// </summary>
        /// <returns>
        /// returns List of Departments as JSON
        /// </returns>

        [Route("GetDepartmentByHospital/{HospId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartmentByHospital(Int32 HospId)
        {
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            try
            {
                departmentList = masterdataService.GetDepartmentByHospital(HospId);
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

        [Route("GetConsultantByHospital")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultantByHospital(ConsultantModel cmodel)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            try
            {
                consultantList = masterdataService.GetConsultantByHospital(cmodel);
                var response = new ResponseDataModel<IEnumerable<ConsultantModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
        /// To get list of Zone Detail of Input parameter. 
        /// profid=Primary key of LH_Zone Table, Returns all if zoneId=0
        /// </summary>
        /// <returns>
        /// returns List of Zone as JSON
        /// </returns>
        [Route("GetDrugs")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> GetDrugs(ConsultantDrugModel cm)
        {
            List<ConsultantDrugModel> drugList = new List<ConsultantDrugModel>();
            try
            {
                drugList = masterdataService.GetDrugs(cm);
                var response = new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drugList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
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
        //Zone Management Start
        /// <summary>
        /// To get list of Zone Detail of Input parameter. 
        /// profid=Primary key of LH_Zone Table, Returns all if zoneId=0
        /// </summary>
        /// <returns>
        /// returns List of Zone as JSON
        /// </returns>
        [Route("GetZone/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetZone(Int32 zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();
            try
            {
                zoneList = masterdataService.GetZone(zoneId);
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

        /// <summary>
        /// To Save zone 
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateZone")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> InsertUpdateZone(ZoneModel zone)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateZone(zone);
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

        [Route("GetRegScheme/{schemeId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> GetRegScheme(Int32 schemeId)
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();
            try
            {
                regSchemeList = masterdataService.GetRegScheme(schemeId);
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

        [Route("InsertUpdateRegScheme")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> InsertUpdateRegScheme(RegSchemeModel zone)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateRegScheme(zone);
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
        [Route("GetRateGroup/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> GetRateGroup(Int32 Id)
        {
            List<RateGroupModel> RateGroupList = new List<RateGroupModel>();
            try
            {
                RateGroupList = masterdataService.GetRateGroup(Id);
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


        [Route("InsertUpdateRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> InsertUpdateRateGroup(RateGroupModel zone)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateRateGroup(zone);
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

        [Route("GetOperator/{operatorId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> GetOperator(Int32 operatorId)
        {
            List<OperatorModel> zoneList = new List<OperatorModel>();
            try
            {
                zoneList = masterdataService.GetOperator(operatorId);
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



        [Route("InsertUpdateOperator")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> InsertUpdateOperator(OperatorModel zone)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateOperator(zone);
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
        public ResponseDataModel<IEnumerable<LeadAgentModel>> GetLeadAgent(Int32 la)
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
            string message = string.Empty;
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


        [Route("GetCompany/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CompanyModel>> GetCompany(Int32 Id)
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
            string message = string.Empty;
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

        [Route("GetMovement/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MovementModel>> GetMovement(Int32 Id)
        {
            List<MovementModel> companyList = new List<MovementModel>();
            try
            {
                companyList = masterdataService.GetMovement(Id);
                var response = new ResponseDataModel<IEnumerable<MovementModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = companyList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MovementModel>>()
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

        [Route("InsertUpdateMovement")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MovementModel>> InsertUpdateMovement(MovementModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateMovement(la);
                var response = new ResponseDataModel<IEnumerable<MovementModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MovementModel>>()
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

        [Route("GetPackage")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PackageModel>> GetPackage(PackageModel pm)
        {
            List<PackageModel> companyList = new List<PackageModel>();
            try
            {
                companyList = masterdataService.GetPackage(pm);
                var response = new ResponseDataModel<IEnumerable<PackageModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = companyList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageModel>>()
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

        [Route("InsertUpdatePackage")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PackageModel>> InsertUpdatePackage(PackageModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdatePackage(la);
                var response = new ResponseDataModel<IEnumerable<PackageModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageModel>>()
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


        [Route("GetLocation/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LocationModel>> GetLocation(Int32 Id)
        {
            List<LocationModel> companyList = new List<LocationModel>();
            try
            {
                companyList = masterdataService.GetLocation(Id);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = companyList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LocationModel>>()
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

        [Route("InsertUpdateLocation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LocationModel>> InsertUpdateLocation(LocationModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateLocation(la);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LocationModel>>()
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


        [Route("GetScientificName/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ScientificNameModel>> GetScientificName(Int32 Id)
        {
            List<ScientificNameModel> companyList = new List<ScientificNameModel>();
            try
            {
                companyList = masterdataService.GetScientificName(Id);
                var response = new ResponseDataModel<IEnumerable<ScientificNameModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = companyList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ScientificNameModel>>()
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

        [Route("InsertUpdateScientificName")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ScientificNameModel>> InsertUpdateScientificName(ScientificNameModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateScientificName(la);
                var response = new ResponseDataModel<IEnumerable<ScientificNameModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ScientificNameModel>>()
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

        [Route("GetTendern/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TendernModel>> GetTendern(Int32 Id)
        {
            List<TendernModel> tendernessList = new List<TendernModel>();
            try
            {
                tendernessList = masterdataService.GetTendern(Id);
                var response = new ResponseDataModel<IEnumerable<TendernModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = tendernessList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TendernModel>>()
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

        [Route("InsertUpdateTendern")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TendernModel>> InsertUpdateTendern(TendernModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.InsertUpdateTendern(la);
                var response = new ResponseDataModel<IEnumerable<TendernModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TendernModel>>()
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

        [Route("GetFormMaster")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> GetFormMaster()
        {
            List<FormValidationModel> cityList = new List<FormValidationModel>();
            try
            {
                cityList = masterdataService.GetFormMaster();
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cityList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<FormValidationModel>>()
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
        [Route("GetFormFields/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> GetFormFields(Int32 id)
        {
            List<FormValidationModel> cityList = new List<FormValidationModel>();
            try
            {
                cityList = masterdataService.GetFormFields(id);
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cityList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<FormValidationModel>>()
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
        /// To get list of all Appointment type 
        /// </summary>
        /// <returns>
        /// returns List of Appointment type as JSON
        /// </returns>
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

        [Route("GetVisaType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VisaTypeModel>> GetVisaType()
        {
            List<VisaTypeModel> visaTypeList = new List<VisaTypeModel>();
            try
            {
                visaTypeList = masterdataService.GetVisaType();
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

        [Route("GetStateByCountryId/{countryId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<StateModel>> GetStateByCountryId(Int32 countryId)
        {
            List<StateModel> stateList = new List<StateModel>();
            try
            {
                stateList = masterdataService.GetStateByCountryId(countryId);
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

        [HttpPost]
        [Route("GetActiveSymptoms")]
        public ResponseDataModel<IEnumerable<SymptomModel>> GetActiveSymptoms()
        {
            List<SymptomModel> activeSymptomsList = new List<SymptomModel>();
            try
            {
                activeSymptomsList = masterdataService.GetActiveSymptoms();
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
            }

        }

        [Route("GetItemsByType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetItemsByType(ItemsByTypeModel ibtm)
        {
            List<ItemsByTypeModel> itemsList = new List<ItemsByTypeModel>();
            try
            {
                itemsList = masterdataService.GetItemsByType(ibtm);
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

        [Route("GetConsentType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentTypeModel>> GetConsentType()
        {
            List<ConsentTypeModel> itemsList = new List<ConsentTypeModel>();
            try
            {
                itemsList = masterdataService.GetConsentType();
                var response = new ResponseDataModel<IEnumerable<ConsentTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentTypeModel>>()
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
        public ResponseDataModel<IEnumerable<GetNumberModel>> GetNumber(string numid)
        {
            List<GetNumberModel> numberList = new List<GetNumberModel>();
            try
            {
                numberList = masterdataService.GetNumber(numid);
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

        [Route("UpdateNumberTable")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GetNumberModel>> UpdateNumberTable(GetNumberModel la)
        {
            string message = string.Empty;
            try
            {
                message = masterdataService.UpdateNumberTable(la);
                var response = new ResponseDataModel<IEnumerable<GetNumberModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
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

        [Route("ConsultantSearchWithDept")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> ConsultantSearchWithDept(GetScheduleInputModel drsearch)
        {
            List<ConsultantModel> departmentList = new List<ConsultantModel>();
            try
            {
                departmentList = masterdataService.ConsultantSearchWithDept(drsearch);
                var response = new ResponseDataModel<IEnumerable<ConsultantModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = departmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
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

    }
}
