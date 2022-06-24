using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
   public  interface IBillManager
    {
        List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm);
    }
}
