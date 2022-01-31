using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AppoinmentValidCheckModel
    {
        public int ConsultantId { get; set; }
        public string AppDate { get; set; }
        public int TimeSliceFirst { get; set; }
        public int RequiredSlots { get; set; } 
    }
}
