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

namespace LeHealth.Core.DataManager
{
    public class HospitalsManager : IHospitalsManager
    {
        private readonly string _connStr;
        public HospitalsManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

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
        public List<DepartmentModel> GetDepartments()
        {
            DataTable dt = new DataTable();
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
                    dt = ds.Tables[0];
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
            return departmentlist;
        }
        public List<ConsultantModel> GetConsultant()
        {
            DataTable dt = new DataTable(); // no need of DataTable
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDept", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", 1); // avoid hard coding
                    cmd.Parameters.AddWithValue("@ShowExternal", false);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
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
            return consultantList; // avoid multiple return
        }
        public List<Appointments> GetAppointments()
        {
            List<Appointments> Appointmentlist = new List<Appointments>();
            List<ConsultantModel> cnsutantList = new List<ConsultantModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("[stLH_GetAppOfaDay]", con))
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", 7); // avoid hard coding
                    cmd.Parameters.AddWithValue("@AppDate", DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Appointments obj = new Appointments();
                            obj.AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["AppId"]);
                            obj.AppType = ds.Tables[0].Rows[i]["AppType"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeNo"]);
                            obj.RegNo = Convert.ToInt32(ds.Tables[0].Rows[i]["RegNo"]);
                            obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            Appointmentlist.Add(obj);
                        }
                    }
                    return Appointmentlist;
                }
                return Appointmentlist;
            }
        }
            public List<ConsultationModel> GetConsultation()
            {
                List<ConsultationModel> Appointmentlist = new List<ConsultationModel>();
                using (SqlConnection con = new SqlConnection(_connStr))
                {

                    using (SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con))
                    {
                        DataTable dt = new DataTable();
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ConsultantId", 7);
                        cmd.Parameters.AddWithValue("@ConsultDate", DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"));
                        cmd.Parameters.AddWithValue("@Status", "W");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dt = ds.Tables[0];
                        con.Close();
                        if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                ConsultationModel obj = new ConsultationModel();
                            obj.TokenNO = ds.Tables[0].Rows[i]["TokenNO"].ToString();
                            obj.Sponsor = ds.Tables[0].Rows[i]["Sponsor"].ToString();
                            obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
                            obj.TimeNo = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeNo"]);
                            obj.RegNo = Convert.ToInt32(ds.Tables[0].Rows[i]["RegNo"]);
                            //obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                            Appointmentlist.Add(obj);
                            }
                        }
                        return Appointmentlist;
                    }
                    return Appointmentlist;
                }
            }
    }
}
