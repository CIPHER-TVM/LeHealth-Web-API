using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class SearchAppointmentModel
    {
        public int AppId { get; set; }
        public DateTime AppDate { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string RegNo { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        public string Status { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int AppType { get; set; }
        public string AppNo { get; set; }
        public string ConsultantName { get; set; }

    }
}
