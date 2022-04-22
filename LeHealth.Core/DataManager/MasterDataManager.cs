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
    public class MasterDataManager : IMasterDataManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        //ProfessionManagement Starts
        /// <summary>
        /// Get proffession list. if profid is zero then returns all professions. if profid is not zero then 
        /// returns specific profession details
        /// </summary>
        /// <param name="profid"></param>
        /// <returns>Profession details list</returns>
        public List<ProfessionModel> GetProfession(Int32 profid)
        {
            List<ProfessionModel> profList = new List<ProfessionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetProfession", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProfId", profid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    ProfessionModel obj = new ProfessionModel
                    {
                        ProfId = Convert.ToInt32(dtProfession.Rows[i]["ProfId"]),
                        ProfName = dtProfession.Rows[i]["ProfName"].ToString(),
                        ProfGroup = Convert.ToInt32(dtProfession.Rows[i]["ProfGroup"]),
                        Active = Convert.ToInt32(dtProfession.Rows[i]["IsActive"]),
                        BlockReason = dtProfession.Rows[i]["BlockReason"].ToString()
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        /// <summary>
        /// Save and updating profession data. if profession.ProfId is zero then saving the proffession details,
        /// else updates specific proffession
        /// </summary>
        /// <param name="profession"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateProfession(ProfessionModel profession)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateProfession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfId", profession.ProfId);
                cmd.Parameters.AddWithValue("@ProfName", profession.ProfName);
                cmd.Parameters.AddWithValue("@UserId", profession.UserId);
                cmd.Parameters.AddWithValue("@ProfGroup", profession.ProfGroup);
                cmd.Parameters.AddWithValue("@Active", profession.Active);
                cmd.Parameters.AddWithValue("@BlockReason", profession.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }

        //ProfessionManagement Endt
        /// <summary>
        /// Save and update MenuGroupMap. 
        /// </summary>
        /// <param name="mgm"></param>
        /// <returns>Success or reason to failure</returns>
        public string InsertUpdateMenuGroupMap(MenuGroupModel mgm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMenuGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int listcount = mgm.MenuIds.Count;
                string MenuIds = "";
                if (listcount > 0)
                    MenuIds = string.Join(",", mgm.MenuIds.ToArray());
                cmd.Parameters.AddWithValue("@GroupId", mgm.GroupId);
                cmd.Parameters.AddWithValue("@MenuIds", MenuIds);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }

        //SponsorManagement Starts
        /// <summary>
        /// Get sponsor list. if sponsorid is zero then returns all sponsor details. else returns specific sponsor id details
        /// </summary>
        /// <param name="sponsorid"></param>
        /// <returns></returns>
        public List<SponsorMasterModel> GetSponsor(Int32 sponsorid)
        {
            List<SponsorMasterModel> profList = new List<SponsorMasterModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", sponsorid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    SponsorMasterModel obj = new SponsorMasterModel
                    {
                        SponsorId = Convert.ToInt32(dtProfession.Rows[i]["SponsorId"]),
                        SponsorName = dtProfession.Rows[i]["SponsorName"].ToString(),
                        SponsorType = Convert.ToInt32(dtProfession.Rows[i]["SponsorType"]),
                        Address1 = dtProfession.Rows[i]["Address1"].ToString(),
                        Address2 = dtProfession.Rows[i]["Address2"].ToString(),
                        Street = dtProfession.Rows[i]["Street"].ToString(),
                        PlacePO = dtProfession.Rows[i]["PlacePO"].ToString(),
                        PIN = dtProfession.Rows[i]["PIN"].ToString(),
                        City = dtProfession.Rows[i]["City"].ToString(),
                        State = dtProfession.Rows[i]["State"].ToString(),
                        CountryId = Convert.ToInt32(dtProfession.Rows[i]["CountryId"]),
                        Phone = dtProfession.Rows[i]["Phone"].ToString(),
                        Mobile = dtProfession.Rows[i]["Mobile"].ToString(),
                        Email = dtProfession.Rows[i]["Email"].ToString(),
                        Fax = dtProfession.Rows[i]["Fax"].ToString(),
                        ContactPerson = dtProfession.Rows[i]["ContactPerson"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dtProfession.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dtProfession.Rows[i]["CoPayPcnt"].ToString()),
                        Remarks = dtProfession.Rows[i]["Remarks"].ToString(),
                        SFormId = Convert.ToInt32(dtProfession.Rows[i]["SFormId"]),
                        Active = Convert.ToInt32(dtProfession.Rows[i]["Active"]),
                        BlockReason = dtProfession.Rows[i]["BlockReason"].ToString(),
                        SponsorLimit = (float)Convert.ToDouble(dtProfession.Rows[i]["SponsorLimit"].ToString()),
                        DHANo = dtProfession.Rows[i]["DHANo"].ToString(),
                        EnableSponsorLimit = Convert.ToInt32(dtProfession.Rows[i]["EnableSponsorLimit"]),
                        EnableSponsorConsent = Convert.ToInt32(dtProfession.Rows[i]["EnableSponsorConsent"]),
                        AuthorizationMode = dtProfession.Rows[i]["AuthorizationMode"].ToString(),
                        URL = dtProfession.Rows[i]["URL"].ToString(),
                        SortOrder = Convert.ToInt32(dtProfession.Rows[i]["SortOrder"]),
                        PartyId = Convert.ToInt32(dtProfession.Rows[i]["PartyId"]),
                        UnclaimedId = Convert.ToInt32(dtProfession.Rows[i]["UnclaimedId"])
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        /// <summary>
        /// insert update sponsor details if SponsorId is zero then inserting the data else updating the data of id
        /// </summary>
        /// <param name="sponsor"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateSponsor(SponsorMasterModel sponsor)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SponsorId", sponsor.SponsorId);
                cmd.Parameters.AddWithValue("@SponsorName", sponsor.SponsorName);
                cmd.Parameters.AddWithValue("@SponsorType", sponsor.SponsorType);
                cmd.Parameters.AddWithValue("@Address1", sponsor.Address1);
                cmd.Parameters.AddWithValue("@Address2", sponsor.Address2);
                cmd.Parameters.AddWithValue("@Street", sponsor.Street);
                cmd.Parameters.AddWithValue("@PlacePO", sponsor.PlacePO);
                cmd.Parameters.AddWithValue("@PIN", sponsor.PIN);
                cmd.Parameters.AddWithValue("@City", sponsor.City);
                cmd.Parameters.AddWithValue("@State", sponsor.State);
                cmd.Parameters.AddWithValue("@CountryId", sponsor.CountryId);
                cmd.Parameters.AddWithValue("@Phone", sponsor.Phone);
                cmd.Parameters.AddWithValue("@Mobile", sponsor.Mobile);
                cmd.Parameters.AddWithValue("@Email", sponsor.Email);
                cmd.Parameters.AddWithValue("@Fax", sponsor.Fax);
                cmd.Parameters.AddWithValue("@ContactPerson", sponsor.ContactPerson);
                cmd.Parameters.AddWithValue("@DedAmount", sponsor.DedAmount);
                cmd.Parameters.AddWithValue("@CoPayPcnt", sponsor.CoPayPcnt);
                cmd.Parameters.AddWithValue("@Remarks", sponsor.Remarks);
                cmd.Parameters.AddWithValue("@PartyId", sponsor.PartyId);
                cmd.Parameters.AddWithValue("@UnclaimedId", sponsor.UnclaimedId);
                cmd.Parameters.AddWithValue("@SFormId", sponsor.SFormId);
                cmd.Parameters.AddWithValue("@SponsorLimit", sponsor.SponsorLimit);
                cmd.Parameters.AddWithValue("@Active", sponsor.Active);
                cmd.Parameters.AddWithValue("@BlockReason", sponsor.BlockReason);
                cmd.Parameters.AddWithValue("@DHANo", sponsor.DHANo);
                cmd.Parameters.AddWithValue("@EnableLimit", sponsor.EnableSponsorLimit);
                cmd.Parameters.AddWithValue("@EnableConsent", sponsor.EnableSponsorConsent);
                cmd.Parameters.AddWithValue("@AuthorizationMode", sponsor.AuthorizationMode);
                cmd.Parameters.AddWithValue("@URL", sponsor.URL);
                cmd.Parameters.AddWithValue("@SortOrder", sponsor.SortOrder);
                cmd.Parameters.AddWithValue("@UserId", sponsor.UserId);


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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //SponsorManagement Endt

        //SponsorType Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<SponsorTypeModel> GetSponsorType(Int32 typeid)
        {
            List<SponsorTypeModel> stypeList = new List<SponsorTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STypeId", typeid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    SponsorTypeModel obj = new SponsorTypeModel
                    {
                        STypeId = Convert.ToInt32(dtProfession.Rows[i]["STypeId"]),
                        STypeDesc = dtProfession.Rows[i]["STypeDesc"].ToString(),
                        Active = Convert.ToInt32(dtProfession.Rows[i]["Active"]),
                        BlockReason = dtProfession.Rows[i]["BlockReason"].ToString()
                    };
                    stypeList.Add(obj);
                }
            }
            return stypeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stype"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@STypeId", stype.STypeId);
                cmd.Parameters.AddWithValue("@STypeDesc", stype.STypeDesc);
                cmd.Parameters.AddWithValue("@Active", stype.Active);
                cmd.Parameters.AddWithValue("@BlockReason", stype.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }

        //SponsorType Ends

        //SponsorForm Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formid"></param>
        /// <returns></returns>
        public List<SponsorFormModel> GetSponsorForm(Int32 formid)
        {
            List<SponsorFormModel> sformList = new List<SponsorFormModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorForms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SFormId", formid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    SponsorFormModel obj = new SponsorFormModel
                    {
                        SFormId = Convert.ToInt32(dsProfession.Rows[i]["SFormId"]),
                        SFormName = dsProfession.Rows[i]["SFormName"].ToString(),
                        Active = Convert.ToInt32(dsProfession.Rows[i]["Active"]),
                        BlockReason = dsProfession.Rows[i]["SFormName"].ToString()
                    };
                    sformList.Add(obj);
                }
            }
            return sformList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sform"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorForm(SponsorFormModel sform)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SFormId", sform.SFormId);
                cmd.Parameters.AddWithValue("@SFormName", sform.SFormName);
                cmd.Parameters.AddWithValue("@Active", sform.Active);
                cmd.Parameters.AddWithValue("@BlockReason", sform.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //SponsorForm Ends

        //Consent Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientid"></param>
        /// <returns></returns>
        public List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 patientid)
        {
            List<ConsentPreviewModel> consentpreviewList = new List<ConsentPreviewModel>();
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            string patientname = string.Empty;
            string fileloc = string.Empty;
            using SqlConnection con = new SqlConnection(_connStr);

            using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", 0);
                cmd.Parameters.AddWithValue("@ConsentType", 1);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();

                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    for (Int32 j = 0; j < dsPatientList.Rows.Count; j++)
                    {
                        ConsentContentModel obj4 = new ConsentContentModel();
                        obj4.ContentId = Convert.ToInt32(dsPatientList.Rows[j]["ContentId"]);
                        obj4.CTEnglish = dsPatientList.Rows[j]["CTEnglish"].ToString();
                        obj4.CTArabic = dsPatientList.Rows[j]["CTArabic"].ToString();
                        ccmlist.Add(obj4);
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("stLH_GetPatConsentDetails", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();
                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    patientname = dsPatientList.Rows[0]["PatientName"].ToString();
                    if (dsPatientList.Rows[0]["SignLocation"].ToString() != "")
                    {
                        fileloc = _uploadpath + dsPatientList.Rows[0]["SignLocation"].ToString();
                    }


                }
            }
            ConsentPreviewModel cpm = new ConsentPreviewModel();
            cpm.ConsentContentValue = ccmlist;
            cpm.PatientName = patientname;
            cpm.FileLoc = fileloc;
            consentpreviewList.Add(cpm);
            return consentpreviewList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consentid"></param>
        /// <returns></returns>
        public List<ConsentContentModel> GetConsent(Int32 consentid)
        {
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", consentid);
                cmd.Parameters.AddWithValue("@ConsentType", 0);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();

                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    for (Int32 j = 0; j < dsPatientList.Rows.Count; j++)
                    {
                        ConsentContentModel obj = new ConsentContentModel
                        {
                            ContentId = Convert.ToInt32(dsPatientList.Rows[j]["ContentId"]),
                            CTEnglish = dsPatientList.Rows[j]["CTEnglish"].ToString(),
                            CTArabic = dsPatientList.Rows[j]["CTArabic"].ToString(),
                            DisplayOrder = Convert.ToInt32(dsPatientList.Rows[j]["DisplayOrder"]),
                            CType = Convert.ToInt32(dsPatientList.Rows[j]["CType"]),
                            Active = Convert.ToInt32(dsPatientList.Rows[j]["Active"]),
                            BlockReason = dsPatientList.Rows[j]["BlockReason"].ToString()
                        };
                        ccmlist.Add(obj);
                    }
                }
            }
            return ccmlist;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consent"></param>
        /// <returns></returns>
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", consent.ContentId);
                cmd.Parameters.AddWithValue("@DisplayOrder", consent.DisplayOrder);
                cmd.Parameters.AddWithValue("@EnglishTxt", consent.CTEnglish);
                cmd.Parameters.AddWithValue("@ArabicTxt", consent.CTArabic);
                cmd.Parameters.AddWithValue("@CType", consent.CType);
                cmd.Parameters.AddWithValue("@Active", consent.Active);
                cmd.Parameters.AddWithValue("@BlockReason", consent.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Consent Management Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryDetails"></param>
        /// <returns></returns>
        public List<CountryModel> GetCountry(Int32 countryDetails)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCountry", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", countryDetails);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dscontryList = new DataTable();
            adapter.Fill(dscontryList);
            con.Close();
            if ((dscontryList != null) && (dscontryList.Rows.Count > 0))
                countryList = dscontryList.ToListOfObject<CountryModel>();
            return countryList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string InsertUpdateCountry(CountryModel country)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
                cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                cmd.Parameters.AddWithValue("@NGroupId", country.NGroupId);
                cmd.Parameters.AddWithValue("@NationalityName", country.NationalityName);
                cmd.Parameters.AddWithValue("@Active", country.Active);
                cmd.Parameters.AddWithValue("@BlockReason", country.BlockReason);
                cmd.Parameters.AddWithValue("@UserId", country.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Country Management Ends
        //State Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public List<StateModel> GetState(Int32 stateId)
        {
            List<StateModel> countryList = new List<StateModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetState", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", stateId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
                countryList = dtStateList.ToListOfObject<StateModel>();
            return countryList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string InsertUpdateState(StateModel state)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", state.StateId);
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
                cmd.Parameters.AddWithValue("@Active", state.Active);
                cmd.Parameters.AddWithValue("@BlockReason", state.BlockReason);
                cmd.Parameters.AddWithValue("@UserId", state.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //State Management Ends

        //Salutation Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutationDetails"></param>
        /// <returns></returns>
        public List<SalutationModel> GetSalutation(Int32 salutationDetails)
        {
            List<SalutationModel> countryList = new List<SalutationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSalutation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SalutationId", salutationDetails);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtsalutationList = new DataTable();
            adapter.Fill(dtsalutationList);
            con.Close();
            if ((dtsalutationList != null) && (dtsalutationList.Rows.Count > 0))
                countryList = dtsalutationList.ToListOfObject<SalutationModel>();
            return countryList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutation"></param>
        /// <returns></returns>
        public string InsertUpdateSalutation(SalutationModel salutation)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSalutation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalutationId", salutation.Id);
                cmd.Parameters.AddWithValue("@Salutation", salutation.Salutation);
                cmd.Parameters.AddWithValue("@UserId", salutation.UserId);
                cmd.Parameters.AddWithValue("@Active", salutation.Active);
                cmd.Parameters.AddWithValue("@BlockReason", salutation.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Salutation Management Ends
        //BodyPart Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutationDetails"></param>
        /// <returns></returns>
        public List<BodyPartModel> GetBodyPart(Int32 salutationDetails)
        {
            List<BodyPartModel> countryList = new List<BodyPartModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetBodyPart", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BodyId", salutationDetails);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbodypartList = new DataTable();
            adapter.Fill(dtbodypartList);
            con.Close();
            if ((dtbodypartList != null) && (dtbodypartList.Rows.Count > 0))
                countryList = dtbodypartList.ToListOfObject<BodyPartModel>();
            return countryList;
        }
        /// <summary>
        /// Save and updating Bodypart master data,Saves when BodyId is zero. Updates when Body Id Not equal to zero
        /// </summary>
        /// <param name="bodypart"></param>
        /// <returns>success or error statement</returns>
        public string InsertUpdateBodyPart(BodyPartModel bodypart)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateBodyPart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyId", bodypart.BodyId);
                cmd.Parameters.AddWithValue("@BodyDesc", bodypart.BodyDesc);
                cmd.Parameters.AddWithValue("@UserId", bodypart.UserId);
                cmd.Parameters.AddWithValue("@Active", bodypart.Active);
                cmd.Parameters.AddWithValue("@BlockReason", bodypart.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //BodyPart Management Ends
        /// <summary>
        /// Save and updating Zone master data,Saves when Id is zero. Updates when Id Not equal to zero
        /// </summary>
        /// <param name="zone"></param>
        /// <returns>success or reason for error</returns>
        public string InsertUpdateZone(ZoneModel zone)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateZone", con);//InsertUpdateZone
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZoneId", zone.Id);
                cmd.Parameters.AddWithValue("@OperatorId", zone.OperatorId);
                cmd.Parameters.AddWithValue("@ZoneName", zone.ZoneName);
                cmd.Parameters.AddWithValue("@ZoneCode", zone.ZoneCode);
                cmd.Parameters.AddWithValue("@ZoneDescription", zone.ZoneDescription);
                cmd.Parameters.AddWithValue("@ZoneCountry", zone.ZoneCountry);
                cmd.Parameters.AddWithValue("@Active", zone.IsActive);
                cmd.Parameters.AddWithValue("@BlockReason", zone.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// if zoneId is zero then returns all zones , else returns specific zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns>Zone list</returns>
        public List<ZoneModel> GetZone(Int32 zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_ZoneById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@zoneId", zoneId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtZoneList = new DataTable();
            adapter.Fill(dtZoneList);
            con.Close();
            if ((dtZoneList != null) && (dtZoneList.Rows.Count > 0))
                zoneList = dtZoneList.ToListOfObject<ZoneModel>();
            return zoneList;
        }

        /// <summary>
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments(Int32 DeptId)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    DepartmentModel obj = new DepartmentModel
                    {
                        DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                        DeptName = dt.Rows[i]["DeptName"].ToString(),
                        DeptCode = dt.Rows[i]["DeptCode"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),
                        BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]),
                        TimeSlice = Convert.ToInt32(dt.Rows[i]["TimeSlice"]),
                        Active = Convert.ToInt32(dt.Rows[i]["Active"]),
                        BlockReason = dt.Rows[i]["BlockReason"].ToString()
                    };
                    departmentlist.Add(obj);
                }
            }
            return departmentlist;
        }
        /// <summary>
        /// Save and updating Department master data,Saves when DeptId is zero. Updates when DeptId Not equal to zero
        /// </summary>
        /// <param name="department"></param>
        /// <returns>success or reason for failure</returns>
        public string InsertUpdateDepartment(DepartmentModel department)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeptId", department.DeptId);
                cmd.Parameters.AddWithValue("@DeptName", department.DeptName);
                cmd.Parameters.AddWithValue("@DeptCode", department.DeptCode);
                cmd.Parameters.AddWithValue("@BranchId", department.BranchId);
                cmd.Parameters.AddWithValue("@Description", department.Description);
                cmd.Parameters.AddWithValue("@TimeSlice", department.TimeSlice);
                cmd.Parameters.AddWithValue("@Active", department.Active);
                cmd.Parameters.AddWithValue("@BlockReason", department.BlockReason);
                cmd.Parameters.AddWithValue("@UserId", department.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// Get Department Details By HospitalId
        /// </summary>
        /// <param name="HospId"></param>
        /// <returns>List Of Departments</returns>
        public List<DepartmentModel> GetDepartmentByHospital(Int32 HospId)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDepartmentByHospital", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalId", HospId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    DepartmentModel obj = new DepartmentModel();
                    obj.DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"]);
                    obj.DeptName = dt.Rows[i]["DeptName"].ToString();
                    obj.DeptCode = dt.Rows[i]["DeptCode"].ToString();
                    departmentlist.Add(obj);
                }
            }
            return departmentlist;
        }
        public List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel)
        {
            List<ConsultantModel> departmentlist = new List<ConsultantModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantByHospital", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@HospitalId", cmodel.BranchId);
            cmd.Parameters.AddWithValue("@IsExternal", cmodel.IsExternal);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ConsultantModel obj = new ConsultantModel();
                    obj.ConsultantId = Convert.ToInt32(dt.Rows[i]["ConsultantId"]);
                    obj.ConsultantName = dt.Rows[i]["ConsultantName"].ToString();
                    departmentlist.Add(obj);
                }
            }
            return departmentlist;
        }

        /// <summary>
        /// Save Registration scheme if itemId is zero else update the Scheme with Id
        /// </summary>
        /// <param name="RegScheme"></param>
        /// <returns></returns>
        public string InsertUpdateRegScheme(RegSchemeModel RegScheme)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRegScheme", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", RegScheme.ItemId);
                cmd.Parameters.AddWithValue("@ItemCode", RegScheme.ItemCode);
                cmd.Parameters.AddWithValue("@ItemName", RegScheme.ItemName);
                cmd.Parameters.AddWithValue("@GroupId", RegScheme.GroupId);
                cmd.Parameters.AddWithValue("@ValidityDays", RegScheme.ValidityDays);
                cmd.Parameters.AddWithValue("@ValidityVisits", RegScheme.ValidityVisits);
                cmd.Parameters.AddWithValue("@AllowRateEdit", RegScheme.AllowRateEdit);
                cmd.Parameters.AddWithValue("@AllowDisc", RegScheme.AllowDisc);
                cmd.Parameters.AddWithValue("@AllowPP", RegScheme.AllowPP);
                cmd.Parameters.AddWithValue("@IsVSign", RegScheme.IsVSign);
                cmd.Parameters.AddWithValue("@ResultOn", RegScheme.ResultOn);
                cmd.Parameters.AddWithValue("@STypeId", RegScheme.STypeId);
                cmd.Parameters.AddWithValue("@TotalTaxPcnt", RegScheme.TotalTaxPcnt);
                cmd.Parameters.AddWithValue("@AllowCommission", RegScheme.AllowCommission);
                cmd.Parameters.AddWithValue("@CommPcnt", RegScheme.CommPcnt);
                cmd.Parameters.AddWithValue("@CommAmt", RegScheme.CommAmt);
                cmd.Parameters.AddWithValue("@MaterialCost", RegScheme.MaterialCost);
                cmd.Parameters.AddWithValue("@BaseCost", RegScheme.BaseCost);
                cmd.Parameters.AddWithValue("@HeadId", RegScheme.HeadId);
                cmd.Parameters.AddWithValue("@SortOrder", RegScheme.SortOrder);
                cmd.Parameters.AddWithValue("@CPTCodeId", RegScheme.CPTCodeId);
                cmd.Parameters.AddWithValue("@ExternalItem", RegScheme.ExternalItem);
                cmd.Parameters.AddWithValue("@Active", RegScheme.Active);
                cmd.Parameters.AddWithValue("@BlockReason", RegScheme.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// Save Re
        /// </summary>
        /// <param name="RegSchemeId"></param>
        /// <returns></returns>
        public List<RegSchemeModel> GetRegScheme(Int32 RegSchemeId)
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_RegSchemeById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemId", RegSchemeId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtRegSchemeList = new DataTable();
            adapter.Fill(dtRegSchemeList);
            con.Close();
            if ((dtRegSchemeList != null) && (dtRegSchemeList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtRegSchemeList.Rows.Count; i++)
                {
                    RegSchemeModel obj = new RegSchemeModel();
                    obj.ItemId = Convert.ToInt32(dtRegSchemeList.Rows[i]["ItemId"]);
                    obj.ItemCode = dtRegSchemeList.Rows[i]["ItemCode"].ToString();
                    obj.ItemName = dtRegSchemeList.Rows[i]["ItemName"].ToString();
                    obj.GroupId = Convert.ToInt32(dtRegSchemeList.Rows[i]["GroupId"]);
                    obj.ValidityDays = Convert.ToInt32(dtRegSchemeList.Rows[i]["ValidityDays"]);
                    obj.ValidityVisits = Convert.ToInt32(dtRegSchemeList.Rows[i]["ValidityVisits"]);
                    obj.AllowRateEdit = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowRateEdit"]);
                    obj.AllowDisc = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowDisc"]);
                    obj.AllowPP = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowPP"]);
                    obj.IsVSign = Convert.ToInt32(dtRegSchemeList.Rows[i]["IsVSign"]);
                    obj.ResultOn = Convert.ToInt32(dtRegSchemeList.Rows[i]["ResultOn"]);
                    obj.STypeId = Convert.ToInt32(dtRegSchemeList.Rows[i]["STypeId"]);
                    obj.TotalTaxPcnt = Convert.ToInt32(dtRegSchemeList.Rows[i]["TotalTaxPcnt"]);
                    obj.AllowCommission = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowCommission"]);
                    obj.CommPcnt = Convert.ToInt32(dtRegSchemeList.Rows[i]["CommPcnt"]);
                    obj.CommAmt = Convert.ToInt32(dtRegSchemeList.Rows[i]["CommAmt"]);
                    obj.MaterialCost = Convert.ToInt32(dtRegSchemeList.Rows[i]["MaterialCost"]);
                    obj.BaseCost = Convert.ToInt32(dtRegSchemeList.Rows[i]["BaseCost"]);
                    obj.HeadId = Convert.ToInt32(dtRegSchemeList.Rows[i]["HeadId"]);
                    obj.SortOrder = Convert.ToInt32(dtRegSchemeList.Rows[i]["SortOrder"]);
                    obj.Active = Convert.ToInt32(dtRegSchemeList.Rows[i]["Active"]);
                    obj.BlockReason = dtRegSchemeList.Rows[i]["BlockReason"].ToString();
                    obj.CPTCodeId = Convert.ToInt32(dtRegSchemeList.Rows[i]["CPTCodeId"]);
                    obj.ExternalItem = Convert.ToInt32(dtRegSchemeList.Rows[i]["ExternalItem"]);
                    regSchemeList.Add(obj);
                }
            }
            return regSchemeList;
        }
        //Rate group Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateGroup"></param>
        /// <returns></returns>
        public string InsertUpdateRateGroup(RateGroupModel RateGroup)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRateGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                cmd.Parameters.AddWithValue("@EffectFrom", Convert.ToDateTime(RateGroup.EffectFrom));
                cmd.Parameters.AddWithValue("@EffectTo", Convert.ToDateTime(RateGroup.EffectTo));
                cmd.Parameters.AddWithValue("@UserId", RateGroup.UserId);
                cmd.Parameters.AddWithValue("@Active", RateGroup.Active);
                cmd.Parameters.AddWithValue("@BlockReason", RateGroup.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// Get Rate group data. if rategroup is zero then lists all rategroups, else returns specific rategroup
        /// </summary>
        /// <param name="RateGroupId"></param>
        /// <returns>Rategroup list</returns>
        public List<RateGroupModel> GetRateGroup(Int32 RateGroupId)
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetRateGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RGroupId", RateGroupId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtStateList.Rows.Count; i++)
                {
                    RateGroupModel obj = new RateGroupModel();
                    obj.RGroupId = Convert.ToInt32(dtStateList.Rows[i]["RGroupId"]);
                    obj.RGroupName = dtStateList.Rows[i]["RGroupName"].ToString();
                    obj.Description = dtStateList.Rows[i]["Description"].ToString();
                    obj.EffectFrom = dtStateList.Rows[i]["EffectFrom"].ToString();
                    obj.EffectTo = dtStateList.Rows[i]["EffectTo"].ToString();
                    obj.Active = Convert.ToInt32(dtStateList.Rows[i]["Active"]);
                    obj.BlockReason = dtStateList.Rows[i]["BlockReason"].ToString();
                    stateList.Add(obj);
                }
            }
            return stateList;
        }
        //Rate Group Ends
        //Hospital Starts
        /// <summary>
        /// Get Hospital list from database.Step three in code execution flow
        /// </summary>
        /// <returns></returns>

        public List<HospitalModel> GetUserHospitals(Int32 id)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsHospitalList = new DataTable();
            adapter.Fill(dsHospitalList);
            con.Close();
            if ((dsHospitalList != null) && (dsHospitalList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsHospitalList.Rows.Count; i++)
                {
                    HospitalModel obj = new HospitalModel();
                    obj.HospitalId = Convert.ToInt32(dsHospitalList.Rows[i]["HospitalId"]);
                    obj.HospitalName = dsHospitalList.Rows[i]["HospitalName"].ToString();
                    obj.HospitalCode = dsHospitalList.Rows[i]["HospitalCode"].ToString();
                    obj.Caption = dsHospitalList.Rows[i]["Caption"].ToString();
                    obj.Address1 = dsHospitalList.Rows[i]["Address1"].ToString();
                    obj.Address2 = dsHospitalList.Rows[i]["Address2"].ToString();
                    obj.Street = dsHospitalList.Rows[i]["Street"].ToString();
                    obj.PlacePO = dsHospitalList.Rows[i]["PlacePO"].ToString();
                    obj.PIN = dsHospitalList.Rows[i]["PIN"].ToString();
                    obj.City = dsHospitalList.Rows[i]["City"].ToString();
                    obj.State = Convert.ToInt32(dsHospitalList.Rows[i]["State"]);
                    obj.Country = Convert.ToInt32(dsHospitalList.Rows[i]["Country"]);
                    obj.Phone = dsHospitalList.Rows[i]["Phone"].ToString();
                    obj.Fax = dsHospitalList.Rows[i]["Fax"].ToString();
                    obj.Email = dsHospitalList.Rows[i]["Email"].ToString();
                    obj.URL = dsHospitalList.Rows[i]["URL"].ToString();
                    obj.Logo = dsHospitalList.Rows[i]["Logo"].ToString();
                    obj.ReportLogo = dsHospitalList.Rows[i]["ReportLogo"].ToString();
                    obj.ClinicId = dsHospitalList.Rows[i]["ClinicId"].ToString();
                    obj.DHAFacilityId = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.DHAUserName = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.DHAPassword = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.SR_ID = dsHospitalList.Rows[i]["SR_ID"].ToString();
                    obj.MalaffiSystemcode = dsHospitalList.Rows[i]["MalaffiSystemcode"].ToString();
                    obj.Active = Convert.ToInt32(dsHospitalList.Rows[i]["IsActive"]);
                    obj.BlockReason = dsHospitalList.Rows[i]["BlockReason"].ToString();
                    hospitalList.Add(obj);
                }
            }
            return hospitalList;

        }
        public List<HospitalModel> GetUserSpecificHospitals(int userId)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUserSpecificHospitals", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsHospitalList = new DataTable();
            adapter.Fill(dsHospitalList);
            con.Close();
            if ((dsHospitalList != null) && (dsHospitalList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsHospitalList.Rows.Count; i++)
                {
                    HospitalModel obj = new HospitalModel();
                    obj.HospitalId = Convert.ToInt32(dsHospitalList.Rows[i]["HospitalId"]);
                    obj.HospitalName = dsHospitalList.Rows[i]["HospitalName"].ToString();
                    obj.HospitalCode = dsHospitalList.Rows[i]["HospitalCode"].ToString();
                    obj.Caption = dsHospitalList.Rows[i]["Caption"].ToString();
                    obj.Address1 = dsHospitalList.Rows[i]["Address1"].ToString();
                    obj.Address2 = dsHospitalList.Rows[i]["Address2"].ToString();
                    obj.Street = dsHospitalList.Rows[i]["Street"].ToString();
                    obj.PlacePO = dsHospitalList.Rows[i]["PlacePO"].ToString();
                    obj.PIN = dsHospitalList.Rows[i]["PIN"].ToString();
                    obj.City = dsHospitalList.Rows[i]["City"].ToString();
                    obj.State = Convert.ToInt32(dsHospitalList.Rows[i]["State"]);
                    obj.Country = Convert.ToInt32(dsHospitalList.Rows[i]["Country"]);
                    obj.Phone = dsHospitalList.Rows[i]["Phone"].ToString();
                    obj.Fax = dsHospitalList.Rows[i]["Fax"].ToString();
                    obj.Email = dsHospitalList.Rows[i]["Email"].ToString();
                    obj.URL = dsHospitalList.Rows[i]["URL"].ToString();
                    obj.Logo = dsHospitalList.Rows[i]["Logo"].ToString();
                    obj.ReportLogo = dsHospitalList.Rows[i]["ReportLogo"].ToString();
                    obj.ClinicId = dsHospitalList.Rows[i]["ClinicId"].ToString();
                    obj.DHAFacilityId = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.DHAUserName = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.DHAPassword = dsHospitalList.Rows[i]["DHAFacilityId"].ToString();
                    obj.SR_ID = dsHospitalList.Rows[i]["SR_ID"].ToString();
                    obj.MalaffiSystemcode = dsHospitalList.Rows[i]["MalaffiSystemcode"].ToString();
                    obj.Active = Convert.ToInt32(dsHospitalList.Rows[i]["IsActive"]);
                    obj.BlockReason = dsHospitalList.Rows[i]["BlockReason"].ToString();
                    hospitalList.Add(obj);
                }
            }
            return hospitalList;
        }
        public List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch)
        {
            List<LocationModel> locationList = new List<LocationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("GetUserSpecificHospitalLocations", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            cmd.Parameters.AddWithValue("@P_BranchId", branch);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dslocationlistList = new DataTable();
            adapter.Fill(dslocationlistList);
            con.Close();
            if ((dslocationlistList != null) && (dslocationlistList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dslocationlistList.Rows.Count; i++)
                {
                    LocationModel obj = new LocationModel();
                    obj.LocationId = Convert.ToInt32(dslocationlistList.Rows[i]["LocationId"].ToString());
                    obj.LocationName = dslocationlistList.Rows[i]["LocationName"].ToString();
                    obj.LTypeId = Convert.ToInt32(dslocationlistList.Rows[i]["LTypeId"].ToString());
                    obj.ManageBilling = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageBilling"].ToString());
                    obj.ManageCash = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageCash"].ToString());
                    obj.ManageCredit = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageCredit"].ToString());
                    obj.ManageIPCredit = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageIPCredit"].ToString());
                    obj.ManageSPoints = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageSPoints"].ToString());
                    obj.Supervisor = dslocationlistList.Rows[i]["Supervisor"].ToString();
                    obj.RepHeadImg = dslocationlistList.Rows[i]["RepHeadImg"].ToString();

                    locationList.Add(obj);
                }
            }
            return locationList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospital"></param>
        /// <returns></returns>
        public string InsertUpdateUserHospital(HospitalRegModel hospital)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateHospital", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HospitalId", hospital.HospitalId);
                cmd.Parameters.AddWithValue("@HospitalName", hospital.HospitalName);
                cmd.Parameters.AddWithValue("@HospitalCode", hospital.HospitalCode);
                cmd.Parameters.AddWithValue("@Caption", hospital.Caption);
                cmd.Parameters.AddWithValue("@Address1", hospital.Address1);
                cmd.Parameters.AddWithValue("@Address2", hospital.Address2);
                cmd.Parameters.AddWithValue("@Street", hospital.Street);
                cmd.Parameters.AddWithValue("@PlacePO", hospital.PlacePO);
                cmd.Parameters.AddWithValue("@Pin", hospital.PIN);
                cmd.Parameters.AddWithValue("@City", hospital.City);
                cmd.Parameters.AddWithValue("@State", hospital.State);
                cmd.Parameters.AddWithValue("@Country", hospital.Country);
                cmd.Parameters.AddWithValue("@Phone", hospital.Phone);
                cmd.Parameters.AddWithValue("@Fax", hospital.Fax);
                cmd.Parameters.AddWithValue("@EMail", hospital.Email);
                cmd.Parameters.AddWithValue("@URL", hospital.URL);
                cmd.Parameters.AddWithValue("@Logo", hospital.Logo);
                cmd.Parameters.AddWithValue("@ReportLogo", hospital.ReportLogo);
                cmd.Parameters.AddWithValue("@ClinicId", hospital.ClinicId);
                cmd.Parameters.AddWithValue("@DhaFacilityId", hospital.DHAFacilityId);
                cmd.Parameters.AddWithValue("@DhaUserName", hospital.DHAUserName);
                cmd.Parameters.AddWithValue("@DhaPassword", hospital.DHAPassword);
                cmd.Parameters.AddWithValue("@UserId", hospital.UserId);
                cmd.Parameters.AddWithValue("@Active", hospital.Active);
                cmd.Parameters.AddWithValue("@BlockReason", hospital.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }

        //Hospital Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consent"></param>
        /// <returns></returns>
        public string ConsentFormDataSave(ConsentFormRegModel consent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertConsentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsentId", consent.ConsentId);
                cmd.Parameters.AddWithValue("@PatientId", consent.PatientId);
                cmd.Parameters.AddWithValue("@BranchId", consent.BranchId);
                cmd.Parameters.AddWithValue("@Sign", consent.Sign);
                //SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(retValV);
                //SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(retDesc);
                con.Open();
                var isUpdated = cmd.ExecuteNonQuery();
                //var ret = retValV.Value;
                //var descrip = retDesc.Value.ToString();
                con.Close();
                //if (descrip == "Saved Successfully")
                //{
                response = "Success";
                //}
                //else
                //{
                //    response = descrip;
                //}
            }
            return response;
        }

        //Operator Starts Now
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Operator"></param>
        /// <returns></returns>
        public string InsertUpdateOperator(OperatorModel Operator)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateOperator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Operator.Id);
                cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                cmd.Parameters.AddWithValue("@Active", Operator.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Operator.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// for getting Operator data. if operator id is zero then returns all operators. else returns specific operator data
        /// </summary>
        /// <param name="OperatorId"></param>
        /// <returns>operator list</returns>
        public List<OperatorModel> GetOperator(Int32 OperatorId)
        {
            List<OperatorModel> stateList = new List<OperatorModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetOperatorById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", OperatorId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsStateList = new DataTable();
            adapter.Fill(dsStateList);
            con.Close();
            if ((dsStateList != null) && (dsStateList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsStateList.Rows.Count; i++)
                {
                    OperatorModel obj = new OperatorModel();
                    obj.Id = Convert.ToInt32(dsStateList.Rows[i]["Id"]);
                    obj.OperatorName = dsStateList.Rows[i]["OperatorName"].ToString();
                    obj.OperatorCode = dsStateList.Rows[i]["OperatorCode"].ToString();
                    obj.Active = Convert.ToInt32(dsStateList.Rows[i]["IsActive"]);
                    obj.BlockReason = dsStateList.Rows[i]["BlockReason"].ToString();
                    stateList.Add(obj);
                }
            }
            return stateList;
        }
        //Operator Ends Now
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<LeadAgentModel> GetLeadAgent(Int32 la)
        {
            List<LeadAgentModel> itemList = new List<LeadAgentModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeadAgentId", la);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    LeadAgentModel obj = new LeadAgentModel();
                    obj.LeadAgentId = Convert.ToInt32(dsNumber.Rows[i]["LeadAgentId"]);
                    obj.Name = dsNumber.Rows[i]["Name"].ToString();
                    obj.ContactNo = dsNumber.Rows[i]["ContactNo"].ToString();
                    obj.CommisionPercent = (float)Convert.ToDouble(dsNumber.Rows[i]["CommisionPercent"].ToString());
                    obj.Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]);
                    obj.BlockReason = dsNumber.Rows[i]["BlockReason"].ToString();
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LeadAgent"></param>
        /// <returns></returns>
        public string InsertUpdateLeadAgent(LeadAgentModel LeadAgent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLeadAgent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeadAgentID", LeadAgent.LeadAgentId);
                cmd.Parameters.AddWithValue("@Name", LeadAgent.Name);
                cmd.Parameters.AddWithValue("@ContactNo", LeadAgent.ContactNo);
                cmd.Parameters.AddWithValue("@CommisionPercent", LeadAgent.CommisionPercent);
                cmd.Parameters.AddWithValue("@Active", LeadAgent.Active);
                cmd.Parameters.AddWithValue("@BlockReason", LeadAgent.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }

        //Company Management Starts
        /// <summary>
        /// Get details of companies. if Id is zero then returns all company data. else returns Data of specific company
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<CompanyModel> GetCompany(Int32 Id)
        {
            List<CompanyModel> companyList = new List<CompanyModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCompany", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CmpId", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsCompany = new DataTable();
            adapter.Fill(dsCompany);
            con.Close();
            if ((dsCompany != null) && (dsCompany.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsCompany.Rows.Count; i++)
                {
                    CompanyModel obj = new CompanyModel();
                    obj.CmpId = Convert.ToInt32(dsCompany.Rows[i]["CmpId"]);
                    obj.CmpName = dsCompany.Rows[i]["CmpName"].ToString();
                    obj.Active = Convert.ToInt32(dsCompany.Rows[i]["Active"]);
                    obj.BlockReason = dsCompany.Rows[i]["BlockReason"].ToString();
                    companyList.Add(obj);
                }
            }
            return companyList;
        }
        /// <summary>
        /// Save Comapny data if cmpid is zero. else updating specific company
        /// </summary>
        /// <param name="Company"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateCompany(CompanyModel Company)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CmpId", Company.CmpId);
                cmd.Parameters.AddWithValue("@CmpName", Company.CmpName);
                cmd.Parameters.AddWithValue("@UserId", Company.UserId);
                cmd.Parameters.AddWithValue("@Active", Company.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Company.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Company saved")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Company Management Ends

        //City Starts
        /// <summary>
        /// Get city details. returns all city data if cityid is zero else returns specific city data
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns>city data list</returns>
        public List<CityModel> GetCity(Int32 cityid)
        {
            List<CityModel> cityList = new List<CityModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCity", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", cityid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    CityModel obj = new CityModel();
                    obj.CityId = Convert.ToInt32(dsProfession.Rows[i]["CityId"]);
                    obj.CityName = dsProfession.Rows[i]["CityName"].ToString();
                    obj.StateId = Convert.ToInt32(dsProfession.Rows[i]["StateId"]);
                    obj.CountryId = Convert.ToInt32(dsProfession.Rows[i]["CountryId"]);
                    obj.CountryName = dsProfession.Rows[i]["CountryName"].ToString();
                    cityList.Add(obj);
                }
            }
            return cityList;
        }
        /// <summary>
        /// Save city data if cityid is zero. else updating specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public string InsertUpdateCity(CityModel city)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityId", city.CityId);
                cmd.Parameters.AddWithValue("@CityName", city.CityName);
                cmd.Parameters.AddWithValue("@CountryId", city.CountryId);
                cmd.Parameters.AddWithValue("@StateId", city.StateId);
                cmd.Parameters.AddWithValue("@UserId", city.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //City Ends
        //Symptom Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Symptom"></param>
        /// <returns></returns>
        public string InsertUpdateSymptom(SymptomModel Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSymptom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SymptomId", Symptom.SymptomId);
                cmd.Parameters.AddWithValue("@SymptomDesc", Symptom.SymptomDesc);
                cmd.Parameters.AddWithValue("@UserId", Symptom.UserId);
                cmd.Parameters.AddWithValue("@Active", Symptom.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Symptom.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SymptomModel> GetActiveSymptoms()
        {
            List<SymptomModel> stateList = new List<SymptomModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetActiveSymptoms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsSymptomList = new DataTable();
            adapter.Fill(dsSymptomList);
            con.Close();
            if ((dsSymptomList != null) && (dsSymptomList.Rows.Count > 0))
                stateList = dsSymptomList.ToListOfObject<SymptomModel>();
            return stateList;
        }
        //Symptom Ends

        //VitalSign Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vitalsign"></param>
        /// <returns></returns>
        public string InsertUpdateVitalSign(VitalSignModel vitalsign)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateVitalSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", vitalsign.SignId);
                cmd.Parameters.AddWithValue("@SignName", vitalsign.SignName);
                cmd.Parameters.AddWithValue("@Mandatory", vitalsign.Mandatory);
                cmd.Parameters.AddWithValue("@SignCode", vitalsign.SignCode);
                cmd.Parameters.AddWithValue("@SignUnit", vitalsign.SignUnit);
                cmd.Parameters.AddWithValue("@MinValue", vitalsign.MinValue);
                cmd.Parameters.AddWithValue("@MaxValue", vitalsign.MaxValue);
                cmd.Parameters.AddWithValue("@SortOrder", vitalsign.SortOrder);
                cmd.Parameters.AddWithValue("@UserId", vitalsign.UserId);
                cmd.Parameters.AddWithValue("@Active", vitalsign.Active);
                cmd.Parameters.AddWithValue("@BlockReason", vitalsign.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<VitalSignModel> GetVitalSign(Int32 Id)
        {
            List<VitalSignModel> vitalSignList = new List<VitalSignModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVitalSign", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SignId", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsVitalSignList = new DataTable();
            adapter.Fill(dsVitalSignList);
            con.Close();
            if ((dsVitalSignList != null) && (dsVitalSignList.Rows.Count > 0))
                vitalSignList = dsVitalSignList.ToListOfObject<VitalSignModel>();
            return vitalSignList;
        }
        //VitalSign Ends
        //Movement Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        public string InsertUpdateMovement(MovementModel movement)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMovement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovementId", movement.MovementId);
                cmd.Parameters.AddWithValue("@MovementDesc", movement.MovementDesc);
                cmd.Parameters.AddWithValue("@Active", movement.Active);
                cmd.Parameters.AddWithValue("@BlockReason", movement.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<MovementModel> GetMovement(Int32 Id)
        {
            List<MovementModel> vitalSignList = new List<MovementModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMovementDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MovementId", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsMovementList = new DataTable();
            adapter.Fill(dsMovementList);
            con.Close();
            if ((dsMovementList != null) && (dsMovementList.Rows.Count > 0))
                vitalSignList = dsMovementList.ToListOfObject<MovementModel>();
            return vitalSignList;
        }
        //Movement Ends
        //Package Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<PackageModel> GetPackage(PackageModel pm)
        {
            List<PackageModel> itemList = new List<PackageModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPackage", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PackId", pm.PackId);
            cmd.Parameters.AddWithValue("@BranchId", pm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    PackageModel obj = new PackageModel();
                    obj.PackId = Convert.ToInt32(dsNumber.Rows[i]["PackId"]);
                    obj.PackDesc = dsNumber.Rows[i]["PackDesc"].ToString();
                    obj.EffectFrom = dsNumber.Rows[i]["EffectFrom"].ToString();
                    obj.EffectTo = dsNumber.Rows[i]["EffectTo"].ToString();
                    obj.PackAmount = (float)Convert.ToDouble(dsNumber.Rows[i]["PackAmount"].ToString());
                    obj.Remarks = dsNumber.Rows[i]["Remarks"].ToString();
                    obj.Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]);
                    obj.BlockReason = dsNumber.Rows[i]["BlockReason"].ToString();
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdatePackage(PackageModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePackage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PackId", Package.PackId);
                cmd.Parameters.AddWithValue("@PackDesc", Package.PackDesc);
                cmd.Parameters.AddWithValue("@EffectFrom", Package.EffectFrom);
                cmd.Parameters.AddWithValue("@EffectTo", Package.EffectTo);
                cmd.Parameters.AddWithValue("@PackAmount", Package.PackAmount);
                cmd.Parameters.AddWithValue("@Remarks", Package.Remarks);
                cmd.Parameters.AddWithValue("@Active", Package.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Package.BlockReason);
                cmd.Parameters.AddWithValue("@UserId", Package.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Package Ends

        //Location Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<LocationModel> GetLocation(Int32 la)
        {
            List<LocationModel> itemList = new List<LocationModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLocation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationId", la);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    LocationModel obj = new LocationModel();
                    obj.LocationId = Convert.ToInt32(dsNumber.Rows[i]["LocationId"]);
                    obj.LocationName = dsNumber.Rows[i]["LocationName"].ToString();
                    obj.Supervisor = dsNumber.Rows[i]["Supervisor"].ToString();
                    obj.ContactNumber = dsNumber.Rows[i]["ContactNumber"].ToString();
                    obj.LTypeId = Convert.ToInt32(dsNumber.Rows[i]["LTypeId"]);
                    obj.ManageSPoints = Convert.ToBoolean(dsNumber.Rows[i]["ManageSPoints"]);
                    obj.ManageBilling = Convert.ToBoolean(dsNumber.Rows[i]["ManageBilling"]);
                    obj.ManageCash = Convert.ToBoolean(dsNumber.Rows[i]["ManageCash"]);
                    obj.ManageCredit = Convert.ToBoolean(dsNumber.Rows[i]["ManageCredit"]);
                    obj.ManageIPCredit = Convert.ToBoolean(dsNumber.Rows[i]["ManageIPCredit"]);
                    obj.Active = Convert.ToBoolean(dsNumber.Rows[i]["Active"]);
                    obj.BlockReason = dsNumber.Rows[i]["BlockReason"].ToString();
                    obj.RepHeadImg = dsNumber.Rows[i]["RepHeadImg"].ToString();
                    obj.HospitalId = Convert.ToInt32(dsNumber.Rows[i]["HospitalId"]);
                    obj.HospitalName = dsNumber.Rows[i]["HospitalName"].ToString();
                    //obj.PackAmount = (float)Convert.ToDouble(dsNumber.Rows[i]["PackAmount"].ToString());
                    obj.Active = Convert.ToBoolean(dsNumber.Rows[i]["Active"]);
                    obj.BlockReason = dsNumber.Rows[i]["BlockReason"].ToString();
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateLocation(LocationModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", Package.LocationId);
                cmd.Parameters.AddWithValue("@LocationName", Package.LocationName);
                cmd.Parameters.AddWithValue("@Supervisor", Package.Supervisor);
                cmd.Parameters.AddWithValue("@ContactNumber", Package.ContactNumber);
                cmd.Parameters.AddWithValue("@LTypeId", Package.LTypeId);
                cmd.Parameters.AddWithValue("@ManageSPoints", Package.ManageSPoints);
                cmd.Parameters.AddWithValue("@ManageBilling", Package.ManageBilling);
                cmd.Parameters.AddWithValue("@ManageCash", Package.ManageCash);
                cmd.Parameters.AddWithValue("@ManageCredit", Package.ManageCredit);
                cmd.Parameters.AddWithValue("@ManageIPCredit", Package.ManageIPCredit);
                cmd.Parameters.AddWithValue("@Active", Package.Active);
                cmd.Parameters.AddWithValue("@RepHeadImg", Package.RepHeadImg);                    //
                                                                                                   //cmd.Parameters.AddWithValue("@BlockReason", Package.BlockReason);
                cmd.Parameters.AddWithValue("@UserId", Package.UserId);
                cmd.Parameters.AddWithValue("@HospitalId", Package.HospitalId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Location Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel dm)
        {
            List<ConsultantDrugModel> drugList = new List<ConsultantDrugModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrug", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugId", dm.DrugId);
            cmd.Parameters.AddWithValue("@DrugTypeId", dm.DrugTypeId);
            cmd.Parameters.AddWithValue("@BranchId", dm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsDrug = new DataTable();
            adapter.Fill(dsDrug);
            con.Close();
            if ((dsDrug != null) && (dsDrug.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsDrug.Rows.Count; i++)
                {
                    ConsultantDrugModel obj = new ConsultantDrugModel();
                    obj.DrugId = Convert.ToInt32(dsDrug.Rows[i]["DrugId"]);
                    obj.DrugName = dsDrug.Rows[i]["DrugName"].ToString();
                    obj.Dosage = dsDrug.Rows[i]["DOSAGE_FORM_PACKAGE"].ToString();
                    obj.RouteId = Convert.ToInt32(dsDrug.Rows[i]["RouteId"]);
                    obj.RouteDesc = dsDrug.Rows[i]["Route"].ToString();
                    obj.Duration = 9999;//Convert.ToInt32(dsDrug.Rows[i]["Duration"]);
                    obj.BranchId = dm.BranchId;//Convert.ToInt32(dsDrug.Rows[i]["Duration"]);
                    drugList.Add(obj);
                }
            }
            return drugList;
        }
        //Location Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<ScientificNameModel> GetScientificName(Int32 la)
        {
            List<ScientificNameModel> itemList = new List<ScientificNameModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetScientificName", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ScientificId", la);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    ScientificNameModel obj = new ScientificNameModel();
                    obj.ScientificId = Convert.ToInt32(dsNumber.Rows[i]["ScientificId"]);
                    obj.ScientificCode = dsNumber.Rows[i]["ScientificCode"].ToString();
                    obj.ScientificName = dsNumber.Rows[i]["ScientificName"].ToString();
                    obj.Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]);
                    itemList.Add(obj);
                }
            }
            return itemList;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateScientificName(ScientificNameModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateScientifcName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScientificId", Package.ScientificId);
                cmd.Parameters.AddWithValue("@ScientificName", Package.ScientificName);
                cmd.Parameters.AddWithValue("@ScientificCode", Package.ScientificCode);
                cmd.Parameters.AddWithValue("@UserId", Package.UserId);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //ScientificName Ends
        //Tendern Starts
        /// <summary>
        /// Get Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="tendernessid">Primary key of LH_PhyTendern Table</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public List<TendernModel> GetTendern(Int32 tendernessid)
        {
            List<TendernModel> itemList = new List<TendernModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTendernDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TendernId", tendernessid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    TendernModel obj = new TendernModel();
                    obj.TendernId = Convert.ToInt32(dsNumber.Rows[i]["TendernId"]);
                    obj.TendernDesc = dsNumber.Rows[i]["TendernDesc"].ToString();
                    obj.Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]);
                    obj.BlockReason = dsNumber.Rows[i]["BlockReason"].ToString();
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// Save/Update Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="TendernId">Primary key of LH_PhyTendern Table,Update Data if param is not zero</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public string InsertUpdateTendern(TendernModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTendern", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TendernId", Package.TendernId);
                cmd.Parameters.AddWithValue("@TendernDesc", Package.TendernDesc);
                cmd.Parameters.AddWithValue("@Active", Package.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Package.BlockReason);
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
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
            }
            return response;
        }
        //Tendern Ends


        // GET MASTER ONLY NO CRUD
        /// <summary>
        /// Get Details of Religion
        /// </summary>
        /// <returns>List of religion details</returns>
        public List<ReligionModel> GetReligion()
        {
            List<ReligionModel> religionList = new List<ReligionModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetReligion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsReligionList = new DataTable();
            adapter.Fill(dsReligionList);
            con.Close();
            if ((dsReligionList != null) && (dsReligionList.Rows.Count > 0))
                religionList = dsReligionList.ToListOfObject<ReligionModel>();
            return religionList;
        }
        /// <summary>
        /// Get Details of Appointment Type
        /// </summary>
        /// <returns>List of Appointment types</returns>
        public List<AppTypeModel> GetAppType()
        {
            List<AppTypeModel> profList = new List<AppTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAppointTypes", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    AppTypeModel obj = new AppTypeModel
                    {
                        AppTypeId = Convert.ToInt32(dsProfession.Rows[i]["AppTypeId"]),
                        AppCode = dsProfession.Rows[i]["AppCode"].ToString(),
                        AppDesc = dsProfession.Rows[i]["AppDesc"].ToString()
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        /// <summary>
        /// Get Details of Visa Type
        /// </summary>
        /// <returns>List of Visa types</returns>
        public List<VisaTypeModel> GetVisaType()
        {
            List<VisaTypeModel> schemeList = new List<VisaTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVisaType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtVisaTypeList = new DataTable();
            adapter.Fill(dtVisaTypeList);
            con.Close();

            if ((dtVisaTypeList != null) && (dtVisaTypeList.Rows.Count > 0))
                schemeList = dtVisaTypeList.ToListOfObject<VisaTypeModel>();
            return schemeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<StateModel> GetStateByCountryId(Int32 countryId)
        {
            List<StateModel> stateList = new List<StateModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetEmirate", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", countryId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
                stateList = dtStateList.ToListOfObject<StateModel>();
            return stateList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ibt"></param>
        /// <returns></returns>
        public List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt)
        {
            List<ItemsByTypeModel> itemList = new List<ItemsByTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetItemsByType", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupCode", ibt.GroupCode);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtNumber = new DataTable();
                    adapter.Fill(dtNumber);
                    con.Close();
                    if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                        {
                            ItemsByTypeModel obj = new ItemsByTypeModel();
                            obj.ItemId = Convert.ToInt32(dtNumber.Rows[i]["ItemId"]);
                            obj.ItemCode = dtNumber.Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dtNumber.Rows[i]["ItemName"].ToString();
                            obj.GroupId = Convert.ToInt32(dtNumber.Rows[i]["GroupId"]);
                            obj.GroupCode = dtNumber.Rows[i]["GroupCode"].ToString();
                            itemList.Add(obj);
                        }
                    }
                    return itemList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ConsentTypeModel> GetConsentType()
        {
            List<ConsentTypeModel> consentTypeList = new List<ConsentTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsentType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    ConsentTypeModel obj = new ConsentTypeModel();
                    obj.Id = Convert.ToInt32(dtNumber.Rows[i]["Id"]);
                    obj.ConsentType = dtNumber.Rows[i]["ConsentType"].ToString();
                    obj.ConsentTypeCode = dtNumber.Rows[i]["ConsentTypeCode"].ToString();
                    consentTypeList.Add(obj);
                }
            }
            return consentTypeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numId"></param>
        /// <returns></returns>
        public List<GetNumberModel> GetNumber(string numId)
        {
            List<GetNumberModel> numberList = new List<GetNumberModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetNumber", con))
                {
                    if (numId == "All")
                    {
                        numId = string.Empty;
                    }
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumId", numId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtNumber = new DataTable();
                    adapter.Fill(dtNumber);
                    con.Close();
                    if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                        {
                            GetNumberModel obj = new GetNumberModel();
                            obj.selectopt = Convert.ToInt32(dtNumber.Rows[i]["selectopt"]);
                            obj.NumId = dtNumber.Rows[i]["NumId"].ToString();
                            obj.Description = dtNumber.Rows[i]["Description"].ToString();
                            obj.Value = Convert.ToInt32(dtNumber.Rows[i]["Value"]);
                            obj.Prefix = dtNumber.Rows[i]["Prefix"].ToString();
                            obj.Suffix = dtNumber.Rows[i]["Suffix"].ToString();
                            obj.Length = Convert.ToInt32(dtNumber.Rows[i]["Length"]);
                            obj.State = Convert.ToInt32(dtNumber.Rows[i]["State"]);
                            obj.Status = Convert.ToInt32(dtNumber.Rows[i]["Status"]);
                            obj.MaxLength = Convert.ToInt32(dtNumber.Rows[i]["MaxLength"]);
                            obj.Preview = dtNumber.Rows[i]["Preview"].ToString();
                            numberList.Add(obj);
                        }
                    }
                    return numberList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<FormValidationModel> GetFormMaster()
        {
            List<FormValidationModel> numberList = new List<FormValidationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetFormMaster", con))
                {

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtNumber = new DataTable();
                    adapter.Fill(dtNumber);
                    con.Close();
                    if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                        {
                            FormValidationModel obj = new FormValidationModel();
                            obj.FormId = Convert.ToInt32(dtNumber.Rows[i]["FormId"]);
                            obj.FormName = dtNumber.Rows[i]["FormName"].ToString();
                            numberList.Add(obj);
                        }
                    }
                    return numberList;
                }
            }
        }
        /// <summary>
        /// GET list of Input Fieldt In a Form Id
        /// </summary>
        /// <param name="FormId">ID of form</param>
        /// <returns>Form Fieldt list</returns>
        public List<FormValidationModel> GetFormFields(Int32 FormId)
        {
            List<FormValidationModel> numberList = new List<FormValidationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_GetFormFields", con);

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FormId", FormId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtNumber = new DataTable();
                adapter.Fill(dtNumber);
                con.Close();
                if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
                {
                    for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                    {
                        FormValidationModel obj = new FormValidationModel();
                        obj.FieldId = Convert.ToInt32(dtNumber.Rows[i]["FieldId"]);
                        obj.FormId = Convert.ToInt32(dtNumber.Rows[i]["FormId"]);
                        obj.FieldName = dtNumber.Rows[i]["FieldName"].ToString();
                        numberList.Add(obj);
                    }
                }
                return numberList;
            }
        }
        /// <summary>
        /// Update Data in Number configuration table 
        /// </summary>
        /// <param name="num">Data in LH_Numbers Table</param>
        /// <returns>Success or reason for error</returns>
        public string UpdateNumberTable(GetNumberModel num)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ActionUpdateNumber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumId", num.NumId);
                    cmd.Parameters.AddWithValue("@Prefix", num.Prefix);
                    cmd.Parameters.AddWithValue("@Suffix", num.Suffix);
                    cmd.Parameters.AddWithValue("@Length", num.Length);
                    cmd.Parameters.AddWithValue("@Status", num.Status);
                    cmd.Parameters.AddWithValue("@Value", num.Value);
                    cmd.Parameters.AddWithValue("@MaxLength", num.MaxLength);
                    cmd.Parameters.AddWithValue("@UserId", num.UserId);
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
                    var ret = retValV.Value;
                    var descrip = retDesc.Value.ToString();
                    con.Close();
                    if (descrip == "Saved Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Get all gender data
        /// </summary>
        /// <returns>Gender data list</returns>
        public List<GenderModel> GetGender()
        {
            List<GenderModel> genderList = new List<GenderModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetGender", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsGender = new DataTable();
                    adapter.Fill(dsGender);
                    con.Close();
                    if ((dsGender != null) && (dsGender.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsGender.Rows.Count; i++)
                        {
                            GenderModel obj = new GenderModel();
                            obj.Id = Convert.ToInt32(dsGender.Rows[i]["Id"]);
                            obj.GenderName = dsGender.Rows[i]["GenderName"].ToString();
                            genderList.Add(obj);
                        }
                    }
                    return genderList;
                }
            }
        }
        /// <summary>
        /// Get all kin relation data
        /// </summary>
        /// <returns>Kin relation list</returns>
        public List<KinRelationModel> GetKinRelation()
        {
            List<KinRelationModel> kinRelationList = new List<KinRelationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetKinRelation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsKinRelation = new DataTable();
                    adapter.Fill(dsKinRelation);
                    con.Close();
                    if ((dsKinRelation != null) && (dsKinRelation.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsKinRelation.Rows.Count; i++)
                        {
                            KinRelationModel obj = new KinRelationModel();
                            obj.Id = Convert.ToInt32(dsKinRelation.Rows[i]["Id"]);
                            obj.KinRelation = dsKinRelation.Rows[i]["KinRelation"].ToString();
                            kinRelationList.Add(obj);
                        }
                    }
                    return kinRelationList;
                }
            }
        }
        /// <summary>
        /// Get all Marital status Data
        /// </summary>
        /// <returns>Marital status list</returns>
        public List<MaritalStatusModel> GetMaritalStatus()
        {
            List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetMaritalStatus", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsmaritalStatus = new DataTable();
                    adapter.Fill(dsmaritalStatus);
                    con.Close();
                    if ((dsmaritalStatus != null) && (dsmaritalStatus.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsmaritalStatus.Rows.Count; i++)
                        {
                            MaritalStatusModel obj = new MaritalStatusModel();
                            obj.Id = Convert.ToInt32(dsmaritalStatus.Rows[i]["Id"]);
                            obj.MaritalStatusDescription = dsmaritalStatus.Rows[i]["MaritalStatusDescription"].ToString();
                            maritalStatusList.Add(obj);
                        }
                    }
                    return maritalStatusList;
                }
            }
        }
        /// <summary>
        /// Get All communication type list
        /// </summary>
        /// <returns>List of communication types</returns>
        public List<CommunicationTypeModel> GetCommunicationType()
        {
            List<CommunicationTypeModel> communicationTypeList = new List<CommunicationTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetCommunicationType", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dscommunicationType = new DataTable();
                    adapter.Fill(dscommunicationType);
                    con.Close();
                    if ((dscommunicationType != null) && (dscommunicationType.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dscommunicationType.Rows.Count; i++)
                        {
                            CommunicationTypeModel obj = new CommunicationTypeModel
                            {
                                Id = Convert.ToInt32(dscommunicationType.Rows[i]["Id"]),
                                CommunicationType = dscommunicationType.Rows[i]["CommunicationType"].ToString()
                            };
                            communicationTypeList.Add(obj);
                        }
                    }
                    return communicationTypeList;
                }
            }
        }

    }
}
