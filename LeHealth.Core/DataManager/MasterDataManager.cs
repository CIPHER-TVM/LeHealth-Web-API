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
using Newtonsoft.Json;
using System.Linq;

namespace LeHealth.Core.DataManager
{
    //LH_ItemGroup Should not be used, Instead of it, use LH_ServiceGroup.
    //111 pass cheythu data edukkunna dropdown check
    public class MasterDataManager : IMasterDataManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        public List<ServiceConfigModel> GetServiceItem(AvailableServiceModel company)
        {
            List<ServiceConfigModel> serviceItemList = new List<ServiceConfigModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemDetailById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemId", company.Id);
            cmd.Parameters.AddWithValue("@ShowAll", company.ShowAll);
            cmd.Parameters.AddWithValue("@GroupId", company.GroupId);
            cmd.Parameters.AddWithValue("@BranchId", company.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtServiceItem = new DataTable();
            adapter.Fill(dtServiceItem);
            con.Close();
            if ((dtServiceItem != null) && (dtServiceItem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtServiceItem.Rows.Count; i++)
                {
                    ServiceConfigModel obj = new ServiceConfigModel();
                    obj.ItemId = Convert.ToInt32(dtServiceItem.Rows[i]["ItemId"]);
                    obj.ItemCode = dtServiceItem.Rows[i]["ItemCode"].ToString();
                    obj.ItemName = dtServiceItem.Rows[i]["ItemName"].ToString();
                    obj.GroupId = Convert.ToInt32(dtServiceItem.Rows[i]["GroupId"]);
                    obj.ValidityDays = Convert.ToInt32(dtServiceItem.Rows[i]["ValidityDays"]);
                    obj.ValidityVisits = Convert.ToInt32(dtServiceItem.Rows[i]["ValidityVisits"]);
                    obj.AllowRateEdit = Convert.ToBoolean(dtServiceItem.Rows[i]["AllowRateEdit"]);
                    obj.AllowDisc = Convert.ToBoolean(dtServiceItem.Rows[i]["AllowDisc"]);
                    obj.AllowPP = Convert.ToBoolean(dtServiceItem.Rows[i]["AllowPP"]);
                    obj.IsVSign = Convert.ToBoolean(dtServiceItem.Rows[i]["IsVSign"]);
                    obj.ResultOn = Convert.ToInt32(dtServiceItem.Rows[i]["ResultOn"]);
                    obj.STypeId = Convert.ToInt32(dtServiceItem.Rows[i]["STypeId"]);
                    obj.TotalTaxPcnt = Convert.ToInt32(dtServiceItem.Rows[i]["TotalTaxPcnt"]);
                    obj.AllowCommission = Convert.ToBoolean(dtServiceItem.Rows[i]["AllowCommission"]);
                    obj.CommPcnt = Convert.ToInt32(dtServiceItem.Rows[i]["CommPcnt"]);
                    obj.CommAmt = Convert.ToInt32(dtServiceItem.Rows[i]["CommAmt"]);
                    obj.MaterialCost = Convert.ToInt32(dtServiceItem.Rows[i]["MaterialCost"]);
                    obj.BaseCost = Convert.ToInt32(dtServiceItem.Rows[i]["BaseCost"]);
                    obj.HeadId = Convert.ToInt32(dtServiceItem.Rows[i]["HeadId"]);
                    obj.SortOrder = Convert.ToInt32(dtServiceItem.Rows[i]["SortOrder"]);
                    obj.IsDeleted = Convert.ToInt32(dtServiceItem.Rows[i]["IsDeleted"]);
                    obj.BlockReason = dtServiceItem.Rows[i]["BlockReason"].ToString();
                    obj.CPTCodeId = Convert.ToInt32(dtServiceItem.Rows[i]["CPTCodeId"]);
                    obj.ExternalItem = Convert.ToBoolean(dtServiceItem.Rows[i]["ExternalItem"]);
                    obj.GroupName = dtServiceItem.Rows[i]["GroupName"].ToString();
                    obj.GroupCode = dtServiceItem.Rows[i]["GroupCode"].ToString();
                    obj.GroupCommPcnt = (float)Convert.ToDouble(dtServiceItem.Rows[i]["GroupCommPcnt"]);
                    obj.Category = dtServiceItem.Rows[i]["Category"].ToString();
                    obj.GroupType = Convert.ToInt32(dtServiceItem.Rows[i]["GroupType"]);
                    obj.DrugTypeId = Convert.ToInt32(dtServiceItem.Rows[i]["DrugTypeId"]);
                    obj.VaccineTypeId = Convert.ToInt32(dtServiceItem.Rows[i]["VaccineTypeId"]);
                    obj.DefaultTAT = dtServiceItem.Rows[i]["DefaultTAT"].ToString();
                    obj.StaffMandatory = Convert.ToBoolean(dtServiceItem.Rows[i]["StaffMandatory"]);
                    obj.ContainerId = Convert.ToInt32(dtServiceItem.Rows[i]["ContainerId"]);
                    obj.IsDisplayed = Convert.ToBoolean(dtServiceItem.Rows[i]["IsDisplayed"]);
                    //obj.ItemRateList = JsonConvert.DeserializeObject<List<RateModel>>(dtServiceItem.Rows[i]["RateData"].ToString());
                    serviceItemList.Add(obj);
                }
            }
            return serviceItemList;
        }
        public List<RateModel> GetItemRateAmountById(AvailableServiceModel company)
        {
            List<RateModel> serviceItemList = new List<RateModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemRateAmountById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemId", company.Id);
            cmd.Parameters.AddWithValue("@BranchId", company.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtServiceItem = new DataTable();
            adapter.Fill(dtServiceItem);
            con.Close();
            if ((dtServiceItem != null) && (dtServiceItem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtServiceItem.Rows.Count; i++)
                {
                    RateModel obj = new RateModel();
                    obj.RGroupId = Convert.ToInt32(dtServiceItem.Rows[i]["RGroupId"]);
                    obj.RGroupName = dtServiceItem.Rows[i]["RGroupName"].ToString();
                    obj.RateStr = dtServiceItem.Rows[i]["RateStr"].ToString();
                    serviceItemList.Add(obj);
                }
            }
            return serviceItemList;
        }
        public string InsertUpdateServiceItem(ServiceConfigModelAll serviceItemModel)//(ServiceItemModel serviceItemModel)
        {
            string response1 = string.Empty;
            string response2 = string.Empty;
            string response3 = string.Empty;
            string responseFinal = string.Empty;
            //int GroupId = 0;
            //int ChildId = 0;
            //if (serviceItemModel.ParentId == 0)
            //{
            //   GroupId = serviceItemModel.GroupId;
            //    ChildId = 0;
            //}
            //else
            //{
            //    GroupId = serviceItemModel.ParentId;
            //    ChildId = serviceItemModel.GroupId;
            //}
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd1 = new SqlCommand("stLH_InsertUpdateItemMaster", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
                cmd1.Parameters.AddWithValue("@ItemCode", serviceItemModel.ItemCode);
                cmd1.Parameters.AddWithValue("@ItemName", serviceItemModel.ItemName);
                cmd1.Parameters.AddWithValue("@GroupId", serviceItemModel.GroupId);
                //cmd1.Parameters.AddWithValue("@ChildGroupId", ChildId);
                cmd1.Parameters.AddWithValue("@ValidityDays", serviceItemModel.ValidityDays);
                cmd1.Parameters.AddWithValue("@ValidityVisits", serviceItemModel.ValidityVisits);
                cmd1.Parameters.AddWithValue("@AllowRateEdit", serviceItemModel.AllowRateEdit);
                cmd1.Parameters.AddWithValue("@AllowDisc", serviceItemModel.AllowDisc);
                cmd1.Parameters.AddWithValue("@AllowPP", serviceItemModel.AllowPP);
                cmd1.Parameters.AddWithValue("@IsVSign", serviceItemModel.IsVSign);
                cmd1.Parameters.AddWithValue("@ResultOn", serviceItemModel.ResultOn);
                cmd1.Parameters.AddWithValue("@STypeId", serviceItemModel.STypeId);
                cmd1.Parameters.AddWithValue("@TotalTaxPcnt", serviceItemModel.TotalTaxPcnt);
                cmd1.Parameters.AddWithValue("@AllowCommission", serviceItemModel.AllowCommission);
                cmd1.Parameters.AddWithValue("@CommPcnt", serviceItemModel.CommPcnt);
                cmd1.Parameters.AddWithValue("@CommAmt", serviceItemModel.CommAmt);
                cmd1.Parameters.AddWithValue("@MaterialCost", serviceItemModel.MaterialCost);
                cmd1.Parameters.AddWithValue("@BaseCost", serviceItemModel.BaseCost);
                cmd1.Parameters.AddWithValue("@HeadId", serviceItemModel.HeadId);
                cmd1.Parameters.AddWithValue("@SortOrder", serviceItemModel.SortOrder);
                cmd1.Parameters.AddWithValue("@UserId", serviceItemModel.UserId);
                cmd1.Parameters.AddWithValue("@SessionId", serviceItemModel.SessionId);
                cmd1.Parameters.AddWithValue("@BranchId", serviceItemModel.BranchId);
                cmd1.Parameters.AddWithValue("@ExternalItem", serviceItemModel.ExternalItem);
                cmd1.Parameters.AddWithValue("@CPTCodeId", serviceItemModel.CPTCodeId);
                cmd1.Parameters.AddWithValue("@DrugTypeId", serviceItemModel.DrugTypeId);
                cmd1.Parameters.AddWithValue("@VaccineTypeId", serviceItemModel.VaccineTypeId);
                cmd1.Parameters.AddWithValue("@DefaultTAT", serviceItemModel.DefaultTAT);
                cmd1.Parameters.AddWithValue("@StaffMandatory", serviceItemModel.StaffMandatory);
                cmd1.Parameters.AddWithValue("@ContainerId", serviceItemModel.ContainerId);
                cmd1.Parameters.AddWithValue("@IsDisplayed", serviceItemModel.IsDisplayed);
                SqlParameter retValV1 = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd1.Parameters.Add(retValV1);
                SqlParameter retDesc1 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd1.Parameters.Add(retDesc1);
                con.Open();
                var isUpdated1 = cmd1.ExecuteNonQuery();
                var ret1 = retValV1.Value;
                var descrip1 = retDesc1.Value.ToString();
                con.Close();
                if (descrip1 == "Saved Successfully")
                {
                    response1 = "Success";
                    serviceItemModel.ItemId = Convert.ToInt32(ret1);
                }
                else
                {
                    response1 = descrip1;
                    return response1;
                }
                if (response1 == "Success")
                {
                    using SqlCommand cmd2 = new SqlCommand("stLH_InsertItemTax", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    int listcount = serviceItemModel.ItemTaxList.Count;
                    string TaxIds = "";
                    if (listcount > 0)
                    {
                        TaxIds = string.Join(",", serviceItemModel.ItemTaxList.ToArray());
                        cmd2.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
                        cmd2.Parameters.AddWithValue("@TaxIds", TaxIds);
                        cmd2.Parameters.AddWithValue("@UserId", serviceItemModel.UserId);
                        SqlParameter retValV2 = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd2.Parameters.Add(retValV2);
                        SqlParameter retDesc2 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd2.Parameters.Add(retDesc2);
                        con.Open();
                        var isUpdated2 = cmd2.ExecuteNonQuery();
                        var ret2 = retValV2.Value;
                        var descrip2 = retDesc2.Value.ToString();
                        con.Close();
                        if (descrip2 == "Saved Successfully")
                        {
                            response2 = "Success";
                        }
                    }
                    else
                    {
                        response2 = "Success";
                    }
                }
                if (response2 == "Success")
                {
                    using SqlCommand cmd3 = new SqlCommand("stLH_InsertUpdateItemRate", con);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
                    string rateString = JsonConvert.SerializeObject(serviceItemModel.ItemRateList);
                    cmd3.Parameters.AddWithValue("@RateJSON", rateString);
                    cmd3.Parameters.AddWithValue("@UserId", serviceItemModel.UserId);
                    SqlParameter retValV3 = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd3.Parameters.Add(retValV3);
                    SqlParameter retDesc3 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd3.Parameters.Add(retDesc3);
                    con.Open();
                    var isUpdated3 = cmd3.ExecuteNonQuery();
                    var ret3 = retValV3.Value;
                    var descrip3 = retDesc3.Value.ToString();
                    con.Close();
                    if (descrip3 == "Saved Successfully")
                    {
                        response3 = "Success";
                    }
                }
                if (response1 == "Success" && response2 == "Success" && response3 == "Success")
                {
                    responseFinal = "Success";
                }
                else
                {
                    responseFinal = "Error";
                }
            }
            return responseFinal;
        }
        public string DeleteServiceItem(ServiceItemModel serviceItemModel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteServiceItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", serviceItemModel.ItemId);
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
        public string InsertUpdateServiceItemGroup(ServiceConfigModel ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateServiceItemGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupId", ccm.GroupId);
                cmd.Parameters.AddWithValue("@ParentId", ccm.ParentId);
                cmd.Parameters.AddWithValue("@GroupName", ccm.GroupName);
                cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
                cmd.Parameters.AddWithValue("@UserId", ccm.UserId);
                cmd.Parameters.AddWithValue("@IsDeleting", ccm.IsDeleting);
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
                if (descrip == "Success")
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
        public List<CommonMasterFieldModel> GetCPTCode(CommonMasterFieldModelAll ccm)
        {
            List<CommonMasterFieldModel> profList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCPTCode", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPTCodeId", ccm.Id);
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
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dtCPT.Rows[i]["CPTCodeId"]),
                        CodeData = dtCPT.Rows[i]["CPTCode"].ToString(),
                        DescriptionData = dtCPT.Rows[i]["CPTDesc"].ToString(),
                        IsDisplayed = Convert.ToInt32(dtCPT.Rows[i]["IsDisplayed"]),
                    };
                    profList.Add(obj);
                }
            }
            return profList;
        }
        public string InsertUpdateCPTCode(CommonMasterFieldModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCPTCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CPTCodeId", ccm.Id);
                cmd.Parameters.AddWithValue("@CPTCode", ccm.CodeData);
                cmd.Parameters.AddWithValue("@CPTDesc", ccm.DescriptionData);
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
        public CommunicationConfigurationModel GetCommunicationConfiguration(CommunicationConfigurationModel ccm)
        {
            CommunicationConfigurationModel profList = new CommunicationConfigurationModel();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCommunicationConfiguration", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtCPT = new DataTable();
            adapter.Fill(dtCPT);
            con.Close();
            if ((dtCPT != null) && (dtCPT.Rows.Count > 0))
            {
                profList = new CommunicationConfigurationModel
                {
                    BranchId = Convert.ToInt32(dtCPT.Rows[0]["BranchId"]),
                    APIUrl = dtCPT.Rows[0]["APIUrl"].ToString(),
                    UserName = dtCPT.Rows[0]["UserName"].ToString(),
                    SMSPassword = dtCPT.Rows[0]["SMSPasswordData"].ToString(),
                    MailSender = dtCPT.Rows[0]["MailSender"].ToString(),
                    MailPassword = dtCPT.Rows[0]["MailPasswordData"].ToString(),
                    SMTP = dtCPT.Rows[0]["SMTP"].ToString(),
                    SMTPPort = Convert.ToInt32(dtCPT.Rows[0]["SMTPPort"]),
                };
            }
            return profList;
        }
        public string InsertUpdateCommunicationConfiguration(CommunicationConfigurationModel ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCommunicationConfiguration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchId", ccm.BranchId);
                cmd.Parameters.AddWithValue("@APIUrl", ccm.APIUrl);
                cmd.Parameters.AddWithValue("@UserName", ccm.UserName);
                cmd.Parameters.AddWithValue("@SMSPassword", ccm.SMSPassword);
                cmd.Parameters.AddWithValue("@MailSender", ccm.MailSender);
                cmd.Parameters.AddWithValue("@MailPassword", ccm.MailPassword);
                cmd.Parameters.AddWithValue("@SMTP", ccm.SMTP);
                cmd.Parameters.AddWithValue("@SMTPPort", ccm.SMTPPort);
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
        public List<NationalityGroupModel> GetNationalityGroup(NationalityGroupModelAll ccm)
        {
            List<NationalityGroupModel> ngroupList = new List<NationalityGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetNationalityGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NGrpId", ccm.NGroupId);
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
                    NationalityGroupModel obj = new NationalityGroupModel
                    {
                        NGroupId = Convert.ToInt32(dtCPT.Rows[i]["NGroupId"]),
                        NGroupDesc = dtCPT.Rows[i]["NGroupDesc"].ToString(),
                        RegionCode = dtCPT.Rows[i]["RegionCode"].ToString(),
                        IsDisplayed = Convert.ToInt32(dtCPT.Rows[i]["IsDisplayed"]),
                    };
                    ngroupList.Add(obj);
                }
            }
            return ngroupList;
        }
        public string InsertUpdateNationalityGroup(NationalityGroupModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateNationalityGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NGrpId", ccm.NGroupId);
                cmd.Parameters.AddWithValue("@NGrpDesc", ccm.NGroupDesc);
                cmd.Parameters.AddWithValue("@RegionCode", ccm.RegionCode);
                cmd.Parameters.AddWithValue("@UserId", ccm.UserId);
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
        public string DeleteNationalityGroup(NationalityGroupModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteNationalityGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NGroupId", ccm.NGroupId);
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
        public List<CardTypeModel> GetCardType(CardTypeModelAll ctm)
        {
            List<CardTypeModel> ctList = new List<CardTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCard", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CardId", ctm.CardId);
            cmd.Parameters.AddWithValue("@ShowAll", ctm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", ctm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtCT = new DataTable();
            adapter.Fill(dtCT);
            con.Close();
            if ((dtCT != null) && (dtCT.Rows.Count > 0))
            {
                ctList = dtCT.ToListOfObject<CardTypeModel>();
            }
            return ctList;
        }
        public string InsertUpdateCardType(CardTypeModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CardId", ccm.CardId);
                cmd.Parameters.AddWithValue("@CardName", ccm.CardName);
                cmd.Parameters.AddWithValue("@ServiceCharge", ccm.ServiceCharge);
                cmd.Parameters.AddWithValue("@UserId", ccm.UserId);
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
        public string DeleteCardType(CardTypeModelAll ccm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ccm.CardId);
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
            List<CPTModifierModel> cptModifierList = new List<CPTModifierModel>();
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
                cptModifierList = dtCPT.ToListOfObject<CPTModifierModel>();
            return cptModifierList;
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
                cmd.Parameters.AddWithValue("@CPTModifierDesc", ccm.CPTDescription);
                cmd.Parameters.AddWithValue("@UserId", ccm.UserId);
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
                cmd.Parameters.AddWithValue("@UserId", ccm.UserId);
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
        public List<ItemRateModel> GetStandardRate(RateGroupModelAll rm)
        {
            List<ItemRateModel> standardRateList = new List<ItemRateModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetStandardRate", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            int listcount = rm.ItemIds.Count;
            string ItemIds = "";
            if (listcount > 0)
                ItemIds = string.Join(",", rm.ItemIds.ToArray());
            cmd.Parameters.AddWithValue("@ItemIds", ItemIds);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsItemGroup = new DataTable();
            adapter.Fill(dsItemGroup);
            con.Close();
            if ((dsItemGroup != null) && (dsItemGroup.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsItemGroup.Rows.Count; i++)
                {
                    ItemRateModel obj = new ItemRateModel
                    {
                        ItemId = Convert.ToInt32(dsItemGroup.Rows[i]["ItemId"]),
                        ItemName = dsItemGroup.Rows[i]["ItemName"].ToString(),
                        Rate = (float)Convert.ToDouble(dsItemGroup.Rows[i]["Rate"])
                    };
                    standardRateList.Add(obj);
                }
            }
            return standardRateList;
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
                        EffectFrom = dtRateGroupList.Rows[i]["EffectFrom"].ToString().Replace("/", "-"),
                        EffectTo = dtRateGroupList.Rows[i]["EffectTo"].ToString().Replace("/", "-"),
                        IsStandard = Convert.ToBoolean(dtRateGroupList.Rows[i]["IsStandard"]),
                        IsDisplayed = Convert.ToInt32(dtRateGroupList.Rows[i]["IsDisplayed"]),
                        Rate = JsonConvert.DeserializeObject<List<ItemRateDetailModel>>(dtRateGroupList.Rows[i]["RateDetail"].ToString()),
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
                string jsonRateItems = JsonConvert.SerializeObject(RateGroup.BaseCostData);
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateRateGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RGroupId", RateGroup.RGroupId);
                cmd.Parameters.AddWithValue("@RGroupName", RateGroup.RGroupName);
                cmd.Parameters.AddWithValue("@Description", RateGroup.Description);
                cmd.Parameters.AddWithValue("@EffectFrom", RateGroup.EffectFrom);
                cmd.Parameters.AddWithValue("@EffectTo", RateGroup.EffectTo);
                cmd.Parameters.AddWithValue("@RateJSON", jsonRateItems);
                cmd.Parameters.AddWithValue("@IsDisplayed", RateGroup.IsDisplayed);
                cmd.Parameters.AddWithValue("@IsStandard", RateGroup.IsStandard);
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

        public List<CurrencyModel> GetCurrency(CurrencyModelAll rm)
        {
            List<CurrencyModel> currencyList = new List<CurrencyModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCurrency", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CurrencyId", rm.CurrencyId);
            cmd.Parameters.AddWithValue("@ShowAll", rm.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtCurrencyList = new DataTable();
            adapter.Fill(dtCurrencyList);
            con.Close();
            if ((dtCurrencyList != null) && (dtCurrencyList.Rows.Count > 0))
            {
                currencyList = dtCurrencyList.ToListOfObject<CurrencyModel>();
            }
            return currencyList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateGroup"></param>
        /// <returns></returns>
        public string InsertUpdateCurrency(CurrencyModelAll currency)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCurrency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrencyId", currency.CurrencyId);
                cmd.Parameters.AddWithValue("@CurrencyName", currency.CurrencyName);
                cmd.Parameters.AddWithValue("@CurrencyDesc", currency.CurrencyDesc);
                cmd.Parameters.AddWithValue("@UserId", currency.UserId);
                cmd.Parameters.AddWithValue("@IsDisplayed", currency.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", currency.BranchId);
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
        public string DeleteCurrency(CurrencyModelAll cm)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteCurrency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", cm.CurrencyId);
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
        public List<ItemGroupTypeModel> GetItemGroupType(ItemGroupTypeModel pm)
        {
            List<ItemGroupTypeModel> itemList = new List<ItemGroupTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemGroupType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemGroupTypeId", pm.GroupTypeId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    ItemGroupTypeModel obj = new ItemGroupTypeModel
                    {
                        GroupTypeId = Convert.ToInt32(dsNumber.Rows[i]["GroupTypeId"]),
                        GroupTypeName = dsNumber.Rows[i]["GroupTypeName"].ToString()
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }


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
                    // var obj = JsonConvert.DeserializeObject<PackageModel>(dsNumber.Rows[i]["ValueDatas"].ToString());

                    PackageModel obj = new PackageModel
                    {
                        PackId = Convert.ToInt32(dsNumber.Rows[i]["PackId"]),
                        PackDesc = dsNumber.Rows[i]["PackDesc"].ToString(),
                        EffectFrom = dsNumber.Rows[i]["EffectFrom"].ToString().Replace("/", "-"),
                        EffectTo = dsNumber.Rows[i]["EffectTo"].ToString().Replace("/", "-"),
                        PackAmount = (float)Convert.ToDouble(dsNumber.Rows[i]["PackAmount"].ToString()),
                        Remarks = dsNumber.Rows[i]["Remarks"].ToString(),
                        IsDisplayed = Convert.ToBoolean(dsNumber.Rows[i]["IsDisplayed"]),
                        ItemRateData = JsonConvert.DeserializeObject<List<ItemRatePackage>>(dsNumber.Rows[i]["PackageItemRate"].ToString()),
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        public List<PackageModel> GetPackageItemRate(PackageModelAll pm)
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
                string rateString = JsonConvert.SerializeObject(Package.ItemRateList);
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
                        IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]),
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
        public string InsertUpdateSymptom(CommonMasterFieldModelAll Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSymptom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SymptomId", Symptom.Id);
                cmd.Parameters.AddWithValue("@SymptomDesc", Symptom.DescriptionData);
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
        public string DeleteSymptom(CommonMasterFieldModelAll Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSymptom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SymptomId", Symptom.Id);
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
        public string DeleteSign(CommonMasterFieldModelAll Symptom)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", Symptom.Id);
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
            DataTable dsLocation = new DataTable();
            adapter.Fill(dsLocation);
            con.Close();
            if ((dsLocation != null) && (dsLocation.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsLocation.Rows.Count; i++)
                {
                    LocationModel obj = new LocationModel
                    {
                        LocationId = Convert.ToInt32(dsLocation.Rows[i]["LocationId"]),
                        LocationName = dsLocation.Rows[i]["LocationName"].ToString(),
                        Supervisor = dsLocation.Rows[i]["Supervisor"].ToString(),
                        ContactNumber = dsLocation.Rows[i]["ContactNumber"].ToString(),
                        LTypeId = Convert.ToInt32(dsLocation.Rows[i]["LTypeId"]),
                        ManageSPoints = Convert.ToBoolean(dsLocation.Rows[i]["ManageSPoints"]),
                        ManageBilling = Convert.ToBoolean(dsLocation.Rows[i]["ManageBilling"]),
                        ManageCash = Convert.ToBoolean(dsLocation.Rows[i]["ManageCash"]),
                        ManageCredit = Convert.ToBoolean(dsLocation.Rows[i]["ManageCredit"]),
                        ManageIPCredit = Convert.ToBoolean(dsLocation.Rows[i]["ManageIPCredit"]),
                        RepHeadImg = dsLocation.Rows[i]["RepHeadImg"].ToString(),
                        HospitalId = la.HospitalId,
                        HospitalName = dsLocation.Rows[i]["HospitalName"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsLocation.Rows[i]["IsDisplayed"])
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
        public string DeleteLocation(LocationModel location)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", location.LocationId);
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
                cmd.Parameters.AddWithValue("@ReportCode", country.ReportCode);
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
            List<StateModel> stateList = new List<StateModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetState", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", state.StateId);
            cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
            cmd.Parameters.AddWithValue("@ShowAll", state.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", state.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtStateList = new DataTable();
            adapter.Fill(dtStateList);
            con.Close();
            if ((dtStateList != null) && (dtStateList.Rows.Count > 0))
                stateList = dtStateList.ToListOfObject<StateModel>();
            return stateList;
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
                cmd.Parameters.AddWithValue("@StateCode", state.StateCode);
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
        public List<CommonMasterFieldModel> GetCompany(CommonMasterFieldModelAll company)
        {
            List<CommonMasterFieldModel> companyList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCompany", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CmpId", company.Id);
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
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsCompany.Rows[i]["CmpId"]),
                        NameData = dsCompany.Rows[i]["CmpName"].ToString(),
                        DescriptionData = dsCompany.Rows[i]["CompanyDescription"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsCompany.Rows[i]["IsDisplayed"])
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
        public string InsertUpdateCompany(CommonMasterFieldModelAll Company)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CmpId", Company.Id);
                cmd.Parameters.AddWithValue("@CmpName", Company.NameData);
                cmd.Parameters.AddWithValue("@CmpDescription", Company.DescriptionData);
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
                        ProfGroup = Convert.ToInt32(dtProfession.Rows[i]["ProfGroup"]),
                        IsDisplayed = Convert.ToBoolean(dtProfession.Rows[i]["IsDisplayed"])
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
        public string InsertUpdateProfession(CommonMasterFieldModelAll prof)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateProfession", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfId", prof.Id);
                cmd.Parameters.AddWithValue("@ProfName", prof.NameData);
                cmd.Parameters.AddWithValue("@ProfCode", prof.CodeData);
                cmd.Parameters.AddWithValue("@ProfGroup", 0);
                cmd.Parameters.AddWithValue("@IsDisplayed", Convert.ToBoolean(prof.IsDisplayed));
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
                        CountryName = dsCity.Rows[i]["CountryName"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsCity.Rows[i]["IsDisplayed"])
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
                    int mast = Convert.ToInt32(dsVitalSignList.Rows[i]["Mandatory"]);
                    VitalSignModel obj = new VitalSignModel
                    {
                        SignId = Convert.ToInt32(dsVitalSignList.Rows[i]["SignId"]),
                        SignName = dsVitalSignList.Rows[i]["SignName"].ToString(),
                        Mandatory = mast,
                        MandatoryStatus = mast == 1 ? "Yes" : "No",
                        SignCode = dsVitalSignList.Rows[i]["SignCode"].ToString(),
                        SignUnit = dsVitalSignList.Rows[i]["SignUnit"].ToString(),
                        MinValue = Convert.ToDouble(dsVitalSignList.Rows[i]["MinValue"]),
                        MaxValue = Convert.ToDouble(dsVitalSignList.Rows[i]["MaxValue"]),
                        SortOrder = Convert.ToInt32(dsVitalSignList.Rows[i]["SortOrder"]),
                        IsDisplayed = Convert.ToInt32(dsVitalSignList.Rows[i]["IsDisplayed"])
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
        public string DeleteVitalSign(CommonMasterFieldModelAll vitalsign)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteVitalSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", vitalsign.Id);
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
                        IsDisplayed = Convert.ToInt32(dtbodypartList.Rows[i]["IsDisplayed"]),
                        BodyPartImageLocation = imgloc != "" ? _uploadpath + imgloc : imgloc,
                        BodyPartFileName = imgloc != "" ? imgloc.Split('/').Last() : imgloc,
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
                        ImageFileName = imgloc != "" ? imgloc.Split('/').Last() : imgloc,
                        IsDisplayed = Convert.ToInt32(dtSketchIndicatorsList.Rows[i]["IsDisplayed"]),

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
        public List<CommonMasterFieldModel> GetSalutation(CommonMasterFieldModelAll salutationDetails)
        {
            List<CommonMasterFieldModel> salutationList = new List<CommonMasterFieldModel>();
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
            {
                for (Int32 i = 0; i < dtsalutationList.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dtsalutationList.Rows[i]["Id"]),
                        NameData = dtsalutationList.Rows[i]["Salutation"].ToString(),
                        IsDisplayed = Convert.ToInt32(dtsalutationList.Rows[i]["IsDisplayed"]),
                    };
                    salutationList.Add(obj);
                }
            }
            return salutationList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salutation"></param>
        /// <returns></returns>
        public string InsertUpdateSalutation(CommonMasterFieldModelAll salutation)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSalutation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalutationId", salutation.Id);
                cmd.Parameters.AddWithValue("@Salutation", salutation.NameData);
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
        public string DeleteSalutation(CommonMasterFieldModelAll salutation)
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
            cmd.Parameters.AddWithValue("@ID", religion.Id);
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
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateReligion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", religion.Id);
                cmd.Parameters.AddWithValue("@ReligionName", religion.ReligionName);
                cmd.Parameters.AddWithValue("@ReligionCode", religion.ReligionCode);
                cmd.Parameters.AddWithValue("@BranchId", religion.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", religion.IsDisplayed);
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
                using SqlCommand cmd = new SqlCommand("stLH_DeleteReligion", con);
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
        public List<LeadAgentModel> GetLeadAgent(LeadAgentModelAll la)
        {
            List<LeadAgentModel> leadAgentList = new List<LeadAgentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLeadAgent", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeadAgentId", la.LeadAgentId);
            cmd.Parameters.AddWithValue("@ShowAll", la.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", la.BranchId);
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
                    };
                    leadAgentList.Add(obj);
                }
            }
            return leadAgentList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LeadAgent"></param>
        /// <returns></returns>
        public string InsertUpdateLeadAgent(LeadAgentModelAll LeadAgent)
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
                cmd.Parameters.AddWithValue("@BranchId", LeadAgent.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", LeadAgent.IsDisplayed);
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
        public string DeleteLeadAgent(LeadAgentModelAll LeadAgent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteLeadAgent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", LeadAgent.LeadAgentId);
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
        /// Get sponsor list. if sponsorid is zero then returns all sponsor details. else returns specific sponsor id details
        /// </summary>
        /// <param name="sponsorid"></param>
        /// <returns></returns>
        public List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsor)
        {
            List<SponsorMasterModel> sponsorList = new List<SponsorMasterModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", sponsor.SponsorId);
            cmd.Parameters.AddWithValue("@ShowAll", sponsor.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sponsor.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtSponsor = new DataTable();
            adapter.Fill(dtSponsor);
            con.Close();
            if ((dtSponsor != null) && (dtSponsor.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtSponsor.Rows.Count; i++)
                {
                    SponsorMasterModel obj = new SponsorMasterModel
                    {

                        SponsorId = Convert.ToInt32(dtSponsor.Rows[i]["SponsorId"]),
                        SponsorName = dtSponsor.Rows[i]["SponsorName"].ToString(),
                        SponsorType = Convert.ToInt32(dtSponsor.Rows[i]["SponsorType"]),
                        Address1 = dtSponsor.Rows[i]["Address1"].ToString(),
                        Address2 = dtSponsor.Rows[i]["Address2"].ToString(),
                        Street = dtSponsor.Rows[i]["Street"].ToString(),
                        PlacePo = dtSponsor.Rows[i]["PlacePO"].ToString(),
                        PIN = dtSponsor.Rows[i]["PIN"].ToString(),
                        City = dtSponsor.Rows[i]["City"].ToString(),
                        State = dtSponsor.Rows[i]["State"].ToString(),
                        CountryId = Convert.ToInt32(dtSponsor.Rows[i]["CountryId"]),
                        Phone = dtSponsor.Rows[i]["Phone"].ToString(),
                        Mobile = dtSponsor.Rows[i]["Mobile"].ToString(),
                        Email = dtSponsor.Rows[i]["Email"].ToString(),
                        Fax = dtSponsor.Rows[i]["Fax"].ToString(),
                        ContactPerson = dtSponsor.Rows[i]["ContactPerson"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dtSponsor.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dtSponsor.Rows[i]["CoPayPcnt"].ToString()),
                        Remarks = dtSponsor.Rows[i]["Remarks"].ToString(),
                        SFormId = Convert.ToInt32(dtSponsor.Rows[i]["SFormId"]),
                        SponsorLimit = (float)Convert.ToDouble(dtSponsor.Rows[i]["SponsorLimit"].ToString()),
                        DHANo = dtSponsor.Rows[i]["DHANo"].ToString(),
                        EnableSponsorLimit = Convert.ToInt32(dtSponsor.Rows[i]["EnableSponsorLimit"]),
                        EnableSponsorConsent = Convert.ToInt32(dtSponsor.Rows[i]["EnableSponsorConsent"]),
                        AuthorizationMode = dtSponsor.Rows[i]["AuthorizationMode"].ToString(),
                        URL = dtSponsor.Rows[i]["URL"].ToString(),
                        SortOrder = Convert.ToInt32(dtSponsor.Rows[i]["SortOrder"]),
                        PartyId = Convert.ToInt32(dtSponsor.Rows[i]["PartyId"]),
                        UnclaimedId = Convert.ToInt32(dtSponsor.Rows[i]["UnclaimedId"])
                    };
                    sponsorList.Add(obj);
                }
            }
            return sponsorList;
        }
        /// <summary>
        /// insert update sponsor details if SponsorId is zero then inserting the data else updating the data of id
        /// </summary>
        /// <param name="sponsor"></param>
        /// <returns>success or reason to failure</returns>
        public string InsertUpdateSponsor(SponsorMasterModelAll sponsor)
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
                cmd.Parameters.AddWithValue("@PlacePO", sponsor.PlacePo);
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
                cmd.Parameters.AddWithValue("@DHANo", sponsor.DHANo);
                cmd.Parameters.AddWithValue("@EnableLimit", sponsor.EnableSponsorLimit);
                cmd.Parameters.AddWithValue("@EnableConsent", sponsor.EnableSponsorConsent);
                cmd.Parameters.AddWithValue("@AuthorizationMode", sponsor.AuthorizationMode);
                cmd.Parameters.AddWithValue("@URL", sponsor.URL);
                cmd.Parameters.AddWithValue("@SortOrder", sponsor.SortOrder);
                cmd.Parameters.AddWithValue("@BranchId", sponsor.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", sponsor.IsDisplayed);
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
        public string DeleteSponsor(SponsorMasterModelAll sponsor)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSponsor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SponsorId", sponsor.SponsorId);
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
                response = descrip;
            }
            return response;
        }
        public List<CommonMasterFieldModel> GetDrugType(CommonMasterFieldModelAll la)
        {
            List<CommonMasterFieldModel> drugList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrugType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugTypeId", la.Id);
            cmd.Parameters.AddWithValue("@ShowAll", la.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", la.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsNumber.Rows[i]["DrugTypeId"]),
                        DescriptionData = dsNumber.Rows[i]["DrugTypeDesc"].ToString(),
                    };
                    drugList.Add(obj);
                }
            }
            return drugList;
        }
        public List<CommonMasterFieldModel> GetContainer(CommonMasterFieldModelAll la)
        {
            List<CommonMasterFieldModel> containerList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetContainer", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", la.Id);
            cmd.Parameters.AddWithValue("@ShowAll", la.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", la.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsContainer = new DataTable();
            adapter.Fill(dsContainer);
            con.Close();
            if ((dsContainer != null) && (dsContainer.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsContainer.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsContainer.Rows[i]["Id"]),
                        NameData = dsContainer.Rows[i]["ContainerName"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsContainer.Rows[i]["IsDisplayed"]),
                    };
                    containerList.Add(obj);
                }
            }
            return containerList;
        }
        public List<CommonMasterFieldModel> GetVaccineType(CommonMasterFieldModelAll la)
        {
            List<CommonMasterFieldModel> vtList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetVaccineType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", la.Id);
            cmd.Parameters.AddWithValue("@ShowAll", la.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", la.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsVT = new DataTable();
            adapter.Fill(dsVT);
            con.Close();
            if ((dsVT != null) && (dsVT.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsVT.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsVT.Rows[i]["Id"]),
                        NameData = dsVT.Rows[i]["VaccineTypeName"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsVT.Rows[i]["IsDisplayed"]),
                    };
                    vtList.Add(obj);
                }
            }
            return vtList;
        }

        public List<TaxModel> GetTax(TaxModelAll tax)
        {
            List<TaxModel> taxList = new List<TaxModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTax", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaxId", tax.TaxId);
            cmd.Parameters.AddWithValue("@ShowAll", tax.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", tax.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    TaxModel obj = new TaxModel
                    {
                        TaxId = Convert.ToInt32(dsNumber.Rows[i]["TaxId"]),
                        TaxDesc = dsNumber.Rows[i]["TaxDesc"].ToString(),
                        TaxPcnt = (float)Convert.ToDouble(dsNumber.Rows[i]["TaxPcnt"].ToString()),
                        HeadId = Convert.ToInt32(dsNumber.Rows[i]["HeadId"]),
                        HeadDesc = dsNumber.Rows[i]["HeadDesc"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsNumber.Rows[i]["IsDisplayed"])
                    };
                    taxList.Add(obj);
                }
            }
            return taxList;
        }
        public string InsertUpdateTax(TaxModelAll tax)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaxId", tax.TaxId);
                cmd.Parameters.AddWithValue("@TaxDesc", tax.TaxDesc);
                cmd.Parameters.AddWithValue("@TaxPcnt", tax.TaxPcnt);
                cmd.Parameters.AddWithValue("@HeadId", tax.HeadId);
                cmd.Parameters.AddWithValue("@BranchId", tax.BranchId);
                cmd.Parameters.AddWithValue("@UserId", tax.UserId);
                cmd.Parameters.AddWithValue("@IsDisplayed", tax.IsDisplayed);
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
        public string DeleteTax(TaxModelAll tax)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", tax.TaxId);
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
                    obj.DateOfBirth = dsConsultant.Rows[i]["DOB"].ToString();
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
                    obj.DateOfJoin = dsConsultant.Rows[i]["DOJ"].ToString();
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
            DataTable dtSponsorType = new DataTable();
            adapter.Fill(dtSponsorType);
            con.Close();
            if ((dtSponsorType != null) && (dtSponsorType.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtSponsorType.Rows.Count; i++)
                {
                    SponsorTypeModel obj = new SponsorTypeModel
                    {
                        STypeId = Convert.ToInt32(dtSponsorType.Rows[i]["STypeId"]),
                        STypeDesc = dtSponsorType.Rows[i]["STypeDesc"].ToString()
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
                        SFormName = dsProfession.Rows[i]["SFormName"].ToString()
                        //Active = Convert.ToInt32(dsProfession.Rows[i]["Active"]),
                        //BlockReason = dsProfession.Rows[i]["SFormName"].ToString()
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
        public string InsertUpdateDeleteZone(ZoneModelAll zone)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateZone", con);//InsertUpdateDeleteZone
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZoneId", zone.Id);
                cmd.Parameters.AddWithValue("@OperatorId", zone.OperatorId);
                cmd.Parameters.AddWithValue("@ZoneName", zone.ZoneName);
                cmd.Parameters.AddWithValue("@ZoneCode", zone.ZoneCode);
                cmd.Parameters.AddWithValue("@ZoneDescription", zone.ZoneDescription);
                cmd.Parameters.AddWithValue("@ZoneCountry", zone.ZoneCountry);
                cmd.Parameters.AddWithValue("@IsDeleting", zone.IsDeleting);
                cmd.Parameters.AddWithValue("@IsDisplayed", zone.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", zone.BranchId);
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
        public List<ZoneModel> GetZone(ZoneModelAll zoneId)
        {
            List<ZoneModel> zoneList = new List<ZoneModel>();

            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_ZoneById", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@zoneId", zoneId.Id);
            cmd.Parameters.AddWithValue("@ShowAll", zoneId.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", zoneId.BranchId);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        public string InsertUpdateMovement(CommonMasterFieldModelAll movement)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateMovement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovementId", movement.Id);
                cmd.Parameters.AddWithValue("@MovementDesc", movement.DescriptionData);
                cmd.Parameters.AddWithValue("@BranchId", movement.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", movement.IsDisplayed);
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
        public List<CommonMasterFieldModel> GetMovement(CommonMasterFieldModelAll movement)
        {
            List<CommonMasterFieldModel> movementList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMovementDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MovementId", movement.Id);
            cmd.Parameters.AddWithValue("@ShowAll", movement.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", movement.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsMovementList = new DataTable();
            adapter.Fill(dsMovementList);
            con.Close();
            if ((dsMovementList != null) && (dsMovementList.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsMovementList.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsMovementList.Rows[i]["MovementId"]),
                        DescriptionData = dsMovementList.Rows[i]["MovementDesc"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsMovementList.Rows[i]["IsDisplayed"])
                    };
                    movementList.Add(obj);
                }
            }
            return movementList;
        }
        public string DeleteMovement(CommonMasterFieldModelAll movement)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteMovement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", movement.Id);
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
        //Movement Ends
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
                        BranchId = dm.BranchId,
                        ScientificName = dsDrug.Rows[i]["ScientificName"].ToString()
                    };
                    drugList.Add(obj);
                }
            }
            return drugList;
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
            if (rm.OrderFromDate.Trim() != "" && rm.OrderToDate.Trim() != "")
            {
                DateTime orderFromDate = DateTime.ParseExact(rm.OrderFromDate.Trim(), "dd-MM-yyyy", null);
                rm.OrderFromDate = orderFromDate.ToString("yyyy-MM-dd");
                DateTime orderToDate = DateTime.ParseExact(rm.OrderToDate.Trim(), "dd-MM-yyyy", null);
                rm.OrderToDate = orderToDate.ToString("yyyy-MM-dd");
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", rm.PatientId);
            cmd.Parameters.AddWithValue("@BranchId", rm.BranchId);
            //New Parameters start
            cmd.Parameters.AddWithValue("@OrderFromDate", rm.OrderFromDate);
            cmd.Parameters.AddWithValue("@OrderToDate", rm.OrderToDate);
            cmd.Parameters.AddWithValue("@OrderNo", rm.OrderNo);
            cmd.Parameters.AddWithValue("@RegNo", rm.RegNo);
            cmd.Parameters.AddWithValue("@PatientName", rm.PatientName);
            cmd.Parameters.AddWithValue("@ConsultantId", rm.ConsultantId);
            cmd.Parameters.AddWithValue("@IsExternal", rm.IsExternalConsultant);
            //New Parameters end
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
        /// Get Scientific names of drugs master. ShowAll=1 && ScientificId=0 gell all data, ShowAll=0 && ScientificId={id} get single data,
        /// </summary>
        /// <param name="scientificName"></param>
        /// <returns></returns>
        public List<ScientificNameModel> GetScientificName(ScientificNameModelAll scientificName)
        {
            List<ScientificNameModel> itemList = new List<ScientificNameModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetScientificName", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ScientificId", scientificName.ScientificId);
            cmd.Parameters.AddWithValue("@ShowAll", scientificName.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", scientificName.BranchId);
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
                        ZoneId = Convert.ToInt32(dsNumber.Rows[i]["ZoneId"]),
                        IsDeleted = Convert.ToInt32(dsNumber.Rows[i]["IsDeleted"]),
                        IsDisplayed = Convert.ToInt32(dsNumber.Rows[i]["IsDisplayed"])
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        /// <summary>
        /// Save or update a drug's scientific name.If ScientificId is zero then inserts the value. else updates the value. If Iseleted=1, It will delete the value
        /// </summary>
        /// <param name="ScientificNameModelAll"></param>
        /// <returns></returns>
        public string InsertUpdateScientificName(ScientificNameModelAll scientificName)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateScientifcName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScientificId", scientificName.ScientificId);
                cmd.Parameters.AddWithValue("@ScientificName", scientificName.ScientificName);
                cmd.Parameters.AddWithValue("@ScientificCode", scientificName.ScientificCode);
                cmd.Parameters.AddWithValue("@IsDisplayed", scientificName.IsDisplayed);
                cmd.Parameters.AddWithValue("@IsDeleted", scientificName.IsDeleted);
                cmd.Parameters.AddWithValue("@BranchId", scientificName.BranchId);
                cmd.Parameters.AddWithValue("@UserId", scientificName.UserId);
                cmd.Parameters.AddWithValue("@ZoneId", scientificName.ZoneId);
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
        public List<CommonMasterFieldModel> GetTendern(CommonMasterFieldModelAll tenderness)
        {
            List<CommonMasterFieldModel> tendernList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTendernDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TendernId", tenderness.Id);
            cmd.Parameters.AddWithValue("@ShowAll", tenderness.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", tenderness.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsNumber = new DataTable();
            adapter.Fill(dsNumber);
            con.Close();
            if ((dsNumber != null) && (dsNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dsNumber.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = Convert.ToInt32(dsNumber.Rows[i]["TendernId"]),
                        DescriptionData = dsNumber.Rows[i]["TendernDesc"].ToString(),
                        IsDisplayed = Convert.ToInt32(dsNumber.Rows[i]["IsDisplayed"])
                    };
                    tendernList.Add(obj);
                }
            }
            return tendernList;
        }
        /// <summary>
        /// Save/Update Details of pain sensitivity(Tenderness)
        /// </summary>
        /// <param name="TendernId">Primary key of LH_PhyTendern Table,Update Data if param is not zero</param>
        /// <returns>List of tenderness details, Returns all if tendernessid=0</returns>
        public string InsertUpdateTendern(CommonMasterFieldModelAll tendern)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTendern", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TendernId", tendern.Id);
                cmd.Parameters.AddWithValue("@TendernDesc", tendern.DescriptionData);
                cmd.Parameters.AddWithValue("@BranchId", tendern.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", tendern.IsDisplayed);
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
        public string DeleteTendern(CommonMasterFieldModelAll tendern)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTenderness", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", tendern.Id);
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
        /// Registration Scheme Data
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
            cmd.Parameters.AddWithValue("@BranchId", ibt.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", ibt.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtNumber = new DataTable();
            adapter.Fill(dtNumber);
            con.Close();
            if ((dtNumber != null) && (dtNumber.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtNumber.Rows.Count; i++)
                {
                    ItemsByTypeModel obj = new ItemsByTypeModel();
                    obj.ItemId = Convert.ToInt32(dtNumber.Rows[i]["ItemId"]);
                    obj.ItemCode = dtNumber.Rows[i]["ItemCode"].ToString();
                    obj.ItemName = dtNumber.Rows[i]["ItemName"].ToString();
                    obj.Rate = (float)Convert.ToDouble(dtNumber.Rows[i]["BaseCost"]);
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
        /// <summary>
        /// Save ICD Categroy
        /// </summary>
        /// <param name="icdCategory"></param>
        /// <returns></returns>
        public string InsertUpdateICDCategory(ICDCategoryModelAll icdCategory)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateICDCategroy", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CatgId", icdCategory.CatgId);
                cmd.Parameters.AddWithValue("@ICDGroupId", icdCategory.ICDGroupId);
                cmd.Parameters.AddWithValue("@CatgName", icdCategory.CatgName);
                cmd.Parameters.AddWithValue("@CatgDesc", icdCategory.CatgDesc);
                cmd.Parameters.AddWithValue("@BranchId", icdCategory.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", icdCategory.IsDisplayed);

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
        /// Get ICD Category list
        /// </summary>
        /// <param name="icdCategory"></param>
        /// <returns></returns>
        public List<ICDCategoryModel> GetICDCategory(ICDCategoryModelAll category)
        {
            List<ICDCategoryModel> categoryList = new List<ICDCategoryModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetICDCategory", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CatgId", category.CatgId);
            cmd.Parameters.AddWithValue("@GroupId", category.ICDGroupId);
            cmd.Parameters.AddWithValue("@ShowAll", category.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", category.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
                categoryList = dataTable.ToListOfObject<ICDCategoryModel>();
            return categoryList;
        }
        public string DeleteICDCategory(CommonMasterFieldModelAll icdcategory)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteICDCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", icdcategory.Id);
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
        /// Save ICD Group
        /// </summary>
        /// <param name="icdGroup"></param>
        /// <returns></returns>
        public string InsertUpdateICDGroup(ICDGroupModelAll icdGroup)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateICDGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GroupId", icdGroup.GroupId);
                cmd.Parameters.AddWithValue("@GroupDesc", icdGroup.GroupDesc);
                cmd.Parameters.AddWithValue("@GroupRange", icdGroup.GroupRange);
                cmd.Parameters.AddWithValue("@BranchId", icdGroup.BranchId);
                cmd.Parameters.AddWithValue("@IsDisplayed", icdGroup.IsDisplayed);
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
        /// Get ICD Group list
        /// </summary>
        /// <param name="icdGroup"></param>
        /// <returns></returns>
        public List<ICDGroupModel> GetICDGroup(ICDGroupModelAll group)
        {
            List<ICDGroupModel> itemList = new List<ICDGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetICDGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@GroupId", group.GroupId);
            cmd.Parameters.AddWithValue("@ShowAll", group.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", group.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    ICDGroupModel obj = new ICDGroupModel();
                    obj.GroupId = Convert.ToInt32(dataTable.Rows[i]["GroupId"]);
                    obj.GroupDesc = dataTable.Rows[i]["GroupDesc"].ToString();
                    obj.GroupRange = dataTable.Rows[i]["GroupRange"].ToString();
                    obj.IsDisplayed = Convert.ToInt32(dataTable.Rows[i]["IsDisplayed"]);
                    itemList.Add(obj);
                }
            }
            return itemList;
        }
        public string DeleteICDGroup(ICDGroupModelAll icdgroup)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteICDGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", icdgroup.GroupId);
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
        /// Save ICD Label
        /// </summary>
        /// <param name="icdLabel"></param>
        /// <returns></returns>
        public string InsertUpdateICDLabel(ICDLabelModelAll icdLabel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateICDLabel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string icdlabelsigns = JsonConvert.SerializeObject(icdLabel.LabelSigns);
                string icdlabelsymptoms = JsonConvert.SerializeObject(icdLabel.LabelSymptoms);
                cmd.Parameters.AddWithValue("@LabelId", icdLabel.LabelId);
                cmd.Parameters.AddWithValue("@LabelDesc", icdLabel.LabelDesc);
                cmd.Parameters.AddWithValue("@LabelCode", icdLabel.LabelCode);
                cmd.Parameters.AddWithValue("@GroupId", icdLabel.ICDGroupId);
                cmd.Parameters.AddWithValue("@CatgId", icdLabel.CatgId);
                cmd.Parameters.AddWithValue("@IsDisplayed", icdLabel.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", icdLabel.BranchId);
                cmd.Parameters.AddWithValue("@ICDLabelSigns", icdlabelsigns);
                cmd.Parameters.AddWithValue("@ICDLabelSymptoms", icdlabelsymptoms);
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
        /// Get ICD Label list
        /// </summary>
        /// <param name="icdLabel"></param>
        /// <returns></returns>
        public List<ICDLabelModel> GetICDLabel(ICDLabelModelAll label)
        {
            List<ICDLabelModel> labelList = new List<ICDLabelModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetICDLabel", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LabelId", label.LabelId);
            cmd.Parameters.AddWithValue("@GroupId", label.ICDGroupId);
            cmd.Parameters.AddWithValue("@CategoryId", label.CatgId);
            cmd.Parameters.AddWithValue("@ShowAll", label.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", label.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    ICDLabelModel obj = new ICDLabelModel();
                    obj.LabelId = Convert.ToInt32(dataTable.Rows[i]["LabelId"]);
                    obj.LabelDesc = dataTable.Rows[i]["LabelDesc"].ToString();
                    obj.LabelCode = dataTable.Rows[i]["LabelCode"].ToString();
                    obj.ICDGroupId = Convert.ToInt32(dataTable.Rows[i]["GroupId"]);
                    obj.GroupDesc = dataTable.Rows[i]["GroupDesc"].ToString();
                    obj.CatgId = Convert.ToInt32(dataTable.Rows[i]["CatgId"]);
                    obj.CatgDesc = dataTable.Rows[i]["CatgDesc"].ToString();
                    obj.CatgName = dataTable.Rows[i]["CatgName"].ToString();
                    obj.IsDisplayed = Convert.ToInt32(dataTable.Rows[i]["IsDisplayed"]);
                    obj.LabelSigns = JsonConvert.DeserializeObject<List<LabelSign>>(dataTable.Rows[i]["LabelSigns"].ToString());
                    obj.LabelSymptoms = JsonConvert.DeserializeObject<List<LabelSymptom>>(dataTable.Rows[i]["LabelSymptoms"].ToString());
                    labelList.Add(obj);
                }
            }
            return labelList;
        }
        public string DeleteICDLabel(ICDLabelModelAll icdlabel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteICDLabel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", icdlabel.LabelId);
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
        /// Save Profile and profile items
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public string InsertUpdateProfile(ProfileModelAll profile)
        {

            SqlTransaction transaction;
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                transaction = con.BeginTransaction();
                SqlCommand cmdSaveProfile = new SqlCommand("stLH_InsertUpdateProfile", con);
                cmdSaveProfile.CommandType = CommandType.StoredProcedure;
                cmdSaveProfile.Parameters.AddWithValue("@ProfileId", profile.ProfileId);
                cmdSaveProfile.Parameters.AddWithValue("@ProfileDesc", profile.ProfileDesc);
                cmdSaveProfile.Parameters.AddWithValue("@UserId", profile.UserId);
                cmdSaveProfile.Parameters.AddWithValue("@IsDisplayed", profile.IsDisplayed);
                cmdSaveProfile.Parameters.AddWithValue("@BranchId", profile.BranchId);
                cmdSaveProfile.Parameters.AddWithValue("@Remarks", profile.Remarks);
                SqlParameter profileRetVal = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter profileRetDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmdSaveProfile.Parameters.Add(profileRetVal);
                cmdSaveProfile.Parameters.Add(profileRetDesc);
                cmdSaveProfile.Transaction = transaction;
                try
                {
                    cmdSaveProfile.ExecuteNonQuery();
                    int ProfileId = (int)profileRetVal.Value;
                    var descProfile = profileRetDesc.Value.ToString();
                    response = descProfile;
                    if (descProfile == "Saved Successfully")
                    {
                        response = "Success";
                    }

                    if (ProfileId > 0)//Inserted / Updated Successfully
                    {
                        transaction.Commit();
                        //====================InsertProfileItem===========================
                        string jsonProfileItems = JsonConvert.SerializeObject(profile.ProfileItems);

                        SqlCommand cmdSign = new SqlCommand("stLH_InsertProfileItem", con);
                        cmdSign.CommandType = CommandType.StoredProcedure;
                        cmdSign.Parameters.AddWithValue("@ProfileId", ProfileId);
                        cmdSign.Parameters.AddWithValue("@UserId", profile.UserId);
                        cmdSign.Parameters.AddWithValue("@ItemJSON", jsonProfileItems);

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
                        response = descript;
                        if (descript == "Saved Successfully")
                        {
                            response = "Success";
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                con.Close();
            }

            return response;
        }
        /// <summary>
        /// Get Profile Details By profileId
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public List<ProfileModel> GetProfile(ProfileModelAll profile)
        {
            List<ProfileModel> profileList = new List<ProfileModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            SqlCommand cmdGetProfile = new SqlCommand("stLH_GetProfileDetailsById", con);
            cmdGetProfile.CommandType = CommandType.StoredProcedure;
            cmdGetProfile.Parameters.AddWithValue("@ProfileId", profile.ProfileId);
            cmdGetProfile.Parameters.AddWithValue("@ShowAll", profile.ShowAll);
            cmdGetProfile.Parameters.AddWithValue("@BranchId", profile.BranchId);
            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmdGetProfile);
            DataTable dataTable = new DataTable();
            adapter1.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    ProfileModel obj = new ProfileModel();
                    obj.ProfileId = Convert.ToInt32(dataTable.Rows[i]["ProfileId"]);
                    obj.ProfileDesc = dataTable.Rows[i]["ProfileDesc"].ToString();
                    obj.Remarks = dataTable.Rows[i]["Remarks"].ToString();
                    obj.IsDisplayed = Convert.ToBoolean(dataTable.Rows[i]["IsDisplayed"]);
                    obj.ProfileItems = JsonConvert.DeserializeObject<List<ProfileItemModel>>(dataTable.Rows[i]["ProfileItems"].ToString());
                    profileList.Add(obj);
                }
            }
            return profileList;

        }
        public string DeleteProfile(ProfileModelAll profile)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_BlockProfile", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfileId", profile.ProfileId);
                    cmd.Parameters.AddWithValue("@UserId", profile.UserId);
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
                    if (Convert.ToInt32(ret) == profile.ProfileId)
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


        public List<ProfileItemModel> GetItemForProfile(int patientId)
        {
            List<ProfileItemModel> itemList = new List<ProfileItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemForProfile", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PatientId", patientId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                itemList = dataTable.ToListOfObject<ProfileItemModel>();
            }
            return itemList;
        }
        public List<CommonMasterFieldModel> GetCommissionRule(CommonMasterFieldModelAll cmfr)
        {
            List<CommonMasterFieldModel> itemList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCommissionRules", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CommissionId", cmfr.Id);
            cmd.Parameters.AddWithValue("@ShowAll", cmfr.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", cmfr.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel();
                    obj.Id = Convert.ToInt32(dataTable.Rows[i]["CommissionId"]);
                    obj.NameData = dataTable.Rows[i]["CommissionName"].ToString();
                    obj.CodeData = dataTable.Rows[i]["CommissionCode"].ToString();
                    itemList.Add(obj);
                }
            }
            return itemList;
        }

        public string InsertUpdateSign(CommonMasterFieldModelAll commonMaster)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SignId", commonMaster.Id);
                cmd.Parameters.AddWithValue("@SignDesc", commonMaster.DescriptionData);
                cmd.Parameters.AddWithValue("@UserId", commonMaster.UserId);
                cmd.Parameters.AddWithValue("@IsDisplayed", commonMaster.IsDisplayed);
                cmd.Parameters.AddWithValue("@BranchId", commonMaster.BranchId);
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
        public List<CommonMasterFieldModel> GetSign(CommonMasterFieldModelAll sign)
        {
            List<CommonMasterFieldModel> itemList = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSign", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SignId", sign.Id);
            cmd.Parameters.AddWithValue("@ShowAll", sign.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sign.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel();
                    obj.Id = Convert.ToInt32(dataTable.Rows[i]["SignId"]);
                    obj.DescriptionData = dataTable.Rows[i]["SignDesc"].ToString();
                    obj.IsDisplayed = Convert.ToInt32(dataTable.Rows[i]["IsDisplayed"]);
                    itemList.Add(obj);
                }
            }
            return itemList;
        }

