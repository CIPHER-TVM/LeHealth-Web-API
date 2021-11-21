using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class FormValidationModel
    {
        public string FormName { get; set; }
        public Int32 FormId { get; set; }
        public long FieldId { get; set; }
        public string FieldName { get; set; }
        public Int32 DepartmentId { get; set; }

        public bool IsMandatory { get; set; }

    }
}
