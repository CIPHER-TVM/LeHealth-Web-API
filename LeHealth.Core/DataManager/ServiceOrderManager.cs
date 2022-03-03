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
    public class ServiceOrderManager : IServiceOrderManager
    {
        private readonly string _connStr;
        public ServiceOrderManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");

        }
        public List<GroupModel> GetItemsGroup(int groupId)
        {
            List<GroupModel> communicationTypeList = new List<GroupModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetItemGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsItemGroup = new DataTable();
                    adapter.Fill(dsItemGroup);
                    con.Close();
                    if ((dsItemGroup != null) && (dsItemGroup.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsItemGroup.Rows.Count; i++)
                        {
                            GroupModel obj = new GroupModel();
                            obj.GroupId = Convert.ToInt32(dsItemGroup.Rows[i]["GroupId"]);
                            obj.GroupName = dsItemGroup.Rows[i]["GroupName"].ToString();
                            obj.GroupCode = dsItemGroup.Rows[i]["GroupCode"].ToString();
                            obj.GroupCommPcnt = Convert.ToInt32(dsItemGroup.Rows[i]["GroupCommPcnt"]);
                            obj.Category = dsItemGroup.Rows[i]["Category"].ToString();
                            obj.GroupType = Convert.ToInt32(dsItemGroup.Rows[i]["GroupType"]);
                            obj.GroupLevel = dsItemGroup.Rows[i]["GroupLevel"].ToString();
                            obj.ParentFlag = Convert.ToInt32(dsItemGroup.Rows[i]["ParentFlag"]);
                            communicationTypeList.Add(obj);
                        }
                    }
                    return communicationTypeList;
                }
            }
        }

        public List<ItemsByTypeModel> GetPackageItem(int packId)
        {
            List<ItemsByTypeModel> communicationTypeList = new List<ItemsByTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetPackageItem", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PackId", packId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsItemGroup = new DataTable();
                    adapter.Fill(dsItemGroup);
                    con.Close();
                    if ((dsItemGroup != null) && (dsItemGroup.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsItemGroup.Rows.Count; i++)
                        {
                            ItemsByTypeModel obj = new ItemsByTypeModel();
                            obj.ItemId = Convert.ToInt32(dsItemGroup.Rows[i]["ItemId"]);
                            obj.ItemCode = dsItemGroup.Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsItemGroup.Rows[i]["ItemName"].ToString();
                            obj.Rate = Convert.ToInt32(dsItemGroup.Rows[i]["Rate"]);
                            obj.Quantity = Convert.ToInt32(dsItemGroup.Rows[i]["Quantity"]);
                            communicationTypeList.Add(obj);
                        }
                    }
                    return communicationTypeList;
                }
            }
        }

        public List<AvailableServiceModel> GetAvailableService(AvailableServiceModel asm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetServiceItemsOfGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", asm.GroupId);
                    cmd.Parameters.AddWithValue("@PatientId", asm.PatientId);
                    cmd.Parameters.AddWithValue("@BranchId", asm.BranchId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsavailableService = new DataTable();
                    adapter.Fill(dsavailableService);
                    con.Close();
                    if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                        {
                            AvailableServiceModel obj = new AvailableServiceModel();
                            obj.ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]);
                            obj.ItemCode = dsavailableService.Rows[i]["ItemCode"].ToString();
                            obj.ItemName = dsavailableService.Rows[i]["ItemName"].ToString();
                            obj.GroupId =Convert.ToInt32( dsavailableService.Rows[i]["GroupId"]);
                            obj.ValidityDays = Convert.ToInt32(dsavailableService.Rows[i]["ValidityDays"]);
                            obj.ValidityVisits = Convert.ToInt32(dsavailableService.Rows[i]["ValidityVisits"]);
                            obj.AllowRateEdit = Convert.ToInt32(dsavailableService.Rows[i]["AllowRateEdit"]);
                            obj.AllowDisc = Convert.ToInt32(dsavailableService.Rows[i]["AllowDisc"]);
                            obj.AllowPP = Convert.ToInt32(dsavailableService.Rows[i]["AllowPP"]);
                            obj.IsVSign = Convert.ToInt32(dsavailableService.Rows[i]["IsVSign"]);
                            obj.ResultOn = Convert.ToInt32(dsavailableService.Rows[i]["ResultOn"]);
                            obj.STypeId = Convert.ToInt32(dsavailableService.Rows[i]["STypeId"]);
                            obj.TotalTaxPcnt = Convert.ToInt32(dsavailableService.Rows[i]["TotalTaxPcnt"]);
                            obj.AllowCommission = Convert.ToInt32(dsavailableService.Rows[i]["AllowCommission"]);
                            obj.CommPcnt = Convert.ToInt32(dsavailableService.Rows[i]["CommPcnt"]);
                            obj.CommAmt = Convert.ToInt32(dsavailableService.Rows[i]["CommAmt"]);
                            obj.MaterialCost = Convert.ToInt32(dsavailableService.Rows[i]["MaterialCost"]);
                            obj.BaseCost = Convert.ToInt32(dsavailableService.Rows[i]["BaseCost"]);
                            obj.HeadId = Convert.ToInt32(dsavailableService.Rows[i]["HeadId"]);
                            obj.SortOrder = Convert.ToInt32(dsavailableService.Rows[i]["SortOrder"]);
                            obj.Active = Convert.ToInt32(dsavailableService.Rows[i]["Active"]);
                            obj.BlockReason = dsavailableService.Rows[i]["BlockReason"].ToString();
                            obj.CPTCodeId = Convert.ToInt32(dsavailableService.Rows[i]["CPTCodeId"]);
                            obj.ExternalItem = Convert.ToInt32(dsavailableService.Rows[i]["ExternalItem"]);
                            obj.RGroupId = Convert.ToInt32(dsavailableService.Rows[i]["RGroupId"]);
                            obj.Rate = Convert.ToInt32(dsavailableService.Rows[i]["Rate"]);
                            obj.GroupName = dsavailableService.Rows[i]["GroupName"].ToString();
                            obj.GroupCode = dsavailableService.Rows[i]["GroupCode"].ToString();
                            obj.GroupCommPcnt = Convert.ToInt32(dsavailableService.Rows[i]["GroupCommPcnt"]);
                            obj.Category = dsavailableService.Rows[i]["Category"].ToString();
                            obj.GroupType = Convert.ToInt32(dsavailableService.Rows[i]["GroupType"]);
                            obj.GroupCommPcnt = Convert.ToInt32(dsavailableService.Rows[i]["GroupCommPcnt"]);
                            obj.Category = dsavailableService.Rows[i]["Category"].ToString();
                            obj.GroupType = Convert.ToInt32(dsavailableService.Rows[i]["GroupType"]);
                            obj.Rate = Convert.ToInt32(dsavailableService.Rows[i]["Rate"]);
                            obj.ItemStatus = dsavailableService.Rows[i]["ItemStatus"].ToString();
                            availableServiceList.Add(obj);
                        }
                    }
                    return availableServiceList;
                }
            }
        }

       

        /// <summary>
        /// Update Data in Number configuration table 
        /// </summary>
        /// <param name="num">Data in LH_Numbers Table</param>
        /// <returns>Success or reason for error</returns>
        public string InsertService(AvailableServiceModel asm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertServiceOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", asm.OrderId);
                    cmd.Parameters.AddWithValue("@OrderNo", asm.OrderNo);
                    cmd.Parameters.AddWithValue("@OrderDate", asm.OrderDate);
                    cmd.Parameters.AddWithValue("@PatientId", asm.PatientId);
                    cmd.Parameters.AddWithValue("@ConsultantId", asm.ConsultantId);
                    cmd.Parameters.AddWithValue("@ConsultationId", asm.ConsultationId);
                    cmd.Parameters.AddWithValue("@PackId", asm.PackId);
                    cmd.Parameters.AddWithValue("@PackNo", asm.PackNo);
                    cmd.Parameters.AddWithValue("@UserId", asm.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", asm.SessionId);
                    cmd.Parameters.AddWithValue("@BranchId", asm.BranchId);
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

    }
}
