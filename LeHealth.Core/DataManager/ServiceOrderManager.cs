﻿using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        /// <summary>
        /// Get all items data in a group if groupId =0 else returns details of a specific Group
        /// </summary>
        /// <param name="groupid">Data in LH_ItemGroup Table</param>
        /// <returns>Profile list</returns>
        public List<GroupModel> GetItemsGroup(int groupId)
        {
            List<GroupModel> communicationTypeList = new List<GroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemGroup", con);
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
        /// <summary>
        /// Get service items in a package
        /// </summary>
        /// <param name="pm">Data in LH_PackageItem Table</param>
        /// <returns>Package Item list</returns>
        public List<ItemsByTypeModel> GetPackageItem(int packId)
        {
            List<ItemsByTypeModel> communicationTypeList = new List<ItemsByTypeModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPackageItem", con);
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
                    ItemsByTypeModel obj = new ItemsByTypeModel
                    {
                        ItemId = Convert.ToInt32(dsItemGroup.Rows[i]["ItemId"]),
                        ItemCode = dsItemGroup.Rows[i]["ItemCode"].ToString(),
                        ItemName = dsItemGroup.Rows[i]["ItemName"].ToString(),
                        Rate = Convert.ToInt32(dsItemGroup.Rows[i]["Rate"]),
                        Quantity = Convert.ToInt32(dsItemGroup.Rows[i]["Quantity"])
                    };
                    communicationTypeList.Add(obj);
                }
            }
            return communicationTypeList;
        }
        /// <summary>
        /// Get all profile data or specific profiles data if pm.ProfileId equals zero
        /// </summary>
        /// <param name="pm">Data in LH_Profile Table</param>
        /// <returns>Profile list</returns>

        /// <summary>
        /// API For getting profile list
        /// </summary>
        /// <param name="pm">if profile id is zero then returns all profile names. else returns specific profile details</param>
        /// <returns>Profile list</returns>
        public List<ProfileModel> GetProfile(ProfileModel pm)
        {
            List<ProfileModel> profileList = new List<ProfileModel>();

            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetProfile", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProfileId", pm.ProfileId);
            cmd.Parameters.AddWithValue("@Active", pm.Active);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsItemGroup = new DataTable();
            adapter.Fill(dsItemGroup);
            con.Close();
            if ((dsItemGroup != null) && (dsItemGroup.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsItemGroup.Rows.Count; i++)
                {
                    ProfileModel obj = new ProfileModel
                    {
                        ProfileId = Convert.ToInt32(dsItemGroup.Rows[i]["ProfileId"]),
                        ProfileDesc = dsItemGroup.Rows[i]["ProfileDesc"].ToString(),
                        Remarks = dsItemGroup.Rows[i]["Remarks"].ToString(),
                        Active = Convert.ToInt32(dsItemGroup.Rows[i]["Active"]),
                        BlockReason = dsItemGroup.Rows[i]["BlockReason"].ToString()
                    };
                    profileList.Add(obj);
                }
            }
            return profileList;
        }
        /// <summary>
        /// Get all items in a profile 
        /// </summary>
        /// <param name="pm">Data in LH_ProfileItem Table</param>
        /// <returns>Items in profile list</returns>
        public List<ItemsByTypeModel> GetProfileItem(ProfileModel pm)
        {
            List<ItemsByTypeModel> profileItemList = new List<ItemsByTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfileItem", con))
                {
                    int listcount = pm.ProfileIds.Count;
                    string ProfIds = string.Empty;
                    if (listcount > 0)
                        ProfIds = string.Join(",", pm.ProfileIds.ToArray());
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfileId", ProfIds);
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
                            profileItemList.Add(obj);
                        }
                    }
                    return profileItemList;
                }
            }
        }
        /// <summary>
        /// Get services data in a branch 
        /// </summary>
        /// <param name="pm">Data in LH_Service Table</param>
        /// <returns>service items list</returns>
        public List<AvailableServiceModel> GetAvailableService(AvailableServiceModel asm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                int listcount = asm.GroupIdList.Count;
                string GroupIds = string.Empty;
                if (listcount > 0)
                    GroupIds = string.Join(",", asm.GroupIdList.ToArray());
                using (SqlCommand cmd = new SqlCommand("stLH_GetServiceItemsOfGroup", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", GroupIds);
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
                            obj.GroupId = Convert.ToInt32(dsavailableService.Rows[i]["GroupId"]);
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
        /// Get last consultation data of a patient with specific consultant
        /// </summary>
        /// <param name="asm">Data in LH_Consultation Table</param>
        /// <returns>Latest consultation data</returns>
        public List<AvailableServiceModel> GetLastConsultation(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLastConsultation", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
            cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsavailableService = new DataTable();
            adapter.Fill(dsavailableService);
            con.Close();
            if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                {
                    AvailableServiceModel obj = new AvailableServiceModel();
                    obj.ConsultationId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultationId"]);
                    obj.ConsultDate = dsavailableService.Rows[i]["ConsultDate"].ToString();
                    obj.ConsultantId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultantId"]);
                    availableServiceList.Add(obj);
                }
            }
            return availableServiceList;
        }
        /// <summary>
        /// Search service data
        /// </summary>
        /// <param name="asm">Search Data in LH_Service Table</param>
        /// <returns>Service list</returns>
        public List<AvailableServiceModel> GetServicesOrderByDate(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetServiceOrderByDate", con))
                {
                    con.Open();
                    if (cm.OrderFromDate.Trim() != "" && cm.OrderToDate.Trim() != "")
                    {
                        DateTime orderFromDate = DateTime.ParseExact(cm.OrderFromDate.Trim(), "dd-MM-yyyy", null);
                        cm.OrderFromDate = orderFromDate.ToString("yyyy-MM-dd");
                        DateTime orderToDate = DateTime.ParseExact(cm.OrderToDate.Trim(), "dd-MM-yyyy", null);
                        cm.OrderToDate = orderToDate.ToString("yyyy-MM-dd");
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderFromDate", cm.OrderFromDate);
                    cmd.Parameters.AddWithValue("@OrderToDate", cm.OrderToDate);
                    cmd.Parameters.AddWithValue("@PatientId", cm.PatientId);
                    cmd.Parameters.AddWithValue("@OrderNo", cm.OrderNo);
                    cmd.Parameters.AddWithValue("@RegNo", cm.RegNo);
                    cmd.Parameters.AddWithValue("@PatientName", cm.PatientName);
                    cmd.Parameters.AddWithValue("@BranchId", cm.BranchId);
                    cmd.Parameters.AddWithValue("@ConsultantId", cm.ConsultantId);
                    cmd.Parameters.AddWithValue("@IsExternal", cm.IsExternalConsultant);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsavailableService = new DataTable();
                    adapter.Fill(dsavailableService);
                    con.Close();
                    int numberOfRecords = 0;//dsavailableService.AsEnumerable().Where(x => x["PayStatus"].ToString() == "Pending").ToList().Count;

                    if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                        {
                            AvailableServiceModel obj = new AvailableServiceModel();
                            obj.OrderId = Convert.ToInt32(dsavailableService.Rows[i]["OrderId"]);
                            obj.OrderDate = dsavailableService.Rows[i]["OrderDate"].ToString();
                            obj.OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString();
                            obj.ConsultantId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultantId"]);
                            obj.ConsultantName = dsavailableService.Rows[i]["ConsultantName"].ToString();
                            obj.FirstName = dsavailableService.Rows[i]["FirstName"].ToString();
                            obj.MiddleName = dsavailableService.Rows[i]["MiddleName"].ToString();
                            obj.LastName = dsavailableService.Rows[i]["LastName"].ToString();
                            obj.RegNo = dsavailableService.Rows[i]["RegNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsavailableService.Rows[i]["PatientId"]);
                            obj.Selected = Convert.ToInt32(dsavailableService.Rows[i]["Selected"]);
                            obj.Mobile = dsavailableService.Rows[i]["Mobile"].ToString();
                            obj.ResNo = dsavailableService.Rows[i]["ResNo"].ToString();
                            obj.ConsultationId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultationId"]);
                            obj.BranchId = Convert.ToInt32(dsavailableService.Rows[i]["BranchId"]);
                            obj.IsExternalConsultant = Convert.ToInt32(dsavailableService.Rows[i]["ExternalConsultant"]);
                            obj.PendingOrderCount = numberOfRecords;
                            availableServiceList.Add(obj);
                        }
                    }
                    return availableServiceList;
                }
            }
        }
        /// <summary>
        /// Get service data on page load.
        /// </summary>
        /// <param name="asm">Data in LH_Service Table</param>
        /// <returns>List of service data as per filter conditions </returns>
        public List<AvailableServiceModel> GetServicesOrderLoad(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetServiceOrderLoad", con))
                {
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
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsavailableService = new DataTable();
                    adapter.Fill(dsavailableService);
                    con.Close();
                    if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                        {
                            AvailableServiceModel obj = new AvailableServiceModel();
                            obj.OrderId = Convert.ToInt32(dsavailableService.Rows[i]["OrderId"]);
                            obj.OrderDate = dsavailableService.Rows[i]["OrderDate"].ToString();
                            obj.OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString();
                            obj.ConsultantName = dsavailableService.Rows[i]["ConsultantName"].ToString();
                            obj.FirstName = dsavailableService.Rows[i]["FirstName"].ToString();
                            obj.MiddleName = dsavailableService.Rows[i]["MiddleName"].ToString();
                            obj.LastName = dsavailableService.Rows[i]["LastName"].ToString();
                            obj.RegNo = dsavailableService.Rows[i]["RegNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsavailableService.Rows[i]["PatientId"]);
                            obj.Selected = Convert.ToInt32(dsavailableService.Rows[i]["Selected"]);
                            obj.IsCancelled = Convert.ToInt32(dsavailableService.Rows[i]["IsCancelled"]);
                            obj.Mobile = dsavailableService.Rows[i]["Mobile"].ToString();
                            obj.ResNo = dsavailableService.Rows[i]["ResNo"].ToString();
                            obj.ConsultationId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultationId"]);
                            availableServiceList.Add(obj);
                        }
                    }
                    return availableServiceList;
                }
            }
        }
        /// <summary>
        /// Get service order's itemdetails 
        /// </summary>
        /// <param name="cm">Data in  LH_ServiceDet Table</param>
        /// <returns>Item Data list</returns>
        public List<AvailableServiceModel> GetServicesOrderDetailById(int sid)
        {
            List<AvailableServiceModel> ServiceorderItemList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetServicesOrderDetailById", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", sid);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsavailableService = new DataTable();
                    adapter.Fill(dsavailableService);
                    con.Close();
                    if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                        {
                            AvailableServiceModel obj = new AvailableServiceModel();
                            obj.OrderId = Convert.ToInt32(dsavailableService.Rows[i]["OrderId"]);
                            obj.OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString();
                            obj.ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]);
                            obj.ItemName = dsavailableService.Rows[i]["ItemName"].ToString();
                            obj.ItemStatus = dsavailableService.Rows[i]["Status"].ToString();
                            obj.PayStatus = dsavailableService.Rows[i]["PayStatus"].ToString();
                            ServiceorderItemList.Add(obj);
                        }
                    }
                    return ServiceorderItemList;
                }
            }
        }

        /// <summary>
        /// Insert service data, Not using now 
        /// </summary>
        /// <param name="asm">Data in LH_Service, LH_ServiceDet Table</param>
        /// <returns>Success or reason for error</returns>
        public string InsertService(AvailableServiceModel asm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertServiceOrder", con))
                {
                    //NEW START
                    string serviceitemString = JsonConvert.SerializeObject(asm.ItemObj);
                    DateTime orderDate = DateTime.ParseExact(asm.OrderDate.Trim(), "dd-MM-yyyy", null);
                    asm.OrderDate = orderDate.ToString("yyyy-MM-dd");
                    //NEW END
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", 0);
                    cmd.Parameters.AddWithValue("@OrderNo", asm.OrderNo);
                    cmd.Parameters.AddWithValue("@OrderDate", asm.OrderDate);
                    cmd.Parameters.AddWithValue("@PatientId", asm.PatientId);
                    cmd.Parameters.AddWithValue("@ConsultantId", asm.ConsultantId);
                    cmd.Parameters.AddWithValue("@ConsultationId", asm.ConsultationId);
                    cmd.Parameters.AddWithValue("@PackId", asm.PackId);
                    cmd.Parameters.AddWithValue("@PackNo", asm.PackNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asm.SerialNo);
                    cmd.Parameters.AddWithValue("@LocationId", asm.LocationId);
                    cmd.Parameters.AddWithValue("@Status", asm.Status);
                    cmd.Parameters.AddWithValue("@PayStatus", asm.PayStatus);
                    cmd.Parameters.AddWithValue("@ItemJSON", serviceitemString);
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
        /// <summary>
        /// Insert service data
        /// </summary>
        /// <param name="asm">Data in LH_Service, LH_ServiceDet Table</param>
        /// <returns>Success or reason for error</returns>
        public ServiceInsertResponse InsertServiceNew(ServiceInsertInputModel asm)
        {
            ServiceInsertResponse response = new ServiceInsertResponse();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_InsertServiceOrder", con))
                {
                    List<PackageItemsModel> allItemListObj = new List<PackageItemsModel>();
                    List<int> packageListObj = new List<int>();
                    for (int i = 0; i < asm.ItemObj.Count; i++)
                    {
                        if (asm.ItemObj[i].itemType == 2)
                        {
                            packageListObj.Add(asm.ItemObj[i].itemTypeId);
                        }
                        String itemdata = asm.ItemObj[i].itemId.ToString();
                        var isNumeric = int.TryParse(itemdata, out int n);
                        if (isNumeric == true)
                        {
                            PackageItemsModel obj = new PackageItemsModel();
                            obj.itemId = Convert.ToInt32(itemdata);
                            obj.rate = asm.ItemObj[i].rate;
                            allItemListObj.Add(obj);
                        }
                        else
                        {
                            List<PackageItemsModel> objResponse1 = JsonConvert.DeserializeObject<List<PackageItemsModel>>(itemdata);
                            allItemListObj.AddRange(objResponse1);
                        }
                    }
                    string serviceitemString = JsonConvert.SerializeObject(allItemListObj);
                    string packageString = string.Join(",", packageListObj.ToArray());
                    DateTime orderDate = DateTime.ParseExact(asm.OrderDate.Trim(), "dd-MM-yyyy", null);
                    asm.OrderDate = orderDate.ToString("yyyy-MM-dd");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", 0);
                    cmd.Parameters.AddWithValue("@OrderNo", asm.OrderNo);
                    cmd.Parameters.AddWithValue("@OrderDate", asm.OrderDate);
                    cmd.Parameters.AddWithValue("@PatientId", asm.PatientId);
                    cmd.Parameters.AddWithValue("@ConsultantId", asm.ConsultantId);
                    cmd.Parameters.AddWithValue("@ConsultationId", asm.ConsultationId);
                    cmd.Parameters.AddWithValue("@PackId", asm.PackId);
                    cmd.Parameters.AddWithValue("@PackNo", asm.PackNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asm.SerialNo);
                    cmd.Parameters.AddWithValue("@LocationId", asm.LocationId);
                    cmd.Parameters.AddWithValue("@Status", asm.Status);
                    cmd.Parameters.AddWithValue("@PayStatus", asm.PayStatus);
                    cmd.Parameters.AddWithValue("@ItemJSON", serviceitemString);
                    cmd.Parameters.AddWithValue("@PackageString", packageString);
                    cmd.Parameters.AddWithValue("@UserId", asm.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", asm.SessionId);
                    cmd.Parameters.AddWithValue("@BranchId", asm.BranchId);
                    SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retValV);
                    SqlParameter retOrderNo = new SqlParameter("@RetOrderNo", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retOrderNo);
                    SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retDesc);
                    con.Open();
                    var isUpdated = cmd.ExecuteNonQuery();
                    var ret = retValV.Value;
                    var orderNo = retOrderNo.Value.ToString();
                    var descrip = retDesc.Value.ToString();
                    con.Close();
                    if (descrip == "Saved Successfully")
                    {
                        response.orderNo = orderNo;
                        response.serviceOrderId = Convert.ToInt32(ret);
                        response.responseMessage = "Success";
                    }
                    else
                    {
                        response.orderNo = "";
                        response.serviceOrderId = 0;
                        response.responseMessage = descrip;
                    }
                }
            }
            return response;
        }
        /// <summary>
        /// Cancelling Service order
        /// </summary>
        /// <param name="asm">Change status Data LH_ServiceDet Table</param>
        /// <returns>Success or reason for error</returns>
        public string CancelServiceOrder(AvailableServiceModel asm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_CancelServiceOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", asm.ItemId);
                    cmd.Parameters.AddWithValue("@OrderId", asm.OrderId);
                    cmd.Parameters.AddWithValue("@CancelReason", asm.CancelReason);
                    cmd.Parameters.AddWithValue("@UserId", asm.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", asm.SessionId);
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
        /// Get service group list
        /// </summary>
        /// <param name="asm">Data in LH_ServiceGroup Table</param>
        /// <returns>Service group list</returns>
        public List<ServiceGroupModel> GetServicesGroups()
        {
            try
            {
                List<ServiceGroupModel> serviceModels = new List<ServiceGroupModel>();
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("stLH_GetServiceGroups", con))
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dsserviceGroup = new DataTable();
                        adapter.Fill(dsserviceGroup);
                        con.Close();
                        if ((dsserviceGroup != null) && (dsserviceGroup.Rows.Count > 0))
                        {
                            for (Int32 i = 0; i < dsserviceGroup.Rows.Count; i++)
                            {
                                ServiceGroupModel obj = new ServiceGroupModel();
                                obj.GroupId = Convert.ToInt32(dsserviceGroup.Rows[i]["groupId"]);
                                obj.Label = dsserviceGroup.Rows[i]["label"].ToString();
                                obj.Children = JsonConvert.DeserializeObject<List<ServiceGroupModel>>(dsserviceGroup.Rows[i]["children"].ToString());
                                serviceModels.Add(obj);
                            }
                        }
                        return serviceModels;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
