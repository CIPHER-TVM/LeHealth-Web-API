using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
   public  interface IAgentService
    {
        string Save(AgentModel obj);
        List<AgentModel> GetAgents(Int32 hospitalId);
        AgentModel GetAgentById(Int32 agentid);
        AgentSponsorModel GetAgentForSponsor(Int32 agentid);

    }
}
