﻿using LeHealth.Common;
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
        public List<VitalSignEMRHistory> GetEMRVitalSignHistory(VitalSignEMRModel ndim)
        {
            List<VitalSignEMRHistory> evsData = new List<VitalSignEMRHistory>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVitalSignEMRHistory", con);
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
                    VitalSignEMRHistory obj = new VitalSignEMRHistory
                    {
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString(),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
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
        public List<DrugModelAutoComplete> GetDrugsAutoComplete(DrugModelAutoComplete dac)
        {
            List<DrugModelAutoComplete> dacData = new List<DrugModelAutoComplete>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrugsAutoComplete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugName", dac.DrugName);
            cmd.Parameters.AddWithValue("@ConsultantId", dac.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", dac.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    DrugModelAutoComplete obj = new DrugModelAutoComplete
                    {
                        DrugId = Convert.ToInt32(ds.Rows[i]["DrugId"]),
                        DrugName = ds.Rows[i]["DrugName"].ToString(),
                        BranchId = dac.BranchId,
                        ConsultantId = dac.ConsultantId
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public DrugsEMRModel InsertDrugsEMR(DrugsEMRModel dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string drugDetailString = JsonConvert.SerializeObject(dem.DrugDetails);
                using SqlCommand cmd = new SqlCommand("stLH_InsertDrugsEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dem.Id);
                cmd.Parameters.AddWithValue("@DrugDetailJSON", drugDetailString);
                cmd.Parameters.AddWithValue("@VisitId", dem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                    dem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
        public List<DrugsEMRModel> GetDrugsEMR(DrugsEMRModel dac)
        {
            List<DrugsEMRModel> dacData = new List<DrugsEMRModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrugsEMR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", dac.VisitId);
            cmd.Parameters.AddWithValue("@ShowAll", dac.ShowAll);
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    DrugsEMRModel obj = new DrugsEMRModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString(),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        DrugDetails = JsonConvert.DeserializeObject<List<ConsultantDrugModel>>(ds.Rows[i]["DrugDetails"].ToString()),
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public PatientHistoryEMRModel InsertUpdatePatientHistoryEMR(PatientHistoryEMRModel pem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePatientHistoryEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", pem.Id);
                cmd.Parameters.AddWithValue("@PastMedicalHistory", pem.PastMedicalHistory);
                cmd.Parameters.AddWithValue("@FamilyHistory", pem.FamilyHistory);
                cmd.Parameters.AddWithValue("@SocialHistory", pem.SocialHistory);
                cmd.Parameters.AddWithValue("@CurrentMedication", pem.CurrentMedication);
                cmd.Parameters.AddWithValue("@Immunization", pem.Immunization);
                cmd.Parameters.AddWithValue("@CancerHistory", pem.CancerHistory);
                cmd.Parameters.AddWithValue("@SurgicalHistory", pem.SurgicalHistory);
                cmd.Parameters.AddWithValue("@Others", pem.Others);
                cmd.Parameters.AddWithValue("@TobaccoStatus", pem.TobaccoStatus);
                cmd.Parameters.AddWithValue("@PatientId", pem.PatientId);
                cmd.Parameters.AddWithValue("@VisitId", pem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", pem.UserId);
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
                    pem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return pem;
        }
        public PatientHistoryEMRModel GetPatientHistoryEMR(PatientHistoryEMRModel dac)
        {
            PatientHistoryEMRModel dacData = new PatientHistoryEMRModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPatientHistoryEMR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                dacData = ds.ToObject<PatientHistoryEMRModel>();
            }
            return dacData;
        }
        public PatientQuestionareModelInput InsertUpdatePatientQuestionareEMR(PatientQuestionareModelInput dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string questionareString = JsonConvert.SerializeObject(dem.PatientQuestionares);
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePatientQuestionareEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", dem.PatientQuestionares[0].PatientId);
                cmd.Parameters.AddWithValue("@QuestionareJSON", questionareString);
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
                    string response = string.Empty;
                    response = descrip;
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
        public List<PatientQuestionareModel> GetPatientQuestionareEMR(PatientQuestionareModel dac)
        {
            List<PatientQuestionareModel> dacData = new List<PatientQuestionareModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetEMRQuestionByPatient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            cmd.Parameters.AddWithValue("@BranchId", dac.BranchId);
            //cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    PatientQuestionareModel obj = new PatientQuestionareModel
                    {
                        PatientId = dac.PatientId,
                        QnId = Convert.ToInt32(ds.Rows[i]["QnId"]),
                        Question = ds.Rows[i]["Question"].ToString(),
                        AnsId = Convert.ToInt32(ds.Rows[i]["AnsId"]),
                        Notes = ds.Rows[i]["Notes"].ToString(),
                        BranchId = dac.BranchId,
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public List<PatientFoldersEMRModel> GetPatientFoldersEMR(EMRInputModel dac)
        {
            List<PatientFoldersEMRModel> dacData = new List<PatientFoldersEMRModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPatientFoldersEMR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    PatientFoldersEMRModel obj = new PatientFoldersEMRModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        FolderName = ds.Rows[i]["FolderName"].ToString(),
                        PatientFiles = JsonConvert.DeserializeObject<List<PatientFilesEMRModel>>(ds.Rows[i]["PatientFiles"].ToString()),
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public PatientFoldersEMRModel InsertUpdateFolderEMR(EMRInputModel dem)
        {
            PatientFoldersEMRModel returnData = new PatientFoldersEMRModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateFolderEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FolderId", dem.FolderId);
                cmd.Parameters.AddWithValue("@FolderName", dem.FolderName);
                cmd.Parameters.AddWithValue("@PatientId", dem.PatientId);
                cmd.Parameters.AddWithValue("@IsDeleting", dem.IsDeleting);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
                cmd.Parameters.AddWithValue("@BranchId", 3);
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
                    returnData.Id = Convert.ToInt32(ret);
                    returnData.FolderName = dem.FolderName;
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return returnData;
        }
        public EMRSaveFilesModel UploadFileEMR(EMRSaveFilesModel dem)
        {
            EMRSaveFilesModel returnData = new EMRSaveFilesModel();
            List<EMRFileDBSaveModel> eds = new List<EMRFileDBSaveModel>();
            foreach (var folderloc in dem.FolderLocation)
            {
                EMRFileDBSaveModel objv = new EMRFileDBSaveModel
                {
                    FileOriginalName = folderloc.FileOriginalName,
                    FilePath = folderloc.FilePath,
                };
                eds.Add(objv);
            }
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string fileLocationString = JsonConvert.SerializeObject(eds);
                using SqlCommand cmd = new SqlCommand("stLH_UploadFileEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileLocationJSON", fileLocationString);
                cmd.Parameters.AddWithValue("@FolderId", dem.FolderId);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                    returnData.FolderId = Convert.ToInt32(ret);
                    //returnData.FolderName = dem.FolderName;
                }
                else
                {
                    returnData.FolderId = 0;
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return returnData;
        }
        public List<ItemEMR> GetEMRServiceItem(EMRInputModel sid)
        {
            List<ItemEMR> ServiceorderItemList = new List<ItemEMR>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetEMRServiceItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupId", sid.GroupId);
            cmd.Parameters.AddWithValue("@ServiceName", sid.ServiceName);
            cmd.Parameters.AddWithValue("@ConsultantId", sid.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", sid.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsavailableService = new DataTable();
            adapter.Fill(dsavailableService);
            con.Close();
            if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                {
                    ItemEMR obj = new ItemEMR
                    {
                        ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]),
                        ItemCode = dsavailableService.Rows[i]["ItemCode"].ToString(),
                        ItemName = dsavailableService.Rows[i]["ItemName"].ToString()
                    };
                    ServiceorderItemList.Add(obj);
                }
            }
            return ServiceorderItemList;
        }
        public ItemEMRInputModel InsertServiceItemsEMR(ItemEMRInputModel dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                foreach (var data in dem.ItemDetails)
                {
                    data.Qty = data.Qty == null ? 0 : data.Qty;
                }
                string serviceItemString = JsonConvert.SerializeObject(dem.ItemDetails);
                using SqlCommand cmd = new SqlCommand("stLH_InsertServiceItemsEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dem.Id);
                cmd.Parameters.AddWithValue("@ServiceItemsJSON", serviceItemString);
                cmd.Parameters.AddWithValue("@VisitId", dem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                    dem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
        public List<ItemEMRInputModel> GetServiceItemsEMR(EMRInputModel dac)
        {
            List<ItemEMRInputModel> siData = new List<ItemEMRInputModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetServiceItemsEMR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", dac.VisitId);
            cmd.Parameters.AddWithValue("@ShowAll", dac.ShowAll);
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ItemEMRInputModel obj = new ItemEMRInputModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString(),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        ItemDetails = JsonConvert.DeserializeObject<List<ItemEMRModel>>(ds.Rows[i]["ItemDetails"].ToString()),
                    };
                    siData.Add(obj);
                }
            }
            return siData;
        }
        public DentalExaminationModel InsertDentalExamination(DentalExaminationModel dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertDentalExamination", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dem.Id);
                cmd.Parameters.AddWithValue("@ExtraOral", dem.ExtraOral);
                cmd.Parameters.AddWithValue("@SoftTissue", dem.SoftTissue);
                cmd.Parameters.AddWithValue("@HardTissue", dem.HardTissue);
                cmd.Parameters.AddWithValue("@Others", dem.Others);
                cmd.Parameters.AddWithValue("@VisitId", dem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                    dem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
        public List<DentalExaminationModel> GetDentalExaminationEMR(EMRInputModel dac)
        {
            List<DentalExaminationModel> siData = new List<DentalExaminationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDentalExamination", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", dac.VisitId);
            cmd.Parameters.AddWithValue("@ShowAll", dac.ShowAll);
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    DentalExaminationModel obj = new DentalExaminationModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
                        ExtraOral = ds.Rows[i]["ExtraOral"].ToString(),
                        SoftTissue = ds.Rows[i]["SoftTissue"].ToString(),
                        HardTissue = ds.Rows[i]["HardTissue"].ToString(),
                        Others = ds.Rows[i]["Others"].ToString(),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString()
                    };
                    siData.Add(obj);
                }
            }
            return siData;
        }
        ////
        public DentalProcedureEMRModel InsertDentalProcedureEMR(DentalProcedureEMRModel dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                List<DentalProcedureEMR> ProcedureDetailsList = new List<DentalProcedureEMR>();
                for (int i = 0; i < dem.ProcedureDetails.Count; i++)
                {
                    if (dem.ProcedureDetails[i].IsCompleted == 0)
                    {
                        DentalProcedureEMR obj = new DentalProcedureEMR
                        {
                            ItemId = Convert.ToInt32(dem.ProcedureDetails[i].ItemId),
                            Teeths = dem.ProcedureDetails[i].Teeths,
                            Qty = Convert.ToInt32(dem.ProcedureDetails[i].Qty),
                            Notes = dem.ProcedureDetails[i].Notes.ToString(),
                            ApprovalStatus = Convert.ToInt32(dem.ProcedureDetails[i].ApprovalStatus),
                            ApprovalNumber = dem.ProcedureDetails[i].ApprovalNumber.ToString(),
                            BillingMode = Convert.ToInt32(dem.ProcedureDetails[i].BillingMode),
                        };
                        ProcedureDetailsList.Add(obj);
                    }
                }
                string procedureDetailString = JsonConvert.SerializeObject(ProcedureDetailsList);
                using SqlCommand cmd = new SqlCommand("stLH_InsertDentalProcedureEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dem.Id);
                cmd.Parameters.AddWithValue("@PlanDescription", dem.PlanDescription);
                cmd.Parameters.AddWithValue("@ProcedureDetailJSON", procedureDetailString);
                cmd.Parameters.AddWithValue("@VisitId", dem.VisitId);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                    dem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
        public List<DentalProcedureEMRModel> GetDentalProcedureEMR(EMRInputModel dac)
        {
            List<DentalProcedureEMRModel> dacData = new List<DentalProcedureEMRModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDentalProcedureEMR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitId", dac.VisitId);
            cmd.Parameters.AddWithValue("@ShowAll", dac.ShowAll);
            cmd.Parameters.AddWithValue("@PatientId", dac.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    DentalProcedureEMRModel obj = new DentalProcedureEMRModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        PlanDescription = ds.Rows[i]["PlanDescription"].ToString(),
                        VisitId = Convert.ToInt32(ds.Rows[i]["VisitId"]),
                        VisitDate = ds.Rows[i]["VisitDate"].ToString(),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        ProcedureDetails = JsonConvert.DeserializeObject<List<DentalProcedureEMR>>(ds.Rows[i]["ProcedureDetails"].ToString()),
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public DentalProcedureEMR CompleteDentalProcedureEMR(DentalProcedureEMR dem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CompleteDentalProcedureEMR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dem.Id);
                cmd.Parameters.AddWithValue("@ItemId", dem.ItemId);
                cmd.Parameters.AddWithValue("@Teeths", dem.Teeths);
                cmd.Parameters.AddWithValue("@Qty", dem.Qty);
                cmd.Parameters.AddWithValue("@Notes", dem.Notes);
                cmd.Parameters.AddWithValue("@ApprovalStatus", dem.ApprovalStatus);
                cmd.Parameters.AddWithValue("@ApprovalNumber", dem.ApprovalNumber);
                cmd.Parameters.AddWithValue("@BillingMode", dem.BillingMode);
                cmd.Parameters.AddWithValue("@UserId", dem.UserId);
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
                if (descrip == "Completed Successfully")
                {
                    dem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return dem;
        }
    }
}
