using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetNumberModel
    {
        public int selectopt { get; set; }
        public String NumId { get; set; } 
        public String Description { get; set; }
        public int Value { get; set; }
        public String Prefix { get; set; }
        public String Suffix { get; set; }
        public int Length { get; set; }
        public int State { get; set; }
        public int Status { get; set; }
        public int MaxLength { get; set; }
        public String Preview { get; set; }
    }
}
