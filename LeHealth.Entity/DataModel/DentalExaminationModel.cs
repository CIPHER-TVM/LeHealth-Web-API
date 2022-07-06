using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DentalExaminationModel
    {
        public int Id { get; set; }
        public string ExtraOral { get; set; }
        public string SoftTissue { get; set; }
        public string HardTissue { get; set; }
        public string Others { get; set; }
        public int VisitId { get; set; }
        public int UserId { get; set; }
    }
}
