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
   public class TreatmentManager : ITreatmentManager
    {
        private readonly string _connStr; 
        private readonly string _uploadpath;
        public TreatmentManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public PhysioAnalysisHistoryModel InsertUpdatePhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel pem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string gmqaString = JsonConvert.SerializeObject(pem.GmQuestionList);
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePhysioAnalysisHistoryTreatment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", pem.Id);
                cmd.Parameters.AddWithValue("@OccupationalHistory", pem.OccupationalHistory);
                cmd.Parameters.AddWithValue("@HazardExposureHistory", pem.HazardExposureHistory);
                cmd.Parameters.AddWithValue("@FamilyMedicalHistory", pem.FamilyMedicalHistory);
                cmd.Parameters.AddWithValue("@VaccinationHistory", pem.VaccinationHistory);
                cmd.Parameters.AddWithValue("@PastMedicalHistory", pem.PastMedicalHistory);
                cmd.Parameters.AddWithValue("@AllergyHistory", pem.AllergyHistory);
                cmd.Parameters.AddWithValue("@SocialHistory", pem.SocialHistory);
                cmd.Parameters.AddWithValue("@GMQuestionareJSON", gmqaString);
                cmd.Parameters.AddWithValue("@PatientId", pem.PatientId);
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

        public List<PhysioAnalysisHistoryModel> GetPhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel eim)
        {
            List<PhysioAnalysisHistoryModel> dacData = new List<PhysioAnalysisHistoryModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPhysioAnalysisHistoryTreatment", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", eim.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    PhysioAnalysisHistoryModel obj = new PhysioAnalysisHistoryModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        OccupationalHistory = ds.Rows[i]["OccupationalHistory"].ToString(),
                        HazardExposureHistory = ds.Rows[i]["HazardExposureHistory"].ToString(),
                        FamilyMedicalHistory = ds.Rows[i]["FamilyMedicalHistory"].ToString(),
                        VaccinationHistory = ds.Rows[i]["VaccinationHistory"].ToString(),
                        PastMedicalHistory = ds.Rows[i]["PastMedicalHistory"].ToString(),
                        AllergyHistory = ds.Rows[i]["AllergyHistory"].ToString(),
                        SocialHistory = ds.Rows[i]["SocialHistory"].ToString(),
                        PatientId = eim.PatientId,
                        GmQuestionList = JsonConvert.DeserializeObject<List<GMQuestionModel>>(ds.Rows[i]["Questionare"].ToString()),
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }

        public TreatmentDetailsModel InsertTreatmentDetails(TreatmentDetailsModel iem)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime TDate = DateTime.ParseExact(iem.TreatmentDate.Trim(), "dd-MM-yyyy", null);
                iem.TreatmentDate = TDate.ToString("yyyy-MM-dd");
                for (int i = 0; i < iem.ItemDetails.Count; i++)
                {
                    DateTime ODate = DateTime.ParseExact(iem.ItemDetails[i].OrderDate.Trim(), "dd-MM-yyyy", null);
                    iem.ItemDetails[i].OrderDate = ODate.ToString("yyyy-MM-dd");

                    DateTime datetimeValue = DateTime.ParseExact(iem.ItemDetails[i].StartDate, "dd-MM-yyyy", null);
                    iem.ItemDetails[i].StartDate = datetimeValue.ToString("yyyy-MM-dd");
                    DateTime datetimeValue2 = DateTime.ParseExact(iem.ItemDetails[i].EndDate, "dd-MM-yyyy", null);
                    iem.ItemDetails[i].EndDate = datetimeValue2.ToString("yyyy-MM-dd");
                }
                iem.TreatmentNumber = AutoregnoCreate(iem.BranchId);
                string itemDetailsString = JsonConvert.SerializeObject(iem.ItemDetails);
                using SqlCommand cmd = new SqlCommand("stLH_InsertTreatmentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", iem.Id);
                cmd.Parameters.AddWithValue("@PatientId", iem.PatientId);
                cmd.Parameters.AddWithValue("@ServicePoint", iem.ServicePoint);
                cmd.Parameters.AddWithValue("@PerformingStaff", iem.PerformingStaff);
                cmd.Parameters.AddWithValue("@TreatmentNumber", iem.TreatmentNumber);
                cmd.Parameters.AddWithValue("@TreatmentDate", iem.TreatmentDate);
                cmd.Parameters.AddWithValue("@TreatmentDetails", iem.TreatmentDetails);
                cmd.Parameters.AddWithValue("@TreatmentRemarks", iem.TreatmentRemarks);
                cmd.Parameters.AddWithValue("@ItemDetailsJSON", itemDetailsString);
                cmd.Parameters.AddWithValue("@ConsultationId", iem.ConsultationId);
                cmd.Parameters.AddWithValue("@AppointmentId", iem.AppointmentId);
                cmd.Parameters.AddWithValue("@UserId", iem.UserId);
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
                    iem.Id = Convert.ToInt32(ret);
                }
                else
                {
                    string response = string.Empty;
                    response = descrip;
                }
            }
            return iem;
        }
        public List<TreatmentDetailsModel> GetTreatmentDetails(TreatmentDetailsModel eim)
        {
            List<TreatmentDetailsModel> dacData = new List<TreatmentDetailsModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTreatmentDetails", con);
            if (eim.DateFrom.Trim() != "" && eim.DateTo.Trim() != "")
            {
                DateTime TDateFrom = DateTime.ParseExact(eim.DateFrom.Trim(), "dd-MM-yyyy", null);
                eim.DateFrom = TDateFrom.ToString("yyyy-MM-dd");

                DateTime TDateTo = DateTime.ParseExact(eim.DateTo.Trim(), "dd-MM-yyyy", null);
                eim.DateTo = TDateTo.ToString("yyyy-MM-dd");
            }
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DateFrom", eim.DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", eim.DateTo);
            cmd.Parameters.AddWithValue("@PatientId", eim.PatientId);
            cmd.Parameters.AddWithValue("@TreatmentId", eim.Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    TreatmentDetailsModel obj = new TreatmentDetailsModel
                    {
                        Id = Convert.ToInt32(ds.Rows[i]["Id"]),
                        PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                        PatientName = ds.Rows[i]["PatientName"].ToString(),
                        RegNo = ds.Rows[i]["RegNo"].ToString(),
                        Mobile = ds.Rows[i]["Mobile"].ToString(),
                        ServicePoint = Convert.ToInt32(ds.Rows[i]["ServicePoint"]),
                        PerformingStaff = Convert.ToInt32(ds.Rows[i]["PerformingStaff"]),
                        TreatmentNumber = ds.Rows[i]["TreatmentNumber"].ToString(),
                        TreatmentDate = ds.Rows[i]["TreatmentDate"].ToString(),
                        TreatmentDetails = ds.Rows[i]["TreatmentDetails"].ToString(),
                        TreatmentRemarks = ds.Rows[i]["TreatmentRemarks"].ToString(),
                        ItemDetails = JsonConvert.DeserializeObject<List<TreatmentItemModel>>(ds.Rows[i]["ItemDetails"].ToString()),
                    };
                    dacData.Add(obj);
                }
            }
            return dacData;
        }
        public string AutoregnoCreate(int BranchId)
        {
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand autonumberCMD = new SqlCommand("stLH_AutoNumberReg", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            autonumberCMD.Parameters.AddWithValue("@NumId", "TREAT-NO");
            autonumberCMD.Parameters.AddWithValue("@BranchId", BranchId);
            SqlParameter patidReturnDesc1 = new SqlParameter("@NewNo", SqlDbType.VarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            autonumberCMD.Parameters.Add(patidReturnDesc1);
            con.Open();
            var isgenerated = autonumberCMD.ExecuteNonQuery();
            con.Close();
            var newregno = patidReturnDesc1.Value.ToString();
            return newregno;
        }
    }
}
