using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IRegistrationManager
    {
        List<ProffessionModel> GetProfession();
        List<RateGroupModel> GetRateGroup(int rgroup); 
    }
}
