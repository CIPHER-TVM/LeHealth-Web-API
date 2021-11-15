using LeHealth.Entity.DataModel;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        List<ProffessionModel> GetProfession();
        List<RateGroupModel> GetRateGroup(int rgroup);
    }
}
