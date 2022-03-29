﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class UserGroupModel
    {
        public int UserGroupId { get; set; }
        public string UserGroup { get; set; }
        public int branchId { get; set; }
        public bool Active { get; set; }
        public string BlockReason { get; set; }
        public List<int> submenuIds { get; set; }
    }
    public class UserMenuModel
    {
        public int userId { get; set; }
        public int branchId { get; set; }
        public List<int> submenuIds { get; set; }
    }
}
