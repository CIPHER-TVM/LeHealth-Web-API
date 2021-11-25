using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
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
        public List<PatientModel> GetPatient(int patientId)
        {
            List<PatientModel> patientDataList = new List<PatientModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetPatient", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsPatientList = new DataSet();
                    adapter.Fill(dsPatientList);
                    con.Close();

                    if ((dsPatientList != null) && (dsPatientList.Tables.Count > 0) && (dsPatientList.Tables[0] != null) && (dsPatientList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsPatientList.Tables[0].Rows.Count; i++)
                        {
                            PatientModel obj = new PatientModel();
                            obj.PatientId = Convert.ToInt32(dsPatientList.Tables[0].Rows[i]["PatientId"]);
                            obj.RegNo = dsPatientList.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.FirstName = dsPatientList.Tables[0].Rows[i]["FirstName"].ToString();
                            obj.MiddleName = dsPatientList.Tables[0].Rows[i]["MiddleName"].ToString();
                            obj.LastName = dsPatientList.Tables[0].Rows[i]["LastName"].ToString();
                            obj.Hook = dsPatientList.Tables[0].Rows[i]["Hook"].ToString();
                            obj.NationalityId = Convert.ToInt32(dsPatientList.Tables[0].Rows[i]["NationalityId"]);
                            patientDataList.Add(obj);
                        }
                    }
                    return patientDataList;
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
        public List<GetNumberModel> GetNumber(string numId)
        {
            List<GetNumberModel> numberList = new List<GetNumberModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetNumber", con))
                {
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
        public List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap)
        {
            List<GetAppTimeModel> scheduleList = new List<GetAppTimeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppTime", con))
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
                        scheduleList = dsScheduleList.Tables[0].ToListOfObject<GetAppTimeModel>();
                    return scheduleList;
                }
            }

        }
        public List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsim)
        {
            List<SheduleGetDataModel> scheduleList = new List<SheduleGetDataModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetScheduleData", con))
                {
                    for (int i = 0; i < gsim.Consultant.Length; i++)
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ConsultantId", gsim.Consultant[i]);
                        cmd.Parameters.AddWithValue("@AppDate", gsim.DateValue);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dsScheduleList = new DataSet();
                        adapter.Fill(dsScheduleList);
                        con.Close();
                        if ((dsScheduleList != null) && (dsScheduleList.Tables.Count > 0) && (dsScheduleList.Tables[0] != null) && (dsScheduleList.Tables[0].Rows.Count > 0))
                        {
                            for (int j = 0; j < dsScheduleList.Tables[0].Rows.Count; i++)
                            {

                            }
                        }
                    }
                    return scheduleList;
                }
            }

        }
        public List<RecentConsultationModel> GetRecentConsultationData()
        {
            List<RecentConsultationModel> scheduleList = new List<RecentConsultationModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetRecentConsultantations", con))
                {

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsScheduleList = new DataSet();
                    adapter.Fill(dsScheduleList);
                    con.Close();
                    if ((dsScheduleList != null) && (dsScheduleList.Tables.Count > 0) && (dsScheduleList.Tables[0] != null) && (dsScheduleList.Tables[0].Rows.Count > 0))
                        scheduleList = dsScheduleList.Tables[0].ToListOfObject<RecentConsultationModel>();
                    return scheduleList;
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
        public string DeleteAppointment(AppointmentModel appointment)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppId", appointment.AppId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr)
        {
            List<GetConsultantItemSchemeRateModel> numberList = new List<GetConsultantItemSchemeRateModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantItemSchemeRate", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", cisr.ItemId);
                    cmd.Parameters.AddWithValue("@ConsultantId", cisr.ConsultantId);
                    cmd.Parameters.AddWithValue("@RGroupId", cisr.RGroupId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            GetConsultantItemSchemeRateModel obj = new GetConsultantItemSchemeRateModel();
                            obj.ItemName = dsNumber.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.Rate = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Rate"]);
                            obj.EmergencyFees = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["EmergencyFees"]);
                            numberList.Add(obj);
                        }
                    }
                    return numberList;
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
        public List<LeadAgentModel> GetLeadAgent(LeadAgentModel la)
        {
            List<LeadAgentModel> itemList = new List<LeadAgentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentId", la.LeadAgentId);
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
                            obj.CommisionPercent = dsNumber.Tables[0].Rows[i]["CommisionPercent"].ToString();
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            itemList.Add(obj);
                        }
                    }
                    return itemList;
                }
            }
        }
        public List<CompanyModel> GetCompany()
        {
            List<CompanyModel> companyList = new List<CompanyModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetCompany", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CmpId", 0);
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
        public string CancelConsultation(ConsultationModel consultation)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ActionCancelConsultation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultationId", consultation.ConsultationId);
                    cmd.Parameters.AddWithValue("@UserId", consultation.UserId);
                    cmd.Parameters.AddWithValue("@CancelReason", consultation.CancelReason);

                    SqlParameter retVal = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retVal);
                    SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retDesc);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    var retV = retVal.Value;
                    var retD = retDesc.Value.ToString();
                    con.Close();
                    if (retV.ToString() == "1")
                    {
                        response = "success";
                    }
                    else
                    {
                        response = retD;
                    }

                }
            }
            return response;
        }
        //ZONE START
        public string InsertZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneName", zone.ZoneName);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zone.Id);
                    cmd.Parameters.AddWithValue("@zoneName", zone.ZoneName);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteZone(int zoneId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ZoneById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
                    return stateList;
                }
            }
        }
        public List<ZoneModel> GetAllZone()
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllZone", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
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
        public List<ConsultRateModel> GetConsultRate(ConsultationModel cm)
        {
            List<ConsultRateModel> stateList = new List<ConsultRateModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultRate", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
                    cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
                    cmd.Parameters.AddWithValue("@ItemId", cm.ItemId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            ConsultRateModel obj = new ConsultRateModel();
                            obj.ItemId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemName = dsStateList.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.Rate = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Rate"]);
                            obj.EmergencyFees = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["EmergencyFees"]);
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm)
        {
            List<ConsultRateModel> rateList = new List<ConsultRateModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetRegSchmAmtOfPatient", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
                    cmd.Parameters.AddWithValue("@ItemId", cm.ItemId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsRateList = new DataSet();
                    adapter.Fill(dsRateList);
                    con.Close();
                    if ((dsRateList != null) && (dsRateList.Tables.Count > 0) && (dsRateList.Tables[0] != null) && (dsRateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsRateList.Tables[0].Rows.Count; i++)
                        {
                            ConsultRateModel obj = new ConsultRateModel();
                            obj.ItemId = Convert.ToInt32(dsRateList.Tables[0].Rows[i]["ItemId"]);
                            obj.Rate = Convert.ToInt32(dsRateList.Tables[0].Rows[i]["Rate"]);
                            rateList.Add(obj);
                        }
                    }
                    return rateList;
                }
            }
        }
        //ZONE END
        /// <summary>
        /// Save consultation details to database,Step three in code execution flow
        /// </summary>
        /// <param name="consultations"></param>
        /// <returns></returns>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            List<ConsultationModel> consultaionsList = new List<ConsultationModel>();
            var descrip = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultation", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (consultations.ConsultationId == null || consultations.ConsultationId == 0)
                            cmd.Parameters.AddWithValue("@ConsultationId", DBNull.Value);

                        else
                            cmd.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);

                        cmd.Parameters.AddWithValue("@ConsultDate", Convert.ToDateTime(consultations.ConsultDate));
                        cmd.Parameters.AddWithValue("@AppId", DBNull.Value);
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
                        cmd.Parameters.AddWithValue("@SessionId", consultations.SessionId);

                        SqlParameter retSeqNumber = new SqlParameter("@RetSeqNo", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retSeqNumber);

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
                        //var seq = retSeqNumber.Value;
                        var ret = retValV.Value;
                        descrip = retDesc.Value.ToString();
                        con.Close();

                        if (int.Parse(ret.ToString()) == -1)
                        {
                            consultations.RetVal = -1;
                            consultations.RetDesc = descrip;
                            consultaionsList.Add(consultations);
                        }
                        else if (int.Parse(ret.ToString()) == -2)
                        {
                            consultations.RetVal = -2;
                            consultations.RetDesc = descrip;
                            consultaionsList.Add(consultations);
                        }
                        else
                        {
                            consultations.RetVal = int.Parse(ret.ToString());
                            consultations.RetDesc = "Success";
                            consultaionsList.Add(consultations);
                        }
                    }
                    catch (Exception ex)
                    {

                        consultations.RetVal = -2;
                        consultations.RetDesc = descrip;
                        consultaionsList.Add(consultations);
                    }
                }
            }
            return consultaionsList;
        }
        public List<TokenModel> GetNewTokenNumber(ConsultationModel cm)
        {
            List<TokenModel> tokenNo = new List<TokenModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetNewTokenNumber", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
                    cmd.Parameters.AddWithValue("@ConsultDate", cm.ConsultDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsTokenList = new DataSet();
                    adapter.Fill(dsTokenList);
                    con.Close();
                    if ((dsTokenList != null) && (dsTokenList.Tables.Count > 0) && (dsTokenList.Tables[0] != null) && (dsTokenList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsTokenList.Tables[0].Rows.Count; i++)
                        {
                            TokenModel tm = new TokenModel();
                            tm.TokenNo = Convert.ToInt32(dsTokenList.Tables[0].Rows[0][0]);
                            tokenNo.Add(tm);
                        }
                    }
                    return tokenNo;
                }
            }
        }
        public List<SponsorModel> GetSponsorListByPatientId(int patientId)
        {
            List<SponsorModel> sponsorList = new List<SponsorModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetActiveCredits", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsSponsorList = new DataSet();
                    adapter.Fill(dsSponsorList);
                    con.Close();
                    if ((dsSponsorList != null) && (dsSponsorList.Tables.Count > 0) && (dsSponsorList.Tables[0] != null) && (dsSponsorList.Tables[0].Rows.Count > 0))
                        for (int i = 0; i < dsSponsorList.Tables[0].Rows.Count; i++)
                        {
                            SponsorModel obj = new SponsorModel();
                            obj.OpenDate = dsSponsorList.Tables[0].Rows[i]["OpenDate"].ToString().Substring(0, 10);
                            obj.CreditRefNo = dsSponsorList.Tables[0].Rows[i]["CreditRefNo"].ToString();
                            obj.SponsorName = dsSponsorList.Tables[0].Rows[i]["Sponsor"].ToString();
                            obj.AgentName = dsSponsorList.Tables[0].Rows[i]["AgentName"].ToString();
                            obj.PolicyNo = dsSponsorList.Tables[0].Rows[i]["PolicyNumber"].ToString();
                            string validupto = dsSponsorList.Tables[0].Rows[i]["ValidUpto"].ToString().Substring(0, 10);
                            DateTime todaydate = DateTime.Now.Date;
                            DateTime validuptodttime = Convert.ToDateTime(validupto);
                            if (todaydate < validuptodttime)
                            {
                                obj.IsSponsorExpired = false;
                            }
                            else
                            {
                                obj.IsSponsorExpired = true;
                            }
                            obj.ValidUpto = validupto;
                            sponsorList.Add(obj);
                        }
                    return sponsorList;
                }
            }
        }

        /// <summary>
        /// Get consultant list from database,Step three in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDept", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", cm.DeptId);
                    cmd.Parameters.AddWithValue("@ShowExternal", cm.ShowExternal);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultantModel obj = new ConsultantModel();
                            obj.ConsultantId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultantId"]);
                            obj.ConsultantName = ds.Tables[0].Rows[i]["ConsultantName"].ToString();
                            obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
                            consultantList.Add(obj);
                        }
                    }
                    return consultantList;
                }
            }
        }
        public List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm)
        {
            List<ConsultationByPatientIdModel> consultationList = new List<ConsultationByPatientIdModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultationByPatientId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
                    cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationByPatientIdModel obj = new ConsultationByPatientIdModel();
                            obj.ItemId = Convert.ToInt32(ds.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            obj.SeqNo = Convert.ToInt32(ds.Tables[0].Rows[i]["SeqNo"]);
                            obj.ConsultFee = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultFee"]);
                            obj.ExpiryDate = ds.Tables[0].Rows[i]["ExpiryDate"].ToString();
                            obj.RemainVisits = Convert.ToInt32(ds.Tables[0].Rows[i]["RemainVisits"]);
                            obj.Symptoms = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.ConsultType = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultType"]);
                            obj.Emergency = Convert.ToInt32(ds.Tables[0].Rows[i]["Emergency"]);
                            obj.ExpiryVisits = Convert.ToInt32(ds.Tables[0].Rows[i]["ExpiryVisits"]);
                            string validupto = obj.ExpiryDate;
                            DateTime todaydate = DateTime.Now.Date;
                            DateTime validuptodttime = Convert.ToDateTime(validupto);
                            if (todaydate < validuptodttime)
                            {
                                obj.IsConsultationExpired = false;
                            }
                            else
                            {
                                obj.IsConsultationExpired = true;
                            }


                            consultationList.Add(obj);
                        }
                    }
                    return consultationList;
                }
            }
        }

        public List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm)
        {
            List<PatRegByPatientIdModel> patregdataList = new List<PatRegByPatientIdModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetPatRegByPatientId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            PatRegByPatientIdModel obj = new PatRegByPatientIdModel();
                            obj.RegId = Convert.ToInt32(ds.Tables[0].Rows[i]["RegId"]);
                            obj.RegDate = ds.Tables[0].Rows[i]["RegDate"].ToString();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ItemId = Convert.ToInt32(ds.Tables[0].Rows[i]["ItemId"]);
                            obj.RegAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["RegAmount"]);
                            obj.ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
                            string validupto = ds.Tables[0].Rows[i]["ExpiryDate"].ToString();
                            DateTime todaydate = DateTime.Now.Date;
                            DateTime validuptodttime = Convert.ToDateTime(validupto);
                            if (todaydate < validuptodttime)
                            {
                                obj.IsRegistrationExpired = false;
                            }
                            else
                            {
                                obj.IsRegistrationExpired = true;
                            }
                            obj.ExpiryDate = validupto;
                            patregdataList.Add(obj);
                        }
                    }
                    return patregdataList;
                }
            }
        }

        //INSERT UPDATE PATIENT
        public string InsertPatient(PatientModel patientDetail)
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
                                response = "success";//patientId.ToString();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }
                        else
                        {
                            response = "success";
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
    }
}
//public List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm)
//{
//    List<PatRegByPatientIdModel> consultationList = new List<PatRegByPatientIdModel>();
//    using (SqlConnection con = new SqlConnection(_connStr))
//    {
//        using (SqlCommand cmd = new SqlCommand("stLH_GetPatRegByPatientId", con))
//        {
//            con.Open();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataSet ds = new DataSet();
//            adapter.Fill(ds);
//            con.Close();
//            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
//            {
//                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//                {
//                    PatRegByPatientIdModel obj = new PatRegByPatientIdModel();
//                    obj.RegId = Convert.ToInt32(ds.Tables[0].Rows[i]["RegId"]);
//                    obj.RegDate = ds.Tables[0].Rows[i]["RegDate"].ToString();
//                    obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
//                    obj.ItemId = Convert.ToInt32(ds.Tables[0].Rows[i]["ItemId"]);
//                    obj.RegAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["RegAmount"]);
//                    obj.ExpiryDate = ds.Tables[0].Rows[i]["ExpiryDate"].ToString();
//                    obj.ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
//                    consultationList.Add(obj);
//                }
//            }
//            return consultationList;
//        }
//    }
//}

