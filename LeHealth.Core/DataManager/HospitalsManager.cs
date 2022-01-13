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
                            obj.ConsultationId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultationId"]);
                            obj.TokenNO = ds.Tables[0].Rows[i]["TokenNO"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["Sponsor"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = (ds.Tables[0].Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["TimeNo"]);
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();// == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["RegNo"]);//int.Parse(ds.Tables[0].Rows[i]["RegNo"].ToString());
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["Sponsor"].ToString();
                            obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString();
                            appointmentlist.Add(obj);
                        }
                    }
                    return appointmentlist;
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
        public string InsertAppointment(Appointments appointments)
        {
            string response = string.Empty;;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertAppointment", con))
                {
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
                    IFormatProvider culture = new CultureInfo("en-US", true);
                    DateTime dateVal = DateTime.ParseExact(DateString, "yyyy-MM-dd", culture);
                    cmd.Parameters.AddWithValue("@AppId", appointments.AppId);
                    cmd.Parameters.AddWithValue("@ConsultantId", appointments.ConsultantId);
                    cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AppDate", dateVal);
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
                    cmd.Parameters.AddWithValue("@AppTypeId", appointments.AppType);
                    cmd.Parameters.AddWithValue("@SessionId", appointments.SessionId);
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
        /// Update appoinments to database,Step three in code execution flow
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>
        public string UpdateAppointment(Appointments appointments)
        {
            string appointmentret = string.Empty;;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_UpdateAppointment", con))
                {
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
                        appointmentret = ret.ToString();
                    }
                    else
                    {
                        appointmentret = descrip;
                    }
                }
            }
            return appointmentret;
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
                            obj.ConsultDate = ds.Tables[0].Rows[i]["ConsultDate"].ToString().Substring(0, 10);
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.ConsultantId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultantId"]);
                            obj.Consultant = ds.Tables[0].Rows[i]["Consultant"].ToString();
                            obj.ConsultType2 = ds.Tables[0].Rows[i]["ConsultType"].ToString();
                            obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
                            obj.PIN = ds.Tables[0].Rows[i]["PIN"].ToString();
                            obj.OtherReasonForVisit = ds.Tables[0].Rows[i]["Symptoms"].ToString();
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
                    DateTime oldFrom = DateTime.Parse(consultation.FromDate.Trim());
                    consultation.FromDate = oldFrom.ToString("yyyy-MM-dd");
                    DateTime oldTo = DateTime.Parse(consultation.ToDate.Trim());
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
                            obj.OtherReasonForVisit = ds.Tables[0].Rows[i]["Symptoms"].ToString();
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            obj.CancelReason = ds.Tables[0].Rows[i]["CancelReason"].ToString();
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
