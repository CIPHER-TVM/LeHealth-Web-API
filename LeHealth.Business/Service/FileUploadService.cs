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

        public List<RegDocLocationModel> SaveFileMultiple(List<IFormFile> Files)
        {
            List<RegDocLocationModel> retvals = new List<RegDocLocationModel>();
            using (var ms = new MemoryStream())
            {
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, @"uploads\documents");
                Files.ForEach(a =>
                {
                    RegDocLocationModel rlm = new RegDocLocationModel();
                    string fileName = a.FileName;
                    var fileNameArray = fileName.Split('.');
                    var extension = fileNameArray[(fileNameArray.Length - 1)];
                    Guid Uniquefilename = Guid.NewGuid();
                    var actualFileName = Uniquefilename + "." + extension;
                    string fullpathtest = "uploads/documents/" + actualFileName;
                    using (FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create))
                    {
                        a.CopyTo(stream);
                    }
                    rlm.FilePath = fullpathtest;
                    rlm.FileOriginalName = fileName;
                    retvals.Add(rlm);
                });

            }
            return retvals;
        }
        public string SaveFile(IFormFile File, string foldername)
        {
            string returnFilePath = string.Empty;
            using (var ms = new MemoryStream())
            {
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                //var PathWithFolderName = System.IO.Path.Combine(webRoot, "documents");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, foldername);
                string fileName = File.FileName;
                var fileNameArray = fileName.Split('.');
                var extension = fileNameArray[(fileNameArray.Length - 1)];
                Guid Uniquefilename = Guid.NewGuid();
                string actualFileName = Uniquefilename + "." + extension;
                returnFilePath = "uploads/" + foldername + "/" + actualFileName;
                using FileStream stream = new FileStream(Path.Combine(PathWithFolderName, actualFileName), FileMode.Create);
                File.CopyTo(stream);
            }
            return returnFilePath;
        }
        public string SaveBase64Fn(string Base64ImageString,string folderName)
        {
            try
            {
                var webRoot = _env.WebRootPath;
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var PathWithFolderName = System.IO.Path.Combine(webRoot, folderName);
                byte[] docbytes = Convert.FromBase64String(Base64ImageString);
                Guid Uniquefilename = Guid.NewGuid();
                var actualFileName = Uniquefilename + "." + ".png";
                System.IO.File.WriteAllBytes(PathWithFolderName + actualFileName, docbytes);
                string returnfilePath = "uploads/" + folderName + "/" + actualFileName;
                return returnfilePath;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
