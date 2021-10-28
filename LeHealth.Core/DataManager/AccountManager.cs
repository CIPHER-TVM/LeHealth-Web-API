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

namespace LeHealth.Core.DataManager
{
    public class AccountManager : IAccountManager, IDisposable
    {
        bool disposed = false;

        private readonly string _connStr;
        /// <summary>
        /// Initializing connection string
        /// </summary>
        /// <param name="_configuration"></param>
        public AccountManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        //Garbage Dispose
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

        ~AccountManager()
        {
            Dispose(false);
        }

        public List<LoginOutputModel> Login(CredentialModel credential)
        {
            List<LoginOutputModel> Appointmentlist = new List<LoginOutputModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                string AppQuery = "[stLH_Login]";
                using (SqlCommand cmd = new SqlCommand(AppQuery, con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", credential.Username);
                    cmd.Parameters.AddWithValue("@Password", credential.Password);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            LoginOutputModel obj = new LoginOutputModel();
                            obj.UserId = ds.Tables[0].Rows[i]["UserId"].ToString();
                            obj.Username = ds.Tables[0].Rows[i]["UserName"].ToString();
                            obj.Usertype = ds.Tables[0].Rows[i]["UserType"].ToString();
                            obj.UserState = ds.Tables[0].Rows[i]["State"].ToString();
                            obj.UserActive = ds.Tables[0].Rows[i]["Active"].ToString();
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            Appointmentlist.Add(obj);
                        }
                    }
                    return Appointmentlist;
                }
            }
        }

    }
}
