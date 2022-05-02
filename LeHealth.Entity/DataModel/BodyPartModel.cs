﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class BodyPartModel
    {
        public int BodyId { get; set; } 
        public string BodyDesc { get; set; } 
        public string BodyPartImageLocation { get; set; } 
    }
    public class BodyPartModelAll  : BodyPartModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
