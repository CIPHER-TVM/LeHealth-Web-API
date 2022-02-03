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
using System.Net;
using System.IO;

namespace LeHealth.Core.DataManager
{
    public class RegistrationManager : IRegistrationManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public RegistrationManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
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
        
        /// <summary>
        /// Get All details of patient.Not using now. Instead of this API SearchPatientInList is calling
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Searching Patient details with patient name,consultant id, mobile, Reg no identiy number ,Reg Date ,Pin,Policy No in Patient Main Page.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patient)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatients", con))
                {
                    con.Open();
                    //DateTime oldFrom = DateTime.Parse(patient.RegDateFrom.Trim());
                    //patient.RegDateFrom = oldFrom.ToString("yyyy-MM-dd");
                    //DateTime oldTo = DateTime.Parse(patient.RegDateTo.Trim()); 
                    //patient.RegDateTo = oldTo.ToString("yyyy-MM-dd");
                    DateTime oldFrom = DateTime.ParseExact(patient.RegDateFrom.Trim(), "dd-MM-yyyy", null);
                    patient.RegDateFrom = oldFrom.ToString("yyyy-MM-dd");

                    DateTime oldTo = DateTime.ParseExact(patient.RegDateTo.Trim(), "dd-MM-yyyy", null);
                    patient.RegDateTo = oldTo.ToString("yyyy-MM-dd");

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", patient.Name.Trim());
                    cmd.Parameters.AddWithValue("@ConsultantId", patient.ConsultantId);
                    cmd.Parameters.AddWithValue("@RegNo", patient.RegNo.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", patient.Mobile.Trim());
                    cmd.Parameters.AddWithValue("@RegFromDate", patient.RegDateFrom);
                    cmd.Parameters.AddWithValue("@RegToDate", patient.RegDateTo);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone.Trim());
                    cmd.Parameters.AddWithValue("@Address", patient.Address.Trim());
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
                            obj.Pin = dsPatientList.Tables[0].Rows[i]["PIN"].ToString();
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
                            obj.Active = Convert.ToInt32(dsPatientList.Tables[0].Rows[i]["Active"]);
                            patientList.Add(obj);
                        }
                    }
                    return patientList;
                }
            }
        }
        /// <summary>
        /// Re Registration Data Save
        /// </summary>
        /// <param name="reregistration"></param>
        /// <returns>Success Message or Error description</returns>
        public string SaveReRegistration(PatientModel reregistration)
        {
            string response = string.Empty;
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
        /// <summary>
        /// Get Patient Profile,address,Identity, Consultation Data
        /// </summary>
        /// <param name="patid">Primary key of LH_Patient, PatientId </param>
        /// <returns></returns>
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
                    obj.PatientName = dsPatientData.Tables[0].Rows[0]["PatientName"].ToString();
                    obj.RegNo = dsPatientData.Tables[0].Rows[0]["RegNo"].ToString();
                    obj.RegDate = dsPatientData.Tables[0].Rows[0]["RegDate"].ToString().Replace("/","-");
                    obj.DOB = dsPatientData.Tables[0].Rows[0]["DOB"].ToString().Substring(0, 10);
                    obj.AgeInMonth = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["AgeInMonth"]);
                    obj.AgeInYear = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["AgeInYear"]);
                    obj.Gender = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["Gender"]);
                    obj.MaritalStatus = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["MaritalStatus"]);
                    obj.KinName = dsPatientData.Tables[0].Rows[0]["KinName"].ToString();
                    obj.KinRelation = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["KinRelation"]);
                    obj.KinContactNo = dsPatientData.Tables[0].Rows[0]["KinContactNo"].ToString();
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
                    obj.RGroupName = dsPatientData.Tables[0].Rows[0]["RGroupName"].ToString();
                    obj.ItemId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["ItemId"]);
                    obj.ItemName = dsPatientData.Tables[0].Rows[0]["ItemName"].ToString();
                    obj.MaritalStatusDescription = dsPatientData.Tables[0].Rows[0]["MaritalStatusDescription"].ToString();
                    obj.GenderName = dsPatientData.Tables[0].Rows[0]["GenderName"].ToString();
                    obj.VisaType = dsPatientData.Tables[0].Rows[0]["VisaType"].ToString();
                    obj.ProfName = dsPatientData.Tables[0].Rows[0]["ProfName"].ToString();
                    obj.NationalityName = dsPatientData.Tables[0].Rows[0]["NationalityName"].ToString();
                    obj.SchemeName = string.Empty;
                    obj.CmpName = dsPatientData.Tables[0].Rows[0]["CmpName"].ToString();
                    obj.KinContactNo = dsPatientData.Tables[0].Rows[0]["KinContactNo"].ToString();
                    obj.OtherReasons = dsPatientData.Tables[0].Rows[0]["Symptoms"].ToString();
                    obj.DepartmentId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["DeptId"]);
                    obj.ConsultantId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["ConsultantId"]);
                    obj.DepartmentName = dsPatientData.Tables[0].Rows[0]["DeptName"].ToString();
                    obj.ConsultantName = dsPatientData.Tables[0].Rows[0]["ConsultantName"].ToString();
                    obj.ConsultationId = Convert.ToInt32(dsPatientData.Tables[0].Rows[0]["ConsultationId"]);
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
                        obj3.StateName = dsRate3.Tables[0].Rows[i]["StateName"].ToString();
                        obj3.CountryName = dsRate3.Tables[0].Rows[i]["CountryName"].ToString();
                        obj3.CountryId = Convert.ToInt32(dsRate3.Tables[0].Rows[i]["CountryId"]);
                        ram.Add(obj3);
                    }
                }
                con.Open();
                SqlCommand cmd4 = new SqlCommand("stLH_GetRegFileNameByPatientId", con);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.AddWithValue("@PatientId", patid);
                SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);
                DataSet ds4 = new DataSet();
                adapter4.Fill(ds4);
                con.Close();
                List<RegDocLocationModel> doclistobj = new List<RegDocLocationModel>();
                if ((ds4 != null) && (ds4.Tables.Count > 0) && (ds4.Tables[0] != null) && (ds4.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                    {
                        RegDocLocationModel obj4 = new RegDocLocationModel();
                        obj4.Id = Convert.ToInt32(ds4.Tables[0].Rows[i]["Id"]);
                        obj4.FilePath = _uploadpath + ds4.Tables[0].Rows[i]["FilePath"].ToString();
                        obj4.FileOriginalName = _uploadpath + ds4.Tables[0].Rows[i]["OriginalFileName"].ToString();
                        doclistobj.Add(obj4);
                    }
                }
                List<RegSymptomsModel> SymptomsList = new List<RegSymptomsModel>();
                if (obj.ConsultationId != null)
                {
                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("GetSymptomByConsultationId", con);
                    cmd5.CommandType = CommandType.StoredProcedure;
                    cmd5.Parameters.AddWithValue("@ConsultationId", obj.ConsultationId);
                    SqlDataAdapter adapter5 = new SqlDataAdapter(cmd5);
                    DataSet ds5 = new DataSet();
                    adapter5.Fill(ds5);
                    con.Close();
                    if ((ds5 != null) && (ds5.Tables.Count > 0) && (ds5.Tables[0] != null) && (ds5.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                        {
                            RegSymptomsModel rsm = new RegSymptomsModel();
                            rsm.SymptomId = Convert.ToInt32(ds5.Tables[0].Rows[0]["SymptomId"]);
                            SymptomsList.Add(rsm);
                        }
                    }

                }
                obj.RegIdentities = rim;
                obj.RegAddress = ram;
                obj.RegDocLocation = doclistobj;
                obj.Symptoms = SymptomsList;
                patientData.Add(obj);
                return patientData;
            }
        }
        /// <summary>
        /// Blocking a patient
        /// </summary>
        /// <param name="patient">PatientId is primary key of LH_Patient</param>
        /// <returns>Success or Error details</returns>
        public string BlockPatient(PatientModel patient)
        {
            string response = string.Empty;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeletePatRegFiles(int Id)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeletePatRegFiles", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        response = "success";

                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }
        /// <summary>
        /// Unblocking a patient
        /// </summary>
        /// <param name="patient">PatientId is primary key of LH_Patient</param>
        /// <returns> success or error details</returns>
        public string UnblockPatient(PatientModel patient)
        {
            string response = string.Empty;
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
        /// <summary>
        /// Save Patient Details,Consultation details(if added)
        /// </summary>
        /// <param name="patientDetail"></param>
        /// <returns>Error details or PatientId</returns>
        public List<PatientRegModel> InsertPatient(PatientRegModel patientDetail)
        {
            List<PatientRegModel> responselist = new List<PatientRegModel>();
            PatientRegModel responseobj = new PatientRegModel();
            SqlTransaction transaction;
            //string response = string.Empty;
            int IsUpdate = 0;
            if (patientDetail.PatientId > 0)
            {
                IsUpdate = 1;
            }
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                if (IsUpdate == 0 && patientDetail.IsManualRegNo == 0)
                {
                    for (int m = 0; m < 100; m++)
                    {
                        string rno = AutoregnoCreate();
                        if (rno != "duplicate")
                        {
                            patientDetail.RegNo = rno;
                            break;
                        }
                    }
                }
                con.Open();
                transaction = con.BeginTransaction();

                DateTime regDate = DateTime.ParseExact(patientDetail.RegDate.Trim(), "dd-MM-yyyy", null);
                patientDetail.RegDate = regDate.ToString("yyyy-MM-dd");

                DateTime dobDate = DateTime.ParseExact(patientDetail.DOB.Trim(), "dd-MM-yyyy", null);
                patientDetail.DOB = dobDate.ToString("yyyy-MM-dd");

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
                cmd.Parameters.AddWithValue("@Status", patientDetail.Status);//All Existing Rows Are 0 No details known
                cmd.Parameters.AddWithValue("@PatState", 0);//The Table column is not using Anywhere
                cmd.Parameters.AddWithValue("@RGroupId", patientDetail.RGroupId);
                cmd.Parameters.AddWithValue("@Mode", patientDetail.Mode);//R,N Two Modes Und. Details Ariyilla
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
                cmd.Parameters.AddWithValue("@RetRegNo", patientDetail.RetRegNo == null ? "" : patientDetail.RetRegNo);
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
                        if (patientDetail.RegDocLocation != null)
                        {
                            for (int k = 0; k < patientDetail.RegDocLocation.Count; k++)
                            {
                                SqlCommand savepatdocCMD = new SqlCommand("stLH_InsertPatRegFiles", con);
                                savepatdocCMD.CommandType = CommandType.StoredProcedure;
                                savepatdocCMD.Parameters.AddWithValue("@PatientId", patientId);
                                savepatdocCMD.Parameters.AddWithValue("@OriginalFilename", patientDetail.RegDocLocation[k].FileOriginalName);
                                savepatdocCMD.Parameters.AddWithValue("@FilePath", patientDetail.RegDocLocation[k].FilePath);
                                var isInserted = savepatdocCMD.ExecuteNonQuery();
                            }
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
                            patientRegscmd.Parameters.AddWithValue("@RegAmount", 0);
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
                                    patientDetail.Consultation.PatientId = patientId;
                                    SqlCommand patientRegConsultationSavecmd = new SqlCommand("stLH_InsertUpdateConsultation", con);
                                    patientRegConsultationSavecmd.CommandType = CommandType.StoredProcedure;
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ConsultationId", DBNull.Value);
                                    DateTime consultDate = DateTime.ParseExact(patientDetail.Consultation.ConsultDate.Trim(), "dd-MM-yyyy", null);
                                    patientDetail.Consultation.ConsultDate = consultDate.ToString("yyyy-MM-dd");
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ConsultDate", patientDetail.Consultation.ConsultDate);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@AppId", patientDetail.Consultation.AppId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ConsultantId", patientDetail.Consultation.ConsultantId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@PatientId", patientDetail.Consultation.PatientId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@Symptoms", patientDetail.Consultation.OtherReasonForVisit);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ConsultFee", patientDetail.Consultation.ConsultFee);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ConsultType", patientDetail.Consultation.ConsultType);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@EmerFee", patientDetail.Consultation.EmerFee);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@Emergency", patientDetail.Consultation.Emergency);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@ItemId", patientDetail.Consultation.ItemId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@AgentId", patientDetail.Consultation.AgentId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@LocationId", patientDetail.Consultation.LocationId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@LeadAgentId", patientDetail.Consultation.LeadAgentId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@InitiateCall", patientDetail.Consultation.InitiateCall);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@UserId", patientDetail.Consultation.UserId);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@RetSeqNo", patientDetail.Consultation.RetSeqNo);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@SessionId", patientDetail.Consultation.SessionId);
                                    SqlParameter patConsReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
                                    {
                                        Direction = ParameterDirection.Output
                                    };
                                    SqlParameter patConsReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                                    {
                                        Direction = ParameterDirection.Output
                                    };
                                    patientRegConsultationSavecmd.Parameters.Add(patConsReturn1);
                                    patientRegConsultationSavecmd.Parameters.Add(patConsReturnDesc1);
                                    var isInsertedCons = patientRegConsultationSavecmd.ExecuteNonQuery();
                                    int savedConsultationId = Convert.ToInt32(patConsReturn1.Value);
                                    var patadrReturnDesc1V = patConsReturnDesc1.Value.ToString();

                                    //Symptom Save Starts
                                    for (int b = 0; b < patientDetail.Symptoms.Count; b++)
                                    {
                                        SqlCommand savesymptomCMD = new SqlCommand("stLH_SaveConsultationSymptoms", con);
                                        savesymptomCMD.CommandType = CommandType.StoredProcedure;
                                        savesymptomCMD.Parameters.AddWithValue("@ConsultationId", savedConsultationId);
                                        savesymptomCMD.Parameters.AddWithValue("@SymptomId", patientDetail.Symptoms[b].SymptomId);
                                        var isInsertedSymptom1 = savesymptomCMD.ExecuteNonQuery();
                                    }
                                    //Symptom Save Ends
                                }

                                responseobj.PatientId = patientId;
                                responseobj.RegNo = patientDetail.RegNo;
                                responseobj.ErrorMessage = "success";
                                ////Call API Block Starts
                                //using (SqlCommand cmdy = new SqlCommand("stLH_GetNabidhRegisterPatient", con))
                                //{
                                //    cmdy.CommandType = CommandType.StoredProcedure;
                                //    cmdy.Parameters.AddWithValue("@PatientId", patientId);
                                //    SqlDataAdapter adaptery = new SqlDataAdapter(cmdy);
                                //    DataSet dsNabidh = new DataSet();
                                //    adaptery.Fill(dsNabidh);
                                //    if ((dsNabidh != null) && (dsNabidh.Tables.Count > 0) && (dsNabidh.Tables[0] != null) && (dsNabidh.Tables[0].Rows.Count > 0))
                                //    {
                                //        DataTable dtemp = dsNabidh.Tables[0];
                                //        string returnstr = CreateHeader(dtemp, "ADT^A28");
                                //        string xcvb = string.Empty;
                                //        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://developerstg.dha.gov.ae/api/nabidhtesting/hl7testutility?app_id=c8d2b83c&app_key=f8d2def2a72f005be96021920faa2c12");
                                //        httpWebRequest.ContentType = "text/plain";
                                //        httpWebRequest.Method = "POST";
                                //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                //        {
                                //            streamWriter.Write(returnstr);
                                //        }
                                //        var responsev = string.Empty;
                                //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                //        {
                                //            responsev = streamReader.ReadToEnd();
                                //        }
                                //        string xcde = string.Empty;
                                //    }
                                //}
                                ////Call API Block Ends
                            }
                            else
                            {
                                //transaction.Rollback();
                            }
                        }
                        else
                        {
                            responseobj.ErrorMessage = "success";
                            responseobj.PatientId = patientId;
                            responseobj.RegNo = patientDetail.RegNo;
                        }
                        //IF INSERT ONLY ENDS
                    }
                    else
                    {
                        transaction.Rollback();
                        responseobj.PatientId = 0;
                        responseobj.RegNo = "";
                        responseobj.ErrorMessage = descr;
                    }
                }
                catch (Exception ex)
                {
                    responseobj.PatientId = 0;
                    responseobj.RegNo = "";
                    responseobj.ErrorMessage = ex.Message.ToString();
                }
                con.Close();
            }
            responselist.Add(responseobj);
            return responselist;
        }

        public string UploadPatientDocuments(PatientRegModel patientDetail)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                try
                {
                    if (patientDetail.PatientPhotoName != "")
                    {
                        SqlCommand cmdup = new SqlCommand("stLH_ActionUpdateProfilePic", con);
                        cmdup.CommandType = CommandType.StoredProcedure;
                        cmdup.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
                        cmdup.Parameters.AddWithValue("@ProfilePicLocation", patientDetail.PatientPhotoName);
                        SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdup.Parameters.Add(retValV);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdup.Parameters.Add(retDesc);
                        var isUpdated = cmdup.ExecuteNonQuery();
                        var ret = retValV.Value;
                        var descrip = retDesc.Value.ToString();
                    }

                    if (patientDetail.RegDocLocation != null)
                    {
                        for (int k = 0; k < patientDetail.RegDocLocation.Count; k++)
                        {
                            SqlCommand savepatdocCMD = new SqlCommand("stLH_InsertPatRegFiles", con);
                            savepatdocCMD.CommandType = CommandType.StoredProcedure;
                            savepatdocCMD.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
                            savepatdocCMD.Parameters.AddWithValue("@OriginalFilename", patientDetail.RegDocLocation[k].FileOriginalName);
                            savepatdocCMD.Parameters.AddWithValue("@FilePath", patientDetail.RegDocLocation[k].FilePath);
                            var isInserted = savepatdocCMD.ExecuteNonQuery();
                        }
                    }
                    response = "success";
                }
                catch (Exception ex)
                {
                    response = ex.Message.ToString();
                }
                con.Close();
            }
            return response;
        }

        public string ValidateHL7(string nabidh)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://developerstg.dha.gov.ae/api/nabidhtesting/hl7testutility?app_id=c8d2b83c&app_key=f8d2def2a72f005be96021920faa2c12");
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(nabidh);
            }
            var responsev = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responsev = streamReader.ReadToEnd();
            }
            return responsev;
        }
        public string AutoregnoCreate()
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand autonumberCMD = new SqlCommand("stLH_AutoNumberReg", con);
                autonumberCMD.CommandType = CommandType.StoredProcedure;
                autonumberCMD.Parameters.AddWithValue("@NumId", "REG-NO");
                SqlParameter patidReturnDesc1 = new SqlParameter("@NewNo", SqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                autonumberCMD.Parameters.Add(patidReturnDesc1);
                con.Open();
                var isgenerated = autonumberCMD.ExecuteNonQuery();
                con.Close();
                var newregno = patidReturnDesc1.Value.ToString();
                return newregno;
            }
        }
        public List<AllPatientModel> ViewPatientFiles(int patientid)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetRegFileNameByPatientId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", patientid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();
                    List<RegDocLocationModel> fileList = new List<RegDocLocationModel>();
                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        for (int j = 0; j < dsPatientList.Tables[0].Rows.Count; j++)
                        {
                            RegDocLocationModel obj4 = new RegDocLocationModel();
                            obj4.Id = Convert.ToInt32(dsPatientList.Tables[0].Rows[j]["Id"]);
                            obj4.FilePath = _uploadpath + dsPatientList.Tables[0].Rows[j]["FilePath"].ToString();


                            var fileNameArray = obj4.FilePath.Split('.');
                            var extension = fileNameArray[(fileNameArray.Length - 1)];
                            string extname = extension.ToString().ToLower();
                            if (extname == "png" || extname == "jpeg" || extname == "jpg" || extension == "gif")
                            {
                                obj4.FileType = "image";
                            }
                            else if (extname == "pdf")
                            {
                                obj4.FileType = "pdf";
                            }
                            else
                            {
                                obj4.FileType = "document";
                            }
                            fileList.Add(obj4);
                        }
                    }
                    AllPatientModel apm = new AllPatientModel();
                    apm.RegDocLocation = fileList;
                    patientList.Add(apm);
                    return patientList;
                }
            }
        }
    }
}
//con.Open();
//SqlCommand cmdmobilemailcheck = new SqlCommand("stLH_CheckPatientEmailExists", con);
//cmdmobilemailcheck.CommandType = CommandType.StoredProcedure;
//cmdmobilemailcheck.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
//cmdmobilemailcheck.Parameters.AddWithValue("@PatientEmail", patientDetail.Email);
//cmdmobilemailcheck.Parameters.AddWithValue("@PatientMobile", patientDetail.Mobile);
//SqlDataAdapter adapter = new SqlDataAdapter(cmdmobilemailcheck);
//DataSet dsMobileMailCheckData = new DataSet();
//adapter.Fill(dsMobileMailCheckData);
//con.Close();
//if ((dsMobileMailCheckData != null) && (dsMobileMailCheckData.Tables.Count > 0) && (dsMobileMailCheckData.Tables[0] != null) && (dsMobileMailCheckData.Tables[0].Rows.Count > 0))
//{
//    int CountDatas = Convert.ToInt32(dsMobileMailCheckData.Tables[0].Rows[0]["CountData"]);
//    string Messagedatas = dsMobileMailCheckData.Tables[0].Rows[0]["MessageData"].ToString();
//    if (Messagedatas != "NoDuplicate")
//    {
//        response = Messagedatas;
//        return response;
//    }
//}