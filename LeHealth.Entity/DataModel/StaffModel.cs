using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class StaffModel
    {
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public string LicenceNo { get; set; }
        public string Category { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Signature { get; set; }
        public string DhaNo { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public string BlockReason { get; set; }
        public int Branchid { get; set; }
        public string Name { get; set; }
    }
}
