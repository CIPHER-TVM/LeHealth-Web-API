using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IBillService
    {
        List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm);
    }
}
