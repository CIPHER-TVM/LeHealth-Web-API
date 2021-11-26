using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Service.ServiceInterface 
{
    public interface IFileUploadService 
    {
        string SaveFile(AAASampleFileUploadTest fileobj); 
    }
}
