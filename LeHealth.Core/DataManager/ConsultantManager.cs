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
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchConsultationById", con);
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
        /// <summary>
        /// Get appointment details using ConsultantId
        /// </summary>
        /// <param name="consultantId"> </param>
        /// <returns>List of appointment details</returns>
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment)
        {
            List<SearchAppointmentModel> appList = new List<SearchAppointmentModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchAppointmentByConsultantId", con);
            DateTime oldFrom = DateTime.ParseExact(appointment.FromDate.Trim(), "dd-MM-yyyy", null);
            appointment.FromDate = oldFrom.ToString("yyyy-MM-dd");

            DateTime oldTo = DateTime.ParseExact(appointment.ToDate.Trim(), "dd-MM-yyyy", null);
            appointment.ToDate = oldTo.ToString("yyyy-MM-dd");
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchId", appointment.BranchId);
            if (appointment.ConsultantId == 0)
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
                    SearchAppointmentModel obj = new SearchAppointmentModel
                    {
                        AppId = Convert.ToInt32(dtAppointments.Rows[i]["AppId"]),
                        AppDate = dtAppointments.Rows[i]["AppDate"].ToString(),
                        AppType = (dtAppointments.Rows[0]["AppType"] == DBNull.Value) ? 0 : Convert.ToInt32(dtAppointments.Rows[0]["AppType"]),
                        AppNo = dtAppointments.Rows[i]["AppNo"].ToString(),
                        RegNo = dtAppointments.Rows[i]["RegNo"].ToString(),
                        SliceTime = dtAppointments.Rows[i]["SliceTime"].ToString(),
                        PatientId = (dtAppointments.Rows[0]["PatientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dtAppointments.Rows[0]["PatientId"]),
                        PatientName = dtAppointments.Rows[i]["PatientName"].ToString(),
                        PIN = dtAppointments.Rows[i]["PIN"].ToString(),
                        Mobile = dtAppointments.Rows[i]["ContactNumber"].ToString(),
                        CFirstName = dtAppointments.Rows[i]["ConsultantName"].ToString(),
                        AppStatus = dtAppointments.Rows[i]["Status"].ToString(),
                        CancelReason = dtAppointments.Rows[i]["CancelReason"].ToString(),
                        ResPhone = dtAppointments.Rows[i]["TelePhone"].ToString(),
                        Address1 = dtAppointments.Rows[i]["Address"].ToString(),
                        BranchId = Convert.ToInt32(dtAppointments.Rows[i]["BranchId"]),
                        EntryDate = dtAppointments.Rows[i]["EntryDate"].ToString()
                    };
                    appList.Add(obj);
                    //obj.EntryDate = DateTime.Now;
                    //DateTime dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //DateTime dateValue = DateTime.ParseExact(appointments.AppDate.Trim(), "dd-MM-yyyy", null);
                }
            }
            return appList;
        }
        /// <summary>
        /// Get Patient details using ConsultantId
        /// </summary>
        /// <param name="consultantId"> </param>
        /// <returns>List of Patient details</returns>
        public List<ConsultantPatientModel> SearchPatientByConsultantId(PatientSearchModel patient)
        {
            List<ConsultantPatientModel> patientList = new List<ConsultantPatientModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchPatientsByConsultantId", con);
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
        /// <summary>L
        /// </summary>
        /// <param name="Consultant"></param>
        /// <returns></returns>
        /// 
        public string InsertUpdateConsultant(ConsultantRegModel consultant)
        {
            string response = "";
            SqlTransaction transaction;
            int userId = 0;
            int ConsultantId = 0;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                transaction = con.BeginTransaction();
                try
                {
                    if (consultant.AllowConsultantLogin)
                    {
                        SqlCommand cmdSaveUser = new SqlCommand("stLH_SaveUser", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };


                        var json = JsonConvert.SerializeObject(consultant.UserData.BranchIds);
                        var jsongroups = JsonConvert.SerializeObject(consultant.UserData.GroupIds);
                        cmdSaveUser.Parameters.AddWithValue("@P_UserName", consultant.UserData.UserName);
                        cmdSaveUser.Parameters.AddWithValue("@P_UserPassword", consultant.UserData.UserPassword);
                        cmdSaveUser.Parameters.AddWithValue("@P_UserId", consultant.UserData.UserId);
                        cmdSaveUser.Parameters.AddWithValue("@P_Active", 1);
                        cmdSaveUser.Parameters.AddWithValue("@P_Branches", json);
                        cmdSaveUser.Parameters.AddWithValue("@P_Groups", jsongroups);
                        cmdSaveUser.Parameters.AddWithValue("@P_BlockReason", "");
                        SqlParameter retVal = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdSaveUser.Parameters.Add(retVal);
                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdSaveUser.Parameters.Add(retDesc);
                        cmdSaveUser.Transaction = transaction;
                        cmdSaveUser.ExecuteNonQuery();
                        string sss = retDesc.Value.ToString();
                        //transaction.Commit();
                        if (retVal.Value != System.DBNull.Value)
                        {
                            userId = (int)retVal.Value;
                            transaction.Commit();
                        }
                        else
                        {
                            userId = 0;
                            transaction.Rollback();
                            return "Username already exists";
                        }
                        string descr = retDesc.Value.ToString();
                        response = descr;
                        if (userId > 0)//Inserted / Updated Successfully
                        {
                            if (consultant.LocationIds != null)
                            {
                                SqlCommand cmdSaveLocation = new SqlCommand("stLH_SaveUserLocation", con);
                                List<int> locationIds = consultant.LocationIds.Select(x => x.LocationId).ToList();
                                var jsonLocationId = JsonConvert.SerializeObject(locationIds);
                                cmdSaveLocation.CommandType = CommandType.StoredProcedure;
                                cmdSaveLocation.Parameters.AddWithValue("@P_UserId", userId);
                                cmdSaveLocation.Parameters.AddWithValue("@P_Locations", jsonLocationId);
                                SqlParameter retValSaveLocation = new SqlParameter("@RetVal", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                SqlParameter retDescSaveLocation = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                cmdSaveLocation.Parameters.Add(retValSaveLocation);
                                cmdSaveLocation.Parameters.Add(retDescSaveLocation);
                                cmdSaveLocation.Transaction = transaction;
                                cmdSaveLocation.ExecuteNonQuery();
                                var retDescSaveLocationV = retDescSaveLocation.Value.ToString();
                                response = retDescSaveLocationV;
                            }

                            Lefmenugroupmodel objMenu = new Lefmenugroupmodel();
                            var groupIds = consultant.UserData.GroupIds.Select(s => Convert.ToInt32(s)).ToList();
                            var jsonIntgroups = JsonConvert.SerializeObject(groupIds);
                            jsonIntgroups = jsonIntgroups.Replace("[", "");
                            jsonIntgroups = jsonIntgroups.Replace("]", "");
                            SqlCommand cmdGetMenu = new SqlCommand("stLH_GetMenuongroups", con);
                            cmdGetMenu.CommandType = CommandType.StoredProcedure;
                            cmdGetMenu.Parameters.AddWithValue("@P_UserId", userId);
                            cmdGetMenu.Parameters.AddWithValue("@P_BranchId", consultant.BranchId);
                            cmdGetMenu.Parameters.AddWithValue("@P_GroupIds", jsonIntgroups);
                            SqlParameter retjson = new SqlParameter("@RetJSON", SqlDbType.NVarChar, -1)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter subjson = new SqlParameter("@SubJSON", SqlDbType.NVarChar, -1)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmdGetMenu.Parameters.Add(retjson);
                            cmdGetMenu.Parameters.Add(subjson);
                            cmdGetMenu.Transaction = transaction;
                            cmdGetMenu.ExecuteNonQuery();
                            // string ret = retjson.Value.ToString();
                            string sub = subjson.Value.ToString();
                            if (sub != null)
                            {
                                objMenu.subMenuIds = JsonConvert.DeserializeObject<List<Submenumapmodel>>(sub);
                            }
                            List<int> subMenuIds = objMenu.subMenuIds.Select(x => x.submenuId).ToList();
                            var jsonSubMenuIds = JsonConvert.SerializeObject(subMenuIds);
                            var jsonGroupIds = JsonConvert.SerializeObject(consultant.UserData.GroupIds);
                            SqlCommand cmdSaveMenu = new SqlCommand("stLH_SaveUserMenus", con);
                            cmdSaveMenu.CommandType = CommandType.StoredProcedure;
                            cmdSaveMenu.Parameters.AddWithValue("@P_UserId", userId);
                            cmdSaveMenu.Parameters.AddWithValue("@P_BranchId", consultant.BranchId);
                            cmdSaveMenu.Parameters.AddWithValue("@P_SubmenuIds", jsonSubMenuIds);
                            cmdSaveMenu.Parameters.AddWithValue("@P_Groups", jsonGroupIds);
                            SqlParameter retValSaveMenu = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmdSaveMenu.Parameters.Add(retValSaveMenu);
                            SqlParameter retDescSaveMenu = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmdSaveMenu.Parameters.Add(retDescSaveMenu);
                            cmdSaveMenu.Transaction = transaction;
                            cmdSaveMenu.ExecuteNonQuery();
                            var retp = retValSaveMenu.Value;
                            var descriptio = retDescSaveMenu.Value.ToString();
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                        //DateTime DateOfBirth = DateTime.Parse(consultant.DateOfBirth, null, DateTimeStyles.RoundtripKind);
                        //DateTime DateOfJoin = DateTime.Parse(consultant.DateOfJoin, null, DateTimeStyles.RoundtripKind);
                        DateTime dobdttime = DateTime.ParseExact(consultant.DateOfBirth.Trim(), "dd-MM-yyyy", null);
                        consultant.DateOfBirth = dobdttime.ToString("yyyy-MM-dd");

                        DateTime dojdttime = DateTime.ParseExact(consultant.DateOfJoin.Trim(), "dd-MM-yyyy", null);
                        consultant.DateOfJoin = dojdttime.ToString("yyyy-MM-dd");

                        string Itemidlist = JsonConvert.SerializeObject(consultant.ItemIdList);


                        SqlCommand cmdSaveConsultant = new SqlCommand("stLH_InsertUpdateConsultant", con);
                        cmdSaveConsultant.CommandType = CommandType.StoredProcedure;
                        cmdSaveConsultant.Parameters.AddWithValue("@ConsultantId", consultant.ConsultantId);
                        cmdSaveConsultant.Parameters.AddWithValue("@DeptId", consultant.DeptId);
                        cmdSaveConsultant.Parameters.AddWithValue("@ConsultantCode", consultant.ConsultantCode);
                        cmdSaveConsultant.Parameters.AddWithValue("@Title", consultant.Title);
                        cmdSaveConsultant.Parameters.AddWithValue("@FirstName", consultant.FirstName);
                        cmdSaveConsultant.Parameters.AddWithValue("@MiddleName", consultant.MiddleName);
                        cmdSaveConsultant.Parameters.AddWithValue("@LastName", consultant.LastName);
                        cmdSaveConsultant.Parameters.AddWithValue("@Gender", consultant.Gender);
                        cmdSaveConsultant.Parameters.AddWithValue("@DOB", consultant.DateOfBirth);
                        cmdSaveConsultant.Parameters.AddWithValue("@Age", consultant.Age);
                        cmdSaveConsultant.Parameters.AddWithValue("@Specialisation", consultant.Specialisation);
                        cmdSaveConsultant.Parameters.AddWithValue("@Designation", consultant.Designation);
                        cmdSaveConsultant.Parameters.AddWithValue("@Qualification", consultant.Qualification);
                        cmdSaveConsultant.Parameters.AddWithValue("@NationalityId", consultant.NationalityId);
                        cmdSaveConsultant.Parameters.AddWithValue("@Mobile", consultant.Mobile);
                        cmdSaveConsultant.Parameters.AddWithValue("@ResPhone", consultant.ResPhone);
                        cmdSaveConsultant.Parameters.AddWithValue("@OffPhone", consultant.OffPhone);
                        cmdSaveConsultant.Parameters.AddWithValue("@Email", consultant.Email);
                        cmdSaveConsultant.Parameters.AddWithValue("@Fax", consultant.Fax);
                        cmdSaveConsultant.Parameters.AddWithValue("@DOJ", consultant.DateOfJoin);
                        cmdSaveConsultant.Parameters.AddWithValue("@CRegNo", consultant.CRegNo);
                        cmdSaveConsultant.Parameters.AddWithValue("@AllowCommission", consultant.AllowCommission);
                        cmdSaveConsultant.Parameters.AddWithValue("@DeptOverrule", consultant.DeptOverrule);
                        cmdSaveConsultant.Parameters.AddWithValue("@TimeSlice", consultant.TimeSlice);
                        cmdSaveConsultant.Parameters.AddWithValue("@AppType", consultant.AppType);
                        cmdSaveConsultant.Parameters.AddWithValue("@MaxPatients", consultant.MaxPatients);
                        cmdSaveConsultant.Parameters.AddWithValue("@BranchId", consultant.BranchId);
                        cmdSaveConsultant.Parameters.AddWithValue("@ItemIdList", Itemidlist);
                        cmdSaveConsultant.Parameters.AddWithValue("@DrugRefType", consultant.DrugRefType);
                        cmdSaveConsultant.Parameters.AddWithValue("@Active", consultant.Active);
                        cmdSaveConsultant.Parameters.AddWithValue("@RoomNo", consultant.RoomNo);
                        cmdSaveConsultant.Parameters.AddWithValue("@UserId", userId);
                        cmdSaveConsultant.Parameters.AddWithValue("@DeptwiseCons", consultant.DeptWiseConsultation);
                        cmdSaveConsultant.Parameters.AddWithValue("@Signature", consultant.SignatureLoc);
                        cmdSaveConsultant.Parameters.AddWithValue("@External", consultant.ExternalConsultant);
                        cmdSaveConsultant.Parameters.AddWithValue("@ConsultantLedger", consultant.ConsultantLedger);
                        cmdSaveConsultant.Parameters.AddWithValue("@CommissionId", consultant.CommissionId);
                        cmdSaveConsultant.Parameters.AddWithValue("@SortOrder", consultant.SortOrder);
                        cmdSaveConsultant.Parameters.AddWithValue("@IsDeleted", consultant.IsDeleted);
                        cmdSaveConsultant.Parameters.AddWithValue("@IsDisplayed", consultant.IsDisplayed);
                        SqlParameter retValSaveConsultant = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter retDescSaveConsultant = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdSaveConsultant.Parameters.Add(retValSaveConsultant);
                        cmdSaveConsultant.Parameters.Add(retDescSaveConsultant);
                        cmdSaveConsultant.Transaction = transaction;
                        var isInserted = cmdSaveConsultant.ExecuteNonQuery();

                        ConsultantId = (int)retValSaveConsultant.Value;
                        var description = retDescSaveConsultant.Value.ToString();
                        response = description;
                        if (response == "Saved Successfully" && ConsultantId != 0)
                        {
                            SqlCommand cmdSaveAddress = new SqlCommand("stLH_InsertUpdateConsultantAddress", con);
                            cmdSaveAddress.CommandType = CommandType.StoredProcedure;
                            cmdSaveAddress.Parameters.AddWithValue("@UserId", userId);
                            cmdSaveAddress.Parameters.AddWithValue("@ConsultantId", ConsultantId);
                            cmdSaveAddress.Parameters.AddWithValue("@Address1", consultant.Residence.Address1);
                            cmdSaveAddress.Parameters.AddWithValue("@Address2", consultant.Residence.Address2);
                            cmdSaveAddress.Parameters.AddWithValue("@AddType", consultant.Residence.AddType);
                            cmdSaveAddress.Parameters.AddWithValue("@City", consultant.Residence.City);
                            cmdSaveAddress.Parameters.AddWithValue("@CountryId", consultant.Residence.CountryId);
                            cmdSaveAddress.Parameters.AddWithValue("@PlacePO", consultant.Residence.PlacePO);
                            cmdSaveAddress.Parameters.AddWithValue("@PIN", consultant.Residence.PIN);
                            cmdSaveAddress.Parameters.AddWithValue("@State", consultant.Residence.State);
                            cmdSaveAddress.Parameters.AddWithValue("@Street", consultant.Residence.Street);
                            SqlParameter retValSaveAddress = new SqlParameter("@RetVal", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter retDescSaveAddress = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmdSaveAddress.Parameters.Add(retValSaveAddress);
                            cmdSaveAddress.Parameters.Add(retDescSaveAddress);
                            cmdSaveAddress.Transaction = transaction;
                            cmdSaveAddress.ExecuteNonQuery();
                            int patadrReturn1V = Convert.ToInt32(retValSaveAddress.Value);
                            var patadrReturnDesc1V = retDescSaveAddress.Value.ToString();
                            response = patadrReturnDesc1V;
                            con.Close();
                        }
                    }
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    response = ex.Message.ToString();
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

                int itemIdlistcount = consultant.ItemIdList.Count;
                string ItemIds = string.Empty;
                if (itemIdlistcount > 0)
                    ItemIds = string.Join(",", consultant.ItemIdList.ToArray());
                cmd.Parameters.AddWithValue("@ConsultantId", consultant.ConsultantId);
                cmd.Parameters.AddWithValue("@ItemIdList", ItemIds);
                cmd.Parameters.AddWithValue("@UserId", consultant.UserId);
                cmd.Parameters.AddWithValue("@BranchId", consultant.BranchId);

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
        public string DeleteConsultantService(ConsultantItemModel ci)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantServiceItem", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", ci.ItemId);
                    cmd.Parameters.AddWithValue("@BranchId", ci.BranchId);
                    cmd.Parameters.AddWithValue("@ConsultantId", ci.ConsultantId);
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
        public string InsertConsultantDrugs(List<ConsultantDrugModel> consultantDrugs)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantDrugs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < 1; i++)
                {
                    cmd.Parameters.AddWithValue("@ConsultantId", consultantDrugs[i].ConsultantId);
                    cmd.Parameters.AddWithValue("@UserId", consultantDrugs[i].UserId);

                }
                string drugJson = JsonConvert.SerializeObject(consultantDrugs);
                cmd.Parameters.AddWithValue("@DrugJson", drugJson);
                //cmd.Parameters.AddWithValue("@ConsultantId", consultantDrug.ConsultantId);
                //cmd.Parameters.AddWithValue("@DrugId", consultantDrug.DrugId);
                //cmd.Parameters.AddWithValue("@Dosage", consultantDrug.Dosage);
                //cmd.Parameters.AddWithValue("@RouteId", consultantDrug.RouteId);
                //cmd.Parameters.AddWithValue("@FreqId", consultantDrug.FreqId);
                //cmd.Parameters.AddWithValue("@Duration", consultantDrug.Duration);
                //cmd.Parameters.AddWithValue("@DurationMode", consultantDrug.DurationMode);
                //cmd.Parameters.AddWithValue("@UserId", consultantDrug.UserId);
                //cmd.Parameters.AddWithValue("@DosageId", consultantDrug.DosageId);


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
        public List<DiseaseSignModel> GetDiseaseSigns(int diseaseId)
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
        public List<ScheduleModel> GetSchedules(ScheduleModelAll schedule)
        {
            List<ScheduleModel> schedules = new List<ScheduleModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSchedules", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", schedule.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", schedule.BranchId);

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
        public string InsertConsultantItem(ConsultantItemModel ci)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertConsultantItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsultantId", ci.ConsultantId);
                cmd.Parameters.AddWithValue("@ItemId", ci.ItemId);
                cmd.Parameters.AddWithValue("@BranchId", ci.BranchId);
                cmd.Parameters.AddWithValue("@UserId", ci.UserId);
                cmd.Parameters.AddWithValue("@SessionId", ci.SessionId);
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
        public List<ConsultantItemModel> GetConsultantServicesItems(AvailableServiceModel cm)
        {
            List<ConsultantItemModel> consultantItemList = new List<ConsultantItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantServicesItems", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
            cmd.Parameters.AddWithValue("@PatientId", 0);
            cmd.Parameters.AddWithValue("@BranchId", cm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsavailableService = new DataTable();
            adapter.Fill(dsavailableService);
            con.Close();
            if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                {
                    ConsultantItemModel obj = new ConsultantItemModel
                    {
                        ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]),
                        ItemName = dsavailableService.Rows[i]["ItemName"].ToString(),
                        ConsultantId = cm.ConsultantId,
                        BranchId = cm.BranchId
                    };
                    consultantItemList.Add(obj);
                }
            }
            return consultantItemList;
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
                        AppTotalCount += Convert.ToInt32(dt.Rows[i]["StatusCount"]);
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
                        ConsTotalCount += Convert.ToInt32(dt2.Rows[i]["StatusCount"]);
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
                jsonResult = "{" + jsonAppoinmentsCount + "," + jsonConsultationCount + "}";
                frontOfficeProgressBar = JsonConvert.DeserializeObject<FrontOfficeProgressBarModel>(jsonResult);

            }
            return frontOfficeProgressBar;
        }

        public List<ICDModel> GetICDBySymptomSign(SymptomSignModel ss)
        {
            List<ICDModel> appointmentlist = new List<ICDModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            int signslistcount = ss.Signs.Count;
            int symptomslistcount = ss.Symptoms.Count;
            string SignIds = string.Empty;
            if (signslistcount > 0)
                SignIds = string.Join(",", ss.Signs.ToArray());
            string SymptomIds = string.Empty;
            if (symptomslistcount > 0)
                SymptomIds = string.Join(",", ss.Symptoms.ToArray());
            using SqlCommand cmd = new SqlCommand("stLH_GetICDBySignSymptom", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SignIds", SignIds);
            cmd.Parameters.AddWithValue("@SymptomIds", SymptomIds);
            cmd.Parameters.AddWithValue("@BranchId", ss.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ICDModel obj = new ICDModel();
                    obj.LabelId = Convert.ToInt32(ds.Rows[i]["LabelId"]);
                    obj.LabelDesc = ds.Rows[i]["LabelDesc"].ToString();
                    obj.LabelCode = ds.Rows[i]["LabelCode"].ToString();
                    appointmentlist.Add(obj);
                }
            }
            return appointmentlist;
        }
        public List<ConsultantBaseCostModel> GetConsultantBaseCost(ConsultantBaseCostModelAll ss)
        {
            List<ConsultantBaseCostModel> consultantbasecostlist = new List<ConsultantBaseCostModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            string SignIds = string.Empty;
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantBaseCost", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", ss.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", ss.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultantBaseCostModel obj = new ConsultantBaseCostModel();
                    obj.ConsultantId = Convert.ToInt32(ds.Rows[i]["ConsultantId"]);
                    obj.ConsultantName = ds.Rows[i]["ConsultantName"].ToString();
                    obj.ItemRates = JsonConvert.DeserializeObject<List<ItemRateDetailModel>>(ds.Rows[i]["ConsultantItemRate"].ToString());
                    consultantbasecostlist.Add(obj);
                }
            }
            return consultantbasecostlist;
        }
        public string InsertUpdateConsultantBaseCost(ConsultantBaseCostModelAll cbcm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                string rateString = JsonConvert.SerializeObject(cbcm.itemRateIP);
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantBaseCost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsultantId", cbcm.ConsultantId);
                cmd.Parameters.AddWithValue("@BranchId", cbcm.BranchId);
                cmd.Parameters.AddWithValue("@ItemRateJSON", rateString);
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
        public DiseaseModel GetDiseaseDetailsById(int diseaseId)
        {
            DiseaseModel disease = new DiseaseModel();
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetDisInsertUpdatePackageeaseDetailsById", con);
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
                        ICD = diseaseICDs == null ? null : diseaseICDs[0]
                    };
                }
            }
            return disease;

        }

        public List<ConsultantItemModel> GetConsultantItemByType(ConsultantItemModel ci)
        {
            List<ConsultantItemModel> consultantitemlist = new List<ConsultantItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            string SignIds = string.Empty;
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantItemBytype", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", ci.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", ci.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            con.Close();
            if ((ds != null) && (ds.Rows.Count > 0))
            {
                for (Int32 i = 0; i < ds.Rows.Count; i++)
                {
                    ConsultantItemModel obj = new ConsultantItemModel();
                    obj.ItemId = Convert.ToInt32(ds.Rows[i]["ItemId"]);
                    obj.ItemName = ds.Rows[i]["ItemName"].ToString();
                    obj.ItemSelect = Convert.ToInt32(ds.Rows[i]["ItemSelect"]);
                    consultantitemlist.Add(obj);
                }
            }
            return consultantitemlist;
        }
        public List<DiseaseModel> GetDiseaseByConsultantIdBU(int consultantId)
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

        public List<ConsultantDrugModel> GetConsultantDrugsById(int drugId)
        {
            List<ConsultantDrugModel> consultantDrugs = new List<ConsultantDrugModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantDrugById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugId", drugId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultantDrugList = new DataTable();
            adapter.Fill(dtConsultantDrugList);
            con.Close();
            if ((dtConsultantDrugList != null) && (dtConsultantDrugList.Rows.Count > 0))
                consultantDrugs = dtConsultantDrugList.ToListOfObject<ConsultantDrugModel>();

            return consultantDrugs;
        }
        public string InsertConsultantSketch(SketchModelAll sketch)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertSketch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", sketch.Id);
                cmd.Parameters.AddWithValue("@SketchName", sketch.SketchName);
                cmd.Parameters.AddWithValue("@ConsultantId", sketch.ConsultantId);
                cmd.Parameters.AddWithValue("@FileLocation", sketch.FileLocation);
                cmd.Parameters.AddWithValue("@BranchId", sketch.BranchId);
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
        public List<SketchModel> GetConsultantSketch(SketchModelAll sketch)
        {
            List<SketchModel> consultantMarkings = new List<SketchModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantSketchData", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", sketch.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", sketch.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultantMarkingsList = new DataTable();
            adapter.Fill(dtConsultantMarkingsList);
            con.Close();
            if ((dtConsultantMarkingsList != null) && (dtConsultantMarkingsList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtConsultantMarkingsList.Rows.Count; i++)
                {
                    string imgloc = dtConsultantMarkingsList.Rows[i]["SketchImage"].ToString();
                    SketchModel obj = new SketchModel()
                    {
                        Id = Convert.ToInt32(dtConsultantMarkingsList.Rows[i]["SketchId"]),
                        ConsultantId = sketch.ConsultantId,
                        SketchName = dtConsultantMarkingsList.Rows[i]["SketchName"].ToString(),
                        FileLocation = imgloc != "" ? _uploadpath + imgloc : imgloc
                    };
                    consultantMarkings.Add(obj);
                }
            }
            return consultantMarkings;
        }
        public string InsertUpdateConsultantMarking(ConsultantMarkingModel consultantMarking)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantMarking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MarkId", consultantMarking.MarkId);
                cmd.Parameters.AddWithValue("@MarkDesc", consultantMarking.MarkDesc);
                //cmd.Parameters.AddWithValue("@IndicatorId", consultantMarking.IndicatorId);
                cmd.Parameters.AddWithValue("@Colour", consultantMarking.Colour);
                cmd.Parameters.AddWithValue("@ShowCaption", consultantMarking.ShowCaption);
                cmd.Parameters.AddWithValue("@ConsultantId", consultantMarking.ConsultantId);
                cmd.Parameters.AddWithValue("@BodyPartId", consultantMarking.BodyPartId);
                cmd.Parameters.AddWithValue("@ConsultantMarkingImageLocation", consultantMarking.ConsultantMarkingImageLocation);
                cmd.Parameters.AddWithValue("@BranchId", consultantMarking.BranchId);


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
        public List<ConsultantMarkingModel> GetConsultantMarkings(ConsultantMarkingModel consultantMarking)
        {
            List<ConsultantMarkingModel> consultantMarkings = new List<ConsultantMarkingModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantMarkings", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MarkId", consultantMarking.MarkId);
            cmd.Parameters.AddWithValue("@ConsultantId", consultantMarking.ConsultantId);
            cmd.Parameters.AddWithValue("@BranchId", consultantMarking.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultantMarkingsList = new DataTable();
            adapter.Fill(dtConsultantMarkingsList);
            con.Close();
            if ((dtConsultantMarkingsList != null) && (dtConsultantMarkingsList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtConsultantMarkingsList.Rows.Count; i++)
                {
                    string imgloc = dtConsultantMarkingsList.Rows[i]["ImageLocation"].ToString();
                    string bodypartloc = dtConsultantMarkingsList.Rows[i]["BodyPartImageLocation"].ToString();
                    ConsultantMarkingModel obj = new ConsultantMarkingModel()
                    {
                        MarkId = Convert.ToInt32(dtConsultantMarkingsList.Rows[i]["MarkId"]),
                        MarkDesc = dtConsultantMarkingsList.Rows[i]["MarkDesc"].ToString(),
                        ConsultantMarkingImageLocation = imgloc != "" ? _uploadpath + imgloc : imgloc,
                        BodyPartLocation = bodypartloc != "" ? _uploadpath + bodypartloc : bodypartloc
                    };
                    consultantMarkings.Add(obj);
                }
            }

            return consultantMarkings;
        }
        public string DeleteConsultantMarkings(int markId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantMarkings", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MarkId", markId);
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
        public List<ConsultantMarkingModel> GetConsultantMarkingsById(int markId)
        {
            List<ConsultantMarkingModel> consultantMarkings = new List<ConsultantMarkingModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantMarkingsByMarkid", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MarkId", markId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtConsultantMarkingsList = new DataTable();
            adapter.Fill(dtConsultantMarkingsList);
            con.Close();
            if ((dtConsultantMarkingsList != null) && (dtConsultantMarkingsList.Rows.Count > 0))
                consultantMarkings = dtConsultantMarkingsList.ToListOfObject<ConsultantMarkingModel>();

            return consultantMarkings;
        }
        public string DeleteConsultantDisease(int diseaseId)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantDisease", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseId", diseaseId);
                    cmd.Parameters.AddWithValue("@SessionId", 0);
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

        public ConsultantMasterModel GetConsultantById(int consultantId)
        {
            ConsultantMasterModel consultant = new ConsultantMasterModel();
            using SqlConnection con = new SqlConnection(_connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("stLH_GetConsultant", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultantId);
            cmd.Parameters.AddWithValue("@Active", 1);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                //consultant = dt.ToObject<ConsultantMasterModel>();
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    consultant.Title = dt.Rows[i]["Title"] != null ? dt.Rows[i]["Title"].ToString() : "";
                    consultant.FirstName = dt.Rows[i]["FirstName"] != null ? dt.Rows[i]["FirstName"].ToString() : "";
                    consultant.MiddleName = dt.Rows[i]["MiddleName"] != null ? dt.Rows[i]["MiddleName"].ToString() : "";
                    consultant.LastName = dt.Rows[i]["LastName"] != null ? dt.Rows[i]["LastName"].ToString() : "";
                    consultant.ConsultantId = dt.Rows[i]["ConsultantId"] != null ? Convert.ToInt32(dt.Rows[i]["ConsultantId"]) : 0;
                    consultant.SpecialityCode = dt.Rows[i]["SpecialityCode"] != null ? dt.Rows[i]["SpecialityCode"].ToString() : "";
                    consultant.ConsultantCode = dt.Rows[i]["ConsultantCode"] != null ? dt.Rows[i]["ConsultantCode"].ToString() : "";
                    consultant.DeptId = dt.Rows[i]["DeptId"] != null ? Convert.ToInt32(dt.Rows[i]["DeptId"]) : 0;
                    consultant.Designation = dt.Rows[i]["Designation"] != null ? dt.Rows[i]["Designation"].ToString() : "";
                    consultant.CRegNo = dt.Rows[i]["CRegNo"] != null ? dt.Rows[i]["CRegNo"].ToString() : "";
                    consultant.DOJ = dt.Rows[i]["DOJ"] != null ? dt.Rows[i]["DOJ"].ToString().Replace("/", "-") : "";
                    consultant.Specialisation = dt.Rows[i]["Specialisation"] != null ? dt.Rows[i]["Specialisation"].ToString() : "";
                    consultant.RoomNo = dt.Rows[i]["RoomNo"] != null ? dt.Rows[i]["RoomNo"].ToString() : "";
                    consultant.SortOrder = dt.Rows[i]["SortOrder"] != null ? Convert.ToInt32(dt.Rows[i]["SortOrder"]) : 0;
                    consultant.NationalityId = dt.Rows[i]["NationalityId"] != null ? Convert.ToInt32(dt.Rows[i]["NationalityId"]) : 0;
                    consultant.Gender = dt.Rows[i]["Gender"] != null ? dt.Rows[i]["Gender"].ToString() : "";
                    consultant.DOB = dt.Rows[i]["DOB"] != null ? dt.Rows[i]["DOB"].ToString().Replace("/", "-") : "";
                    consultant.Age = dt.Rows[i]["Age"] != null ? Convert.ToInt32(dt.Rows[i]["Age"]) : 0;
                    consultant.Month = dt.Rows[i]["Month"] != null ? Convert.ToInt32(dt.Rows[i]["Month"]) : 0;
                    consultant.Qualification = dt.Rows[i]["Qualification"] != null ? dt.Rows[i]["Qualification"].ToString() : "";
                    consultant.Mobile = dt.Rows[i]["Mobile"] != null ? dt.Rows[i]["Mobile"].ToString() : "";
                    consultant.ResPhone = dt.Rows[i]["ResPhone"] != null ? dt.Rows[i]["ResPhone"].ToString() : "";
                    consultant.OffPhone = dt.Rows[i]["OffPhone"] != null ? dt.Rows[i]["OffPhone"].ToString() : "";
                    consultant.Email = dt.Rows[i]["Email"] != null ? dt.Rows[i]["Email"].ToString() : "";
                    consultant.Fax = dt.Rows[i]["Fax"] != null ? dt.Rows[i]["Fax"].ToString() : "";
                    consultant.TimeSlice = dt.Rows[i]["TimeSlice"] != null ? Convert.ToInt32(dt.Rows[i]["TimeSlice"]) : 0;
                    consultant.MaxPatients = dt.Rows[i]["MaxPatients"] != null ? Convert.ToInt32(dt.Rows[i]["MaxPatients"]) : 0;
                    consultant.ConsultantLedger = dt.Rows[i]["ConsultantLedger"] != null ? Convert.ToInt32(dt.Rows[i]["ConsultantLedger"]) : 0;
                    consultant.CommissionId = dt.Rows[i]["CommissionId"] != null ? Convert.ToInt32(dt.Rows[i]["CommissionId"]) : 0;
                    consultant.AllowCommission = dt.Rows[i]["AllowCommission"] != null ? Convert.ToBoolean(dt.Rows[i]["AllowCommission"]) : false;
                    consultant.DeptOverrule = dt.Rows[i]["DeptOverrule"] != null ? Convert.ToBoolean(dt.Rows[i]["DeptOverrule"]) : false;
                    consultant.DeptWiseConsultation = dt.Rows[i]["DeptWiseConsultation"] != null ? Convert.ToBoolean(dt.Rows[i]["DeptWiseConsultation"]) : false;
                    consultant.ExternalConsultant = dt.Rows[i]["ExternalConsultant"] != null ? Convert.ToBoolean(dt.Rows[i]["ExternalConsultant"]) : false;
                    consultant.AppType = dt.Rows[i]["AppType"] != null ? Convert.ToInt32(dt.Rows[i]["AppType"]) : 0;
                    consultant.SignatureLoc = dt.Rows[i]["SignatureLoc"] != null ? dt.Rows[i]["SignatureLoc"].ToString() : "";
                    consultant.DrugRefType = Convert.ToInt32(dt.Rows[i]["DrugRefType"]);
                    consultant.UserId = Convert.ToInt32(dt.Rows[i]["ConsultantUserId"]);
                    consultant.ItemIdList = JsonConvert.DeserializeObject<List<ItemIdListCls>>(dt.Rows[i]["ItemIdList"].ToString());
                }
                con.Open();
                SqlCommand cmdAddress = new SqlCommand("stLH_GetConsultantAddress", con);
                cmdAddress.CommandType = CommandType.StoredProcedure;
                cmdAddress.Parameters.AddWithValue("@ConsultantId", consultantId);
                cmdAddress.Parameters.AddWithValue("@AddType", 0);
                SqlDataAdapter adapter3 = new SqlDataAdapter(cmdAddress);
                DataTable dsAddress = new DataTable();
                adapter3.Fill(dsAddress);
                con.Close();
                ConsultantAddressModel consultantAddress = new ConsultantAddressModel();
                if ((dsAddress != null) && (dsAddress.Rows.Count > 0))
                {
                    consultantAddress = dsAddress.ToObject<ConsultantAddressModel>();
                    for (Int32 i = 0; i < dsAddress.Rows.Count; i++)
                    {
                        consultantAddress.Address1 = dsAddress.Rows[i]["Address1"] != null ? dsAddress.Rows[i]["Address1"].ToString() : "";
                        consultantAddress.Address2 = dsAddress.Rows[i]["Address2"] != null ? dsAddress.Rows[i]["Address2"].ToString() : "";
                        consultantAddress.AddType = dsAddress.Rows[i]["AddType"] != null ? Convert.ToInt32(dsAddress.Rows[i]["AddType"]) : 0;
                        consultantAddress.City = dsAddress.Rows[i]["City"] != null ? dsAddress.Rows[i]["City"].ToString() : "";
                        consultantAddress.ConsultantId = dsAddress.Rows[i]["ConsultantId"] != null ? Convert.ToInt32(dsAddress.Rows[i]["ConsultantId"]) : 0;
                        consultantAddress.CountryId = dsAddress.Rows[i]["CountryId"] != null ? Convert.ToInt32(dsAddress.Rows[i]["CountryId"]) : 0;
                        consultantAddress.PIN = dsAddress.Rows[i]["PIN"] != null ? dsAddress.Rows[i]["PIN"].ToString() : "";
                        consultantAddress.PlacePO = dsAddress.Rows[i]["PlacePO"] != null ? dsAddress.Rows[i]["PlacePO"].ToString() : "";
                        consultantAddress.State = dsAddress.Rows[i]["State"] != null ? dsAddress.Rows[i]["State"].ToString() : "";
                        consultantAddress.Street = dsAddress.Rows[i]["Street"] != null ? dsAddress.Rows[i]["Street"].ToString() : "";
                    }
                }
                consultant.Residence = consultantAddress;
            }




            return consultant;
        }
        public string InsertUpdateConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            List<ConsultantTimeScheduleMaster> responselist = new List<ConsultantTimeScheduleMaster>();
            ConsultantTimeScheduleMaster responseobj = new ConsultantTimeScheduleMaster();
            SqlTransaction transaction;
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                transaction = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultantTimeScheduleMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string DayIds = "";

                foreach (var timeSchedule in timeScheduleMaster.TimeSchedules)
                {

                    string temp = DayIds;
                    temp = temp + timeSchedule.DayId + "-";
                    DayIds = temp;

                    timeSchedule.FromTime = timeSchedule.FromHour + ":" + timeSchedule.FromMinute;
                    timeSchedule.ToTime = timeSchedule.ToHour + ":" + timeSchedule.ToMinute;
                }

                cmd.Parameters.AddWithValue("@ScheMid", timeScheduleMaster.ScheMid);
                cmd.Parameters.AddWithValue("@ConsultantId", timeScheduleMaster.ConsultantId);
                cmd.Parameters.AddWithValue("@BranchId", timeScheduleMaster.BranchId);
                cmd.Parameters.AddWithValue("@UserId", timeScheduleMaster.UserId);
                cmd.Parameters.AddWithValue("@AlldaySameFlag", timeScheduleMaster.AlldaySameFlag);
                cmd.Parameters.AddWithValue("@DayIds", DayIds);



                SqlParameter timeMasterRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(timeMasterRetVal);

                SqlParameter timeMasterRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(timeMasterRetDesc);
                cmd.Transaction = transaction;
                try
                {
                    cmd.ExecuteNonQuery();
                    int ScheduleMasterId = (int)timeMasterRetVal.Value;

                    //........................
                    var desceMaster = timeMasterRetDesc.Value.ToString();
                    response = desceMaster;
                    if (desceMaster == "Saved Successfully")
                    {
                        response = "Success";
                    }

                    if (ScheduleMasterId > 0)//Inserted / Updated Successfully
                    {
                        transaction.Commit();
                        //====================InsertTimeSchedules===========================
                        string timeScheduleString = JsonConvert.SerializeObject(timeScheduleMaster.TimeSchedules);

                        SqlCommand cmdTimeSchedule = new SqlCommand("stLH_InsertConsultantTimeSchedule", con);
                        cmdTimeSchedule.CommandType = CommandType.StoredProcedure;

                        cmdTimeSchedule.Parameters.AddWithValue("@ScheMid", ScheduleMasterId);
                        cmdTimeSchedule.Parameters.AddWithValue("@ConsultantId", timeScheduleMaster.ConsultantId);
                        cmdTimeSchedule.Parameters.AddWithValue("@BranchId", timeScheduleMaster.BranchId);
                        cmdTimeSchedule.Parameters.AddWithValue("@UserId", timeScheduleMaster.UserId);
                        cmdTimeSchedule.Parameters.AddWithValue("@TimeScheduleJSON", timeScheduleString);

                        SqlParameter timeScheduleRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter timeScheduleRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdTimeSchedule.Parameters.Add(timeScheduleRetVal);
                        cmdTimeSchedule.Parameters.Add(timeScheduleRetDesc);
                        cmdTimeSchedule.ExecuteNonQuery();

                        var descTimeSchedule = timeScheduleRetDesc.Value.ToString();
                        con.Close();
                        response = descTimeSchedule;
                        if (descTimeSchedule == "Saved Successfully")
                        {
                            response = "Success";
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        responseobj.ScheMid = 0;

                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    responseobj.ScheMid = 0;
                }
                con.Close();
            }
            responselist.Add(responseobj);
            return response;
        }
        public ConsultantTimeScheduleMaster GetConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            ConsultantTimeScheduleMaster consultant = new ConsultantTimeScheduleMaster();
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand appointmentCountCMD = new SqlCommand("stLH_GetConsultantTimeScheduleById", con);
            appointmentCountCMD.CommandType = CommandType.StoredProcedure;
            appointmentCountCMD.Parameters.AddWithValue("@ConsultantId", timeScheduleMaster.ConsultantId);
            appointmentCountCMD.Parameters.AddWithValue("@BranchId", timeScheduleMaster.BranchId);
            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(appointmentCountCMD);
            DataTable dataTable = new DataTable();
            adapter1.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {

                    List<ConsultantTimeSchedule> timeSchedules = JsonConvert.DeserializeObject<List<ConsultantTimeSchedule>>(dataTable.Rows[i]["TimeSchedules"].ToString());
                    foreach (var item in timeSchedules)
                    {
                        string[] strlistFrom = item.FromTime.Split(':');
                        string[] strlistTo = item.ToTime.Split(':');
                        item.FromHour = (strlistFrom[0] != "") ? strlistFrom[0] : "00";
                        item.FromMinute = (strlistFrom[1] != "") ? strlistFrom[1] : "00";

                        item.ToHour = (strlistTo[0] != "") ? strlistTo[0] : "00";
                        item.ToMinute = (strlistTo[1] != "") ? strlistTo[1] : "00";
                    }

                    consultant = new ConsultantTimeScheduleMaster
                    {

                        ScheMid = Convert.ToInt32(dataTable.Rows[i]["ScheMid"]),
                        ConsultantId = Convert.ToInt32(dataTable.Rows[i]["ConsultantId"]),
                        BranchId = Convert.ToInt32(dataTable.Rows[i]["BranchId"]),
                        AlldaySameFlag = Convert.ToInt32(dataTable.Rows[i]["AlldaySameFlag"]),
                        UserId = Convert.ToInt32(dataTable.Rows[i]["UserId"]),
                        TimeSchedules = timeSchedules,





                    };


                }
            }
            return consultant;

        }
        public string DeleteConsultant(int id)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultant", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", id);

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

    }
}
