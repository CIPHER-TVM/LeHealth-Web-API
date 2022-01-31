using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LeHealth.Service
{
    public class FormValidationService : IFormValidationService
    {
        private readonly IFormValidationManager formValidationManager;
        public FormValidationService(IFormValidationManager _formValidationManager)
        {
            formValidationManager = _formValidationManager;
        }
        public List<FormValidationModel> GetFormValidation(Int32 FormId, Int32 DepartmentId)
        {
            return formValidationManager.GetFormValidation(FormId, DepartmentId);
        }
        public String InsertUpdateFormValidation(FormValidationModel formvalidation)
        {
            return formValidationManager.InsertUpdateFormValidation(formvalidation);
        }
    }
}
