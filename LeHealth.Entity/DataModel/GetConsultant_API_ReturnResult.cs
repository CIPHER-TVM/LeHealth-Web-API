using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetConsultant_API_ReturnResult
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public List<ConsultantModel> Result { get; set; }
    }
}
