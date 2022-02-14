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
        /// <summary>
        /// Get Appointment list from database,Step three in code execution flow
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
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
                    if ((dsAppointmentsList != null) && (dsAppointmentsList.Tables.Count > 0) && (dsAppointmentsList.Tables[0] != null) && (dsAppointmentsList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsAppointmentsList.Tables[0].Rows.Count; i++)
                        {
                            SearchAppointmentModel obj = new SearchAppointmentModel();
                            obj.AppId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[i]["AppId"]);
                            obj.AppDate = dsAppointmentsList.Tables[0].Rows[i]["AppDate"].ToString();
                            obj.AppType = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["AppTypeId"]);
                            obj.AppNo = dsAppointmentsList.Tables[0].Rows[i]["AppNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["PatientId"]);
                            obj.PatientName = dsAppointmentsList.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.PatientRegNo = dsAppointmentsList.Tables[0].Rows[i]["PatientRegNo"].ToString();
                            obj.PIN = dsAppointmentsList.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Mobile = dsAppointmentsList.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.ConsultantName = dsAppointmentsList.Tables[0].Rows[i]["ConsultantName"].ToString();
                            obj.AppStatus = dsAppointmentsList.Tables[0].Rows[i]["AppStatus"].ToString();
                            obj.ResPhone = dsAppointmentsList.Tables[0].Rows[i]["ResPhone"].ToString();
                            obj.Address1 = dsAppointmentsList.Tables[0].Rows[i]["Address1"].ToString();
                            appointmentlist.Add(obj);
                        }
                    }
                    return appointmentlist;
                }
            }
        }
        /// <summary>
        /// Get details of appointment by appointmentId from database,Step three in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<SearchAppointmentModel> GetAppointmentById(AppointmentModel appointment)
        {
            SearchAppointmentModel obj = new SearchAppointmentModel();
            List<SearchAppointmentModel> appointmentlist = new List<SearchAppointmentModel>();
            List<Slice> slicelist = new List<Slice>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppointmentById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppId", appointment.AppId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsAppointmentsList = new DataSet();
                    adapter.Fill(dsAppointmentsList);
                    con.Close();
                    if ((dsAppointmentsList != null) && (dsAppointmentsList.Tables.Count > 0) && (dsAppointmentsList.Tables[0] != null) && (dsAppointmentsList.Tables[0].Rows.Count > 0))
                    {
                        obj.AppId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["AppId"]);
                        obj.AppDate = dsAppointmentsList.Tables[0].Rows[0]["AppDate"].ToString().Replace("/", "-");
                        obj.AppType = (dsAppointmentsList.Tables[0].Rows[0]["AppTypeId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["AppTypeId"]);
                        obj.AppNo = dsAppointmentsList.Tables[0].Rows[0]["AppNo"].ToString();
                        obj.PatientId = (dsAppointmentsList.Tables[0].Rows[0]["PatientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["PatientId"]);
                        obj.Title = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["Title"]);
                        obj.TitleText = dsAppointmentsList.Tables[0].Rows[0]["Salutation"].ToString();
                        obj.FirstName = dsAppointmentsList.Tables[0].Rows[0]["FirstName"].ToString();
                        obj.MiddleName = dsAppointmentsList.Tables[0].Rows[0]["MiddleName"].ToString();
                        obj.LastName = dsAppointmentsList.Tables[0].Rows[0]["LastName"].ToString();
                        obj.PatientName = dsAppointmentsList.Tables[0].Rows[0]["PatientName"].ToString();
                        obj.PatientRegNo = dsAppointmentsList.Tables[0].Rows[0]["PatientRegNo"].ToString();
                        obj.PIN = dsAppointmentsList.Tables[0].Rows[0]["PIN"].ToString();
                        obj.Email = dsAppointmentsList.Tables[0].Rows[0]["Email"].ToString();
                        obj.Mobile = dsAppointmentsList.Tables[0].Rows[0]["Mobile"].ToString();
                        obj.OffPhone = dsAppointmentsList.Tables[0].Rows[0]["OffPhone"].ToString();
                        obj.Address1 = dsAppointmentsList.Tables[0].Rows[0]["Address1"].ToString();
                        obj.Address2 = dsAppointmentsList.Tables[0].Rows[0]["Address2"].ToString();
                        obj.Street = dsAppointmentsList.Tables[0].Rows[0]["Street"].ToString();
                        obj.PlacePO = dsAppointmentsList.Tables[0].Rows[0]["PlacePO"].ToString();
                        obj.City = dsAppointmentsList.Tables[0].Rows[0]["City"].ToString();
                        obj.CountryName = dsAppointmentsList.Tables[0].Rows[0]["CountryName"].ToString();
                        obj.StateName = dsAppointmentsList.Tables[0].Rows[0]["StateName"].ToString();
                        obj.ConsultantId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["ConsultantId"]);
                        obj.ConsultantName = dsAppointmentsList.Tables[0].Rows[0]["ConsultantName"].ToString();
                        obj.BranchId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["BranchId"]);
                        obj.DeptId = Convert.ToInt32(dsAppointmentsList.Tables[0].Rows[0]["DeptId"]);
                        obj.DepartmentName = dsAppointmentsList.Tables[0].Rows[0]["DeptName"].ToString();
                        obj.Remarks = dsAppointmentsList.Tables[0].Rows[0]["Remarks"].ToString();
                        obj.AppStatus = dsAppointmentsList.Tables[0].Rows[0]["AppStatus"].ToString();
                        obj.ResPhone = dsAppointmentsList.Tables[0].Rows[0]["ResPhone"].ToString();
                        obj.RegNo = dsAppointmentsList.Tables[0].Rows[0]["RegNo"].ToString();

                        using (SqlCommand cmdslot = new SqlCommand("GetSliceDataByAppId", con))
                        {
                            con.Open();
                            cmdslot.CommandType = CommandType.StoredProcedure;
                            cmdslot.Parameters.AddWithValue("@AppId", obj.AppId);
                            SqlDataAdapter adapterslot = new SqlDataAdapter(cmdslot);
                            DataSet ds = new DataSet();
                            adapterslot.Fill(ds);
                            con.Close();
                            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                            {
                                for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Slice rsm = new Slice();
                                    rsm.SliceNo = Convert.ToInt32(ds.Tables[0].Rows[i]["SliceNo"]);
                                    rsm.SliceTime = ds.Tables[0].Rows[i]["SliceTime"].ToString();
                                    slicelist.Add(rsm);
                                }
                            }
                        }
                        obj.SliceData = slicelist;
                        appointmentlist.Add(obj);
                    }
                    return appointmentlist;
                }
            }
        }

        /// <summary>
        /// Filter and get appointment details
        /// </summary>
        /// <param name="appointment">appointment model with Patient's Name,address,Mobile Phone ,Pin,AppointmentFrom,Appointment To,Appointment type </param>
        /// <returns>List of appointment details</returns>
        public List<SearchAppointmentModel> SearchAppointment(AppointmentModel appointment)
        {
            List<SearchAppointmentModel> appList = new List<SearchAppointmentModel>();

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

                    DateTime oldFrom = DateTime.ParseExact(appointment.AppFromDate.Trim(), "dd-MM-yyyy", null);
                    appointment.AppFromDate = oldFrom.ToString("yyyy-MM-dd");

                    DateTime oldTo = DateTime.ParseExact(appointment.AppToDate.Trim(), "dd-MM-yyyy", null);
                    appointment.AppToDate = oldTo.ToString("yyyy-MM-dd");

                    cmd.Parameters.AddWithValue("@Name", appointment.Name.Trim());
                    cmd.Parameters.AddWithValue("@Address", appointment.Address.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", appointment.Mobile.Trim());
                    cmd.Parameters.AddWithValue("@Phone", appointment.Phone.Trim());
                    cmd.Parameters.AddWithValue("@PIN", appointment.PIN.Trim());
                    cmd.Parameters.AddWithValue("@AppFromDate", appointment.AppFromDate);
                    cmd.Parameters.AddWithValue("@AppToDate", appointment.AppToDate);
                    cmd.Parameters.AddWithValue("@RegNo", appointment.RegNo.Trim());
                    cmd.Parameters.AddWithValue("@AppointmentType", appointment.AppType);
                    cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsAppointments = new DataSet();
                    adapter.Fill(dsAppointments);
                    con.Close();
                    if ((dsAppointments != null) && (dsAppointments.Tables.Count > 0) && (dsAppointments.Tables[0] != null) && (dsAppointments.Tables[0].Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsAppointments.Tables[0].Rows.Count; i++)
                        {
                            SearchAppointmentModel obj = new SearchAppointmentModel();
                            obj.AppId = Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["AppId"]);
                            obj.AppDate = dsAppointments.Tables[0].Rows[i]["AppDate"].ToString();
                            obj.AppType = (dsAppointments.Tables[0].Rows[0]["AppType"] == DBNull.Value) ? 0 : Convert.ToInt32(dsAppointments.Tables[0].Rows[0]["AppType"]);//Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["AppType"]);
                            obj.AppNo = dsAppointments.Tables[0].Rows[i]["AppNo"].ToString();
                            obj.RegNo = dsAppointments.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PatientId = (dsAppointments.Tables[0].Rows[0]["PatientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dsAppointments.Tables[0].Rows[0]["PatientId"]);//Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["PatientId"]);
                            obj.PatientName = dsAppointments.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.PIN = dsAppointments.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Mobile = dsAppointments.Tables[0].Rows[i]["ContactNumber"].ToString();
                            obj.CFirstName = dsAppointments.Tables[0].Rows[i]["ConsultantName"].ToString();
                            obj.AppStatus = dsAppointments.Tables[0].Rows[i]["Status"].ToString();
                            obj.CancelReason = dsAppointments.Tables[0].Rows[i]["CancelReason"].ToString();
                            obj.ResPhone = dsAppointments.Tables[0].Rows[i]["TelePhone"].ToString();
                            obj.Address1 = dsAppointments.Tables[0].Rows[i]["Address"].ToString();
                            obj.BranchId = Convert.ToInt32(dsAppointments.Tables[0].Rows[i]["BranchId"]);
                            appList.Add(obj);
                        }
                    }
                    return appList;
                }
            }
        }
        /// <summary>
        /// Filter Patients and get patient details
        /// </summary>
        /// <param name="patientDetails">PatientSearchModel with ConsultantId,Patient's Name,RegNo,Mobile,ResNo,PIN,Policy Number,Identity number,Address, mode </param>
        /// <returns>List of patient details</returns>
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
                    cmd.Parameters.AddWithValue("@Name", patientDetails.Name.Trim());
                    cmd.Parameters.AddWithValue("@RegNo", patientDetails.RegNo.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", patientDetails.Mobile);
                    cmd.Parameters.AddWithValue("@ResNo", patientDetails.ResNo);
                    cmd.Parameters.AddWithValue("@PIN", patientDetails.PIN);
                    cmd.Parameters.AddWithValue("@PolicyNo", patientDetails.PolicyNo);
                    cmd.Parameters.AddWithValue("@IdentityNo", patientDetails.IdentityNo);
                    cmd.Parameters.AddWithValue("@Address", patientDetails.Address.Trim());
                    cmd.Parameters.AddWithValue("@Mode", patientDetails.Mode);
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
        /// <summary>
        /// Filter by Registration number and get patient details
        /// </summary>
        /// <param name="regNo">Register number</param>
        /// <returns>List of patient details</returns>
        public List<PatientListModel> GetPatientByRegNo(string regNo)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatientsByRegNo", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
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
        /// <summary>
        ///  get appointment details, Filtered by parameters
        /// </summary>
        /// <param name="appointment">AppointmentModel with ConsultantId,AppDate,DeptId </param>
        /// <returns>List of appointment details</returns>
        public List<Appointments> GetAppointments(AppointmentModel appointment)
        {

            List<Appointments> Appointmentlist = new List<Appointments>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string AppQuery = "[stLH_GetAppOfaDay]";
                using (SqlCommand cmd = new SqlCommand(AppQuery, con))
                {
                    con.Open();
                    DateTime appDate = DateTime.ParseExact(appointment.AppDate.Trim(), "dd-MM-yyyy", null);
                    appointment.AppDate = appDate.ToString("yyyy-MM-dd");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                    cmd.Parameters.AddWithValue("@AppDate", appointment.AppDate);
                    cmd.Parameters.AddWithValue("@DeptId", appointment.DeptId);
                    cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Appointments obj = new Appointments();
                            obj.AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["AppId"]);
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"].ToString());
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = ds.Tables[0].Rows[i]["TimeNo"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Gender = Convert.ToInt32(ds.Tables[0].Rows[i]["Gender"]);
                            obj.AppDate = ds.Tables[0].Rows[i]["AppDate"].ToString();
                            obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Address1 = ds.Tables[0].Rows[i]["Address1"].ToString();
                            Appointmentlist.Add(obj);
                        }
                    }
                    return Appointmentlist;
                }
            }
        }

        /// <summary>
        ///  get Scheme  details, Filtered by Consultant Id
        /// </summary>
        /// <param name="consultantid"> </param>
        /// <returns>List of Scheme details</returns>
        public List<SchemeModel> GetSchemeByConsultant(Int32 consultantid)
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
        /// <summary>
        /// Get Details of patient
        /// </summary>
        /// <param name="patientId">Primary key of LH_Patient Table</param>
        /// <returns>patient details</returns>

        public List<PatientModel> GetPatient(Int32 patientId)
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
                        for (Int32 i = 0; i < dsPatientList.Tables[0].Rows.Count; i++)
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
        /// <summary>
        /// Get Details of patient
        /// </summary>
        /// <param name="patientId">Primary key of LH_Patient Table</param>
        /// <returns>patient details</returns>
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
        /// <summary>
        /// Get Details of patient
        /// </summary>
        /// <param name="patientId">Primary key of LH_Patient Table</param>
        /// <returns>patient details</returns>
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
        /// <summary>
        /// Get Details of patient
        /// </summary>
        /// <param name="patientId">Primary key of LH_Patient Table</param>
        /// <returns>patient details</returns>
        public List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsim)
        {
            List<SheduleGetDataModel> scheduleList = new List<SheduleGetDataModel>();
            DateTime scheduleDate = DateTime.ParseExact(gsim.DateValue.Trim(), "dd-MM-yyyy", null);
            gsim.DateValue = scheduleDate.ToString("yyyy-MM-dd");
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetScheduleByDateConsultants", con))
                {
                    int listdepcount = gsim.Departments.Count;
                    int listconsultantcount = gsim.Consultant.Count;
                    string DepIds = "";
                    string consultantIds = "";
                    if (listdepcount > 0)
                        DepIds = string.Join(",", gsim.Departments.ToArray());
                    if (listconsultantcount > 0)
                        consultantIds = string.Join(",", gsim.Consultant.ToArray());
                    int consultantId = 0;
                    int depId = 0;
                    int branchId = 0;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ConsultantId", consultantIds);
                    cmd.Parameters.AddWithValue("@AppDate", gsim.DateValue);
                    cmd.Parameters.AddWithValue("@BranchId", gsim.BranchId);
                    cmd.Parameters.AddWithValue("@DepartmentId", DepIds);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsScheduleList = new DataSet();
                    adapter.Fill(dsScheduleList);
                    con.Close();
                    List<Label> labelsList = new List<Label>();
                    SheduleGetDataModel sgdm = new SheduleGetDataModel();
                    if ((dsScheduleList != null) && (dsScheduleList.Tables.Count > 0) && (dsScheduleList.Tables[0] != null) && (dsScheduleList.Tables[0].Rows.Count > 0))
                    {
                        for (Int32 j = 0; j < dsScheduleList.Tables[0].Rows.Count; j++)
                        {
                            int curConsultant = Convert.ToInt32(dsScheduleList.Tables[0].Rows[j]["ConsultantId"].ToString());
                            int curBranch = Convert.ToInt32(dsScheduleList.Tables[0].Rows[j]["BranchId"].ToString());
                            int curDep = Convert.ToInt32(dsScheduleList.Tables[0].Rows[j]["DeptId"].ToString());
                            if (consultantId != curConsultant || depId != curDep)
                            {
                                if (consultantId != 0)
                                {
                                    sgdm.labels = labelsList;
                                    sgdm.slotlength = labelsList.Count;
                                    scheduleList.Add(sgdm);
                                }
                                consultantId = curConsultant;
                                branchId = curBranch;
                                depId = curDep;
                                labelsList = new List<Label>();
                                sgdm = new SheduleGetDataModel();
                                sgdm.drName = dsScheduleList.Tables[0].Rows[j]["ConsultantName"].ToString();
                                sgdm.deptName = dsScheduleList.Tables[0].Rows[j]["DeptName"].ToString();
                                sgdm.id = consultantId;
                            }
                            Label lb = new Label();
                            lb.SliceNo = dsScheduleList.Tables[0].Rows[j]["SliceNo"].ToString();
                            lb.ConsultantName = dsScheduleList.Tables[0].Rows[j]["ConsultantName"].ToString();
                            lb.AppId = dsScheduleList.Tables[0].Rows[j]["AppId"].ToString();
                            lb.AppNo = dsScheduleList.Tables[0].Rows[j]["AppNo"].ToString();
                            lb.AppDate = gsim.DateValue;
                            lb.SliceTime = dsScheduleList.Tables[0].Rows[j]["SliceTime"].ToString();
                            lb.PatientId = dsScheduleList.Tables[0].Rows[j]["PatientId"].ToString();
                            lb.RegNo = dsScheduleList.Tables[0].Rows[j]["RegNo"].ToString();
                            lb.PatientName = dsScheduleList.Tables[0].Rows[j]["PatientName"].ToString();
                            lb.MobileNumber = dsScheduleList.Tables[0].Rows[j]["MobileNo"].ToString();
                            lb.DeptName = dsScheduleList.Tables[0].Rows[j]["DeptName"].ToString();
                            lb.DeptId = Convert.ToInt32(dsScheduleList.Tables[0].Rows[j]["DeptId"]);
                            labelsList.Add(lb);
                        }
                    }
                    if (labelsList.Count > 0)
                    {
                        sgdm.labels = labelsList;
                        scheduleList.Add(sgdm);
                    }

                }


                return scheduleList;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Cancelling appointment
        /// </summary>
        /// <param name="appointment">AppId,Reason,UserId</param>
        /// <returns>Success Or Error Details</returns>
        public string DeleteAppointment(AppointmentModel appointment)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_CancelAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppId", appointment.AppId);
                    cmd.Parameters.AddWithValue("@CancelReason", appointment.Reason);
                    cmd.Parameters.AddWithValue("@UserId", appointment.UserId);
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
                    if (retD == "Saved Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = retD;
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public string UpdateAppointmentStatus(AppointmentModel appointment)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateAppointmentStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppId", appointment.AppId);
                    cmd.Parameters.AddWithValue("@CancelReason", appointment.Reason);
                    cmd.Parameters.AddWithValue("@NewStatus", appointment.NewStatus);
                    cmd.Parameters.AddWithValue("@UserId", appointment.UserId);
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
                    if (retD == "Saved Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = retD;
                    }
                }
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cisr"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Cancel Consultation
        /// </summary>
        /// <param name="consultation">ConsultationId,CancelReason,UserId</param>
        /// <returns>Success or Error details</returns>
        public string CancelConsultation(ConsultationModel consultation)
        {
            string response = string.Empty;
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
        /// <summary>
        /// Postpone appointment
        /// </summary>
        /// <param name="app">ConsultantId,AppDate,AppNo,SliceNo,SliceTime,UserId</param>
        /// <returns>Appointment valid or not</returns>
        public string PostponeAppointment(Appointments app)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ActionPostponeApp", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime postponeDate = DateTime.ParseExact(app.AppDate.Trim(), "dd-MM-yyyy", null);
                    app.AppDate = postponeDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@AppId", app.AppId);
                    cmd.Parameters.AddWithValue("@BranchId", app.BranchId);
                    cmd.Parameters.AddWithValue("@ConsultantId", app.ConsultantId);
                    cmd.Parameters.AddWithValue("@AppDate", app.AppDate);
                    cmd.Parameters.AddWithValue("@UserId", app.UserId);
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

                    if (retD.ToString() == "Appointment Postponed")
                    {
                        response = "success";
                        SqlCommand deletesymptomCMD = new SqlCommand("stLH_DeleteSliceTimes", con);
                        deletesymptomCMD.CommandType = CommandType.StoredProcedure;
                        deletesymptomCMD.Parameters.AddWithValue("@AppId", app.AppId);
                        var isDeleted = deletesymptomCMD.ExecuteNonQuery();
                        for (int b = 0; b < app.SliceData.Count; b++)
                        {
                            SqlCommand savesliceCMD = new SqlCommand("stLH_SaveAppointmentSlice", con);
                            savesliceCMD.CommandType = CommandType.StoredProcedure;
                            savesliceCMD.Parameters.AddWithValue("@AppNo", app.AppNo);
                            savesliceCMD.Parameters.AddWithValue("@SliceNo", app.SliceData[b].SliceNo);
                            savesliceCMD.Parameters.AddWithValue("@ConsultantId", app.ConsultantId);
                            savesliceCMD.Parameters.AddWithValue("@SliceTime", app.SliceData[b].SliceTime);
                            savesliceCMD.Parameters.AddWithValue("@AppDate", app.AppDate);
                            savesliceCMD.Parameters.AddWithValue("@PatientId", app.PatientId);
                            savesliceCMD.Parameters.AddWithValue("@AppId", app.AppId);
                            savesliceCMD.Parameters.AddWithValue("@AppType", app.AppType);
                            SqlParameter retValueV = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            savesliceCMD.Parameters.Add(retValueV);
                            SqlParameter retDescrV = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            savesliceCMD.Parameters.Add(retDescrV);
                            var isInsertedSliceData = savesliceCMD.ExecuteNonQuery();
                            var retSlice = retValueV.Value;
                            var descripSlice = retDescrV.Value.ToString();
                        }
                    }
                    else
                    {
                        response = retD;
                    }
                    con.Close();
                }
            }
            return response;
        }
        /// <summary>
        /// appointment available checking
        /// </summary>
        /// <param name="app">ConsultantId,AppDate,TimeSliceFirst,TimeSliceFirst,RequiredSlots count</param>
        /// <returns>Appointment valid or not</returns>
        public string AppoinmentValidCheck(AppoinmentValidCheckModel appoinment)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_AppoinmentValidCheck", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime appDate = DateTime.ParseExact(appoinment.AppDate.Trim(), "dd/MM/yyyy", null);
                    cmd.Parameters.AddWithValue("@ConsultantId", appoinment.ConsultantId);
                    cmd.Parameters.AddWithValue("@AppDate", appDate);
                    cmd.Parameters.AddWithValue("@TimeSliceFirst", appoinment.TimeSliceFirst);
                    cmd.Parameters.AddWithValue("@RequiredSlots", appoinment.RequiredSlots);
                    SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retDesc);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    var retD = retDesc.Value.ToString();
                    con.Close();
                    response = retD;
                }
            }
            return response;
        }

        /// <summary>
        /// Change Consultation status to urgent
        /// </summary>
        /// <param name="consultation">ConsultationId,UserId,LocationId</param>
        /// <returns>Success or reason for failure</returns>
        public string SetUrgentConsultation(ConsultationModel consultation)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ActionSetUrgentConsultation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultationId", consultation.ConsultationId);
                    cmd.Parameters.AddWithValue("@UserId", consultation.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", consultation.LocationId);
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
                    var isSetUrgent = cmd.ExecuteNonQuery();
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
        /// <summary>
        /// Get Rate 
        /// </summary>
        /// <param name="cm">ConsultantId,PatientId,ItemId</param>
        /// <returns>Rate of </returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Save consultation details to database,Step three in code execution flow
        /// </summary>
        /// <param name="consultations"></param>
        /// <returns></returns>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            List<ConsultationModel> consultaionsList = new List<ConsultationModel>();
            var descrip = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultation", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (consultations.ConsultationId == null || consultations.ConsultationId == 0)
                        {
                            cmd.Parameters.AddWithValue("@ConsultationId", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);
                        }
                        DateTime ConsultDate = DateTime.ParseExact(consultations.ConsultDate.Trim(), "dd-MM-yyyy", null);
                        cmd.Parameters.AddWithValue("@ConsultDate", ConsultDate);
                        cmd.Parameters.AddWithValue("@AppId", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ConsultantId", consultations.ConsultantId);
                        cmd.Parameters.AddWithValue("@PatientId", consultations.PatientId);
                        cmd.Parameters.AddWithValue("@Symptoms", consultations.OtherReasonForVisit);
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
                            con.Open();

                            for (int b = 0; b < consultations.Symptoms.Count; b++)
                            {
                                SqlCommand savesymptomCMD = new SqlCommand("stLH_SaveConsultationSymptoms", con);
                                savesymptomCMD.CommandType = CommandType.StoredProcedure;
                                savesymptomCMD.Parameters.AddWithValue("@ConsultationId", int.Parse(ret.ToString()));
                                savesymptomCMD.Parameters.AddWithValue("@SymptomId", consultations.Symptoms[b].SymptomId);
                                var isInsertedSymptom1 = savesymptomCMD.ExecuteNonQuery();
                            }
                            con.Close();
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

        public List<ConsultationModel> UpdateConsultationSymptoms(ConsultationModel consultations)
        {
            List<ConsultationModel> consultaionsList = new List<ConsultationModel>();
            var descrip = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateConsultationSymptoms", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);
                        cmd.Parameters.AddWithValue("@Symptoms", consultations.OtherReasonForVisit);

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
                        descrip = retDesc.Value.ToString();

                        con.Close();
                        if (descrip == "Saved Successfully")
                        {
                            consultations.RetDesc = "Saved Successfully";
                            con.Open();
                            SqlCommand deletesymptomCMD = new SqlCommand("stLH_DeleteConsultationSymptoms", con);
                            deletesymptomCMD.CommandType = CommandType.StoredProcedure;
                            deletesymptomCMD.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);
                            var isDeleted = deletesymptomCMD.ExecuteNonQuery();
                            for (int b = 0; b < consultations.Symptoms.Count; b++)
                            {
                                SqlCommand savesymptomCMD = new SqlCommand("stLH_SaveConsultationSymptoms", con);
                                savesymptomCMD.CommandType = CommandType.StoredProcedure;
                                savesymptomCMD.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);
                                savesymptomCMD.Parameters.AddWithValue("@SymptomId", consultations.Symptoms[b].SymptomId);
                                var isInsertedSymptom1 = savesymptomCMD.ExecuteNonQuery();
                            }
                            con.Close();
                            consultations.RetVal = -1;
                            consultations.RetDesc = descrip;
                            consultaionsList.Add(consultations);
                        }
                        else
                        {
                            consultations.RetVal = -2;
                            consultations.RetDesc = descrip;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get List of sponsors of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>List of sponsors details</returns>
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
                            obj.OpenDate = dsSponsorList.Tables[0].Rows[i]["OpenDate"].ToString().Substring(0, 10).Replace("/", "-");
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

                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDeptById", con))
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
                            obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                            consultantList.Add(obj);
                        }
                    }
                    return consultantList;
                }
            }
        }

        public List<ConsultantModel> GetConsultants(DepartmentIdModel dept)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                int listcount = dept.Departments.Count;
                string DepIds = "";
                if (listcount > 0)
                    DepIds = string.Join(",", dept.Departments.ToArray());
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDepts", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", DepIds);
                    cmd.Parameters.AddWithValue("@ShowExternal", dept.ShowExternal);
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
                            obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                            consultantList.Add(obj);
                        }
                    }
                    return consultantList;
                }
            }
        }
        /// <summary>
        /// Get Consultation Filtered by PatientId,ConsultantId
        /// </summary>
        /// <param name="cm">PatientId,ConsultantId</param>
        /// <returns>Get Consultation details</returns>
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
        /// <summary>
        /// Get Consultation Filtered by PatientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>Get Consultation List</returns>
        public List<PatientConsultationModel> GetConsultationDataById(int Id)
        {
            PatientConsultationModel obj = new PatientConsultationModel();
            List<PatientConsultationModel> consultationList = new List<PatientConsultationModel>();
            List<RegSymptomsModel> SymptomsList = new List<RegSymptomsModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultationById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantionId", Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[0]["ConsultationId"]);
                        obj.ReasonForVisit = ds.Tables[0].Rows[0]["Symptoms"].ToString();
                    }
                }

                if (obj.ConsultationId != 0)
                {
                    using (SqlCommand cmd = new SqlCommand("GetSymptomByConsultationId", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ConsultationId", obj.ConsultationId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        con.Close();
                        if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                RegSymptomsModel rsm = new RegSymptomsModel();
                                rsm.SymptomId = Convert.ToInt32(ds.Tables[0].Rows[i]["SymptomId"]);
                                rsm.NewsymDesc = ds.Tables[0].Rows[i]["SymptomDesc"].ToString();
                                SymptomsList.Add(rsm);
                            }
                        }
                    }
                }
                obj.Symptoms = SymptomsList;
                consultationList.Add(obj);
                return consultationList;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
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
                            obj.RegDate = ds.Tables[0].Rows[i]["RegDate"].ToString().Replace("/", "-");
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ItemId = Convert.ToInt32(ds.Tables[0].Rows[i]["ItemId"]);
                            obj.RegAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["RegAmount"]);
                            obj.ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.ExpiryVisits = Convert.ToInt32(ds.Tables[0].Rows[i]["ExpiryVisits"]);
                            obj.VisitsMade = Convert.ToInt32(ds.Tables[0].Rows[i]["VisitsMade"]);
                            obj.Emergency = Convert.ToInt32(ds.Tables[0].Rows[i]["Emergency"]);
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString().Replace("/", "-");
                            obj.ConsultFee = ds.Tables[0].Rows[i]["ConsultFee"].ToString();
                            string validupto = ds.Tables[0].Rows[i]["ExpiryDate"].ToString().Replace("/", "-");
                            string consultationExpiry = ds.Tables[0].Rows[i]["ConsultationExpiryDate"].ToString().Replace("/", "-");
                            string todaydateStr = DateTime.Now.ToString("dd-MM-yyyy");
                            DateTime todaydate = DateTime.ParseExact(todaydateStr, "dd-MM-yyyy", null);
                            DateTime validuptodttime = DateTime.ParseExact(validupto, "dd-MM-yyyy", null);//Convert.ToDateTime(validupto);
                            DateTime validuptodttimeConsultation = DateTime.ParseExact(consultationExpiry, "dd-MM-yyyy", null);//Convert.ToDateTime(validupto);
                            if (todaydate < validuptodttime)
                            {
                                obj.IsRegistrationExpired = false;
                            }
                            else
                            {
                                obj.IsRegistrationExpired = true;
                            }

                            if (todaydate < validuptodttimeConsultation)
                            {
                                obj.IsConsultationExpired = false;
                            }
                            else
                            {
                                obj.IsConsultationExpired = true;
                            }
                            obj.ExpiryDate = validupto;
                            patregdataList.Add(obj);
                        }
                    }
                    return patregdataList;
                }
            }
        }

        public FrontOfficePBarModel GetFrontOfficeProgressBars(string todaydate)
        {
            FrontOfficePBarModel fopb = new FrontOfficePBarModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime appDate = DateTime.ParseExact(todaydate.Trim(), "dd-MM-yyyy", null);
                todaydate = appDate.ToString("yyyy-MM-dd");
                List<PercentageCountGetModel> AppcountGetList = new List<PercentageCountGetModel>();
                List<PercentageCountGetModel> ConscountGetList = new List<PercentageCountGetModel>();
                SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetAppointmentCount", con);
                appointmentCountCMD.CommandType = CommandType.StoredProcedure;
                appointmentCountCMD.Parameters.AddWithValue("@AppDate", todaydate);
                con.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(appointmentCountCMD);
                DataSet ds = new DataSet();
                adapter1.Fill(ds);
                con.Close();
                int AppTotalCount = 0;
                int AppStatA = 0;
                int AppStatC = 0;
                int AppStatF = 0;
                int AppStatW = 0;
                int AppStatUnknown = 0;

                int ConsTotalCount = 0;
                int ConsStatW = 0;
                int ConsStatF = 0;
                int ConsStatC = 0;
                int ConsStatO = 0;
                int ConsStatUnknown = 0;
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PatientModel obj = new PatientModel();
                        string StatusName = ds.Tables[0].Rows[i]["StatusName"].ToString();
                        if (StatusName == "A")
                        {
                            AppStatA = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "C")
                        {
                            AppStatC = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "F")
                        {
                            AppStatF = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "W")
                        {
                            AppStatW = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else
                        {
                            AppStatUnknown = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                        }
                        AppTotalCount = AppTotalCount + Convert.ToInt32(ds.Tables[0].Rows[i]["StatusCount"]);
                    }
                }
                SqlCommand consultantcountCMD = new SqlCommand("stLH_GetConsultationCount", con);
                consultantcountCMD.CommandType = CommandType.StoredProcedure;
                consultantcountCMD.Parameters.AddWithValue("@ConsultDate", todaydate);
                con.Open();
                SqlDataAdapter adapter2 = new SqlDataAdapter(consultantcountCMD);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2);
                con.Close();
                if ((ds2 != null) && (ds2.Tables.Count > 0) && (ds2.Tables[0] != null) && (ds2.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        PatientModel obj = new PatientModel();
                        string StatusName = ds2.Tables[0].Rows[i]["StatusName"].ToString();
                        if (StatusName == "W")
                        {
                            ConsStatW = Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "F")
                        {
                            ConsStatF = Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "C")
                        {
                            ConsStatC = Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "O")
                        {
                            ConsStatO = Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                        }
                        else
                        {
                            ConsStatUnknown = Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                        }
                        ConsTotalCount = ConsTotalCount + Convert.ToInt32(ds2.Tables[0].Rows[i]["StatusCount"]);
                    }
                }
                fopb.AppPercA = (decimal)AppStatA;
                fopb.AppPercC = (decimal)AppStatC;
                fopb.AppPercF = (decimal)AppStatF;
                fopb.AppPercW = (decimal)AppStatW;

                fopb.ConsPercW = (decimal)ConsStatW;
                fopb.ConsPercF = (decimal)ConsStatF;
                fopb.ConsPercC = (decimal)ConsStatC;
                fopb.ConsPercO = (decimal)ConsStatO;

            }
            return fopb;
        }
    }
}