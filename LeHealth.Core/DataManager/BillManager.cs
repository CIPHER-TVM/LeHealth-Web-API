using LeHealth.Common;
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
    public class BillManager:IBillManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public BillManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        public List<AgentModel> GetSponsorAgent(AgentModel details)
        {
            List<AgentModel> itemList = new List<AgentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorAgent", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentId", details.AgentId);
            cmd.Parameters.AddWithValue("@IsDisplayed", details.IsDisplayed);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", details.ShowAll);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    AgentModel obj = new AgentModel
                    {
                       
                        AgentId =Convert.ToInt32( dt.Rows[i]["AgentId"].ToString()),
                        AgentName = dt.Rows[i]["AgentName"].ToString(),
                        Address1 = dt.Rows[i]["Address1"].ToString(),
                        Address2 = dt.Rows[i]["Address2"].ToString(),
                        Street = dt.Rows[i]["Street"].ToString(),
                        city = dt.Rows[i]["city"].ToString(),
                        PlacePO = dt.Rows[i]["PlacePO"].ToString(),
                        PIN = dt.Rows[i]["PIN"].ToString(),
                        State = dt.Rows[i]["State"].ToString(),
                        CountryId =Convert.ToInt32( dt.Rows[i]["CountryId"].ToString()),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Fax = dt.Rows[i]["Fax"].ToString(),
                        ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        DHANo = dt.Rows[i]["DHANo"].ToString(),
                        PayerId = dt.Rows[i]["PayerId"].ToString(),
                        HospitalId =Convert.ToInt32( dt.Rows[i]["HospitalId"].ToString()),
                       


                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }

        public List<UnBilledItemModel> GetUnBilledItem(UnBilledItemModel details)
        {
            List<UnBilledItemModel> itemList = new List<UnBilledItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetUnBilledItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", details.PatientId);
            cmd.Parameters.AddWithValue("@ConsultantId", details.ConsultantId);
            cmd.Parameters.AddWithValue("@External", details.External);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", details.ShowAll);
           
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbillitem = new DataTable();
            adapter.Fill(dtbillitem);
            con.Close();
            if ((dtbillitem != null) && (dtbillitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtbillitem.Rows.Count; i++)
                {
                    UnBilledItemModel obj = new UnBilledItemModel
                    {

                        Select = Convert.ToInt32(dtbillitem.Rows[i]["Select"]),
                        PostId = Convert.ToInt32(dtbillitem.Rows[i]["PostId"]),
                        PostDate = dtbillitem.Rows[i]["PostDate"].ToString(),
                        OrderDetId = Convert.ToInt32(dtbillitem.Rows[i]["OrderDetId"]),
                        LocationId = Convert.ToInt32(dtbillitem.Rows[i]["LocationId"]),
                        UserId = Convert.ToInt32(dtbillitem.Rows[i]["UserId"]),
                        ItemId = Convert.ToInt32(dtbillitem.Rows[i]["ItemId"]),
                        Nos = Convert.ToInt32(dtbillitem.Rows[i]["Nos"]),
                        PatientId = Convert.ToInt32(dtbillitem.Rows[i]["PatientId"]),                                             
                        ItemCode = dtbillitem.Rows[i]["ItemCode"].ToString(),                      
                        ItemName = dtbillitem.Rows[i]["ItemName"].ToString(),
                        User = dtbillitem.Rows[i]["User"].ToString(),
                        Location = dtbillitem.Rows[i]["Location"].ToString(),
                        Packid = Convert.ToInt32(dtbillitem.Rows[i]["Packid"]),
                        PayStatus = Convert.ToInt32(dtbillitem.Rows[i]["PayStatus"])


                    };
                    itemList.Add(obj);
                }
            }
            return itemList;
        }

        public List<BillItemModel> GetItemForSelectionByGroup(BillItemModel billdetails)
        {
            List<BillItemModel> itempList = new List<BillItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemForSelectionByGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CommItemsOnly", billdetails.CommItemsOnly);
            cmd.Parameters.AddWithValue("@GroupCode", billdetails.GroupCode.ToString());
            cmd.Parameters.AddWithValue("@SPointId", billdetails.SPointId);
            cmd.Parameters.AddWithValue("@ServiceTtems", billdetails.ServiceTtems);
            cmd.Parameters.AddWithValue("@GroupId", billdetails.GroupId);
            cmd.Parameters.AddWithValue("@BranchId", billdetails.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", billdetails.ShowAll);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbillitem = new DataTable();
            adapter.Fill(dtbillitem);
            con.Close();
            if ((dtbillitem != null) && (dtbillitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtbillitem.Rows.Count; i++)
                {
                    BillItemModel obj = new BillItemModel
                    {

                        GroupId = Convert.ToInt32(dtbillitem.Rows[i]["GroupId"]),
                        GroupName = dtbillitem.Rows[i]["GroupName"].ToString(),
                        GroupCode = dtbillitem.Rows[i]["GroupCode"].ToString(),
                        ItemCode = dtbillitem.Rows[i]["ItemCode"].ToString(),
                        ItemId = Convert.ToInt32(dtbillitem.Rows[i]["ItemId"]),
                        ItemName = dtbillitem.Rows[i]["ItemName"].ToString(),
                        Rate = (float)Convert.ToDouble(dtbillitem.Rows[i]["Rate"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dtbillitem.Rows[i]["DiscAmount"].ToString()),
                        TreatNos = Convert.ToInt32(dtbillitem.Rows[i]["TreatNos"].ToString()),
                        ItemSelected = Convert.ToInt32(dtbillitem.Rows[i]["ItemSelected"]),
                        CPTDesc = dtbillitem.Rows[i]["CPTDesc"].ToString(),

                    };
                    itempList.Add(obj);
                }
            }
            return itempList;
        }
        public List<BillItemModel> SearchServiceItem(BillItemModel billdetails)
        {
            List<BillItemModel> itempList = new List<BillItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchServiceItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CommItemsOnly", billdetails.CommItemsOnly);
            cmd.Parameters.AddWithValue("@GroupCode", billdetails.GroupCode.ToString());
            cmd.Parameters.AddWithValue("@SPointId", billdetails.SPointId);
            cmd.Parameters.AddWithValue("@ServiceTtems", billdetails.ServiceTtems);
            cmd.Parameters.AddWithValue("@ItemName", billdetails.ItemName);
            cmd.Parameters.AddWithValue("@BranchId", billdetails.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", billdetails.ShowAll);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbillitem = new DataTable();
            adapter.Fill(dtbillitem);
            con.Close();
            if ((dtbillitem != null) && (dtbillitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtbillitem.Rows.Count; i++)
                {
                    BillItemModel obj = new BillItemModel
                    {

                        GroupId = Convert.ToInt32(dtbillitem.Rows[i]["GroupId"]),
                        GroupName = dtbillitem.Rows[i]["GroupName"].ToString(),
                        GroupCode = dtbillitem.Rows[i]["GroupCode"].ToString(),
                        ItemCode = dtbillitem.Rows[i]["ItemCode"].ToString(),
                        ItemId = Convert.ToInt32(dtbillitem.Rows[i]["ItemId"]),
                        ItemName = dtbillitem.Rows[i]["ItemName"].ToString(),
                        Rate = (float)Convert.ToDouble(dtbillitem.Rows[i]["Rate"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dtbillitem.Rows[i]["DiscAmount"].ToString()),
                        TreatNos = Convert.ToInt32(dtbillitem.Rows[i]["TreatNos"].ToString()),
                        ItemSelected = Convert.ToInt32(dtbillitem.Rows[i]["ItemSelected"]),                    
                        CPTDesc = dtbillitem.Rows[i]["CPTDesc"].ToString(),
                      
                    };
                    itempList.Add(obj);
                }
            }
            return itempList;
        }
        public List<PackageItemsModel> GetPackageItem(PackageItemsModel details)
        {
            List<PackageItemsModel> packageitemList = new List<PackageItemsModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPackageItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PackId", details.PackId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtpackageitem = new DataTable();
            adapter.Fill(dtpackageitem);
            con.Close();
            if ((dtpackageitem != null) && (dtpackageitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtpackageitem.Rows.Count; i++)
                {
                    PackageItemsModel obj = new PackageItemsModel
                    {

                        itemId = Convert.ToInt32(dtpackageitem.Rows[i]["PackId"]),
                        itemCode = dtpackageitem.Rows[i]["PackDesc"].ToString(),
                        itemName = dtpackageitem.Rows[i]["EffectFrom"].ToString(),                       
                        rate = (float)Convert.ToDouble(dtpackageitem.Rows[i]["PackAmount"].ToString()),
                        quantity = Convert.ToInt16(dtpackageitem.Rows[i]["PackageItemRate"].ToString()),
                      
                       
                    };
                    packageitemList.Add(obj);
                }
            }
            return packageitemList;
        } 
        public List<PackageModelAll> GetPackage(PackageModelAll details)
        {
            List<PackageModelAll> packageList = new List<PackageModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPackage", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PackId", details.PackId);
            cmd.Parameters.AddWithValue("@ShowAll", details.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);
            


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtpackage = new DataTable();
            adapter.Fill(dtpackage);
            con.Close();
            if ((dtpackage != null) && (dtpackage.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtpackage.Rows.Count; i++)
                {
                    PackageModelAll obj = new PackageModelAll
                    {

                        PackId = Convert.ToInt32(dtpackage.Rows[i]["PackId"]),
                        IsDisplayed =Convert.ToBoolean( dtpackage.Rows[i]["IsDisplayed"]),
                        PackDesc = dtpackage.Rows[i]["PackDesc"].ToString(),
                        EffectFrom = dtpackage.Rows[i]["EffectFrom"].ToString(),
                        EffectTo = dtpackage.Rows[i]["EffectTo"].ToString(),
                        PackAmount = (float)Convert.ToDouble(dtpackage.Rows[i]["PackAmount"].ToString()),
                        PackageItemRate = (float)Convert.ToDouble(dtpackage.Rows[i]["PackageItemRate"].ToString()),
                        Remarks = dtpackage.Rows[i]["Remarks"].ToString()
                       
                    };
                    packageList.Add(obj);
                }
            }
            return packageList;
        }

        public List<BillItemModel> GetItemForSelection(BillItemModel billdetails)
        {
            List<BillItemModel> itempList = new List<BillItemModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetItemForSelection", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CommItemsOnly", billdetails.CommItemsOnly);
            cmd.Parameters.AddWithValue("@GroupCode", billdetails.GroupCode.ToString());
            cmd.Parameters.AddWithValue("@SPointId", billdetails.SPointId);
            cmd.Parameters.AddWithValue("@ServiceTtems", billdetails.ServiceTtems);
            cmd.Parameters.AddWithValue("@BranchId", billdetails.BranchId);
            cmd.Parameters.AddWithValue("@ShowAll", billdetails.ShowAll);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbillitem = new DataTable();
            adapter.Fill(dtbillitem);
            con.Close();
            if ((dtbillitem != null) && (dtbillitem.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtbillitem.Rows.Count; i++)
                {
                    BillItemModel obj = new BillItemModel
                    {

                        GroupId = Convert.ToInt32(dtbillitem.Rows[i]["GroupId"]),
                        ItemId = Convert.ToInt32(dtbillitem.Rows[i]["ItemId"]),
                        TreatNos = Convert.ToInt32(dtbillitem.Rows[i]["TreatNos"].ToString()),
                        ItemSelected = Convert.ToInt32(dtbillitem.Rows[i]["ItemSelected"]),
                        GroupName = dtbillitem.Rows[i]["GroupName"].ToString(),
                        GroupCode = dtbillitem.Rows[i]["GroupCode"].ToString(),
                        ItemCode = dtbillitem.Rows[i]["ItemCode"].ToString(),
                        DiscAmount = (float)Convert.ToDouble(dtbillitem.Rows[i]["DiscAmount"].ToString()),
                        Rate = (float)Convert.ToDouble(dtbillitem.Rows[i]["Rate"].ToString()),
                        CPTDesc = dtbillitem.Rows[i]["CPTDesc"].ToString(),
                        ItemName = dtbillitem.Rows[i]["ItemName"].ToString()




                    };
                    itempList.Add(obj);
                }
            }
            return itempList;
        }



        public string InsertUpdateCreditItemGroup(CreditItemGroupModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCreditItemGroup", con);
                try
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EntryId", obj.EntryId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@GroupId", obj.GroupId);
                    cmd.Parameters.AddWithValue("@DedAmt", obj.DedAmt);
                    cmd.Parameters.AddWithValue("@DedPer", obj.DedPer);
                    cmd.Parameters.AddWithValue("@CopayAmt", obj.CoPayAmt);
                    cmd.Parameters.AddWithValue("@CopayPer", obj.CopayPer);
                    
                    SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public List<CreditItemGroupModel> GetCreditItemGroup(CreditItemGroupModel spdetails)
        {
            List<CreditItemGroupModel> sponsorgrpList = new List<CreditItemGroupModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetCreditItemGroup", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RuleId", spdetails.RuleId);
            cmd.Parameters.AddWithValue("@CreditId", spdetails.CreditId);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtsponsorgrp = new DataTable();
            adapter.Fill(dtsponsorgrp);
            con.Close();
            if ((dtsponsorgrp != null) && (dtsponsorgrp.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtsponsorgrp.Rows.Count; i++)
                {
                    CreditItemGroupModel obj = new CreditItemGroupModel
                    {

                        SponsorId = Convert.ToInt32(dtsponsorgrp.Rows[i]["SponsorId"]),
                        CreditId = Convert.ToInt32(dtsponsorgrp.Rows[i]["CreditId"]),
                        EntryId =Convert.ToInt32(dtsponsorgrp.Rows[i]["EntryId"].ToString()),
                        GroupId = Convert.ToInt32(dtsponsorgrp.Rows[i]["GroupId"].ToString()),
                        GroupName = dtsponsorgrp.Rows[i]["GroupName"].ToString(),
                        DiscPcnt = (float)Convert.ToDouble(dtsponsorgrp.Rows[i]["DiscPcnt"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dtsponsorgrp.Rows[i]["DiscAmount"].ToString()),
                        DedGroup = Convert.ToInt32(dtsponsorgrp.Rows[i]["DedGroup"]),
                        CoPayGroup = Convert.ToInt32(dtsponsorgrp.Rows[i]["CoPayGroup"]),
                        DedAmt = (float)Convert.ToDouble(dtsponsorgrp.Rows[i]["DedPer"].ToString()),
                        CoPayAmt = (float)Convert.ToDouble(dtsponsorgrp.Rows[i]["CoPayAmt"].ToString()),
                        CopayPer = (float)Convert.ToDouble(dtsponsorgrp.Rows[i]["CopayPer"].ToString()),
                        RuleCategory = dtsponsorgrp.Rows[i]["RuleCategory"].ToString(),
                        GroupType = dtsponsorgrp.Rows[i]["GroupType"].ToString(),
                        GroupCode = dtsponsorgrp.Rows[i]["GroupCode"].ToString()




                    };
                    sponsorgrpList.Add(obj);
                }
            }
            return sponsorgrpList;
        }


        public List<PatientSponsorModel> GetSponsorDetailsByPatient(PatientSponsorModel sponsor)
        {
            List<PatientSponsorModel> sponsorList = new List<PatientSponsorModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPatientSponsorForCredit", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", sponsor.PatientId);
            

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtsponsor = new DataTable();
            adapter.Fill(dtsponsor);
            con.Close();
            if ((dtsponsor != null) && (dtsponsor.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtsponsor.Rows.Count; i++)
                {
                    PatientSponsorModel obj = new PatientSponsorModel
                    {

                        SponsorId = Convert.ToInt32(dtsponsor.Rows[i]["SponsorId"]),
                        CreditId = Convert.ToInt32(dtsponsor.Rows[i]["CreditId"]),
                        OpenDate = dtsponsor.Rows[i]["OpenDate"].ToString(),
                        SponsorName = dtsponsor.Rows[i]["SponsorName"].ToString(),
                        RefNo = dtsponsor.Rows[i]["RefNo"].ToString(),
                        Limit = (float)Convert.ToDouble(dtsponsor.Rows[i]["Limit"].ToString()),
                        Enjoyed = (float)Convert.ToDouble( dtsponsor.Rows[i]["Enjoyed"].ToString()),
                        Available = (float)Convert.ToDouble( dtsponsor.Rows[i]["Available"].ToString()),
                        Deduction = (float)Convert.ToDouble( dtsponsor.Rows[i]["Deduction"].ToString()),
                        CoPayment = (float)Convert.ToDouble( dtsponsor.Rows[i]["CoPayment"].ToString()),
                        PolicyNo = dtsponsor.Rows[i]["PolicyNo"].ToString(),
                        AgentName = dtsponsor.Rows[i]["AgentName"].ToString(),
                       

                    };
                    sponsorList.Add(obj);
                }
            }
            return sponsorList;
        }


        public List<PatientBillModel> SearchTodayPatientBill(PatientBillModel pat)
        {
            List<PatientBillModel> billList = new List<PatientBillModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_SearchTodayPatientBill", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegNo", pat.RegNo);
            cmd.Parameters.AddWithValue("@ConsultantId", pat.ConsultantId);
            cmd.Parameters.AddWithValue("@ConsultDate", pat.ConsultDate);         
            cmd.Parameters.AddWithValue("@BranchId", pat.BranchId);            
            cmd.Parameters.AddWithValue("@DeptId", pat.DeptId);
            cmd.Parameters.AddWithValue("@status", pat.status);            
            cmd.Parameters.AddWithValue("@Sponsorid", pat.Sponsorid);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtform = new DataTable();
            adapter.Fill(dtform);
            con.Close();
            if ((dtform != null) && (dtform.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtform.Rows.Count; i++)
                {
                    PatientBillModel obj = new PatientBillModel
                    {

                        ConsultationId = Convert.ToInt32(dtform.Rows[i]["ConsultationId"]),
                        RegNo = dtform.Rows[i]["RegNo"].ToString(),
                        PatientName = dtform.Rows[i]["PatientName"].ToString(),
                        ConsultantName = dtform.Rows[i]["ConsultantName"].ToString(),
                        Sponsor = dtform.Rows[i]["Sponsor"].ToString(),
                        PayStatus = dtform.Rows[i]["PayStatus"].ToString(),
                        Billdate = dtform.Rows[i]["Billdate"].ToString(),
                        PatientId = Convert.ToInt32(dtform.Rows[i]["PatientId"])

                    };
                    billList.Add(obj);
                }
            }
            return billList;
        }

        public string CancelReceipt(ReceiptModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelReceipt", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReceiptId", obj.ReceiptId);
                    cmd.Parameters.AddWithValue("@CancelReason", obj.CancelReason);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);



                    SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string CancelPayment(PaymentModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelPayment", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaymentId", obj.PaymentId);
                    cmd.Parameters.AddWithValue("@CancelReason", obj.CancelReason);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                   cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);



                    SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string InsertUpdatePayment(PaymentModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdatePayment", con);
                try
                {
                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaymentId", obj.PaymentId);
                    cmd.Parameters.AddWithValue("@PaymentNo", obj.PaymentNo);
                    cmd.Parameters.AddWithValue("@PayDate", obj.PayDate);
                    cmd.Parameters.AddWithValue("@PayType", obj.PayType);
                    cmd.Parameters.AddWithValue("@HeadId", obj.HeadId);
                    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);                   
                    cmd.Parameters.AddWithValue("@Mode", obj.Mode);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@ChqNo", obj.ChqNo);
                    cmd.Parameters.AddWithValue("@ChqDate", obj.ChqDate);
                    cmd.Parameters.AddWithValue("@ChqBranch", obj.ChqBranch);
                    //cmd.Parameters.AddWithValue("@CardType", obj.CardType);
                    //cmd.Parameters.AddWithValue("@CardNo", obj.CardNo);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@ShiftId", obj.ShiftId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    //cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    //cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                    cmd.Parameters.AddWithValue("@isdeleted", 0);
                    



                    SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();

                    response = descrip;
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string InsertUpdateReceipt(ReceiptModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stlh_insertupdatereceipt", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReceiptId", obj.ReceiptId);
                    cmd.Parameters.AddWithValue("@ReceiptNo", obj.ReceiptNo);
                    cmd.Parameters.AddWithValue("@RecDate", obj.RecDate);
                    cmd.Parameters.AddWithValue("@RecType", obj.RecType);
                    cmd.Parameters.AddWithValue("@HeadId", obj.HeadId);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                    cmd.Parameters.AddWithValue("@Mode", obj.Mode);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@CardType", obj.CardType);
                    cmd.Parameters.AddWithValue("@CardNo", obj.CardNo);
                    cmd.Parameters.AddWithValue("@ChqNo", obj.ChqNo);
                    cmd.Parameters.AddWithValue("@ChqDate", obj.ChqDate);
                    cmd.Parameters.AddWithValue("@ChqBranch", obj.ChqBranch);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@ShiftId", obj.ShiftId);
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                    cmd.Parameters.AddWithValue("@isdeleted", 0);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                   


                    SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();

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
