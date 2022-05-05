﻿using System;
using System.Collections.Generic;
using System.Text;

using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;
using Newtonsoft.Json;

namespace LeHealth.Core.DataManager
{
    public class MasterDataManager : IMasterDataManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public string InsertUpdateServiceItem(ServiceItemModel serviceItemModel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                //(float)Convert.ToDouble(dtProfession.Rows[i]["DedAmount"].ToString()),
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateItemMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
                cmd.Parameters.AddWithValue("@ItemCode", serviceItemModel.ItemCode);
                cmd.Parameters.AddWithValue("@ItemName", serviceItemModel.ItemName);
                cmd.Parameters.AddWithValue("@GroupId", serviceItemModel.GroupId);
                cmd.Parameters.AddWithValue("@ValidityDays", serviceItemModel.ValidityDays);
                cmd.Parameters.AddWithValue("@ValidityVisits", serviceItemModel.ValidityVisits);
                cmd.Parameters.AddWithValue("@AllowRateEdit", serviceItemModel.AllowRateEdit);
                cmd.Parameters.AddWithValue("@AllowDisc", serviceItemModel.AllowDisc);
                cmd.Parameters.AddWithValue("@AllowPP", serviceItemModel.AllowPP);
                cmd.Parameters.AddWithValue("@IsVSign", serviceItemModel.IsVSign);
                cmd.Parameters.AddWithValue("@ResultOn", serviceItemModel.ResultOn);
                cmd.Parameters.AddWithValue("@STypeId", serviceItemModel.STypeId);
                cmd.Parameters.AddWithValue("@TotalTaxPcnt", serviceItemModel.TotalTaxPcnt);
                cmd.Parameters.AddWithValue("@AllowCommission", serviceItemModel.AllowCommission);
                cmd.Parameters.AddWithValue("@CommPcnt", serviceItemModel.CommPcnt);
                cmd.Parameters.AddWithValue("@CommAmt", serviceItemModel.CommAmt);
                cmd.Parameters.AddWithValue("@MaterialCost", serviceItemModel.MaterialCost);
                cmd.Parameters.AddWithValue("@BaseCost", serviceItemModel.BaseCost);
                cmd.Parameters.AddWithValue("@HeadId", serviceItemModel.HeadId);
                cmd.Parameters.AddWithValue("@SortOrder", serviceItemModel.SortOrder);
                cmd.Parameters.AddWithValue("@Active", serviceItemModel.Active);
                cmd.Parameters.AddWithValue("@UserId", serviceItemModel.UserId);
                cmd.Parameters.AddWithValue("@SessionId", serviceItemModel.SessionId);
                cmd.Parameters.AddWithValue("@BranchId", serviceItemModel.BranchId);
                cmd.Parameters.AddWithValue("@ExternalItem", serviceItemModel.ExternalItem);
                cmd.Parameters.AddWithValue("@CPTCodeId", serviceItemModel.CPTCodeId);
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
        public string BlockUnblockServiceItem(ServiceItemModel serviceItemModel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_BlockUnblockServiceItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
                cmd.Parameters.AddWithValue("@BlockReason", serviceItemModel.BlockReason);
                cmd.Parameters.AddWithValue("@Active", serviceItemModel.Active);
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
                response = descrip;

            }
            return response;
        }

