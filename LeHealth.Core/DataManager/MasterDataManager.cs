using System;
using System.Collections.Generic;
using System.Text;

using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;

namespace LeHealth.Core.DataManager
{
    public class MasterDataManager: IMasterDataManager 
    {
        private readonly string _connStr;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        public List<ProffessionModel> GetProfession()
        {
            List<ProffessionModel> profList = new List<ProffessionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfession", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfId", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            ProffessionModel obj = new ProffessionModel();
                            obj.ProfId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfId"]);
                            obj.ProfName = dsProfession.Tables[0].Rows[i]["ProfName"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        public List<AppTypeModel> GetAppType()
        {
            List<AppTypeModel> profList = new List<AppTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppointTypes", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            AppTypeModel obj = new AppTypeModel();
                            obj.AppTypeId  = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["AppTypeId"]);
                            obj.AppCode = dsProfession.Tables[0].Rows[i]["AppCode"].ToString();
                            obj.AppDesc = dsProfession.Tables[0].Rows[i]["AppDesc"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }

        public string InsertZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneName", zone.ZoneName);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zone.Id);
                    cmd.Parameters.AddWithValue("@zoneName", zone.ZoneName);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteZone(int zoneId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ZoneById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
                    return stateList;
                }
            }
        }
        public List<ZoneModel> GetAllZone()
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllZone", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
                    return stateList;
                }
            }
        }

        public List<ReligionModel> GetReligion()
        {
            List<ReligionModel> religionList = new List<ReligionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetReligion", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsReligionList = new DataSet();
                    adapter.Fill(dsReligionList);
                    con.Close();
                    if ((dsReligionList != null) && (dsReligionList.Tables.Count > 0) && (dsReligionList.Tables[0] != null) && (dsReligionList.Tables[0].Rows.Count > 0))
                        religionList = dsReligionList.Tables[0].ToListOfObject<ReligionModel>();
                    return religionList;
                }
            }
        }

        /// <summary>
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", 0);
                    cmd.Parameters.AddWithValue("@Active", 1);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DepartmentModel obj = new DepartmentModel();
                            obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
                            obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                            obj.DeptCode = ds.Tables[0].Rows[i]["DeptCode"].ToString();
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }

    }
}
