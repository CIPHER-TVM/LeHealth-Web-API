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


        //
        public List<GenderModel> GetGender()
        {
            List<GenderModel> profList = new List<GenderModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetGender", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            GenderModel obj = new GenderModel();
                            obj.Id = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["Id"]);
                            obj.GenderName = dsCompany.Tables[0].Rows[i]["GenderName"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }



        public List<SalutationModel> GetSalutation()
        {
            List<SalutationModel> profList = new List<SalutationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSalutation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            SalutationModel obj = new SalutationModel();
                            obj.Id = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["Id"]);
                            obj.Salutation = dsCompany.Tables[0].Rows[i]["Salutation"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        public List<KinRelationModel> GetKinRelation()
        {
            List<KinRelationModel> profList = new List<KinRelationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetKinRelation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            KinRelationModel obj = new KinRelationModel();
                            obj.Id = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["Id"]);
                            obj.KinRelation = dsCompany.Tables[0].Rows[i]["KinRelation"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        //

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
                    DataSet dsmaritalStatus = new DataSet();
                    adapter.Fill(dsmaritalStatus);
                    con.Close();
                    if ((dsmaritalStatus != null) && (dsmaritalStatus.Tables.Count > 0) && (dsmaritalStatus.Tables[0] != null) && (dsmaritalStatus.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsmaritalStatus.Tables[0].Rows.Count; i++)
                        {
                            MaritalStatusModel obj = new MaritalStatusModel();
                            obj.Id = Convert.ToInt32(dsmaritalStatus.Tables[0].Rows[i]["Id"]);
                            obj.MaritalStatusCode = dsmaritalStatus.Tables[0].Rows[i]["MaritalStatusCode"].ToString();
                            obj.MaritalStatusDescription = dsmaritalStatus.Tables[0].Rows[i]["MaritalStatusDescription"].ToString();
                            maritalStatusList.Add(obj);
                        }
                    }
                    return maritalStatusList;
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
        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patient)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatients", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@ConsultantId", patient.ConsultantId);
                    cmd.Parameters.AddWithValue("@RegNo", patient.RegNo);
                    cmd.Parameters.AddWithValue("@Mobile", patient.Mobile);
                    cmd.Parameters.AddWithValue("@RegFromDate", patient.RegDateFrom);
                    cmd.Parameters.AddWithValue("@RegToDate", patient.RegDateTo);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@PIN", patient.PIN);
                    cmd.Parameters.AddWithValue("@PolicyNo", patient.PolicyNo);
                    cmd.Parameters.AddWithValue("@IdentityNo", patient.IdentityNo);
                    cmd.Parameters.AddWithValue("@BranchId", patient.BranchId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();
                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsPatientList.Tables[0].Rows.Count; i++)
                        {
                            AllPatientModel obj = new AllPatientModel();
                            obj.PatientId = Convert.ToInt32(dsPatientList.Tables[0].Rows[i]["PatientId"]);
                            obj.RegNo = dsPatientList.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.RegDate = Convert.ToDateTime(dsPatientList.Tables[0].Rows[i]["RegDate"]);
                            obj.RegisteredDate = dsPatientList.Tables[0].Rows[i]["RegisteredDate"].ToString();
                            obj.AgeInYears = dsPatientList.Tables[0].Rows[i]["AgeInYears"].ToString();
                            obj.PatientName = dsPatientList.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Age = dsPatientList.Tables[0].Rows[i]["Age"].ToString();
                            obj.Mobile = dsPatientList.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Address = dsPatientList.Tables[0].Rows[i]["Address"].ToString();
                            obj.SponsorName = dsPatientList.Tables[0].Rows[i]["SponsorName"].ToString();
                            obj.Consultant = dsPatientList.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.PolicyNo = dsPatientList.Tables[0].Rows[i]["PolicyNo"].ToString();
                            obj.EmiratesId = dsPatientList.Tables[0].Rows[i]["EmirateID"].ToString();
                            obj.SponsorId = dsPatientList.Tables[0].Rows[i]["SponsorId"].ToString();
                            patientList.Add(obj);
                        }
                    }
                    return patientList;
                }
            }

        }

        public string SaveReRegistration(PatientModel reregistration)
        {
            string response = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("stLH_InsertPatRegs", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RegId", 0);
                        cmd.Parameters.AddWithValue("@RegDate", reregistration.RegDate);
                        cmd.Parameters.AddWithValue("@PatientId", reregistration.PatientId);
                        cmd.Parameters.AddWithValue("@ItemId", reregistration.ItemId);
                        cmd.Parameters.AddWithValue("@RegAmount", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@UserId", reregistration.UserId);
                        cmd.Parameters.AddWithValue("@LocationId", reregistration.LocationId);
                        cmd.Parameters.AddWithValue("@SessionId", reregistration.SessionId);
                        SqlParameter patientIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(patientIdParam);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retDesc);
                        con.Open();
                        var isInserted = cmd.ExecuteNonQuery();
                        con.Close();
                        response = retDesc.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message.ToString();
            }
            return response;
        }


        public List<PatientModel> GetRegsteredDataById(int patid)
        {
            PatientModel obj = new PatientModel();
            List<PatientModel> patientData = new List<PatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("stLH_GetRegsteredDataById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsRate = new DataSet();
                adapter.Fill(dsRate);
                con.Close();
                if ((dsRate != null) && (dsRate.Tables.Count > 0) && (dsRate.Tables[0] != null) && (dsRate.Tables[0].Rows.Count > 0))
                {
                    obj.Salutation = dsRate.Tables[0].Rows[0]["Salutation"].ToString();
                    obj.FirstName = dsRate.Tables[0].Rows[0]["FirstName"].ToString();
                    obj.MiddleName = dsRate.Tables[0].Rows[0]["MiddleName"].ToString();
                    obj.LastName = dsRate.Tables[0].Rows[0]["LastName"].ToString();
                    obj.DOB = dsRate.Tables[0].Rows[0]["DOB"].ToString();
                    obj.Gender = dsRate.Tables[0].Rows[0]["Gender"].ToString();
                    obj.MaritalStatus = dsRate.Tables[0].Rows[0]["MaritalStatus"].ToString();
                    obj.KinName = dsRate.Tables[0].Rows[0]["KinName"].ToString();
                    obj.KinRelation = dsRate.Tables[0].Rows[0]["KinRelation"].ToString();
                    obj.Mobile = dsRate.Tables[0].Rows[0]["Mobile"].ToString();
                    obj.ResNo = dsRate.Tables[0].Rows[0]["ResNo"].ToString();
                    obj.OffNo = dsRate.Tables[0].Rows[0]["OffNo"].ToString();
                    obj.Remarks = dsRate.Tables[0].Rows[0]["Remarks"].ToString();
                    obj.Email = dsRate.Tables[0].Rows[0]["Email"].ToString();
                    obj.FaxNo = dsRate.Tables[0].Rows[0]["FaxNo"].ToString();
                    obj.Religion = dsRate.Tables[0].Rows[0]["Religion"].ToString();
                    obj.ProfId = (dsRate.Tables[0].Rows[0]["ProfId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsRate.Tables[0].Rows[0]["ProfId"]);
                    obj.CmpId = (dsRate.Tables[0].Rows[0]["CmpId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsRate.Tables[0].Rows[0]["CmpId"]);
                    obj.RGroupId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["RGroupId"]);
                    obj.Mode = dsRate.Tables[0].Rows[0]["Mode"].ToString();
                    obj.NationalityId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["NationalityId"]);
                    obj.RefBy = dsRate.Tables[0].Rows[0]["ReferredBy"].ToString();
                    obj.PrivilegeCard = Convert.ToBoolean(dsRate.Tables[0].Rows[0]["PrivilegeCard"]);
                    obj.UserId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["UserId"]);
                    obj.WorkEnvironMent = dsRate.Tables[0].Rows[0]["WorkEnvironment"].ToString();
                    obj.ProfessionalNoxious = dsRate.Tables[0].Rows[0]["ProfessionalNoxious"].ToString();
                    obj.ProfessionalExperience = dsRate.Tables[0].Rows[0]["ProfessionalExperience"].ToString();
                    obj.LocationId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["LocationId"]);
                    obj.VisaTypeId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["VisaTypeID"]);
                    obj.BranchId = Convert.ToInt32(dsRate.Tables[0].Rows[0]["BranchId"]);
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("stLH_GetPatIdentity", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@PatientId", patid);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataSet dsRate2 = new DataSet();
                adapter2.Fill(dsRate2);
                con.Close();
                List<RegIdentitiesModel> rim = new List<RegIdentitiesModel>();
                if ((dsRate2 != null) && (dsRate2.Tables.Count > 0) && (dsRate2.Tables[0] != null) && (dsRate2.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < dsRate2.Tables[0].Rows.Count; i++)
                    {
                        RegIdentitiesModel obj2 = new RegIdentitiesModel();
                        obj2.IdentityType = Convert.ToInt32(dsRate2.Tables[0].Rows[i]["IdentityType"]);
                        obj2.IdentityNo = dsRate2.Tables[0].Rows[i]["IdentityNo"].ToString();
                        obj2.PatientId = Convert.ToInt32(dsRate2.Tables[0].Rows[i]["PatientId"]);
                        rim.Add(obj2);
                    }
                }

                con.Open();
                SqlCommand cmd3 = new SqlCommand("stLH_GetPatAddress", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@PatientId", patid);
                SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
                DataSet dsRate3 = new DataSet();
                adapter3.Fill(dsRate3);
                con.Close();
                List<RegAddressModel> ram = new List<RegAddressModel>();
                if ((dsRate3 != null) && (dsRate3.Tables.Count > 0) && (dsRate3.Tables[0] != null) && (dsRate3.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < dsRate3.Tables[0].Rows.Count; i++)
                    {
                        RegAddressModel obj3 = new RegAddressModel();
                        obj3.PatientId = Convert.ToInt32(dsRate3.Tables[0].Rows[i]["PatientId"]);
                        obj3.AddType = Convert.ToInt32(dsRate3.Tables[0].Rows[i]["AddType"]);
                        obj3.Address1 = dsRate3.Tables[0].Rows[i]["Address1"].ToString();
                        obj3.Address2 = dsRate3.Tables[0].Rows[i]["Address2"].ToString();
                        obj3.Street = dsRate3.Tables[0].Rows[i]["Street"].ToString();
                        obj3.PlacePO = dsRate3.Tables[0].Rows[i]["PlacePO"].ToString();
                        obj3.PIN = dsRate3.Tables[0].Rows[i]["PIN"].ToString();
                        obj3.City = dsRate3.Tables[0].Rows[i]["City"].ToString();
                        obj3.State = dsRate3.Tables[0].Rows[i]["State"].ToString();
                        obj3.CountryId = Convert.ToInt32(dsRate3.Tables[0].Rows[i]["CountryId"]);
                        ram.Add(obj3);
                    }
                }
                obj.RegIdentities = rim;
                obj.RegAddress = ram;
                patientData.Add(obj);
                return patientData;
            }
        }

        public string BlockPatient(PatientModel patient)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_BlockPatient", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                        cmd.Parameters.AddWithValue("@BlockReason", patient.BlockReason);
                        cmd.Parameters.AddWithValue("@UserId", patient.UserId);
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
                        if (Convert.ToInt32(ret) == patient.PatientId)
                        {
                            response = "success";
                        }
                        else
                        {
                            response = descrip;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }

        public string UnblockPatient(PatientModel patient) 
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UnblockPatient", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                        cmd.Parameters.AddWithValue("@UserId", patient.UserId);
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
                        if (Convert.ToInt32(ret) == patient.PatientId)
                        {
                            response = "success";
                        }
                        else
                        {
                            response = descrip;
                        }
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
