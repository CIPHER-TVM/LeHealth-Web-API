using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PendingItemModel
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public string ConsultantName { get; set; }
        public string OrderDate { get; set; }
        public List<ServiceItem> ItemData { get; set; }
    }
    public class ServiceItem
    {
        public string PayStatus { get; set; }
        public string Status { get; set; }
        public string RequestStatus { get; set; }
        public string ItemName { get; set; }
        public string OrderId { get; set; }
    }
    public class PendingItemInputData
    {
        public int PatientId { get; set; }
        public int BranchId { get; set; }
    }
}