//public DataTable ToDataTable<T>(List<T> items)
//{
//    DataTable dataTable = new DataTable(typeof(T).Name);
//    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
//    foreach (PropertyInfo prop in Props)
//    {
//        dataTable.Columns.Add(prop.Name);
//    }
//    foreach (T item in items)
//    {
//        var values = new object[Props.Length];
//        for (int i = 0; i < Props.Length; i++)
//        {

//            values[i] = Props[i].GetValue(item, null);
//        }
//        dataTable.Rows.Add(values);
//    }

//    return dataTable;
//}

//public string SendAddPatientInformation(int patientid)
//{
//    List<AllPatientModel> patientList = new List<AllPatientModel>();
//    using (SqlConnection con = new SqlConnection(_connStr))
//    {
//        using (SqlCommand cmd = new SqlCommand("stLH_GetMalaffiRegisterPatient", con))
//        {
//            con.Open();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@PatientId", patientid);
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataSet ds = new DataSet();
//            adapter.Fill(ds);
//            con.Close();
//            if ((ds != null) && (ds.Tables.Count > 0) && (ds
//                != null) && (ds.Tables[0].Rows.Count > 0))
//            {
//                DataTable dt = ds.Tables[0];
//                string strFile = DateTime.Now.ToString("yyyyMMddHHmmss");
//                string strFileName = "Path.GetTempPath()" + @"\" + Convert.ToString(ds.Tables[0].Rows[0]["MalaffiSystemcode"]) + "_REGISTERPATIENT_" + strFile + ".HL7";
//                string strValue = MalaffiStringBuilder(dt, "ADT^A28");
//                if (strValue == string.Empty)
//                {
//                    return "";
//                }
//            }
//            return "";
//        }
//    }
//}

