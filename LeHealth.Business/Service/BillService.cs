using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;

namespace LeHealth.Service.Service
{
    public class BillService:IBillService
    {
        private readonly IBillManager billmanager;

        public List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm)
        {
            return billmanager.GetSponsorForm(frm);
        }
    }
}
