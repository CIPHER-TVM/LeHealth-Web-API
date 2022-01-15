using System;

namespace LeHealth.Entity.DataModel
{
    public class SearchAppointmentModel
    {
        public Int32 AppId { get; set; }
        public string AppDate { get; set; }
        public string AppNo { get; set; } 
        public string CFirstName { get; set; }
        public string PatientRegNo { get; set; }
        public string Mobile { get; set; }
        public string ConsultantName { get; set; }
        public string PatientName { get; set; }
        public Int32 AppType { get; set; }
        public string TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Status { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public DateTime EntryDate { get; set; }
        
        
       
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string City { get; set; }
        public Int32 State { get; set; }
        public string StateName { get; set; }
        public Int32 CountryId { get; set; }
        public string CountryName { get; set; }
        public string ResPhone { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string AppStatus { get; set; }
        public bool Reminder { get; set; }
        public string CancelReason { get; set; }
        public Int32 UserId { get; set; }

        //public int appTypeId = 1;
        public Int32 AppTypeId { get; set; }
        public Int32 SessionId { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 RetVal { get; set; }
        public string RetDesc { get; set; }
        //
        public Int32 Title { get; set; }
        public string TitleText { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SliceTime { get; set; }
        public int DeptId { get; set; } 
        public string DepartmentName { get; set; }
        public Int32 SliceNo { get; set; }


    }
}
