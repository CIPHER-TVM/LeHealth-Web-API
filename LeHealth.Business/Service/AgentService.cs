using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class AgentService :IAgentService
    {
        private readonly IAgentManager agentmanager;

        public AgentService(IAgentManager _agentmanager)
        {
            agentmanager = _agentmanager;
        }

        public string Save(AgentModel obj)
        {
            return agentmanager.Save(obj);
        }
        public List<AgentModel> GetAgents(AgentModel agent)
        {
            return agentmanager.GetAgents(agent);
        }
        public AgentModel GetAgentById(Int32 Agentid)
        {
            return agentmanager.GetAgentById(Agentid);
        }

        public AgentSponsorModel GetAgentForSponsor(Int32 sponsorid)
        {
            return agentmanager.GetAgentForSponsor(sponsorid);
        }
    }
}
