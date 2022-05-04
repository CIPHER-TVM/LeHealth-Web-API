using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SalutationModel
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
    }
    public class SalutationModelAll : SalutationModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
