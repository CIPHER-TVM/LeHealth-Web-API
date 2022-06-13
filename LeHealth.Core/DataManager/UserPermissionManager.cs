using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LeHealth.Core.DataManager
{
    public class UserPermissionManager : IUserPermissionManager
    {
        private readonly string _connStr;
        public UserPermissionManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }
        #region UserGroups
        public UserGroupModel GetUserGroup(Int32 id)
        {
            UserGroupModel obj = new UserGroupModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_getUserGroupsMaster", con);
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
                obj.submenuIds = new List<int>();
            }
            if ((ds != null) && (ds.Tables.Count > 1) && (ds.Tables[1] != null) && (ds.Tables[1].Rows.Count > 0))
            {

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    obj.submenuIds.Add(Convert.ToInt32(dr.ItemArray[0].ToString()));
                }
            }
            return obj;
        }
        public UserPermissionGroups GetUserGroupsonBranch(int branchId, int userid)
        {
            UserPermissionGroups obj = new UserPermissionGroups();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_getUserGroupsMasteronBranch", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_branchId", branchId);
            cmd.Parameters.AddWithValue("@P_userId", userid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                obj.userGroups = ds.Tables[0].ToListOfObject<UserGroupModel>();
            }
            if ((ds != null) && (ds.Tables.Count > 1) && (ds.Tables[1] != null) && (ds.Tables[1].Rows.Count > 0))
            {
                obj.groupIds = new List<string>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    obj.groupIds.Add(dr.ItemArray[0].ToString());
                }
            }
            return obj;
        }
        public List<UserGroupModel> GetUserGroups(int branchId)
        {
            List<UserGroupModel> obj = new List<UserGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_getUserGroupsMasterByBranch", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Branch_Id", branchId);
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
        public string SaveUserGroup(UserGroupModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_SaveUserGroup", con);
                try
                {
                    var jsonsubmenuIds = JsonConvert.SerializeObject(obj.submenuIds);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UserGroupId", obj.UserGroupId);
                    cmd.Parameters.AddWithValue("@P_branchId", obj.branchId);
                    cmd.Parameters.AddWithValue("@P_UserGroup", obj.UserGroup);
                    cmd.Parameters.AddWithValue("@P_Active", obj.Active);
                    cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);
                    cmd.Parameters.AddWithValue("@P_Submenu", jsonsubmenuIds);
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
            return response;
        }
        #endregion
        #region User
        public string SaveUser(UserModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_SaveUser", con);
                try
                {
                    var json = JsonConvert.SerializeObject(obj.BranchIds);
                    var jsongroups = JsonConvert.SerializeObject(obj.GroupIds);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@P_UserName", obj.UserName);
                    cmd.Parameters.AddWithValue("@P_UserPassword", obj.UserPassword);
                    cmd.Parameters.AddWithValue("@P_Active", obj.Active);
                    cmd.Parameters.AddWithValue("@P_Branches", json);
                    cmd.Parameters.AddWithValue("@P_Groups", jsongroups);
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
            return response;
        }
        public List<UserModel> GetUsers(Int32 branchId)
        {
            List<UserModel> obj = new List<UserModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_getUsers", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchId", branchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                obj = ds.Tables[0].ToListOfObject<UserModel>();
            return obj;
        }
        public UserModel GetUser(Int32 id)
        {
            UserModel obj = new UserModel();
            obj.BranchIds = new List<string>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_getUserMaster", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                obj = ds.Tables[0].ToObject<UserModel>();
                obj.GroupIds = new List<string>();
                obj.BranchIds = new List<string>();
            }
            if ((ds != null) && (ds.Tables.Count > 1) && (ds.Tables[1] != null) && (ds.Tables[1].Rows.Count > 0))
            {
                obj.BranchIds = new List<string>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    obj.BranchIds.Add(dr.ItemArray[0].ToString());
                }
            }
            if ((ds != null) && (ds.Tables.Count > 2) && (ds.Tables[2] != null) && (ds.Tables[2].Rows.Count > 0))
            {
                obj.GroupIds = new List<string>();
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    obj.GroupIds.Add(dr.ItemArray[0].ToString());
                }
            }
            return obj;
        }
        public List<HospitalModel> GetUserBranches(Int32 id)
        {
            List<HospitalModel> obj = new List<HospitalModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetBranchesOnUser", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                obj = ds.Tables[0].ToListOfObject<HospitalModel>();
            }
            return obj;
        }
        public List<UserGroupBranchModel> GetUserGroupBranches(Int32 id)
        {
            List<UserGroupBranchModel> obj = new List<UserGroupBranchModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUserGroupBranches", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    var branchobj = JsonConvert.DeserializeObject<UserGroupBranchModel>(dsProfession.Rows[i]["ValueDatas"].ToString());
                    obj.Add(branchobj);
                }
            }
            return obj;
        }
        public List<MapLocationModel> GetUserLocations(Int32 userId)
        {
            List<MapLocationModel> obj = new List<MapLocationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLocationsOnUser", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                obj = ds.Tables[0].ToListOfObject<MapLocationModel>();
            }
            return obj;
        }
        public MapUserGroupModel GetUserGrouponUser(int userId)
        {
            MapUserGroupModel obj = new MapUserGroupModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("getUserGrouponUser", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                obj.Groups = ds.Tables[0].ToListOfObject<groupmap>();
            }
            return obj;
        }
        public string MapLocation(MapLocationModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_SaveUserLocation", con);
                try
                {

                    var json = JsonConvert.SerializeObject(obj.LocationIds);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@P_Locations", json);
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
            return response;
        }
        public string MapUserGroup(MapUserGroupModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_SaveUserGroups", con);
                try
                {
                    var json = JsonConvert.SerializeObject(obj.Groups);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@P_Groups", json);
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
            return response;
        }
        public string SaveUsermenu(UserMenuModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_SaveUserMenus", con);
                try
                {

                    var json = JsonConvert.SerializeObject(obj.submenuIds);
                    var groupjson = JsonConvert.SerializeObject(obj.groupIds);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UserId", obj.userId);
                    cmd.Parameters.AddWithValue("@P_BranchId", obj.branchId);
                    cmd.Parameters.AddWithValue("@P_SubmenuIds", json);
                    cmd.Parameters.AddWithValue("@P_Groups", groupjson);

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
            return response;
        }
        #endregion
    }
}
