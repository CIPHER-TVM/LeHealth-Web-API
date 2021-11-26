using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LeHealth.Service.ServiceInterface 
{
    public interface IFileUploadService 
    {
        List<string> SaveFileMultiple(List<IFormFile> Files); 
        string SaveFile(IFormFile File); 
    }
}
