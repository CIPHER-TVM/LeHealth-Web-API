using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TradeNameModel
    {
        public int TradeId { get; set; }
        public string TradeName { get; set; }
        public int ScientificId { get; set; }
        public int RouteId { get; set; }
        public string DosageForm { get; set; }
        public string IngredentStrength { get; set; }
        public string PackagePrice { get; set; }
        public string GranularUnit { get; set; }
        public string Manufacturer { get; set; }
        public string RegisteredOwner { get; set; }
        public int IsDeleted { get; set; }
        public string TradeCode { get; set; }
    }
    public class TradeNameModelAll : TradeNameModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
