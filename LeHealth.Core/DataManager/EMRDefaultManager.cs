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
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultationByPatientConsultant", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
            cmd.Parameters.AddWithValue("@PatientId", consultation.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                consultationlist = ds.ToListOfObject<ConsultationEMRModel>();
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
                if (patientData[0].ProfilePicLocation != "")
                    patientData[0].ProfilePicLocation = _uploadpath + patientData[0].ProfilePicLocation;
            }
            return patientData;
        }

        public VisitModel InsertVisit(VisitModel visit)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertVisit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitId", visit.VisitId);
                cmd.Parameters.AddWithValue("@ConsultantId", visit.ConsultantId);
                cmd.Parameters.AddWithValue("@ConsultationId", visit.ConsultationId);
                cmd.Parameters.AddWithValue("@PatientId", visit.PatientId);
                cmd.Parameters.AddWithValue("@VisitType", visit.VisitType);
                cmd.Parameters.AddWithValue("@UserId", visit.UserId);
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

                SqlParameter retStart = new SqlParameter("@VisitStart", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(retStart);

                SqlParameter retEnd = new SqlParameter("@VisitEnd", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(retEnd);

                con.Open();
                var isUpdated = cmd.ExecuteNonQuery();
                var ret = retValV.Value;
                var descrip = retDesc.Value.ToString();
                var vs = retStart.Value.ToString();
                var ve = retEnd.Value.ToString();
                con.Close();
                if (descrip == "Saved Successfully")
                {
                    visit.VisitId = Convert.ToInt32(ret);
                    visit.VisitStartTime = vs;
                    visit.VisitEndTime = ve;
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return visit;
        }

        public List<VisitModel> GetVisitDetails(VisitModel visit)
        {
            List<VisitModel> visitData = new List<VisitModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVisitDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", visit.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                visitData = ds.ToListOfObject<VisitModel>();

            }
            return visitData;
        }

        public ComplaintsModel InsertComplaints(ComplaintsModel complaints)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertComplaints", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ComplaintId", complaints.ComplaintId);
                cmd.Parameters.AddWithValue("@ChiefComplaint", complaints.ChiefComplaint);
                cmd.Parameters.AddWithValue("@ComplaintOf", complaints.ComplaintOf);
                cmd.Parameters.AddWithValue("@Site", complaints.Site);
                cmd.Parameters.AddWithValue("@SymptomSince", complaints.SymptomSince);
                cmd.Parameters.AddWithValue("@Severity", complaints.Severity);
                cmd.Parameters.AddWithValue("@Course", complaints.Course);
                cmd.Parameters.AddWithValue("@Symptom", complaints.Symptom);
                cmd.Parameters.AddWithValue("@TobaccoStatus", complaints.TobaccoStatus);
                cmd.Parameters.AddWithValue("@AssociatedSigns", complaints.AssociatedSigns);
                cmd.Parameters.AddWithValue("@ChiefComplaintsBy", complaints.ChiefComplaintsBy);
                cmd.Parameters.AddWithValue("@PainScale", complaints.PainScale);
                cmd.Parameters.AddWithValue("@VisitId", complaints.VisitId);
                cmd.Parameters.AddWithValue("@UserId", complaints.UserId);
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
                    complaints.ComplaintId = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return complaints;
        }
        public List<ComplaintsModel> GetChiefComplaints(ComplaintsModel visit)
        {
            List<ComplaintsModel> visitData = new List<ComplaintsModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetChiefComplaints", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", visit.VisitId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                visitData = ds.ToListOfObject<ComplaintsModel>();

            }
            return visitData;
        }


        public PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pe)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertPhysicalExamination", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PEId", pe.PEId);
                cmd.Parameters.AddWithValue("@Constitution", pe.Constitution);
                cmd.Parameters.AddWithValue("@Gastrointestinial", pe.Gastrointestinial);
                cmd.Parameters.AddWithValue("@Genitourinary", pe.Genitourinary);
                cmd.Parameters.AddWithValue("@Eyes", pe.Eyes);
                cmd.Parameters.AddWithValue("@ENT", pe.ENT);
                cmd.Parameters.AddWithValue("@Neck", pe.Neck);
                cmd.Parameters.AddWithValue("@Skin", pe.Skin);
                cmd.Parameters.AddWithValue("@Breast", pe.Breast);
                cmd.Parameters.AddWithValue("@Respiratory", pe.Respiratory);
                cmd.Parameters.AddWithValue("@Muscleoskle", pe.Muscleoskle);
                cmd.Parameters.AddWithValue("@Psychiarty", pe.Psychiarty);
                cmd.Parameters.AddWithValue("@Cardiovascular", pe.Cardiovascular);
                cmd.Parameters.AddWithValue("@Neurological", pe.Neurological);
                cmd.Parameters.AddWithValue("@Hemotology", pe.Hemotology);
                cmd.Parameters.AddWithValue("@Thyroid", pe.Thyroid);
                cmd.Parameters.AddWithValue("@Abdomen", pe.Abdomen);
                cmd.Parameters.AddWithValue("@Pelvis", pe.Pelvis);
                cmd.Parameters.AddWithValue("@Others", pe.Others);
                cmd.Parameters.AddWithValue("@VisitId", pe.VisitId);
                cmd.Parameters.AddWithValue("@UserId", pe.UserId);
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
                    pe.PEId = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return pe;
        }
        public List<PhysicalExaminationModel> GetPEDetails(PhysicalExaminationModel visit)
        {
            List<PhysicalExaminationModel> visitData = new List<PhysicalExaminationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPEDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", visit.VisitId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                visitData = ds.ToListOfObject<PhysicalExaminationModel>();

            }
            return visitData;
        }

        public SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertReviewOfSymptoms", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRMId", srm.SRMId);
                cmd.Parameters.AddWithValue("@Constitutional", srm.Constitutional);
                cmd.Parameters.AddWithValue("@Respiratory", srm.Respiratory);
                cmd.Parameters.AddWithValue("@Phychiatry", srm.Phychiatry);
                cmd.Parameters.AddWithValue("@Gastrointestinial", srm.Gastrointestinial);
                cmd.Parameters.AddWithValue("@Hemotology", srm.Hemotology);
                cmd.Parameters.AddWithValue("@Neurological", srm.Neurological);
                cmd.Parameters.AddWithValue("@Skin", srm.Skin);
                cmd.Parameters.AddWithValue("@Cardiovascular", srm.Cardiovascular);
                cmd.Parameters.AddWithValue("@Endocrinal", srm.Endocrinal);
                cmd.Parameters.AddWithValue("@Genitourinary", srm.Genitourinary);
                cmd.Parameters.AddWithValue("@ENT", srm.ENT);
                cmd.Parameters.AddWithValue("@Immunological", srm.Immunological);
                cmd.Parameters.AddWithValue("@VisitId", srm.VisitId);
                cmd.Parameters.AddWithValue("@UserId", srm.UserId);
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
                    srm.SRMId = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return srm;
        }
        public List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel visit)
        {
            List<SymptomReviewModel> visitData = new List<SymptomReviewModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetReviewOfSymptoms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", visit.VisitId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                visitData = ds.ToListOfObject<SymptomReviewModel>();
            }
            return visitData;
        }

    }
}
