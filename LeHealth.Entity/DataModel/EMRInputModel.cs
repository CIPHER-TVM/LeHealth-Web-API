using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class EMRInputModel
    {
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public int FolderId { get; set; }
        public int ShowAll { get; set; }
        public string FolderName { get; set; }
        public int IsDeleting { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string ServiceName { get; set; }
        public string Notes { get; set; }
        public List<RegDocLocationModel> FolderLocation { get; set; }

    }
    public class EMRSaveFilesModel : EMRInputModel
    {
        public List<IFormFile> EMRFiles { get; set; }
    }
    public class EMRFileSaveRequestModel
    {
        public string FileJson { get; set; }
        public List<IFormFile> PatientDocs { get; set; }
    }
    public class EMRFileOutputModel
    {
        public int PatientId { get; set; }
        public int FolderId { get; set; }
        public int UserId { get; set; }
    }

    public class EMRFileDBSaveModel
    {
        public string FilePath { get; set; }
        public string FileOriginalName { get; set; }
    }
}
