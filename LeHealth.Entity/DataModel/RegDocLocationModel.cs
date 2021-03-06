using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RegDocLocationModel
    {
        public Int32 Id { get; set; } 
        public string FilePath { get; set; } 
        public string FileType { get; set; }  
        public string FileOriginalName { get; set; }  
        public string NewUniqueName { get; set; }   
    }
}
