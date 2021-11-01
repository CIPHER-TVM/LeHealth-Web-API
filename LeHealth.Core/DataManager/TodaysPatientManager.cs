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
                    //converting datatable to list of countries
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
        public List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment)
        {
            List<SearchAppointmentModel> appointmentlist = new List<SearchAppointmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppointment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppId", appointment.AppId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsAppointmentsList = new DataSet();
                    adapter.Fill(dsAppointmentsList);
                    con.Close();
                    //converting datatable to list of Appointments
                    if ((dsAppointmentsList != null) && (dsAppointmentsList.Tables.Count > 0) && (dsAppointmentsList.Tables[0] != null) && (dsAppointmentsList.Tables[0].Rows.Count > 0))
                        appointmentlist = dsAppointmentsList.Tables[0].ToListOfObject<SearchAppointmentModel>();
                    return appointmentlist;
                }
            }
        }

        public List<AppSearchModel> SearchAppointment(AppointmentModel appointment)
        {
            List<SearchAppointmentModel> appointmentlist = new List<SearchAppointmentModel>();
            List<AppSearchModel> appList = new List<AppSearchModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchAppointment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (appointment.ConsultantId == 0 || appointment.ConsultantId == null)
                        cmd.Parameters.AddWithValue("@ConsultantId", 0);

                    else
                        cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);

                    cmd.Parameters.AddWithValue("@Name", appointment.Name);
                    cmd.Parameters.AddWithValue("@Address", appointment.Address);
                    cmd.Parameters.AddWithValue("@Mobile", appointment.Mobile);
                    cmd.Parameters.AddWithValue("@Phone", appointment.Phone);
                    cmd.Parameters.AddWithValue("@PIN", appointment.PIN);
                    cmd.Parameters.AddWithValue("@AppFromDate", appointment.AppFromDate);
                    cmd.Parameters.AddWithValue("@AppToDate", appointment.AppToDate);
                    cmd.Parameters.AddWithValue("@RegNo", appointment.RegNo);
                    cmd.Parameters.AddWithValue("@AppointmentType", appointment.AppType);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsAppointments = new DataSet();
                    adapter.Fill(dsAppointments);
                    con.Close();
                    //converting datatable to list of Appointments by Searching Patient details
                    if ((dsAppointments != null) && (dsAppointments.Tables.Count > 0) && (dsAppointments.Tables[0] != null) && (dsAppointments.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsAppointments.Tables[0].Rows.Count; i++)
                        {
                            AppSearchModel obj = new AppSearchModel();
                            obj.AppId = Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["AppId"]);
                            obj.AppDate = Convert.ToDateTime(dsAppointments.Tables[0].Rows[i]["AppDate"]);
                            obj.AppType = Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["AppType"]);
                            obj.AppNo = dsAppointments.Tables[0].Rows[i]["AppNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["PatientId"]);
                            obj.FirstName = dsAppointments.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.PatientRegNo = dsAppointments.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PIN = dsAppointments.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Mobile = dsAppointments.Tables[0].Rows[i]["ContactNumber"].ToString();
                            obj.CFirstName = dsAppointments.Tables[0].Rows[i]["ConsultantName"].ToString();
                            obj.AppStatus = dsAppointments.Tables[0].Rows[i]["Status"].ToString();
                            obj.ResPhone = dsAppointments.Tables[0].Rows[i]["TelePhone"].ToString();
                            obj.Address1 = dsAppointments.Tables[0].Rows[i]["Address"].ToString();
                            appList.Add(obj);
                        }
                    }
                    //if ((dsAppointmentsList != null) && (dsAppointmentsList.Tables.Count > 0) && (dsAppointmentsList.Tables[0] != null) && (dsAppointmentsList.Tables[0].Rows.Count > 0))
                    //    appointmentlist = dsAppointmentsList.Tables[0].ToListOfObject<Appointments>();
                    return appList;
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
        public List<PatientListModel> SearchPatient(PatientSearchModel patientDetails)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatientsBase", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", patientDetails.ConsultantId);
                    cmd.Parameters.AddWithValue("@Name", patientDetails.Name);
                    cmd.Parameters.AddWithValue("@RegNo", patientDetails.RegNo);
                    cmd.Parameters.AddWithValue("@Mobile", patientDetails.Mobile);
                    cmd.Parameters.AddWithValue("@ResNo", patientDetails.ResNo);//?????
                    cmd.Parameters.AddWithValue("@PIN", patientDetails.PIN);
                    cmd.Parameters.AddWithValue("@PolicyNo", patientDetails.PolicyNo);
                    cmd.Parameters.AddWithValue("@IdentityNo", patientDetails.IdentityNo);
                    cmd.Parameters.AddWithValue("@Address", patientDetails.Address);
                    cmd.Parameters.AddWithValue("@Mode", patientDetails.Mode);//????
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();
                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                        patientList = dsPatientList.Tables[0].ToListOfObject<PatientListModel>();

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
        public List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname)
        {
            List<MandatoryFieldsModel> mandatoryList = new List<MandatoryFieldsModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSavingSchemaMandatory", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FormName", formname);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsMandatoryList = new DataSet();
                    adapter.Fill(dsMandatoryList);
                    con.Close();

                    if ((dsMandatoryList != null) && (dsMandatoryList.Tables.Count > 0) && (dsMandatoryList.Tables[0] != null) && (dsMandatoryList.Tables[0].Rows.Count > 0))
                        mandatoryList = dsMandatoryList.Tables[0].ToListOfObject<MandatoryFieldsModel>();
                    return mandatoryList;
                }
            }

        }
        
        public List<SchemeModel> GetSchemeByConsultant(int consultantid)
        {
            List<SchemeModel> schemeList = new List<SchemeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantItem", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ConsultantId", consultantid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsSchemeList = new DataSet();
                    adapter.Fill(dsSchemeList);
                    con.Close();

                    if ((dsSchemeList != null) && (dsSchemeList.Tables.Count > 0) && (dsSchemeList.Tables[0] != null) && (dsSchemeList.Tables[0].Rows.Count > 0))
                        schemeList = dsSchemeList.Tables[0].ToListOfObject<SchemeModel>();
                    return schemeList;
                }
            }

        }

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
        public List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap)
        {
            List<GetAppNoModel> scheduleList = new List<GetAppNoModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppNumber", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ConsultantId", gap.ConsultantId);
                    cmd.Parameters.AddWithValue("@AppDate", gap.AppDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsScheduleList = new DataSet();
                    adapter.Fill(dsScheduleList);
                    con.Close();
                    if ((dsScheduleList != null) && (dsScheduleList.Tables.Count > 0) && (dsScheduleList.Tables[0] != null) && (dsScheduleList.Tables[0].Rows.Count > 0))
                        scheduleList = dsScheduleList.Tables[0].ToListOfObject<GetAppNoModel>();
                    return scheduleList;
                }
            }

        }

    }

}
