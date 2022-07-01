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
        public string FolderName { get; set; }
        public int IsDeleting { get; set; }
        public int UserId { get; set; }
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
}
