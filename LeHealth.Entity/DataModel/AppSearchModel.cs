
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class AppSearchModel
    {
        public Int32 AppId { get; set; }
        public DateTime AppDate { get; set; }
        public String AppNo { get; set; }
        public String CFirstName { get; set; }
        public String FirstName { get; set; }
        public String PatientRegNo { get; set; }
        public String Mobile { get; set; }
        public String Sponsor { get; set; }
        public String PatientName { get; set; }
        public Int32 AppType { get; set; }
        public String TimeNo { get; set; }
        public String RegNo { get; set; }
        public String Status { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public DateTime EntryDate { get; set; }
        public Int32 SliceNo { get; set; }
        public String SliceTime { get; set; }
        public String Title { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Street { get; set; }
        public String PlacePO { get; set; }
        public String PIN { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public Int32 CountryId { get; set; }
        public String ResPhone { get; set; }
        public String OffPhone { get; set; }
        public String Email { get; set; }
        public String Remarks { get; set; }
        public String AppStatus { get; set; }
        public bool Reminder { get; set; }
        public String CancelReason { get; set; }
        public Int32 UserId { get; set; }

        //public int appTypeId = 1;
        public Int32 AppTypeId { get; set; }
        public Int32 SessionId { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 RetVal { get; set; }
        public String RetDesc { get; set; }

    }
}
