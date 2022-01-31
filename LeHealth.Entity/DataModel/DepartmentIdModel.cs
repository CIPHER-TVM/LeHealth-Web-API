using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DepartmentIdModel
    {
        //public List<Int32?> Departments { get; set; }
        public Int32?[] Departments { get; set; }
        public String ConsultantName { get; set; }
        public bool ShowExternal { get; set; }
    }
}
