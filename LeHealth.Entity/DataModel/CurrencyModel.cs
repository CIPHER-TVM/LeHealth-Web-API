using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyDesc { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class CurrencyModelAll : CurrencyModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
    }
}
