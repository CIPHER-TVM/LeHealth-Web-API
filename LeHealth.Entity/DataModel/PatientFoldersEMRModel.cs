using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientFoldersEMRModel
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public List<PatientFilesEMRModel> PatientFiles { get; set; }
    }
    public class PatientFilesEMRModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string Notes { get; set; } = "";
        public string UploadedDate { get; set; } = "";
    }
}