        public List<CPTCodeModel> GetCPTCode(CPTCodeModelAll ccm)
        {
            List<CPTCodeModel> profList = new List<CPTCodeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCPTCode", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPTCodeId", ccm.CPTCodeId);
            cmd.Parameters.AddWithValue("@ShowAll", ccm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtCPT = new DataTable();
            adapter.Fill(dtCPT);
            con.Close();
            if ((dtCPT != null) && (dtCPT.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtCPT.Rows.Count; i++)
                {
                    CPTCodeModel obj = new CPTCodeModel
                    {
                        CPTCodeId = Convert.ToInt32(dtCPT.Rows[i]["CPTCodeId"]),
                        CPTCode = dtCPT.Rows[i]["CPTCode"].ToString(),
                        CPTDesc = dtCPT.Rows[i]["CPTDesc"].ToString(),
                        BranchId = ccm.BranchId
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        public string InsertUpdateCPTCode(CPTCodeModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCPTCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CPTCodeId", ccm.CPTCodeId);
                cmd.Parameters.AddWithValue("@CPTCode", ccm.CPTCode);
                cmd.Parameters.AddWithValue("@CPTDesc", ccm.CPTDesc);
                cmd.Parameters.AddWithValue("@IsDisplayed", ccm.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
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
        public string DeleteCPTCode(CPTCodeModel ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCPTCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CPTCodeId", ccm.CPTCodeId);
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
                response = descrip;

            }
            return response;
        }
        public List<CPTModifierModel> GetCPTModifier(CPTModifierAll ccm)
        {
            List<CPTModifierModel> profList = new List<CPTModifierModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCPTModifier", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ccm.Id);
            cmd.Parameters.AddWithValue("@ShowAll", ccm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtCPT = new DataTable();
            adapter.Fill(dtCPT);
            con.Close();
            if ((dtCPT != null) && (dtCPT.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtCPT.Rows.Count; i++)
                {
                    CPTModifierModel obj = new CPTModifierModel
                    {
                        Id = Convert.ToInt32(dtCPT.Rows[i]["Id"]),
                        CPTModifier = dtCPT.Rows[i]["CPTModifier"].ToString()
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        public string InsertUpdateCPTModifier(CPTModifierAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCPTModifier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ccm.Id);
                cmd.Parameters.AddWithValue("@CPTModifier", ccm.CPTModifier);
                cmd.Parameters.AddWithValue("@IsDisplayed", ccm.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
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
        public string DeleteCPTModifier(CPTModifierAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCPTModifier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ccm.Id);
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
                response = descrip;

            }
            return response;
        }

        //Rate group Starts
        /// <summary>
        /// Get Rate group data. if rategroup is zero then lists all rategroups, else returns specific rategroup
        /// </summary>
        /// <param name="RateGroupId"></param>
        /// <returns>Rategroup list</returns>
        public List<RateGroupModel> GetRateGroup(RateGroupModelAll rm)
        {
            List<RateGroupModel> stateList = new List<RateGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetRateGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RGroupId", rm.RGroupId);
            cmd.Parameters.AddWithValue("@ShowAll", rm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtRateGroupList = new DataTable();
            adapter.Fill(dtRateGroupList);
            con.Close();
            if ((dtRateGroupList != null) && (dtRateGroupList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtRateGroupList.Rows.Count; i++)
                {
                    RateGroupModel obj = new RateGroupModel
                    {
                        RGroupId = Convert.ToInt32(dtRateGroupList.Rows[i]["RGroupId"]),
                        RGroupName = dtRateGroupList.Rows[i]["RGroupName"].ToString(),
                        Description = dtRateGroupList.Rows[i]["Description"].ToString(),
                        EffectFrom = dtRateGroupList.Rows[i]["EffectFrom"].ToString(),
                        EffectTo = dtRateGroupList.Rows[i]["EffectTo"].ToString(),
                        BranchId = rm.BranchId
                    };
                    stateList.Add(obj);
                }
            }
            return stateList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateGroup"></param>
        /// <returns></returns>
        public string InsertUpdateRateGroup(RateGroupModelAll RateGroup)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime EffectFrom = DateTime.ParseExact(RateGroup.EffectFrom.Trim(), "dd-MM-yyyy", null);
                RateGroup.EffectFrom = EffectFrom.ToString("yyyy-MM-dd");
                DateTime EffectTo = DateTime.ParseExact(RateGroup.EffectTo.Trim(), "dd-MM-yyyy", null);
                RateGroup.EffectTo = EffectTo.ToString("yyyy-MM-dd");

                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRateGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                cmd.Parameters.AddWithValue("@EffectFrom", RateGroup.EffectFrom);
                cmd.Parameters.AddWithValue("@EffectTo", RateGroup.EffectTo);
                cmd.Parameters.AddWithValue("@IsDisplayed", RateGroup.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", RateGroup.BranchId);
                cmd.Parameters.AddWithValue("@UserId", RateGroup.UserId);
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
        public string DeleteRateGroup(RateGroupModel rm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteRateGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RGroupId", rm.RGroupId);
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
                response = descrip;

            }
            return response;
        }
        //Rate Group Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<PackageModel> GetPackage(PackageModelAll pm)
        {
            List<PackageModel> itemList = new List<PackageModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPackage", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PackId", pm.PackId);
            cmd.Parameters.AddWithValue("@ShowAll", pm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", pm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    PackageModel obj = new PackageModel
                    {
                        PackId = Convert.ToInt32(dsNumber.Rows[i]["PackId"]),
                        PackDesc = dsNumber.Rows[i]["PackDesc"].ToString(),
                        EffectFrom = dsNumber.Rows[i]["EffectFrom"].ToString(),
                        EffectTo = dsNumber.Rows[i]["EffectTo"].ToString(),
                        PackAmount = (float)Convert.ToDouble(dsNumber.Rows[i]["PackAmount"].ToString()),
                        Remarks = dsNumber.Rows[i]["Remarks"].ToString(),
                        BranchId = pm.BranchId
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdatePackage(PackageModelAll Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                DateTime packFrom = DateTime.ParseExact(Package.EffectFrom.Trim(), "dd-MM-yyyy", null);
                Package.EffectFrom = packFrom.ToString("yyyy-MM-dd");
                DateTime packTo = DateTime.ParseExact(Package.EffectTo.Trim(), "dd-MM-yyyy", null);
                Package.EffectTo = packTo.ToString("yyyy-MM-dd");

                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePackage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PackId", Package.PackId);
                cmd.Parameters.AddWithValue("@PackDesc", Package.PackDesc);
                cmd.Parameters.AddWithValue("@EffectFrom", Package.EffectFrom);
                cmd.Parameters.AddWithValue("@EffectTo", Package.EffectTo);
                cmd.Parameters.AddWithValue("@PackAmount", Package.PackAmount);
                cmd.Parameters.AddWithValue("@Remarks", Package.Remarks);
                cmd.Parameters.AddWithValue("@IsDisplayed", Package.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", Package.BranchId);
                cmd.Parameters.AddWithValue("@UserId", Package.UserId);
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
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string DeletePackage(PackageModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeletePackage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PackId", Package.PackId);
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
        /// Get department list from database,Step three in code execution flow
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartment(DepartmentModelAll department)
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptId", department.DeptId);
            cmd.Parameters.AddWithValue("@ShowAll", department.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", department.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    DepartmentModel obj = new DepartmentModel
                    {
                        DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                        DeptName = dt.Rows[i]["DeptName"].ToString(),
                        DeptCode = dt.Rows[i]["DeptCode"].ToString(),
                        Description = dt.Rows[i]["Description"].ToString(),
                        BranchId = department.BranchId,
                        TimeSlice = Convert.ToInt32(dt.Rows[i]["TimeSlice"]),
                    };
                    departmentlist.Add(obj);
                }
            }
            return departmentlist;
        }
        /// <summary>
        /// Save and updating Department master data,Saves when DeptId is zero. Updates when DeptId Not equal to zero
        /// </summary>
        /// <param name="department"></param>
        /// <returns>success or reason for failure</returns>
        public string InsertUpdateDepartment(DepartmentModelAll department)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeptId", department.DeptId);
                cmd.Parameters.AddWithValue("@DeptName", department.DeptName);
                cmd.Parameters.AddWithValue("@DeptCode", department.DeptCode);
                cmd.Parameters.AddWithValue("@Description", department.Description);
                cmd.Parameters.AddWithValue("@TimeSlice", department.TimeSlice);
                cmd.Parameters.AddWithValue("@IsDisplayed", department.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", department.BranchId);
                cmd.Parameters.AddWithValue("@UserId", department.UserId);
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
        /// Save and updating Department master data,Saves when DeptId is zero. Updates when DeptId Not equal to zero
        /// </summary>
        /// <param name="department"></param>
        /// <returns>success or reason for failure</returns>
        public string DeleteDepartment(DepartmentModel department)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeptId", department.DeptId);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SymptomModel> GetSymptom(SymptomModelAll symptom)
        {
            List<SymptomModel> stateList = new List<SymptomModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSymptom", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SymptomId", symptom.SymptomId);
            cmd.Parameters.AddWithValue("@ShowAll", symptom.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", symptom.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsSymptomList = new DataTable();
            adapter.Fill(dsSymptomList);
            con.Close();
            if ((dsSymptomList != null) && (dsSymptomList.Rows.Count > 0))
                stateList = dsSymptomList.ToListOfObject<SymptomModel>();
            return stateList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Symptom"></param>
        /// <returns></returns>
        public string InsertUpdateSymptom(SymptomModelAll Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSymptom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SymptomId", Symptom.SymptomId);
                cmd.Parameters.AddWithValue("@SymptomDesc", Symptom.SymptomDesc);
                cmd.Parameters.AddWithValue("@IsDisplayed", Symptom.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", Symptom.BranchId);
                cmd.Parameters.AddWithValue("@UserId", Symptom.UserId);
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
        public string DeleteSymptom(SymptomModel Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSymptom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SymptomId", Symptom.SymptomId);
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
                response = descrip;
            }
            return response;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<LocationModel> GetLocation(LocationAll la)
        {
            List<LocationModel> itemList = new List<LocationModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLocation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationId", la.LocationId);
            cmd.Parameters.AddWithValue("@ShowAll", la.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", la.HospitalId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    LocationModel obj = new LocationModel
                    {
                        LocationId = Convert.ToInt32(dsNumber.Rows[i]["LocationId"]),
                        LocationName = dsNumber.Rows[i]["LocationName"].ToString(),
                        Supervisor = dsNumber.Rows[i]["Supervisor"].ToString(),
                        ContactNumber = dsNumber.Rows[i]["ContactNumber"].ToString(),
                        LTypeId = Convert.ToInt32(dsNumber.Rows[i]["LTypeId"]),
                        ManageSPoints = Convert.ToBoolean(dsNumber.Rows[i]["ManageSPoints"]),
                        ManageBilling = Convert.ToBoolean(dsNumber.Rows[i]["ManageBilling"]),
                        ManageCash = Convert.ToBoolean(dsNumber.Rows[i]["ManageCash"]),
                        ManageCredit = Convert.ToBoolean(dsNumber.Rows[i]["ManageCredit"]),
                        ManageIPCredit = Convert.ToBoolean(dsNumber.Rows[i]["ManageIPCredit"]),
                        RepHeadImg = dsNumber.Rows[i]["RepHeadImg"].ToString(),
                        HospitalId = la.HospitalId,
                        HospitalName = dsNumber.Rows[i]["HospitalName"].ToString(),
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateLocation(LocationAll location)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", location.LocationId);
                cmd.Parameters.AddWithValue("@LocationName", location.LocationName);
                cmd.Parameters.AddWithValue("@Supervisor", location.Supervisor);
                cmd.Parameters.AddWithValue("@ContactNumber", location.ContactNumber);
                cmd.Parameters.AddWithValue("@LTypeId", location.LTypeId);
                cmd.Parameters.AddWithValue("@ManageSPoints", location.ManageSPoints);
                cmd.Parameters.AddWithValue("@ManageBilling", location.ManageBilling);
                cmd.Parameters.AddWithValue("@ManageCash", location.ManageCash);
                cmd.Parameters.AddWithValue("@ManageCredit", location.ManageCredit);
                cmd.Parameters.AddWithValue("@ManageIPCredit", location.ManageIPCredit);
                cmd.Parameters.AddWithValue("@RepHeadImg", location.RepHeadImg);
                cmd.Parameters.AddWithValue("@UserId", location.UserId);
                cmd.Parameters.AddWithValue("@HospitalId", location.HospitalId);
                cmd.Parameters.AddWithValue("@IsDisplayed", location.IsDisplayed);
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
        public string DeleteLocation(LocationModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", Package.LocationId);
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
                response = descrip;
            }
            return response;
        }
        public List<CountryModel> GetCountry(CountryModel country)
        {
            List<CountryModel> countryList = new List<CountryModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCountry", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
            cmd.Parameters.AddWithValue("@ShowAll", country.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", country.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dscontryList = new DataTable();
            adapter.Fill(dscontryList);
            con.Close();
            if ((dscontryList != null) && (dscontryList.Rows.Count > 0))
                countryList = dscontryList.ToListOfObject<CountryModel>();
            return countryList;
        }
        public string InsertUpdateCountry(CountryModel country)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
                cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                cmd.Parameters.AddWithValue("@NGroupId", country.NGroupId);
                cmd.Parameters.AddWithValue("@NationalityName", country.NationalityName);
                cmd.Parameters.AddWithValue("@IsDisplayed", country.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", country.BranchId);
                cmd.Parameters.AddWithValue("@UserId", country.UserId);
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
        public string DeleteCountry(CountryModel country)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
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
        public List<StateModel> GetState(StateModel state)
        {
            List<StateModel> countryList = new List<StateModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetState", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", state.StateId);
            cmd.Parameters.AddWithValue("@ShowAll", state.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", state.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
                countryList = dtStateList.ToListOfObject<StateModel>();
            return countryList;
        }
        public string InsertUpdateState(StateModel state)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", state.StateId);
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
                cmd.Parameters.AddWithValue("@IsDisplayed", state.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", state.BranchId);
                cmd.Parameters.AddWithValue("@UserId", state.UserId);
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
        public string DeleteState(StateModel state)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", state.StateId);
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
        /// Get details of companies. if Id is zero then returns all company data. else returns Data of specific company
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<CompanyModel> GetCompany(CompanyModelAll company)
        {
            List<CompanyModel> companyList = new List<CompanyModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCompany", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CmpId", company.CmpId);
            cmd.Parameters.AddWithValue("@ShowAll", company.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", company.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsCompany = new DataTable();
            adapter.Fill(dsCompany);
            con.Close();
            if ((dsCompany != null) && (dsCompany.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsCompany.Rows.Count; i++)
                {
                    CompanyModel obj = new CompanyModel
                    {
                        CmpId = Convert.ToInt32(dsCompany.Rows[i]["CmpId"]),
                        CmpName = dsCompany.Rows[i]["CmpName"].ToString()
                    };
                    companyList.Add(obj);
                }
            }
            return companyList;
        }
        /// <summary>
        /// Save Comapny data if cmpid is zero. else updating specific company
        /// </summary>
        /// <param name="Company"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateCompany(CompanyModelAll Company)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CmpId", Company.CmpId);
                cmd.Parameters.AddWithValue("@CmpName", Company.CmpName);
                cmd.Parameters.AddWithValue("@IsDisplayed", Company.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", Company.BranchId);
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
            return response;
        }
        public string DeleteCompany(CompanyModel Company)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Company.CmpId);
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
            return response;
        }
        /// <summary>
        /// Get proffession list. if profid is zero then returns all professions. if profid is not zero then 
        /// returns specific profession details
        /// </summary>
        /// <param name="profid"></param>
        /// <returns>Profession details list</returns>


        public List<ProfessionModel> GetProfession(ProfessionModelAll prof)
        {
            List<ProfessionModel> profList = new List<ProfessionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetProfession", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProfId", prof.ProfId);
            cmd.Parameters.AddWithValue("@ShowAll", prof.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", prof.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    ProfessionModel obj = new ProfessionModel
                    {
                        ProfId = Convert.ToInt32(dtProfession.Rows[i]["ProfId"]),
                        ProfName = dtProfession.Rows[i]["ProfName"].ToString(),
                        ProfCode = dtProfession.Rows[i]["ProfCode"].ToString(),
                        ProfGroup = Convert.ToInt32(dtProfession.Rows[i]["ProfGroup"])
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        /// <summary>
        /// Save and updating profession data. if profession.ProfId is zero then saving the proffession details,
        /// else updates specific proffession
        /// </summary>
        /// <param name="profession"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateProfession(ProfessionModelAll prof)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateProfession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfId", prof.ProfId);
                cmd.Parameters.AddWithValue("@ProfName", prof.ProfName);
                cmd.Parameters.AddWithValue("@ProfCode", prof.ProfCode);
                cmd.Parameters.AddWithValue("@ProfGroup", prof.ProfGroup);
                cmd.Parameters.AddWithValue("@IsDisplayed", prof.IsDisplayed);
                cmd.Parameters.AddWithValue("@UserId", prof.UserId);
                cmd.Parameters.AddWithValue("@BranchId", prof.BranchId);
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
        public string DeleteProfession(ProfessionModel profession)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteProfession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", profession.ProfId);
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
                response = descrip;
            }
            return response;
        }
        /// <summary>
        /// Get city details. returns all city data if cityid is zero else returns specific city data
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns>city data list</returns>
        public List<CityModel> GetCity(CityModelAll city)
        {
            List<CityModel> cityList = new List<CityModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCity", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", city.CityId);
            cmd.Parameters.AddWithValue("@ShowAll", city.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", city.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsCity = new DataTable();
            adapter.Fill(dsCity);
            con.Close();
            if ((dsCity != null) && (dsCity.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsCity.Rows.Count; i++)
                {
                    CityModel obj = new CityModel
                    {
                        CityId = Convert.ToInt32(dsCity.Rows[i]["CityId"]),
                        CityName = dsCity.Rows[i]["CityName"].ToString(),
                        StateId = Convert.ToInt32(dsCity.Rows[i]["StateId"]),
                        CountryId = Convert.ToInt32(dsCity.Rows[i]["CountryId"]),
                        CountryName = dsCity.Rows[i]["CountryName"].ToString()
                    };
                    cityList.Add(obj);
                }
            }
            return cityList;
        }
        /// <summary>
        /// Save city data if cityid is zero. else updating specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public string InsertUpdateCity(CityModelAll city)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityId", city.CityId);
                cmd.Parameters.AddWithValue("@CityName", city.CityName);
                cmd.Parameters.AddWithValue("@CountryId", city.CountryId);
                cmd.Parameters.AddWithValue("@StateId", city.StateId);
                cmd.Parameters.AddWithValue("@UserId", city.UserId);
                cmd.Parameters.AddWithValue("@BranchId", city.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", city.IsDisplayed);
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
        public string DeleteCity(CityModel city)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", city.CityId);
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

        public List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign)
        {
            List<VitalSignModel> vitalSignList = new List<VitalSignModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVitalSign", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SignId", vitalsign.SignId);
            cmd.Parameters.AddWithValue("@ShowAll", vitalsign.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", vitalsign.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsVitalSignList = new DataTable();
            adapter.Fill(dsVitalSignList);
            con.Close();
            if ((dsVitalSignList != null) && (dsVitalSignList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsVitalSignList.Rows.Count; i++)
                {
                    VitalSignModel obj = new VitalSignModel
                    {
                        SignId = Convert.ToInt32(dsVitalSignList.Rows[i]["SignId"]),
                        SignName = dsVitalSignList.Rows[i]["SignName"].ToString(),
                        Mandatory = dsVitalSignList.Rows[i]["Mandatory"].ToString(),
                        SignCode = dsVitalSignList.Rows[i]["SignCode"].ToString(),
                        SignUnit = dsVitalSignList.Rows[i]["SignUnit"].ToString(),
                        MinValue = Convert.ToDouble(dsVitalSignList.Rows[i]["MinValue"]),
                        MaxValue = Convert.ToDouble(dsVitalSignList.Rows[i]["MaxValue"]),
                        SortOrder = Convert.ToInt32(dsVitalSignList.Rows[i]["SortOrder"])
                    };
                    vitalSignList.Add(obj);
                }
            }
            return vitalSignList;
        }
        public string InsertUpdateVitalSign(VitalSignModelAll vitalsign)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateVitalSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", vitalsign.SignId);
                cmd.Parameters.AddWithValue("@SignName", vitalsign.SignName);
                cmd.Parameters.AddWithValue("@Mandatory", vitalsign.Mandatory);
                cmd.Parameters.AddWithValue("@SignCode", vitalsign.SignCode);
                cmd.Parameters.AddWithValue("@SignUnit", vitalsign.SignUnit);
                cmd.Parameters.AddWithValue("@MinValue", vitalsign.MinValue);
                cmd.Parameters.AddWithValue("@MaxValue", vitalsign.MaxValue);
                cmd.Parameters.AddWithValue("@SortOrder", vitalsign.SortOrder);
                cmd.Parameters.AddWithValue("@BranchId", vitalsign.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", vitalsign.IsDisplayed);
                cmd.Parameters.AddWithValue("@UserId", vitalsign.UserId);
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
        public string DeleteVitalSign(VitalSignModelAll vitalsign)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteVitalSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", vitalsign.SignId);
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

        public List<LedgerHeadModel> GetLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            List<LedgerHeadModel> ledgerHeadList = new List<LedgerHeadModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLedger", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HeadId", ledgerHead.HeadId);
            cmd.Parameters.AddWithValue("@ShowAll", ledgerHead.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", ledgerHead.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsLedgerHeadList = new DataTable();
            adapter.Fill(dsLedgerHeadList);
            con.Close();
            if ((dsLedgerHeadList != null) && (dsLedgerHeadList.Rows.Count > 0))
                ledgerHeadList = dsLedgerHeadList.ToListOfObject<LedgerHeadModel>();
            return ledgerHeadList;
        }
        public string InsertUpdateLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLedgerHead", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HeadId", ledgerHead.HeadId);
                cmd.Parameters.AddWithValue("@HeadDesc", ledgerHead.HeadDesc);
                cmd.Parameters.AddWithValue("@HeadType", ledgerHead.HeadType);
                cmd.Parameters.AddWithValue("@State", ledgerHead.State);
                cmd.Parameters.AddWithValue("@UserId", ledgerHead.UserId);
                cmd.Parameters.AddWithValue("@BranchId", ledgerHead.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", ledgerHead.IsDisplayed);
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
        public string DeleteLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteLedgerHead", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HeadId", ledgerHead.HeadId);
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
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutationDetails"></param>
        /// <returns></returns>
        public List<BodyPartModelReturn> GetBodyPart(BodyPartModel salutationDetails)
        {
            List<BodyPartModelReturn> bodypartList = new List<BodyPartModelReturn>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetBodyPart", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BodyId", salutationDetails.BodyId);
            cmd.Parameters.AddWithValue("@ShowAll", salutationDetails.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", salutationDetails.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbodypartList = new DataTable();
            adapter.Fill(dtbodypartList);
            con.Close();
            if ((dtbodypartList != null) && (dtbodypartList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtbodypartList.Rows.Count; i++)
                {
                    string imgloc = dtbodypartList.Rows[i]["BodyPartImageLocation"].ToString();
                    BodyPartModelReturn obj = new BodyPartModelReturn()
                    {
                        BodyId = Convert.ToInt32(dtbodypartList.Rows[i]["BodyId"]),
                        BodyDesc = dtbodypartList.Rows[i]["BodyDesc"].ToString(),
                        BodyPartImageLocation = imgloc != "" ? _uploadpath + imgloc : imgloc,
                    };
                    bodypartList.Add(obj);
                }
            }
            return bodypartList;
        }
        /// <summary>
        /// Save and updating Bodypart master data,Saves when BodyId is zero. Updates when Body Id Not equal to zero
        /// </summary>
        /// <param name="bodypart"></param>
        /// <returns>success or error statement</returns>
        public string InsertUpdateBodyPart(BodyPartRegModel bodypart)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateBodyPart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyId", bodypart.BodyId);
                cmd.Parameters.AddWithValue("@BodyDesc", bodypart.BodyDesc);
                cmd.Parameters.AddWithValue("@ImageLocation", bodypart.BodyPartImageLocation);
                cmd.Parameters.AddWithValue("@UserId", bodypart.UserId);
                cmd.Parameters.AddWithValue("@BranchId", bodypart.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", bodypart.IsDisplayed);
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
        public string DeleteBodyPart(BodyPartModel bodypart)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteBodyPart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyId", bodypart.BodyId);
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

                response = descrip;

            }
            return response;
        }
        public List<SketchIndicatorModel> GetSketchIndicators(SketchIndicatorModelAll sketch)
        {
            List<SketchIndicatorModel> sketchIndicators = new List<SketchIndicatorModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSketchIndicators", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IndicatorId", sketch.IndicatorId);
            cmd.Parameters.AddWithValue("@ShowAll", sketch.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sketch.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtSketchIndicatorsList = new DataTable();
            adapter.Fill(dtSketchIndicatorsList);
            con.Close();
            if ((dtSketchIndicatorsList != null) && (dtSketchIndicatorsList.Rows.Count > 0))
                for (Int32 i = 0; i < dtSketchIndicatorsList.Rows.Count; i++)
                {
                    string imgloc = dtSketchIndicatorsList.Rows[i]["ImageLocation"].ToString();
                    SketchIndicatorModel obj = new SketchIndicatorModel
                    {
                        IndicatorId = Convert.ToInt32(dtSketchIndicatorsList.Rows[i]["IndicatorId"]),
                        IndicatorDesc = dtSketchIndicatorsList.Rows[i]["IndicatorDesc"].ToString(),
                        ImageUrl = imgloc != "" ? _uploadpath + imgloc : imgloc,
                    };
                    sketchIndicators.Add(obj);
                }

            return sketchIndicators;
        }
        public string InsertUpdateSketchIndicator(SketchIndicatorRegModel sketch)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSketchIndicator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IndicatorId", sketch.IndicatorId);
                cmd.Parameters.AddWithValue("@IndicatorDesc", sketch.IndicatorDesc);
                cmd.Parameters.AddWithValue("@ImageLocation", sketch.ImageUrl);
                cmd.Parameters.AddWithValue("@BranchId", sketch.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", sketch.IsDisplayed);
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
        public string DeleteSketchIndicator(SketchIndicatorModelAll sketch)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSketchIndicator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IndicatorId", sketch.IndicatorId);
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
                response = descrip;
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutationDetails"></param>
        /// <returns></returns>
        public List<SalutationModel> GetSalutation(SalutationModelAll salutationDetails)
        {
            List<SalutationModel> salutationList = new List<SalutationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSalutation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SalutationId", salutationDetails.Id);
            cmd.Parameters.AddWithValue("@ShowAll", salutationDetails.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", salutationDetails.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtsalutationList = new DataTable();
            adapter.Fill(dtsalutationList);
            con.Close();
            if ((dtsalutationList != null) && (dtsalutationList.Rows.Count > 0))
                salutationList = dtsalutationList.ToListOfObject<SalutationModel>();
            return salutationList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutation"></param>
        /// <returns></returns>
        public string InsertUpdateSalutation(SalutationModelAll salutation)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSalutation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalutationId", salutation.Id);
                cmd.Parameters.AddWithValue("@Salutation", salutation.Salutation);
                cmd.Parameters.AddWithValue("@UserId", salutation.UserId);
                cmd.Parameters.AddWithValue("@BranchId", salutation.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", salutation.IsDisplayed);
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
        public string DeleteSalutation(SalutationModelAll salutation)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSalutation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalutationId", salutation.Id);
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
                response = descrip;

            }
            return response;
        }
        public List<MaritalStatusModel> GetMaritalStatus(MaritalStatusModelAll maritalstatus)
        {
            List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMaritalStatus", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", maritalstatus.Id);
            cmd.Parameters.AddWithValue("@ShowAll", maritalstatus.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", maritalstatus.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsmaritalStatus = new DataTable();
            adapter.Fill(dsmaritalStatus);
            con.Close();
            if ((dsmaritalStatus != null) && (dsmaritalStatus.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsmaritalStatus.Rows.Count; i++)
                {
                    MaritalStatusModel obj = new MaritalStatusModel
                    {
                        Id = Convert.ToInt32(dsmaritalStatus.Rows[i]["Id"]),
                        MaritalStatusDescription = dsmaritalStatus.Rows[i]["MaritalStatusDescription"].ToString()
                    };
                    maritalStatusList.Add(obj);
                }
            }
            return maritalStatusList;
        }
        public string InsertUpdateMaritalStatus(MaritalStatusModelAll maritalStatus)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMaritalStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", maritalStatus.Id);
                cmd.Parameters.AddWithValue("@MaritalStatus", maritalStatus.MaritalStatusDescription);
                cmd.Parameters.AddWithValue("@BranchId", maritalStatus.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", maritalStatus.IsDisplayed);
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
        public string DeleteMaritalStatus(MaritalStatusModelAll maritalstatus)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteMaritalStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", maritalstatus.Id);
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
                response = descrip;

            }
            return response;
        }
        public List<CommunicationTypeModel> GetCommunicationType(CommunicationTypeModelAll ctype)
        {
            List<CommunicationTypeModel> communicationTypeList = new List<CommunicationTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCommunicationType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ctype.Id);
            cmd.Parameters.AddWithValue("@ShowAll", ctype.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", ctype.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dscommunicationType = new DataTable();
            adapter.Fill(dscommunicationType);
            con.Close();
            if ((dscommunicationType != null) && (dscommunicationType.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dscommunicationType.Rows.Count; i++)
                {
                    CommunicationTypeModel obj = new CommunicationTypeModel
                    {
                        Id = Convert.ToInt32(dscommunicationType.Rows[i]["Id"]),
                        CommunicationType = dscommunicationType.Rows[i]["CommunicationType"].ToString()
                    };
                    communicationTypeList.Add(obj);
                }
            }
            return communicationTypeList;
        }
        public string InsertUpdateCommunicationType(CommunicationTypeModelAll ctype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCommunicationType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ctype.Id);
                cmd.Parameters.AddWithValue("@CommunicationType", ctype.CommunicationType);
                cmd.Parameters.AddWithValue("@BranchId", ctype.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", ctype.IsDisplayed);
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
        public string DeleteCommunicationType(CommunicationTypeModelAll ctype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCommunicationType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ctype.Id);
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
                response = descrip;
            }
            return response;
        }
        public List<VisaTypeModel> GetVisaType(VisaTypeModelAll visatype)
        {
            List<VisaTypeModel> visatypeList = new List<VisaTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVisaType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisaTypeID", visatype.VisaTypeID);
            cmd.Parameters.AddWithValue("@ShowAll", visatype.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", visatype.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtVisaTypeList = new DataTable();
            adapter.Fill(dtVisaTypeList);
            con.Close();
            if ((dtVisaTypeList != null) && (dtVisaTypeList.Rows.Count > 0))
                visatypeList = dtVisaTypeList.ToListOfObject<VisaTypeModel>();
            return visatypeList;
        }
        public string InsertUpdateVisaType(VisaTypeModelAll visatype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateVisaType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", visatype.VisaTypeID);
                cmd.Parameters.AddWithValue("@VisaType", visatype.VisaType);
                cmd.Parameters.AddWithValue("@BranchId", visatype.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", visatype.IsDisplayed);
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
        public string DeleteVisaType(VisaTypeModelAll visatype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteVisaType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", visatype.VisaTypeID);
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
                response = descrip;

            }
            return response;
        }
        public List<ReligionModel> GetReligion(ReligionModelAll religion)
        {
            List<ReligionModel> religionList = new List<ReligionModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetReligion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", religion.ID);
            cmd.Parameters.AddWithValue("@ShowAll", religion.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", religion.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsReligionList = new DataTable();
            adapter.Fill(dsReligionList);
            con.Close();
            if ((dsReligionList != null) && (dsReligionList.Rows.Count > 0))
                religionList = dsReligionList.ToListOfObject<ReligionModel>();
            return religionList;
        }
        public string InsertUpdateReligion(ReligionModelAll religion)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMaritalStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", religion.Id);
                //cmd.Parameters.AddWithValue("@MaritalStatus", maritalStatus.MaritalStatusDescription);
                //cmd.Parameters.AddWithValue("@BranchId", maritalStatus.BranchId);
                //cmd.Parameters.AddWithValue("@IsDisplayed", maritalStatus.IsDisplayed);
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
        public string DeleteReligion(ReligionModelAll religion)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteMaritalStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", religion.Id);
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
                response = descrip;

            }
            return response;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel consultant)
        {
            List<ConsultantMasterModel> consultantList = new List<ConsultantMasterModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultant", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", consultant.ConsultantId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsConsultant = new DataTable();
            adapter.Fill(dsConsultant);
            con.Close();
            if ((dsConsultant != null) && (dsConsultant.Rows.Count > 0))
                for (Int32 i = 0; i < dsConsultant.Rows.Count; i++)
                {
                    ConsultantMasterModel obj = new ConsultantMasterModel();
                    obj.ConsultantId = Convert.ToInt32(dsConsultant.Rows[i]["ConsultantId"]);
                    obj.DeptId = Convert.ToInt32(dsConsultant.Rows[i]["DeptId"]);
                    obj.ConsultantCode = dsConsultant.Rows[i]["ConsultantCode"].ToString();
                    obj.Title = dsConsultant.Rows[i]["Title"].ToString();
                    obj.FirstName = dsConsultant.Rows[i]["FirstName"].ToString();
                    obj.MiddleName = dsConsultant.Rows[i]["MiddleName"].ToString();
                    obj.LastName = dsConsultant.Rows[i]["LastName"].ToString();
                    obj.Gender = dsConsultant.Rows[i]["Gender"].ToString();
                    string dobstr = dsConsultant.Rows[i]["DOB"].ToString().Replace("/", "-");
                    DateTime dobdatetime = DateTime.ParseExact(dobstr, "dd-MM-yyyy", null);
                    obj.DOB = dobdatetime;
                    obj.Age = Convert.ToInt32(dsConsultant.Rows[i]["Age"]);
                    obj.Specialisation = dsConsultant.Rows[i]["Specialisation"].ToString();
                    obj.Designation = dsConsultant.Rows[i]["Designation"].ToString();
                    obj.Qualification = dsConsultant.Rows[i]["Qualification"].ToString();
                    obj.NationalityId = Convert.ToInt32(dsConsultant.Rows[i]["NationalityId"]);
                    obj.Mobile = dsConsultant.Rows[i]["Mobile"].ToString();
                    obj.ResPhone = dsConsultant.Rows[i]["ResPhone"].ToString();
                    obj.OffPhone = dsConsultant.Rows[i]["OffPhone"].ToString();
                    obj.Email = dsConsultant.Rows[i]["Email"].ToString();
                    obj.Fax = dsConsultant.Rows[i]["Fax"].ToString();
                    string dojstr = dsConsultant.Rows[i]["DOJ"].ToString().Replace("/", "-");
                    DateTime dojdatetime = DateTime.ParseExact(dobstr, "dd-MM-yyyy", null);
                    obj.DOB = dojdatetime;
                    obj.CRegNo = dsConsultant.Rows[i]["CRegNo"].ToString();
                    obj.TimeSlice = Convert.ToInt32(dsConsultant.Rows[i]["TimeSlice"]);
                    obj.AppType = Convert.ToInt32(dsConsultant.Rows[i]["AppType"]);
                    obj.MaxPatients = Convert.ToInt32(dsConsultant.Rows[i]["MaxPatients"]);
                    obj.ItemId = Convert.ToInt32(dsConsultant.Rows[i]["ItemId"]);
                    obj.RoomNo = dsConsultant.Rows[i]["RoomNo"].ToString();
                    obj.SignatureLoc = dsConsultant.Rows[i]["SignatureLoc"].ToString();
                    obj.ConsultantLedger = Convert.ToInt32(dsConsultant.Rows[i]["ConsultantLedger"]);
                    obj.CommissionId = Convert.ToInt32(dsConsultant.Rows[i]["CommissionId"]);
                    obj.SortOrder = Convert.ToInt32(dsConsultant.Rows[i]["SortOrder"]);
                    obj.SpecialityCode = dsConsultant.Rows[i]["SpecialityCode"].ToString();
                    obj.AllowCommission = Convert.ToBoolean(dsConsultant.Rows[i]["AllowCommission"]);
                    obj.DeptOverrule = Convert.ToBoolean(dsConsultant.Rows[i]["DeptOverrule"].ToString());
                    obj.DeptWiseConsultation = Convert.ToBoolean(dsConsultant.Rows[i]["DeptWiseConsultation"].ToString());
                    obj.ExternalConsultant = Convert.ToBoolean(dsConsultant.Rows[i]["ExternalConsultant"].ToString());
                    consultantList.Add(obj);
                }
            return consultantList;
        }
        public string DeleteConsultant(ConsultantMasterModel consultant)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultant", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", consultant);
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
        public List<RegSchemeModel> GetRegScheme(RegSchemeModelAll RegScheme)
        {
            List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_RegSchemeById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemId", RegScheme.ItemId);
            cmd.Parameters.AddWithValue("@ShowAll", RegScheme.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", RegScheme.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtRegSchemeList = new DataTable();
            adapter.Fill(dtRegSchemeList);
            con.Close();
            if ((dtRegSchemeList != null) && (dtRegSchemeList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtRegSchemeList.Rows.Count; i++)
                {
                    RegSchemeModel obj = new RegSchemeModel
                    {
                        ItemId = Convert.ToInt32(dtRegSchemeList.Rows[i]["ItemId"]),
                        ItemCode = dtRegSchemeList.Rows[i]["ItemCode"].ToString(),
                        ItemName = dtRegSchemeList.Rows[i]["ItemName"].ToString(),
                        GroupId = Convert.ToInt32(dtRegSchemeList.Rows[i]["GroupId"]),
                        ValidityDays = Convert.ToInt32(dtRegSchemeList.Rows[i]["ValidityDays"]),
                        ValidityVisits = Convert.ToInt32(dtRegSchemeList.Rows[i]["ValidityVisits"]),
                        AllowRateEdit = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowRateEdit"]),
                        AllowDisc = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowDisc"]),
                        AllowPP = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowPP"]),
                        IsVSign = Convert.ToInt32(dtRegSchemeList.Rows[i]["IsVSign"]),
                        ResultOn = Convert.ToInt32(dtRegSchemeList.Rows[i]["ResultOn"]),
                        STypeId = Convert.ToInt32(dtRegSchemeList.Rows[i]["STypeId"]),
                        TotalTaxPcnt = Convert.ToInt32(dtRegSchemeList.Rows[i]["TotalTaxPcnt"]),
                        AllowCommission = Convert.ToInt32(dtRegSchemeList.Rows[i]["AllowCommission"]),
                        CommPcnt = Convert.ToInt32(dtRegSchemeList.Rows[i]["CommPcnt"]),
                        CommAmt = Convert.ToInt32(dtRegSchemeList.Rows[i]["CommAmt"]),
                        MaterialCost = Convert.ToInt32(dtRegSchemeList.Rows[i]["MaterialCost"]),
                        BaseCost = Convert.ToInt32(dtRegSchemeList.Rows[i]["BaseCost"]),
                        HeadId = Convert.ToInt32(dtRegSchemeList.Rows[i]["HeadId"]),
                        SortOrder = Convert.ToInt32(dtRegSchemeList.Rows[i]["SortOrder"]),
                        CPTCodeId = Convert.ToInt32(dtRegSchemeList.Rows[i]["CPTCodeId"]),
                        ExternalItem = Convert.ToInt32(dtRegSchemeList.Rows[i]["ExternalItem"])
                    };
                    regSchemeList.Add(obj);
                }
            }
            return regSchemeList;
        }
        /// <summary>
        /// Save Registration scheme if itemId is zero else update the Scheme with Id
        /// </summary>
        /// <param name="RegScheme"></param>
        /// <returns></returns>


        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Save and update MenuGroupMap. 
        /// </summary>
        /// <param name="mgm"></param>
        /// <returns>Success or reason to failure</returns>
        public string InsertUpdateMenuGroupMap(MenuGroupModel mgm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMenuGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int listcount = mgm.MenuIds.Count;
                string MenuIds = "";
                if (listcount > 0)
                    MenuIds = string.Join(",", mgm.MenuIds.ToArray());
                cmd.Parameters.AddWithValue("@GroupId", mgm.GroupId);
                cmd.Parameters.AddWithValue("@MenuIds", MenuIds);
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

        //SponsorManagement Starts
        /// <summary>
        /// Get sponsor list. if sponsorid is zero then returns all sponsor details. else returns specific sponsor id details
        /// </summary>
        /// <param name="sponsorid"></param>
        /// <returns></returns>
        public List<SponsorMasterModel> GetSponsor(Int32 sponsorid)
        {
            List<SponsorMasterModel> profList = new List<SponsorMasterModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", sponsorid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    SponsorMasterModel obj = new SponsorMasterModel
                    {
                        SponsorId = Convert.ToInt32(dtProfession.Rows[i]["SponsorId"]),
                        SponsorName = dtProfession.Rows[i]["SponsorName"].ToString(),
                        SponsorType = Convert.ToInt32(dtProfession.Rows[i]["SponsorType"]),
                        Address1 = dtProfession.Rows[i]["Address1"].ToString(),
                        Address2 = dtProfession.Rows[i]["Address2"].ToString(),
                        Street = dtProfession.Rows[i]["Street"].ToString(),
                        PlacePO = dtProfession.Rows[i]["PlacePO"].ToString(),
                        PIN = dtProfession.Rows[i]["PIN"].ToString(),
                        City = dtProfession.Rows[i]["City"].ToString(),
                        State = dtProfession.Rows[i]["State"].ToString(),
                        CountryId = Convert.ToInt32(dtProfession.Rows[i]["CountryId"]),
                        Phone = dtProfession.Rows[i]["Phone"].ToString(),
                        Mobile = dtProfession.Rows[i]["Mobile"].ToString(),
                        Email = dtProfession.Rows[i]["Email"].ToString(),
                        Fax = dtProfession.Rows[i]["Fax"].ToString(),
                        ContactPerson = dtProfession.Rows[i]["ContactPerson"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dtProfession.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dtProfession.Rows[i]["CoPayPcnt"].ToString()),
                        Remarks = dtProfession.Rows[i]["Remarks"].ToString(),
                        SFormId = Convert.ToInt32(dtProfession.Rows[i]["SFormId"]),
                        Active = Convert.ToInt32(dtProfession.Rows[i]["Active"]),
                        BlockReason = dtProfession.Rows[i]["BlockReason"].ToString(),
                        SponsorLimit = (float)Convert.ToDouble(dtProfession.Rows[i]["SponsorLimit"].ToString()),
                        DHANo = dtProfession.Rows[i]["DHANo"].ToString(),
                        EnableSponsorLimit = Convert.ToInt32(dtProfession.Rows[i]["EnableSponsorLimit"]),
                        EnableSponsorConsent = Convert.ToInt32(dtProfession.Rows[i]["EnableSponsorConsent"]),
                        AuthorizationMode = dtProfession.Rows[i]["AuthorizationMode"].ToString(),
                        URL = dtProfession.Rows[i]["URL"].ToString(),
                        SortOrder = Convert.ToInt32(dtProfession.Rows[i]["SortOrder"]),
                        PartyId = Convert.ToInt32(dtProfession.Rows[i]["PartyId"]),
                        UnclaimedId = Convert.ToInt32(dtProfession.Rows[i]["UnclaimedId"])
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        /// <summary>
        /// insert update sponsor details if SponsorId is zero then inserting the data else updating the data of id
        /// </summary>
        /// <param name="sponsor"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateSponsor(SponsorMasterModel sponsor)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SponsorId", sponsor.SponsorId);
                cmd.Parameters.AddWithValue("@SponsorName", sponsor.SponsorName);
                cmd.Parameters.AddWithValue("@SponsorType", sponsor.SponsorType);
                cmd.Parameters.AddWithValue("@Address1", sponsor.Address1);
                cmd.Parameters.AddWithValue("@Address2", sponsor.Address2);
                cmd.Parameters.AddWithValue("@Street", sponsor.Street);
                cmd.Parameters.AddWithValue("@PlacePO", sponsor.PlacePO);
                cmd.Parameters.AddWithValue("@PIN", sponsor.PIN);
                cmd.Parameters.AddWithValue("@City", sponsor.City);
                cmd.Parameters.AddWithValue("@State", sponsor.State);
                cmd.Parameters.AddWithValue("@CountryId", sponsor.CountryId);
                cmd.Parameters.AddWithValue("@Phone", sponsor.Phone);
                cmd.Parameters.AddWithValue("@Mobile", sponsor.Mobile);
                cmd.Parameters.AddWithValue("@Email", sponsor.Email);
                cmd.Parameters.AddWithValue("@Fax", sponsor.Fax);
                cmd.Parameters.AddWithValue("@ContactPerson", sponsor.ContactPerson);
                cmd.Parameters.AddWithValue("@DedAmount", sponsor.DedAmount);
                cmd.Parameters.AddWithValue("@CoPayPcnt", sponsor.CoPayPcnt);
                cmd.Parameters.AddWithValue("@Remarks", sponsor.Remarks);
                cmd.Parameters.AddWithValue("@PartyId", sponsor.PartyId);
                cmd.Parameters.AddWithValue("@UnclaimedId", sponsor.UnclaimedId);
                cmd.Parameters.AddWithValue("@SFormId", sponsor.SFormId);
                cmd.Parameters.AddWithValue("@SponsorLimit", sponsor.SponsorLimit);
                cmd.Parameters.AddWithValue("@Active", sponsor.Active);
                cmd.Parameters.AddWithValue("@BlockReason", sponsor.BlockReason);
                cmd.Parameters.AddWithValue("@DHANo", sponsor.DHANo);
                cmd.Parameters.AddWithValue("@EnableLimit", sponsor.EnableSponsorLimit);
                cmd.Parameters.AddWithValue("@EnableConsent", sponsor.EnableSponsorConsent);
                cmd.Parameters.AddWithValue("@AuthorizationMode", sponsor.AuthorizationMode);
                cmd.Parameters.AddWithValue("@URL", sponsor.URL);
                cmd.Parameters.AddWithValue("@SortOrder", sponsor.SortOrder);
                cmd.Parameters.AddWithValue("@UserId", sponsor.UserId);


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
        //SponsorManagement Endt

        //SponsorType Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<SponsorTypeModel> GetSponsorType(Int32 typeid)
        {
            List<SponsorTypeModel> stypeList = new List<SponsorTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STypeId", typeid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProfession = new DataTable();
            adapter.Fill(dtProfession);
            con.Close();
            if ((dtProfession != null) && (dtProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtProfession.Rows.Count; i++)
                {
                    SponsorTypeModel obj = new SponsorTypeModel
                    {
                        STypeId = Convert.ToInt32(dtProfession.Rows[i]["STypeId"]),
                        STypeDesc = dtProfession.Rows[i]["STypeDesc"].ToString(),
                        Active = Convert.ToInt32(dtProfession.Rows[i]["Active"]),
                        BlockReason = dtProfession.Rows[i]["BlockReason"].ToString()
                    };
                    stypeList.Add(obj);
                }
            }
            return stypeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stype"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@STypeId", stype.STypeId);
                cmd.Parameters.AddWithValue("@STypeDesc", stype.STypeDesc);
                cmd.Parameters.AddWithValue("@Active", stype.Active);
                cmd.Parameters.AddWithValue("@BlockReason", stype.BlockReason);
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

        //SponsorType Ends

        //SponsorForm Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formid"></param>
        /// <returns></returns>
        public List<SponsorFormModel> GetSponsorForm(Int32 formid)
        {
            List<SponsorFormModel> sformList = new List<SponsorFormModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorForms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SFormId", formid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    SponsorFormModel obj = new SponsorFormModel
                    {
                        SFormId = Convert.ToInt32(dsProfession.Rows[i]["SFormId"]),
                        SFormName = dsProfession.Rows[i]["SFormName"].ToString(),
                        Active = Convert.ToInt32(dsProfession.Rows[i]["Active"]),
                        BlockReason = dsProfession.Rows[i]["SFormName"].ToString()
                    };
                    sformList.Add(obj);
                }
            }
            return sformList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sform"></param>
        /// <returns></returns>
        public string InsertUpdateSponsorForm(SponsorFormModel sform)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SFormId", sform.SFormId);
                cmd.Parameters.AddWithValue("@SFormName", sform.SFormName);
                cmd.Parameters.AddWithValue("@Active", sform.Active);
                cmd.Parameters.AddWithValue("@BlockReason", sform.BlockReason);
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
        //SponsorForm Ends

        //Consent Management Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientid"></param>
        /// <returns></returns>
        public List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 patientid)
        {
            List<ConsentPreviewModel> consentpreviewList = new List<ConsentPreviewModel>();
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            string patientname = string.Empty;
            string fileloc = string.Empty;
            using SqlConnection con = new SqlConnection(_connStr);

            using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", 0);
                cmd.Parameters.AddWithValue("@ConsentType", 1);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();

                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    for (Int32 j = 0; j < dsPatientList.Rows.Count; j++)
                    {
                        ConsentContentModel obj4 = new ConsentContentModel
                        {
                            ContentId = Convert.ToInt32(dsPatientList.Rows[j]["ContentId"]),
                            CTEnglish = dsPatientList.Rows[j]["CTEnglish"].ToString(),
                            CTArabic = dsPatientList.Rows[j]["CTArabic"].ToString()
                        };
                        ccmlist.Add(obj4);
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("stLH_GetPatConsentDetails", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();
                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    patientname = dsPatientList.Rows[0]["PatientName"].ToString();
                    if (dsPatientList.Rows[0]["SignLocation"].ToString() != "")
                    {
                        fileloc = _uploadpath + dsPatientList.Rows[0]["SignLocation"].ToString();
                    }


                }
            }
            ConsentPreviewModel cpm = new ConsentPreviewModel
            {
                ConsentContentValue = ccmlist,
                PatientName = patientname,
                FileLoc = fileloc
            };
            consentpreviewList.Add(cpm);
            return consentpreviewList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consentid"></param>
        /// <returns></returns>
        public List<ConsentContentModel> GetConsent(Int32 consentid)
        {
            List<ConsentContentModel> ccmlist = new List<ConsentContentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using (SqlCommand cmd = new SqlCommand("stLH_GetConsent", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", consentid);
                cmd.Parameters.AddWithValue("@ConsentType", 0);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dsPatientList = new DataTable();
                adapter.Fill(dsPatientList);
                con.Close();

                if ((dsPatientList != null) && (dsPatientList.Rows.Count > 0))
                {
                    for (Int32 j = 0; j < dsPatientList.Rows.Count; j++)
                    {
                        ConsentContentModel obj = new ConsentContentModel
                        {
                            ContentId = Convert.ToInt32(dsPatientList.Rows[j]["ContentId"]),
                            CTEnglish = dsPatientList.Rows[j]["CTEnglish"].ToString(),
                            CTArabic = dsPatientList.Rows[j]["CTArabic"].ToString(),
                            DisplayOrder = Convert.ToInt32(dsPatientList.Rows[j]["DisplayOrder"]),
                            CType = Convert.ToInt32(dsPatientList.Rows[j]["CType"]),
                            Active = Convert.ToInt32(dsPatientList.Rows[j]["Active"]),
                            BlockReason = dsPatientList.Rows[j]["BlockReason"].ToString()
                        };
                        ccmlist.Add(obj);
                    }
                }
            }
            return ccmlist;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consent"></param>
        /// <returns></returns>
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", consent.ContentId);
                cmd.Parameters.AddWithValue("@DisplayOrder", consent.DisplayOrder);
                cmd.Parameters.AddWithValue("@EnglishTxt", consent.CTEnglish);
                cmd.Parameters.AddWithValue("@ArabicTxt", consent.CTArabic);
                cmd.Parameters.AddWithValue("@CType", consent.CType);
                cmd.Parameters.AddWithValue("@Active", consent.Active);
                cmd.Parameters.AddWithValue("@BlockReason", consent.BlockReason);
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
        //Consent Management Ends


        /// <summary>
        /// Save and updating Zone master data,Saves when Id is zero. Updates when Id Not equal to zero
        /// </summary>
        /// <param name="zone"></param>
        /// <returns>success or reason for error</returns>
        public string InsertUpdateZone(ZoneModel zone)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateZone", con);//InsertUpdateZone
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZoneId", zone.Id);
                cmd.Parameters.AddWithValue("@OperatorId", zone.OperatorId);
                cmd.Parameters.AddWithValue("@ZoneName", zone.ZoneName);
                cmd.Parameters.AddWithValue("@ZoneCode", zone.ZoneCode);
                cmd.Parameters.AddWithValue("@ZoneDescription", zone.ZoneDescription);
                cmd.Parameters.AddWithValue("@ZoneCountry", zone.ZoneCountry);
                cmd.Parameters.AddWithValue("@Active", zone.IsActive);
                cmd.Parameters.AddWithValue("@BlockReason", zone.BlockReason);
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
        /// if zoneId is zero then returns all zones , else returns specific zone
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns>Zone list</returns>
        public List<ZoneModel> GetZone(Int32 zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_ZoneById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@zoneId", zoneId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtZoneList = new DataTable();
            adapter.Fill(dtZoneList);
            con.Close();
            if ((dtZoneList != null) && (dtZoneList.Rows.Count > 0))
                zoneList = dtZoneList.ToListOfObject<ZoneModel>();
            return zoneList;
        }
        //NOT NEEDED TODO
        /// <summary>
        /// Get Department Details By HospitalId
        /// </summary>
        /// <param name="HospId"></param>
        /// <returns>List Of Departments</returns>
        //public List<DepartmentModel> GetDepartmentByHospital(Int32 HospId)
        //{
        //    List<DepartmentModel> departmentlist = new List<DepartmentModel>();
        //    using SqlConnection con = new SqlConnection(_connStr);
        //    using SqlCommand cmd = new SqlCommand("stLH_GetDepartmentByHospital", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@HospitalId", HospId);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    con.Close();
        //    if ((dt != null) && (dt.Rows.Count > 0))
        //    {
        //        for (Int32 i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DepartmentModel obj = new DepartmentModel
        //            {
        //                DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"]),
        //                DeptName = dt.Rows[i]["DeptName"].ToString(),
        //                DeptCode = dt.Rows[i]["DeptCode"].ToString()
        //            };
        //            departmentlist.Add(obj);
        //        }
        //    }
        //    return departmentlist;
        //}
        public List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel)
        {
            List<ConsultantModel> departmentlist = new List<ConsultantModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantByHospital", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@HospitalId", cmodel.BranchId);
            cmd.Parameters.AddWithValue("@IsExternal", cmodel.IsExternal);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ConsultantModel obj = new ConsultantModel
                    {
                        ConsultantId = Convert.ToInt32(dt.Rows[i]["ConsultantId"]),
                        ConsultantName = dt.Rows[i]["ConsultantName"].ToString()
                    };
                    departmentlist.Add(obj);
                }
            }
            return departmentlist;
        }




        //Hospital Starts
        /// <summary>
        /// Get Hospital list from database.Step three in code execution flow
        /// </summary>
        /// <returns></returns>

        public List<HospitalModel> GetUserHospitals(Int32 id)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsHospitalList = new DataTable();
            adapter.Fill(dsHospitalList);
            con.Close();
            if ((dsHospitalList != null) && (dsHospitalList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsHospitalList.Rows.Count; i++)
                {
                    HospitalModel obj = new HospitalModel
                    {
                        HospitalId = Convert.ToInt32(dsHospitalList.Rows[i]["HospitalId"]),
                        HospitalName = dsHospitalList.Rows[i]["HospitalName"].ToString(),
                        HospitalCode = dsHospitalList.Rows[i]["HospitalCode"].ToString(),
                        Caption = dsHospitalList.Rows[i]["Caption"].ToString(),
                        Address1 = dsHospitalList.Rows[i]["Address1"].ToString(),
                        Address2 = dsHospitalList.Rows[i]["Address2"].ToString(),
                        Street = dsHospitalList.Rows[i]["Street"].ToString(),
                        PlacePO = dsHospitalList.Rows[i]["PlacePO"].ToString(),
                        PIN = dsHospitalList.Rows[i]["PIN"].ToString(),
                        City = dsHospitalList.Rows[i]["City"].ToString(),
                        State = Convert.ToInt32(dsHospitalList.Rows[i]["State"]),
                        Country = Convert.ToInt32(dsHospitalList.Rows[i]["Country"]),
                        Phone = dsHospitalList.Rows[i]["Phone"].ToString(),
                        Fax = dsHospitalList.Rows[i]["Fax"].ToString(),
                        Email = dsHospitalList.Rows[i]["Email"].ToString(),
                        URL = dsHospitalList.Rows[i]["URL"].ToString(),
                        Logo = dsHospitalList.Rows[i]["Logo"].ToString(),
                        ReportLogo = dsHospitalList.Rows[i]["ReportLogo"].ToString(),
                        ClinicId = dsHospitalList.Rows[i]["ClinicId"].ToString(),
                        DHAFacilityId = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        DHAUserName = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        DHAPassword = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        SR_ID = dsHospitalList.Rows[i]["SR_ID"].ToString(),
                        MalaffiSystemcode = dsHospitalList.Rows[i]["MalaffiSystemcode"].ToString()
                    };
                    hospitalList.Add(obj);
                }
            }
            return hospitalList;

        }
        public List<HospitalModel> GetUserSpecificHospitals(int userId)
        {
            List<HospitalModel> hospitalList = new List<HospitalModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUserSpecificHospitals", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsHospitalList = new DataTable();
            adapter.Fill(dsHospitalList);
            con.Close();
            if ((dsHospitalList != null) && (dsHospitalList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsHospitalList.Rows.Count; i++)
                {
                    HospitalModel obj = new HospitalModel
                    {
                        HospitalId = Convert.ToInt32(dsHospitalList.Rows[i]["HospitalId"]),
                        HospitalName = dsHospitalList.Rows[i]["HospitalName"].ToString(),
                        HospitalCode = dsHospitalList.Rows[i]["HospitalCode"].ToString(),
                        Caption = dsHospitalList.Rows[i]["Caption"].ToString(),
                        Address1 = dsHospitalList.Rows[i]["Address1"].ToString(),
                        Address2 = dsHospitalList.Rows[i]["Address2"].ToString(),
                        Street = dsHospitalList.Rows[i]["Street"].ToString(),
                        PlacePO = dsHospitalList.Rows[i]["PlacePO"].ToString(),
                        PIN = dsHospitalList.Rows[i]["PIN"].ToString(),
                        City = dsHospitalList.Rows[i]["City"].ToString(),
                        State = Convert.ToInt32(dsHospitalList.Rows[i]["State"]),
                        Country = Convert.ToInt32(dsHospitalList.Rows[i]["Country"]),
                        Phone = dsHospitalList.Rows[i]["Phone"].ToString(),
                        Fax = dsHospitalList.Rows[i]["Fax"].ToString(),
                        Email = dsHospitalList.Rows[i]["Email"].ToString(),
                        URL = dsHospitalList.Rows[i]["URL"].ToString(),
                        Logo = dsHospitalList.Rows[i]["Logo"].ToString(),
                        ReportLogo = dsHospitalList.Rows[i]["ReportLogo"].ToString(),
                        ClinicId = dsHospitalList.Rows[i]["ClinicId"].ToString(),
                        DHAFacilityId = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        DHAUserName = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        DHAPassword = dsHospitalList.Rows[i]["DHAFacilityId"].ToString(),
                        SR_ID = dsHospitalList.Rows[i]["SR_ID"].ToString(),
                        MalaffiSystemcode = dsHospitalList.Rows[i]["MalaffiSystemcode"].ToString()
                        //Active = Convert.ToInt32(dsHospitalList.Rows[i]["IsActive"]),
                        //BlockReason = dsHospitalList.Rows[i]["BlockReason"].ToString()
                    };
                    hospitalList.Add(obj);
                }
            }
            return hospitalList;
        }
        public List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch)
        {
            List<LocationModel> locationList = new List<LocationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("GetUserSpecificHospitalLocations", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_UserId", userId);
            cmd.Parameters.AddWithValue("@P_BranchId", branch);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dslocationlistList = new DataTable();
            adapter.Fill(dslocationlistList);
            con.Close();
            if ((dslocationlistList != null) && (dslocationlistList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dslocationlistList.Rows.Count; i++)
                {
                    LocationModel obj = new LocationModel
                    {
                        LocationId = Convert.ToInt32(dslocationlistList.Rows[i]["LocationId"].ToString()),
                        LocationName = dslocationlistList.Rows[i]["LocationName"].ToString(),
                        LTypeId = Convert.ToInt32(dslocationlistList.Rows[i]["LTypeId"].ToString()),
                        ManageBilling = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageBilling"].ToString()),
                        ManageCash = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageCash"].ToString()),
                        ManageCredit = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageCredit"].ToString()),
                        ManageIPCredit = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageIPCredit"].ToString()),
                        ManageSPoints = Convert.ToBoolean(dslocationlistList.Rows[i]["ManageSPoints"].ToString()),
                        Supervisor = dslocationlistList.Rows[i]["Supervisor"].ToString(),
                        RepHeadImg = dslocationlistList.Rows[i]["RepHeadImg"].ToString()
                    };

                    locationList.Add(obj);
                }
            }
            return locationList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospital"></param>
        /// <returns></returns>
        public string InsertUpdateUserHospital(HospitalRegModel hospital)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateHospital", con);
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
            return response;
        }

        //Hospital Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consent"></param>
        /// <returns></returns>
        public string ConsentFormDataSave(ConsentFormRegModel consent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertConsentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConsentId", consent.ConsentId);
                cmd.Parameters.AddWithValue("@PatientId", consent.PatientId);
                cmd.Parameters.AddWithValue("@BranchId", consent.BranchId);
                cmd.Parameters.AddWithValue("@Sign", consent.Sign);
                //SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(retValV);
                //SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(retDesc);
                con.Open();
                var isUpdated = cmd.ExecuteNonQuery();
                //var ret = retValV.Value;
                //var descrip = retDesc.Value.ToString();
                con.Close();
                //if (descrip == "Saved Successfully")
                //{
                response = "Success";
                //}
                //else
                //{
                //    response = descrip;
                //}
            }
            return response;
        }

        //Operator Starts Now
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Operator"></param>
        /// <returns></returns>
        public string InsertUpdateOperator(OperatorModel Operator)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateOperator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Operator.Id);
                cmd.Parameters.AddWithValue("@OperatorName", Operator.OperatorName);
                cmd.Parameters.AddWithValue("@OperatorCode", Operator.OperatorCode);
                cmd.Parameters.AddWithValue("@OperatorDescription", Operator.OperatorDescription);
                cmd.Parameters.AddWithValue("@Active", Operator.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Operator.BlockReason);
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
        /// for getting Operator data. if operator id is zero then returns all operators. else returns specific operator data
        /// </summary>
        /// <param name="OperatorId"></param>
        /// <returns>operator list</returns>
        public List<OperatorModel> GetOperator(Int32 OperatorId)
        {
            List<OperatorModel> stateList = new List<OperatorModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetOperatorById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", OperatorId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsStateList = new DataTable();
            adapter.Fill(dsStateList);
            con.Close();
            if ((dsStateList != null) && (dsStateList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsStateList.Rows.Count; i++)
                {
                    OperatorModel obj = new OperatorModel
                    {
                        Id = Convert.ToInt32(dsStateList.Rows[i]["Id"]),
                        OperatorName = dsStateList.Rows[i]["OperatorName"].ToString(),
                        OperatorCode = dsStateList.Rows[i]["OperatorCode"].ToString(),
                        Active = Convert.ToInt32(dsStateList.Rows[i]["IsActive"]),
                        BlockReason = dsStateList.Rows[i]["BlockReason"].ToString()
                    };
                    stateList.Add(obj);
                }
            }
            return stateList;
        }
        //Operator Ends Now
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<LeadAgentModel> GetLeadAgent(Int32 la)
        {
            List<LeadAgentModel> itemList = new List<LeadAgentModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeadAgentId", la);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    LeadAgentModel obj = new LeadAgentModel
                    {
                        LeadAgentId = Convert.ToInt32(dsNumber.Rows[i]["LeadAgentId"]),
                        Name = dsNumber.Rows[i]["Name"].ToString(),
                        ContactNo = dsNumber.Rows[i]["ContactNo"].ToString(),
                        CommisionPercent = (float)Convert.ToDouble(dsNumber.Rows[i]["CommisionPercent"].ToString()),
                        Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]),
                        BlockReason = dsNumber.Rows[i]["BlockReason"].ToString()
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LeadAgent"></param>
        /// <returns></returns>
        public string InsertUpdateLeadAgent(LeadAgentModel LeadAgent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateLeadAgent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeadAgentID", LeadAgent.LeadAgentId);
                cmd.Parameters.AddWithValue("@Name", LeadAgent.Name);
                cmd.Parameters.AddWithValue("@ContactNo", LeadAgent.ContactNo);
                cmd.Parameters.AddWithValue("@CommisionPercent", LeadAgent.CommisionPercent);
                cmd.Parameters.AddWithValue("@Active", LeadAgent.Active);
                cmd.Parameters.AddWithValue("@BlockReason", LeadAgent.BlockReason);
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



        //Movement Starts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        public string InsertUpdateMovement(MovementModel movement)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMovement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovementId", movement.MovementId);
                cmd.Parameters.AddWithValue("@MovementDesc", movement.MovementDesc);
                cmd.Parameters.AddWithValue("@Active", movement.Active);
                cmd.Parameters.AddWithValue("@BlockReason", movement.BlockReason);
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
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<MovementModel> GetMovement(Int32 Id)
        {
            List<MovementModel> vitalSignList = new List<MovementModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMovementDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MovementId", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsMovementList = new DataTable();
            adapter.Fill(dsMovementList);
            con.Close();
            if ((dsMovementList != null) && (dsMovementList.Rows.Count > 0))
                vitalSignList = dsMovementList.ToListOfObject<MovementModel>();
            return vitalSignList;
        }
        //Movement Ends
        //Package Starts


        //Package Ends

        //Location Starts

        //Location Ends
        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel dm)
        {
            List<ConsultantDrugModel> drugList = new List<ConsultantDrugModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrug", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugId", dm.DrugId);
            cmd.Parameters.AddWithValue("@DrugTypeId", dm.DrugTypeId);
            cmd.Parameters.AddWithValue("@BranchId", dm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsDrug = new DataTable();
            adapter.Fill(dsDrug);
            con.Close();
            if ((dsDrug != null) && (dsDrug.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsDrug.Rows.Count; i++)
                {
                    ConsultantDrugModel obj = new ConsultantDrugModel
                    {
                        DrugId = Convert.ToInt32(dsDrug.Rows[i]["DrugId"]),
                        DrugName = dsDrug.Rows[i]["DrugName"].ToString(),
                        Dosage = dsDrug.Rows[i]["DOSAGE_FORM_PACKAGE"].ToString(),
                        RouteId = Convert.ToInt32(dsDrug.Rows[i]["RouteId"]),
                        RouteDesc = dsDrug.Rows[i]["Route"].ToString(),
                        Duration = 9999,//Convert.ToInt32(dsDrug.Rows[i]["Duration"]);
                        BranchId = dm.BranchId,
                        ScientificName = dsDrug.Rows[i]["ScientificName"].ToString()
                    };
                    drugList.Add(obj);
                }
            }
            return drugList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<DosageModel> GetDosage(DosageModel dm)
        {
            List<DosageModel> dosageList = new List<DosageModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDosage", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DosageId", dm.DosageId);
            cmd.Parameters.AddWithValue("@BranchId", dm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsDrug = new DataTable();
            adapter.Fill(dsDrug);
            con.Close();
            if ((dsDrug != null) && (dsDrug.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsDrug.Rows.Count; i++)
                {
                    DosageModel obj = new DosageModel
                    {
                        DosageId = Convert.ToInt32(dsDrug.Rows[i]["DosageId"]),
                        DosageDesc = dsDrug.Rows[i]["DosageDesc"].ToString(),
                        Active = Convert.ToBoolean(dsDrug.Rows[i]["Active"]),
                        DosageValue = Convert.ToInt32(dsDrug.Rows[i]["DosageValue"]),
                        BranchId = dm.BranchId
                    };
                    dosageList.Add(obj);
                }
            }
            return dosageList;
        }
        public List<RouteModel> GetRoute(RouteModel rm)
        {
            List<RouteModel> routeList = new List<RouteModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetRoute", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RouteId", rm.RouteId);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsRoute = new DataTable();
            adapter.Fill(dsRoute);
            con.Close();
            if ((dsRoute != null) && (dsRoute.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsRoute.Rows.Count; i++)
                {
                    RouteModel obj = new RouteModel
                    {
                        RouteId = Convert.ToInt32(dsRoute.Rows[i]["RouteId"]),
                        RouteDesc = dsRoute.Rows[i]["RouteDesc"].ToString(),
                        RouteCode = dsRoute.Rows[i]["RouteCode"].ToString(),
                        Active = Convert.ToBoolean(dsRoute.Rows[i]["Active"]),
                        BlockReason = dsRoute.Rows[i]["BlockReason"].ToString(),
                        SortOrder = Convert.ToInt32(dsRoute.Rows[i]["SortOrder"]),
                        BranchId = rm.BranchId
                    };
                    routeList.Add(obj);
                }
            }
            return routeList;
        }
        public List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData rm)
        {
            List<PendingItemModel> itemList = new List<PendingItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPendingItemByPatient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", rm.PatientId);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsItem = new DataTable();
            adapter.Fill(dsItem);
            con.Close();
            if ((dsItem != null) && (dsItem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsItem.Rows.Count; i++)
                {
                    var obj = JsonConvert.DeserializeObject<PendingItemModel>(dsItem.Rows[i]["ValueDatas"].ToString());
                    if (obj != null)
                    {
                        itemList.Add(obj);
                    }
                }
            }
            return itemList;
        }
        //Location Starts
        /// <summary>
        /// Get Scientific names of drugs master
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public List<ScientificNameModel> GetScientificName(Int32 la)
        {
            List<ScientificNameModel> itemList = new List<ScientificNameModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetScientificName", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ScientificId", la);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    ScientificNameModel obj = new ScientificNameModel
                    {
                        ScientificId = Convert.ToInt32(dsNumber.Rows[i]["ScientificId"]),
                        ScientificCode = dsNumber.Rows[i]["ScientificCode"].ToString(),
                        ScientificName = dsNumber.Rows[i]["ScientificName"].ToString(),
                        Active = Convert.ToInt32(dsNumber.Rows[i]["Active"])
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }



        /// <summary>
        /// Save or update a drug's scientific name.If ScientificId is zero then inserts the value. else updates the value
        /// </summary>
        /// <param name="Package"></param>
        /// <returns></returns>
        public string InsertUpdateScientificName(ScientificNameModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateScientifcName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScientificId", Package.ScientificId);
                cmd.Parameters.AddWithValue("@ScientificName", Package.ScientificName);
                cmd.Parameters.AddWithValue("@ScientificCode", Package.ScientificCode);
                cmd.Parameters.AddWithValue("@UserId", Package.UserId);
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
        //ScientificName Ends
        //Tendern Starts
        /// <summary>
        /// Get Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="tendernessid">Primary key of LH_PhyTendern Table</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public List<TendernModel> GetTendern(Int32 tendernessid)
        {
            List<TendernModel> itemList = new List<TendernModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTendernDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TendernId", tendernessid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    TendernModel obj = new TendernModel
                    {
                        TendernId = Convert.ToInt32(dsNumber.Rows[i]["TendernId"]),
                        TendernDesc = dsNumber.Rows[i]["TendernDesc"].ToString(),
                        Active = Convert.ToInt32(dsNumber.Rows[i]["Active"]),
                        BlockReason = dsNumber.Rows[i]["BlockReason"].ToString()
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// Save/Update Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="TendernId">Primary key of LH_PhyTendern Table,Update Data if param is not zero</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public string InsertUpdateTendern(TendernModel Package)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTendern", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TendernId", Package.TendernId);
                cmd.Parameters.AddWithValue("@TendernDesc", Package.TendernDesc);
                cmd.Parameters.AddWithValue("@Active", Package.Active);
                cmd.Parameters.AddWithValue("@BlockReason", Package.BlockReason);
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
        //Tendern Ends


        // GET MASTER ONLY NO CRUD

        /// <summary>
        /// Get Details of Appointment Type
        /// </summary>
        /// <returns>List of Appointment types</returns>
        public List<AppTypeModel> GetAppType()
        {
            List<AppTypeModel> profList = new List<AppTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetAppointTypes", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsProfession = new DataTable();
            adapter.Fill(dsProfession);
            con.Close();
            if ((dsProfession != null) && (dsProfession.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsProfession.Rows.Count; i++)
                {
                    AppTypeModel obj = new AppTypeModel
                    {
                        AppTypeId = Convert.ToInt32(dsProfession.Rows[i]["AppTypeId"]),
                        AppCode = dsProfession.Rows[i]["AppCode"].ToString(),
                        AppDesc = dsProfession.Rows[i]["AppDesc"].ToString()
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<StateModel> GetStateByCountryId(Int32 countryId)
        {
            List<StateModel> stateList = new List<StateModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetEmirate", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", countryId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
                stateList = dtStateList.ToListOfObject<StateModel>();
            return stateList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ibt"></param>
        /// <returns></returns>
        public List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt)
        {
            List<ItemsByTypeModel> itemList = new List<ItemsByTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemsByType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupCode", ibt.GroupCode);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    ItemsByTypeModel obj = new ItemsByTypeModel
                    {
                        ItemId = Convert.ToInt32(dtNumber.Rows[i]["ItemId"]),
                        ItemCode = dtNumber.Rows[i]["ItemCode"].ToString(),
                        ItemName = dtNumber.Rows[i]["ItemName"].ToString(),
                        GroupId = Convert.ToInt32(dtNumber.Rows[i]["GroupId"]),
                        GroupCode = dtNumber.Rows[i]["GroupCode"].ToString()
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ConsentTypeModel> GetConsentType()
        {
            List<ConsentTypeModel> consentTypeList = new List<ConsentTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsentType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    ConsentTypeModel obj = new ConsentTypeModel
                    {
                        Id = Convert.ToInt32(dtNumber.Rows[i]["Id"]),
                        ConsentType = dtNumber.Rows[i]["ConsentType"].ToString(),
                        ConsentTypeCode = dtNumber.Rows[i]["ConsentTypeCode"].ToString()
                    };
                    consentTypeList.Add(obj);
                }
            }
            return consentTypeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numId"></param>
        /// <returns></returns>
        public List<GetNumberModel> GetNumber(string numId)
        {
            List<GetNumberModel> numberList = new List<GetNumberModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetNumber", con);
            if (numId == "All")
            {
                numId = string.Empty;
            }
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumId", numId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    GetNumberModel obj = new GetNumberModel
                    {
                        selectopt = Convert.ToInt32(dtNumber.Rows[i]["selectopt"]),
                        NumId = dtNumber.Rows[i]["NumId"].ToString(),
                        Description = dtNumber.Rows[i]["Description"].ToString(),
                        Value = Convert.ToInt32(dtNumber.Rows[i]["Value"]),
                        Prefix = dtNumber.Rows[i]["Prefix"].ToString(),
                        Suffix = dtNumber.Rows[i]["Suffix"].ToString(),
                        Length = Convert.ToInt32(dtNumber.Rows[i]["Length"]),
                        State = Convert.ToInt32(dtNumber.Rows[i]["State"]),
                        Status = Convert.ToInt32(dtNumber.Rows[i]["Status"]),
                        MaxLength = Convert.ToInt32(dtNumber.Rows[i]["MaxLength"]),
                        Preview = dtNumber.Rows[i]["Preview"].ToString()
                    };
                    numberList.Add(obj);
                }
            }
            return numberList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<FormValidationModel> GetFormMaster()
        {
            List<FormValidationModel> numberList = new List<FormValidationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetFormMaster", con);

            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    FormValidationModel obj = new FormValidationModel
                    {
                        FormId = Convert.ToInt32(dtNumber.Rows[i]["FormId"]),
                        FormName = dtNumber.Rows[i]["FormName"].ToString()
                    };
                    numberList.Add(obj);
                }
            }
            return numberList;
        }
        /// <summary>
        /// GET list of Input Fieldt In a Form Id
        /// </summary>
        /// <param name="FormId">ID of form</param>
        /// <returns>Form Fieldt list</returns>
        public List<FormValidationModel> GetFormFields(Int32 FormId)
        {
            List<FormValidationModel> numberList = new List<FormValidationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetFormFields", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormId", FormId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    FormValidationModel obj = new FormValidationModel
                    {
                        FieldId = Convert.ToInt32(dtNumber.Rows[i]["FieldId"]),
                        FormId = Convert.ToInt32(dtNumber.Rows[i]["FormId"]),
                        FieldName = dtNumber.Rows[i]["FieldName"].ToString()
                    };
                    numberList.Add(obj);
                }
            }
            return numberList;
        }
        /// <summary>
        /// Update Data in Number configuration table 
        /// </summary>
        /// <param name="num">Data in LH_Numbers Table</param>
        /// <returns>Success or reason for error</returns>
        public string UpdateNumberTable(GetNumberModel num)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_ActionUpdateNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumId", num.NumId);
                cmd.Parameters.AddWithValue("@Prefix", num.Prefix);
                cmd.Parameters.AddWithValue("@Suffix", num.Suffix);
                cmd.Parameters.AddWithValue("@Length", num.Length);
                cmd.Parameters.AddWithValue("@Status", num.Status);
                cmd.Parameters.AddWithValue("@Value", num.Value);
                cmd.Parameters.AddWithValue("@MaxLength", num.MaxLength);
                cmd.Parameters.AddWithValue("@UserId", num.UserId);
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
        /// Get all gender data
        /// </summary>
        /// <returns>Gender data list</returns>
        public List<GenderModel> GetGender()
        {
            List<GenderModel> genderList = new List<GenderModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetGender", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsGender = new DataTable();
            adapter.Fill(dsGender);
            con.Close();
            if ((dsGender != null) && (dsGender.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsGender.Rows.Count; i++)
                {
                    GenderModel obj = new GenderModel
                    {
                        Id = Convert.ToInt32(dsGender.Rows[i]["Id"]),
                        GenderName = dsGender.Rows[i]["GenderName"].ToString()
                    };
                    genderList.Add(obj);
                }
            }
            return genderList;
        }
        /// <summary>
        /// Get all kin relation data
        /// </summary>
        /// <returns>Kin relation list</returns>
        public List<KinRelationModel> GetKinRelation()
        {
            List<KinRelationModel> kinRelationList = new List<KinRelationModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetKinRelation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsKinRelation = new DataTable();
            adapter.Fill(dsKinRelation);
            con.Close();
            if ((dsKinRelation != null) && (dsKinRelation.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsKinRelation.Rows.Count; i++)
                {
                    KinRelationModel obj = new KinRelationModel();
                    obj.Id = Convert.ToInt32(dsKinRelation.Rows[i]["Id"]);
                    obj.KinRelation = dsKinRelation.Rows[i]["KinRelation"].ToString();
                    kinRelationList.Add(obj);
                }
            }
            return kinRelationList;
        }
    }
}