//private string MalaffiStringBuilder(DataTable dt, string MessageType)
//{
//    string strValue = string.Empty;

//    DataRow dr = dt.Rows[0];
//    if (!this.MalaffiValidations(dr))
//        return string.Empty;
//    strValue = @"MSH|" + Convert.ToString(dr["MSHEncode"]) + "|" +
//                Convert.ToString(dr["MalaffiSystemcode"]) + "^" + Convert.ToString(dr["MalaffiSystemcode"]) + "|" +
//                Convert.ToString(dr["MalaffiSystemcode"]) + "^" + Convert.ToString(dr["MalaffiSystemcode"]) + "|" +
//                Convert.ToString(dr["MSHRecApp"]) + "||" +
//                Convert.ToString(dr["MSHDate"]) + "||" +
//                MessageType + "|" +
//                DateTime.Now.ToString("ddMMyyyyhhmmssffftt") +
//                "|P|" +
//                Convert.ToString(dr["MSHVersion"]) + "\r";
//    if (!MessageType.Equals("OMP^O09") && !MessageType.Equals("ORU^R01") && !MessageType.Equals("RAS^O17") && !MessageType.Equals("PPR^PC1"))
//        strValue += "EVN|" + MessageType.Substring(4, 3) + "|" + Convert.ToString(dr["EVNRecDate"]) + "\r";
//    strValue += "PID|" + Convert.ToString(dr["PIDSetId"]) + "||" +
//                 Convert.ToString(dr["PIDRegNo"]) + "^^^&" + Convert.ToString(dr["MalaffiSystemcode"]) + "||" +
//                 Convert.ToString(dr["PIDPatLastName"]) + "^" + Convert.ToString(dr["PIDPatFirstName"]) + "^" + Convert.ToString(dr["PIDMiddleName"]) +
//                 "||" +
//                 Convert.ToString(dr["PIDDOB"]) + "|" + Convert.ToString(dr["PIDSex"]) +
//                 "|||" +
//                 Convert.ToString(dr["PatAddress"]) + "|||" +
//                 Convert.ToString(dr["PIDMobile"]) + "||" +
//                 Convert.ToString(dr["PIDMaritalStat"]) + "|" +
//                 Convert.ToString(dr["PIDReligionCode"]) + "^" + Convert.ToString(dr["PIDReligionName"]) + "^MALAFFI"
//                 + "||" + Convert.ToString(dr["PIDEmiratesId"]) + "|||||||||" +
//                 Convert.ToString(dr["PIDMalaffiNationalityCode"]) + "^" + Convert.ToString(dr["PIDNationalityName"]) + "^MALAFFI"
//                 + "|||||||||||||||\r";
//    if (!MessageType.Equals("ADT^A28"))
//        strValue += "PV1|" +
//                    Convert.ToString(dr["PV1SedId"]) + "|" +
//                    Convert.ToString(dr["PVIPatClass"]) + "|" +
//                    "^^^" + Convert.ToString(dr["PV1DHAFacilityId"] + "&" + Convert.ToString(dr["PV1MalaffiSystemcode"]) + "-DOHID" +
//                    "||||||" +
//                    Convert.ToString(dr["PV1CRegNo"]) + "^" + Convert.ToString(dr["PV1ConLastName"]) + "^" + Convert.ToString(dr["PV1ConFirstName"]) + "^^^^^^&" +
//                    Convert.ToString(dr["PV1MalaffiSystemcode"]) + "-DOHID" + "|" +
//                    Convert.ToString(dr["PV1HospSpeciality"]) + "||||" +
//                    Convert.ToString(dr["PV1AdmitSource"]) + "|||||" +
//                    Convert.ToString(dr["PV1VisitNo"]) + "^^^&" + Convert.ToString(dr["PV1MalaffiSystemcode"]) + "|||||||||||||||||" +
//                    Convert.ToString(dr["PV1DischrgPosition"]) + "||||||||" +
//                    Convert.ToString(dr["PV1AdmitDate"]) + "|" +
//                    (MessageType == "ADT^A03" ? Convert.ToString(dr["PV1DischargeDate"]) : string.Empty)) +
//                    "|||||||\r";
//    if (!MessageType.Equals("PPR^PC1"))
//    {
//        if (dt.Columns.Contains("PV2VisitReason"))
//            if (Convert.ToString(dt.Rows[0]["PV2VisitReason"]).Trim().Length > 0)
//                strValue += "PV2|||" + "^" + Convert.ToString(dt.Rows[0]["PV2VisitReason"]).Trim() + "|||||||||\r";
//    }
//    return strValue;
//}
//private bool MalaffiValidations(DataRow dr)
//{
//    string strValidationMessage = string.Empty;
//    if (Convert.ToString(dr["MalaffiSystemcode"]).Trim().Length <= 0)
//        strValidationMessage += "Malaffi System Code\r\n";
//    if (Convert.ToString(dr["PIDPatFirstName"]).Trim().Length <= 0)
//        strValidationMessage += "Patient First Name\r\n";
//    //if (Convert.ToString(dr["PIDMiddleName"]).Length <= 0)
//    //    strValidationMessage += "Patient Middle Name\r\n";
//    if (Convert.ToString(dr["PIDPatLastName"]).Trim().Length <= 0)
//        strValidationMessage += "Patient Last Name\r\n";
//    if (Convert.ToString(dr["PIDDOB"]).Trim().Length <= 0)
//        strValidationMessage += "DOB\r\n";
//    if (Convert.ToString(dr["PIDSex"]).Trim().Length <= 0)
//        strValidationMessage += "Sex\r\n";
//    if (Convert.ToString(dr["PIDMobile"]).Trim().Length <= 0)
//        strValidationMessage += "Mobile\r\n";
//    if (Convert.ToString(dr["PIDMaritalStat"]).Trim().Length <= 0)
//        strValidationMessage += "MaritalStatus\r\n";
//    if (Convert.ToString(dr["PIDReligionCode"]).Trim().Length <= 0 || Convert.ToString(dr["PIDReligionName"]).Trim().Length <= 0)
//        strValidationMessage += "Religion Code/Name\r\n";
//    if (Convert.ToString(dr["PIDEmiratesId"]).Trim().Length <= 0)
//        strValidationMessage += "Emirates ID Number\r\n";
//    if (Convert.ToString(dr["PIDMalaffiNationalityCode"]).Trim().Length <= 0 || Convert.ToString(dr["PIDNationalityName"]).Trim().Length <= 0)
//        strValidationMessage += "Nationality Code/Name\r\n";
//    string strConsultant = string.Empty;
//    if (Convert.ToString(dr["PV1CRegNo"]).Trim().Length <= 0)
//        strConsultant += "Consultant Register Number\r\n";
//    if (Convert.ToString(dr["PV1ConLastName"]).Trim().Length <= 0)
//        strConsultant += "Consultant Last Name\r\n";
//    if (Convert.ToString(dr["PV1HospSpeciality"]).Trim().Length <= 0)
//        strConsultant += "Consultant Speciality Code\r\n";
//    if (strConsultant.Length > 0)
//    {
//        strValidationMessage += "\r\nBelow Consultant (" + (dr["PV1CRegNo"] == null || dr["PV1CRegNo"] == DBNull.Value ? string.Empty
//            : Convert.ToString(dr["PV1CRegNo"])) + ") details are empty \r\n" + strConsultant;
//    }
//    if (strValidationMessage.Length > 0)
//    {
//        string aaa = "Malaffi Validation details. Below required fields are empty\r\n" + strValidationMessage;
//        return false;
//    }
//    return true;
//}
////Insert patient working
//public string InsertPatientOriginal(PatientModel patientDetail)
//{
//    SqlTransaction transaction;
//    string response = "";
//    using (SqlConnection con = new SqlConnection(_connStr))
//    {
//        con.Open();
//        transaction = con.BeginTransaction();
//        SqlCommand cmd = new SqlCommand("stLH_InsertPatient", con);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
//        cmd.Parameters.AddWithValue("@RegNo", patientDetail.RegNo);
//        cmd.Parameters.AddWithValue("@RegDate", patientDetail.RegDate);
//        cmd.Parameters.AddWithValue("@Salutation", patientDetail.Salutation);
//        cmd.Parameters.AddWithValue("@FirstName", patientDetail.FirstName);
//        cmd.Parameters.AddWithValue("@MiddleName", patientDetail.MiddleName);
//        cmd.Parameters.AddWithValue("@LastName", patientDetail.LastName);
//        cmd.Parameters.AddWithValue("@DOB", patientDetail.DOB);
//        cmd.Parameters.AddWithValue("@Gender", patientDetail.Gender);
//        cmd.Parameters.AddWithValue("@MaritalStatus", patientDetail.MaritalStatus);
//        cmd.Parameters.AddWithValue("@KinName", patientDetail.KinName);
//        cmd.Parameters.AddWithValue("@KinRelation", patientDetail.KinRelation);
//        cmd.Parameters.AddWithValue("@KinContactNo", patientDetail.KinContactNo);
//        cmd.Parameters.AddWithValue("@Mobile", patientDetail.Mobile);
//        cmd.Parameters.AddWithValue("@ResNo", patientDetail.ResNo);
//        cmd.Parameters.AddWithValue("@OffNo", patientDetail.OffNo);
//        cmd.Parameters.AddWithValue("@Email", patientDetail.Email);
//        cmd.Parameters.AddWithValue("@FaxNo", patientDetail.FaxNo);
//        cmd.Parameters.AddWithValue("@Religion", patientDetail.Religion);
//        cmd.Parameters.AddWithValue("@ProfId", patientDetail.ProfId);
//        cmd.Parameters.AddWithValue("@CmpId", patientDetail.CmpId);
//        cmd.Parameters.AddWithValue("@Status", patientDetail.Status);
//        cmd.Parameters.AddWithValue("@PatState", patientDetail.PatState);
//        cmd.Parameters.AddWithValue("@RGroupId", patientDetail.RGroupId);
//        cmd.Parameters.AddWithValue("@Mode", patientDetail.Mode);
//        cmd.Parameters.AddWithValue("@Remarks", patientDetail.Remarks);
//        cmd.Parameters.AddWithValue("@NationalityId", patientDetail.NationalityId);
//        cmd.Parameters.AddWithValue("@ConsultantId", patientDetail.ConsultantId);
//        cmd.Parameters.AddWithValue("@Active", patientDetail.Active);
//        cmd.Parameters.AddWithValue("@AppId", patientDetail.AppId);
//        cmd.Parameters.AddWithValue("@RefBy", patientDetail.RefBy);
//        cmd.Parameters.AddWithValue("@PrivilegeCard", patientDetail.PrivilegeCard);
//        cmd.Parameters.AddWithValue("@UserId", patientDetail.UserId);
//        cmd.Parameters.AddWithValue("@LocationId", patientDetail.LocationId);
//        cmd.Parameters.AddWithValue("@WorkEnvironment", patientDetail.WorkEnvironMent);
//        cmd.Parameters.AddWithValue("@ProfessionalExperience", patientDetail.ProfessionalExperience);
//        cmd.Parameters.AddWithValue("@ProfessionalNoxious", patientDetail.ProfessionalNoxious);
//        cmd.Parameters.AddWithValue("@VisaTypeId", patientDetail.VisaTypeId);
//        cmd.Parameters.AddWithValue("@SessionId", patientDetail.SessionId);
//        cmd.Parameters.AddWithValue("@BranchId", patientDetail.BranchId);
//        cmd.Parameters.AddWithValue("@RetRegNo", patientDetail.RetRegNo);
//        SqlParameter patientIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
//        {
//            Direction = ParameterDirection.Output
//        };
//        cmd.Parameters.Add(patientIdParam);
//        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
//        {
//            Direction = ParameterDirection.Output
//        };
//        cmd.Parameters.Add(retDesc);
//        cmd.Transaction = transaction;
//        try
//        {
//            cmd.ExecuteNonQuery();
//            int patientId = (int)patientIdParam.Value;
//            string descr = retDesc.Value.ToString();
//            if (patientId > 0)
//            {
//                patientDetail.PatientId = patientId;
//                patientDetail.RegAddress[0].PatientId = patientId;
//                patientDetail.RegAddress[1].PatientId = patientId;
//                patientDetail.RegAddress[2].PatientId = patientId;
//                DataTable dt = new DataTable();
//                dt = ToDataTable(patientDetail.RegAddress);
//                Insert_Patient_Address(dt, _connStr);

