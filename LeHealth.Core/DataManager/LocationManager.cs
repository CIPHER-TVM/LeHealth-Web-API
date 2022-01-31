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
    public class LocationManager : ILocationManager
    {
        private readonly String _connStr;
        private readonly String _uploadpath;
        public LocationManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public LocationModel GetLocationById(int locationId)
        {
            LocationModel obj = new LocationModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLocation", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocationId", locationId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToObject<LocationModel>();
                    }
                    return obj;
                }
            }
        }

        public List<LocationModel> GetLocations(int hospitalId)
        {
            List<LocationModel> obj = new List<LocationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLocations", con))
                {
                    con.Open();
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_HospitalId",hospitalId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToListOfObject<LocationModel>();
                    }
                    return obj;
                }
            }
        }

        public List<LocationType> GetLocationTypes()
        {
            List<LocationType> obj = new List<LocationType>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLocationType", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LTypeId", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToListOfObject<LocationType>();
                    }
                    return obj;
                }
            }
        }

        public String Save(LocationModel obj)
        {
            String response = String.Empty;;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("[stLH_SaveLocation]", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_LocationId", obj.LocationId);
                        cmd.Parameters.AddWithValue("@P_LocationName", obj.LocationName);
                        cmd.Parameters.AddWithValue("@P_Supervisor", obj.Supervisor);
                        cmd.Parameters.AddWithValue("@P_ContactNumber", obj.ContactNumber);
                        cmd.Parameters.AddWithValue("@P_ManageSPoints", obj.ManageSPoints);
                        cmd.Parameters.AddWithValue("@P_ManageBilling", obj.ManageBilling);
                        cmd.Parameters.AddWithValue("@P_ManageCash", obj.ManageCash);
                        cmd.Parameters.AddWithValue("@P_ManageCredit", obj.ManageCredit);
                        cmd.Parameters.AddWithValue("@P_ManageIPCredit", obj.ManageIPCredit);
                        cmd.Parameters.AddWithValue("@P_LTypeId", obj.LTypeId);
                        cmd.Parameters.AddWithValue("@P_Active", obj.Active);
                        cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);
                        cmd.Parameters.AddWithValue("@P_RepHeadImg", obj.RepHeadImg);
                        cmd.Parameters.AddWithValue("@P_HospitalId", obj.HospitalId);
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
    }
}
