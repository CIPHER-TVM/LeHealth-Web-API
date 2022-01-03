using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeHealth.Core.DataManager
{
    public class UserPermissionManager : IUserPermissionManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public UserPermissionManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        #region UserGroups
        public UserGroupModel getUserGroup(int id)
        {
            UserGroupModel obj = new UserGroupModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_getUserGroupsMaster", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToObject<UserGroupModel>();
                    }
                    return obj;
                }
            }
        }

        public List<UserGroupModel> getUserGroups()
        {
            List<UserGroupModel> obj = new List<UserGroupModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_getUserGroupsMaster", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@P_Id", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToListOfObject<UserGroupModel>();
                    }
                    return obj;
                }
            }
        }

        public string SaveUserGroup(UserGroupModel obj)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SaveUserGroup", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_UserGroupId", obj.UserGroupId);
                        cmd.Parameters.AddWithValue("@P_UserGroup", obj.UserGroup);
                        cmd.Parameters.AddWithValue("@P_Active", obj.Active);
                        cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);
                        SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retValV);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retDesc);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        var ret = retValV.Value;
                        var descrip = retDesc.Value.ToString();

                        response = descrip;
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }
        #endregion
    }
}
