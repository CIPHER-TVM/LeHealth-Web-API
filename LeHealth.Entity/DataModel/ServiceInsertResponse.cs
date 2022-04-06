using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ServiceInsertResponse
    {
        public int serviceOrderId { get; set; }
        public string orderNo { get; set; }
        public string responseMessage { get; set; }
    }
}
