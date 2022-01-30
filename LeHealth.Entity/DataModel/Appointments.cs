using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class Appointments
    {
        public int AppId { get; set; }
        public string AppDate { get; set; }
        public int AppNo { get; set; }
        public string CFirstName { get; set; }
        public string FirstName { get; set; }
        public string PatientRegNo { get; set; }
        public string Mobile { get; set; }
        public string Sponsor { get; set; }
        public string PatientName { get; set; }
        public int AppType { get; set; }
        public string TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Status { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public DateTime EntryDate { get; set; }
        public int SliceNo { get; set; }
        public string SliceTime { get; set; }
        public int Title { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int CountryId { get; set; }
        public string ResPhone { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string AppStatus { get; set; }
        public bool Reminder { get; set; }
        public string CancelReason { get; set; }
        public int Gender { get; set; }
        public int UserId { get; set; }
        public int AppTypeId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public int RetVal { get; set; }
        public string RetDesc { get; set; }
        public int SlotCount { get; set; }
        public int DeptId { get; set; }
        public List<Slice> SliceData  { get; set; }
    }
    public class Slice
    {
        public int SliceNo { get; set; }
        public string SliceTime { get; set; }
    }
}
