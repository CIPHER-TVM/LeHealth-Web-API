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
        //

        /// <summary>
        /// API For gettingSponsor Types 
        /// </summary>
        /// <param name="sponsortypedetails">SponsorType table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetSponsorTypeByID")]

        public ResponseDataModel<IEnumerable<SponsorTypeModel>> GetSponsorTypeByID(SponsorTypeModel sponsor)
        {
            try
            {
                List<SponsorTypeModel> StypeList = new List<SponsorTypeModel>();
                StypeList = sponserService.GetSponsorTypeByID(sponsor);
                var response = new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = StypeList
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
        /// API For saving Sponsor Rule data and 
        /// saving SponsorRuleGroup and SponsorRuleItem under SponsorRule
        /// </summary>
        /// <param name="obj">Sponsor Rule Details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateSponsorRule")]
        public ResponseDataModel<string> InsertUpdateSponsorRule(SponsorRuleModel obj)
        {
            try
            {
                string message = string.Empty;
                message = sponserService.InsertUpdateSponsorRule(obj);
                //var agent = sponserService.InsertUpdateSponsor(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    // Response = agent,
                    Message = message

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertUpdateSponsorRule()");

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



        /// <summary>
        /// API For gettingSponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetSponsorForm")]

        public ResponseDataModel<IEnumerable<SponsorFormModel>> GetSponsorForm(SponsorFormModel frm)
        {
            try
            {
                List<SponsorFormModel> formList = new List<SponsorFormModel>();
                formList = sponserService.GetSponsorForm(frm);
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = formList
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
        /// API For saving sponsor Forms  data
        /// </summary>
        /// <param name="obj">Sponsor Form details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateSponsorForms")]
        public ResponseDataModel<string> InsertUpdateSponsorForms(SponsorFormModel obj)
        {
            try
            {
                string message = string.Empty;
                message = sponserService.InsertUpdateSponsorForms(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = "",
                    Message = message,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertUpdateSponsorForms()");

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
        /// API For saving SponsorRule group data
        /// </summary>
        /// <param name="obj">Sponsor Rule group details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertSponsorRuleGroup")]
        public ResponseDataModel<string> InsertSponsorRuleGroup(SponsorGroupModel obj)
        {
            try
            {
                var drug = sponserService.InsertSponsorRuleGroup(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drug,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertSponsorRuleGroup()");

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
        /// API For saving SponsorRule Item data
        /// </summary>
        /// <param name="obj">Sponsor Rule Item details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteSponsorRuleItem")]
        public ResponseDataModel<string> DeleteSponsorRuleItem(SponsorGropuServiceItemModel obj)
        {
            try
            {
                var drug = sponserService.DeleteSponsorRuleItem(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drug,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "DeleteSponsorRuleItem()");

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
        /// API For saving SponsorRule Item data
        /// </summary>
        /// <param name="obj">Sponsor Rule Item details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertSponsorRuleItem")]
        public ResponseDataModel<string> InsertSponsorRuleItem(SponsorGropuServiceItemModel obj)
        {
            try
            {
                var drug = sponserService.InsertSponsorRuleItem(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drug,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertSponsorRuleItem()");

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
        /// API For getting Service Items for rules 
        /// </summary>
        /// <param name="ruledetails">SponsorRles table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetSponsorItemForRule")]

        public ResponseDataModel<IEnumerable<SponsorGropuServiceItemModel>> GetSponsorItemForRule(SponsorGropuServiceItemModel itm)
        {
            try
            {
                List<SponsorGropuServiceItemModel> itemList = new List<SponsorGropuServiceItemModel>();
                itemList = sponserService.GetSponsorItemForRule(itm);
                var response = new ResponseDataModel<IEnumerable<SponsorGropuServiceItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorGropuServiceItemModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting sponsor group for rules 
        /// </summary>
        /// <param name="ruledetails">SponsorRles table</param>
        /// <returns>sponsor group  data for rule</returns>

        [HttpPost]
        [Route("GetSponsorGroupForRule")]

        public ResponseDataModel<IEnumerable<SponsorGroupModel>> GetSponsorGroupForRule(SponsorGroupModel ruledesc)
        {
            try
            {
                List<SponsorGroupModel> groupList = new List<SponsorGroupModel>();
                groupList = sponserService.GetSponsorGroupForRule(ruledesc);
                var response = new ResponseDataModel<IEnumerable<SponsorGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = groupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorGroupModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Rule description Under Sponsor
        /// </summary>
        /// <param name="ruledesc">SponsorRles table</param>
        /// <returns>SponsorRule data</returns>

        [HttpPost]
        [Route("GetRuleDescription")]

        public ResponseDataModel<IEnumerable<SponsorRuleModel>> GetRuleDescription(SponsorRuleModel ruledesc)
        {
            try
            {
                List<SponsorRuleModel> ruleList = new List<SponsorRuleModel>();
                ruleList = sponserService.GetRuleDescription(ruledesc);
                var response = new ResponseDataModel<IEnumerable<SponsorRuleModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = ruleList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorRuleModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For Deleting consultant Reduction data
        /// </summary>
        /// <param name="obj">consultant Reduction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteConsultantReduction")]
        public ResponseDataModel<string> DeleteConsultantReduction(ConsultantReductionModel obj)
        {
            try
            {
                var drug = sponserService.DeleteConsultantReduction(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drug,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "DeleteConsultantReduction()");

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
        /// API For saving consultant Reduction data
        /// </summary>
        /// <param name="obj">consultant Reduction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertConsultantReduction")]
        public ResponseDataModel<string> InsertConsultantReduction(ConsultantReductionModel obj)
        {
            try
            {
                string message = string.Empty;
               message = sponserService.InsertConsultantReduction(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertConsultantReduction()");

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
        /// API For getting Drug List Under Sponsorrule  
        /// </summary>
        /// <param name="drug">Drug table</param>
        /// <returns>SponsorRule data</returns>

        [HttpPost]
        [Route("GetConsultantReduction")]

        public ResponseDataModel<IEnumerable<ConsultantReductionModel>> GetConsultantReduction(ConsultantReductionModel creduction)
        {
            try
            {
                List<ConsultantReductionModel> creductionList = new List<ConsultantReductionModel>();
                creductionList = sponserService.GetConsultantReduction(creduction);
                var response = new ResponseDataModel<IEnumerable<ConsultantReductionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = creductionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantReductionModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For  Deleting Drugs under SponsorRule data
        /// </summary>
        /// <param name="obj">Drug details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteSponsorRuleDrugList")]
        public ResponseDataModel<string> DeleteSponsorRuleDrugList(DrugModelAll obj)
        {
            try
            {
                var drug = sponserService.DeleteSponsorRuleDrugList(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drug,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "DeleteSponsorRuleDrugList()");

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
        /// API For saving Drugs under SponsorRule data
        /// </summary>
        /// <param name="obj">Drug details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertSponsorRuleDrugList")]
        public ResponseDataModel<string> InsertSponsorRuleDrugList(DrugModelAll obj)
        {
            try
            {
                string message = string.Empty;
                message = sponserService.InsertSponsorRuleDrugList(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    //Response = drug,
                    Message = message

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SponsorController", "InsertSponsorRuleDrugList()");

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
        /// API For getting Drug List Under Sponsorrule  
        /// </summary>
        /// <param name="drug">Drug table</param>
        /// <returns>SponsorRule data</returns>

        [HttpPost]
        [Route("GetDrugBySponsorRule")]

        public ResponseDataModel<IEnumerable<DrugModelAll>> GetDrugBySponsorRule(DrugModelAll drug)
        {
            try
            {
                List<DrugModelAll> drugList = new List<DrugModelAll>();
                drugList = sponserService.GetDrugBySponsorRule(drug);
                var response = new ResponseDataModel<IEnumerable<DrugModelAll>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drugList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DrugModelAll>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Sponsorrule  
        /// </summary>
        /// <param name="sponsorrule">sponsor rule model</param>
        /// <returns>SponsorRule data</returns>

        [HttpPost]
        [Route("GetSponsorRule")]

        public ResponseDataModel<IEnumerable<SponsorRuleModel>> GetSponsorRule(SponsorRuleModel sponsorrule)
        {
            try
            {
                List<SponsorRuleModel> sponsorruleList = new List<SponsorRuleModel>();
                sponsorruleList = sponserService.GetSponsorRule(sponsorrule);
                var response = new ResponseDataModel<IEnumerable<SponsorRuleModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorruleList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorRuleModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Sponsor  by  Id
        /// </summary>
        /// <param name="Sponsorid">Primary key of Sponsor table</param>
        /// <returns>Sponsor  data</returns>

        [HttpPost]
        [Route("GetSponsor")]
        
        public ResponseDataModel<IEnumerable<SponsorMasterModel>> GetSponsor(SponsorMasterModelAll sponsor)
        {
            try
            {
                List<SponsorMasterModel> professionList = new List<SponsorMasterModel>();
                professionList = sponserService.GetSponsor(sponsor);
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
                string message = string.Empty;
                message = sponserService.InsertUpdateSponsor(obj);
                //var agent = sponserService.InsertUpdateSponsor(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                   // Response = agent,
                    Message = message

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
            finally
            {
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
                string message = string.Empty;
                message = sponserService.InsertUpdateSponsorConsent(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = "",
                    Message = message,

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
