using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CardTypeModel
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public double ServiceCharge { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class CardTypeModelAll : CardTypeModel
    {
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int ShowAll { get; set; }
        public bool IsDeleted { get; set; }
    }
}