//                patientDetail.RegIdentities[0].PatientId = patientId;
//                patientDetail.RegIdentities[1].PatientId = patientId;
//                patientDetail.RegIdentities[2].PatientId = patientId;
//                patientDetail.RegIdentities[3].PatientId = patientId;
//                patientDetail.RegIdentities[4].PatientId = patientId;
//                patientDetail.RegIdentities[5].PatientId = patientId;
//                patientDetail.RegIdentities[6].PatientId = patientId;
//                DataTable dti = new DataTable();
//                dti = ToDataTable(patientDetail.RegIdentities);
//                Insert_Patient_Identity(dti, _connStr);
//                //SqlCommand patientCompanyCmd = InsertCompany(patientDetail);
//                //patientCompanyCmd.Connection = con;
//                //patientCompanyCmd.ExecuteNonQuery();
//                transaction.Commit();
//                SqlCommand patientRegscmd = new SqlCommand("stLH_InsertPatRegs", con);
//                patientRegscmd.CommandType = CommandType.StoredProcedure;
//                patientRegscmd.Parameters.AddWithValue("@RegId", DBNull.Value);
//                patientRegscmd.Parameters.AddWithValue("@RegDate", patientDetail.RegDate);
//                patientRegscmd.Parameters.AddWithValue("@PatientId", patientDetail.PatientId);
//                patientRegscmd.Parameters.AddWithValue("@RegAmount", DBNull.Value);
//                patientRegscmd.Parameters.AddWithValue("@LocationId", patientDetail.LocationId);
//                patientRegscmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
//                patientRegscmd.Parameters.AddWithValue("@UserId", patientDetail.UserId);
//                patientRegscmd.Parameters.AddWithValue("@SessionId", patientDetail.SessionId);
//                patientRegscmd.Parameters.AddWithValue("@ItemId", patientDetail.ItemId);
//                SqlParameter returnParam = new SqlParameter("@RetVal", SqlDbType.Int)
//                {
//                    Direction = ParameterDirection.Output
//                };
//                patientRegscmd.Parameters.Add(returnParam);
//                SqlParameter returnDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
//                {
//                    Direction = ParameterDirection.Output
//                };
//                patientRegscmd.Parameters.Add(returnDesc);
//                var isInserted = patientRegscmd.ExecuteNonQuery();
//                var patregsresponse = returnDesc.Value.ToString();
//                int RegId = Convert.ToInt32(returnParam.Value);
//                if (RegId > 0)
//                {
//                    if (patientDetail.Consultation.EnableConsultation == true)//checking consultation true and reg id is created
//                    {
//                        patientDetail.Consultation.PatientId = patientDetail.PatientId;
//                        SqlCommand patientConsultationCmd = InsertConsultation(patientDetail.Consultation);
//                        patientConsultationCmd.Connection = con;
//                        var isUpdated = patientConsultationCmd.ExecuteNonQuery();
//                    }
//                    SqlCommand updateRegNoCmd = UPDATERegNo();
//                    updateRegNoCmd.Connection = con;
//                    updateRegNoCmd.ExecuteNonQuery();
//                    //transaction.Commit();
//                    response = "success";//patientId.ToString();
//                }
//                else
//                {
//                    transaction.Rollback();
//                }
//            }
//            else
//            {
//                transaction.Rollback();
//                response = descr;
//            }
//        }
//        catch (Exception ex)
//        {
//            transaction.Rollback();
//            response = ex.Message.ToString();
//        }
//        con.Close();
//    }
//    return response;
//}
//SEVEN TIMES START
//SqlCommand savepatidentity1CMD = new SqlCommand("stLH_InsertPatIdentity", con);
//savepatidentity1CMD.CommandType = CommandType.StoredProcedure;
//savepatidentity1CMD.Parameters.AddWithValue("@PatientId", patientId);
//savepatidentity1CMD.Parameters.AddWithValue("@IdentityType", patientDetail.RegIdentities[0].IdentityType);
//savepatidentity1CMD.Parameters.AddWithValue("@IdentityNo", patientDetail.RegIdentities[0].IdentityNo);
//SqlParameter patidReturn1 = new SqlParameter("@RetVal", SqlDbType.Int)
//{
//    Direction = ParameterDirection.Output
//};
//SqlParameter patidReturnDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
//{
//    Direction = ParameterDirection.Output
//};
//savepatidentity1CMD.Parameters.Add(patidReturn1);
//savepatidentity1CMD.Parameters.Add(patidReturnDesc1);
//var isInserted = savepatidentity1CMD.ExecuteNonQuery();
//int patidReturn1V = Convert.ToInt32(patidReturn1.Value);
//var patidReturnDesc1V = patidReturnDesc1.Value.ToString();

