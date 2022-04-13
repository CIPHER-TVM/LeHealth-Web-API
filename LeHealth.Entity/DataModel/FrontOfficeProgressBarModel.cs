using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class FrontOfficeProgressBarModel
    {
        public int AppStatCountA { get; set; }
        public int AppStatCountC { get; set; }
        public int AppStatCountCF{ get; set; }
        public int AppStatCountF { get; set; }
        public int AppStatCountW { get; set; }
        public int ConStatCountW { get; set; }
        public int ConStatCountF { get; set; }
        public int ConStatCountC { get; set; }
        public int ConStatCountO { get; set; }

    }

    public class AppointmentCountModel
    {
        public int AppStatCountA { get; set; }
        public int AppStatCountC { get; set; }
        public int AppStatCountCF { get; set; }
        public int AppStatCountF { get; set; }
        public int AppStatCountW { get; set; }

    }

    public class ConsultationCountModel
    {
        public int ConStatCountW { get; set; }
        public int ConStatCountF { get; set; }
        public int ConStatCountC { get; set; }
        public int ConStatCountO { get; set; }

    }

}
