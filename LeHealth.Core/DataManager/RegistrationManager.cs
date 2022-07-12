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
using Newtonsoft.Json;

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

        /// <summary>
        /// Get All details of patient.Not using now. Instead of this API SearchPatientInList is calling
        /// </summary>
        /// <returns></returns>
        public List<AllPatientModel> GetAllPatient(int BranchId)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPatientList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", 0);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsPatientList = new DataTable();
            adapter.Fill(dsPatientList);
            con.Close();
            if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                patientList = dsPatientList.ToListOfObject<AllPatientModel>();
            return patientList;
        }
        /// <summary>
        /// Searching Patient details with patient name,consultant id, mobile, Reg no identiy number ,Reg Date ,Pin,Policy No in Patient Main Page.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patient)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchPatients", con);
            con.Open();
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
            DataTable dsPatientList = new DataTable();
            adapter.Fill(dsPatientList);
            con.Close();
            if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsPatientList.Rows.Count; i++)
                {
                    AllPatientModel obj = new AllPatientModel
                    {
                        PatientId = Convert.ToInt32(dsPatientList.Rows[i]["PatientId"]),
                        RegNo = dsPatientList.Rows[i]["RegNo"].ToString(),
                        RegDate = dsPatientList.Rows[i]["RegDate"].ToString(),
                        AgeInYears = dsPatientList.Rows[i]["AgeInYears"].ToString(),
                        PatientName = dsPatientList.Rows[i]["PatientName"].ToString(),
                        Age = dsPatientList.Rows[i]["Age"].ToString(),
                        Pin = dsPatientList.Rows[i]["PIN"].ToString(),
                        Gender = Convert.ToInt32(dsPatientList.Rows[i]["Gender"]),
                        GenderName = dsPatientList.Rows[i]["GenderName"].ToString(),
                        Email = dsPatientList.Rows[i]["Email"].ToString(),
                        Mobile = dsPatientList.Rows[i]["Mobile"].ToString(),
                        Address = dsPatientList.Rows[i]["Address"].ToString(),
                        SponsorName = dsPatientList.Rows[i]["SponsorName"].ToString(),
                        Consultant = dsPatientList.Rows[i]["Consultant"].ToString(),
                        PolicyNo = dsPatientList.Rows[i]["PolicyNo"].ToString(),
                        EmiratesId = dsPatientList.Rows[i]["EmirateID"].ToString(),
                        SponsorId = dsPatientList.Rows[i]["SponsorId"].ToString(),
                        Active = Convert.ToInt32(dsPatientList.Rows[i]["Active"])
                    };
                    patientList.Add(obj);
                }
            }
            return patientList;
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
                DateTime regDate = DateTime.ParseExact(reregistration.RegDate.Trim(), "dd-MM-yyyy", null);
                reregistration.RegDate = regDate.ToString("yyyy-MM-dd");
                using SqlConnection con = new SqlConnection(_connStr);
                using SqlCommand cmd = new SqlCommand("stLH_InsertPatRegs", con);
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
        public List<PatientModel> GetRegisteredDataById(Int32 patid)
        {
            PatientModel obj = new PatientModel();
            List<PatientModel> patientData = new List<PatientModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("stLH_GetRegsteredDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", patid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsPatientData = new DataTable();
            adapter.Fill(dsPatientData);
            con.Close();
            if ((dsPatientData != null) && (dsPatientData.Rows.Count > 0))
            {
                obj.Salutation = Convert.ToInt32(dsPatientData.Rows[0]["Salutation"]);
                obj.FirstName = dsPatientData.Rows[0]["FirstName"].ToString();
                obj.MiddleName = dsPatientData.Rows[0]["MiddleName"].ToString();
                obj.LastName = dsPatientData.Rows[0]["LastName"].ToString();
                obj.PatientName = dsPatientData.Rows[0]["PatientName"].ToString();
                obj.RegNo = dsPatientData.Rows[0]["RegNo"].ToString();
                obj.RegDate = dsPatientData.Rows[0]["RegDate"].ToString().Replace("/", "-");
                obj.DOB = dsPatientData.Rows[0]["DOB"].ToString().Substring(0, 10);
                obj.AgeInMonth = Convert.ToInt32(dsPatientData.Rows[0]["AgeInMonth"]);
                obj.AgeInYear = Convert.ToInt32(dsPatientData.Rows[0]["AgeInYear"]);
                obj.Gender = Convert.ToInt32(dsPatientData.Rows[0]["Gender"]);
                obj.MaritalStatus = Convert.ToInt32(dsPatientData.Rows[0]["MaritalStatus"]);
                obj.KinName = dsPatientData.Rows[0]["KinName"].ToString();
                obj.KinRelation = Convert.ToInt32(dsPatientData.Rows[0]["KinRelation"]);
                obj.KinContactNo = dsPatientData.Rows[0]["KinContactNo"].ToString();
                obj.Mobile = dsPatientData.Rows[0]["Mobile"].ToString();
                obj.ResNo = dsPatientData.Rows[0]["ResNo"].ToString();
                obj.OffNo = dsPatientData.Rows[0]["OffNo"].ToString();
                obj.Remarks = dsPatientData.Rows[0]["Remarks"].ToString();
                obj.Email = dsPatientData.Rows[0]["Email"].ToString();
                obj.FaxNo = dsPatientData.Rows[0]["FaxNo"].ToString();
                obj.Religion = Convert.ToInt32(dsPatientData.Rows[0]["Religion"]);
                obj.ProfId = (dsPatientData.Rows[0]["ProfId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Rows[0]["ProfId"]);
                obj.CmpId = (dsPatientData.Rows[0]["CmpId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Rows[0]["CmpId"]);
                obj.RGroupId = Convert.ToInt32(dsPatientData.Rows[0]["RGroupId"]);
                obj.Mode = dsPatientData.Rows[0]["Mode"].ToString();
                obj.NationalityId = Convert.ToInt32(dsPatientData.Rows[0]["NationalityId"]);
                obj.RefBy = dsPatientData.Rows[0]["ReferredBy"].ToString();
                obj.PrivilegeCard = Convert.ToBoolean(dsPatientData.Rows[0]["PrivilegeCard"]);
                obj.UserId = Convert.ToInt32(dsPatientData.Rows[0]["UserId"]);
                obj.WorkEnvironMent = dsPatientData.Rows[0]["WorkEnvironment"].ToString();
                obj.ProfessionalNoxious = dsPatientData.Rows[0]["ProfessionalNoxious"].ToString();
                obj.ProfessionalExperience = dsPatientData.Rows[0]["ProfessionalExperience"].ToString();
                obj.LocationId = Convert.ToInt32(dsPatientData.Rows[0]["LocationId"]);
                obj.VisaTypeId = Convert.ToInt32(dsPatientData.Rows[0]["VisaTypeID"]);
                obj.CommunicationType = (dsPatientData.Rows[0]["CommunicationType"] == DBNull.Value) ? 0 : Convert.ToInt32(dsPatientData.Rows[0]["CommunicationType"]);// Convert.ToInt32(dsPatientData.Rows[0]["CommunicationType"]);
                obj.BranchId = Convert.ToInt32(dsPatientData.Rows[0]["BranchId"]);
                obj.RGroupName = dsPatientData.Rows[0]["RGroupName"].ToString();
                obj.ItemId = Convert.ToInt32(dsPatientData.Rows[0]["ItemId"]);
                obj.ItemName = dsPatientData.Rows[0]["ItemName"].ToString();
                obj.MaritalStatusDescription = dsPatientData.Rows[0]["MaritalStatusDescription"].ToString();
                obj.GenderName = dsPatientData.Rows[0]["GenderName"].ToString();
                obj.VisaType = dsPatientData.Rows[0]["VisaType"].ToString();
                obj.ProfName = dsPatientData.Rows[0]["ProfName"].ToString();
                obj.NationalityName = dsPatientData.Rows[0]["NationalityName"].ToString();
                obj.SchemeName = string.Empty;
                obj.CmpName = dsPatientData.Rows[0]["CmpName"].ToString();
                obj.KinContactNo = dsPatientData.Rows[0]["KinContactNo"].ToString();
                obj.OtherReasons = dsPatientData.Rows[0]["Symptoms"].ToString();
                obj.DepartmentId = Convert.ToInt32(dsPatientData.Rows[0]["DeptId"]);
                obj.ConsultantId = Convert.ToInt32(dsPatientData.Rows[0]["ConsultantId"]);
                obj.PatientId = patid;
                obj.DepartmentName = dsPatientData.Rows[0]["DeptName"].ToString();
                obj.ConsultantName = dsPatientData.Rows[0]["ConsultantName"].ToString();
                obj.ConsultationId = Convert.ToInt32(dsPatientData.Rows[0]["ConsultationId"]);
            }

            con.Open();
            SqlCommand cmd2 = new SqlCommand("stLH_GetPatIdentity", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@PatientId", patid);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dsIdentity = new DataTable();
            adapter2.Fill(dsIdentity);
            con.Close();
            List<RegIdentitiesModel> rim = new List<RegIdentitiesModel>();
            if ((dsIdentity != null) && (dsIdentity.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsIdentity.Rows.Count; i++)
                {
                    RegIdentitiesModel objIdentity = new RegIdentitiesModel();
                    objIdentity.IdentityType = Convert.ToInt32(dsIdentity.Rows[i]["IdentityType"]);
                    objIdentity.IdentityNo = dsIdentity.Rows[i]["IdentityNo"].ToString();
                    objIdentity.PatientId = Convert.ToInt32(dsIdentity.Rows[i]["PatientId"]);
                    rim.Add(objIdentity);
                }
            }

            con.Open();
            SqlCommand cmd3 = new SqlCommand("stLH_GetPatAddress", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@PatientId", patid);
            SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
            DataTable dsRate3 = new DataTable();
            adapter3.Fill(dsRate3);
            con.Close();
            List<RegAddressModel> ram = new List<RegAddressModel>();
            if ((dsRate3 != null) && (dsRate3.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsRate3.Rows.Count; i++)
                {
                    RegAddressModel obj3 = new RegAddressModel();
                    obj3.PatientId = Convert.ToInt32(dsRate3.Rows[i]["PatientId"]);
                    obj3.AddType = Convert.ToInt32(dsRate3.Rows[i]["AddType"]);
                    obj3.Address1 = dsRate3.Rows[i]["Address1"].ToString();
                    obj3.Address2 = dsRate3.Rows[i]["Address2"].ToString();
                    obj3.Street = dsRate3.Rows[i]["Street"].ToString();
                    obj3.PlacePO = dsRate3.Rows[i]["PlacePO"].ToString();
                    obj3.PIN = dsRate3.Rows[i]["PIN"].ToString();
                    obj3.City = dsRate3.Rows[i]["City"].ToString();
                    obj3.State = dsRate3.Rows[i]["State"].ToString();
                    obj3.StateName = dsRate3.Rows[i]["StateName"].ToString();
                    obj3.CountryName = dsRate3.Rows[i]["CountryName"].ToString();
                    obj3.CountryId = Convert.ToInt32(dsRate3.Rows[i]["CountryId"]);
                    ram.Add(obj3);
                }
            }
            con.Open();
            SqlCommand cmd4 = new SqlCommand("stLH_GetRegFileNameByPatientId", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@PatientId", patid);
            SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);
            DataTable ds4 = new DataTable();
            adapter4.Fill(ds4);
            con.Close();
            List<RegDocLocationModel> doclistobj = new List<RegDocLocationModel>();
            if ((ds4 != null) && (ds4.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds4.Rows.Count; i++)
                {
                    RegDocLocationModel obj4 = new RegDocLocationModel
                    {
                        Id = Convert.ToInt32(ds4.Rows[i]["Id"]),
                        FilePath = _uploadpath + ds4.Rows[i]["FilePath"].ToString(),
                        FileOriginalName = _uploadpath + ds4.Rows[i]["OriginalFileName"].ToString()
                    };
                    doclistobj.Add(obj4);
                }
            }
            List<RegSymptomsModel> SymptomsList = new List<RegSymptomsModel>();
            if (obj.ConsultationId != null)
            {
                con.Open();
                SqlCommand cmd5 = new SqlCommand("stLH_GetSymptomByConsultationId", con);
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Parameters.AddWithValue("@ConsultationId", obj.ConsultationId);
                SqlDataAdapter adapter5 = new SqlDataAdapter(cmd5);
                DataTable ds5 = new DataTable();
                adapter5.Fill(ds5);
                con.Close();
                if ((ds5 != null) && (ds5.Rows.Count > 0))
                {
                    for (Int32 i = 0; i < ds5.Rows.Count; i++)
                    {
                        RegSymptomsModel rsm = new RegSymptomsModel();
                        rsm.SymptomId = Convert.ToInt32(ds5.Rows[0]["SymptomId"]);
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
                using SqlCommand cmd = new SqlCommand("stLH_BlockPatient", con);
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
            return response;
        }
        /// <summary>
        /// Delete patient's Saved file names from database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeletePatRegFiles(Int32 Id)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeletePatRegFiles", con);
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
                using SqlCommand cmd = new SqlCommand("stLH_UnblockPatient", con);
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
            int IsUpdate = 0;
            if (patientDetail.PatientId > 0)
            {
                IsUpdate = 1;
            }
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                if (IsUpdate == 0 && patientDetail.IsManualRegNo == 0)
                {
                    string rno = AutoregnoCreate(patientDetail.BranchId);
                    patientDetail.RegNo = rno;
                }
                else if (IsUpdate == 0 && patientDetail.IsManualRegNo == 1)
                {
                    string IsDuplicate = RegnoDuplicateCheck(patientDetail.RegNo, patientDetail.BranchId);
                    if (IsDuplicate == "duplicate")
                    {
                        responseobj.ErrorMessage = "Registration number already exists";
                        responselist.Add(responseobj);
                        return responselist;
                    }
                }
                con.Open();
                transaction = con.BeginTransaction();
                DateTime regDate = DateTime.ParseExact(patientDetail.RegDate.Trim(), "dd-MM-yyyy", null);
                patientDetail.RegDate = regDate.ToString("yyyy-MM-dd");
                DateTime dobDate = DateTime.ParseExact(patientDetail.DOB.Trim(), "dd-MM-yyyy", null);
                patientDetail.DOB = dobDate.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand("stLH_InsertPatient", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
                cmd.Parameters.AddWithValue("@Mode", patientDetail.Mode);//R,N Two Modes exists. Details Dont know
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
                        SqlCommand savepatidentity1CMD = new SqlCommand("stLH_InsertPatIdentity", con);
                        savepatidentity1CMD.CommandType = CommandType.StoredProcedure;
                        savepatidentity1CMD.Parameters.AddWithValue("@PatientId", patientId);
                        string identityString = JsonConvert.SerializeObject(patientDetail.RegIdentities);
                        savepatidentity1CMD.Parameters.AddWithValue("@IdentityJSON", identityString);
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
                        SqlCommand savepataddress1CMD = new SqlCommand("stLH_InsertPatAddress", con);
                        savepataddress1CMD.CommandType = CommandType.StoredProcedure;
                        savepataddress1CMD.Parameters.AddWithValue("@PatientId", patientId);
                        string addressString = JsonConvert.SerializeObject(patientDetail.RegAddress);
                        savepataddress1CMD.Parameters.AddWithValue("@AddressJSON", addressString);
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
                        var isInsertedAdr = savepataddress1CMD.ExecuteNonQuery();
                        int patadrReturn1V = Convert.ToInt32(patadrReturn1.Value);
                        var patadrReturnDesc1V = patadrReturnDesc1.Value.ToString();
                        //FileUploadStarts
                        if (patientDetail.RegDocLocation != null)
                        {
                            SqlCommand savepatdocCMD = new SqlCommand("stLH_InsertPatRegFiles", con);
                            savepatdocCMD.CommandType = CommandType.StoredProcedure;
                            savepatdocCMD.Parameters.AddWithValue("@PatientId", patientId);
                            string filelocString = JsonConvert.SerializeObject(patientDetail.RegDocLocation);
                            savepatdocCMD.Parameters.AddWithValue("@RegFileJson", filelocString);
                            SqlParameter patfileReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter patfileReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            savepatdocCMD.Parameters.Add(patfileReturn1);
                            savepatdocCMD.Parameters.Add(patfileReturnDesc1);
                            var isdocInserted = savepatdocCMD.ExecuteNonQuery();
                            int patfileReturn1V = Convert.ToInt32(patfileReturn1.Value);
                            var patfileReturnDesc1V = patfileReturnDesc1.Value.ToString();
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
                                    SqlCommand patientRegConsultationSavecmd = new SqlCommand("stLH_InsertUpdateConsultation", con)
                                    {
                                        CommandType = CommandType.StoredProcedure
                                    };
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
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@BranchId", patientDetail.Consultation.BranchId);
                                    string symptomString = JsonConvert.SerializeObject(patientDetail.Symptoms);
                                    patientRegConsultationSavecmd.Parameters.AddWithValue("@SymptomJson", symptomString);
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
                                    var savedConsultationDesc1V = patConsReturnDesc1.Value.ToString();
                                }
                                responseobj.PatientId = patientId;
                                responseobj.RegNo = patientDetail.RegNo;
                                responseobj.ErrorMessage = "success";
                            }
                            else
                            {
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
        /// <summary>
        /// Upload Patient's documents
        /// </summary>
        /// <param name="patientDetail"></param>
        /// <returns> success or reason for error</returns>
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
                        SqlCommand cmdup = new SqlCommand("stLH_ActionUpdateProfilePic", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
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
                        SqlCommand savepatdocCMD = new SqlCommand("stLH_InsertPatRegFiles", con);
                        savepatdocCMD.CommandType = CommandType.StoredProcedure;
                        savepatdocCMD.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
                        string filelocString = JsonConvert.SerializeObject(patientDetail.RegDocLocation);
                        savepatdocCMD.Parameters.AddWithValue("@RegFileJson", filelocString);
                        SqlParameter patfileReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter patfileReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        savepatdocCMD.Parameters.Add(patfileReturn1);
                        savepatdocCMD.Parameters.Add(patfileReturnDesc1);
                        var isdocInserted = savepatdocCMD.ExecuteNonQuery();
                        int patfileReturn1V = Convert.ToInt32(patfileReturn1.Value);
                        string patfileReturn2V = patfileReturnDesc1.Value.ToString();

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
        public string AutoregnoCreate(int BranchId)
        {
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand autonumberCMD = new SqlCommand("stLH_AutoNumberReg", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            autonumberCMD.Parameters.AddWithValue("@NumId", "REG-NO");
            autonumberCMD.Parameters.AddWithValue("@BranchId", BranchId);
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
        public string RegnoDuplicateCheck(string RegNo, int BranchId)
        {
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand autonumberCMD = new SqlCommand("stLH_RegNoCheck", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            autonumberCMD.Parameters.AddWithValue("@RegNo", RegNo);
            autonumberCMD.Parameters.AddWithValue("@BranchId", BranchId);
            SqlParameter patidReturnDesc1 = new SqlParameter("@HasDuplicate", SqlDbType.VarChar, 20)
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
        /// <summary>
        /// View All file urls of a patient
        /// </summary>
        /// <param name="patientid"></param>
        /// <returns>List of file's url, type uploaded for a patient</returns>
        public List<AllPatientModel> ViewPatientFiles(Int32 patientid)
        {
            List<AllPatientModel> patientList = new List<AllPatientModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetRegFileNameByPatientId", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", patientid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsPatientList = new DataTable();
            adapter.Fill(dsPatientList);
            con.Close();
            List<RegDocLocationModel> fileList = new List<RegDocLocationModel>();
            if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
            {
                for (int j = 0; j < dsPatientList.Rows.Count; j++)
                {
                    RegDocLocationModel obj4 = new RegDocLocationModel();
                    obj4.Id = Convert.ToInt32(dsPatientList.Rows[j]["Id"]);
                    obj4.FilePath = _uploadpath + dsPatientList.Rows[j]["FilePath"].ToString();
                    obj4.NewUniqueName = dsPatientList.Rows[j]["FilePath"].ToString().Replace("uploads/documents/", "");
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
            AllPatientModel apm = new AllPatientModel
            {
                RegDocLocation = fileList
            };
            patientList.Add(apm);
            return patientList;
        }
    }
}