using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DrugModel
    {
        public int DrugId { get; set; }
        public string DrugCode { get; set; }
        public string DrugName { get; set; }
        public string Ingredient { get; set; }
        public string Form { get; set; }
        public int MarketStatus { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string IngredientStrength { get; set; }
        public string PackageNo { get; set; }
        public string DDCCode { get; set; }
        public int DrugTypeId { get; set; }
        public int RouteId { get; set; }
        public bool Active { get; set; }
        public int ScientificId { get; set; }
        public int TradeId { get; set; }
        public int IsDeleted { get; set; }
        public int ZoneId { get; set; }
        public ScientificNameModel ScientificNameDetails { get; set; }
        public RouteModel RouteDetails { get; set; }
        public TradeNameModel TradeNameDetails { get; set; }
    }
    public class DrugModelAll : DrugModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