//public static void Insert_Patient_Address(DataTable csvData, string con)
//{
//    using (SqlConnection dbConnection = new SqlConnection(con))
//    {
//        dbConnection.Open();
//        using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
//        {
//            s.DestinationTableName = "LH_PatAddress";
//            s.ColumnMappings.Add("PatientId", "PatientId");
//            s.ColumnMappings.Add("AddType", "AddType");
//            s.ColumnMappings.Add("Address1", "Address1");
//            s.ColumnMappings.Add("Address2", "Address2");
//            s.ColumnMappings.Add("Street", "Street");
//            s.ColumnMappings.Add("PlacePO", "PlacePO");
//            s.ColumnMappings.Add("PIN", "PIN");
//            s.ColumnMappings.Add("City", "City");
//            s.ColumnMappings.Add("State", "State");
//            s.ColumnMappings.Add("CountryId", "CountryId");
//            s.WriteToServer(csvData);
//        }
//    }
//}
//public static void Insert_Patient_Identity(DataTable csvData, string con)
//{
//    using (SqlConnection dbConnection = new SqlConnection(con))
//    {
//        dbConnection.Open();
//        using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
//        {
//            s.DestinationTableName = "LH_PatIdentity";

//            s.ColumnMappings.Add("IdentityType", "IdentityType");
//            s.ColumnMappings.Add("IdentityNo", "IdentityNo");
//            s.ColumnMappings.Add("PatientId", "PatientId");

