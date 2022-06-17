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
    public class EMRDefaultManager : IEMRDefaultManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public EMRDefaultManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        public List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll consultation)
        {
            List<ConsultationEMRModel> consultationlist = new List<ConsultationEMRModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Status", consultation.Status);
            //cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
            //cmd.Parameters.AddWithValue("@DepartmentId", consultation.DeptId);
            //cmd.Parameters.AddWithValue("@ConsultDate", consultation.ConsultantDate);
            //cmd.Parameters.AddWithValue("@BranchId", consultation.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultationEMRModel obj = new ConsultationEMRModel
                    {
                        //ConsultationId = Convert.ToInt32(ds.Rows[i]["ConsultationId"]),
                        //TokenNO = ds.Rows[i]["TokenNO"].ToString(),
                        //DeptId = Convert.ToInt32(ds.Rows[i]["DeptId"]),
                        //PatientName = ds.Rows[i]["PatientName"].ToString(),
                        //TimeNo = (ds.Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Rows[i]["TimeNo"]),
                        //RegNo = ds.Rows[i]["RegNo"].ToString(),
                        //Status = ds.Rows[i]["Status"].ToString(),
                        //Gender = ds.Rows[i]["Gender"].ToString(),
                        //Sponsor = ds.Rows[i]["Sponsor"].ToString(),
                        //Emergency = Convert.ToInt32(ds.Rows[i]["Emergency"]),
                        //Address = ds.Rows[i]["Address"].ToString(),
                        //ConsultDate = ds.Rows[i]["ConsultDate"].ToString(),
                        //Email = ds.Rows[i]["Email"].ToString(),
                        //Mobile = ds.Rows[i]["Mobile"].ToString()
                    };
                    consultationlist.Add(obj);
                }
            }
            return consultationlist;
        }
        public List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel consultation)
        {
            List<PatientBasicModel> patientData = new List<PatientBasicModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetBasicPatientDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", consultation.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                patientData = ds.ToListOfObject<PatientBasicModel>();
                if(patientData[0].ProfilePicLocation!="")
                patientData[0].ProfilePicLocation = _uploadpath + patientData[0].ProfilePicLocation;
            }
            return patientData;
        }


    }
}
