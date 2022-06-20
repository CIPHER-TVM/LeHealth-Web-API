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
    [Route("api/Agent")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> logger;
        private readonly IAgentService agentService;


        public AgentController(ILogger<AgentController> _logger, IAgentService _agentservice)
        {
            logger = _logger;
            agentService = _agentservice;
        }

        /// <summary>
        /// API For saving agent data
        /// </summary>
        /// <param name="obj">agent details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("Save")]
        public ResponseDataModel<string> Save(AgentModel obj)
        {
            try
            {
                var agent = agentService.Save(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agent,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AgentController", "Save()");

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
        /// API for Getting Agents by Hospital branch id
        /// </summary>
        /// <param name="HospitalId">Branch Id</param>
        /// <returns>Location list</returns>
        [HttpPost]
        [Route("GetAgents")]
        
       // public ResponseDataModel<IEnumerable<AgentModel>> GetAgents([FromBody] int HospitalId)
      
        public ResponseDataModel<IEnumerable<AgentModel>> GetAgents(AgentModel obj)
        {
            try
            {
                List<AgentModel> Agent = new List<AgentModel>();
                Agent = agentService.GetAgents(obj.HospitalId);
                var response = new ResponseDataModel<IEnumerable<AgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Agent
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AgentModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Agent data by Agent Id
        /// </summary>
        /// <param name="Agentid">Primary key of Agent table</param>
        /// <returns>Agent data</returns>

        [HttpPost]
        [Route("GetAgentById/{agentId}")]
        // public ResponseDataModel<LocationModel> GetLocationById([FromBody] int LocationId)
        //public ResponseDataModel<IEnumerable<ConsultantMasterModel>> GetConsultantById(int consultantId)
        public ResponseDataModel<AgentModel> GetAgentById(int agentid)
        {
            try
            {
                AgentModel Agent = new AgentModel();
                Agent = agentService.GetAgentById(agentid); 
                 var response = new ResponseDataModel<AgentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Agent
                 };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<AgentModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
        /// API For getting Agent for sponser Id
        /// </summary>
        /// <param name="sponserid">
        /// <returns>Location data</returns>

        [HttpPost]
        [Route("GetAgentForSponsor/{SponsorId}")]
         public ResponseDataModel<AgentSponsorModel> GetAgentForSponsor(int SponsorId)
        {
            try
            {
                AgentSponsorModel Agent = new AgentSponsorModel();
                Agent = agentService.GetAgentForSponsor(SponsorId);
                var response = new ResponseDataModel<AgentSponsorModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = Agent
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<AgentSponsorModel>()
                {
                    Status = HttpStatusCode.InternalServerError,
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