//            s.WriteToServer(csvData);

//        }
//    }
//}
//public SqlCommand InsertPatAddress(RegAddressModel patIdentityDetail)
//{
//    using (SqlCommand cmd = new SqlCommand("stLH_InsertPatAddress"))
//    {
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@PatientId", patIdentityDetail.PatientId);
//        cmd.Parameters.AddWithValue("@AddType", patIdentityDetail.AddType);
//        cmd.Parameters.AddWithValue("@Street", patIdentityDetail.Street);
//        cmd.Parameters.AddWithValue("@PlacePO", patIdentityDetail.PlacePO);
//        cmd.Parameters.AddWithValue("@City", patIdentityDetail.City);
//        cmd.Parameters.AddWithValue("@PIN", patIdentityDetail.PIN);
//        cmd.Parameters.AddWithValue("@CountryId", patIdentityDetail.CountryId);
//        cmd.Parameters.AddWithValue("@Address1", patIdentityDetail.Address1);
//        cmd.Parameters.AddWithValue("@Address2", patIdentityDetail.Address2);
//        cmd.Parameters.AddWithValue("@State", patIdentityDetail.State);
//        cmd.Parameters.AddWithValue("@RetDesc", DBNull.Value);
//        SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
//        {
//            Direction = ParameterDirection.Output
//        };
//        cmd.Parameters.Add(outputIdParam);
//        return cmd;
//    }
//}
//public SqlCommand InsertCompany(PatientModel patient)
//{
//    using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany"))
//    {
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@CmpId", 0);//NIKTODO
//        cmd.Parameters.AddWithValue("@CmpName", patient.CompanyName);
//        cmd.Parameters.AddWithValue("@UserId", 0);//NIKTODO
//        cmd.Parameters.AddWithValue("@SessionId", 0);

