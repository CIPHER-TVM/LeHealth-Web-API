using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SheduleGetDataModel
    {
        public int id { get; set; }
        public string drName { get; set; }
        public string deptName { get; set; }
        public int slotlength { get; set; }
        public List<Label> labels { get; set; }
    }

    public class Label
    {
        public string SliceNo { get; set; }
        public string ConsultantName { get; set; } 
        public string AppId { get; set; }
        public string AppNo { get; set; }
        public string AppDate { get; set; }
        public string SliceTime { get; set; }
        public string PatientId { get; set; }
        public string RegNo { get; set; }
        public string PatientName { get; set; }
        public string MobileNumber { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; } 
    }
}
