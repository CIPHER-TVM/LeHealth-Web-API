﻿using System;
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
            //
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
                    using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, fileName), FileMode.Create))
                    {
                        a.CopyTo(stream);

                    }
                });
                
            }
            return "Success";
        }
        public string SaveFile(IFormFile File)
        {
            //
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
                    using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, fileName), FileMode.Create))
                    {
                    File.CopyTo(stream);

                    }

            }
            return "Success";
        }
    }
}
