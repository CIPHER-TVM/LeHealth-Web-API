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
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }
        //ProfessionManagement Starts
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
        public string InsertUpdateProfession(ProfessionModel profession)
        {
            string response = "";
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
        public List<SponsorMasterModel> GetSponsor(int profid)
        {
            List<SponsorMasterModel> profList = new List<SponsorMasterModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", profid);
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
        public string InsertUpdateSponsor(SponsorMasterModel sponsor)
        {
            string response = "";
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
                    cmd.Parameters.AddWithValue("@Active", 1);
                    cmd.Parameters.AddWithValue("@UserId", sponsor.UserId);
                    cmd.Parameters.AddWithValue("@DHANo", sponsor.DHANo);
                    cmd.Parameters.AddWithValue("@EnableLimit", sponsor.EnableSponsorLimit);
                    cmd.Parameters.AddWithValue("@EnableConsent", sponsor.EnableSponsorConsent);
                    cmd.Parameters.AddWithValue("@AuthorizationMode", sponsor.AuthorizationMode);
                    cmd.Parameters.AddWithValue("@URL", sponsor.URL);
                    cmd.Parameters.AddWithValue("@SortOrder", sponsor.SortOrder);


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
                            stypeList.Add(obj);
                        }
                    }
                    return stypeList;
                }
            }
        }
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STypeId", stype.STypeId);
                    cmd.Parameters.AddWithValue("@STypeDesc", stype.STypeDesc);
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
                            sformList.Add(obj);
                        }
                    }
                    return sformList;
                }
            }
        }
        public string InsertUpdateSponsorForm(SponsorFormModel sform)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorForm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SFormId", sform.SFormId);
                    cmd.Parameters.AddWithValue("@SFormName", sform.SFormName);
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

        //City Starts
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
        public string InsertUpdateCity(CityModel city)
        {
            string response = "";
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
        //SponsorForm Ends

        //Consent Management Starts
        public List<ConsentPreviewModel> GetConsentPreviewConsent(int patientid)
        {
            List<ConsentPreviewModel> consentpreviewList = new List<ConsentPreviewModel>();
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            string patientname = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetPatConsent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId", 0);
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
                    }
                }
                ConsentPreviewModel cpm = new ConsentPreviewModel();
                cpm.ConsentContentValue = ccmlist;
                cpm.PatientName = patientname;
                consentpreviewList.Add(cpm);
                return consentpreviewList;
            }
        }
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
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            string response = "";
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

        public List<ConsentContentModel> GetSponsorConsent(int consentid)
        {
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId", consentid);
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
                return ccmlist;
            }
        }
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
        public string InsertUpdateCountry(CountryModel country)
        {
            string response = "";
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
        public string InsertUpdateState(StateModel state)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateState", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StateId", state.StateId);
                    cmd.Parameters.AddWithValue("@StateName", state.StateName);
                    cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
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
                    DataSet dscontryList = new DataSet();
                    adapter.Fill(dscontryList);
                    con.Close();
                    if ((dscontryList != null) && (dscontryList.Tables.Count > 0) && (dscontryList.Tables[0] != null) && (dscontryList.Tables[0].Rows.Count > 0))
                        countryList = dscontryList.Tables[0].ToListOfObject<SalutationModel>();
                    return countryList;
                }
            }
        }
        public string InsertUpdateSalutation(SalutationModel salutation)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSalutation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalutationId", salutation.Id);
                    cmd.Parameters.AddWithValue("@Salutation", salutation.Salutation);
                    cmd.Parameters.AddWithValue("@UserId", salutation.UserId);
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
        public string InsertUpdateBodyPart(BodyPartModel bodypart)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateBodyPart", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BodyId", bodypart.BodyId);
                    cmd.Parameters.AddWithValue("@BodyDesc", bodypart.BodyDesc);
                    cmd.Parameters.AddWithValue("@UserId", bodypart.UserId);
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
        public string InsertUpdateZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertZone", con))//InsertUpdateZone
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
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
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
                            obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                            obj.BranchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BranchId"]);
                            obj.TimeSlice = ds.Tables[0].Rows[i]["TimeSlice"].ToString();
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }
        public string InsertUpdateDepartment(DepartmentModel department)
        {
            string response = "";
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

        //
        public string InsertUpdateRegScheme(RegSchemeModel RegScheme)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRegScheme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public string DeleteRegScheme(int RegSchemeId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteRegScheme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", RegSchemeId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
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
        public List<RegSchemeModel> GetAllRegScheme()
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllRegScheme", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsRegSchemeList = new DataSet();
                    adapter.Fill(dsRegSchemeList);
                    con.Close();
                    if ((dsRegSchemeList != null) && (dsRegSchemeList.Tables.Count > 0) && (dsRegSchemeList.Tables[0] != null) && (dsRegSchemeList.Tables[0].Rows.Count > 0))
                    //stateList = dsRegSchemeList.Tables[0].ToListOfObject<RegSchemeModel>();
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

        public string InsertRateGroup(RateGroupModel RateGroup)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                    cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                    cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                    cmd.Parameters.AddWithValue("@EffectFrom", Convert.ToDateTime(RateGroup.EffectFrom));
                    cmd.Parameters.AddWithValue("@EffectTo", Convert.ToDateTime(RateGroup.EffectTo));
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateRateGroup(RateGroupModel RateGroup)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                    cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                    cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                    cmd.Parameters.AddWithValue("@EffectFrom", Convert.ToDateTime(RateGroup.EffectFrom));
                    cmd.Parameters.AddWithValue("@EffectTo", Convert.ToDateTime(RateGroup.EffectTo));
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteRateGroup(int RateGroupId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroupId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<RateGroupModel> GetRateGroupById(int RateGroupId)
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_RateGroupById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RateGroupId", RateGroupId);
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
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<RateGroupModel> GetAllRateGroup()
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllRateGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RateGroupModel obj = new RateGroupModel();
                            obj.RGroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["RGroupId"]);
                            obj.RGroupName = dsStateList.Tables[0].Rows[i]["RGroupName"].ToString();
                            obj.Description = dsStateList.Tables[0].Rows[i]["Description"].ToString();
                            obj.EffectFrom = dsStateList.Tables[0].Rows[i]["EffectFrom"].ToString();
                            obj.EffectTo = dsStateList.Tables[0].Rows[i]["EffectTo"].ToString();
                            stateList.Add(obj);
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
        public string InsertUpdateUserHospital(HospitalRegModel hospital)
        {
            string response = "";
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
        //Operator Starts Now
        public string InsertOperator(OperatorModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                    cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                    cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateOperator(OperatorModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Operator.Id);
                    cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                    cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                    cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteOperator(int OperatorId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", OperatorId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<OperatorModel> GetOperatorById(int OperatorId)
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
                            obj.OperatorDescription = dsStateList.Tables[0].Rows[i]["OperatorDescription"].ToString();
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<OperatorModel> GetAllOperator()
        {
            List<OperatorModel> stateList = new List<OperatorModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllOperator", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            OperatorModel obj = new OperatorModel();
                            obj.Id = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Id"]);
                            obj.OperatorName = dsStateList.Tables[0].Rows[i]["OperatorName"].ToString();
                            obj.OperatorCode = dsStateList.Tables[0].Rows[i]["OperatorCode"].ToString();
                            obj.OperatorDescription = dsStateList.Tables[0].Rows[i]["OperatorDescription"].ToString();
                            stateList.Add(obj);
                        }
                    return stateList;
                }
            }
        }
        //Operator Ends Now

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
        public string InsertUpdateLeadAgent(LeadAgentModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLeadAgent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentID", Operator.LeadAgentId);
                    cmd.Parameters.AddWithValue("@Name", Operator.Name);
                    cmd.Parameters.AddWithValue("@ContactNo", Operator.ContactNo);
                    cmd.Parameters.AddWithValue("@CommisionPercent", Operator.CommisionPercent);
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


        //Company Management Starts
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
        public string InsertUpdateCompany(CompanyModel Company)
        {
            string response = "";
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
        public string DeleteCompany(int Id)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        //Company Management Ends
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
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<SymptomModel>();
                    return stateList;
                }
            }
        }
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
    }
}
