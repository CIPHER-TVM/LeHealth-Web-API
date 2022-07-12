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
   public class AgentManager :IAgentManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public AgentManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public string Save(AgentModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_SaveAgent]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_AgentId",Convert.ToInt32( obj.AgentId));
                    cmd.Parameters.AddWithValue("@P_AgentName", obj.AgentName);
                    cmd.Parameters.AddWithValue("@P_Address1", obj.Address1);
                    cmd.Parameters.AddWithValue("@P_Address2", obj.Address2);
                    cmd.Parameters.AddWithValue("@P_Street", obj.Street);
                    cmd.Parameters.AddWithValue("@P_PlacePO", obj.PlacePo);
                    cmd.Parameters.AddWithValue("@P_PIN", obj.Pin);
                    cmd.Parameters.AddWithValue("@P_City", obj.city);
                    cmd.Parameters.AddWithValue("@P_State", obj.State);
                    cmd.Parameters.AddWithValue("@P_CountryId", Convert.ToInt32(obj.CountryId));
                    cmd.Parameters.AddWithValue("@P_Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("@P_Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@P_Email", obj.Email);
                    cmd.Parameters.AddWithValue("@P_Fax", obj.Fax);
                    cmd.Parameters.AddWithValue("@P_ContactPerson", obj.ContactPerson);
                    cmd.Parameters.AddWithValue("@P_Remarks", obj.Remarks);

                    //cmd.Parameters.AddWithValue("@P_Active", Convert.ToInt32(obj.Active));
                    //cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);

                    cmd.Parameters.AddWithValue("@P_DhaId", obj.DhaNo);
                    cmd.Parameters.AddWithValue("@P_PayerId", obj.PayerId);
                    cmd.Parameters.AddWithValue("@P_HospitalId", Convert.ToInt32(obj.HospitalId));
                    cmd.Parameters.AddWithValue("@IsDisplayed", Convert.ToInt32(obj.IsDisplayed));
                    cmd.Parameters.AddWithValue("@IsDeleted", Convert.ToInt32(0));
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

        public List<AgentModel> GetAgents(Int32 hospitalId)
        {
            List<AgentModel> obj = new List<AgentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAgent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentId", 0);
            cmd.Parameters.AddWithValue("@HospitalId", hospitalId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<AgentModel>();
            }
            return obj;
        }

        public AgentModel GetAgentById(Int32 agentid)
        {
            AgentModel obj = new AgentModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAgentByid", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Agentid", agentid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToObject<AgentModel>();
            }
            return obj;
        }

        public AgentSponsorModel GetAgentForSponsor(Int32 sponsorid)
        {
            AgentSponsorModel obj = new AgentSponsorModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAgentForSponsor", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", sponsorid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToObject<AgentSponsorModel>();
            }
            return obj;
        }
    }
}
