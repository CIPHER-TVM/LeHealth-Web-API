using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IRegistrationManager registrationManager;
        public RegistrationService(IRegistrationManager _registrationManager)
        {
            registrationManager = _registrationManager;
        }
        public List<ProffessionModel> GetProfession()
        {
            return registrationManager.GetProfession();
        }
         public List<RateGroupModel> GetRateGroup(int rgroup)
        {
            return registrationManager.GetRateGroup(rgroup);
        }


    }
}
