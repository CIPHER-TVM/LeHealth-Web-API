using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   

    public class ServiceInsertInputModel
    {
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public int BranchId { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
        public int ConsultationId { get; set; }
        public int PackId { get; set; }
        public string PackNo { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int SerialNo { get; set; }
        public int LocationId { get; set; }
        public string Status { get; set; }
        public string PayStatus { get; set; }
        public List<ItemObj> ItemObj { get; set; }
    }
    public class ItemObj
    {
        //public int itemId { get; set; }
        //public int itemType { get; set; }
        //public int itemTypeId { get; set; }
        public object itemId { get; set; }
        public int itemType { get; set; }
        public int itemTypeId { get; set; }
    }

}
