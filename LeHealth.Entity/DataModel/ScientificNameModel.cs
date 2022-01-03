using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ScientificNameModel
    {
        public int ScientificId { get; set; }
        public string ScientificCode { get; set; }
        public string ScientificName { get; set; }
        public int Active { get; set; } 
        public int UserId { get; set; } 
    }
}
