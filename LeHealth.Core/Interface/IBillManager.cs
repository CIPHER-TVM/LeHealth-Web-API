﻿using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;

namespace LeHealth.Core.Interface
{
    public interface IBillManager
    {
        List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm);
    }
}
