using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ReregistrationModel
    {
        public int RegDate { get; set; }
        public int PatientId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int SessionId { get; set; }
    }
}
