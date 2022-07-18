using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TreatmentDetailsModel
    {
        public int Id { get; set; }
        public int? ConsultationId { get; set; } = 0;
        public int? AppointmentId { get; set; } = 0;
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string RegNo { get; set; }
        public string Mobile { get; set; }
        public int ServicePoint { get; set; }
        public int PerformingStaff { get; set; }
        public string TreatmentNumber { get; set; }
        public string TreatmentDate { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string TreatmentDetails { get; set; }
        public string TreatmentRemarks { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public List<TreatmentItemModel> ItemDetails { get; set; }
    }
    public class TreatmentDetailsModelIP
    {

    }
    public class TreatmentItemModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string OrderDate { get; set; }
        public int Route { get; set; }
        public string Dosage { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Notes { get; set; }
    }
}
