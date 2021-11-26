using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class AAASampleFileUploadTest
    {
        public List<IFormFile> Files { get; set; } 
        public string FilePathName { get; set; } 
        public string FileName  { get; set; } 
    }
}
