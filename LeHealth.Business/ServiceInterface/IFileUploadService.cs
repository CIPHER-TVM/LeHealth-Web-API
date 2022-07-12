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
        List<RegDocLocationModel> SaveFileMultiple(List<IFormFile> Files);
        List<RegDocLocationModel> SaveEMRFileMultiple(List<IFormFile> Files,int PatientId);
        string SaveFile(IFormFile File, string foldername);
        string SaveBase64Fn(string filestring, string foldername);
    }
}
