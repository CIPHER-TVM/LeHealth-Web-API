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
        public List<ConsultationModel> SearchConsultationById(ConsultationModel consultation)
        {
            List<ConsultationModel> Consultationlist = new List<ConsultationModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchConsultationById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
                    cmd.Parameters.AddWithValue("@BranchId", consultation.BranchId);

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
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment)
        {
            List<SearchAppointmentModel> appList = new List<SearchAppointmentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SearchAppointmentByConsultantId", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);
                    if (appointment.ConsultantId == 0 || appointment.ConsultantId == null)
                        cmd.Parameters.AddWithValue("@ConsultantId", 0);
                    else
                        cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);

                 
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
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", patient.ConsultantId);
                    cmd.Parameters.AddWithValue("@BranchId", patient.BranchId);

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
        public string InsertConsultantService(ConsultantServiceModel consultant)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertConsultantServices", con))
                {
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
            }
            return response;
        }
        public string DeleteConsultantService(int serviceId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantServiceItem", con))
                {
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
            }
            return response;
        }
        public List<ConsultantServiceModel> GetConsultantServices(int consultantId)
        {
            List<ConsultantServiceModel> consultantServices = new List<ConsultantServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantServices", con))
                {
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
            }
        }
        public string InsertConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantDrugs", con))
                {
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
            }
            return response;
        }
        public string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateConsultantDrugs", con))
                {
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
            }
            return response;
        }
        public List<ConsultantDrugModel> GetConsultantDrugs(int consultantId)
        {
            List<ConsultantDrugModel> consultantServices = new List<ConsultantDrugModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantDrugList", con))
                {
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
            }
        }
        public string DeleteConsultantDrug(int drugId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantDrug", con))
                {
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
            }
            return response;
        }
        public string InsertConsultantDiseases(DiseaseModel disease)
        {
            List<DiseaseModel> responselist = new List<DiseaseModel>();
            DiseaseModel responseobj = new DiseaseModel();
            SqlTransaction transaction;
            string response = string.Empty;
            string Description = string.Empty;
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

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDiseaseSymptom", con))
                {
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
            }
        }
        public List<DiseaseSignModel> GetDiseaseVitalSigns(int diseaseId)
        {
            List<DiseaseSignModel> diseaseSigns = new List<DiseaseSignModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDiseaseSign", con))
                {
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
            }
        }
        public List<DiseaseICDModel> GetDiseaseICD(int diseaseId)
        {
            List<DiseaseICDModel> diseaseSigns = new List<DiseaseICDModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDiseaseICD", con))
                {
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
            }
        }
        public string DeleteDiseaseICD(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseICD", con))
                {
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
            }
            return response;
        }
        public string DeleteDiseaseSymptom(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseSymptom", con))
                {
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
            }
            return response;
        }
        public string DeleteDiseaseSign(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteDiseaseSign", con))
                {
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
            }
            return response;
        }
        public string BlockDisease(DiseaseModel disease)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_BlockDisease", con))
                {
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
            }
            return response;
        }
        public string UnblockDisease(DiseaseModel disease)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UnblockDisease", con))
                {
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
            }
            return response;
        }
    }
}
