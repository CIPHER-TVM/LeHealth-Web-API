using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class BillItemModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public string ItemCode { get; set; }
        public int ItemId { get; set; }
        public float DiscAmount { get; set; }
        public int TreatNos { get; set; }
        public int ItemSelected { get; set; }
        public string ItemName { get; set; }
        public float Rate { get; set; }
        public string CPTDesc { get; set; }
        public int CommItemsOnly { get; set; }
        public int SPointId { get; set; }
        public int ServiceTtems { get; set; }
        public int BranchId { get; set; }
        public int ShowAll { get; set; }
    }
    public class UnBilledItemModel
    {
        public int Select { get; set; }
        public int PostId { get; set; }
        public string PostDate { get; set; }
        public int OrderDetId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Nos { get; set; }
        public int PatientId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string User { get; set; }
        public string Location { get; set; }
        public int Packid { get; set; }
        public int PayStatus { get; set; }
        public int ConsultantId { get; set; }
        public int External { get; set; }
        public int BranchId { get; set; }
        public int ShowAll { get; set; }

    }
    
}
      


