using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class LoginOutputModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Usersname { get; set; }
        public string Usertype { get; set; }
        public string UserState { get; set; }
        public string UserActive { get; set; }
        public string BlockReason { get; set; }
        public string Token { get; set; }
    }
}
