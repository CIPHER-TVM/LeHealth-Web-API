using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IFormValidationManager
    {
        List<FormValidationModel> GetFormValidation(Int32 FormId,Int32 DepartmentId);
    }
}
