using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantMarkingModel
    {
        public int MarkId { get; set; }
        public string MarkDesc { get; set; }
        public int IndicatorId { get; set; }
        public string IndicatorDesc { get; set; }
        public string Colour { get; set; }
        public bool ShowCaption { get; set; }
        public int ConsultantId { get; set; }
    }

}
