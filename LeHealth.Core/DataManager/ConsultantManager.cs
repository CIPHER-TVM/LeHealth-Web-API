using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace LeHealth.Core.DataManager
{
    public class ConsultantManager:IConsultantManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public ConsultantManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        /// <summary>
        /// Search data in consultation table using ConsultantId
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns>List of consultation details</returns>
        public List<ConsultationModel> SearchConsultationById(int consultantId)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultationById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", consultantId);
                  
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


        /// <summary>
        /// Get appointment details using ConsultantId
        /// </summary>
        /// <param name="consultantId"> </param>
        /// <returns>List of appointment details</returns>
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(int consultantId)
        {
            List<SearchAppointmentModel> appList = new List<SearchAppointmentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchAppointmentByConsultantId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (consultantId == 0 || consultantId == null)
                        cmd.Parameters.AddWithValue("@ConsultantId", 0);
                    else
                        cmd.Parameters.AddWithValue("@ConsultantId", consultantId);

                 
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtAppointments = new DataTable();
                    adapter.Fill(dtAppointments);
                    con.Close();
                    if ((dtAppointments != null) && (dtAppointments.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dtAppointments.Rows.Count; i++)
                        {
                            SearchAppointmentModel obj = new SearchAppointmentModel();
                            obj.AppId = Convert.ToInt32(dtAppointments.Rows[i]["AppId"]);
                            obj.AppDate = dtAppointments.Rows[i]["AppDate"].ToString();
                            obj.AppType = (dtAppointments.Rows[0]["AppType"] == DBNull.Value) ? 0 : Convert.ToInt32(dtAppointments.Rows[0]["AppType"]);
                            obj.AppNo = dtAppointments.Rows[i]["AppNo"].ToString();
                            obj.RegNo = dtAppointments.Rows[i]["RegNo"].ToString();
                            obj.SliceTime = dtAppointments.Rows[i]["SliceTime"].ToString();
                            obj.PatientId = (dtAppointments.Rows[0]["PatientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dtAppointments.Rows[0]["PatientId"]);
                            obj.PatientName = dtAppointments.Rows[i]["PatientName"].ToString();
                            obj.PIN = dtAppointments.Rows[i]["PIN"].ToString();
                            obj.Mobile = dtAppointments.Rows[i]["ContactNumber"].ToString();
                            obj.CFirstName = dtAppointments.Rows[i]["ConsultantName"].ToString();
                            obj.AppStatus = dtAppointments.Rows[i]["Status"].ToString();
                            obj.CancelReason = dtAppointments.Rows[i]["CancelReason"].ToString();
                            obj.ResPhone = dtAppointments.Rows[i]["TelePhone"].ToString();
                            obj.Address1 = dtAppointments.Rows[i]["Address"].ToString();
                            obj.BranchId = Convert.ToInt32(dtAppointments.Rows[i]["BranchId"]);
                            appList.Add(obj);
                        }
                    }
                    return appList;
                }
            }
        }

        /// <summary>
        /// Get Patient details using ConsultantId
        /// </summary>
        /// <param name="consultantId"> </param>
        /// <returns>List of Patient details</returns>
        public List<PatientListModel> SearchPatientByConsultantId(int consultantId)
        {
            List<PatientListModel> patientList = new List<PatientListModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatientsByConsultantId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", consultantId);
                   
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtPatientList = new DataTable();
                    adapter.Fill(dtPatientList);
                    con.Close();
                    if ((dtPatientList != null) && (dtPatientList.Rows.Count > 0))
                        patientList = dtPatientList.ToListOfObject<PatientListModel>();

                    return patientList;
                }
            }
        }
    }
}
