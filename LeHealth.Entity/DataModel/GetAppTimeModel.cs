using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetAppTimeModel
    {
        public int SliceNo { get; set; }
        public string SliceTime { get; set; }
        public string SelectTime { get; set; }
        public int AppNo { get; set; }
        public string PatientName { get; set; }
    }
}
