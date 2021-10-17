﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class Appointments
    {
    public int AppId { get; set; }
        public string PatientName { get; set; }
        public string AppType { get; set; }
        public string TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Status { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AppDate { get; set; }
        public int AppNo { get; set; }
        public int SliceNo { get; set; }
        public string SliceTime { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Mobile { get; set; }
        public string ResPhone { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string AppStatus { get; set; }
        public bool Reminder { get; set; }
        public string CancelReason { get; set; }
        public int UserId { get; set; }

        public int appTypeId = 1;
        public int AppTypeId { get { return appTypeId; } set { appTypeId = value; } }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public int RetVal { get; set; }
        public string RetDesc { get; set; }


    }
}
