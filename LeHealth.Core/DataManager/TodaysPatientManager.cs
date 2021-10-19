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
    public class TodaysPatientManager : ITodaysPatientManager
    {
        private readonly string _connStr;
        string patientid = "hhhhhh";
        public TodaysPatientManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        public List<PatientModel> InsertPatient(PatientModel patientDetail)
        {
            List<PatientModel> patientDetails = new List<PatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_InsertPatient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", DBNull.Value);
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
                    //cmd.Parameters.AddWithValue("@RetVal", patientDetail.RetVal);
                    cmd.Parameters.AddWithValue("@RetDesc", patientDetail.RetDesc);
                    cmd.Parameters.AddWithValue("@PrivilegeCard", patientDetail.PrivilegeCard);
                    cmd.Parameters.AddWithValue("@UserId", patientDetail.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", patientDetail.LocationId);
                    cmd.Parameters.AddWithValue("@WorkEnvironment", patientDetail.WorkEnvironMent);
                    cmd.Parameters.AddWithValue("@ProfessionalExperience", patientDetail.ProfessionalExperience);
                    cmd.Parameters.AddWithValue("@ProfessionalNoxious", patientDetail.ProfessionalNoxious);
                    cmd.Parameters.AddWithValue("@VisaTypeId", patientDetail.VisaTypeId);
                    cmd.Parameters.AddWithValue("@SessionId", patientDetail.SessionId);
                    cmd.Parameters.AddWithValue("@BranchId", patientDetail.BranchId);
                    //cmd.Parameters.AddWithValue("@RetRegNo", patientDetail.RetRegNo);
                    SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //con.BeginTransaction();
                    //cmd.Transaction()
                    int patientId = (int)outputIdParam.Value;
                    patientid = patientId.ToString();
                    con.Close();
                    if (patientId > 0)// check patient basic detail is inserted
                    {
                        patientDetail.PatientId = patientId;
                        bool isPatIdentityUpdated = InsertPatIdentity(patientDetail);
                        if (isPatIdentityUpdated == true)//checke patient identity is updated
                        {
                            bool isPatAddressUpdated = InsertPatAddress(patientDetail);
                            if (isPatAddressUpdated == true)//check patient address is updated
                            {
                                bool isRegDetailsUpdated = InsertPatRegs(patientDetail);
                            }
                        }
                    }
                }
            }

            return patientDetails;
        }

        public bool InsertPatRegs(PatientModel patientRegDetail)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertPatRegs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@RegDate", patientRegDetail.RegDate);
                    cmd.Parameters.AddWithValue("@PatientId", patientRegDetail.PatientId);
                    cmd.Parameters.AddWithValue("@RegAmount", patientRegDetail.RegAmount);
                    cmd.Parameters.AddWithValue("@LocationId", patientRegDetail.LocationId);
                    cmd.Parameters.AddWithValue("@ExpiryDate", patientRegDetail.ExpiryDate);
                    cmd.Parameters.AddWithValue("@UserId", patientRegDetail.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", patientRegDetail.SessionId);
                    cmd.Parameters.AddWithValue("@ItemId", patientRegDetail.ItemId);
                    cmd.Parameters.AddWithValue("@RetDesc", patientRegDetail.RetDesc);
                    SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int RegId = (int)outputIdParam.Value;
                    con.Close();
                    if(RegId > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public bool InsertPatIdentity(PatientModel patIdentityDetail)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertPatIdentity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", patIdentityDetail.PatientId);
                    cmd.Parameters.AddWithValue("@IdentityType", patIdentityDetail.IdentityType);
                    cmd.Parameters.AddWithValue("@IdentityNo", patIdentityDetail.IdentityNo);
                    cmd.Parameters.AddWithValue("@RetDesc", patIdentityDetail.RetDesc);
                    SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int patientId = (int)outputIdParam.Value;
                    con.Close();
                    if (patientId > 0)// check patient identity detail is inserted
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public bool InsertPatAddress(PatientModel patIdentityDetail)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertPatAddress", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", patIdentityDetail.PatientId);
                    cmd.Parameters.AddWithValue("@AddType", patIdentityDetail.AddType);
                    cmd.Parameters.AddWithValue("@Street", patIdentityDetail.Street);
                    cmd.Parameters.AddWithValue("@PlacePO", patIdentityDetail.PlacePO);
                    cmd.Parameters.AddWithValue("@City", patIdentityDetail.City);
                    cmd.Parameters.AddWithValue("@PIN", patIdentityDetail.PIN);
                    cmd.Parameters.AddWithValue("@CountryId", patIdentityDetail.CountryId);
                    cmd.Parameters.AddWithValue("@Address1", patIdentityDetail.Address1);
                    cmd.Parameters.AddWithValue("@Address2", patIdentityDetail.Address2);
                    cmd.Parameters.AddWithValue("@State", patIdentityDetail.State);
                    cmd.Parameters.AddWithValue("@RetDesc", patIdentityDetail.RetDesc);
                    SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int patientId = (int)outputIdParam.Value;
                    con.Close();
                    if (patientId > 0)// check patient identity detail is inserted
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