        public List<LocationModel> GetLocationByType(LocationAll location)
        {
            List<LocationModel> itemList = new List<LocationModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetLocationByType", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LTypeId", location.LTypeId);
            cmd.Parameters.AddWithValue("@BranchId", location.HospitalId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                itemList = dataTable.ToListOfObject<LocationModel>();
            }
            return itemList;
        }
        public string InsertAssociateLocation(LocationAssociateModel locationAssociate)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertAssociateLocation", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocationId", locationAssociate.LocationId);
                    string associateLcations = JsonConvert.SerializeObject(locationAssociate.AssociateLcations);
                    cmd.Parameters.AddWithValue("@LocationJSON", associateLcations);
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
        public string InsertUpdateServicePoint(ServicePointModel servicePoint)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateServicePoint", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SPointId", servicePoint.SPointId);
                    cmd.Parameters.AddWithValue("@LocationId", servicePoint.LocationId);
                    cmd.Parameters.AddWithValue("@SPointName", servicePoint.SPointName);
                    cmd.Parameters.AddWithValue("@Schedulable", servicePoint.Schedulable);
                    cmd.Parameters.AddWithValue("@RoutineNos", servicePoint.RoutineNos);
                    cmd.Parameters.AddWithValue("@UrgentNos", servicePoint.UrgentNos);
                    cmd.Parameters.AddWithValue("@UserId", servicePoint.UserId);

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
        public List<ServicePointModel> GetServicePoint(ServicePointModelAll sPoint)
        {
            List<ServicePointModel> itemList = new List<ServicePointModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetServicePoint", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SPointId", sPoint.SPointId);
            cmd.Parameters.AddWithValue("@BranchId", sPoint.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                itemList = dataTable.ToListOfObject<ServicePointModel>();
            }
            return itemList;
        }

        public string DeleteServicePoint(ServicePointModel servicePoint)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteServicePoint", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SPointId", servicePoint.SPointId);
                    cmd.Parameters.AddWithValue("@UserId", servicePoint.UserId);

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
                    if (Convert.ToInt32(ret) == servicePoint.SPointId)
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
        public string InsertUpdateDeleteTradeName(TradeNameModelAll tradeName)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTradeName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TradeId", tradeName.TradeId);
                cmd.Parameters.AddWithValue("@TradeName", tradeName.TradeName);
                cmd.Parameters.AddWithValue("@ScientificId", tradeName.ScientificId);
                cmd.Parameters.AddWithValue("@RouteId", tradeName.RouteId);
                cmd.Parameters.AddWithValue("@DosageForm", tradeName.DosageForm);
                cmd.Parameters.AddWithValue("@IngredentStrength", tradeName.IngredentStrength);
                cmd.Parameters.AddWithValue("@PackagePrice", tradeName.PackagePrice);
                cmd.Parameters.AddWithValue("@GranularUnit", tradeName.GranularUnit);
                cmd.Parameters.AddWithValue("@Manufacturer", tradeName.Manufacturer);
                cmd.Parameters.AddWithValue("@RegisteredOwner", tradeName.RegisteredOwner);
                cmd.Parameters.AddWithValue("@IsDisplayed", tradeName.IsDisplayed);
                cmd.Parameters.AddWithValue("@IsDeleted", tradeName.IsDeleted);
                cmd.Parameters.AddWithValue("@BranchId", tradeName.BranchId);
                cmd.Parameters.AddWithValue("@TradeCode", tradeName.TradeCode);
                cmd.Parameters.AddWithValue("@UserId", tradeName.UserId);
                cmd.Parameters.AddWithValue("@ZoneId", tradeName.ZoneId);
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
        public List<TradeNameModel> GetTradeName(TradeNameModelAll tradeName)
        {
            List<TradeNameModel> tradeNames = new List<TradeNameModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetTradeName", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TradeNameId", tradeName.TradeId);
            cmd.Parameters.AddWithValue("@ShowAll", tradeName.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", tradeName.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    TradeNameModel obj = new TradeNameModel
                    {
                        TradeId = dt.Rows[i]["TradeId"] != null ? Convert.ToInt32(dt.Rows[i]["TradeId"]) : 0,
                        ScientificId = dt.Rows[i]["ScientificId"] != null ? Convert.ToInt32(dt.Rows[i]["ScientificId"]) : 0,
                        RouteId = dt.Rows[i]["RouteId"] != null ? Convert.ToInt32(dt.Rows[i]["RouteId"]) : 0,
                        IsDeleted = dt.Rows[i]["IsDeleted"] != null ? Convert.ToInt32(dt.Rows[i]["IsDeleted"]) : 0,
                        ZoneId = dt.Rows[i]["ZoneId"] != null ? Convert.ToInt32(dt.Rows[i]["ZoneId"]) : 0,
                        IsDisplayed = dt.Rows[i]["IsDisplayed"] != null ? Convert.ToInt32(dt.Rows[i]["IsDisplayed"]) : 0,
                        TradeName = dt.Rows[i]["TradeName"] != null ? dt.Rows[i]["TradeName"].ToString() : "",
                        TradeCode = dt.Rows[i]["TradeCode"] != null ? dt.Rows[i]["TradeCode"].ToString() : "",
                        DosageForm = dt.Rows[i]["DosageForm"] != null ? dt.Rows[i]["DosageForm"].ToString() : "",
                        IngredentStrength = dt.Rows[i]["IngredentStrength"] != null ? dt.Rows[i]["IngredentStrength"].ToString() : "",
                        PackagePrice = dt.Rows[i]["PackagePrice"] != null ? dt.Rows[i]["PackagePrice"].ToString() : "",
                        GranularUnit = dt.Rows[i]["GranularUnit"] != null ? dt.Rows[i]["GranularUnit"].ToString() : "",
                        Manufacturer = dt.Rows[i]["Manufacturer"] != null ? dt.Rows[i]["Manufacturer"].ToString() : "",
                        RegisteredOwner = dt.Rows[i]["RegisteredOwner"] != null ? dt.Rows[i]["RegisteredOwner"].ToString() : ""
                    };
                    tradeNames.Add(obj);
                }
            }

            return tradeNames;
        }
        public string InsertUpdateDeleteDrug(DrugModelAll drug)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDrug", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DrugId", drug.DrugId);
                cmd.Parameters.AddWithValue("@DrugCode", drug.DrugCode);
                cmd.Parameters.AddWithValue("@DosageForm", drug.DosageForm);
                cmd.Parameters.AddWithValue("@DrugName", drug.DrugName);
                cmd.Parameters.AddWithValue("@Ingredient", drug.Ingredient);
                cmd.Parameters.AddWithValue("@Form", drug.Form);
                cmd.Parameters.AddWithValue("@MarketStatus", drug.MarketStatus);
                cmd.Parameters.AddWithValue("@Remarks", drug.Remarks);
                cmd.Parameters.AddWithValue("@IngredientStrength", drug.IngredientStrength);
                cmd.Parameters.AddWithValue("@DDCCode", drug.DDCCode);
                cmd.Parameters.AddWithValue("@PackageNo", drug.PackageNo);
                cmd.Parameters.AddWithValue("@DrugTypeId", drug.DrugTypeId);
                cmd.Parameters.AddWithValue("@RouteId", drug.RouteId);
                cmd.Parameters.AddWithValue("@ScientificId", drug.ScientificId);
                cmd.Parameters.AddWithValue("@TradeId", drug.TradeId);
                cmd.Parameters.AddWithValue("@IsDeleted", drug.IsDeleted);
                cmd.Parameters.AddWithValue("@ZoneId", drug.ZoneId);
                cmd.Parameters.AddWithValue("@BranchId", drug.BranchId);
                cmd.Parameters.AddWithValue("@UserId", drug.UserId);
                cmd.Parameters.AddWithValue("@IsDisplayed", drug.IsDisplayed);

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
                if (descrip == "Saved Successfully" || descrip == "Deleted Successfully")
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
        public List<DrugModel> GetDrug(DrugModelAll drug)
        {
            List<DrugModel> drugs = new List<DrugModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDrug", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugId", drug.DrugId);
            cmd.Parameters.AddWithValue("@DrugTypeId", drug.DrugTypeId);
            cmd.Parameters.AddWithValue("@ShowAll", drug.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", drug.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))

            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {

                    DrugModel obj = new DrugModel();
                    obj.DrugId = dt.Rows[i]["DrugId"] != null ? Convert.ToInt32(dt.Rows[i]["DrugId"]) : 0;
                    obj.DrugCode = dt.Rows[i]["DrugCode"] != null ? dt.Rows[i]["DrugCode"].ToString() : "";
                    obj.DrugName = dt.Rows[i]["DrugName"] != null ? dt.Rows[i]["DrugName"].ToString() : "";
                    obj.Ingredient = dt.Rows[i]["Ingredient"] != null ? dt.Rows[i]["Ingredient"].ToString() : "";
                    obj.Form = dt.Rows[i]["Form"] != null ? dt.Rows[i]["Form"].ToString() : "";
                    obj.MarketStatus = dt.Rows[i]["MarketStatus"] != null ? Convert.ToInt32(dt.Rows[i]["MarketStatus"]) : 0;
                    obj.Status = dt.Rows[i]["Status"] != null ? dt.Rows[i]["Status"].ToString() : "";
                    obj.Remarks = dt.Rows[i]["Remarks"] != null ? dt.Rows[i]["Remarks"].ToString() : "";
                    obj.IngredientStrength = dt.Rows[i]["IngredientStrength"] != null ? dt.Rows[i]["IngredientStrength"].ToString() : "";
                    obj.DDCCode = dt.Rows[i]["DDCCode"] != null ? dt.Rows[i]["DDCCode"].ToString() : "";
                    obj.PackageNo = dt.Rows[i]["PackageNo"] != null ? dt.Rows[i]["PackageNo"].ToString() : "";
                    obj.DrugTypeId = dt.Rows[i]["DrugTypeId"] != null ? Convert.ToInt32(dt.Rows[i]["DrugTypeId"]) : 0;
                    obj.RouteId = dt.Rows[i]["RouteId"] != null ? Convert.ToInt32(dt.Rows[i]["RouteId"]) : 0;
                    obj.ScientificId = dt.Rows[i]["ScientificId"] != null ? Convert.ToInt32(dt.Rows[i]["ScientificId"]) : 0;
                    obj.TradeId = dt.Rows[i]["TradeId"] != null ? Convert.ToInt32(dt.Rows[i]["TradeId"]) : 0;
                    obj.IsDeleted = dt.Rows[i]["IsDeleted"] != null ? Convert.ToInt32(dt.Rows[i]["IsDeleted"]) : 0;
                    obj.ZoneId = dt.Rows[i]["ZoneId"] != null ? Convert.ToInt32(dt.Rows[i]["ZoneId"]) : 0;
                    obj.DosageForm = dt.Rows[i]["DosageForm"] != null ? dt.Rows[i]["DosageForm"].ToString() : "";
                    obj.IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]);
                    obj.ScientificNameDetails = new ScientificNameModel
                    {
                        ScientificId = dt.Rows[i]["ScientificId"] != null ? Convert.ToInt32(dt.Rows[i]["ScientificId"]) : 0,
                        ScientificCode = dt.Rows[i]["ScientificCode"] != null ? dt.Rows[i]["ScientificCode"].ToString() : "",
                        ScientificName = dt.Rows[i]["ScientificName"] != null ? dt.Rows[i]["ScientificName"].ToString() : "",
                    };
                    obj.RouteDetails = new RouteModel
                    {
                        RouteId = dt.Rows[i]["RouteId"] != null ? Convert.ToInt32(dt.Rows[i]["RouteId"]) : 0,
                        RouteDesc = dt.Rows[i]["RouteDesc"] != null ? dt.Rows[i]["RouteDesc"].ToString() : "",
                    };
                    obj.TradeNameDetails = new TradeNameModel
                    {
                        TradeId = dt.Rows[i]["TradeId"] != null ? Convert.ToInt32(dt.Rows[i]["TradeId"]) : 0,
                        TradeCode = dt.Rows[i]["TradeCode"] != null ? dt.Rows[i]["TradeCode"].ToString() : "",
                        TradeName = dt.Rows[i]["TradeName"] != null ? dt.Rows[i]["TradeName"].ToString() : "",
                        ScientificId = dt.Rows[i]["ScientificId"] != null ? Convert.ToInt32(dt.Rows[i]["ScientificId"]) : 0,
                        RouteId = dt.Rows[i]["RouteId"] != null ? Convert.ToInt32(dt.Rows[i]["RouteId"]) : 0,
                        DosageForm = dt.Rows[i]["DosageForm"] != null ? dt.Rows[i]["DosageForm"].ToString() : "",
                        IngredentStrength = dt.Rows[i]["IngredentStrength"] != null ? dt.Rows[i]["IngredentStrength"].ToString() : "",
                        PackagePrice = dt.Rows[i]["PackagePrice"] != null ? dt.Rows[i]["PackagePrice"].ToString() : "",
                        GranularUnit = dt.Rows[i]["GranularUnit"] != null ? dt.Rows[i]["GranularUnit"].ToString() : "",
                        Manufacturer = dt.Rows[i]["Manufacturer"] != null ? dt.Rows[i]["Manufacturer"].ToString() : "",
                        RegisteredOwner = dt.Rows[i]["RegisteredOwner"] != null ? dt.Rows[i]["RegisteredOwner"].ToString() : "",
                    };

                    drugs.Add(obj);
                }
            }

            return drugs;
        }
        public string InsertUpdateDeleteInformedConsent(InformedConsentModelAll informedConsent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateInformedConsent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", informedConsent.ContentId);
                cmd.Parameters.AddWithValue("@CGroupId", informedConsent.CGroupId);
                cmd.Parameters.AddWithValue("@EnglishTxt", informedConsent.CTEnglish);
                cmd.Parameters.AddWithValue("@ArabicTxt", informedConsent.CTArabic);
                cmd.Parameters.AddWithValue("@DisplayOrder", informedConsent.DisplayOrder);
                cmd.Parameters.AddWithValue("@BranchId", informedConsent.BranchId);
                cmd.Parameters.AddWithValue("@UserId", informedConsent.UserId);
                cmd.Parameters.AddWithValue("@IsDeleted", informedConsent.IsDeleted);
                cmd.Parameters.AddWithValue("@IsDisplayed", informedConsent.IsDisplayed);


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
        public List<InformedConsentModel> GetInformedConsent(InformedConsentModelAll informedConsent)
        {
            List<InformedConsentModel> informedConsents = new List<InformedConsentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetInformedConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", informedConsent.ContentId);
            cmd.Parameters.AddWithValue("@ShowAll", informedConsent.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", informedConsent.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))

            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    InformedConsentModel obj = new InformedConsentModel();
                    obj.ContentId = dt.Rows[i]["ContentId"] != null ? Convert.ToInt32(dt.Rows[i]["ContentId"]) : 0;
                    obj.CTEnglish = dt.Rows[i]["CTEnglish"] != null ? dt.Rows[i]["CTEnglish"].ToString() : "";
                    obj.CTArabic = dt.Rows[i]["CTArabic"] != null ? dt.Rows[i]["CTArabic"].ToString() : "";
                    obj.DisplayOrder = dt.Rows[i]["DisplayOrder"] != null ? Convert.ToInt32(dt.Rows[i]["DisplayOrder"]) : 0;
                    obj.CType = dt.Rows[i]["CType"] != null ? dt.Rows[i]["CType"].ToString() : "";
                    obj.CGroupId = dt.Rows[i]["CGroupId"] != null ? Convert.ToInt32(dt.Rows[i]["CGroupId"]) : 0;
                    obj.CGroupName = dt.Rows[i]["CGroupName"] != null ? dt.Rows[i]["CGroupName"].ToString() : "";
                    obj.IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]);
                    informedConsents.Add(obj);
                }
            }

            return informedConsents;
        }
        public string InsertUpdateDeletePatientConsent(PatientConsentModelAll patientConsent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePatConsent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", patientConsent.ContentId);
                cmd.Parameters.AddWithValue("@EnglishTxt", patientConsent.CTEnglish);
                cmd.Parameters.AddWithValue("@ArabicTxt", patientConsent.CTArabic);
                cmd.Parameters.AddWithValue("@DisplayOrder", patientConsent.DisplayOrder);
                cmd.Parameters.AddWithValue("@BranchId", patientConsent.BranchId);
                cmd.Parameters.AddWithValue("@UserId", patientConsent.UserId);
                cmd.Parameters.AddWithValue("@IsDeleted", patientConsent.IsDeleted);
                cmd.Parameters.AddWithValue("@IsDisplayed", patientConsent.IsDisplayed);


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
        public List<PatientConsentModel> GetPatientConsent(PatientConsentModelAll patientConsent)
        {
            List<PatientConsentModel> patientConsents = new List<PatientConsentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPatConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", patientConsent.ContentId);
            cmd.Parameters.AddWithValue("@ShowAll", patientConsent.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", patientConsent.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))

            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    PatientConsentModel obj = new PatientConsentModel();
                    obj.ContentId = dt.Rows[i]["ContentId"] != null ? Convert.ToInt32(dt.Rows[i]["ContentId"]) : 0;
                    obj.CTEnglish = dt.Rows[i]["CTEnglish"] != null ? dt.Rows[i]["CTEnglish"].ToString() : "";
                    obj.CTArabic = dt.Rows[i]["CTArabic"] != null ? dt.Rows[i]["CTArabic"].ToString() : "";
                    obj.DisplayOrder = dt.Rows[i]["DisplayOrder"] != null ? Convert.ToInt32(dt.Rows[i]["DisplayOrder"]) : 0;
                    obj.CType = dt.Rows[i]["CType"] != null ? dt.Rows[i]["CType"].ToString() : "";
                    obj.CGroupId = dt.Rows[i]["CGroupId"] != null ? Convert.ToInt32(dt.Rows[i]["CGroupId"]) : 0;
                    obj.IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]);
                    patientConsents.Add(obj);
                }
            }

            return patientConsents;
        }
        public string InsertUpdateDeleteSponserConsent(SponserConsentModelAll sponserConsent)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorConsent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", sponserConsent.ContentId);
                cmd.Parameters.AddWithValue("@EnglishTxt", sponserConsent.CTEnglish);
                cmd.Parameters.AddWithValue("@ArabicTxt", sponserConsent.CTArabic);
                cmd.Parameters.AddWithValue("@DisplayOrder", sponserConsent.DisplayOrder);
                cmd.Parameters.AddWithValue("@BranchId", sponserConsent.BranchId);
                cmd.Parameters.AddWithValue("@SponsorId", sponserConsent.SponsorId);
                cmd.Parameters.AddWithValue("@UserId", sponserConsent.UserId);
                cmd.Parameters.AddWithValue("@IsDeleted", sponserConsent.IsDeleted);
                cmd.Parameters.AddWithValue("@IsDisplayed", sponserConsent.IsDisplayed);


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
        public List<SponserConsentModel> GetSponserConsent(SponserConsentModelAll sponserConsent)
        {
            List<SponserConsentModel> informedConsents = new List<SponserConsentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", sponserConsent.ContentId);
            cmd.Parameters.AddWithValue("@ShowAll", sponserConsent.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sponserConsent.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))

            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    SponserConsentModel obj = new SponserConsentModel();
                    obj.ContentId = dt.Rows[i]["ContentId"] != null ? Convert.ToInt32(dt.Rows[i]["ContentId"]) : 0;
                    obj.CTEnglish = dt.Rows[i]["CTEnglish"] != null ? dt.Rows[i]["CTEnglish"].ToString() : "";
                    obj.CTArabic = dt.Rows[i]["CTArabic"] != null ? dt.Rows[i]["CTArabic"].ToString() : "";
                    obj.DisplayOrder = dt.Rows[i]["DisplayOrder"] != null ? Convert.ToInt32(dt.Rows[i]["DisplayOrder"]) : 0;


                    obj.SponsorId = dt.Rows[i]["SponsorId"] != null ? Convert.ToInt32(dt.Rows[i]["SponsorId"]) : 0;
                    obj.SponsorName = dt.Rows[i]["SponsorName"] != null ? dt.Rows[i]["SponsorName"].ToString() : "";
                    obj.IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]);


                    informedConsents.Add(obj);
                }
            }

            return informedConsents;
        }
        public List<DosageModel> GetDosage(DosageModelAll dosageModel)
        {
            List<DosageModel> dosageList = new List<DosageModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetDosage", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DosageId", dosageModel.DosageId);
            cmd.Parameters.AddWithValue("@BranchId", dosageModel.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", dosageModel.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    DosageModel obj = new DosageModel
                    {
                        DosageId = dt.Rows[i]["DosageId"] != null ? Convert.ToInt32(dt.Rows[i]["DosageId"]) : 0,
                        DosageDesc = dt.Rows[i]["DosageDesc"] != null ? dt.Rows[i]["DosageDesc"].ToString() : "",
                        ZoneId = dt.Rows[i]["ZoneId"] != null ? Convert.ToInt32(dt.Rows[i]["ZoneId"]) : 0,
                        IsDisplayed = dt.Rows[i]["IsDisplayed"] != null ? Convert.ToInt32(dt.Rows[i]["IsDisplayed"]) : 0,
                        IsDeleted = dt.Rows[i]["IsDeleted"] != null ? Convert.ToInt32(dt.Rows[i]["IsDeleted"]) : 0,
                        DosageValue = dt.Rows[i]["DosageValue"] != null ? Convert.ToDouble(dt.Rows[i]["DosageValue"]) : 0,
                    };
                    dosageList.Add(obj);
                }
            }
            return dosageList;
        }
        public string InsertUpdateDeleteDosage(DosageModelAll dosageModel)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateDose", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DosageId", dosageModel.DosageId);
                cmd.Parameters.AddWithValue("@DosageDesc", dosageModel.DosageDesc);
                cmd.Parameters.AddWithValue("@DosageValue", dosageModel.DosageValue);
                cmd.Parameters.AddWithValue("@ZoneId", dosageModel.ZoneId);
                cmd.Parameters.AddWithValue("@BranchId", dosageModel.BranchId);
                cmd.Parameters.AddWithValue("@UserId", dosageModel.UserId);
                cmd.Parameters.AddWithValue("@IsDeleted", dosageModel.IsDeleted);
                cmd.Parameters.AddWithValue("@IsDisplayed", dosageModel.IsDisplayed);


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
        public List<FrequencyModel> GetFrequency(FrequencyModelAll frequency)
        {
            List<FrequencyModel> frequencies = new List<FrequencyModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetFrequency", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FreqId", frequency.FreqId);
            cmd.Parameters.AddWithValue("@BranchId", frequency.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", frequency.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    FrequencyModel obj = new FrequencyModel
                    {
                        FreqId = dt.Rows[i]["FreqId"] != null ? Convert.ToInt32(dt.Rows[i]["FreqId"]) : 0,
                        FreqDesc = dt.Rows[i]["FreqDesc"] != null ? dt.Rows[i]["FreqDesc"].ToString() : "",
                        FreqValue = dt.Rows[i]["FreqValue"] != null ? Convert.ToInt32(dt.Rows[i]["FreqValue"]) : 0,
                        ZoneId = dt.Rows[i]["ZoneId"] != null ? Convert.ToInt32(dt.Rows[i]["ZoneId"]) : 0,
                        IsDisplayed = dt.Rows[i]["IsDisplayed"] != null ? Convert.ToInt32(dt.Rows[i]["IsDisplayed"]) : 0,
                        IsDeleted = dt.Rows[i]["IsDeleted"] != null ? Convert.ToInt32(dt.Rows[i]["IsDeleted"]) : 0,
                    };
                    frequencies.Add(obj);
                }
            }
            return frequencies;
        }
        public string InsertUpdateDeleteFrequency(FrequencyModelAll frequency)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateFrequency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FreqId", frequency.FreqId);
                cmd.Parameters.AddWithValue("@FreqDesc", frequency.FreqDesc);
                cmd.Parameters.AddWithValue("@FreqValue", frequency.FreqValue);

                cmd.Parameters.AddWithValue("@ZoneId", frequency.ZoneId);
                cmd.Parameters.AddWithValue("@BranchId", frequency.BranchId);
                cmd.Parameters.AddWithValue("@UserId", frequency.UserId);
                cmd.Parameters.AddWithValue("@IsDeleted", frequency.IsDeleted);
                cmd.Parameters.AddWithValue("@IsDisplayed", frequency.IsDisplayed);


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
        public List<ConsentGroupModel> GetConsentGroup()
        {
            List<ConsentGroupModel> consentGroups = new List<ConsentGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsentGroup", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ConsentGroupModel obj = new ConsentGroupModel
                    {
                        CGroupID = dt.Rows[i]["CGroupID"] != null ? Convert.ToInt32(dt.Rows[i]["CGroupID"]) : 0,
                        CGroupName = dt.Rows[i]["CGroupName"] != null ? dt.Rows[i]["CGroupName"].ToString() : "",

                    };
                    consentGroups.Add(obj);
                }
            }
            return consentGroups;
        }
        public List<CommonMasterFieldModel> GetMarketStatus(CommonMasterFieldModelAll ms)
        {
            List<CommonMasterFieldModel> marketstatus = new List<CommonMasterFieldModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetMarketStatus", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ms.Id);
            cmd.Parameters.AddWithValue("@BranchId", ms.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", ms.ShowAll);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CommonMasterFieldModel obj = new CommonMasterFieldModel
                    {
                        Id = dt.Rows[i]["Id"] != null ? Convert.ToInt32(dt.Rows[i]["Id"]) : 0,
                        NameData = dt.Rows[i]["MarketStatus"] != null ? dt.Rows[i]["MarketStatus"].ToString() : "",
                    };
                    marketstatus.Add(obj);
                }
            }
            return marketstatus;
        }
    }
}
