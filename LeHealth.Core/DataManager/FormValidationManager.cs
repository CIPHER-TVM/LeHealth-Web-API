using Microsoft.Extensions.Configuration;
using LeHealth.Core.Interface;
using LeHealth.Entity;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;

namespace LeHealth.Core.DataManager
{
    public class FormValidationManager : IFormValidationManager, IDisposable
    {
        bool disposed = false;

        private readonly string _connStr;
        public FormValidationManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }

            disposed = true;
        }

        public List<FormValidationModel> GetFormValidation(Int32 FormId, Int32 DepartmentId)
        {
            List<FormValidationModel> FormValidationList = new List<FormValidationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetFormValidation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormId", FormId);
                    cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet FormValidation = new DataSet();
                    adapter.Fill(FormValidation);
                    if ((FormValidation != null) && (FormValidation.Tables.Count > 0) && (FormValidation.Tables[0] != null) && (FormValidation.Tables[0].Rows.Count > 0))
                        FormValidationList = FormValidation.Tables[0].ToListOfObject<FormValidationModel>();
                    return FormValidationList;
                }
            }
        }

        ~FormValidationManager()
        {
            Dispose(false);
        }

    }
}
