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
    public class TodaysPatientManager : ITodaysPatientManager
    {
        private readonly string _connStr;
        string patientid = "hhhhhh";
        public TodaysPatientManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }
        public List<CountryModel> GetCountry(CountryModel countryDetails)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetCountry", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryId", countryDetails.CountryId);
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
        public List<PatientModel> InsertPatient(PatientModel patientDetail)
        {
            SqlTransaction transaction;
            List<PatientModel> patientDetails = new List<PatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                con.Open();
                transaction = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("stLH_InsertPatient", con);
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
                cmd.Parameters.AddWithValue("@RetRegNo", patientDetail.RetRegNo);
                SqlParameter patientIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(patientIdParam);
                cmd.Transaction = transaction;
                try
                {
                    cmd.ExecuteNonQuery();
                    int patientId = (int)patientIdParam.Value;
                    if (patientId > 0)
                    {
                        patientDetail.PatientId = patientId;
                        SqlCommand patientIdentityCmd = InsertPatIdentity(patientDetail);
                        patientIdentityCmd.Transaction = transaction;
                        patientIdentityCmd.Connection = con;
                        patientIdentityCmd.ExecuteNonQuery();

                        SqlCommand patientAddressCmd = InsertPatAddress(patientDetail);
                        patientAddressCmd.Transaction = transaction;
                        patientAddressCmd.Connection = con;
                        patientAddressCmd.ExecuteNonQuery();

                        SqlCommand patientRegsCmd = InsertPatRegs(patientDetail);
                        patientRegsCmd.Transaction = transaction;
                        patientRegsCmd.Connection = con;
                        SqlParameter regIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        patientRegsCmd.Parameters.Add(regIdParam);
                        var isupdated = patientRegsCmd.ExecuteNonQuery();
                        int RegsId = (int)regIdParam.Value;
                        if (RegsId > 0)
                        {
                            patientDetail.Consultation.PatientId = patientDetail.PatientId;
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                        SqlCommand patientConsultationCmd = InsertConsultation(patientDetail.Consultation);
                        patientConsultationCmd.Transaction = transaction;
                        patientConsultationCmd.Connection = con;
                        var isUpdated = patientConsultationCmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                con.Close();

            }
            return patientDetails;
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
        public SqlCommand InsertPatRegs(PatientModel patientRegDetail)
        {
            using (SqlCommand cmd = new SqlCommand("stLH_InsertPatRegs"))
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
                return cmd;
            }
        }

        public SqlCommand InsertPatIdentity(PatientModel patIdentityDetail)
        {
            using (SqlCommand cmd = new SqlCommand("stLH_InsertPatIdentity"))
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
                return cmd;
            }
        }
        public SqlCommand InsertPatAddress(PatientModel patIdentityDetail)
        {
            using (SqlCommand cmd = new SqlCommand("stLH_InsertPatAddress"))
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
                return cmd;
            }
        }
    }
}
