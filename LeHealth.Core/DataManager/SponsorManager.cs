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
    public class SponsorManager :ISponsorManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public SponsorManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public SponserConsentModelAll GetSponserConsentById(Int32 ContentId)
        {
            SponserConsentModelAll obj = new SponserConsentModelAll();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", ContentId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
           
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToObject<SponserConsentModelAll>();
            }
            return obj;
        }


        public List<SponserConsentModel> GetSponsorConsent(Int32 Branchid)
        {
            List<SponserConsentModel> obj = new List<SponserConsentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", 0);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponserConsentModel>();
            }
            return obj;
        }
        public List<SponsorTypeModel> GetSponsorTypes()
        {
            List<SponsorTypeModel> obj = new List<SponsorTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorType", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STypeId", 0);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorTypeModel>();
            }
            return obj;
        }

        public List<SponsorFormModel> GetSponsorForms()
        {
            List<SponsorFormModel> obj = new List<SponsorFormModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorSForm", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", 0);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorFormModel>();
            }
            return obj;
        }

        public string InsertUpdateSponsor(SponsorMasterModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_InsertUpdateSponsor]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", Convert.ToInt32(obj.SponsorId));
                    cmd.Parameters.AddWithValue("@SponsorName", obj.SponsorName);
                    cmd.Parameters.AddWithValue("@SponsorType", obj.SponsorType);
                    cmd.Parameters.AddWithValue("@Address1", obj.Address1);
                    cmd.Parameters.AddWithValue("@Address2", obj.Address2);
                    cmd.Parameters.AddWithValue("@Street", obj.Street);
                    cmd.Parameters.AddWithValue("@PlacePO", obj.PlacePO);
                    cmd.Parameters.AddWithValue("@PIN", obj.PIN);
                    cmd.Parameters.AddWithValue("@City", obj.City);
                    cmd.Parameters.AddWithValue("@State", obj.State);
                    cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
                    cmd.Parameters.AddWithValue("@Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);

                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Fax", obj.Fax);
                    cmd.Parameters.AddWithValue("@ContactPerson", obj.ContactPerson);
                    cmd.Parameters.AddWithValue("@DedAmount", obj.DedAmount);
                    cmd.Parameters.AddWithValue("@CoPayPcnt", obj.CoPayPcnt);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
                    cmd.Parameters.AddWithValue("@UnclaimedId", obj.UnclaimedId);
                    cmd.Parameters.AddWithValue("@SFormId", obj.SFormId);
                    cmd.Parameters.AddWithValue("@SponsorLimit", obj.SponsorLimit);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@DHANo", obj.DHANo);
                    cmd.Parameters.AddWithValue("@EnableLimit", obj.EnableSponsorLimit);
                    cmd.Parameters.AddWithValue("@EnableConsent", obj.EnableSponsorConsent);
                    cmd.Parameters.AddWithValue("@AuthorizationMode", obj.AuthorizationMode);
                    cmd.Parameters.AddWithValue("@URL", obj.URL);
                    cmd.Parameters.AddWithValue("@SortOrder", obj.SortOrder);

                    //cmd.Parameters.AddWithValue("@P_Active", Convert.ToInt32(obj.Active));
                    //cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);
                                      
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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

        public string DeleteAgentSponsor(SponsorModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_DeleteAgentSponsor]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", Convert.ToInt32(obj.SponsorId));

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

       
       public string InsertAgentSponsor(SponsorModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_InsertAgentSponsor]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgentId", Convert.ToInt32(obj.AgentId));
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    
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

       
        public List<SponsorMasterModelAll> GetAllSponsors(Int32 Branchid)
        {
            List<SponsorMasterModelAll> obj = new List<SponsorMasterModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sponsorid", 0);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorMasterModelAll>();
            }
            return obj;
        }

        

        public string InsertUpdateSponsorConsent(SponserConsentModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorConsent", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId",obj.ContentId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
                    //cmd.Parameters.AddWithValue("@EnglishTxt", obj.CTEnglish);
                    //cmd.Parameters.AddWithValue("@ArabicTxt", obj.CTArabic);
                    cmd.Parameters.AddWithValue("@EnglishTxt", obj.CTEnglish);
                    cmd.Parameters.AddWithValue("@ArabicTxt", obj.CTArabic);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                    
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



    }
}
