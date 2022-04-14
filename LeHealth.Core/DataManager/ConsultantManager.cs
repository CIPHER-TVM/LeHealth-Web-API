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
using System.Linq;
using System.Text.RegularExpressions;

namespace LeHealth.Core.DataManager
{
    public class ConsultantManager : IConsultantManager
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
        public List<ConsultationModel> SearchConsultationById(ConsultationModel consultation)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultationById", con))
                {
                    DateTime oldFrom = DateTime.ParseExact(consultation.FromDate.Trim(), "dd-MM-yyyy", null);
                    consultation.FromDate = oldFrom.ToString("yyyy-MM-dd");

                    DateTime oldTo = DateTime.ParseExact(consultation.ToDate.Trim(), "dd-MM-yyyy", null);
                    consultation.ToDate = oldTo.ToString("yyyy-MM-dd");

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
                    cmd.Parameters.AddWithValue("@BranchId", consultation.BranchId);
                    cmd.Parameters.AddWithValue("@FromDate", consultation.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", consultation.ToDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < ds.Rows.Count; i++)
                        {
                            ConsultationModel obj = new ConsultationModel
                            {
                                PatientId = Convert.ToInt32(ds.Rows[i]["PatientId"]),
                                ConsultationId = Convert.ToInt32(ds.Rows[i]["ConsultationId"]),
                                ConsultDate = ds.Rows[i]["ConsultDate"].ToString(),
                                PatientName = ds.Rows[i]["PatientName"].ToString(),
                                Consultant = ds.Rows[i]["Consultant"].ToString(),
                                ConsultType2 = ds.Rows[i]["ConsultType"].ToString(),
                                RegNo = ds.Rows[i]["RegNo"].ToString(),
                                PIN = ds.Rows[i]["PIN"].ToString(),
                                OtherReasonForVisit = ds.Rows[i]["Symptoms"].ToString(),
                                Status = ds.Rows[i]["Status"].ToString(),
                                CancelReason = ds.Rows[i]["CancelReason"].ToString(),
                                Mobile = ds.Rows[i]["Mobile"].ToString(),
                                Telephone = ds.Rows[i]["Telephone"].ToString(),
                                Address = ds.Rows[i]["Address"].ToString(),
                                Sponsor = ds.Rows[i]["ConsultationSponsors"].ToString()
                            };
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
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment)
        {
            List<SearchAppointmentModel> appList = new List<SearchAppointmentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchAppointmentByConsultantId", con))
                {
                    DateTime oldFrom = DateTime.ParseExact(appointment.FromDate.Trim(), "dd-MM-yyyy", null);
                    appointment.FromDate = oldFrom.ToString("yyyy-MM-dd");

                    DateTime oldTo = DateTime.ParseExact(appointment.ToDate.Trim(), "dd-MM-yyyy", null);
                    appointment.ToDate = oldTo.ToString("yyyy-MM-dd");
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);
                    if (appointment.ConsultantId == 0 || appointment.ConsultantId == null)
                        cmd.Parameters.AddWithValue("@ConsultantId", 0);
                    else
                        cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                    cmd.Parameters.AddWithValue("@FromDate", appointment.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", appointment.ToDate);

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
        public List<ConsultantPatientModel> SearchPatientByConsultantId(PatientSearchModel patient)
        {
            List<ConsultantPatientModel> patientList = new List<ConsultantPatientModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchPatientsByConsultantId", con))
                {
                    DateTime oldFrom = DateTime.ParseExact(patient.RegDateFrom.Trim(), "dd-MM-yyyy", null);
                    patient.RegDateFrom = oldFrom.ToString("yyyy-MM-dd");

                    DateTime oldTo = DateTime.ParseExact(patient.RegDateTo.Trim(), "dd-MM-yyyy", null);
                    patient.RegDateTo = oldTo.ToString("yyyy-MM-dd");
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", patient.ConsultantId);
                    cmd.Parameters.AddWithValue("@BranchId", patient.BranchId);
                    cmd.Parameters.AddWithValue("@FromDate", patient.RegDateFrom);
                    cmd.Parameters.AddWithValue("@ToDate", patient.RegDateTo);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtPatientList = new DataTable();
                    adapter.Fill(dtPatientList);
                    con.Close();
                    if ((dtPatientList != null) && (dtPatientList.Rows.Count > 0))
                        patientList = dtPatientList.ToListOfObject<ConsultantPatientModel>();

                    return patientList;
                }
            }
        }
        /// <summary>L
        /// </summary>
        /// <param name="Consultant"></param>
        /// <returns></returns>
        public string InsertUpdateConsultant(ConsultantMasterModel consultant)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultant", con);
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

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAllConsultants", con);
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
        public string InsertConsultantService(ConsultantServiceModel consultant)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertConsultantServices", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConsultantId", consultant.ConsultantId);
                cmd.Parameters.AddWithValue("@ItemId", consultant.ItemId);
                cmd.Parameters.AddWithValue("@UserId", consultant.UserId);

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
            return response;
        }
        public string DeleteConsultantService(int serviceId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantServiceItem", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", serviceId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "success";

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public List<ConsultantServiceModel> GetConsultantServices(int consultantId)
        {
            List<ConsultantServiceModel> consultantServices = new List<ConsultantServiceModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantServices", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultantId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtServicesList = new DataTable();
            adapter.Fill(dtServicesList);
            con.Close();
            if ((dtServicesList != null) && (dtServicesList.Rows.Count > 0))
                consultantServices = dtServicesList.ToListOfObject<ConsultantServiceModel>();

            return consultantServices;
        }
        public string InsertConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantDrugs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConsultantId", consultantDrug.ConsultantId);
                cmd.Parameters.AddWithValue("@DrugId", consultantDrug.DrugId);
                cmd.Parameters.AddWithValue("@Dosage", consultantDrug.Dosage);
                cmd.Parameters.AddWithValue("@RouteId", consultantDrug.RouteId);
                cmd.Parameters.AddWithValue("@FreqId", consultantDrug.FreqId);
                cmd.Parameters.AddWithValue("@Duration", consultantDrug.Duration);
                cmd.Parameters.AddWithValue("@DurationMode", consultantDrug.DurationMode);
                cmd.Parameters.AddWithValue("@UserId", consultantDrug.UserId);
                cmd.Parameters.AddWithValue("@DosageId", consultantDrug.DosageId);


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
            return response;
        }
        public string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_UpdateConsultantDrugs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsultantId", consultantDrug.ConsultantId);
                cmd.Parameters.AddWithValue("@DrugId", consultantDrug.DrugId);
                cmd.Parameters.AddWithValue("@Dosage", consultantDrug.Dosage);
                cmd.Parameters.AddWithValue("@RouteId", consultantDrug.RouteId);
                cmd.Parameters.AddWithValue("@FreqId", consultantDrug.FreqId);
                cmd.Parameters.AddWithValue("@Duration", consultantDrug.Duration);
                cmd.Parameters.AddWithValue("@DurationMode", consultantDrug.DurationMode);
                cmd.Parameters.AddWithValue("@UserId", consultantDrug.UserId);
                cmd.Parameters.AddWithValue("@DosageId", consultantDrug.DosageId);


                SqlParameter retVal = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(retVal);
                SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(retDesc);
                con.Open();
                var isUpdated = cmd.ExecuteNonQuery();
                var retV = retVal.Value;
                var retD = retDesc.Value.ToString();
                con.Close();
                if (retD == "Saved Successfully")
                {
                    response = "Success";
                }
                else
                {
                    response = retD;
                }
            }
            return response;
        }
        public List<ConsultantDrugModel> GetConsultantDrugs(int consultantId)
        {
            List<ConsultantDrugModel> consultantServices = new List<ConsultantDrugModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantDrugList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultantId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultantDrugList = new DataTable();
            adapter.Fill(dtConsultantDrugList);
            con.Close();
            if ((dtConsultantDrugList != null) && (dtConsultantDrugList.Rows.Count > 0))
                consultantServices = dtConsultantDrugList.ToListOfObject<ConsultantDrugModel>();

            return consultantServices;
        }
        public string DeleteConsultantDrug(int drugId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantDrug", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DrugId", drugId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "success";

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string InsertConsultantDiseases(DiseaseModel disease)
        {
            List<DiseaseModel> responselist = new List<DiseaseModel>();
            DiseaseModel responseobj = new DiseaseModel();
            SqlTransaction transaction;
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                transaction = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDisease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiseaseId", disease.DiseaseId);
                cmd.Parameters.AddWithValue("@DiseaseDesc", disease.DiseaseDesc);
                cmd.Parameters.AddWithValue("@ConsultantId", disease.ConsultantId);

                SqlParameter diseaseIdParam = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(diseaseIdParam);

                SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(retDesc);
                cmd.Transaction = transaction;
                try
                {
                    cmd.ExecuteNonQuery();
                    int diseaseId = (int)diseaseIdParam.Value;

                    //........................
                    var descrip = retDesc.Value.ToString();
                    if (descrip == "Saved Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }
                    //........................


                    if (diseaseId > 0)//Inserted / Updated Successfully
                    {
                        transaction.Commit();
                        //====================InsertDiseaseICD===========================

                        SqlCommand cmdICD = new SqlCommand("stLH_InsertDiseaseICD", con);
                        cmdICD.CommandType = CommandType.StoredProcedure;

                        cmdICD.Parameters.AddWithValue("@DiseaseId", diseaseId);
                        cmdICD.Parameters.AddWithValue("@LabelId", disease.LabelId);

                        SqlParameter icdRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter icdRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdICD.Parameters.Add(icdRetVal);
                        cmdICD.Parameters.Add(icdRetDesc);
                        cmdICD.ExecuteNonQuery();

                        //........................

                        //........................

                        //====================InsertDiseaseSymptom===========================

                        SqlCommand cmdSymptom = new SqlCommand("stLH_InsertDiseaseSymptom", con);
                        cmdSymptom.CommandType = CommandType.StoredProcedure;

                        cmdSymptom.Parameters.AddWithValue("@DiseaseId", diseaseId);
                        string symptomsString = JsonConvert.SerializeObject(disease.Symptoms);
                        cmdSymptom.Parameters.AddWithValue("@SymptomJSON", symptomsString);

                        SqlParameter symRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter symRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdSymptom.Parameters.Add(symRetVal);
                        cmdSymptom.Parameters.Add(symRetDesc);
                        cmdSymptom.ExecuteNonQuery();


                        //====================InsertDiseaseSign===========================

                        SqlCommand cmdSign = new SqlCommand("stLH_InsertDiseaseSign", con);
                        cmdSign.CommandType = CommandType.StoredProcedure;

                        cmdSign.Parameters.AddWithValue("@DiseaseId", diseaseId);
                        string signsString = JsonConvert.SerializeObject(disease.Signs);
                        cmdSign.Parameters.AddWithValue("@SignJSON", signsString);

                        SqlParameter signRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter signRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdSign.Parameters.Add(signRetVal);
                        cmdSign.Parameters.Add(signRetDesc);
                        cmdSign.ExecuteNonQuery();

                        var descript = signRetDesc.Value.ToString();
                        con.Close();
                        if (descript == "Saved Successfully")
                        {
                            response = "Success";
                        }
                        else
                        {
                            response = descript;
                        }

                    }
                    else
                    {
                        transaction.Rollback();
                        responseobj.DiseaseId = 0;

                    }
                }
                catch (Exception ex)
                {
                    responseobj.DiseaseId = 0;

                }
                con.Close();
            }
            responselist.Add(responseobj);
            return response;
        }
        public List<DiseaseSymptomModel> GetDiseaseSymptoms(int diseaseId)
        {
            List<DiseaseSymptomModel> diseaseSymptoms = new List<DiseaseSymptomModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDiseaseSymptom", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtList = new DataTable();
            adapter.Fill(dtList);
            con.Close();
            if ((dtList != null) && (dtList.Rows.Count > 0))
                diseaseSymptoms = dtList.ToListOfObject<DiseaseSymptomModel>();

            return diseaseSymptoms;
        }
        public List<DiseaseSignModel> GetDiseaseVitalSigns(int diseaseId)
        {
            List<DiseaseSignModel> diseaseSigns = new List<DiseaseSignModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDiseaseSign", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtList = new DataTable();
            adapter.Fill(dtList);
            con.Close();
            if ((dtList != null) && (dtList.Rows.Count > 0))
                diseaseSigns = dtList.ToListOfObject<DiseaseSignModel>();

            return diseaseSigns;
        }
        public List<DiseaseICDModel> GetDiseaseICD(int diseaseId)
        {
            List<DiseaseICDModel> diseaseSigns = new List<DiseaseICDModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDiseaseICD", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtList = new DataTable();
            adapter.Fill(dtList);
            con.Close();
            if ((dtList != null) && (dtList.Rows.Count > 0))
                diseaseSigns = dtList.ToListOfObject<DiseaseICDModel>();

            return diseaseSigns;
        }
        public string DeleteDiseaseICD(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseICD", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);

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
                    if (descrip == "Deleted Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }



                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string DeleteDiseaseSymptom(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseSymptom", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);
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
                    if (descrip == "Deleted Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string DeleteDiseaseSign(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseSign", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);
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
                    if (descrip == "Deleted Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string BlockDisease(DiseaseModel disease)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_BlockDisease", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", disease.DiseaseId);
                    cmd.Parameters.AddWithValue("@BlockReason", disease.BlockReason);

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
                    con.Close();
                    var ret = retValV.Value;
                    var descrip = retDesc.Value.ToString();
                    if (Convert.ToInt32(ret) == disease.DiseaseId)
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string UnblockDisease(DiseaseModel disease)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_UnblockDisease", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", disease.DiseaseId);
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
                    con.Close();
                    var ret = retValV.Value;
                    var descrip = retDesc.Value.ToString();
                    if (Convert.ToInt32(ret) == disease.DiseaseId)
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public List<Appointments> GetMyAppointments(AppointmentModel appointment)
        {
            List<Appointments> appointmentList = new List<Appointments>();
            using SqlConnection con = new SqlConnection(_connStr);
            string AppQuery = "[stLH_GetAppOfaDay]";
            using SqlCommand cmd = new SqlCommand(AppQuery, con);
            con.Open();
            appointment.DeptId = 0;
            DateTime appDate = DateTime.ParseExact(appointment.AppDate.Trim(), "dd-MM-yyyy", null);
            appointment.AppDate = appDate.ToString("yyyy-MM-dd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
            cmd.Parameters.AddWithValue("@AppDate", appointment.AppDate);
            cmd.Parameters.AddWithValue("@DeptId", appointment.DeptId);
            cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtAppointmentList = new DataTable();
            adapter.Fill(dtAppointmentList);
            con.Close();
            if ((dtAppointmentList != null) && (dtAppointmentList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtAppointmentList.Rows.Count; i++)
                {
                    Appointments obj = new Appointments();
                    obj.AppId = Convert.ToInt32(dtAppointmentList.Rows[i]["AppId"]);
                    obj.ConsultantId = Convert.ToInt32(dtAppointmentList.Rows[i]["ConsultantId"].ToString());
                    obj.PatientId = Convert.ToInt32(dtAppointmentList.Rows[i]["PatientId"].ToString());
                    obj.PatientName = dtAppointmentList.Rows[i]["PatientName"].ToString();
                    obj.TimeNo = dtAppointmentList.Rows[i]["TimeNo"].ToString();
                    obj.RegNo = dtAppointmentList.Rows[i]["RegNo"].ToString();
                    obj.Status = dtAppointmentList.Rows[i]["Status"].ToString();
                    obj.Gender = Convert.ToInt32(dtAppointmentList.Rows[i]["Gender"]);
                    obj.AppDate = dtAppointmentList.Rows[i]["AppDate"].ToString();
                    obj.Email = dtAppointmentList.Rows[i]["Email"].ToString();
                    obj.Mobile = dtAppointmentList.Rows[i]["Mobile"].ToString();
                    obj.Address1 = dtAppointmentList.Rows[i]["Address1"].ToString();
                    appointmentList.Add(obj);
                }
            }
            return appointmentList;
        }
        public List<ConsultationModel> GetMyConsultations(ConsultantModel consultation)
        {
            List<ConsultationModel> consultationsList = new List<ConsultationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con);

            con.Open();
            consultation.DeptId = 0;
            DateTime appDate = DateTime.ParseExact(consultation.ConsultantDate.Trim(), "dd-MM-yyyy", null);
            consultation.ConsultantDate = appDate.ToString("yyyy-MM-dd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Status", consultation.Status);
            cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
            cmd.Parameters.AddWithValue("@DepartmentId", consultation.DeptId);
            cmd.Parameters.AddWithValue("@ConsultDate", consultation.ConsultantDate);
            cmd.Parameters.AddWithValue("@BranchId", consultation.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultationsList = new DataTable();
            adapter.Fill(dtConsultationsList);
            con.Close();
            if ((dtConsultationsList != null) && (dtConsultationsList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtConsultationsList.Rows.Count; i++)
                {
                    ConsultationModel obj = new ConsultationModel();
                    obj.ConsultationId = Convert.ToInt32(dtConsultationsList.Rows[i]["ConsultationId"]);
                    obj.TokenNO = dtConsultationsList.Rows[i]["TokenNO"].ToString();
                    obj.DeptId = Convert.ToInt32(dtConsultationsList.Rows[i]["DeptId"]);
                    obj.PatientName = dtConsultationsList.Rows[i]["PatientName"].ToString();
                    obj.PatientId = Convert.ToInt32(dtConsultationsList.Rows[i]["PatientId"]);
                    obj.TimeNo = (dtConsultationsList.Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(dtConsultationsList.Rows[i]["TimeNo"]);
                    obj.RegNo = dtConsultationsList.Rows[i]["RegNo"].ToString();
                    obj.Status = dtConsultationsList.Rows[i]["Status"].ToString();
                    obj.Gender = dtConsultationsList.Rows[i]["Gender"].ToString();
                    obj.Sponsor = dtConsultationsList.Rows[i]["Sponsor"].ToString();
                    obj.Emergency = Convert.ToInt32(dtConsultationsList.Rows[i]["Emergency"]);
                    obj.Address = dtConsultationsList.Rows[i]["Address"].ToString();
                    obj.ConsultDate = dtConsultationsList.Rows[i]["ConsultDate"].ToString();
                    obj.Email = dtConsultationsList.Rows[i]["Email"].ToString();
                    obj.Mobile = dtConsultationsList.Rows[i]["Mobile"].ToString();
                    obj.ChangeStatus = "";
                    obj.CreditTime = "";
                    obj.PolicyNo = dtConsultationsList.Rows[i]["PolicyNo"].ToString();
                    obj.PolicyPeriod = 0;
                    obj.OtherReasonForVisit = dtConsultationsList.Rows[i]["Symptoms"].ToString();
                    consultationsList.Add(obj);
                }
            }

            return consultationsList;
        }
        public string InsertUpdateSchedule(ScheduleModel schedule)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ScheduleId", schedule.ScheduleId);
                cmd.Parameters.AddWithValue("@ConsultantId", schedule.ConsultantId);
                cmd.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", schedule.EndTime);
                cmd.Parameters.AddWithValue("@Title", schedule.Title);


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
            return response;
        }
        public List<ScheduleModel> GetSchedules(int consultantId)
        {
            List<ScheduleModel> schedules = new List<ScheduleModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSchedules", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultantId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtschedulesList = new DataTable();
            adapter.Fill(dtschedulesList);
            con.Close();
            if ((dtschedulesList != null) && (dtschedulesList.Rows.Count > 0))
                schedules = dtschedulesList.ToListOfObject<ScheduleModel>();

            return schedules;
        }
        public string DeleteSchedule(int scheduleId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSchedule", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
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
                    if (descrip == "Deleted Successfully")
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = descrip;
                    }

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public string InsertUpdateTimer(TimerModel timer)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTimer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TimerId", timer.TimerId);
                cmd.Parameters.AddWithValue("@PatientId", timer.PatientId);
                cmd.Parameters.AddWithValue("@ConsultantId", timer.ConsultantId);
                cmd.Parameters.AddWithValue("@UserId", timer.UserId);
                cmd.Parameters.AddWithValue("@StartTime", timer.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", timer.EndTime);
                cmd.Parameters.AddWithValue("@Days", timer.Days);
                cmd.Parameters.AddWithValue("@Hours", timer.Hours);
                cmd.Parameters.AddWithValue("@Minutes", timer.Minutes);
                cmd.Parameters.AddWithValue("@Seconds", timer.Seconds);
                cmd.Parameters.AddWithValue("@TickCount", timer.TickCount);

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
            return response;
        }
        public List<AvailableServiceModel> GetServicesOrderLoadByConsultantId(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetServiceOrderLoadByConsultantId", con);
            con.Open();
            if (cm.OrderFromDate.Trim() != "" && cm.OrderToDate.Trim() != "")
            {
                DateTime orderFromDate = DateTime.ParseExact(cm.OrderFromDate.Trim(), "dd-MM-yyyy", null);
                cm.OrderFromDate = orderFromDate.ToString("yyyy-MM-dd");
                DateTime orderToDate = DateTime.ParseExact(cm.OrderToDate.Trim(), "dd-MM-yyyy", null);
                cm.OrderToDate = orderToDate.ToString("yyyy-MM-dd");
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchId", cm.BranchId);
            cmd.Parameters.AddWithValue("@OrderFromDate", cm.OrderFromDate);
            cmd.Parameters.AddWithValue("@OrderToDate", cm.OrderToDate);
            cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsavailableService = new DataTable();
            adapter.Fill(dsavailableService);
            con.Close();
            if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                {
                    AvailableServiceModel obj = new AvailableServiceModel
                    {
                        OrderId = Convert.ToInt32(dsavailableService.Rows[i]["OrderId"]),
                        OrderDate = dsavailableService.Rows[i]["OrderDate"].ToString(),
                        OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString(),
                        ConsultantName = dsavailableService.Rows[i]["ConsultantName"].ToString(),
                        FirstName = dsavailableService.Rows[i]["FirstName"].ToString(),
                        MiddleName = dsavailableService.Rows[i]["MiddleName"].ToString(),
                        LastName = dsavailableService.Rows[i]["LastName"].ToString(),
                        RegNo = dsavailableService.Rows[i]["RegNo"].ToString(),
                        PatientId = Convert.ToInt32(dsavailableService.Rows[i]["PatientId"]),
                        Selected = Convert.ToInt32(dsavailableService.Rows[i]["Selected"]),
                        IsCancelled = Convert.ToInt32(dsavailableService.Rows[i]["IsCancelled"]),
                        Mobile = dsavailableService.Rows[i]["Mobile"].ToString(),
                        ResNo = dsavailableService.Rows[i]["ResNo"].ToString(),
                        ConsultationId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultationId"])
                    };
                    availableServiceList.Add(obj);
                }
            }
            return availableServiceList;
        }
        public FrontOfficePBarModel GetFrontOfficeProgressBarsByConsultantId(AppointmentModel appointment)
        {
            FrontOfficePBarModel fopb = new FrontOfficePBarModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime appDate = DateTime.ParseExact(appointment.AppDate.Trim(), "dd-MM-yyyy", null);
                appointment.AppDate = appDate.ToString("yyyy-MM-dd");
                List<PercentageCountGetModel> AppcountGetList = new List<PercentageCountGetModel>();
                List<PercentageCountGetModel> ConscountGetList = new List<PercentageCountGetModel>();
                SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetAppointmentCountByConsultantId", con);
                appointmentCountCMD.CommandType = CommandType.StoredProcedure;
                appointmentCountCMD.Parameters.AddWithValue("@AppDate", appointment.AppDate);
                appointmentCountCMD.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                con.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(appointmentCountCMD);
                DataTable dt = new DataTable();
                adapter1.Fill(dt);
                con.Close();
                int AppTotalCount = 0;
                int AppStatA = 0;
                int AppStatC = 0;
                int AppStatF = 0;
                int AppStatCF = 0;
                int AppStatW = 0;
                int AppStatUnknown = 0;

                int ConsTotalCount = 0;
                int ConsStatW = 0;
                int ConsStatF = 0;
                int ConsStatC = 0;
                int ConsStatO = 0;
                int ConsStatUnknown = 0;
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    for (Int32 i = 0; i < dt.Rows.Count; i++)
                    {
                        PatientModel obj = new PatientModel();
                        string StatusName = dt.Rows[i]["StatusName"].ToString();
                        if (StatusName == "A")
                        {
                            AppStatA = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "C")
                        {
                            AppStatC = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "F")
                        {
                            AppStatF = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "CF")
                        {
                            AppStatCF = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "W")
                        {
                            AppStatW = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        else
                        {
                            AppStatUnknown = Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                        }
                        AppTotalCount = AppTotalCount + Convert.ToInt32(dt.Rows[i]["StatusCount"]);
                    }
                }
                SqlCommand consultantcountCMD = new SqlCommand("stLH_GetConsultationCountByConsultantId", con);
                consultantcountCMD.CommandType = CommandType.StoredProcedure;
                consultantcountCMD.Parameters.AddWithValue("@ConsultDate", appointment.AppDate);
                consultantcountCMD.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                con.Open();
                SqlDataAdapter adapter2 = new SqlDataAdapter(consultantcountCMD);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                con.Close();
                if ((dt2 != null) && (dt2.Rows.Count > 0))
                {
                    for (Int32 i = 0; i < dt2.Rows.Count; i++)
                    {
                        PatientModel obj = new PatientModel();
                        string StatusName = dt2.Rows[i]["StatusName"].ToString();
                        if (StatusName == "W")
                        {
                            ConsStatW = Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "F")
                        {
                            ConsStatF = Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "C")
                        {
                            ConsStatC = Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                        }
                        else if (StatusName == "O")
                        {
                            ConsStatO = Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                        }
                        else
                        {
                            ConsStatUnknown = Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                        }
                        ConsTotalCount = ConsTotalCount + Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
                    }
                }
                fopb.AppPercA = (decimal)AppStatA;
                fopb.AppPercC = (decimal)AppStatC;
                fopb.AppPercF = (decimal)AppStatF;
                fopb.AppStatCF = (decimal)AppStatCF;
                fopb.AppPercW = (decimal)AppStatW;

                fopb.ConsPercW = (decimal)ConsStatW;
                fopb.ConsPercF = (decimal)ConsStatF;
                fopb.ConsPercC = (decimal)ConsStatC;
                fopb.ConsPercO = (decimal)ConsStatO;

            }
            return fopb;
        }
        public FrontOfficeProgressBarModel GetFrontOfficeProgressBarByConsultantId(AppointmentModel appointment)
        {
            FrontOfficeProgressBarModel frontOfficeProgressBar = new FrontOfficeProgressBarModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime appDate = DateTime.ParseExact(appointment.AppDate.Trim(), "dd-MM-yyyy", null);
                appointment.AppDate = appDate.ToString("yyyy-MM-dd");
                string jsonAppoinmentsCount = "";
                string jsonConsultationCount = "";
                string jsonResult = "";
                SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetAppointmentCountByConsultId", con);
                appointmentCountCMD.CommandType = CommandType.StoredProcedure;
                appointmentCountCMD.Parameters.AddWithValue("@AppDate", appointment.AppDate);
                appointmentCountCMD.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                con.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(appointmentCountCMD);
                DataTable dt = new DataTable();
                adapter1.Fill(dt);
                con.Close();
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    jsonAppoinmentsCount = Regex.Replace(dt.Rows[0][0].ToString(), @"[\{\[\]\}]", "");
                }
                SqlCommand consultantcountCMD = new SqlCommand("stLH_GetConsultationCountByConsultId", con);
                consultantcountCMD.CommandType = CommandType.StoredProcedure;
                consultantcountCMD.Parameters.AddWithValue("@ConsultDate", appointment.AppDate);
                consultantcountCMD.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
                con.Open();
                SqlDataAdapter adapter2 = new SqlDataAdapter(consultantcountCMD);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                con.Close();
                if ((dt2 != null) && (dt2.Rows.Count > 0))
                {
                    jsonConsultationCount = Regex.Replace(dt2.Rows[0][0].ToString(), @"[\{\[\]\}]", "");
                }
                jsonResult ="{"+ jsonAppoinmentsCount +","+ jsonConsultationCount+"}";
                frontOfficeProgressBar = JsonConvert.DeserializeObject<FrontOfficeProgressBarModel>(jsonResult);

            }
            return frontOfficeProgressBar;
        }
        public DiseaseModel GetDiseaseDetailsById(int diseaseId)
        {
            DiseaseModel disease = new DiseaseModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetDiseaseDetailsById", con);
                appointmentCountCMD.CommandType = CommandType.StoredProcedure;
                appointmentCountCMD.Parameters.AddWithValue("@DiseaseId", diseaseId);
                con.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(appointmentCountCMD);
                DataTable dtDisease = new DataTable();
                adapter1.Fill(dtDisease);
                con.Close();
                if ((dtDisease != null) && (dtDisease.Rows.Count > 0))
                {
                    for (Int32 i = 0; i < dtDisease.Rows.Count; i++)
                    {
                        List<DiseaseICDModel> diseaseICDs = JsonConvert.DeserializeObject<List<DiseaseICDModel>>(dtDisease.Rows[i]["ICD"].ToString());
                        disease = new DiseaseModel
                        {
                            DiseaseId = Convert.ToInt32(dtDisease.Rows[i]["DiseaseId"]),
                            DiseaseDesc = dtDisease.Rows[i]["DiseaseDesc"].ToString(),
                            ConsultantId = Convert.ToInt32(dtDisease.Rows[i]["ConsultantId"]),
                            Active = Convert.ToInt32(dtDisease.Rows[i]["Active"]),
                            BlockReason = dtDisease.Rows[i]["BlockReason"].ToString(),
                            Symptoms = JsonConvert.DeserializeObject<List<DiseaseSymptomModel>>(dtDisease.Rows[i]["Symptoms"].ToString()),
                            Signs = JsonConvert.DeserializeObject<List<DiseaseSignModel>>(dtDisease.Rows[i]["Signs"].ToString()),
                            ICD = diseaseICDs[0]
                        };
                    }
                }
                return disease;

            }
          
        }
        public List<DiseaseModel> GetDiseaseByConsultantId(int consultantId)
        {
            List<DiseaseModel> diseases = new List<DiseaseModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDiseaseByConsultantId", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultantId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtDiseases = new DataTable();
            adapter.Fill(dtDiseases);
            con.Close();
            if ((dtDiseases != null) && (dtDiseases.Rows.Count > 0))
                diseases = dtDiseases.ToListOfObject<DiseaseModel>();

            return diseases;
        }
    }
}
