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


    }
}
