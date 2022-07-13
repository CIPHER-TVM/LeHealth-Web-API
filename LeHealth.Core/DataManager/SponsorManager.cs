using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Linq;

namespace LeHealth.Core.DataManager
{
    public class SponsorManager : ISponsorManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public SponsorManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }


        public List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm)
        {
            List<SponsorFormModel> formList = new List<SponsorFormModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorForms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SFormId", frm.SFormId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtform = new DataTable();
            adapter.Fill(dtform);
            con.Close();
            if ((dtform != null) && (dtform.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtform.Rows.Count; i++)
                {
                    SponsorFormModel obj = new SponsorFormModel
                    {

                        SFormId = Convert.ToInt32(dtform.Rows[i]["SFormId"]),
                        SFormName = dtform.Rows[i]["SFormName"].ToString(),
                        BlockReason = dtform.Rows[i]["BlockReason"].ToString(),
                        IsDisplayed = Convert.ToInt32(dtform.Rows[i]["IsDisplayed"])

                    };
                    formList.Add(obj);
                }
            }
            return formList;
        }


        public string InsertUpdateSponsorForms(SponsorFormModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorForm", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SFormId", obj.SFormId);
                    cmd.Parameters.AddWithValue("@SFormName", obj.SFormName);
                    //cmd.Parameters.AddWithValue("@BlockReason", obj.GroupId);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);


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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public string InsertSponsorRuleGroup(SponsorGroupModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertSponsorRuleGroup", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@GroupId", obj.GroupId);
                    cmd.Parameters.AddWithValue("@DiscPcnt", obj.DiscPcnt);
                    cmd.Parameters.AddWithValue("@DiscAmount", obj.DiscAmount);
                    cmd.Parameters.AddWithValue("@DedGroup", obj.DedGroup);
                    cmd.Parameters.AddWithValue("@CoPayGroup", obj.CoPayGroup);
                    cmd.Parameters.AddWithValue("@DedAmt", obj.DedAmt);
                    cmd.Parameters.AddWithValue("@DedPer", obj.DedPer);
                    cmd.Parameters.AddWithValue("@CoPayAmt", obj.CoPayAmt);
                    cmd.Parameters.AddWithValue("@CopayPer", obj.CopayPer);


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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public string DeleteSponsorRuleItem(SponsorGropuServiceItemModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSponsorRuleItem", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);


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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }



        public string InsertSponsorRuleItem(SponsorGropuServiceItemModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertSponsorRuleItem", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@ItemId", obj.ItemId);
                    cmd.Parameters.AddWithValue("@NewName", obj.NewName);
                    cmd.Parameters.AddWithValue("@Rate", obj.Rate);
                    cmd.Parameters.AddWithValue("@DiscPcnt", obj.DiscPcnt);
                    cmd.Parameters.AddWithValue("@DiscAmount", obj.DiscAmount);
                    cmd.Parameters.AddWithValue("@CoPayItem", obj.CoPayItem);
                    cmd.Parameters.AddWithValue("@DedItem", obj.DedItem);
                    cmd.Parameters.AddWithValue("@AuthReq", obj.AuthReq);

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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public List<SponsorGropuServiceItemModel> GetSponsorItemForRule(SponsorGropuServiceItemModel itm)
        {
            List<SponsorGropuServiceItemModel> itemList = new List<SponsorGropuServiceItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorItemForRule", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RuleId", itm.RuleId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtitem = new DataTable();
            adapter.Fill(dtitem);
            con.Close();
            if ((dtitem != null) && (dtitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtitem.Rows.Count; i++)
                {
                    SponsorGropuServiceItemModel obj = new SponsorGropuServiceItemModel
                    {
                        ItemId = Convert.ToInt32(dtitem.Rows[i]["ItemId"]),
                        GroupId = Convert.ToInt32(dtitem.Rows[i]["GroupId"]),
                        SponsorId = Convert.ToInt32(dtitem.Rows[i]["SponsorId"]),
                        ItemName = dtitem.Rows[i]["ItemName"].ToString(),
                        NewName = dtitem.Rows[i]["NewName"].ToString(),
                        CPTCode = dtitem.Rows[i]["CPTCode"].ToString(),
                        StdRate = (float)Convert.ToDouble(dtitem.Rows[i]["StdRate"].ToString()),
                        DiscPcnt = (float)Convert.ToDouble(dtitem.Rows[i]["DiscPcnt"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dtitem.Rows[i]["DiscAmount"].ToString()),
                        // DedGroup = Convert.ToInt32(dtgroup.Rows[i]["UpfrontDed"]),
                        Rate = (float)Convert.ToDouble(dtitem.Rows[i]["Rate"].ToString()),
                        DedItem = Convert.ToInt32(dtitem.Rows[i]["DedItem"]),
                        CoPayItem = Convert.ToInt32(dtitem.Rows[i]["CoPayItem"]),
                        RuleCategory = dtitem.Rows[i]["RuleCategory"].ToString(),
                        ItemCode = dtitem.Rows[i]["ItemCode"].ToString(),
                        AuthReq = Convert.ToInt32(dtitem.Rows[i]["AuthReq"])
                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }


        public List<SponsorGroupModel> GetSponsorGroupForRule(SponsorGroupModel grp)
        {
            List<SponsorGroupModel> groupList = new List<SponsorGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorGroupForRule", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RuleId", grp.RuleId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtgroup = new DataTable();
            adapter.Fill(dtgroup);
            con.Close();
            if ((dtgroup != null) && (dtgroup.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtgroup.Rows.Count; i++)
                {
                    SponsorGroupModel obj = new SponsorGroupModel
                    {

                        GroupId = Convert.ToInt32(dtgroup.Rows[i]["GroupId"]),
                        // SponsorId = Convert.ToInt32(dtgroup.Rows[i]["SponsorId"]),
                        GroupName = dtgroup.Rows[i]["GroupName"].ToString(),
                        DedGroup = Convert.ToInt32(dtgroup.Rows[i]["DedGroup"]),
                        DiscPcnt = (float)Convert.ToDouble(dtgroup.Rows[i]["DiscPcnt"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dtgroup.Rows[i]["DiscAmount"].ToString()),
                        // DedGroup = Convert.ToInt32(dtgroup.Rows[i]["UpfrontDed"]),
                        CoPayGroup = Convert.ToInt32(dtgroup.Rows[i]["CoPayGroup"]),
                        DedAmt = (float)Convert.ToInt32(dtgroup.Rows[i]["DedAmt"]),
                        DedPer = (float)Convert.ToInt32(dtgroup.Rows[i]["DedPer"]),
                        CoPayAmt = (float)Convert.ToInt32(dtgroup.Rows[i]["CoPayAmt"]),
                        CopayPer = (float)Convert.ToInt32(dtgroup.Rows[i]["CopayPer"]),
                        RuleCategory = dtgroup.Rows[i]["RuleCategory"].ToString()



                    };
                    groupList.Add(obj);
                }
            }
            return groupList;
        }


        public List<SponsorRuleModel> GetRuleDescription(SponsorRuleModel ruledesc)
        {
            List<SponsorRuleModel> ruleList = new List<SponsorRuleModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorRuleS", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", ruledesc.SponsorId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtrules = new DataTable();
            adapter.Fill(dtrules);
            con.Close();
            if ((dtrules != null) && (dtrules.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtrules.Rows.Count; i++)
                {
                    SponsorRuleModel obj = new SponsorRuleModel
                    {

                        RuleId = Convert.ToInt32(dtrules.Rows[i]["RuleId"]),
                        SponsorId = Convert.ToInt32(dtrules.Rows[i]["SponsorId"]),
                        RuleDesc = dtrules.Rows[i]["RuleDesc"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dtrules.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dtrules.Rows[i]["CoPayPcnt"].ToString()),
                        UpfrontDed = Convert.ToInt32(dtrules.Rows[i]["UpfrontDed"]),
                        CopayBefDisc = Convert.ToInt32(dtrules.Rows[i]["CopayBefDisc"]),
                        RateGroupId = Convert.ToInt32(dtrules.Rows[i]["RateGroupId"]),
                        IsDisplayed = Convert.ToInt32(dtrules.Rows[i]["IsDisplayed"]),
                        IsDeleted = Convert.ToInt32(dtrules.Rows[i]["IsDeleted"]),
                        BranchId = Convert.ToInt32(dtrules.Rows[i]["BranchId"])



                    };
                    ruleList.Add(obj);
                }
            }
            return ruleList;
        }


        public string DeleteConsultantReduction(ConsultantReductionModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteConsultantReduction", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);

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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public string InsertConsultantReduction(ConsultantReductionModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertConsultantReduction", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultantId", obj.ConsultantId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@ItemGroupId", obj.ItemGroupId);
                    cmd.Parameters.AddWithValue("@DiscPerc", obj.DiscPerc);



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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public List<ConsultantReductionModel> GetConsultantReduction(ConsultantReductionModel creduction)
        {
            List<ConsultantReductionModel> reductionList = new List<ConsultantReductionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetConsultantReductionDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", creduction.SponsorId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtcreduction = new DataTable();
            adapter.Fill(dtcreduction);
            con.Close();
            if ((dtcreduction != null) && (dtcreduction.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtcreduction.Rows.Count; i++)
                {
                    ConsultantReductionModel obj = new ConsultantReductionModel
                    {

                        ItemGroupId = Convert.ToInt32(dtcreduction.Rows[i]["ItemGroupId"]),
                        ItemGroupName = dtcreduction.Rows[i]["ItemGroupName"].ToString(),
                        DiscPerc = (float)Convert.ToDouble(dtcreduction.Rows[i]["DiscPerc"].ToString()),



                    };
                    reductionList.Add(obj);
                }
            }
            return reductionList;
        }




        public string DeleteSponsorRuleDrugList(DrugModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteSponsorRuleDrugList", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);

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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public string InsertSponsorRuleDrugList(DrugModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertSponsorRuleDrugList", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);
                    cmd.Parameters.AddWithValue("@DrugId", obj.DrugId);
                    cmd.Parameters.AddWithValue("@DDCCode", obj.DDCCode);


                    //cmd.Parameters.AddWithValue("@P_Active", Convert.ToInt32(obj.Active));
                    //cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);


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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public List<DrugModelAll> GetDrugBySponsorRule(DrugModelAll drug)
        {
            List<DrugModelAll> drugList = new List<DrugModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorRuleDrugList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DrugId", drug.DrugId);
            cmd.Parameters.AddWithValue("@RuleId", drug.RuleId);
            cmd.Parameters.AddWithValue("@ShowAll", drug.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", drug.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtDrug = new DataTable();
            adapter.Fill(dtDrug);
            con.Close();
            if ((dtDrug != null) && (dtDrug.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtDrug.Rows.Count; i++)
                {
                    DrugModelAll obj = new DrugModelAll
                    {

                        DrugId = Convert.ToInt32(dtDrug.Rows[i]["DrugId"]),

                        DrugName = dtDrug.Rows[i]["DrugName"].ToString(),
                        TradeCode = dtDrug.Rows[i]["TradeCode"].ToString(),
                    };
                    drugList.Add(obj);
                }
            }
            return drugList;
        }


        public List<SponsorRuleModel> GetSponsorRule(SponsorRuleModel sponsorrule)
        {
            List<SponsorRuleModel> sponsorruleList = new List<SponsorRuleModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorRule", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RuleId", sponsorrule.RuleId);
            cmd.Parameters.AddWithValue("@ShowAll", sponsorrule.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sponsorrule.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtSponsorrule = new DataTable();
            adapter.Fill(dtSponsorrule);
            con.Close();
            if ((dtSponsorrule != null) && (dtSponsorrule.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtSponsorrule.Rows.Count; i++)
                {
                    SponsorRuleModel obj = new SponsorRuleModel
                    {

                        RuleId = Convert.ToInt32(dtSponsorrule.Rows[i]["RuleId"]),
                        SponsorId = Convert.ToInt32(dtSponsorrule.Rows[i]["SponsorId"]),
                        RuleDesc = dtSponsorrule.Rows[i]["RuleDesc"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dtSponsorrule.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dtSponsorrule.Rows[i]["CoPayPcnt"].ToString()),
                        UpfrontDed = Convert.ToInt32(dtSponsorrule.Rows[i]["UpfrontDed"]),
                        CopayBefDisc = Convert.ToInt32(dtSponsorrule.Rows[i]["CopayBefDisc"]),

                        RateGroupId = Convert.ToInt32(dtSponsorrule.Rows[i]["RateGroupId"]),
                        BranchId = Convert.ToInt32(dtSponsorrule.Rows[i]["BranchId"]),
                        IsDisplayed = Convert.ToInt32(dtSponsorrule.Rows[i]["IsDisplayed"]),
                        IsDeleted = Convert.ToInt32(dtSponsorrule.Rows[i]["IsDeleted"])
                    };
                    sponsorruleList.Add(obj);
                }
            }
            return sponsorruleList;
        }



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
                        ResNo = dtSponsor.Rows[i]["Phone"].ToString(),
                        VATRegNo = dtSponsor.Rows[i]["SpoVATRegNo"].ToString(),
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
                        UnclaimedId = Convert.ToInt32(dtSponsor.Rows[i]["UnclaimedId"]),
                        AgentData = JsonConvert.DeserializeObject<List<AgentforSponsorModel>>(dtSponsor.Rows[i]["AgentList"].ToString()),


                    };
                    sponsorList.Add(obj);
                }
            }
            return sponsorList;
        }

        public SponserConsentModelAll GetSponserConsentById(Int32 ContentId)
        {
            SponserConsentModelAll obj = new SponserConsentModelAll();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", ContentId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToObject<SponserConsentModelAll>();
            }
            return obj;
        }


        public List<SponserConsentModel> GetSponsorConsent(Int32 Branchid)
        {
            List<SponserConsentModel> obj = new List<SponserConsentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorConsent", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContentId", 0);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponserConsentModel>();
            }
            return obj;
        }
        public List<SponsorTypeModel> GetSponsorTypes()
        {
            List<SponsorTypeModel> obj = new List<SponsorTypeModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorType", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STypeId", 0);
           
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorTypeModel>();
            }
            return obj;
        }

       
        public List<SponsorFormModel> GetSponsorForms()
        {
            List<SponsorFormModel> obj = new List<SponsorFormModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorSForm", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", 0);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorFormModel>();
            }
            return obj;
        }

        public string InsertUpdateSponsor(SponsorMasterModelAll obj)
        {
            string response = string.Empty;
            
            string agentString = JsonConvert.SerializeObject(obj.AgentforSponsorList);
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_UpdateSponsor", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", Convert.ToInt32(obj.SponsorId));
                    cmd.Parameters.AddWithValue("@SponsorName", obj.SponsorName);
                    cmd.Parameters.AddWithValue("@SponsorType", obj.SponsorType);
                    cmd.Parameters.AddWithValue("@Address1", obj.Address1);
                    cmd.Parameters.AddWithValue("@Address2", obj.Address2);
                    cmd.Parameters.AddWithValue("@Street", obj.Street);
                    cmd.Parameters.AddWithValue("@PlacePO", obj.PlacePo);
                    cmd.Parameters.AddWithValue("@PIN", obj.PIN);
                    cmd.Parameters.AddWithValue("@City", obj.City);
                    cmd.Parameters.AddWithValue("@State", obj.State);
                    	
                    cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
                    cmd.Parameters.AddWithValue("@Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Fax", obj.Fax);
                    cmd.Parameters.AddWithValue("@ContactPerson", obj.ContactPerson);
                    cmd.Parameters.AddWithValue("@DedAmount", obj.DedAmount);
                    cmd.Parameters.AddWithValue("@CoPayPcnt", obj.CoPayPcnt);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
                    cmd.Parameters.AddWithValue("@UnclaimedId", obj.UnclaimedId);
                    cmd.Parameters.AddWithValue("@SFormId", obj.SFormId);

                    cmd.Parameters.AddWithValue("@SponsorLimit", obj.SponsorLimit);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@DHANo", obj.DHANo);
                    cmd.Parameters.AddWithValue("@EnableLimit", obj.EnableSponsorLimit);
                    cmd.Parameters.AddWithValue("@EnableConsent", obj.EnableSponsorConsent);
                    cmd.Parameters.AddWithValue("@AuthorizationMode", obj.AuthorizationMode);
                    cmd.Parameters.AddWithValue("@URL", obj.URL);
                    //cmd.Parameters.AddWithValue("@Phone", obj.Phone);
                    cmd.Parameters.AddWithValue("@SortOrder", obj.SortOrder);
                    cmd.Parameters.AddWithValue("@SpoVATRegNo", obj.VATRegNo);
                    cmd.Parameters.AddWithValue("@AgentJSON", agentString);
                    
                    //cmd.Parameters.AddWithValue("@P_Active", Convert.ToInt32(obj.Active));
                    //cmd.Parameters.AddWithValue("@P_BlockReason", obj.BlockReason);

                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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

        public string DeleteAgentSponsor(SponsorModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_DeleteAgentSponsor]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SponsorId", Convert.ToInt32(obj.SponsorId));

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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public string InsertAgentSponsor(SponsorModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("[stLH_InsertAgentSponsor]", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgentId", Convert.ToInt32(obj.AgentId));
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);

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

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public List<SponsorMasterModelAll> GetAllSponsors(Int32 Branchid)
        {
            List<SponsorMasterModelAll> obj = new List<SponsorMasterModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsor", con);
            con.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sponsorid", 0);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                obj = dt.ToListOfObject<SponsorMasterModelAll>();
            }
            return obj;
        }



        public string InsertUpdateSponsorConsent(SponserConsentModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateSponsorConsent", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContentId", obj.ContentId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
                    //cmd.Parameters.AddWithValue("@EnglishTxt", obj.CTEnglish);
                    //cmd.Parameters.AddWithValue("@ArabicTxt", obj.CTArabic);
                    cmd.Parameters.AddWithValue("@EnglishTxt", obj.CTEnglish);
                    cmd.Parameters.AddWithValue("@ArabicTxt", obj.CTArabic);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);

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

                    response = descrip;
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
