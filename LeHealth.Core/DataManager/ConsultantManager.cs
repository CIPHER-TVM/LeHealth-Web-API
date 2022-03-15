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
                            obj.EntryDate = dtAppointments.Rows[i]["EntryDate"].ToString();
                            //obj.EntryDate = DateTime.Now;
                            //DateTime dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //DateTime dateValue = DateTime.ParseExact(appointments.AppDate.Trim(), "dd-MM-yyyy", null);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Consultant"></param>
        /// <returns></returns>
        public string InsertUpdateConsultant(ConsultantMasterModel consultant)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ConsultantId", consultant.ConsultantId);
                    cmd.Parameters.AddWithValue("@DeptId", consultant.DeptId);
                    cmd.Parameters.AddWithValue("@ConsultantCode", consultant.ConsultantCode);
                    cmd.Parameters.AddWithValue("@Title", consultant.Title);
                    cmd.Parameters.AddWithValue("@FirstName", consultant.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", consultant.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", consultant.LastName);
                    cmd.Parameters.AddWithValue("@Gender", consultant.Gender);
                    cmd.Parameters.AddWithValue("@DOB", consultant.DOB);
                    cmd.Parameters.AddWithValue("@Age", consultant.Age);
                    cmd.Parameters.AddWithValue("@Specialisation", consultant.Specialisation);
                    cmd.Parameters.AddWithValue("@Designation", consultant.Designation);
                    cmd.Parameters.AddWithValue("@Qualification", consultant.Qualification);
                    cmd.Parameters.AddWithValue("@NationalityId", consultant.NationalityId);
                    cmd.Parameters.AddWithValue("@Mobile", consultant.Mobile);
                    cmd.Parameters.AddWithValue("@ResPhone", consultant.ResPhone);
                    cmd.Parameters.AddWithValue("@OffPhone", consultant.OffPhone);
                    cmd.Parameters.AddWithValue("@Email", consultant.Email);
                    cmd.Parameters.AddWithValue("@Fax", consultant.Fax);
                    cmd.Parameters.AddWithValue("@DOJ", consultant.DOJ);
                    cmd.Parameters.AddWithValue("@CRegNo", consultant.CRegNo);
                    cmd.Parameters.AddWithValue("@AllowCommission", consultant.AllowCommission);
                    cmd.Parameters.AddWithValue("@DeptOverrule", consultant.DeptOverrule);
                    cmd.Parameters.AddWithValue("@TimeSlice", consultant.TimeSlice);
                    cmd.Parameters.AddWithValue("@AppType", consultant.AppType);
                    cmd.Parameters.AddWithValue("@MaxPatients", consultant.MaxPatients);
                    cmd.Parameters.AddWithValue("@Active", consultant.Active);
                    cmd.Parameters.AddWithValue("@RoomNo", consultant.RoomNo);
                    cmd.Parameters.AddWithValue("@UserId", consultant.UserId);
                    cmd.Parameters.AddWithValue("@DeptwiseCons", consultant.DeptWiseConsultation);
                    cmd.Parameters.AddWithValue("@Signature", consultant.Signature);
                    cmd.Parameters.AddWithValue("@External", consultant.ExternalConsultant);
                    cmd.Parameters.AddWithValue("@ConsultantLedger", consultant.ConsultantLedger);
                    cmd.Parameters.AddWithValue("@CommissionId", consultant.CommissionId);
                    cmd.Parameters.AddWithValue("@SortOrder", consultant.SortOrder);


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
                    con.Close();
                    if (descrip == "Saved Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }
                }
            }
            return response;
        }


        /// <summary>
        /// Get Consultant details using ConsultantType
        /// </summary>
        /// <param name="consultantType  =2 for all consultants"> </param>
        /// <returns>List of Consultant details</returns>
        public List<ConsultantMasterModel> GetAllConsultants(int consultantType)
        {
            List<ConsultantMasterModel> patientList = new List<ConsultantMasterModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllConsultants", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsType", consultantType);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtPatientList = new DataTable();
                    adapter.Fill(dtPatientList);
                    con.Close();
                    if ((dtPatientList != null) && (dtPatientList.Rows.Count > 0))
                        patientList = dtPatientList.ToListOfObject<ConsultantMasterModel>();

                    return patientList;
                }
            }
        }
    }
}
