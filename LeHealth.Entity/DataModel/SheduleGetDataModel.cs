using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SheduleGetDataModel
    {
        public int id { get; set; }
        public string drName { get; set; }
        public List<Label> labels { get; set; }
    }

    public class Label
    {
        public string time { get; set; }
        public string name { get; set; }
    }
}
