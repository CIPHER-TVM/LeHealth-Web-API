using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class AAASampleFileUploadTest
    {
        public List<IFormFile> Files { get; set; } 
        public String FilePathName { get; set; } 
        public String FileName  { get; set; } 
    }
}
