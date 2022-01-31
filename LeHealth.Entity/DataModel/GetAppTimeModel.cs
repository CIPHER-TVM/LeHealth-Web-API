using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetAppTimeModel
    {
        public int SliceNo { get; set; }
        public String SliceTime { get; set; }
        public String SelectTime { get; set; }
        public int AppNo { get; set; }
        public String PatientName { get; set; }
    }
}
