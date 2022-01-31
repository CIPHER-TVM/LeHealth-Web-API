using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class Appointments
    {
        public int AppId { get; set; }
        public String AppDate { get; set; }
        public int AppNo { get; set; }
        public String CFirstName { get; set; }
        public String FirstName { get; set; }
        public String PatientRegNo { get; set; }
        public String Mobile { get; set; }
        public String Sponsor { get; set; }
        public String PatientName { get; set; }
        public int AppType { get; set; }
        public String TimeNo { get; set; }
        public String RegNo { get; set; }
        public String Status { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public DateTime EntryDate { get; set; }
        public int SliceNo { get; set; }
        public String SliceNos { get; set; }
        public String SliceTime { get; set; }
        public int Title { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Street { get; set; }
        public String PlacePO { get; set; }
        public String PIN { get; set; }
        public String City { get; set; }
        public int State { get; set; }
        public int CountryId { get; set; }
        public String ResPhone { get; set; }
        public String OffPhone { get; set; }
        public String Email { get; set; }
        public String Remarks { get; set; }
        public String AppStatus { get; set; }
        public bool Reminder { get; set; }
        public String CancelReason { get; set; }
        public int Gender { get; set; }
        public int UserId { get; set; }
        public int AppTypeId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public int RetVal { get; set; }
        public String RetDesc { get; set; }
        public int SlotCount { get; set; }
        public int DeptId { get; set; }
        public List<Slice> SliceData  { get; set; }
    }
    public class Slice
    {
        public int SliceNo { get; set; }
        public String SliceTime { get; set; }
    }
}
