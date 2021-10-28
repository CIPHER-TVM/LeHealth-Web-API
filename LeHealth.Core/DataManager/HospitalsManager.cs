using Microsoft.Extensions.Configuration;
using LeHealth.Core.Interface;
using LeHealth.Entity;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;

namespace LeHealth.Core.DataManager
{
    public class HospitalsManager : IHospitalsManager, IDisposable
    {
        bool disposed = false;

        private readonly string _connStr;
        /// <summary>
        /// Initializing connection string
        /// </summary>
        /// <param name="_configuration"></param>
        public HospitalsManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        //Garbage Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }

            disposed = true;
        }

        ~HospitalsManager()
        {
            Dispose(false);
        }


        /// <summary>
        /// Get Hospital list from database.Step three in code execution flow
        /// </summary>
        /// <returns></returns>

        public List<HospitalModel> GetUserHospitals()
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsHospitalList = new DataSet();
                    adapter.Fill(dsHospitalList);
                    con.Close();


                    if ((dsHospitalList != null) && (dsHospitalList.Tables.Count > 0) && (dsHospitalList.Tables[0] != null) && (dsHospitalList.Tables[0].Rows.Count > 0))
                        hospitalList = dsHospitalList.Tables[0].ToListOfObject<HospitalModel>();
                    return hospitalList;

                }
            }

        }
        /// <summary>
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", 0);
                    cmd.Parameters.AddWithValue("@Active", 1);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DepartmentModel obj = new DepartmentModel();
                            obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
                            obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                            obj.DeptCode = ds.Tables[0].Rows[i]["DeptCode"].ToString();
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }
        /// <summary>
        /// Get consultant list from database,Step three in code execution flow
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<ConsultantModel> GetConsultant(int deptId)
        {
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDept", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", deptId); // avoid hard coding
                    cmd.Parameters.AddWithValue("@ShowExternal", false);
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
                            //obj.ConsultantCode = ds.Tables[0].Rows[i]["ConsultantCode"].ToString();
                            obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
                            consultantList.Add(obj);
                        }
                    }
                    return consultantList;
                }
            }
        }
        /// <summary>
        /// Get appoinment list from database,Step three in code execution flow
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public List<Appointments> GetAppointments(AppointmentModel appointment)
        {
            List<Appointments> Appointmentlist = new List<Appointments>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                string AppQuery = "[stLH_GetAppOfaDay]";
                using (SqlCommand cmd = new SqlCommand(AppQuery, con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                    cmd.Parameters.AddWithValue("@AppDate", appointment.AppDate);
                    cmd.Parameters.AddWithValue("@DeptId", appointment.DeptId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Appointments obj = new Appointments();
                            obj.AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["AppId"]);
                            // obj.AppType =Convert.ToInt32( ds.Tables[0].Rows[i]["AppType"]);
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = ds.Tables[0].Rows[i]["TimeNo"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            Appointmentlist.Add(obj);
                        }
                    }
                    return Appointmentlist;
                }
            }
        }

        /// <summary>
        /// Get consultantion's list from database, Step three in code execution flow
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
        {
            List<ConsultationModel> appointmentlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Status", consultation.Status);
                    cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
                    cmd.Parameters.AddWithValue("@ConsultDate", consultation.ConsultantDate);
                    cmd.Parameters.AddWithValue("@BranchId", 0);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel();
                            obj.TokenNO = ds.Tables[0].Rows[i]["TokenNO"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["Sponsor"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = (ds.Tables[0].Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["TimeNo"]);
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();// == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["RegNo"]);//int.Parse(ds.Tables[0].Rows[i]["RegNo"].ToString());
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            appointmentlist.Add(obj);
                        }
                    }
                    return appointmentlist;
                }
            }
        }

        public List<ConsultationModel> GetAllConsultation()
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllConsultation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultationId", 0);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultationId"]);
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.ConsultTypeStr = ds.Tables[0].Rows[i]["ConsultType"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.Pin = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Symptoms = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["ConsultationSponsors"].ToString();
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }

        public List<PatientModel> SearchPatient(PatientModel patient)
        {
            List<PatientModel> Consultationlist = new List<PatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatients", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", patient.PatientName);
                    cmd.Parameters.AddWithValue("@ConsultantId", patient.ConsultantId);
                    cmd.Parameters.AddWithValue("@RegNo", patient.RegNo);
                    cmd.Parameters.AddWithValue("@Mobile", patient.Mobile);
                    cmd.Parameters.AddWithValue("@RegFromDate", patient.RegFromDate);
                    cmd.Parameters.AddWithValue("@RegToDate", patient.RegToDate);
                    cmd.Parameters.AddWithValue("@Phone", patient.Mobile);
                    cmd.Parameters.AddWithValue("@Address", patient.Address1);
                    cmd.Parameters.AddWithValue("@PIN", patient.PIN);
                    cmd.Parameters.AddWithValue("@PolicyNo", patient.PolicyNo);
                    cmd.Parameters.AddWithValue("@IdentityNo", patient.IdentityNo);
                    cmd.Parameters.AddWithValue("@BranchId", patient.BranchId);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            PatientModel obj = new PatientModel();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Age = ds.Tables[0].Rows[i]["Age"].ToString();
                            obj.PIN = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Telephone = ds.Tables[0].Rows[i]["Telephone"].ToString();
                            obj.Address1 = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.SponsorName = ds.Tables[0].Rows[i]["SponsorName"].ToString();
                            obj.SponsorId = ds.Tables[0].Rows[i]["SponsorId"].ToString();
                            obj.EnableSponsorConsent = ds.Tables[0].Rows[i]["EnableSponsorConsent"].ToString();
                            obj.PolicyNo = ds.Tables[0].Rows[i]["PolicyNo"].ToString();
                            obj.EmirateID = ds.Tables[0].Rows[i]["EmirateID"].ToString();
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }


        public List<ConsultationModel> SearchConsultation(ConsultationModel consultation)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", consultation.PatientName);
                    cmd.Parameters.AddWithValue("@RegNo", consultation.RegNo);
                    cmd.Parameters.AddWithValue("@Mobile", consultation.Mobile);
                    cmd.Parameters.AddWithValue("@FromDate", consultation.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", consultation.ToDate);
                    cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
                    cmd.Parameters.AddWithValue("@Phone", consultation.Mobile);
                    cmd.Parameters.AddWithValue("@Address", consultation.Address);
                    cmd.Parameters.AddWithValue("@PIN", consultation.Pin);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultationId"]);
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.ConsultTypeStr = ds.Tables[0].Rows[i]["ConsultType"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.Pin = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Symptoms = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Telephone = ds.Tables[0].Rows[i]["Telephone"].ToString();
                            obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["ConsultationSponsors"].ToString();
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }

        public List<TabOrderModel> GetTabOrder(string screenname)
        {
            List<TabOrderModel> Consultationlist = new List<TabOrderModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetTabOrder", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ScreenName", screenname);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            TabOrderModel obj = new TabOrderModel();
                            obj.ScreenName = ds.Tables[0].Rows[i]["ScreenName"].ToString();
                            obj.ObjectName = ds.Tables[0].Rows[i]["ObjectName"].ToString();
                            obj.ObjectOrder = Convert.ToInt32(ds.Tables[0].Rows[i]["ObjectOrder"]);
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }




        /// <summary>
        /// Save appoinments to database,Step three in code execution flow
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>
        public List<Appointments> InsertUpdateAppointment(Appointments appointments)
        {
            List<Appointments> appointmentsList = new List<Appointments>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_InsertAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (appointments == null || appointments.PatientId <= 0)
                        cmd.Parameters.AddWithValue("@PatientId", DBNull.Value);

                    else
                        cmd.Parameters.AddWithValue("@PatientId", appointments.PatientId);

                    //string DateString = appointments.AppDate;
                    //IFormatProvider culture = new CultureInfo("en-US", true);
                    //DateTime dateVal = DateTime.ParseExact(DateString, "yyyy-MM-dd", culture);


                    cmd.Parameters.AddWithValue("@AppId", appointments.AppId);
                    cmd.Parameters.AddWithValue("@ConsultantId", appointments.ConsultantId);
                    cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AppDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AppNo", appointments.AppNo);
                    cmd.Parameters.AddWithValue("@SliceNo", appointments.SliceNo);
                    cmd.Parameters.AddWithValue("@SliceTime", appointments.SliceTime);
                    cmd.Parameters.AddWithValue("@Title", appointments.Title);
                    cmd.Parameters.AddWithValue("@FirstName", appointments.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", appointments.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", appointments.LastName);
                    cmd.Parameters.AddWithValue("@Address1", appointments.Address1);
                    cmd.Parameters.AddWithValue("@Address2", appointments.Address2);
                    cmd.Parameters.AddWithValue("@Street", appointments.Street);
                    cmd.Parameters.AddWithValue("@PlacePo", appointments.PlacePO);
                    cmd.Parameters.AddWithValue("@PIN", appointments.PIN);
                    cmd.Parameters.AddWithValue("@City", appointments.City);
                    cmd.Parameters.AddWithValue("@State", appointments.State);
                    cmd.Parameters.AddWithValue("@CountryId", appointments.CountryId);
                    cmd.Parameters.AddWithValue("@Mobile", appointments.Mobile);
                    cmd.Parameters.AddWithValue("@ResPhone", appointments.ResPhone);
                    cmd.Parameters.AddWithValue("@OffPhone", appointments.OffPhone);
                    cmd.Parameters.AddWithValue("@Email", appointments.Email);
                    cmd.Parameters.AddWithValue("@Remarks", appointments.Remarks);
                    cmd.Parameters.AddWithValue("@Reminder", appointments.Reminder);
                    cmd.Parameters.AddWithValue("@AppStatus", appointments.AppStatus);
                    cmd.Parameters.AddWithValue("@CancelReason", appointments.CancelReason);
                    cmd.Parameters.AddWithValue("@UserId", appointments.UserId);
                    cmd.Parameters.AddWithValue("@AppTypeId", 1);
                    cmd.Parameters.AddWithValue("@SessionId", appointments.SessionId);
                    cmd.Parameters.AddWithValue("@RetVal", appointments.RetVal);
                    cmd.Parameters.AddWithValue("@RetDesc", appointments.RetDesc);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return appointmentsList;
        }
        /// <summary>
        /// Save consultation details to database,Step three in code execution flow
        /// </summary>
        /// <param name="consultations"></param>
        /// <returns></returns>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            List<ConsultationModel> consultaionsList = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (consultations.ConsultationId == null || consultations.ConsultationId == 0)
                        cmd.Parameters.AddWithValue("@ConsultationId", DBNull.Value);

                    else
                        cmd.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);

                    cmd.Parameters.AddWithValue("@ConsultDate", consultations.ConsultDate);
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
                    cmd.Parameters.AddWithValue("@RetSeqNo", consultations.RetSeqNo);
                    cmd.Parameters.AddWithValue("@SessionId", consultations.SessionId);
                    cmd.Parameters.AddWithValue("@RetVal", consultations.RetVal);
                    cmd.Parameters.AddWithValue("@RetDesc", consultations.RetDesc);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return consultaionsList;
        }


        public List<ConsultationModel> GetAllConsultation()
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllConsultation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultationId", 0);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultationId"]);
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.ConsultType2 = ds.Tables[0].Rows[i]["ConsultType"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PIN = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Symptoms = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["ConsultationSponsors"].ToString();
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }
        public List<ConsultationModel> SearchConsultation(ConsultationModel consultation)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultation", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", consultation.PatientName);
                    cmd.Parameters.AddWithValue("@RegNo", consultation.RegNo);
                    cmd.Parameters.AddWithValue("@Mobile", consultation.Mobile);
                    cmd.Parameters.AddWithValue("@FromDate", consultation.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", consultation.ToDate);
                    cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
                    cmd.Parameters.AddWithValue("@Phone", consultation.Mobile);
                    cmd.Parameters.AddWithValue("@Address", consultation.Address);
                    cmd.Parameters.AddWithValue("@PIN", consultation.PIN);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel();
                            obj.PatientId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"]);
                            obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultationId"]);
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.ConsultType2 = ds.Tables[0].Rows[i]["ConsultType"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PIN = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.Symptoms = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            obj.Telephone = ds.Tables[0].Rows[i]["Telephone"].ToString();
                            obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["ConsultationSponsors"].ToString();
                            Consultationlist.Add(obj);
                        }
                    }
                    return Consultationlist;
                }
            }
        }
    }
}
