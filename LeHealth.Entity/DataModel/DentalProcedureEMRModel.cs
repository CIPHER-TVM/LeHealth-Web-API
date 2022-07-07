using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DentalProcedureEMRModel
    {
        public int Id { get; set; }
        public string PlanDescription { get; set; }
        public int VisitId { get; set; }
        public string VisitDate { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int PatientId { get; set; }
        public List<DentalProcedureEMR> ProcedureDetails { get; set; }
    }
    public class DentalProcedureEMR
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Teeths { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalNumber { get; set; }
        public int BillingMode { get; set; }
        public int IsCompleted { get; set; } 
        public int UserId { get; set; } 
    }
}
