using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantByDeptModel
    {
        public int DeptId { get; set; }
        public bool ShowExternal { get; set; } = false;
    }
}
