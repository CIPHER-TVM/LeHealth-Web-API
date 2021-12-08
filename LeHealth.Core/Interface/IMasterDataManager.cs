﻿using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {
        List<ProffessionModel> GetProfession();
        List<AppTypeModel> GetAppType();
    }
}
