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
                    DataSet dsGender = new DataSet();
                    adapter.Fill(dsGender);
                    con.Close();
                    if ((dsGender != null) && (dsGender.Tables.Count > 0) && (dsGender.Tables[0] != null) && (dsGender.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsGender.Tables[0].Rows.Count; i++)
                        {
                            GenderModel obj = new GenderModel();
                            obj.Id = Convert.ToInt32(dsGender.Tables[0].Rows[i]["Id"]);
                            obj.GenderName = dsGender.Tables[0].Rows[i]["GenderName"].ToString();
                            genderList.Add(obj);
                        }
                    }
                    return genderList;
                }
            }
        }
        public List<SalutationModel> GetSalutation()
        {
            List<SalutationModel> salutationList = new List<SalutationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSalutation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsSalutation = new DataSet();
                    adapter.Fill(dsSalutation);
                    con.Close();
                    if ((dsSalutation != null) && (dsSalutation.Tables.Count > 0) && (dsSalutation.Tables[0] != null) && (dsSalutation.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsSalutation.Tables[0].Rows.Count; i++)
                        {
                            SalutationModel obj = new SalutationModel();
                            obj.Id = Convert.ToInt32(dsSalutation.Tables[0].Rows[i]["Id"]);
                            obj.Salutation = dsSalutation.Tables[0].Rows[i]["Salutation"].ToString();
                            salutationList.Add(obj);
                        }
                    }
                    return salutationList;
                }
            }
        }
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
                    DataSet dsKinRelation = new DataSet();
                    adapter.Fill(dsKinRelation);
                    con.Close();
                    if ((dsKinRelation != null) && (dsKinRelation.Tables.Count > 0) && (dsKinRelation.Tables[0] != null) && (dsKinRelation.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsKinRelation.Tables[0].Rows.Count; i++)
                        {
                            KinRelationModel obj = new KinRelationModel();
                            obj.Id = Convert.ToInt32(dsKinRelation.Tables[0].Rows[i]["Id"]);
                            obj.KinRelation = dsKinRelation.Tables[0].Rows[i]["KinRelation"].ToString();
                            kinRelationList.Add(obj);
                        }
                    }
                    return kinRelationList;
                }
            }
        }
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
                            obj.MaritalStatusDescription = dsmaritalStatus.Tables[0].Rows[i]["MaritalStatusDescription"].ToString();
                            maritalStatusList.Add(obj);
                        }
                    }
                    return maritalStatusList;
                }
            }
        }
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
                    DataSet dscommunicationType = new DataSet();
                    adapter.Fill(dscommunicationType);
                    con.Close();
                    if ((dscommunicationType != null) && (dscommunicationType.Tables.Count > 0) && (dscommunicationType.Tables[0] != null) && (dscommunicationType.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dscommunicationType.Tables[0].Rows.Count; i++)
                        {
                            CommunicationTypeModel obj = new CommunicationTypeModel();
                            obj.Id = Convert.ToInt32(dscommunicationType.Tables[0].Rows[i]["Id"]);
                            obj.CommunicationType = dscommunicationType.Tables[0].Rows[i]["CommunicationType"].ToString();
                            communicationTypeList.Add(obj);
                        }
                    }
                    return communicationTypeList;
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
                            obj.RegDate = dsPatientList.Tables[0].Rows[i]["RegDate"].ToString().ToString();
                            obj.AgeInYears = dsPatientList.Tables[0].Rows[i]["AgeInYears"].ToString();
                            obj.PatientName = dsPatientList.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Age = dsPatientList.Tables[0].Rows[i]["Age"].ToString();
                            obj.Gender = Convert.ToInt32(dsPatientList.Tables[0].Rows[i]["Gender"]);
                            obj.GenderName = dsPatientList.Tables[0].Rows[i]["GenderName"].ToString();
                            obj.Email = dsPatientList.Tables[0].Rows[i]["Email"].ToString();
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


        public List<PatientModel> GetRegisteredDataById(int patid)
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
                DataSet dsPatientData = new DataSet();
                adapter.Fill(dsPatientData);
                con.Close();
                if ((dsPatientData != null) && (dsPatientData.Tables.Count > 0) && (dsPatientData.Tables[0] != null) && (dsPatientData.Tables[0].Rows.Count > 0))
                {
                    obj.Salutation = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["Salutation"]);
                    obj.FirstName = dsPatientData.Tables[0].Rows[0]["FirstName"].ToString();
                    obj.MiddleName = dsPatientData.Tables[0].Rows[0]["MiddleName"].ToString();
                    obj.LastName = dsPatientData.Tables[0].Rows[0]["LastName"].ToString();
                    obj.DOB = dsPatientData.Tables[0].Rows[0]["DOB"].ToString().Substring(0, 10);
                    obj.Gender = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["Gender"]);
                    obj.MaritalStatus = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["MaritalStatus"]);
                    obj.KinName = dsPatientData.Tables[0].Rows[0]["KinName"].ToString();
                    obj.KinRelation = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["KinRelation"]);
                    obj.Mobile = dsPatientData.Tables[0].Rows[0]["Mobile"].ToString();
                    obj.ResNo = dsPatientData.Tables[0].Rows[0]["ResNo"].ToString();
                    obj.OffNo = dsPatientData.Tables[0].Rows[0]["OffNo"].ToString();
                    obj.Remarks = dsPatientData.Tables[0].Rows[0]["Remarks"].ToString();
                    obj.Email = dsPatientData.Tables[0].Rows[0]["Email"].ToString();
                    obj.FaxNo = dsPatientData.Tables[0].Rows[0]["FaxNo"].ToString();
                    obj.Religion = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["Religion"]);
                    obj.ProfId = (dsPatientData.Tables[0].Rows[0]["ProfId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["ProfId"]);
                    obj.CmpId = (dsPatientData.Tables[0].Rows[0]["CmpId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["CmpId"]);
                    obj.RGroupId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["RGroupId"]);
                    obj.Mode = dsPatientData.Tables[0].Rows[0]["Mode"].ToString();
                    obj.NationalityId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["NationalityId"]);
                    obj.RefBy = dsPatientData.Tables[0].Rows[0]["ReferredBy"].ToString();
                    obj.PrivilegeCard = Convert.ToBoolean(dsPatientData.Tables[0].Rows[0]["PrivilegeCard"]);
                    obj.UserId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["UserId"]);
                    obj.WorkEnvironMent = dsPatientData.Tables[0].Rows[0]["WorkEnvironment"].ToString();
                    obj.ProfessionalNoxious = dsPatientData.Tables[0].Rows[0]["ProfessionalNoxious"].ToString();
                    obj.ProfessionalExperience = dsPatientData.Tables[0].Rows[0]["ProfessionalExperience"].ToString();
                    obj.LocationId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["LocationId"]);
                    obj.VisaTypeId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["VisaTypeID"]);
                    obj.CommunicationType = (dsPatientData.Tables[0].Rows[0]["CommunicationType"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["CommunicationType"]);// Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["CommunicationType"]);
                    obj.BranchId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["BranchId"]);
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("stLH_GetPatIdentity", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@PatientId", patid);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataSet dsIdentity = new DataSet();
                adapter2.Fill(dsIdentity);
                con.Close();
                List<RegIdentitiesModel> rim = new List<RegIdentitiesModel>();
                if ((dsIdentity != null) && (dsIdentity.Tables.Count > 0) && (dsIdentity.Tables[0] != null) && (dsIdentity.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < dsIdentity.Tables[0].Rows.Count; i++)
                    {
                        RegIdentitiesModel objIdentity = new RegIdentitiesModel();
                        objIdentity.IdentityType = Convert.ToInt32(dsIdentity.Tables[0].Rows[i]["IdentityType"]);
                        objIdentity.IdentityNo = dsIdentity.Tables[0].Rows[i]["IdentityNo"].ToString();
                        objIdentity.PatientId = Convert.ToInt32(dsIdentity.Tables[0].Rows[i]["PatientId"]);
                        rim.Add(objIdentity);
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

        //INSERT UPDATE PATIENT
        public string InsertPatient(PatientRegModel patientDetail)
        {
            SqlTransaction transaction;
            string response = "";
            int IsUpdate = 0;
            if (patientDetail.PatientId > 0)
            {
                IsUpdate = 1;
            }
            else
            {
                IsUpdate = 0;
            }
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                transaction = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("stLH_InsertPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
                cmd.Parameters.AddWithValue("@RegNo", patientDetail.RegNo);
                cmd.Parameters.AddWithValue("@RegDate", patientDetail.RegDate);
                cmd.Parameters.AddWithValue("@Salutation", patientDetail.Salutation);
                cmd.Parameters.AddWithValue("@FirstName", patientDetail.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", patientDetail.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", patientDetail.LastName);
                cmd.Parameters.AddWithValue("@DOB", patientDetail.DOB);
                cmd.Parameters.AddWithValue("@Gender", patientDetail.Gender);
                cmd.Parameters.AddWithValue("@MaritalStatus", patientDetail.MaritalStatus);
                cmd.Parameters.AddWithValue("@KinName", patientDetail.KinName);
                cmd.Parameters.AddWithValue("@KinRelation", patientDetail.KinRelation);
                cmd.Parameters.AddWithValue("@KinContactNo", patientDetail.KinContactNo);
                cmd.Parameters.AddWithValue("@Mobile", patientDetail.Mobile);
                cmd.Parameters.AddWithValue("@ResNo", patientDetail.ResNo);
                cmd.Parameters.AddWithValue("@OffNo", patientDetail.OffNo);
                cmd.Parameters.AddWithValue("@Email", patientDetail.Email);
                cmd.Parameters.AddWithValue("@FaxNo", patientDetail.FaxNo);
                cmd.Parameters.AddWithValue("@Religion", patientDetail.Religion);
                cmd.Parameters.AddWithValue("@ProfId", patientDetail.ProfId);
                cmd.Parameters.AddWithValue("@CmpId", patientDetail.CmpId);
                cmd.Parameters.AddWithValue("@Status", patientDetail.Status);
                cmd.Parameters.AddWithValue("@PatState", patientDetail.PatState);
                cmd.Parameters.AddWithValue("@RGroupId", patientDetail.RGroupId);
                cmd.Parameters.AddWithValue("@Mode", patientDetail.Mode);
                cmd.Parameters.AddWithValue("@Remarks", patientDetail.Remarks);
                cmd.Parameters.AddWithValue("@NationalityId", patientDetail.NationalityId);
                cmd.Parameters.AddWithValue("@ConsultantId", patientDetail.ConsultantId);
                cmd.Parameters.AddWithValue("@Active", patientDetail.Active);
                cmd.Parameters.AddWithValue("@AppId", patientDetail.AppId);
                cmd.Parameters.AddWithValue("@RefBy", patientDetail.RefBy);
                cmd.Parameters.AddWithValue("@PrivilegeCard", patientDetail.PrivilegeCard);
                cmd.Parameters.AddWithValue("@UserId", patientDetail.UserId);
                cmd.Parameters.AddWithValue("@LocationId", patientDetail.LocationId);
                cmd.Parameters.AddWithValue("@ProfilePicLocation", patientDetail.PatientPhotoName);
                cmd.Parameters.AddWithValue("@WorkEnvironment", patientDetail.WorkEnvironMent);
                cmd.Parameters.AddWithValue("@ProfessionalExperience", patientDetail.ProfessionalExperience);
                cmd.Parameters.AddWithValue("@ProfessionalNoxious", patientDetail.ProfessionalNoxious);
                cmd.Parameters.AddWithValue("@VisaTypeId", patientDetail.VisaTypeId);
                cmd.Parameters.AddWithValue("@CommunicationType", patientDetail.CommunicationType);
                cmd.Parameters.AddWithValue("@SessionId", patientDetail.SessionId);
                cmd.Parameters.AddWithValue("@BranchId", patientDetail.BranchId);
                cmd.Parameters.AddWithValue("@RetRegNo", patientDetail.RetRegNo);
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
                cmd.Transaction = transaction;
                try
                {
                    cmd.ExecuteNonQuery();
                    int patientId = (int)patientIdParam.Value;
                    string descr = retDesc.Value.ToString();
                    if (patientId > 0)//Inserted / Updated Successfully
                    {
                        transaction.Commit();
                        for (int i = 0; i < patientDetail.RegIdentities.Count; i++)
                        {
                            SqlCommand savepatidentity1CMD = new SqlCommand("stLH_InsertPatIdentity", con);
                            savepatidentity1CMD.CommandType = CommandType.StoredProcedure;
                            savepatidentity1CMD.Parameters.AddWithValue("@PatientId", patientId);
                            savepatidentity1CMD.Parameters.AddWithValue("@IdentityType", patientDetail.RegIdentities[i].IdentityType);
                            savepatidentity1CMD.Parameters.AddWithValue("@IdentityNo", patientDetail.RegIdentities[i].IdentityNo);
                            SqlParameter patidReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter patidReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            savepatidentity1CMD.Parameters.Add(patidReturn1);
                            savepatidentity1CMD.Parameters.Add(patidReturnDesc1);
                            var isInserted = savepatidentity1CMD.ExecuteNonQuery();
                            int patidReturn1V = Convert.ToInt32(patidReturn1.Value);
                            var patidReturnDesc1V = patidReturnDesc1.Value.ToString();
                        }
                        //SEVEN TIMES END


                        //THREE TIMES START

                        for (int i = 0; i < patientDetail.RegAddress.Count; i++)
                        {
                            SqlCommand savepataddress1CMD = new SqlCommand("stLH_InsertPatAddress", con);
                            savepataddress1CMD.CommandType = CommandType.StoredProcedure;
                            savepataddress1CMD.Parameters.AddWithValue("@PatientId", patientId);
                            savepataddress1CMD.Parameters.AddWithValue("@AddType", patientDetail.RegAddress[i].AddType);
                            savepataddress1CMD.Parameters.AddWithValue("@Street", patientDetail.RegAddress[i].Street);
                            savepataddress1CMD.Parameters.AddWithValue("@PlacePO", patientDetail.RegAddress[i].PlacePO);
                            savepataddress1CMD.Parameters.AddWithValue("@City", patientDetail.RegAddress[i].City);
                            savepataddress1CMD.Parameters.AddWithValue("@PIN", patientDetail.RegAddress[i].PIN);
                            savepataddress1CMD.Parameters.AddWithValue("@CountryId", patientDetail.RegAddress[i].CountryId);
                            savepataddress1CMD.Parameters.AddWithValue("@Address1", patientDetail.RegAddress[i].Address1);
                            savepataddress1CMD.Parameters.AddWithValue("@Address2", patientDetail.RegAddress[i].Address2);
                            savepataddress1CMD.Parameters.AddWithValue("@State", patientDetail.RegAddress[i].State);
                            SqlParameter patadrReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter patadrReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            savepataddress1CMD.Parameters.Add(patadrReturn1);
                            savepataddress1CMD.Parameters.Add(patadrReturnDesc1);
                            var isInsertedAdr1 = savepataddress1CMD.ExecuteNonQuery();
                            int patadrReturn1V = Convert.ToInt32(patadrReturn1.Value);
                            var patadrReturnDesc1V = patadrReturnDesc1.Value.ToString();
                        }

                        //THREE TIMES END

                        //FileUploadStarts
                        for (int k = 0; k < patientDetail.PatientDocNames.Count; k++)
                        {
                            SqlCommand savepatdocCMD = new SqlCommand("stLH_InsertPatRegFiles", con);
                            savepatdocCMD.CommandType = CommandType.StoredProcedure;
                            savepatdocCMD.Parameters.AddWithValue("@PatientId", patientId);
                            savepatdocCMD.Parameters.AddWithValue("@FilePath", patientDetail.PatientDocNames[k]);
                            var isInserted = savepatdocCMD.ExecuteNonQuery();
                        }
                        //FileUploadEnds

                        //IF INSERT ONLY STARTS
                        if (IsUpdate == 0)
                        {
                            SqlCommand patientRegscmd = new SqlCommand("stLH_InsertPatRegs", con);
                            patientRegscmd.CommandType = CommandType.StoredProcedure;
                            patientRegscmd.Parameters.AddWithValue("@RegId", DBNull.Value);
                            patientRegscmd.Parameters.AddWithValue("@RegDate", patientDetail.RegDate);
                            patientRegscmd.Parameters.AddWithValue("@PatientId", patientId);
                            patientRegscmd.Parameters.AddWithValue("@RegAmount", DBNull.Value);
                            patientRegscmd.Parameters.AddWithValue("@LocationId", patientDetail.LocationId);
                            patientRegscmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                            patientRegscmd.Parameters.AddWithValue("@UserId", patientDetail.UserId);
                            patientRegscmd.Parameters.AddWithValue("@SessionId", patientDetail.SessionId);
                            patientRegscmd.Parameters.AddWithValue("@ItemId", patientDetail.ItemId);
                            SqlParameter returnParam = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            patientRegscmd.Parameters.Add(returnParam);
                            SqlParameter returnDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            patientRegscmd.Parameters.Add(returnDesc);
                            var isInsertedVV = patientRegscmd.ExecuteNonQuery();
                            var patregsresponse = returnDesc.Value.ToString();
                            int RegId = Convert.ToInt32(returnParam.Value);
                            if (RegId > 0)
                            {
                                if (patientDetail.Consultation.EnableConsultation == true)//checking consultation true and reg id is created
                                {
                                    patientDetail.Consultation.PatientId = patientDetail.PatientId;
                                    SqlCommand patientConsultationCmd = InsertConsultation(patientDetail.Consultation);
                                    patientConsultationCmd.Connection = con;
                                    var isUpdated = patientConsultationCmd.ExecuteNonQuery();
                                }
                                SqlCommand updateRegNoCmd = UPDATERegNo();
                                updateRegNoCmd.Connection = con;
                                updateRegNoCmd.ExecuteNonQuery();
                                //transaction.Commit();
                                response = patientId.ToString();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }
                        else
                        {
                            response = patientId.ToString();//"success";
                        }
                        //IF INSERT ONLY ENDS
                    }
                    else
                    {
                        transaction.Rollback();
                        response = descr;
                    }
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    response = ex.Message.ToString();
                }
                con.Close();
            }
            return response;
        }
        public SqlCommand InsertConsultation(ConsultationModel consultations)
        {
            using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultation"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsultationId", DBNull.Value);
                cmd.Parameters.AddWithValue("@ConsultDate", consultations.ConsultDate);
                cmd.Parameters.AddWithValue("@AppId", consultations.AppId);
                cmd.Parameters.AddWithValue("@ConsultantId", consultations.ConsultantId);
                cmd.Parameters.AddWithValue("@PatientId", consultations.PatientId);
                cmd.Parameters.AddWithValue("@Symptoms", consultations.Symptoms);
                cmd.Parameters.AddWithValue("@ConsultFee", consultations.ConsultFee);
                cmd.Parameters.AddWithValue("@ConsultType", consultations.ConsultType);
                cmd.Parameters.AddWithValue("@EmerFee", consultations.EmerFee);
                cmd.Parameters.AddWithValue("@Emergency", consultations.Emergency);
                cmd.Parameters.AddWithValue("@ItemId", consultations.ItemId);
                cmd.Parameters.AddWithValue("@AgentId", consultations.AgentId);
                cmd.Parameters.AddWithValue("@LocationId", consultations.LocationId);
                cmd.Parameters.AddWithValue("@LeadAgentId", consultations.LeadAgentId);
                cmd.Parameters.AddWithValue("@InitiateCall", consultations.InitiateCall);
                cmd.Parameters.AddWithValue("@UserId", consultations.UserId);
                cmd.Parameters.AddWithValue("@RetSeqNo", consultations.RetSeqNo);
                cmd.Parameters.AddWithValue("@SessionId", consultations.SessionId);
                cmd.Parameters.AddWithValue("@RetVal", consultations.RetVal);
                cmd.Parameters.AddWithValue("@RetDesc", consultations.RetDesc);
                return cmd;
            }
        }
        public SqlCommand UPDATERegNo()
        {
            using (SqlCommand cmd = new SqlCommand("stLH_AutoNumber"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumId", "REG-NO");
                SqlParameter outputIdParam = new SqlParameter("@NewNo", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                return cmd;
            }
        }
    }
}
