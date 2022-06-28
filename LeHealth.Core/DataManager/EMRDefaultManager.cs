using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
            cmd.Parameters.AddWithValue("@PatientId", visit.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", visit.ShowAll);
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
            List<PhysicalExaminationModel> peData = new List<PhysicalExaminationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPEDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", visit.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", visit.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", visit.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                peData = ds.ToListOfObject<PhysicalExaminationModel>();
            }
            return peData;
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
                cmd.Parameters.AddWithValue("@ENT", srm.Ent);
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
        public List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel srm)
        {
            List<SymptomReviewModel> rosData = new List<SymptomReviewModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetReviewOfSymptoms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", srm.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", srm.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", srm.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                rosData = ds.ToListOfObject<SymptomReviewModel>();
            }
            return rosData;
        }

        //
        public MedicalDecisionModel InsertMedicalDecision(MedicalDecisionModel srm)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertMedicalDecision", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MDId", srm.MDId);
                cmd.Parameters.AddWithValue("@LabOrder", srm.LabOrder);
                cmd.Parameters.AddWithValue("@RadiologyOrder", srm.RadiologyOrder);
                cmd.Parameters.AddWithValue("@TreatmentOrder", srm.TreatmentOrder);
                cmd.Parameters.AddWithValue("@OldMedicalRecord", srm.OldMedicalRecord);
                cmd.Parameters.AddWithValue("@ReferToPhysician", srm.ReferToPhysician);
                cmd.Parameters.AddWithValue("@DifferencialDiagnosis", srm.DifferencialDiagnosis);
                cmd.Parameters.AddWithValue("@Eligibility", srm.Eligibility);
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
                    srm.MDId = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return srm;
        }
        public List<MedicalDecisionModel> GetMedicalDecision(MedicalDecisionModel srm)
        {
            List<MedicalDecisionModel> rosData = new List<MedicalDecisionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMedicalDecision", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", srm.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", srm.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", srm.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                rosData = ds.ToListOfObject<MedicalDecisionModel>();
            }
            return rosData;
        }

        public PlanAndProcedureModel InsertPlanAndProcedure(PlanAndProcedureModel srm)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertPlanAndProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PapId", srm.PapId);
                cmd.Parameters.AddWithValue("@PlanAndProcedure", srm.PlanAndProcedure);
                cmd.Parameters.AddWithValue("@PatientInstruction", srm.PatientInstruction);
                cmd.Parameters.AddWithValue("@FollowUp", srm.FollowUp);
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
                    srm.PapId = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return srm;
        }
        public List<PlanAndProcedureModel> GetPlanAndProcedure(PlanAndProcedureModel srm)
        {
            List<PlanAndProcedureModel> rosData = new List<PlanAndProcedureModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPlanAndProcedure", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", srm.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", srm.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", srm.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                rosData = ds.ToListOfObject<PlanAndProcedureModel>();
            }
            return rosData;
        }
        public MenstrualHistoryModel InsertMenstrualHistory(MenstrualHistoryModel srm)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertMenstrualHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mid", srm.Mid);
                cmd.Parameters.AddWithValue("@Menarche", srm.Menarche);
                cmd.Parameters.AddWithValue("@Cycle", srm.Cycle);
                cmd.Parameters.AddWithValue("@Lmp", srm.Lmp);
                cmd.Parameters.AddWithValue("@Flow", srm.Flow);
                cmd.Parameters.AddWithValue("@Contraception", srm.Contraception);
                cmd.Parameters.AddWithValue("@PapSmear", srm.PapSmear);
                cmd.Parameters.AddWithValue("@Memogram", srm.Memogram);
                cmd.Parameters.AddWithValue("@ObstertrichHistory", srm.ObstertrichHistory);
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
                    srm.Mid = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return srm;
        }
        public List<MenstrualHistoryModel> GetMenstrualHistory(MenstrualHistoryModel srm)
        {
            List<MenstrualHistoryModel> menstrualData = new List<MenstrualHistoryModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMenstrualHistory", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", srm.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", srm.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", srm.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                menstrualData = ds.ToListOfObject<MenstrualHistoryModel>();
            }
            return menstrualData;
        }
        public NarrativeDiagnosisICDModel InsertNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string icdlabelString = JsonConvert.SerializeObject(ndim.IcdLabelList);
                using SqlCommand cmd = new SqlCommand("stLH_InsertNarrativeDiagnosisICD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nid", ndim.Nid);
                cmd.Parameters.AddWithValue("@NarrativeDiagnosis", ndim.NarrativeDiagnosis);
                cmd.Parameters.AddWithValue("@IcdLabelJSON", icdlabelString);
                cmd.Parameters.AddWithValue("@VisitId", ndim.VisitId);
                cmd.Parameters.AddWithValue("@UserId", ndim.UserId);
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
                    ndim.Nid = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return ndim;
        }
        public List<NarrativeDiagnosisICDModel> GetNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            List<NarrativeDiagnosisICDModel> ndimData = new List<NarrativeDiagnosisICDModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetNarrativeDiagnosisICD", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", ndim.VisitId);
            cmd.Parameters.AddWithValue("@PatientId", ndim.PatientId);
            cmd.Parameters.AddWithValue("@ShowAll", ndim.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    NarrativeDiagnosisICDModel obj = new NarrativeDiagnosisICDModel
                    {
                        Nid = Convert.ToInt32(ds.Rows[i]["Nid"]),
                        NarrativeDiagnosis = ds.Rows[i]["NarrativeDiagnosis"].ToString(),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString(),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        IcdLabelList = JsonConvert.DeserializeObject<List<ICDModel>>(ds.Rows[i]["ICDLabelList"].ToString()),
                    };
                    ndimData.Add(obj);
                }
            }
            return ndimData;
        }
        //
        public VitalSignEMRModel InsertEMRVitalSign(VitalSignEMRModel vsem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                List<VitalSignEMRData> vsed = new List<VitalSignEMRData>();
                foreach (var vitalsign in vsem.VitalSignDataList)
                {
                    if (vitalsign.VitalSignValue != "")
                    {
                        vsed.Add(vitalsign);
                    }
                }
                string vitalsignString = JsonConvert.SerializeObject(vsed);
                using SqlCommand cmd = new SqlCommand("stLH_InsertVitalSignEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Eid", vsem.Eid);
                cmd.Parameters.AddWithValue("@VitalSignJSON", vitalsignString);
                cmd.Parameters.AddWithValue("@VisitId", vsem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", vsem.UserId);
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
                    vsem.Eid = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return vsem;
        }
        public List<VitalSignEMRData> GetEMRVitalSign(VitalSignEMRModel ndim)
        {
            List<VitalSignEMRData> evsData = new List<VitalSignEMRData>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetEMRVitalSign", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", ndim.VisitId);
            cmd.Parameters.AddWithValue("@BranchId", ndim.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    VitalSignEMRData obj = new VitalSignEMRData
                    {
                        VitalSignId = Convert.ToInt32(ds.Rows[i]["VitalSignId"]),
                        VitalSignName = ds.Rows[i]["VitalSignName"].ToString(),
                        VitalSignValue = ds.Rows[i]["VitalSignValue"].ToString(),
                        Eid = Convert.ToInt32(ds.Rows[i]["Eid"])
                    };
                    evsData.Add(obj);
                }
            }
            return evsData;
        }
        public List<VitalSignEMRAll> GetAllEMRVitalSignByVisitId(VitalSignEMRModel ndim)
        {
            List<VitalSignEMRAll> evsData = new List<VitalSignEMRAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAllEMRVitalSignByVisitId", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", ndim.VisitId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    VitalSignEMRAll obj = new VitalSignEMRAll
                    {
                        Eid = Convert.ToInt32(ds.Rows[i]["Id"]),
                        CreatedDate = ds.Rows[i]["CreatedDate"].ToString(),
                        VitalSignData = JsonConvert.DeserializeObject<List<VitalSignEMRData>>(ds.Rows[i]["VitalSignData"].ToString()),
                    };
                    evsData.Add(obj);
                }
            }
            return evsData;
        }
        //public List<DrugModelAutoComplete> GetAllEMRVitalSignByVisitId(DrugModelAutoComplete ndim)
        //{
        //    List<VitalSignEMRAll> evsData = new List<VitalSignEMRAll>();
        //    using SqlConnection con = new SqlConnection(_connStr);
        //    using SqlCommand cmd = new SqlCommand("stLH_GetAllEMRVitalSignByVisitId", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@VisitId", ndim.VisitId);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable ds = new DataTable();
        //    adapter.Fill(ds);
        //    con.Close();
        //    if ((ds != null) && (ds.Rows.Count > 0))
        //    {
        //        for (Int32 i = 0; i < ds.Rows.Count; i++)
        //        {
        //            VitalSignEMRAll obj = new VitalSignEMRAll
        //            {
        //                Id = Convert.ToInt32(ds.Rows[i]["Id"]),
        //                CreatedDate = ds.Rows[i]["CreatedDate"].ToString(),
        //                VitalSignData = JsonConvert.DeserializeObject<List<VitalSignEMRData>>(ds.Rows[i]["VitalSignData"].ToString()),
        //            };
        //            evsData.Add(obj);
        //        }
        //    }
        //    return evsData;
        //}

    }
}
