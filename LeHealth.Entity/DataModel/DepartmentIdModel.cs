using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DepartmentIdModel
    {
        public List<int> Departments { get; set; }
        public string ConsultantName { get; set; }
        public bool ShowExternal { get; set; }
    }
}
