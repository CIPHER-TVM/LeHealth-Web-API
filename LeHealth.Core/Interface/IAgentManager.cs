using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IAgentManager
    {
        string Save(AgentModel obj);
        List<AgentModel> GetAgents(AgentModel agent);
        AgentModel GetAgentById(Int32 agentid);

        AgentSponsorModel GetAgentForSponsor(Int32 Sponsorid);

    }
}
