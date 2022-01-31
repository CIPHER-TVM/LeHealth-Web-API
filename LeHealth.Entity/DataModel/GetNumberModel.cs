using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetNumberModel
    {
        public int selectopt { get; set; }
        public string NumId { get; set; } 
        public string Description { get; set; }
        public int Value { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Length { get; set; }
        public int State { get; set; }
        public int Status { get; set; }
        public int MaxLength { get; set; }
        public string Preview { get; set; }
        public int UserId { get; set; } 
    }
}
