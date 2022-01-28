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
        /// 
        /// </summary>
        /// <param name="profid"></param>
        /// <returns></returns>
        public List<ProfessionModel> GetProfession(int profid)
        {
            List<ProfessionModel> profList = new List<ProfessionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfession", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfId", profid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            ProfessionModel obj = new ProfessionModel();
                            obj.ProfId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfId"]);
                            obj.ProfName = dsProfession.Tables[0].Rows[i]["ProfName"].ToString();
                            obj.ProfGroup = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfGroup"]);
                            obj.Active = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["IsActive"]);
                            obj.BlockReason = dsProfession.Tables[0].Rows[i]["BlockReason"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profession"></param>
        /// <returns></returns>
        public string InsertUpdateProfession(ProfessionModel profession)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateProfession", con))
                {
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
            }
            return response;
        }

        //ProfessionManagement Ends

        //SponsorManagement Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sponsorid"></param>
        /// <returns></returns>
        public List<SponsorMasterModel> GetSponsor(int sponsorid)
        {
            List<SponsorMasterModel> profList = new List<SponsorMasterModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", sponsorid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            SponsorMasterModel obj = new SponsorMasterModel();
                            obj.SponsorId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["SponsorId"]);
                            obj.SponsorName = dsProfession.Tables[0].Rows[i]["SponsorName"].ToString();
                            obj.SponsorType = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["SponsorType"]);
                            obj.Address1 = dsProfession.Tables[0].Rows[i]["Address1"].ToString();
                            obj.Address2 = dsProfession.Tables[0].Rows[i]["Address2"].ToString();
                            obj.Street = dsProfession.Tables[0].Rows[i]["Street"].ToString();
                            obj.PlacePO = dsProfession.Tables[0].Rows[i]["PlacePO"].ToString();
                            obj.PIN = dsProfession.Tables[0].Rows[i]["PIN"].ToString();
                            obj.City = dsProfession.Tables[0].Rows[i]["City"].ToString();
                            obj.State = dsProfession.Tables[0].Rows[i]["State"].ToString();
                            obj.CountryId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["CountryId"]);
                            obj.Phone = dsProfession.Tables[0].Rows[i]["Phone"].ToString();
                            obj.Mobile = dsProfession.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Email = dsProfession.Tables[0].Rows[i]["Email"].ToString();
                            obj.Fax = dsProfession.Tables[0].Rows[i]["Fax"].ToString();
                            obj.ContactPerson = dsProfession.Tables[0].Rows[i]["ContactPerson"].ToString();
                            obj.DedAmount = (float)Convert.ToDouble(dsProfession.Tables[0].Rows[i]["DedAmount"].ToString());
                            obj.CoPayPcnt = (float)Convert.ToDouble(dsProfession.Tables[0].Rows[i]["CoPayPcnt"].ToString());
                            obj.Remarks = dsProfession.Tables[0].Rows[i]["Remarks"].ToString();
                            obj.SFormId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["SFormId"]);
                            obj.Active = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsProfession.Tables[0].Rows[i]["BlockReason"].ToString();
                            obj.SponsorLimit = (float)Convert.ToDouble(dsProfession.Tables[0].Rows[i]["SponsorLimit"].ToString());
                            obj.DHANo = dsProfession.Tables[0].Rows[i]["DHANo"].ToString();
                            obj.EnableSponsorLimit = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["EnableSponsorLimit"]);
                            obj.EnableSponsorConsent = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["EnableSponsorConsent"]);
                            obj.AuthorizationMode = dsProfession.Tables[0].Rows[i]["AuthorizationMode"].ToString();
                            obj.URL = dsProfession.Tables[0].Rows[i]["URL"].ToString();
                            obj.SortOrder = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["SortOrder"]);
                            obj.PartyId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["PartyId"]);
                            obj.UnclaimedId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["UnclaimedId"]);
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sponsor"></param>
        /// <returns></returns>
        public string InsertUpdateSponsor(SponsorMasterModel sponsor)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsor", con))
                {
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
            }
            return response;
        }
        //SponsorManagement Ends

        //SponsorType Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<SponsorTypeModel> GetSponsorType(int typeid)
        {
            List<SponsorTypeModel> stypeList = new List<SponsorTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSponsorType", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STypeId", typeid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            SponsorTypeModel obj = new SponsorTypeModel();
                            obj.STypeId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["STypeId"]);
                            obj.STypeDesc = dsProfession.Tables[0].Rows[i]["STypeDesc"].ToString();
                            obj.Active = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsProfession.Tables[0].Rows[i]["BlockReason"].ToString();
                            stypeList.Add(obj);
                        }
                    }
                    return stypeList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stype"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorType", con))
                {
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
        public List<SponsorFormModel> GetSponsorForm(int formid)
        {
            List<SponsorFormModel> sformList = new List<SponsorFormModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSponsorForms", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SFormId", formid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            SponsorFormModel obj = new SponsorFormModel();
                            obj.SFormId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["SFormId"]);
                            obj.SFormName = dsProfession.Tables[0].Rows[i]["SFormName"].ToString();
                            obj.Active = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsProfession.Tables[0].Rows[i]["SFormName"].ToString();
                            sformList.Add(obj);
                        }
                    }
                    return sformList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sform"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorForm(SponsorFormModel sform)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorForm", con))
                {
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
        public List<ConsentPreviewModel> GetConsentPreviewConsent(int patientid)
        {
            List<ConsentPreviewModel> consentpreviewList = new List<ConsentPreviewModel>();
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            string patientname = string.Empty;
            string fileloc = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId", 0);
                    cmd.Parameters.AddWithValue("@ConsentType", 1);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();

                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        for (int j = 0; j < dsPatientList.Tables[0].Rows.Count; j++)
                        {
                            ConsentContentModel obj4 = new ConsentContentModel();
                            obj4.ContentId = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["ContentId"]);
                            obj4.CTEnglish = dsPatientList.Tables[0].Rows[j]["CTEnglish"].ToString();
                            obj4.CTArabic = dsPatientList.Tables[0].Rows[j]["CTArabic"].ToString();
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
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();
                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        patientname = dsPatientList.Tables[0].Rows[0]["PatientName"].ToString();
                        if (dsPatientList.Tables[0].Rows[0]["SignLocation"].ToString() != "")
                        {
                            fileloc = _uploadpath + dsPatientList.Tables[0].Rows[0]["SignLocation"].ToString();
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consentid"></param>
        /// <returns></returns>
        public List<ConsentContentModel> GetConsent(int consentid)
        {
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId", consentid);
                    cmd.Parameters.AddWithValue("@ConsentType", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();

                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        for (int j = 0; j < dsPatientList.Tables[0].Rows.Count; j++)
                        {
                            ConsentContentModel obj4 = new ConsentContentModel();
                            obj4.ContentId = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["ContentId"]);
                            obj4.CTEnglish = dsPatientList.Tables[0].Rows[j]["CTEnglish"].ToString();
                            obj4.CTArabic = dsPatientList.Tables[0].Rows[j]["CTArabic"].ToString();
                            obj4.DisplayOrder = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["DisplayOrder"]);
                            obj4.CType = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["CType"]);
                            obj4.Active = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["Active"]);
                            obj4.BlockReason = dsPatientList.Tables[0].Rows[j]["BlockReason"].ToString();
                            ccmlist.Add(obj4);
                        }
                    }
                }
                return ccmlist;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consent"></param>
        /// <returns></returns>
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsent", con))
                {
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
            }
            return response;
        }
        //Consent Management Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryDetails"></param>
        /// <returns></returns>
        public List<CountryModel> GetCountry(int countryDetails)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetCountry", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryId", countryDetails);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dscontryList = new DataSet();
                    adapter.Fill(dscontryList);
                    con.Close();
                    if ((dscontryList != null) && (dscontryList.Tables.Count > 0) && (dscontryList.Tables[0] != null) && (dscontryList.Tables[0].Rows.Count > 0))
                        countryList = dscontryList.Tables[0].ToListOfObject<CountryModel>();
                    return countryList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string InsertUpdateCountry(CountryModel country)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCountry", con))
                {
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
        public List<StateModel> GetState(int stateId)
        {
            List<StateModel> countryList = new List<StateModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetState", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StateId", stateId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        countryList = dsStateList.Tables[0].ToListOfObject<StateModel>();
                    return countryList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string InsertUpdateState(StateModel state)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateState", con))
                {
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
        public List<SalutationModel> GetSalutation(int salutationDetails)
        {
            List<SalutationModel> countryList = new List<SalutationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetSalutation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalutationId", salutationDetails);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dssalutationList = new DataSet();
                    adapter.Fill(dssalutationList);
                    con.Close();
                    if ((dssalutationList != null) && (dssalutationList.Tables.Count > 0) && (dssalutationList.Tables[0] != null) && (dssalutationList.Tables[0].Rows.Count > 0))
                        countryList = dssalutationList.Tables[0].ToListOfObject<SalutationModel>();
                    return countryList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutation"></param>
        /// <returns></returns>
        public string InsertUpdateSalutation(SalutationModel salutation)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSalutation", con))
                {
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
        public List<BodyPartModel> GetBodyPart(int salutationDetails)
        {
            List<BodyPartModel> countryList = new List<BodyPartModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetBodyPart", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BodyId", salutationDetails);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dscontryList = new DataSet();
                    adapter.Fill(dscontryList);
                    con.Close();
                    if ((dscontryList != null) && (dscontryList.Tables.Count > 0) && (dscontryList.Tables[0] != null) && (dscontryList.Tables[0].Rows.Count > 0))
                        countryList = dscontryList.Tables[0].ToListOfObject<BodyPartModel>();
                    return countryList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bodypart"></param>
        /// <returns></returns>
        public string InsertUpdateBodyPart(BodyPartModel bodypart)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateBodyPart", con))
                {
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
            }
            return response;
        }
        //BodyPart Management Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public string InsertUpdateZone(ZoneModel zone)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateZone", con))//InsertUpdateZone
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns></returns>
        public List<ZoneModel> GetZone(int zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ZoneById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsZoneList = new DataSet();
                    adapter.Fill(dsZoneList);
                    con.Close();
                    if ((dsZoneList != null) && (dsZoneList.Tables.Count > 0) && (dsZoneList.Tables[0] != null) && (dsZoneList.Tables[0].Rows.Count > 0))
                        zoneList = dsZoneList.Tables[0].ToListOfObject<ZoneModel>();
                    return zoneList;
                }
            }
        }

        /// <summary>
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments(int DeptId)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", DeptId);
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
                            obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                            obj.BranchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BranchId"]);
                            obj.TimeSlice = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeSlice"]);
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public string InsertUpdateDepartment(DepartmentModel department)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDepartment", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// Get Department Details By HospitalId
        /// </summary>
        /// <param name="HospId"></param>
        /// <returns>List Of Departments</returns>
        public List<DepartmentModel> GetDepartmentByHospital(int HospId)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDepartmentByHospital", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", HospId);
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
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RegScheme"></param>
        /// <returns></returns>
        public string InsertUpdateRegScheme(RegSchemeModel RegScheme)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRegScheme", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RegSchemeId"></param>
        /// <returns></returns>
        public List<RegSchemeModel> GetRegScheme(int RegSchemeId)
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_RegSchemeById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemId", RegSchemeId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsRegSchemeList = new DataSet();
                    adapter.Fill(dsRegSchemeList);
                    con.Close();
                    if ((dsRegSchemeList != null) && (dsRegSchemeList.Tables.Count > 0) && (dsRegSchemeList.Tables[0] != null) && (dsRegSchemeList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsRegSchemeList.Tables[0].Rows.Count; i++)
                        {
                            RegSchemeModel obj = new RegSchemeModel();
                            obj.ItemId = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemCode = dsRegSchemeList.Tables[0].Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsRegSchemeList.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.GroupId = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["GroupId"]);
                            obj.ValidityDays = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["ValidityDays"]);
                            obj.ValidityVisits = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["ValidityVisits"]);
                            obj.AllowRateEdit = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["AllowRateEdit"]);
                            obj.AllowDisc = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["AllowDisc"]);
                            obj.AllowPP = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["AllowPP"]);
                            obj.IsVSign = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["IsVSign"]);
                            obj.ResultOn = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["ResultOn"]);
                            obj.STypeId = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["STypeId"]);
                            obj.TotalTaxPcnt = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["TotalTaxPcnt"]);
                            obj.AllowCommission = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["AllowCommission"]);
                            obj.CommPcnt = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["CommPcnt"]);
                            obj.CommAmt = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["CommAmt"]);
                            obj.MaterialCost = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["MaterialCost"]);
                            obj.BaseCost = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["BaseCost"]);
                            obj.HeadId = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["HeadId"]);
                            obj.SortOrder = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["SortOrder"]);
                            obj.Active = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsRegSchemeList.Tables[0].Rows[i]["BlockReason"].ToString();
                            obj.CPTCodeId = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["CPTCodeId"]);
                            obj.ExternalItem = Convert.ToInt32(dsRegSchemeList.Tables[0].Rows[i]["ExternalItem"]);
                            regSchemeList.Add(obj);
                        }
                    }
                    return regSchemeList;
                }
            }
        }
        //Rate group Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateGroup"></param>
        /// <returns></returns>
        public string InsertUpdateRateGroup(RateGroupModel RateGroup)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRateGroup", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateGroupId"></param>
        /// <returns></returns>
        public List<RateGroupModel> GetRateGroup(int RateGroupId)
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetRateGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RGroupId", RateGroupId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RateGroupModel obj = new RateGroupModel();
                            obj.RGroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["RGroupId"]);
                            obj.RGroupName = dsStateList.Tables[0].Rows[i]["RGroupName"].ToString();
                            obj.Description = dsStateList.Tables[0].Rows[i]["Description"].ToString();
                            obj.EffectFrom = dsStateList.Tables[0].Rows[i]["EffectFrom"].ToString();
                            obj.EffectTo = dsStateList.Tables[0].Rows[i]["EffectTo"].ToString();
                            obj.Active = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsStateList.Tables[0].Rows[i]["BlockReason"].ToString();
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        //Rate Group Ends
        //Hospital Starts
        /// <summary>
        /// Get Hospital list from database.Step three in code execution flow
        /// </summary>
        /// <returns></returns>

        public List<HospitalModel> GetUserHospitals(int id)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsHospitalList = new DataSet();
                    adapter.Fill(dsHospitalList);
                    con.Close();
                    if ((dsHospitalList != null) && (dsHospitalList.Tables.Count > 0) && (dsHospitalList.Tables[0] != null) && (dsHospitalList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsHospitalList.Tables[0].Rows.Count; i++)
                        {
                            HospitalModel obj = new HospitalModel();
                            obj.HospitalId = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["HospitalId"]);
                            obj.HospitalName = dsHospitalList.Tables[0].Rows[i]["HospitalName"].ToString();
                            obj.HospitalCode = dsHospitalList.Tables[0].Rows[i]["HospitalCode"].ToString();
                            obj.Caption = dsHospitalList.Tables[0].Rows[i]["Caption"].ToString();
                            obj.Address1 = dsHospitalList.Tables[0].Rows[i]["Address1"].ToString();
                            obj.Address2 = dsHospitalList.Tables[0].Rows[i]["Address2"].ToString();
                            obj.Street = dsHospitalList.Tables[0].Rows[i]["Street"].ToString();
                            obj.PlacePO = dsHospitalList.Tables[0].Rows[i]["PlacePO"].ToString();
                            obj.PIN = dsHospitalList.Tables[0].Rows[i]["PIN"].ToString();
                            obj.City = dsHospitalList.Tables[0].Rows[i]["City"].ToString();
                            obj.State = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["State"]);
                            obj.Country = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["Country"]);
                            obj.Phone = dsHospitalList.Tables[0].Rows[i]["Phone"].ToString();
                            obj.Fax = dsHospitalList.Tables[0].Rows[i]["Fax"].ToString();
                            obj.Email = dsHospitalList.Tables[0].Rows[i]["Email"].ToString();
                            obj.URL = dsHospitalList.Tables[0].Rows[i]["URL"].ToString();
                            obj.Logo = dsHospitalList.Tables[0].Rows[i]["Logo"].ToString();
                            obj.ReportLogo = dsHospitalList.Tables[0].Rows[i]["ReportLogo"].ToString();
                            obj.ClinicId = dsHospitalList.Tables[0].Rows[i]["ClinicId"].ToString();
                            obj.DHAFacilityId = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.DHAUserName = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.DHAPassword = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.SR_ID = dsHospitalList.Tables[0].Rows[i]["SR_ID"].ToString();
                            obj.MalaffiSystemcode = dsHospitalList.Tables[0].Rows[i]["MalaffiSystemcode"].ToString();
                            obj.Active = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["IsActive"]);
                            obj.BlockReason = dsHospitalList.Tables[0].Rows[i]["BlockReason"].ToString();
                            hospitalList.Add(obj);
                        }
                    }
                    return hospitalList;

                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospital"></param>
        /// <returns></returns>
        public string InsertUpdateUserHospital(HospitalRegModel hospital)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateHospital", con))
                {
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
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertConsentForm", con))
                {
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
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateOperator", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OperatorId"></param>
        /// <returns></returns>
        public List<OperatorModel> GetOperator(int OperatorId)
        {
            List<OperatorModel> stateList = new List<OperatorModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetOperatorById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", OperatorId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            OperatorModel obj = new OperatorModel();
                            obj.Id = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Id"]);
                            obj.OperatorName = dsStateList.Tables[0].Rows[i]["OperatorName"].ToString();
                            obj.OperatorCode = dsStateList.Tables[0].Rows[i]["OperatorCode"].ToString();
                            obj.Active = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["IsActive"]);
                            obj.BlockReason = dsStateList.Tables[0].Rows[i]["BlockReason"].ToString();
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        //Operator Ends Now
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<LeadAgentModel> GetLeadAgent(int la)
        {
            List<LeadAgentModel> itemList = new List<LeadAgentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentId", la);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            LeadAgentModel obj = new LeadAgentModel();
                            obj.LeadAgentId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["LeadAgentId"]);
                            obj.Name = dsNumber.Tables[0].Rows[i]["Name"].ToString();
                            obj.ContactNo = dsNumber.Tables[0].Rows[i]["ContactNo"].ToString();
                            obj.CommisionPercent = (float)Convert.ToDouble(dsNumber.Tables[0].Rows[i]["CommisionPercent"].ToString());
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
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
        /// <param name="LeadAgent"></param>
        /// <returns></returns>
        public string InsertUpdateLeadAgent(LeadAgentModel LeadAgent)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLeadAgent", con))
                {
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
            }
            return response;
        }

        //Company Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<CompanyModel> GetCompany(int Id)
        {
            List<CompanyModel> companyList = new List<CompanyModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetCompany", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CmpId", Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            CompanyModel obj = new CompanyModel();
                            obj.CmpId = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["CmpId"]);
                            obj.CmpName = dsCompany.Tables[0].Rows[i]["CmpName"].ToString();
                            obj.Active = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsCompany.Tables[0].Rows[i]["BlockReason"].ToString();
                            companyList.Add(obj);
                        }
                    }
                    return companyList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Company"></param>
        /// <returns></returns>
        public string InsertUpdateCompany(CompanyModel Company)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany", con))
                {
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
            }
            return response;
        }
        //Company Management Ends

        //City Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public List<CityModel> GetCity(int cityid)
        {
            List<CityModel> cityList = new List<CityModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetCity", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityId", cityid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            CityModel obj = new CityModel();
                            obj.CityId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["CityId"]);
                            obj.CityName = dsProfession.Tables[0].Rows[i]["CityName"].ToString();
                            obj.StateId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["StateId"]);
                            obj.CountryId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["CountryId"]);
                            obj.CountryName = dsProfession.Tables[0].Rows[i]["CountryName"].ToString();
                            cityList.Add(obj);
                        }
                    }
                    return cityList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public string InsertUpdateCity(CityModel city)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCity", con))
                {
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
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSymptom", con))
                {
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

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetActiveSymptoms", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsSymptomList = new DataSet();
                    adapter.Fill(dsSymptomList);
                    con.Close();
                    if ((dsSymptomList != null) && (dsSymptomList.Tables.Count > 0) && (dsSymptomList.Tables[0] != null) && (dsSymptomList.Tables[0].Rows.Count > 0))
                        stateList = dsSymptomList.Tables[0].ToListOfObject<SymptomModel>();
                    return stateList;
                }
            }
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
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateVitalSign", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<VitalSignModel> GetVitalSign(int Id)
        {
            List<VitalSignModel> vitalSignList = new List<VitalSignModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetVitalSign", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SignId", Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsVitalSignList = new DataSet();
                    adapter.Fill(dsVitalSignList);
                    con.Close();
                    if ((dsVitalSignList != null) && (dsVitalSignList.Tables.Count > 0) && (dsVitalSignList.Tables[0] != null) && (dsVitalSignList.Tables[0].Rows.Count > 0))
                        vitalSignList = dsVitalSignList.Tables[0].ToListOfObject<VitalSignModel>();
                    return vitalSignList;
                }
            }
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
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMovement", con))
                {
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
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<MovementModel> GetMovement(int Id)
        {
            List<MovementModel> vitalSignList = new List<MovementModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetMovementDetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovementId", Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsMovementList = new DataSet();
                    adapter.Fill(dsMovementList);
                    con.Close();
                    if ((dsMovementList != null) && (dsMovementList.Tables.Count > 0) && (dsMovementList.Tables[0] != null) && (dsMovementList.Tables[0].Rows.Count > 0))
                        vitalSignList = dsMovementList.Tables[0].ToListOfObject<MovementModel>();
                    return vitalSignList;
                }
            }
        }
        //Movement Ends
        //Package Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<PackageModel> GetPackage(int la)
        {
            List<PackageModel> itemList = new List<PackageModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetPackage", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PackId", la);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            PackageModel obj = new PackageModel();
                            obj.PackId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["PackId"]);
                            obj.PackDesc = dsNumber.Tables[0].Rows[i]["PackDesc"].ToString();
                            obj.EffectFrom = dsNumber.Tables[0].Rows[i]["EffectFrom"].ToString();
                            obj.EffectTo = dsNumber.Tables[0].Rows[i]["EffectTo"].ToString();
                            obj.PackAmount = (float)Convert.ToDouble(dsNumber.Tables[0].Rows[i]["PackAmount"].ToString());
                            obj.Remarks = dsNumber.Tables[0].Rows[i]["Remarks"].ToString();
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
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
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdatePackage(PackageModel Package)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePackage", con))
                {
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
        public List<LocationModel> GetLocation(int la)
        {
            List<LocationModel> itemList = new List<LocationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLocation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocationId", la);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            LocationModel obj = new LocationModel();
                            obj.LocationId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["LocationId"]);
                            obj.LocationName = dsNumber.Tables[0].Rows[i]["LocationName"].ToString();
                            obj.Supervisor = dsNumber.Tables[0].Rows[i]["Supervisor"].ToString();
                            obj.ContactNumber = dsNumber.Tables[0].Rows[i]["ContactNumber"].ToString();
                            obj.LTypeId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["LTypeId"]);
                            obj.ManageSPoints = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["ManageSPoints"]);
                            obj.ManageBilling = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["ManageBilling"]);
                            obj.ManageCash = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["ManageCash"]);
                            obj.ManageCredit = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["ManageCredit"]);
                            obj.ManageIPCredit = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["ManageIPCredit"]);
                            obj.Active = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
                            obj.RepHeadImg = dsNumber.Tables[0].Rows[i]["RepHeadImg"].ToString();
                            obj.HospitalId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["HospitalId"]);
                            obj.HospitalName = dsNumber.Tables[0].Rows[i]["HospitalName"].ToString();
                            //obj.PackAmount = (float)Convert.ToDouble(dsNumber.Tables[0].Rows[i]["PackAmount"].ToString());
                            obj.Active = Convert.ToBoolean(dsNumber.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
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
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateLocation(LocationModel Package)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLocation", con))
                {
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
            }
            return response;
        }
        //Location Ends
        //Location Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<ScientificNameModel> GetScientificName(int la)
        {
            List<ScientificNameModel> itemList = new List<ScientificNameModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetScientificName", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ScientificId", la);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            ScientificNameModel obj = new ScientificNameModel();
                            obj.ScientificId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["ScientificId"]);
                            obj.ScientificCode = dsNumber.Tables[0].Rows[i]["ScientificCode"].ToString();
                            obj.ScientificName = dsNumber.Tables[0].Rows[i]["ScientificName"].ToString();
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            //obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
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
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateScientificName(ScientificNameModel Package)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateScientifcName", con))
                {
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
        public List<TendernModel> GetTendern(int tendernessid)
        {
            List<TendernModel> itemList = new List<TendernModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetTendernDetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TendernId", tendernessid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            TendernModel obj = new TendernModel();
                            obj.TendernId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["TendernId"]);
                            obj.TendernDesc = dsNumber.Tables[0].Rows[i]["TendernDesc"].ToString();
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsNumber.Tables[0].Rows[i]["BlockReason"].ToString();
                            itemList.Add(obj);
                        }
                    }
                    return itemList;
                }
            }
        }
        /// <summary>
        /// Save/Update Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="TendernId">Primary key of LH_PhyTendern Table,Update Data if param is not zero</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public string InsertUpdateTendern(TendernModel Package)
        {
            string response = string.Empty; ;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTendern", con))
                {
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
        /// Get Details of Appointment Type
        /// </summary>
        /// <returns>List of Appointment types</returns>
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
                            obj.AppTypeId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["AppTypeId"]);
                            obj.AppCode = dsProfession.Tables[0].Rows[i]["AppCode"].ToString();
                            obj.AppDesc = dsProfession.Tables[0].Rows[i]["AppDesc"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        /// <summary>
        /// Get Details of Visa Type
        /// </summary>
        /// <returns>List of Visa types</returns>
        public List<VisaTypeModel> GetVisaType()
        {
            List<VisaTypeModel> schemeList = new List<VisaTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetVisaType", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsVisaTypeList = new DataSet();
                    adapter.Fill(dsVisaTypeList);
                    con.Close();

                    if ((dsVisaTypeList != null) && (dsVisaTypeList.Tables.Count > 0) && (dsVisaTypeList.Tables[0] != null) && (dsVisaTypeList.Tables[0].Rows.Count > 0))
                        schemeList = dsVisaTypeList.Tables[0].ToListOfObject<VisaTypeModel>();
                    return schemeList;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<StateModel> GetStateByCountryId(int countryId)
        {
            List<StateModel> stateList = new List<StateModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetEmirate", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CountryId", countryId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<StateModel>();
                    return stateList;
                }
            }
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
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            ItemsByTypeModel obj = new ItemsByTypeModel();
                            obj.ItemId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemCode = dsNumber.Tables[0].Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsNumber.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.GroupId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["GroupId"]);
                            obj.GroupCode = dsNumber.Tables[0].Rows[i]["GroupCode"].ToString();
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

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsentType", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            ConsentTypeModel obj = new ConsentTypeModel();
                            obj.Id = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Id"]);
                            obj.ConsentType = dsNumber.Tables[0].Rows[i]["ConsentType"].ToString();
                            obj.ConsentTypeCode = dsNumber.Tables[0].Rows[i]["ConsentTypeCode"].ToString();
                            consentTypeList.Add(obj);
                        }
                    }
                    return consentTypeList;
                }
            }
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
                        numId = string.Empty; ;
                    }
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumId", numId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            GetNumberModel obj = new GetNumberModel();
                            obj.selectopt = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["selectopt"]);
                            obj.NumId = dsNumber.Tables[0].Rows[i]["NumId"].ToString();
                            obj.Description = dsNumber.Tables[0].Rows[i]["Description"].ToString();
                            obj.Value = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Value"]);
                            obj.Prefix = dsNumber.Tables[0].Rows[i]["Prefix"].ToString();
                            obj.Suffix = dsNumber.Tables[0].Rows[i]["Suffix"].ToString();
                            obj.Length = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Length"]);
                            obj.State = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["State"]);
                            obj.Status = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Status"]);
                            obj.MaxLength = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["MaxLength"]);
                            obj.Preview = dsNumber.Tables[0].Rows[i]["Preview"].ToString();
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
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            FormValidationModel obj = new FormValidationModel();
                            obj.FormId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["FormId"]);
                            obj.FormName = dsNumber.Tables[0].Rows[i]["FormName"].ToString();
                            numberList.Add(obj);
                        }
                    }
                    return numberList;
                }
            }
        }
        /// <summary>
        /// GET list of Input Fields In a Form Id
        /// </summary>
        /// <param name="FormId">ID of form</param>
        /// <returns>Form Fields list</returns>
        public List<FormValidationModel> GetFormFields(int FormId)
        {
            List<FormValidationModel> numberList = new List<FormValidationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetFormFields", con))
                {

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormId", FormId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            FormValidationModel obj = new FormValidationModel();
                            obj.FieldId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["FieldId"]);
                            obj.FormId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["FormId"]);
                            obj.FieldName = dsNumber.Tables[0].Rows[i]["FieldName"].ToString();
                            numberList.Add(obj);
                        }
                    }
                    return numberList;
                }
            }
        }
        /// <summary>
        /// Update Data in Number configuration table 
        /// </summary>
        /// <param name="num">Data in LH_Numbers Table</param>
        /// <returns>Success or reason for error</returns>
        public string UpdateNumberTable(GetNumberModel num)
        {
            string response = string.Empty; ;
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

        public List<ConsultantModel> ConsultantSearchWithDept(GetScheduleInputModel drsearch)
        {
            List<ConsultantModel> numberList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultant", con))
                {
                    //con.Open();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@NumId", numId);
                    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //DataSet dsNumber = new DataSet();
                    //adapter.Fill(dsNumber);
                    //con.Close();                    
                    return numberList;
                }
            }
        }
    }
}
