using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LeHealth.Common;
using System.Globalization;

namespace LeHealth.Core.DataManager
{
    public class RegistrationManager : IRegistrationManager
    {
        private readonly string _connStr;
        public RegistrationManager(IConfiguration _configuration)
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
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            ProffessionModel obj = new ProffessionModel();
                            obj.ProfId = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["ProfId"]);
                            obj.ProfName = dsCompany.Tables[0].Rows[i]["ProfName"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }

        public List<RateGroupModel> GetRateGroup(int rgroup)
        {
            List<RateGroupModel> rateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetRateGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", rgroup);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsRate = new DataSet();
                    adapter.Fill(dsRate);
                    con.Close();
                    if ((dsRate != null) && (dsRate.Tables.Count > 0) && (dsRate.Tables[0] != null) && (dsRate.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsRate.Tables[0].Rows.Count; i++)
                        {
                            RateGroupModel obj = new RateGroupModel();
                            obj.RGroupId = Convert.ToInt32(dsRate.Tables[0].Rows[i]["RGroupId"]);
                            obj.RGroupName = dsRate.Tables[0].Rows[i]["RGroupName"].ToString();
                            obj.Description = dsRate.Tables[0].Rows[i]["Description"].ToString();
                            obj.Active = Convert.ToInt32(dsRate.Tables[0].Rows[i]["Active"]);
                            rateList.Add(obj);
                        }
                    }
                    return rateList;
                }
            }
        }

        public List<AllPatientModel> GetAllPatient()
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetPatientList", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();
                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                        patientList = dsPatientList.Tables[0].ToListOfObject<AllPatientModel>();
                    return patientList;
                }
            }
        }
    }
}
