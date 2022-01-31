using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
namespace LeHealth.Service.ServiceInterface
{
    public interface IFormValidationService
    {
        List<FormValidationModel> GetFormValidation(Int32 FormId, Int32 DepartmentId);
        String InsertUpdateFormValidation(FormValidationModel formvalidation);
    }
}
