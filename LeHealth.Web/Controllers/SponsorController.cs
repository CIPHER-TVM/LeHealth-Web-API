using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers
{
    [Route("api/Sponsor")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ILogger<SponsorController> logger;
        private readonly ISponsorService sponserService;
        public SponsorController(ILogger<SponsorController> _logger, ISponsorService _sponserservice)
        {
            logger = _logger;
            sponserService = _sponserservice;
        }
        /// <summary>
        /// API For getting Sponsor Consent by  Id
        /// </summary>
        /// <param name="ContentId">Primary key of SponsorConsent table</param>
        /// <returns>Sponsor Consent data</returns>

        [HttpPost]
        [Route("GetSponserConsentById")]
         public ResponseDataModel<SponserConsentModelAll> GetSponserConsentById(SponserConsentModelAll obj)
        {
            try
            {
                SponserConsentModelAll Sponsorconsent = new SponserConsentModelAll();
                Sponsorconsent = sponserService.GetSponserConsentById(obj.ContentId);
                var response = new ResponseDataModel<SponserConsentModelAll>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Sponsorconsent
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SponserConsentModelAll>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Sponser types
        /// </summary>
        /// <returns>Sponser type list</returns>
        [HttpPost]
        [Route("GetSponsorTypes")]
        public ResponseDataModel<IEnumerable<SponsorTypeModel>> GetSponsorTypes()
        {
            try
            {
                List<SponsorTypeModel> sponser = new List<SponsorTypeModel>();
                sponser = sponserService.GetSponsorTypes();
                var response = new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponser
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
        /// API For getting Sponser Frorms
        /// </summary>
        /// <returns>Sponser Form list</returns>
        [HttpPost]
        [Route("GetSponsorForms")]
        public ResponseDataModel<IEnumerable<SponsorFormModel>> GetSponserForms()
        {
            try
            {
                List<SponsorFormModel> sponser = new List<SponsorFormModel>();
                sponser = sponserService.GetSponsorForms();
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponser
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
        /// API For saving Sponsor data
        /// </summary>
        /// <param name="obj">Sponsor details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateSponsor")]
        public ResponseDataModel<string> InsertUpdateSponsor(SponsorMasterModelAll obj)
        {
            try
            {
                var agent = sponserService.InsertUpdateSponsor(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agent,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertUpdateSponsor()");

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
        }


        /// <summary>
        /// API For Delete Agent Under Sponsor 
        /// </summary>
        /// <param name="obj">Sponsor details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteAgentSponsor")]
        public ResponseDataModel<string> DeleteAgentSponsor(SponsorModel obj)
        {
            try
            {
                var agent = sponserService.DeleteAgentSponsor(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agent,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "DeleteAgentSponsor()");

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
        }


        /// <summary>
        /// API For Delete Agent Under Sponsor 
        /// </summary>
        /// <param name="obj">Sponsor details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertAgentSponsor")]
        
        public ResponseDataModel<string> InsertAgentSponsor(SponsorModel obj)
        {
            try
            {
                var agentSponsor = sponserService.InsertAgentSponsor(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agentSponsor,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertAgentSponsor()");

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
        }

        //GetAllSponsors
        /// <summary>
        /// API For getting Sponsor 
        /// </summary>
        /// <returns>Sponser list</returns>
        [HttpPost]
        [Route("GetAllSponsors")]
        public ResponseDataModel<IEnumerable<SponsorMasterModelAll>> GetAllSponsors(SponsorMasterModelAll obj)
        {
            try
            {
                List<SponsorMasterModelAll> sponser = new List<SponsorMasterModelAll>();
                sponser = sponserService.GetAllSponsors(obj.BranchId);
                var response = new ResponseDataModel<IEnumerable<SponsorMasterModelAll>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponser
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorMasterModelAll>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For saving Sponsor Consent data
        /// </summary>
        /// <param name="obj">Sponsor Consent details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateSponsorConsent")]
        public ResponseDataModel<string> InsertUpdateSponsorConsent(SponserConsentModelAll obj)
        {
            try
            {
                var agent = sponserService.InsertUpdateSponsorConsent(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agent,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertUpdateSponsorConsent()");

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
        }

        /// <summary>
        /// API For getting Sponser types
        /// </summary>
        /// <returns>Sponser Consent list</returns>
        [HttpPost]
        [Route("GetSponsorConsent")]
        public ResponseDataModel<IEnumerable<SponserConsentModel>> GetSponsorConsent(SponserConsentModelAll obj)
        {
            try
            {
                List<SponserConsentModel> sponser = new List<SponserConsentModel>();
                sponser = sponserService.GetSponsorConsent(obj.BranchId);
                var response = new ResponseDataModel<IEnumerable<SponserConsentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponser
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponserConsentModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
