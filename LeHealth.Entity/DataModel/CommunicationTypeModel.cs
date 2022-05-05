using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CommunicationTypeModel
    {
        public int Id { get; set; }
        public string CommunicationType { get; set; }
    }
    public class CommunicationTypeModelAll : CommunicationTypeModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
