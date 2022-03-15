using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantMasterModel
    {
        public int ConsultantId { get; set; }
        public int DeptId { get; set; }
        public string ConsultantCode { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Specialisation { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public int NationalityId { get; set; }
        public string Mobile { get; set; }
        public string ResPhone { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public DateTime DOJ { get; set; }
        public string CRegNo { get; set; }
        public int TimeSlice { get; set; }
        public int AppType { get; set; }
        public int MaxPatients { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
        public int ItemId { get; set; }
        public string RoomNo { get; set; }
        public int UserId { get; set; }
        public byte[] Signature { get; set; }
        public int ConsultantLedger { get; set; }
        public int CommissionId { get; set; }
        public int SortOrder { get; set; }
        public string SpecialityCode { get; set; }

        public bool AllowCommission { get; set; }
        public bool DeptOverrule { get; set; }
        public bool DeptWiseConsultation { get; set; }
        public bool ExternalConsultant { get; set; }




    }
}
