using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LeHealth.Service.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;
        private IHostingEnvironment _env;
        private readonly string _uploadpath;
        public FileUploadService(IHospitalsManager _hospitalsManager, IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _uploadpath = configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public List<string> SaveFileMultiple(List<IFormFile> Files)
        {
            List<string> retvals = new List<string>();
            using (var ms = new MemoryStream())
            {
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, @"uploads\documents");
                Files.ForEach(a =>
                {
                    //string fileName = a.FileName;
                    //var fileNameArray = fileName.Split('.');
                    //var extension = fileNameArray[(fileNameArray.Length - 1)];
                    //Guid Uniquefilename = Guid.NewGuid();
                    //var actualFileName = Uniquefilename + "." + extension;
                    //retvals.Add(PathWithFolderName + @"\" + actualFileName);
                    //using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create))
                    //{
                    //    a.CopyTo(stream);
                    //}
                    string fileName = a.FileName;
                    var fileNameArray = fileName.Split('.');
                    var extension = fileNameArray[(fileNameArray.Length - 1)];
                    Guid Uniquefilename = Guid.NewGuid();
                    var actualFileName = Uniquefilename + "." + extension;
                    //retvals.Add(PathWithFolderName + @"\" + actualFileName);
                    //NEW CODE START
                    string fullpathtest = "uploads/documents/" + actualFileName;
                    retvals.Add(fullpathtest);
                    //NEW CODE END
                    using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create))
                    {
                        a.CopyTo(stream);
                    }
                });

            }
            return retvals;
        }
        public string SaveFile(IFormFile File)
        {
            string returnFilePath = "";
            using (var ms = new MemoryStream())
            {


                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, "documents");
                string fileName = File.FileName;
                var fileNameArray = fileName.Split('.');
                var extension = fileNameArray[(fileNameArray.Length - 1)];
                Guid Uniquefilename = Guid.NewGuid();
                string actualFileName = Uniquefilename + "." + extension;
                returnFilePath = "uploads/documents/" + actualFileName;
                using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create))
                {
                    File.CopyTo(stream);
                }
            }
            return returnFilePath;
        }
    }
}
