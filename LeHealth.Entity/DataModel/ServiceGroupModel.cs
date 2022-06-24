using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ServiceGroupModel
    {
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public String Label { get; set; }
        public List<ServiceGroupModel> Children { get; set; }
        public string expandedIcon { get; set; } = "pi pi-folder-open";
        public string collapsedIcon { get; set; } = "pi pi-folder";
    }
    
   
}
