using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SketchIndicatorModel
    {
        public int IndicatorId { get; set; }
        public string IndicatorDesc { get; set; }
        public string ImageUrl { get; set; }
    }
    public class SketchIndicatorModelAll : SketchIndicatorModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
