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

namespace LeHealth.Core.DataManager
{
    public class MasterDataManager : IMasterDataManager
    {
        private readonly string _connStr;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }
        //ProfessionManagement Starts
        public List<ProfessionModel> GetProfession(int profid)
        {
            List<ProfessionModel> profList = new List<ProfessionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfession", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfId", profid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            ProfessionModel obj = new ProfessionModel();
                            obj.ProfId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfId"]);
                            obj.ProfName = dsProfession.Tables[0].Rows[i]["ProfName"].ToString();
                            obj.ProfGroup = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfGroup"]);
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }

        public string InsertUpdateProfession(ProfessionModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateProfession", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfId", zone.ProfId);
                    cmd.Parameters.AddWithValue("@ProfName", zone.ProfName);
                    cmd.Parameters.AddWithValue("@UserId", zone.UserId);
                    cmd.Parameters.AddWithValue("@ProfGroup", zone.ProfGroup);
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

        public string DeleteProfession(int profid)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteProfession", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", profid);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }

        //ProfessionManagement Ends

        public List<AppTypeModel> GetAppType()
        {
            List<AppTypeModel> profList = new List<AppTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAppointTypes", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            AppTypeModel obj = new AppTypeModel();
                            obj.AppTypeId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["AppTypeId"]);
                            obj.AppCode = dsProfession.Tables[0].Rows[i]["AppCode"].ToString();
                            obj.AppDesc = dsProfession.Tables[0].Rows[i]["AppDesc"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
        public string InsertZone(ZoneModel zone)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ZoneId", zone.Id);
                    cmd.Parameters.AddWithValue("@OperatorId", zone.OperatorId);
                    cmd.Parameters.AddWithValue("@ZoneName", zone.ZoneName);
                    cmd.Parameters.AddWithValue("@ZoneCode", zone.ZoneCode);
                    cmd.Parameters.AddWithValue("@ZoneDescription", zone.ZoneDescription);
                    cmd.Parameters.AddWithValue("@ZoneCountry", zone.ZoneCountry);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteZone(int zoneId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteZone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_ZoneById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@zoneId", zoneId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
                    return stateList;
                }
            }
        }
        public List<ZoneModel> GetAllZone()
        {
            List<ZoneModel> stateList = new List<ZoneModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllZone", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        stateList = dsStateList.Tables[0].ToListOfObject<ZoneModel>();
                    return stateList;
                }
            }
        }

        public List<ReligionModel> GetReligion()
        {
            List<ReligionModel> religionList = new List<ReligionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetReligion", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsReligionList = new DataSet();
                    adapter.Fill(dsReligionList);
                    con.Close();
                    if ((dsReligionList != null) && (dsReligionList.Tables.Count > 0) && (dsReligionList.Tables[0] != null) && (dsReligionList.Tables[0].Rows.Count > 0))
                        religionList = dsReligionList.Tables[0].ToListOfObject<ReligionModel>();
                    return religionList;
                }
            }
        }

        /// <summary>
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments(int DeptId)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", DeptId);
                    cmd.Parameters.AddWithValue("@Active", 1);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DepartmentModel obj = new DepartmentModel();
                            obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
                            obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                            obj.DeptCode = ds.Tables[0].Rows[i]["DeptCode"].ToString();
                            obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                            obj.BranchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BranchId"]);
                            obj.TimeSlice = ds.Tables[0].Rows[i]["TimeSlice"].ToString();
                            obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            departmentlist.Add(obj);
                        }
                    }
                    return departmentlist;
                }
            }
        }
        public string InsertUpdateDepartment(DepartmentModel RegScheme)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", RegScheme.DeptId);
                    cmd.Parameters.AddWithValue("@DeptName", RegScheme.DeptName);
                    cmd.Parameters.AddWithValue("@DeptCode", RegScheme.DeptCode);
                    cmd.Parameters.AddWithValue("@BranchId", RegScheme.BranchId);
                    cmd.Parameters.AddWithValue("@Description", RegScheme.Description);
                    cmd.Parameters.AddWithValue("@TimeSlice", RegScheme.TimeSlice);
                    cmd.Parameters.AddWithValue("@Active", RegScheme.Active);
                    cmd.Parameters.AddWithValue("@UserId", RegScheme.UserId);
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
        public string DeleteDepartment(int DeptId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", DeptId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        //
        public string InsertRegScheme(RegSchemeModel RegScheme)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertRegScheme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemCode", RegScheme.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", RegScheme.ItemName);
                    cmd.Parameters.AddWithValue("@GroupId", RegScheme.GroupId);
                    cmd.Parameters.AddWithValue("@ValidityDays", RegScheme.ValidityDays);
                    cmd.Parameters.AddWithValue("@ValidityVisits", RegScheme.ValidityVisits);
                    cmd.Parameters.AddWithValue("@AllowRateEdit", RegScheme.AllowRateEdit);
                    cmd.Parameters.AddWithValue("@AllowDisc", RegScheme.AllowDisc);
                    cmd.Parameters.AddWithValue("@AllowPP", RegScheme.AllowPP);
                    cmd.Parameters.AddWithValue("@IsVSign", RegScheme.IsVSign);
                    cmd.Parameters.AddWithValue("@ResultOn", RegScheme.ResultOn);
                    cmd.Parameters.AddWithValue("@STypeId", RegScheme.STypeId);
                    cmd.Parameters.AddWithValue("@TotalTaxPcnt", RegScheme.TotalTaxPcnt);
                    cmd.Parameters.AddWithValue("@AllowCommission", RegScheme.AllowCommission);
                    cmd.Parameters.AddWithValue("@CommPcnt", RegScheme.CommPcnt);
                    cmd.Parameters.AddWithValue("@CommAmt", RegScheme.CommAmt);
                    cmd.Parameters.AddWithValue("@MaterialCost", RegScheme.MaterialCost);
                    cmd.Parameters.AddWithValue("@BaseCost", RegScheme.BaseCost);
                    cmd.Parameters.AddWithValue("@HeadId", RegScheme.HeadId);
                    cmd.Parameters.AddWithValue("@SortOrder", RegScheme.SortOrder);
                    cmd.Parameters.AddWithValue("@CPTCodeId", RegScheme.CPTCodeId);
                    cmd.Parameters.AddWithValue("@ExternalItem", RegScheme.ExternalItem);
                    con.Open();
                    var isSaved = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateRegScheme(RegSchemeModel RegScheme)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateRegScheme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", RegScheme.ItemId);
                    cmd.Parameters.AddWithValue("@ItemCode", RegScheme.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", RegScheme.ItemName);
                    cmd.Parameters.AddWithValue("@GroupId", RegScheme.GroupId);
                    cmd.Parameters.AddWithValue("@ValidityDays", RegScheme.ValidityDays);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteRegScheme(int RegSchemeId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteRegScheme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", RegSchemeId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<RegSchemeModel> GetRegSchemeById(int RegSchemeId)
        {
            List<RegSchemeModel> stateList = new List<RegSchemeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_RegSchemeById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemId", RegSchemeId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RegSchemeModel obj = new RegSchemeModel();
                            obj.ItemId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemCode = dsStateList.Tables[0].Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsStateList.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.GroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["GroupId"]);
                            obj.ValidityDays = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ValidityDays"]);
                            obj.ValidityVisits = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ValidityVisits"]);
                            obj.AllowRateEdit = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowRateEdit"]);
                            obj.AllowDisc = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowDisc"]);
                            obj.AllowPP = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowPP"]);
                            obj.IsVSign = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["IsVSign"]);
                            obj.ResultOn = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ResultOn"]);
                            obj.STypeId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["STypeId"]);
                            obj.TotalTaxPcnt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["TotalTaxPcnt"]);
                            obj.AllowCommission = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowCommission"]);
                            obj.CommPcnt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CommPcnt"]);
                            obj.CommAmt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CommAmt"]);
                            obj.MaterialCost = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["MaterialCost"]);
                            obj.BaseCost = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["BaseCost"]);
                            obj.HeadId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["HeadId"]);
                            obj.SortOrder = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["SortOrder"]);
                            obj.Active = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsStateList.Tables[0].Rows[i]["BlockReason"].ToString();
                            obj.CPTCodeId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CPTCodeId"]);
                            obj.ExternalItem = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ExternalItem"]);
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<RegSchemeModel> GetAllRegScheme()
        {
            List<RegSchemeModel> stateList = new List<RegSchemeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllRegScheme", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    //stateList = dsStateList.Tables[0].ToListOfObject<RegSchemeModel>();
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RegSchemeModel obj = new RegSchemeModel();
                            obj.ItemId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ItemId"]);
                            obj.ItemCode = dsStateList.Tables[0].Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsStateList.Tables[0].Rows[i]["ItemName"].ToString();
                            obj.GroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["GroupId"]);
                            obj.ValidityDays = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ValidityDays"]);
                            obj.ValidityVisits = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ValidityVisits"]);
                            obj.AllowRateEdit = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowRateEdit"]);
                            obj.AllowDisc = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowDisc"]);
                            obj.AllowPP = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowPP"]);
                            obj.IsVSign = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["IsVSign"]);
                            obj.ResultOn = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ResultOn"]);
                            obj.STypeId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["STypeId"]);
                            obj.TotalTaxPcnt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["TotalTaxPcnt"]);
                            obj.AllowCommission = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["AllowCommission"]);
                            obj.CommPcnt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CommPcnt"]);
                            obj.CommAmt = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CommAmt"]);
                            obj.MaterialCost = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["MaterialCost"]);
                            obj.BaseCost = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["BaseCost"]);
                            obj.HeadId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["HeadId"]);
                            obj.SortOrder = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["SortOrder"]);
                            obj.Active = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsStateList.Tables[0].Rows[i]["BlockReason"].ToString();
                            obj.CPTCodeId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["CPTCodeId"]);
                            obj.ExternalItem = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["ExternalItem"]);
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        //Rate group Starts

        public string InsertRateGroup(RateGroupModel RateGroup)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                    cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                    cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                    cmd.Parameters.AddWithValue("@EffectFrom", Convert.ToDateTime(RateGroup.EffectFrom));
                    cmd.Parameters.AddWithValue("@EffectTo", Convert.ToDateTime(RateGroup.EffectTo));
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateRateGroup(RateGroupModel RateGroup)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                    cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                    cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                    cmd.Parameters.AddWithValue("@EffectFrom", Convert.ToDateTime(RateGroup.EffectFrom));
                    cmd.Parameters.AddWithValue("@EffectTo", Convert.ToDateTime(RateGroup.EffectTo));
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteRateGroup(int RateGroupId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteRateGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RGroupId", RateGroupId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<RateGroupModel> GetRateGroupById(int RateGroupId)
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_RateGroupById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RateGroupId", RateGroupId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RateGroupModel obj = new RateGroupModel();
                            obj.RGroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["RGroupId"]);
                            obj.RGroupName = dsStateList.Tables[0].Rows[i]["RGroupName"].ToString();
                            obj.Description = dsStateList.Tables[0].Rows[i]["Description"].ToString();
                            obj.EffectFrom = dsStateList.Tables[0].Rows[i]["EffectFrom"].ToString();
                            obj.EffectTo = dsStateList.Tables[0].Rows[i]["EffectTo"].ToString();
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<RateGroupModel> GetAllRateGroup()
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllRateGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            RateGroupModel obj = new RateGroupModel();
                            obj.RGroupId = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["RGroupId"]);
                            obj.RGroupName = dsStateList.Tables[0].Rows[i]["RGroupName"].ToString();
                            obj.Description = dsStateList.Tables[0].Rows[i]["Description"].ToString();
                            obj.EffectFrom = dsStateList.Tables[0].Rows[i]["EffectFrom"].ToString();
                            obj.EffectTo = dsStateList.Tables[0].Rows[i]["EffectTo"].ToString();
                            stateList.Add(obj);
                        }
                    return stateList;
                }
            }
        }
        //Rate Group Ends
        //Hospital Starts
        /// <summary>
        /// Get Hospital list from database.Step three in code execution flow
        /// </summary>
        /// <returns></returns>

        public List<HospitalModel> GetUserHospitals(int id)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsHospitalList = new DataSet();
                    adapter.Fill(dsHospitalList);
                    con.Close();
                    if ((dsHospitalList != null) && (dsHospitalList.Tables.Count > 0) && (dsHospitalList.Tables[0] != null) && (dsHospitalList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsHospitalList.Tables[0].Rows.Count; i++)
                        {
                            HospitalModel obj = new HospitalModel();
                            obj.HospitalId = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["HospitalId"]);
                            obj.HospitalName = dsHospitalList.Tables[0].Rows[i]["HospitalName"].ToString();
                            obj.HospitalCode = dsHospitalList.Tables[0].Rows[i]["HospitalCode"].ToString();
                            obj.Caption = dsHospitalList.Tables[0].Rows[i]["Caption"].ToString();
                            obj.Address1 = dsHospitalList.Tables[0].Rows[i]["Address1"].ToString();
                            obj.Address2 = dsHospitalList.Tables[0].Rows[i]["Address2"].ToString();
                            obj.Street = dsHospitalList.Tables[0].Rows[i]["Street"].ToString();
                            obj.PlacePO = dsHospitalList.Tables[0].Rows[i]["PlacePO"].ToString();
                            obj.PIN = dsHospitalList.Tables[0].Rows[i]["PIN"].ToString();
                            obj.City = dsHospitalList.Tables[0].Rows[i]["City"].ToString();
                            obj.State = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["State"]);
                            obj.Country = Convert.ToInt32(dsHospitalList.Tables[0].Rows[i]["Country"]);
                            obj.Phone = dsHospitalList.Tables[0].Rows[i]["Phone"].ToString();
                            obj.Fax = dsHospitalList.Tables[0].Rows[i]["Fax"].ToString();
                            obj.Email = dsHospitalList.Tables[0].Rows[i]["Email"].ToString();
                            obj.URL = dsHospitalList.Tables[0].Rows[i]["URL"].ToString();
                            obj.Logo = dsHospitalList.Tables[0].Rows[i]["Logo"].ToString();
                            obj.ReportLogo = dsHospitalList.Tables[0].Rows[i]["ReportLogo"].ToString();
                            obj.ClinicId = dsHospitalList.Tables[0].Rows[i]["ClinicId"].ToString();
                            obj.DHAFacilityId = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.DHAUserName = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.DHAPassword = dsHospitalList.Tables[0].Rows[i]["DHAFacilityId"].ToString();
                            obj.SR_ID = dsHospitalList.Tables[0].Rows[i]["SR_ID"].ToString();
                            obj.MalaffiSystemcode = dsHospitalList.Tables[0].Rows[i]["MalaffiSystemcode"].ToString();
                            hospitalList.Add(obj);
                        }
                    }
                    return hospitalList;

                }
            }

        }

        public string InsertUpdateUserHospital(HospitalRegModel hospital)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateHospital", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", hospital.HospitalId);
                    cmd.Parameters.AddWithValue("@HospitalName", hospital.HospitalName);
                    cmd.Parameters.AddWithValue("@HospitalCode", hospital.HospitalCode);
                    cmd.Parameters.AddWithValue("@Caption", hospital.Caption);
                    cmd.Parameters.AddWithValue("@Address1", hospital.Address1);
                    cmd.Parameters.AddWithValue("@Address2", hospital.Address2);
                    cmd.Parameters.AddWithValue("@Street", hospital.Street);
                    cmd.Parameters.AddWithValue("@PlacePO", hospital.PlacePO);
                    cmd.Parameters.AddWithValue("@Pin", hospital.PIN);
                    cmd.Parameters.AddWithValue("@City", hospital.City);
                    cmd.Parameters.AddWithValue("@State", hospital.State);
                    cmd.Parameters.AddWithValue("@Country", hospital.Country);
                    cmd.Parameters.AddWithValue("@Phone", hospital.Phone);
                    cmd.Parameters.AddWithValue("@Fax", hospital.Fax);
                    cmd.Parameters.AddWithValue("@EMail", hospital.Email);
                    cmd.Parameters.AddWithValue("@URL", hospital.URL);
                    cmd.Parameters.AddWithValue("@Logo", hospital.Logo);
                    cmd.Parameters.AddWithValue("@ReportLogo", hospital.ReportLogo);
                    cmd.Parameters.AddWithValue("@ClinicId", hospital.ClinicId);
                    cmd.Parameters.AddWithValue("@DhaFacilityId", hospital.DHAFacilityId);
                    cmd.Parameters.AddWithValue("@DhaUserName", hospital.DHAUserName);
                    cmd.Parameters.AddWithValue("@DhaPassword", hospital.DHAPassword);
                    cmd.Parameters.AddWithValue("@UserId", hospital.UserId);
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

        public string DeleteUserHospital(int Id)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteUserHospital", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", Id);

                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }

        //Hospital Ends
        //Operator Starts Now
        public string InsertOperator(OperatorModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                    cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                    cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string UpdateOperator(OperatorModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_UpdateOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Operator.Id);
                    cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                    cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                    cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public string DeleteOperator(int OperatorId)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteOperator", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", OperatorId);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }
        public List<OperatorModel> GetOperatorById(int OperatorId)
        {
            List<OperatorModel> stateList = new List<OperatorModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetOperatorById", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", OperatorId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            OperatorModel obj = new OperatorModel();
                            obj.Id = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Id"]);
                            obj.OperatorName = dsStateList.Tables[0].Rows[i]["OperatorName"].ToString();
                            obj.OperatorCode = dsStateList.Tables[0].Rows[i]["OperatorCode"].ToString();
                            obj.OperatorDescription = dsStateList.Tables[0].Rows[i]["OperatorDescription"].ToString();
                            stateList.Add(obj);
                        }
                    }
                    return stateList;
                }
            }
        }
        public List<OperatorModel> GetAllOperator()
        {
            List<OperatorModel> stateList = new List<OperatorModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetAllOperator", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsStateList = new DataSet();
                    adapter.Fill(dsStateList);
                    con.Close();
                    if ((dsStateList != null) && (dsStateList.Tables.Count > 0) && (dsStateList.Tables[0] != null) && (dsStateList.Tables[0].Rows.Count > 0))
                        for (int i = 0; i < dsStateList.Tables[0].Rows.Count; i++)
                        {
                            OperatorModel obj = new OperatorModel();
                            obj.Id = Convert.ToInt32(dsStateList.Tables[0].Rows[i]["Id"]);
                            obj.OperatorName = dsStateList.Tables[0].Rows[i]["OperatorName"].ToString();
                            obj.OperatorCode = dsStateList.Tables[0].Rows[i]["OperatorCode"].ToString();
                            obj.OperatorDescription = dsStateList.Tables[0].Rows[i]["OperatorDescription"].ToString();
                            stateList.Add(obj);
                        }
                    return stateList;
                }
            }
        }
        //Operator Ends Now

        public List<LeadAgentModel> GetLeadAgent(int la)
        {
            List<LeadAgentModel> itemList = new List<LeadAgentModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentId", la);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsNumber = new DataSet();
                    adapter.Fill(dsNumber);
                    con.Close();
                    if ((dsNumber != null) && (dsNumber.Tables.Count > 0) && (dsNumber.Tables[0] != null) && (dsNumber.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsNumber.Tables[0].Rows.Count; i++)
                        {
                            LeadAgentModel obj = new LeadAgentModel();
                            obj.LeadAgentId = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["LeadAgentId"]);
                            obj.Name = dsNumber.Tables[0].Rows[i]["Name"].ToString();
                            obj.ContactNo = dsNumber.Tables[0].Rows[i]["ContactNo"].ToString();
                            obj.CommisionPercent = (float)Convert.ToDouble(dsNumber.Tables[0].Rows[i]["CommisionPercent"].ToString());
                            obj.Active = Convert.ToInt32(dsNumber.Tables[0].Rows[i]["Active"]);
                            itemList.Add(obj);
                        }
                    }
                    return itemList;
                }
            }
        }

        public string InsertUpdateLeadAgent(LeadAgentModel Operator)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLeadAgent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentID", Operator.LeadAgentId);
                    cmd.Parameters.AddWithValue("@Name", Operator.Name);
                    cmd.Parameters.AddWithValue("@ContactNo", Operator.ContactNo);
                    cmd.Parameters.AddWithValue("@CommisionPercent", Operator.CommisionPercent);
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
        public string DeleteLeadAgent(int Id)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteLeadAgent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadAgentId", Id);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }


        public List<CompanyModel> GetCompany(int Id)
        {
            List<CompanyModel> companyList = new List<CompanyModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetCompany", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CmpId", Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsCompany = new DataSet();
                    adapter.Fill(dsCompany);
                    con.Close();
                    if ((dsCompany != null) && (dsCompany.Tables.Count > 0) && (dsCompany.Tables[0] != null) && (dsCompany.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsCompany.Tables[0].Rows.Count; i++)
                        {
                            CompanyModel obj = new CompanyModel();
                            obj.CmpId = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["CmpId"]);
                            obj.CmpName = dsCompany.Tables[0].Rows[i]["CmpName"].ToString();
                            obj.Active = Convert.ToInt32(dsCompany.Tables[0].Rows[i]["Active"]);
                            obj.BlockReason = dsCompany.Tables[0].Rows[i]["BlockReason"].ToString();
                            companyList.Add(obj);
                        }
                    }
                    return companyList;
                }
            }
        }

        public string InsertUpdateCompany(CompanyModel Company)  
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CmpId", Company.CmpId);
                    cmd.Parameters.AddWithValue("@CmpName", Company.CmpName);
                    cmd.Parameters.AddWithValue("@UserId", Company.UserId);
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
                    if (descrip == "Company saved")
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
        public string DeleteCompany(int Id)
        {
            string response = "";
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_DeleteCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                    response = "Success";
                }
            }
            return response;
        }

    }
}
