using LeHealth.Core.Interface;
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
        public List<ProfileModel> GetProfile(ProfileModel pm)
        {
            List<ProfileModel> communicationTypeList = new List<ProfileModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using (SqlCommand cmd = new SqlCommand("stLH_GetProfile", con))
                {
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
                            ProfileModel obj = new ProfileModel();
                            obj.ProfileId = Convert.ToInt32(dsItemGroup.Rows[i]["ProfileId"]);
                            obj.ProfileDesc = dsItemGroup.Rows[i]["ProfileDesc"].ToString();
                            obj.Remarks = dsItemGroup.Rows[i]["Remarks"].ToString();
                            obj.Active = Convert.ToInt32(dsItemGroup.Rows[i]["Active"]);
                            obj.BlockReason = dsItemGroup.Rows[i]["BlockReason"].ToString();
                            communicationTypeList.Add(obj);
                        }
                    }
                    return communicationTypeList;
                }
            }
        }
        public List<ItemsByTypeModel> GetProfileItem(ProfileModel pm)
        {
            List<ItemsByTypeModel> communicationTypeList = new List<ItemsByTypeModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfileItem", con))
                {
                    int listcount = pm.ProfileIds.Count;
                    string ProfIds = "";
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
                int listcount = asm.GroupIdList.Count;
                string GroupIds = "";
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
        public List<AvailableServiceModel> GetLastConsultation(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLastConsultation", con))
                {
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
            }
        }

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
                    cmd.Parameters.AddWithValue("@PayStatus", Convert.ToInt32(cm.PayStatus));
                    cmd.Parameters.AddWithValue("@RegNo", cm.RegNo);
                    cmd.Parameters.AddWithValue("@PatientName", cm.PatientName);
                    cmd.Parameters.AddWithValue("@BranchId", cm.BranchId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dsavailableService = new DataTable();
                    adapter.Fill(dsavailableService);
                    con.Close();
                    int numberOfRecords = dsavailableService.AsEnumerable().Where(x => x["PayStatus"].ToString() == "Pending").ToList().Count;

                    if ((dsavailableService != null) && (dsavailableService.Rows.Count > 0))
                    {
                        for (Int32 i = 0; i < dsavailableService.Rows.Count; i++)
                        {
                            AvailableServiceModel obj = new AvailableServiceModel();
                            obj.OrderId = Convert.ToInt32(dsavailableService.Rows[i]["OrderId"]);
                            obj.SubId = Convert.ToInt32(dsavailableService.Rows[i]["SubId"]);
                            obj.SubType = dsavailableService.Rows[i]["SubType"].ToString();
                            obj.OrderDate = dsavailableService.Rows[i]["OrderDate"].ToString();
                            obj.OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString();
                            obj.ConsultantId = Convert.ToInt32(dsavailableService.Rows[i]["ConsultantId"]);
                            obj.ConsultantName = dsavailableService.Rows[i]["ConsultantName"].ToString();
                            obj.ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]);
                            obj.ItemName = dsavailableService.Rows[i]["ItemName"].ToString();
                            obj.FirstName = dsavailableService.Rows[i]["FirstName"].ToString();
                            obj.MiddleName = dsavailableService.Rows[i]["MiddleName"].ToString();
                            obj.LastName = dsavailableService.Rows[i]["LastName"].ToString();
                            obj.RegNo = dsavailableService.Rows[i]["RegNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsavailableService.Rows[i]["PatientId"]);
                            obj.Selected = Convert.ToInt32(dsavailableService.Rows[i]["Selected"]);
                            obj.ItemStatus = dsavailableService.Rows[i]["Status"].ToString();
                            obj.PayStatus = dsavailableService.Rows[i]["PayStatus"].ToString();
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

        public List<AvailableServiceModel> GetServicesOrderLoad(AvailableServiceModel cm)
        {
            List<AvailableServiceModel> availableServiceList = new List<AvailableServiceModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetServiceOrderLoad", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", cm.BranchId);

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
                            obj.SubId = Convert.ToInt32(dsavailableService.Rows[i]["SubId"]);
                            obj.SubType = dsavailableService.Rows[i]["SubType"].ToString();
                            obj.OrderDate = dsavailableService.Rows[i]["OrderDate"].ToString();
                            obj.OrderNo = dsavailableService.Rows[i]["OrderNo"].ToString();
                            obj.ConsultantName = dsavailableService.Rows[i]["ConsultantName"].ToString();
                            obj.ItemId = Convert.ToInt32(dsavailableService.Rows[i]["ItemId"]);
                            obj.ItemName = dsavailableService.Rows[i]["ItemName"].ToString();
                            obj.FirstName = dsavailableService.Rows[i]["FirstName"].ToString();
                            obj.MiddleName = dsavailableService.Rows[i]["MiddleName"].ToString();
                            obj.LastName = dsavailableService.Rows[i]["LastName"].ToString();
                            obj.RegNo = dsavailableService.Rows[i]["RegNo"].ToString();
                            obj.PatientId = Convert.ToInt32(dsavailableService.Rows[i]["PatientId"]);
                            obj.Selected = Convert.ToInt32(dsavailableService.Rows[i]["Selected"]);
                            obj.ItemStatus = dsavailableService.Rows[i]["Status"].ToString();
                            obj.PayStatus = dsavailableService.Rows[i]["PayStatus"].ToString();
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
                    //NEW START

                    List<ItemDataModel> servicepackageList = new List<ItemDataModel>();
                    List<ItemDataModel> serviceitemList = new List<ItemDataModel>();
                    for (int i = 0; i < asm.ItemObj.Count; i++)
                    {
                        if (asm.ItemObj[i].ItemType == "package")
                        {
                            servicepackageList.Add(new ItemDataModel { ItemId = asm.ItemObj[i].ItemId, ItemType = asm.ItemObj[i].ItemType });
                        }
                        else if (asm.ItemObj[i].ItemType == "profile" || asm.ItemObj[i].ItemType == "service")
                        {
                            serviceitemList.Add(new ItemDataModel { ItemId = asm.ItemObj[i].ItemId, ItemType = asm.ItemObj[i].ItemType });
                        }
                        else
                        {

                        }
                    }
                    string serviceitemString = JsonConvert.SerializeObject(serviceitemList);
                    string servicepackageString = JsonConvert.SerializeObject(servicepackageList);
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
                    //NEW START
                    cmd.Parameters.AddWithValue("@SerialNo", asm.SerialNo);
                    cmd.Parameters.AddWithValue("@LocationId", asm.LocationId);
                    cmd.Parameters.AddWithValue("@Status", asm.Status);
                    cmd.Parameters.AddWithValue("@PayStatus", asm.PayStatus);
                    cmd.Parameters.AddWithValue("@ItemJSON", serviceitemString);
                    cmd.Parameters.AddWithValue("@PackageJSON", servicepackageString);
                    //NEW END
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
        public string CancelServiceOrder(AvailableServiceModel asm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_CancelServiceOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", asm.Id);
                    cmd.Parameters.AddWithValue("@SubType", asm.SubType);
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
                        DataTable dscommunicationType = new DataTable();
                        adapter.Fill(dscommunicationType);
                        con.Close();
                        if ((dscommunicationType != null) && (dscommunicationType.Rows.Count > 0))
                        {
                            for (Int32 i = 0; i < dscommunicationType.Rows.Count; i++)
                            {
                                ServiceGroupModel obj = new ServiceGroupModel();
                                obj.GroupId = Convert.ToInt32(dscommunicationType.Rows[i]["groupId"]);
                                obj.Label = dscommunicationType.Rows[i]["label"].ToString();
                                obj.Children = JsonConvert.DeserializeObject<List<ServiceGroupModel>>(dscommunicationType.Rows[i]["children"].ToString());
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
