using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SalutationModel
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public int UserId { get; set; } 
        public int Active { get; set; } 
        public string BlockReason { get; set; } 
    }
}
