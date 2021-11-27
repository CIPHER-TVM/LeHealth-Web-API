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

namespace LeHealth.Service.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadService hospitalsManager;
        private IHostingEnvironment _env;
        public FileUploadService(IHospitalsManager _hospitalsManager, IHostingEnvironment env)
        {
            _env = env;
            // hospitalsManager = _hospitalsManager;

        }

        public List<string> SaveFileMultiple(List<IFormFile> Files)
        {
            List<string> retvals = new List<string>();
            using (var ms = new MemoryStream())
            {
                //filep.TestingFile.CopyTo(ms);
                //var fileBytes = ms.ToArray();
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, "documents");
                //if (!Directory.Exists(PathWithFolderName))
                //{
                //    Directory.CreateDirectory(PathWithFolderName);
                //}
                //System.IO.File.WriteAllBytes(PathWithFolderName , fileBytes);
                Files.ForEach(a =>
                {
                    string fileName = a.FileName;
                    var fileNameArray = fileName.Split('.');
                    var extension = fileNameArray[(fileNameArray.Length - 1)];
                    Guid Uniquefilename = Guid.NewGuid();
                    var actualFileName = Uniquefilename + "." + extension;
                  
                    retvals.Add(actualFileName);
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
            string actualFileName = "";
            using (var ms = new MemoryStream())
            {
                //filep.TestingFile.CopyTo(ms);
                //var fileBytes = ms.ToArray();
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, "documents");
                //if (!Directory.Exists(PathWithFolderName))
                //{
                //    Directory.CreateDirectory(PathWithFolderName);
                //}
                //System.IO.File.WriteAllBytes(PathWithFolderName , fileBytes);
              
                string fileName = File.FileName;
                var fileNameArray = fileName.Split('.');
                var extension = fileNameArray[(fileNameArray.Length - 1)];
                Guid Uniquefilename = Guid.NewGuid();
                 actualFileName = Uniquefilename + "." + extension;
                using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create))
                    {
                    File.CopyTo(stream);

                    }

            }
            return actualFileName;
        }
    }
}