//        cmd.Parameters.AddWithValue("@RetVal", DBNull.Value);
//        cmd.Parameters.AddWithValue("@RetDesc", DBNull.Value);

//        return cmd;
//    }
//}
//public SqlCommand InsertPatRegs(PatientModel patientRegDetail)
//{
//    using (SqlCommand cmd = new SqlCommand("stLH_InsertPatRegs"))
//    {
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@RegId", DBNull.Value);
//        cmd.Parameters.AddWithValue("@RegDate", patientRegDetail.RegDate);
//        cmd.Parameters.AddWithValue("@PatientId", patientRegDetail.PatientId);
//        cmd.Parameters.AddWithValue("@RegAmount", DBNull.Value);
//        cmd.Parameters.AddWithValue("@LocationId", patientRegDetail.LocationId);
//        cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
//        cmd.Parameters.AddWithValue("@UserId", patientRegDetail.UserId);
//        cmd.Parameters.AddWithValue("@SessionId", patientRegDetail.SessionId);
//        cmd.Parameters.AddWithValue("@ItemId", patientRegDetail.ItemId);
//        cmd.Parameters.AddWithValue("@RetDesc", patientRegDetail.RetDesc);
//        return cmd;
//    }
//}
//public SqlCommand InsertPatIdentity(RegIdentitiesModel patIdentityDetail)
//{
//    using (SqlCommand cmd = new SqlCommand("stLH_InsertPatIdentity"))
//    {
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@PatientId", patIdentityDetail.PatientId);
//        cmd.Parameters.AddWithValue("@IdentityType", patIdentityDetail.IdentityType);
//        cmd.Parameters.AddWithValue("@IdentityNo", patIdentityDetail.IdentityNo);
//        cmd.Parameters.AddWithValue("@RetDesc", DBNull.Value);
//        SqlParameter outputIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
//        {
//            Direction = ParameterDirection.Output
//        };
//        cmd.Parameters.Add(outputIdParam);
//        return cmd;
//    }
//}
