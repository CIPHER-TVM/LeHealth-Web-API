using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class MenuGroupModel
    {
        public int GroupId { get; set; }
        public List<int> MenuIds { get; set; }
    }
}
