using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultRateModel
    {
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public int Rate { get; set; }
        public int EmergencyFees { get; set; }

    }
}
