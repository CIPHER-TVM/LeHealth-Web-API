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
using Newtonsoft.Json;

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
        /// Get consultantion's list from database, Step three in code execution flow
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
        {
            List<ConsultationModel> appointmentlist = new List<ConsultationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Status", consultation.Status);
            cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
            cmd.Parameters.AddWithValue("@DepartmentId", consultation.DeptId);
            cmd.Parameters.AddWithValue("@ConsultDate", consultation.ConsultantDate);
            cmd.Parameters.AddWithValue("@BranchId", consultation.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultationModel obj = new ConsultationModel();
                    obj.ConsultationId = Convert.ToInt32(ds.Rows[i]["ConsultationId"]);
                    obj.TokenNO = ds.Rows[i]["TokenNO"].ToString();
                    obj.DeptId = Convert.ToInt32(ds.Rows[i]["DeptId"]);
                    obj.PatientName = ds.Rows[i]["PatientName"].ToString();
                    obj.TimeNo = (ds.Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Rows[i]["TimeNo"]);
                    obj.RegNo = ds.Rows[i]["RegNo"].ToString();
                    obj.Status = ds.Rows[i]["Status"].ToString();
                    obj.Gender = ds.Rows[i]["Gender"].ToString();
                    obj.Sponsor = ds.Rows[i]["Sponsor"].ToString();
                    obj.Emergency = Convert.ToInt32(ds.Rows[i]["Emergency"]);
                    obj.Address = ds.Rows[i]["Address"].ToString();
                    obj.ConsultDate = ds.Rows[i]["ConsultDate"].ToString();
                    obj.Email = ds.Rows[i]["Email"].ToString();
                    obj.Mobile = ds.Rows[i]["Mobile"].ToString();
                    appointmentlist.Add(obj);
                }
            }
            return appointmentlist;
        }


        public List<TabOrderModel> GetTabOrder(string screenname)
        {
            List<TabOrderModel> Consultationlist = new List<TabOrderModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTabOrder", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ScreenName", screenname);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    TabOrderModel obj = new TabOrderModel();
                    obj.ScreenName = ds.Rows[i]["ScreenName"].ToString();
                    obj.ObjectName = ds.Rows[i]["ObjectName"].ToString();
                    obj.ObjectOrder = Convert.ToInt32(ds.Rows[i]["ObjectOrder"]);
                    Consultationlist.Add(obj);
                }
            }
            return Consultationlist;
        }




        /// <summary>
        /// Save appoinments to database,Step three in code execution flow
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>
        public string InsertAppointment(Appointments appointments)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (appointments == null || appointments.PatientId <= 0)
                {
                    cmd.Parameters.AddWithValue("@PatientId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PatientId", appointments.PatientId);
                }
                string DateString = appointments.AppDate;
                DateTime dateValue = DateTime.ParseExact(appointments.AppDate.Trim(), "dd-MM-yyyy", null);
                appointments.AppDate = dateValue.ToString("yyyy-MM-dd");
                string sliceString = JsonConvert.SerializeObject(appointments.SliceData);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AppId", appointments.AppId);
                cmd.Parameters.AddWithValue("@ConsultantId", appointments.ConsultantId);
                cmd.Parameters.AddWithValue("@PatientId", appointments.PatientId);
                cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@AppDate", appointments.AppDate);
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
                cmd.Parameters.AddWithValue("@AppTypeId", appointments.AppType);
                cmd.Parameters.AddWithValue("@SessionId", appointments.SessionId);
                cmd.Parameters.AddWithValue("@BranchId", appointments.BranchId);
                cmd.Parameters.AddWithValue("@SliceDataJson", sliceString);
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
                var isSaved = cmd.ExecuteNonQuery();
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                if (descrip == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = descrip;
                }
                con.Close();
            }
            return response;
        }

        /// <summary>
        /// Update appoinments to database,Step three in code execution flow
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>
        public string UpdateAppointment(Appointments appointments)
        {
            string appointmentret = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using SqlCommand cmd = new SqlCommand("stLH_UpdateAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppId", appointments.AppId);
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
                cmd.Parameters.AddWithValue("@UserId", appointments.UserId);
                DateTime dateValue = DateTime.ParseExact(appointments.AppDate.Trim(), "dd-MM-yyyy", null);
                appointments.AppDate = dateValue.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@AppDate", appointments.AppDate);
                string sliceString = JsonConvert.SerializeObject(appointments.SliceData);
                cmd.Parameters.AddWithValue("@SliceDataJson", sliceString);
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
                var descrip = retDesc.Value.ToString();

                if (descrip == "Saved Successfully")
                {
                    appointmentret = ret.ToString();
                }
                else
                {
                    appointmentret = descrip;
                }
                con.Close();
            }
            return appointmentret;
        }
        /// <summary>
        /// Get list of all consultations
        /// </summary>
        /// <returns></returns>
        public List<ConsultationModel> GetAllConsultation()
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAllConsultation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultationId", 0);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultationModel obj = new ConsultationModel();
                    obj.PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]);
                    obj.ConsultationId = Convert.ToInt32(ds.Rows[i]["ConsultationId"]);
                    obj.ConsultDate = ds.Rows[i]["ConsultDate"].ToString().Substring(0, 10);
                    obj.PatientName = ds.Rows[i]["PatientName"].ToString();
                    obj.ConsultantId = Convert.ToInt32(ds.Rows[i]["ConsultantId"]);
                    obj.Consultant = ds.Rows[i]["Consultant"].ToString();
                    obj.ConsultType2 = ds.Rows[i]["ConsultType"].ToString();
                    obj.RegNo = ds.Rows[i]["RegNo"].ToString();
                    obj.PIN = ds.Rows[i]["PIN"].ToString();
                    obj.OtherReasonForVisit = ds.Rows[i]["Symptoms"].ToString();
                    obj.Status = ds.Rows[i]["Status"].ToString();
                    obj.Mobile = ds.Rows[i]["Mobile"].ToString();
                    obj.Address = ds.Rows[i]["Address"].ToString();
                    obj.Sponsor = ds.Rows[i]["ConsultationSponsors"].ToString();
                    Consultationlist.Add(obj);
                }
            }
            return Consultationlist;
        }
        /// <summary>
        /// Search data in consultation table
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        public List<ConsultationModel> SearchConsultation(ConsultationModel consultation)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchConsultation", con);
            DateTime oldFrom = DateTime.ParseExact(consultation.FromDate.Trim(), "dd-MM-yyyy", null);
            consultation.FromDate = oldFrom.ToString("yyyy-MM-dd");

            DateTime oldTo = DateTime.ParseExact(consultation.ToDate.Trim(), "dd-MM-yyyy", null);
            consultation.ToDate = oldTo.ToString("yyyy-MM-dd");
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", consultation.PatientName);
            cmd.Parameters.AddWithValue("@RegNo", consultation.RegNo);
            cmd.Parameters.AddWithValue("@Mobile", consultation.Mobile);
            cmd.Parameters.AddWithValue("@FromDate", consultation.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", consultation.ToDate);
            cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
            cmd.Parameters.AddWithValue("@Phone", "");
            cmd.Parameters.AddWithValue("@Address", consultation.Address);
            cmd.Parameters.AddWithValue("@PIN", consultation.PIN);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultationModel obj = new ConsultationModel();
                    obj.PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]);
                    obj.ConsultationId = Convert.ToInt32(ds.Rows[i]["ConsultationId"]);
                    obj.ConsultDate = ds.Rows[i]["ConsultDate"].ToString();
                    obj.PatientName = ds.Rows[i]["PatientName"].ToString();
                    obj.Consultant = ds.Rows[i]["Consultant"].ToString();
                    obj.ConsultType2 = ds.Rows[i]["ConsultType"].ToString();
                    obj.RegNo = ds.Rows[i]["RegNo"].ToString();
                    obj.PIN = ds.Rows[i]["PIN"].ToString();
                    obj.OtherReasonForVisit = ds.Rows[i]["Symptoms"].ToString();
                    obj.Status = ds.Rows[i]["Status"].ToString();
                    obj.CancelReason = ds.Rows[i]["CancelReason"].ToString();
                    obj.Mobile = ds.Rows[i]["Mobile"].ToString();
                    obj.Telephone = ds.Rows[i]["Telephone"].ToString();
                    obj.Address = ds.Rows[i]["Address"].ToString();
                    obj.Sponsor = ds.Rows[i]["ConsultationSponsors"].ToString();
                    Consultationlist.Add(obj);
                }
            }
            return Consultationlist;
        }
    }
}
