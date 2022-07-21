using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TransactionDetailsModel
    {
        public int TransId { get; set; }
        public int TransDetId { get; set; }
        public int ItemId { get; set; }
        public float Rate { get; set; }
        public float ActualRate { get; set; }
        public float DiscPcnt { get; set; }
        public float DiscAmount { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public bool AllowRateEdit { get; set; }
        public bool AllowDisc { get; set; }
        public float Qty { get; set; }
        public float TaxAmount { get; set; }
        public int PostId { get; set; }
        public int OrderDetId { get; set; }
        public int CreditId { get; set; }
        public bool DedItem { get; set; }
        public bool CoPayItem { get; set; }
        public string ServiceDate { get; set; }
        public int GroupId { get; set; }
        public string AprovalNo { get; set; }
        public int Branchid { get; set; }
        public int ShowAll { get; set; }
    }
}
