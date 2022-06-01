using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CommunicationConfigurationModel
    {
        public int BranchId { get; set; }
        public string APIUrl { get; set; }
        public string UserName { get; set; }
        public string SMSPassword { get; set; }
        public string MailSender { get; set; }
        public string MailPassword { get; set; }
        public string SMTP { get; set; }
        public int SMTPPort { get; set; }
    }
}
