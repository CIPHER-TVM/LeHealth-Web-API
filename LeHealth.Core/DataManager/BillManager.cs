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
    public class BillManager:IBillManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public BillManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }

        //GetSponsorChequeReceiptDetails

        public List<ClaimReceiptModel> GetSponsorChequeReceiptDetails(ClaimReceiptModel details)
        {
            List<ClaimReceiptModel> claimList = new List<ClaimReceiptModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorChequeReceiptDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SponsorId", details.SponsorId);
            cmd.Parameters.AddWithValue("@ClaimReceiptId", details.ClaimReceiptId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimReceiptModel obj = new ClaimReceiptModel
                    {

                        // BillSelect = Convert.ToBoolean(dt.Rows[i]["BillSelect"]),
                        ReceiptId = Convert.ToInt32(dt.Rows[i]["ReceiptId"]),
                        RecType = Convert.ToInt32(dt.Rows[i]["RecType"]),
                        HeadId = Convert.ToInt32(dt.Rows[i]["HeadId"]),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"]),
                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"]),
                        Mode = Convert.ToInt32(dt.Rows[i]["Mode"]),
                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"]),
                        SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"]),
                        Active = Convert.ToInt32(dt.Rows[i]["Active"]),
                        

                        PaymentMode = dt.Rows[i]["PaymentMode"].ToString(),
                        ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                        CardType = dt.Rows[i]["CardType"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        ChqNo = dt.Rows[i]["ChqNo"].ToString(),
                        ChqDate = dt.Rows[i]["ChqDate"].ToString(),
                        ChqBranch = dt.Rows[i]["ChqBranch"].ToString(),
                        HeadDesc = dt.Rows[i]["HeadDesc"].ToString(),
                        SponsorName = dt.Rows[i]["SponsorName"].ToString(),


                        RecDate = dt.Rows[i]["RecDate"].ToString().Replace("/", "-"),


                        Amount = (float)Convert.ToDouble(dt.Rows[i]["Amount"].ToString()),
                        ReceivedAmount = (float)Convert.ToDouble(dt.Rows[i]["ReceivedAmount"].ToString()),
                        BalanceAmount = (float)Convert.ToDouble(dt.Rows[i]["BalanceAmount"].ToString()),

                    };
                    claimList.Add(obj);
                }
            }
            return claimList;
        }
        public List<ClaimReceiptModel> GetClaimReceiptList(ClaimReceiptModel details)
        {
            List<ClaimReceiptModel> claimList = new List<ClaimReceiptModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetClaimReceiptList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClaimId", details.ClaimId);
            cmd.Parameters.AddWithValue("@ClaimRecId", details.ClaimRecId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimReceiptModel obj = new ClaimReceiptModel
                    {

                       // BillSelect = Convert.ToBoolean(dt.Rows[i]["BillSelect"]),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"]),
                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"]),
                         ClaimRecId = Convert.ToInt32(dt.Rows[i]["ClaimRecId"]),
                        // ConsultationId = Convert.ToInt32(dt.Rows[i]["ConsultationId"]),
                        //  RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"]),

                        AsoapNo = dt.Rows[i]["AsoapNo"].ToString(),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        BillNo = dt.Rows[i]["BillNo"].ToString(),
                        ClaimNo = dt.Rows[i]["ClaimNo"].ToString(),
                        SponsorName = dt.Rows[i]["SponsorName"].ToString(),
                        AgentName = dt.Rows[i]["AgentName"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        ReceiptRemarks = dt.Rows[i]["ReceiptRemarks"].ToString(),

                        BillDate = dt.Rows[i]["BillDate"].ToString().Replace("/", "-"),
                        ClaimDate = dt.Rows[i]["ClaimDate"].ToString().Replace("/", "-"),
                        BillPeriod = dt.Rows[i]["BillPeriod"].ToString().Replace("/", "-"),
                        BillPeriodTo = dt.Rows[i]["BillPeriodTo"].ToString().Replace("/", "-"),
                        RecDate = dt.Rows[i]["RecDate"].ToString().Replace("/", "-"),

                        //BillAmount = (float)Convert.ToDouble(dt.Rows[i]["BillAmount"].ToString()),
                        InvoiceAmount = (float)Convert.ToDouble(dt.Rows[i]["InvoiceAmount"].ToString()),
                        //Discount = (float)Convert.ToDouble(dt.Rows[i]["Discount"].ToString()),

                        Collectedamount = (float)Convert.ToDouble(dt.Rows[i]["Collectedamount"].ToString()),
                        ReceivedAmount = (float)Convert.ToDouble(dt.Rows[i]["ReceivedAmount"].ToString()),

                        RecAmt = (float)Convert.ToDouble(dt.Rows[i]["RecAmt"].ToString()),
                        DeniedAmt = (float)Convert.ToDouble(dt.Rows[i]["DeniedAmt"].ToString()),
                        OutStanding = (float)Convert.ToDouble(dt.Rows[i]["OutStanding"].ToString()),
                        ClaimedAmount = (float)Convert.ToDouble(dt.Rows[i]["ClaimedAmount"].ToString()),

                    };
                    claimList.Add(obj);
                }
            }
            return claimList;
        }

        public string CancelClaimReceipt(ClaimReceiptModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelClaimReceipt", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@claimRecId", obj.ClaimRecId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    

                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public List<ClaimReceiptModel> GetClaimReceipts(ClaimReceiptModel details)
        {
            List<ClaimReceiptModel> claimList = new List<ClaimReceiptModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetClaimReceipts", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClaimId", details.ClaimId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimReceiptModel obj = new ClaimReceiptModel
                    {

                        
                        ClaimId = Convert.ToInt32(dt.Rows[i]["Claimid"]),
                        ClaimRecId = Convert.ToInt32(dt.Rows[i]["ClaimRecId"]),                       
                        RefNo = dt.Rows[i]["RefNo"].ToString(),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        Status = dt.Rows[i]["Status"].ToString(),         

                        RecDate = dt.Rows[i]["RecDate"].ToString().Replace("/", "-"),

                        TotRecAmt = (float)Convert.ToDouble(dt.Rows[i]["TotRecAmt"].ToString()),
                        TotDeniedAmt = (float)Convert.ToDouble(dt.Rows[i]["TotDeniedAmt"].ToString()),

                    };
                    claimList.Add(obj);
                }
            }
            return claimList;
        }
        public string CancelClaim(ClaimModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelClaim", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClaimId", obj.ClaimId);
                    cmd.Parameters.AddWithValue("@CancelReason", obj.CancelReason);
                    cmd.Parameters.AddWithValue("@Branchid", obj.Branchid);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);

                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public List<ClaimModelAll> GetClaimDetails(ClaimModelAll details)
        {
            List<ClaimModelAll> claimList = new List<ClaimModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetClaimDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClaimId", details.ClaimId);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimModelAll obj = new ClaimModelAll
                    {

                        BillSelect = Convert.ToBoolean(dt.Rows[i]["BillSelect"]),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"]),
                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"]),
                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"]),
                        ConsultationId = Convert.ToInt32(dt.Rows[i]["ConsultationId"]),
                        RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"]),

                        AsoapNo = dt.Rows[i]["AsoapNo"].ToString(),
                        AprovalNo = dt.Rows[i]["AprovalNo"].ToString(),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        BillNo = dt.Rows[i]["BillNo"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        Rule = dt.Rows[i]["Rule"].ToString(),

                        BillDate = dt.Rows[i]["BillDate"].ToString().Replace("/", "-"),
                      
                        BillAmount = (float)Convert.ToDouble(dt.Rows[i]["BillAmount"].ToString()),
                        ClaimAmt = (float)Convert.ToDouble(dt.Rows[i]["ClaimAmt"].ToString()),

                    };
                    claimList.Add(obj);
                }
            }
            return claimList;
        }

        public List<ClaimModelAll> GetClaim(ClaimModelAll sponsor)
        {
            List<ClaimModelAll> claimList = new List<ClaimModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetClaim", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClaimId", sponsor.ClaimId);
            cmd.Parameters.AddWithValue("@ShowAll", sponsor.ShowAll);
            cmd.Parameters.AddWithValue("@BranchId", sponsor.Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimModelAll obj = new ClaimModelAll
                    {

                        ClaimId = Convert.ToInt32(dt.Rows[i]["ClaimId"]),
                        SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"]),
                        ConsultantId = Convert.ToInt32(dt.Rows[i]["ConsultantId"]),
                        AgentId = Convert.ToInt32(dt.Rows[i]["AgentId"]),
                        RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"]),

                        RefNo = dt.Rows[i]["RefNo"].ToString(),
                        ClaimDate = dt.Rows[i]["ClaimDate"].ToString().Replace("/", "-"),
                        PeriodFrom = dt.Rows[i]["PeriodFrom"].ToString().Replace("/", "-"),
                        PeriodTo = dt.Rows[i]["PeriodTo"].ToString().Replace("/", "-"),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        ClaimAmount = (float)Convert.ToDouble(dt.Rows[i]["ClaimAmount"].ToString()),

                    };
                    claimList.Add(obj);
                }
            }
            return claimList;
        }

        public string InsertUpdateClaim(ClaimModelAll details)//(ServiceItemModel serviceItemModel)
        {
            string response1 = string.Empty;
            string response2 = string.Empty;
           
            string responseFinal = string.Empty;
            
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd1 = new SqlCommand("stLH_InsertUpdateClaim", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@ClaimId", details.ClaimId);
                cmd1.Parameters.AddWithValue("@ClaimDate", details.ClaimDate);
                cmd1.Parameters.AddWithValue("@RefNo", details.RefNo);
                cmd1.Parameters.AddWithValue("@ClaimAmount", details.ClaimAmount);
                //cmd1.Parameters.AddWithValue("@ChildGroupId", ChildId);
                cmd1.Parameters.AddWithValue("@SponsorId", details.SponsorId);
                cmd1.Parameters.AddWithValue("@UserId", details.UserId);
                cmd1.Parameters.AddWithValue("@PeriodFrom", details.PeriodFrom);
                cmd1.Parameters.AddWithValue("@PeriodTo", details.PeriodTo);
                cmd1.Parameters.AddWithValue("@AgentId", details.AgentId);
                cmd1.Parameters.AddWithValue("@Remarks", details.Remarks);
                cmd1.Parameters.AddWithValue("@Status", details.Status);
                cmd1.Parameters.AddWithValue("@ConsultantId", details.ConsultantId);
                cmd1.Parameters.AddWithValue("@SessionId", details.SessionId);
                cmd1.Parameters.AddWithValue("@RuleId", details.RuleId);
                cmd1.Parameters.AddWithValue("@Branchid", details.Branchid);
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
                    details.ClaimId = Convert.ToInt32(ret1);
                }
                else
                {
                    response1 = descrip1;
                    return response1;
                }
               
                if (response1 == "Success")
                {
                    using SqlCommand cmd3 = new SqlCommand("stLH_InsertUpdateClaimDet", con);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@Claimid", details.ClaimId);
                    string ClaimdetailsString = JsonConvert.SerializeObject(details.ClaimDetailList);
                    cmd3.Parameters.AddWithValue("@ClaimdetJSON", ClaimdetailsString);
                    cmd3.Parameters.AddWithValue("@UserId", details.UserId);
                    SqlParameter retValV2 = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd3.Parameters.Add(retValV2);
                    SqlParameter retDesc2 = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd3.Parameters.Add(retDesc2);
                    con.Open();
                    var isUpdated3 = cmd3.ExecuteNonQuery();
                    var ret2 = retValV2.Value;
                    var descrip2 = retDesc2.Value.ToString();
                    con.Close();
                    if (descrip2 == "Saved Successfully")
                    {
                        response2 = "Success";
                    }
                }
                if (response1 == "Success" &&  response2 == "Success")
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

        public string UpdateSOPerformingDetails(ServiceOrderModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_UpdateSOPerformingDetails", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@OrderDetId", obj.OrderDetId);
                    //cmd.Parameters.AddWithValue("@PerStaffId", obj.PerStaffId);
                    //cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
                    //cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                    //cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    //cmd.Parameters.AddWithValue("@ToothNo", obj.ToothNo);
                    //cmd.Parameters.AddWithValue("@PerLocation", obj.PerLocation);
                    //cmd.Parameters.AddWithValue("@UnlistedCodeValue", obj.UnlistedCodeValue);
                    //cmd.Parameters.AddWithValue("@LoginUserId", obj.LoginUserId);
                    //cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    string ServiceorderString = JsonConvert.SerializeObject(obj.ServiceorderList);
                    cmd.Parameters.AddWithValue("@SOPerformingDetailsJSON", ServiceorderString);

                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        public string UpdateApprovalNo(TransactionDetailsModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_UpdateApprovalNo", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Transid", obj.TransId);
                    cmd.Parameters.AddWithValue("@ItemId", obj.ItemId);
                    cmd.Parameters.AddWithValue("@AprovalNo", obj.AprovalNo);
                    
                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public List<TransactionDetailsModel> GetTransactionDetails(TransactionDetailsModel details)
        {

            List<TransactionDetailsModel> transList = new List<TransactionDetailsModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetTransactionDet", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransId", details.TransId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);
            cmd.Parameters.AddWithValue("@ShowAll", details.ShowAll);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    TransactionDetailsModel obj = new TransactionDetailsModel
                    {
                        TransDetId =Convert.ToInt32( dt.Rows[i]["TransDetId"].ToString()),
                        ItemId = Convert.ToInt32( dt.Rows[i]["ItemId"].ToString()),
                        ItemCode = dt.Rows[i]["ItemCode"].ToString(),
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        Rate = (float)Convert.ToDouble(dt.Rows[i]["Rate"].ToString()),
                        ActualRate = (float)Convert.ToDouble(dt.Rows[i]["ActualRate"].ToString()),
                        DiscPcnt = (float)Convert.ToDouble(dt.Rows[i]["DiscPcnt"].ToString()),
                        DiscAmount = (float)Convert.ToDouble(dt.Rows[i]["DiscAmount"].ToString()),
                        Qty = (float)Convert.ToDouble(dt.Rows[i]["Qty"].ToString()),
                        TaxAmount = (float)Convert.ToDouble(dt.Rows[i]["TaxAmount"].ToString()),
                        AllowRateEdit =Convert.ToBoolean( dt.Rows[i]["AllowRateEdit"].ToString()),
                        AllowDisc = Convert.ToBoolean( dt.Rows[i]["AllowDisc"].ToString()),
                        PostId = Convert.ToInt32( dt.Rows[i]["PostId"].ToString()),
                        OrderDetId = Convert.ToInt32( dt.Rows[i]["OrderDetId"].ToString()),
                        CreditId = Convert.ToInt32( dt.Rows[i]["CreditId"].ToString()),
                        DedItem = Convert.ToBoolean( dt.Rows[i]["DedItem"].ToString()),
                        CoPayItem = Convert.ToBoolean( dt.Rows[i]["CoPayItem"].ToString()),
                        ServiceDate = dt.Rows[i]["ServiceDate"].ToString().Replace("/","-"),
                        GroupId =Convert.ToInt32( dt.Rows[i]["GroupId"].ToString()),
                        AprovalNo = dt.Rows[i]["AprovalNo"].ToString(),
                    };

                    transList.Add(obj);
                }
            }
            return transList;
        }
        public string CloseCredit(CreditModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_ApproveCloseCredit", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
                    cmd.Parameters.AddWithValue("@Userid", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }
        public string ApproveCredit(CreditModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_ActionApproveCredit", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
                    cmd.Parameters.AddWithValue("@Userid", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    SqlParameter retval = new SqlParameter("@RetVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retval); 
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public List<CreditModel> GetTransactionSummary(CreditModel details)
        {

            List<CreditModel> transList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetTransactionSummary", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Creditid", details.CreditId);
            cmd.Parameters.AddWithValue("@Branchid", details.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {
                        Date = dt.Rows[i]["Date"].ToString().Replace("/", "-"),
                        RefNo = dt.Rows[i]["RefNo"].ToString(),
                        Particulars = dt.Rows[i]["Particulars"].ToString(),
                        Debit =(float)Convert.ToDouble( dt.Rows[i]["Debit"].ToString()),
                        Credit = (float)Convert.ToDouble(dt.Rows[i]["Credit"].ToString()),
                        Balance = (float)Convert.ToDouble(dt.Rows[i]["Balance"].ToString()),
                        BalType =dt.Rows[i]["BalType"].ToString(),
                        TransType = dt.Rows[i]["TransType"].ToString(),
                        PatAccNo = dt.Rows[i]["PatAccNo"].ToString(),
                        OpenDate = dt.Rows[i]["OpenDate"].ToString().Replace("/", "-"),
                        PatName = dt.Rows[i]["PatName"].ToString(),
                        RegNo = dt.Rows[i]["RegNo"].ToString(),
                    };

                    transList.Add(obj);
                }
            }
            return transList;
        }

        public List<ToothModel> GetToothNo(ToothModel details)
        {

            List<ToothModel> toothList = new List<ToothModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetToothNo", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Type", details.Type);
            

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ToothModel obj = new ToothModel
                    {                       
                        ToothId = Convert.ToInt32(dt.Rows[i]["ToothId"].ToString()),
                        ToothNo = dt.Rows[i]["ToothNo"].ToString(),
                       
                    };

                    toothList.Add(obj);
                }
            }
            return toothList;
        }

       public List<StaffModel> GetAllStaff(StaffModel details)
        {

            List<StaffModel> claimList = new List<StaffModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetAllStaff", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@staffid", details.StaffId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    StaffModel obj = new StaffModel
                    {                       
                        StaffId = Convert.ToInt32(dt.Rows[i]["StaffId"].ToString()),
                        Designation = dt.Rows[i]["Designation"].ToString(),
                        LicenceNo = dt.Rows[i]["LicenceNo"].ToString(),
                        Category = dt.Rows[i]["Category"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        DhaNo = dt.Rows[i]["DHANo"].ToString(),
                        IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"].ToString()),                       
                    };

                    claimList.Add(obj);
                }
            }
            return claimList;
        }



        public List<ServiceOrderModel> GetTransactionClaimDetails(ServiceOrderModel details)
        {

            List<ServiceOrderModel> claimList = new List<ServiceOrderModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetTransactionClaimDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransId", details.TransId);
            cmd.Parameters.AddWithValue("@OrderId", details.OrderId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ServiceOrderModel obj = new ServiceOrderModel
                    {

                        Selected = Convert.ToBoolean(dt.Rows[i]["Selected"].ToString()),
                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"].ToString()),
                        OrderDetId = Convert.ToInt32(dt.Rows[i]["OrderDetId"].ToString()),
                        ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"].ToString()),
                        PerStaffId = Convert.ToInt32(dt.Rows[i]["PerStaffId"].ToString()),
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        ToothNo = dt.Rows[i]["ToothNo"].ToString(),
                       // TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        StartDate = dt.Rows[i]["StartDate"].ToString().Replace("/", "-"),
                        EndDate = dt.Rows[i]["EndDate"].ToString().Replace("/", "-"),
                        PerLocation = dt.Rows[i]["PerLocation"].ToString(),
                        UnlistedCodeValue = dt.Rows[i]["UnlistedCodeValue"].ToString(),


                    };

                    claimList.Add(obj);
                }
            }
            return claimList;
        }
        public string VerifyClaim(ClaimModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_VerifyClaim", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConsultationId", obj.ConsultationId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);              
                    SqlParameter retdesc = new SqlParameter("@RetVal", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    var descrip = retdesc.Value.ToString();
                    con.Close();

                    response = descrip;

                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }


        public List<ClaimModel> GetSponsorshipDetails(ClaimModelAll details)
        {

            List<ClaimModel> claimList = new List<ClaimModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorshipDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", details.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", details.ToDate);
            cmd.Parameters.AddWithValue("@SponsorId", details.SponsorId);
            cmd.Parameters.AddWithValue("@AgentId", details.AgentId);
            cmd.Parameters.AddWithValue("@ClaimId", details.ClaimId);
            cmd.Parameters.AddWithValue("@ConsultantId", details.ConsultantId);
            cmd.Parameters.AddWithValue("@RuleId", details.RuleId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimModel obj = new ClaimModel
                    {
                        BillSelect = Convert.ToBoolean(dt.Rows[i]["BillSelect"].ToString()),
                        EncounterType = Convert.ToInt32(dt.Rows[i]["EncounterType"].ToString()),
                        AsoapNo = dt.Rows[i]["AsoapNo"].ToString(),

                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),
                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        BillDate = dt.Rows[i]["BillDate"].ToString().Replace("/", "-"),


                        BillNo = dt.Rows[i]["BillNo"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        TotalAmount = (float)Convert.ToDouble(dt.Rows[i]["TotalAmount"].ToString()),
                        BillAmount = (float)Convert.ToDouble(dt.Rows[i]["BillAmount"].ToString()),
                        ClaimAmt = (float)Convert.ToDouble(dt.Rows[i]["ClaimAmt"].ToString()),
                        CoPay = (float)Convert.ToDouble(dt.Rows[i]["CoPay"].ToString()),
                        Discount = (float)Convert.ToDouble(dt.Rows[i]["Discount"].ToString()),
                        Consultant = dt.Rows[i]["Consultant"].ToString(),
                        AprovalNo = dt.Rows[i]["AprovalNo"].ToString(),
                        RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"].ToString()),
                        ConsultationId = Convert.ToInt32(dt.Rows[i]["ConsultationId"].ToString()),
                        Rule = dt.Rows[i]["Rule"].ToString()

                    };

                    claimList.Add(obj);
                }
            }
            return claimList;
        }
        public List<ClaimModel> GetManageClaimForBilling(ClaimModelAll details)
        {

            List<ClaimModel> claimList = new List<ClaimModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetManageClaimForBilling", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", details.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", details.ToDate);
            cmd.Parameters.AddWithValue("@SponsorId", details.SponsorId);
            cmd.Parameters.AddWithValue("@AgentId", details.AgentId);
            cmd.Parameters.AddWithValue("@ConsultantId", details.ConsultantId);
            cmd.Parameters.AddWithValue("@Branchid", details.Branchid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ClaimModel obj = new ClaimModel
                    {

                        ClaimId = Convert.ToInt32(dt.Rows[i]["ClaimId"].ToString()),
                        SponsorName = dt.Rows[i]["SponsorName"].ToString(),
                        SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"].ToString()),
                        //RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"].ToString()),
                        AgentName = dt.Rows[i]["AgentName"].ToString(),
                        ClaimDate = dt.Rows[i]["ClaimDate"].ToString().Replace("/", "-"),
                        RefNo = dt.Rows[i]["RefNo"].ToString(),
                        ClaimAmount =(float) Convert.ToDouble(dt.Rows[i]["ClaimAmount"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        PeriodFrom = dt.Rows[i]["PeriodFrom"].ToString().Replace("/", "-"),
                        PeriodTo = dt.Rows[i]["PeriodTo"].ToString().Replace("/", "-"),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        Consultant = dt.Rows[i]["Consultant"].ToString(),
                       
                    };

                    claimList.Add(obj);
                }
            }
            return claimList;
        }
        public string ActionSettleBill(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_ActionSettleBill", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                   // cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);

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

        public string InsertTransactionPayment(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionPayment", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@Mode", obj.Mode);
                    cmd.Parameters.AddWithValue("@HeadId", obj.HeadId);
                    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                    cmd.Parameters.AddWithValue("@CardId", obj.CardId);
                    cmd.Parameters.AddWithValue("@CardNo", obj.CardNo);
                    cmd.Parameters.AddWithValue("@ChqNo", obj.ChqNo);
                    cmd.Parameters.AddWithValue("@Chqdate", obj.Chqdate);
                    cmd.Parameters.AddWithValue("@ChqBranch", obj.ChqBranch);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
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
                    var ret = retvalv.Value;
                    var descrip = retdesc.Value.ToString();
                    con.Close();
                    
                    response = descrip;
                    
                }
                catch (Exception ex)
                {
                    response = ex.Message;
                }
            }
            return response;
        }

        
        public List<CreditModel> GetAdvanceBalance(CreditModel details)
        {

            List<CreditModel> creditList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetAdvanceBalance", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", details.PatientId);
           

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {

                        AdvBal =(float) Convert.ToDouble(dt.Rows[i]["AdvBal"].ToString()),
                        

                    };

                    creditList.Add(obj);
                }
            }
            return creditList;
        }

        public List<CreditModel> GetOutstandingBalance(CreditModel details)
        {

            List<CreditModel> creditList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetOutstandingBalance", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", details.PatientId);
            cmd.Parameters.AddWithValue("@CreditId", details.CreditId);
            cmd.Parameters.AddWithValue("@Branchid", details.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {

                        Amount =(float) Convert.ToDouble(dt.Rows[i]["Amount"].ToString()),
                        OpenDate = dt.Rows[i]["OpenDate"].ToString()

                    };

                    creditList.Add(obj);
                }
            }
            return creditList;
        }

        public List<CreditModel> GetCredit(CreditModel details)
        {

            List<CreditModel> creditList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetCredit", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreditId", details.CreditId);
            cmd.Parameters.AddWithValue("@Branchid", details.BranchId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {

                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),
                        CreditRefNo =dt.Rows[i]["CreditRefNo"].ToString(),
                        AgentId = Convert.ToInt32(dt.Rows[i]["AgentId"].ToString()),
                        RuleId = Convert.ToInt32(dt.Rows[i]["RuleId"].ToString()),
                        BlockReason = dt.Rows[i]["BlockReason"].ToString(),
                        MaxLimit = (float)Convert.ToDouble(dt.Rows[i]["MaxLimit"].ToString()),
                        PayerId = dt.Rows[i]["PayerId"].ToString(),
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["IsDeleted"].ToString()),
                        BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"].ToString()),
                        Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString()),

                        CreditType = Convert.ToInt32(dt.Rows[i]["CreditType"].ToString()),
                        OpenDate = dt.Rows[i]["OpenDate"].ToString(),


                        SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"].ToString()),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        CreditLimit = (float)Convert.ToDouble(dt.Rows[i]["CreditLimit"].ToString()),



                        CreditAvailed = (float)Convert.ToDouble(dt.Rows[i]["CreditLimit"].ToString()),
                        ValidUpto = dt.Rows[i]["ValidUpto"].ToString(),
                        DedAmount = (float)Convert.ToDouble(dt.Rows[i]["DedAmount"].ToString()),
                        CoPayPcnt = (float)Convert.ToDouble(dt.Rows[i]["CoPayPcnt"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        Priority = Convert.ToInt32(dt.Rows[i]["Priority"].ToString()),



                    };

                    creditList.Add(obj);
                }
            }
            return creditList;
        }
        public List<CreditModel> GetCreditForPatAcc(CreditModel details)
        {
            
            List<CreditModel> creditList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetCreditForPatAcc", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", details.PatientId);
            cmd.Parameters.AddWithValue("@Branchid", details.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {

                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),
                        Credit =(float)Convert.ToDouble( dt.Rows[i]["Credit"].ToString())
                        
                    };

                    creditList.Add(obj);
                }
            }
            return creditList;
        }


        public List<TransactionModelAll> GetTransaction(TransactionModelAll details)
        {
            //List<LocationType> obj = new List<LocationType>();
            List<TransactionModelAll> transList = new List<TransactionModelAll>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetTransaction", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transid", details.TransId);
            cmd.Parameters.AddWithValue("@Branchid", details.BranchId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    TransactionModelAll obj = new TransactionModelAll
                    {

                        TransId =Convert.ToInt32( dt.Rows[i]["TransId"].ToString()),
                        PatientId = Convert.ToInt32( dt.Rows[i]["PatientId"].ToString()),
                        TransDate =  dt.Rows[i]["TransDate"].ToString(),
                        TransNo =  dt.Rows[i]["TransNo"].ToString(),
                        TransFlag =Convert.ToInt32(dt.Rows[i]["TransFlag"].ToString()),
                        Remarks =  dt.Rows[i]["Remarks"].ToString(),
                        TotalAmount =(float)Convert.ToDouble( dt.Rows[i]["TotalAmount"].ToString()),
                        TotalDiscount = (float)Convert.ToDouble( dt.Rows[i]["TotalDiscount"].ToString()),
                        TotalTax = (float)Convert.ToDouble( dt.Rows[i]["TotalTax"].ToString()),
                        SpdiscPcnt = (float)Convert.ToDouble( dt.Rows[i]["SpdiscPcnt"].ToString()),
                        SpdiscAmount = (float)Convert.ToDouble( dt.Rows[i]["SpdiscAmount"].ToString()),
                        NetAmount = (float)Convert.ToDouble(dt.Rows[i]["NetAmount"].ToString()),
                        TotalDeduction = (float)Convert.ToDouble(dt.Rows[i]["TotalDeduction"].ToString()),
                        TotalCoPay = (float)Convert.ToDouble(dt.Rows[i]["TotalCopay"].ToString()),
                        TotalSponsored = (float)Convert.ToDouble(dt.Rows[i]["TotalSponsored"].ToString()),
                        TotalNonInsured = (float)Convert.ToDouble(dt.Rows[i]["TotalNonInsured"].ToString()),
                        DeductionSurplus = (float)Convert.ToDouble(dt.Rows[i]["DeductionSurplus"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        CancelReason = dt.Rows[i]["CancelReason"].ToString(),
                        CancelSettleReason = dt.Rows[i]["CancelSettleReason"].ToString(),
                        Duplicate = Convert.ToInt32(dt.Rows[i]["Duplicate"].ToString()),
                        LocationId = Convert.ToInt32(dt.Rows[i]["LocationId"].ToString()),
                        ConsultantId = Convert.ToInt32(dt.Rows[i]["ConsultantId"].ToString()),
                        RGroupId = Convert.ToInt32(dt.Rows[i]["RGroupId"].ToString()),

                        PackId = Convert.ToInt32(dt.Rows[i]["PackId"].ToString()),
                        ShiftId = Convert.ToInt32(dt.Rows[i]["ShiftId"].ToString()),
                        SplDiscRemarks = dt.Rows[i]["SplDiscRemarks"].ToString(),

                        ItemDiscRemarks = dt.Rows[i]["ItemDiscRemarks"].ToString(),
                        AprovalNo = dt.Rows[i]["AprovalNo"].ToString(),
                        ConsultationId = Convert.ToInt32(dt.Rows[i]["ConsultationId"].ToString()),
                        BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"].ToString()),



                    };
                    
                    transList.Add(obj);
                }
            }
            return transList;
        }


        public string InsertTransactionSOExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionSOExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);                    
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);

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

        public string InsertUpdateInvestigation(InvestigationModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateInvestigation", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvestgnId", obj.InvestgnId);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@InvestgnNo", obj.InvestgnNo);
                    cmd.Parameters.AddWithValue("@InvestgnDate", obj.InvestgnDate);
                    cmd.Parameters.AddWithValue("@STypeId", obj.STypeId);
                    cmd.Parameters.AddWithValue("@SPointId", obj.SPointId);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
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


        public List<ServiceAutoInitiateModel> GetServicesForAutoInitiate(ServiceAutoInitiateModel details)
        {
            List<ServiceAutoInitiateModel> transList = new List<ServiceAutoInitiateModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_GetServicesForAutoInitiate", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", details.OrderId);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    ServiceAutoInitiateModel obj = new ServiceAutoInitiateModel
                    {

                        GroupTypeName = dt.Rows[i]["GroupTypeName"].ToString(),
                        GroupName = dt.Rows[i]["GroupName"].ToString(),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"].ToString()),
                        OrderDate = dt.Rows[i]["OrderDate"].ToString(),
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        OrderDetId = Convert.ToInt32(dt.Rows[i]["OrderDetId"].ToString()),
                        ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"].ToString()),
                        SPointId = Convert.ToInt32(dt.Rows[i]["SPointId"].ToString()),
                        STypeId = Convert.ToInt32(dt.Rows[i]["STypeId"].ToString()),
                        InvestgnId = Convert.ToInt32(dt.Rows[i]["InvestgnId"].ToString()),
                        InvestgnNo = dt.Rows[i]["InvestgnNo"].ToString(),
                       
                    };
                    transList.Add(obj);
                }
            }
            return transList;
        }

        public string InsertTransactionSO(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionSO", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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

        public string InsertTransactionLOC(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionLOC", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@SerialNo", obj.SerialNo);
                    cmd.Parameters.AddWithValue("@DeductionAmount", obj.DeductionAmount);                   
                    cmd.Parameters.AddWithValue("@CoPayAmount", obj.CoPayAmount);
                    cmd.Parameters.AddWithValue("@SponsoredAmount", obj.SponsoredAmount);
                    cmd.Parameters.AddWithValue("@AppliedDed", obj.AppliedDed);
                    cmd.Parameters.AddWithValue("@AppliedCoPay", obj.AppliedCoPay);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);


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

        public string DeleteTransactionLoc(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTransactionLoc", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);


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

        public string InsertTransactionTAX(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionTAX", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransDetId", obj.TransDetId);
                    cmd.Parameters.AddWithValue("@TaxId", obj.TaxId);

                    cmd.Parameters.AddWithValue("@TaxPcnt", obj.TaxPcnt);
                    cmd.Parameters.AddWithValue("@TaxAmount", obj.TaxAmount);
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
        public string DeleteTransactionTax(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTransactionTax", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransdetId", obj.TransDetId);


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
        public string InsertTransLocItem(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransLocItem", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransLOcItemId", obj.TransId);
                    cmd.Parameters.AddWithValue("@TransDetId", obj.TransDetId);
                    cmd.Parameters.AddWithValue("@Copay", obj.Copay);
                    cmd.Parameters.AddWithValue("@Deduction", obj.Deduction);
                    cmd.Parameters.AddWithValue("@CopayPer", obj.CopayPer);
                    cmd.Parameters.AddWithValue("@CopayAmt", obj.CopayAmt);
                    cmd.Parameters.AddWithValue("@DedPer", obj.DedPer);
                    cmd.Parameters.AddWithValue("@DedAmt", obj.DedAmt);
                   

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


        public string InsertTransactionDet(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionDet", con);
                try
                {
                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@TransDetId", obj.TransDetId);

                    cmd.Parameters.AddWithValue("@ItemId", obj.ItemId);
                    cmd.Parameters.AddWithValue("@Qty", obj.Qty);
                    cmd.Parameters.AddWithValue("@Rate", obj.Rate);
                    cmd.Parameters.AddWithValue("@ActualRate", obj.ActualRate);
                    cmd.Parameters.AddWithValue("@DiscPcnt", obj.DiscPcnt);
                    cmd.Parameters.AddWithValue("@DiscAmount", obj.DiscAmount);
                    cmd.Parameters.AddWithValue("@OrderDetId", obj.OrderDetId);
                    cmd.Parameters.AddWithValue("@PostId", obj.PostId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@AprovalNo", obj.AprovalNo);

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


        public string DeleteTransactionDet(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTransactionDet", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);


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

        public string InsertUpdateTransaction(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTransaction", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@TransDate", obj.TransDate);

                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@TransNo", obj.TransNo);
                    cmd.Parameters.AddWithValue("@TransFlag", obj.TransFlag);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
                    cmd.Parameters.AddWithValue("@TotalDiscount", obj.TotalDiscount);
                    cmd.Parameters.AddWithValue("@TotalTax", obj.TotalTax);
                    cmd.Parameters.AddWithValue("@SpdiscPcnt", obj.SpdiscPcnt);
                    cmd.Parameters.AddWithValue("@SpdiscAmount", obj.SpdiscAmount);
                    cmd.Parameters.AddWithValue("@NetAmount", obj.NetAmount);
                    cmd.Parameters.AddWithValue("@TotalDeduction", obj.TotalDeduction);
                    cmd.Parameters.AddWithValue("@TotalCopay", obj.TotalCoPay);
                    cmd.Parameters.AddWithValue("@TotalSponsored", obj.TotalSponsored);
                    cmd.Parameters.AddWithValue("@TotalNonInsured", obj.TotalNonInsured);
                   // cmd.Parameters.AddWithValue("@TotalSponsored", obj.TotalSponsored);
                    cmd.Parameters.AddWithValue("@DeductionSurplus", obj.DeductionSurplus);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Duplicate", obj.Duplicate);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@ConsultantId", obj.ConsultantId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@RGroupId", obj.RGroupId);
                    cmd.Parameters.AddWithValue("@PackId", obj.PackId);
                    //cmd.Parameters.AddWithValue("@ExtLabId", obj.ExtLabId);
                    cmd.Parameters.AddWithValue("@SplDiscRemarks", obj.SplDiscRemarks);
                    cmd.Parameters.AddWithValue("@ItmDiscRemarks", obj.ItmDiscRemarks);
                    cmd.Parameters.AddWithValue("@ConsultationId", obj.ConsultationId);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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
                    SqlParameter rettransno = new SqlParameter("@RetTransNo", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                  
                    cmd.Parameters.Add(rettransno);
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


        public string InsertTransCreditItemGroup(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransCreditItemGroup", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    //cmd.Parameters.AddWithValue("@Category", obj.Category);
                   

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

        public string InsertTransactionLOCExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionLOCExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@SerialNo", obj.SerialNo);
                    cmd.Parameters.AddWithValue("@DeductionAmount", obj.DeductionAmount);
                    cmd.Parameters.AddWithValue("@CoPayAmount", obj.CoPayAmount);
                    cmd.Parameters.AddWithValue("@SponsoredAmount", obj.SponsoredAmount);
                    cmd.Parameters.AddWithValue("@AppliedDed", obj.AppliedDed);
                    cmd.Parameters.AddWithValue("@AppliedCoPay", obj.AppliedCoPay);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    

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

        public string DeleteTransactionLocExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTransactionLocExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);


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
        
        public string InsertTransactionDetExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertTransactionDetExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@TransDetId", obj.TransDetId);
                    cmd.Parameters.AddWithValue("@ItemId", obj.ItemId);
                    cmd.Parameters.AddWithValue("@Qty", obj.Qty);
                    cmd.Parameters.AddWithValue("@Rate", obj.Rate);
                    cmd.Parameters.AddWithValue("@ActualRate", obj.ActualRate);
                    cmd.Parameters.AddWithValue("@DiscPcnt", obj.DiscPcnt);
                    cmd.Parameters.AddWithValue("@DiscAmount", obj.DiscAmount);
                    cmd.Parameters.AddWithValue("@OrderDetId", obj.OrderDetId);
                    cmd.Parameters.AddWithValue("@PostId", obj.PostId);
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                   // cmd.Parameters.AddWithValue("@PhysioDetId", obj.PhysioDetId);
                    
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

        public string DeleteTransactionDetExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_DeleteTransactionDetExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);


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

        public string InsertUpdateTransactionExternal(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateTransactionExternal", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@TransDate", obj.TransDate);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@TransNo", obj.TransNo);
                    cmd.Parameters.AddWithValue("@TransFlag", obj.TransFlag);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
                    cmd.Parameters.AddWithValue("@TotalDiscount", obj.TotalDiscount);
                    cmd.Parameters.AddWithValue("@TotalTax", obj.TotalTax);
                    cmd.Parameters.AddWithValue("@SpdiscPcnt", obj.SpdiscPcnt);
                    cmd.Parameters.AddWithValue("@SpdiscAmount", obj.SpdiscAmount);
                    cmd.Parameters.AddWithValue("@NetAmount", obj.NetAmount);
                    cmd.Parameters.AddWithValue("@TotalDeduction", obj.TotalDeduction);
                    cmd.Parameters.AddWithValue("@TotalCopay", obj.TotalCoPay);
                    cmd.Parameters.AddWithValue("@TotalSponsored", obj.TotalSponsored);
                    cmd.Parameters.AddWithValue("@TotalNonInsured", obj.TotalNonInsured);
                   // cmd.Parameters.AddWithValue("@TotalSponsored", obj.TotalSponsored);
                    cmd.Parameters.AddWithValue("@DeductionSurplus", obj.DeductionSurplus);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Duplicate", obj.Duplicate);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
                    cmd.Parameters.AddWithValue("@ConsultantId", obj.ConsultantId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@RGroupId", obj.RGroupId);
                    cmd.Parameters.AddWithValue("@PackId", obj.PackId);
                    cmd.Parameters.AddWithValue("@ExtLabId", obj.ExtLabId);
                    cmd.Parameters.AddWithValue("@SplDiscRemarks", obj.SplDiscRemarks);
                    cmd.Parameters.AddWithValue("@ItmDiscRemarks", obj.ItmDiscRemarks);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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
                    SqlParameter rettransno = new SqlParameter("@RetTransNo", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(rettransno);
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

        public string CheckPatientSOHistory(ServiceOrderModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CheckPatientSOHistory", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@ItemId", obj.ItemId);

                    //SqlParameter retvalv = new SqlParameter("@RetVal", SqlDbType.Int)
                    //{
                    //    Direction = ParameterDirection.Output
                    //};
                   // cmd.Parameters.Add(retvalv);
                    SqlParameter retdesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(retdesc);
                    con.Open();
                    var isupdated = cmd.ExecuteNonQuery();
                    con.Close();
                    //var ret = retvalv.Value;
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
        public List<AgentModel> CheckSubAgentStatus(CreditModel details)
        {
            List<AgentModel> Agent = new List<AgentModel>();
            using SqlConnection con = new SqlConnection(_connStr);

            using SqlCommand cmd = new SqlCommand("stLH_CheckSubAgentStatus", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreditId", details.CreditId);
            cmd.Parameters.AddWithValue("@SponsorId", details.SponsorId);
           


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

                        AgentId = Convert.ToInt32(dt.Rows[i]["AgentId"].ToString()),
                     
                    };
                    Agent.Add(obj);
                }
            }
            return Agent;
        }

        public string CheckForClaimGeneration(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CheckForClaimGeneration", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);

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

        public string CancelBill(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelBill", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@CancelReason", obj.CancelReason);
                   
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@OrderDate", obj.OrderDate);
                    cmd.Parameters.AddWithValue("@LocationId", obj.LocationId);
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
        public string IsBilledTransaction(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_IsBilledTransaction", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                   
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

        public List<CreditModel> GetManageCreditForBilling(CreditModelAll details)
        {
            List<CreditModel> transList = new List<CreditModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            
            using SqlCommand cmd = new SqlCommand("stLH_GetManageCreditForBilling", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", details.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", details.ToDate);            
            cmd.Parameters.AddWithValue("@RegNo", details.RegNo);
            cmd.Parameters.AddWithValue("@Status", details.Status);
            cmd.Parameters.AddWithValue("@Active", details.Active);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    CreditModel obj = new CreditModel
                    {

                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),
                        Limit = (float)Convert.ToDecimal(dt.Rows[i]["Limit"].ToString()),
                        Balance = (float)Convert.ToDecimal(dt.Rows[i]["Balance"].ToString()),
                        CreditAvailed = (float)Convert.ToDecimal(dt.Rows[i]["CreditAvailed"].ToString()),
                        Date = dt.Rows[i]["Date"].ToString().Replace("/", "-"),
                        RefNo = dt.Rows[i]["RefNo"].ToString(),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        Age = dt.Rows[i]["Age"].ToString(),
                        Active = Convert.ToInt32(dt.Rows[i]["Active"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        RegNo = dt.Rows[i]["RegNo"].ToString(),
                        SponsorName = dt.Rows[i]["SponsorName"].ToString()



                    };
                    transList.Add(obj);
                }
            }
            return transList;
        }
        public string CancelBillSettlement(TransactionModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_CancelBillSettlement", con);
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", obj.TransId);
                    cmd.Parameters.AddWithValue("@CancelReason", obj.CancelReason);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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
        public List<TransactionModel> GetBillList(TransactionModelAll details)
        {
            List<TransactionModel> transList = new List<TransactionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            string spname = "";
            if (details.Externalstatus == 1)
            {
                spname = "stLH_GetBillListExternal";
              //  using SqlCommand cmd = new SqlCommand("stLH_GetBillListExternal", con);
            }
            else
            {
                spname = "stLH_GetBillList";
            }
            using SqlCommand cmd = new SqlCommand(spname, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Locationid", details.LocationId);
            cmd.Parameters.AddWithValue("@TransFromDate", details.TransFromDate);
            cmd.Parameters.AddWithValue("@TransToDate", details.TransToDate);
            cmd.Parameters.AddWithValue("@RegNo", details.RegNo);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    TransactionModel obj = new TransactionModel
                    {

                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        BillAmount = (float)Convert.ToDecimal(dt.Rows[i]["BillAmount"].ToString()),
                        DueAmt = (float)Convert.ToDecimal(dt.Rows[i]["DueAmt"].ToString()),
                        BillDate = dt.Rows[i]["BillDate"].ToString(),
                        BillNo = dt.Rows[i]["BillNo"].ToString(),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        ConsultantName = dt.Rows[i]["ConsultantName"].ToString(),
                        Location = dt.Rows[i]["Location"].ToString(),
                        Status = dt.Rows[i]["Status"].ToString(),
                        RegNo = dt.Rows[i]["RegNo"].ToString(),
                        SettledUser = dt.Rows[i]["SettledUser"].ToString(),
                        SponsorName = dt.Rows[i]["SponsorName"].ToString()

                    };
                    transList.Add(obj);
                }
            }
            return transList;
        }

        public List<TransactionModel> GetPendingBill(TransactionModel details)
        {
            List<TransactionModel> transList = new List<TransactionModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPendingBill", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", details.PatientId);
            cmd.Parameters.AddWithValue("@LocationId", details.LocationId);
            cmd.Parameters.AddWithValue("@BranchId", details.BranchId);
            

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    TransactionModel obj = new TransactionModel
                    {

                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        Amount =(float) Convert.ToDecimal(dt.Rows[i]["TransId"].ToString()),
                       

                        Date = dt.Rows[i]["Date"].ToString(),
                        Location = dt.Rows[i]["Location"].ToString(),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        RegNo = dt.Rows[i]["RegNo"].ToString()

                    };
                    transList.Add(obj);
                }
            }
            return transList;
        }
        public List<PaymentModel> GetPaymentList(PaymentModelAll details)
        {
            List<PaymentModel> pymntList = new List<PaymentModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetPaymentList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", details.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", details.ToDate);
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
                    PaymentModel obj = new PaymentModel
                    {

                        PaymentId = Convert.ToInt32(dt.Rows[i]["PaymentId"].ToString()),
                        PaymentNo = dt.Rows[i]["PaymentNo"].ToString(),
                        PayDate = dt.Rows[i]["PayDate"].ToString(),
                        PayType = Convert.ToInt32(dt.Rows[i]["HeadId"].ToString()),
                        HeadId = Convert.ToInt32(dt.Rows[i]["HeadId"].ToString()),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),
                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),
                        Mode = Convert.ToInt32(dt.Rows[i]["Mode"].ToString()),
                        Amount = (float)Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        //CardType = dt.Rows[i]["CardType"].ToString(),
                        //CardNo = dt.Rows[i]["CardNo"].ToString(),
                        ChqNo = dt.Rows[i]["ChqNo"].ToString(),
                        ChqDate = dt.Rows[i]["ChqDate"].ToString(),                       
                        ChqBranch = dt.Rows[i]["ChqBranch"].ToString(),
                        LocationId = Convert.ToInt32(dt.Rows[i]["LocationId"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        CancelReason = dt.Rows[i]["CancelReason"].ToString(),
                       
                        //TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        //SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"]),
                        BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]),
                        IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]),
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["IsDeleted"].ToString()),                      
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        RegNo = dt.Rows[i]["RegNo"].ToString()
                      
                       


                    };
                    pymntList.Add(obj);
                }
            }
            return pymntList;
        }

        public List<ReceiptModel> GetReceiptList(ReceiptModelAll details)
        {
            List<ReceiptModel> receiptList = new List<ReceiptModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetReceiptList", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", details.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", details.ToDate);
            cmd.Parameters.AddWithValue("@RecType", details.RecType);
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
                    ReceiptModel obj = new ReceiptModel
                    {

                        ReceiptId = Convert.ToInt32(dt.Rows[i]["ReceiptId"].ToString()),
                        ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                        RecDate = dt.Rows[i]["RecDate"].ToString(),
                        HeadId = Convert.ToInt32(dt.Rows[i]["HeadId"].ToString()),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        CardType = dt.Rows[i]["CardType"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        ChqNo = dt.Rows[i]["ChqNo"].ToString(),
                        ChqDate = dt.Rows[i]["ChqDate"].ToString(),
                        ChqBranch = dt.Rows[i]["ChqBranch"].ToString(),
                        LocationId = Convert.ToInt32(dt.Rows[i]["LocationId"].ToString()),
                        CancelReason = dt.Rows[i]["CancelReason"].ToString(),
                        RecType = Convert.ToInt32(dt.Rows[i]["RecType"].ToString()),
                        PatientId = Convert.ToInt32(dt.Rows[i]["PatientId"].ToString()),                       
                        Mode = Convert.ToInt32(dt.Rows[i]["Mode"].ToString()),
                        Amount = (float)Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()),                        
                        BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]),
                        IsDisplayed = Convert.ToInt32(dt.Rows[i]["IsDisplayed"]),                      
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["IsDeleted"].ToString()),
                        Status = dt.Rows[i]["Status"].ToString(),
                        PatientName = dt.Rows[i]["PatientName"].ToString(),
                        ShiftId = Convert.ToInt32(dt.Rows[i]["ShiftId"].ToString()),
                        TransId = Convert.ToInt32(dt.Rows[i]["TransId"].ToString()),
                        SponsorId = Convert.ToInt32(dt.Rows[i]["SponsorId"]),
                        CreditId = Convert.ToInt32(dt.Rows[i]["CreditId"].ToString()),


                    };
                    receiptList.Add(obj);
                }
            }
            return receiptList;
        }

        public string InsertUpdateCredit(CreditModelAll obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using SqlCommand cmd = new SqlCommand("stLH_InsertUpdateCredit", con);
                try
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreditId", obj.CreditId);
                    cmd.Parameters.AddWithValue("@CreditRefNo", obj.CreditRefNo);
                    cmd.Parameters.AddWithValue("@CreditType", obj.CreditType);
                    cmd.Parameters.AddWithValue("@OpenDate", obj.OpenDate);
                    cmd.Parameters.AddWithValue("@SponsorId", obj.SponsorId);
                    cmd.Parameters.AddWithValue("@PatientId", obj.PatientId);
                    cmd.Parameters.AddWithValue("@AgentId", obj.AgentId);
                    cmd.Parameters.AddWithValue("@CreditLimit", obj.CreditLimit);
                    cmd.Parameters.AddWithValue("@CreditAvailed", obj.CreditAvailed);
                    cmd.Parameters.AddWithValue("@ValidUpto", obj.ValidUpto);
                    cmd.Parameters.AddWithValue("@DedAmount", obj.DedAmount);
                    cmd.Parameters.AddWithValue("@CoPayPcnt", obj.CoPayPcnt);
                    cmd.Parameters.AddWithValue("@MaxLimit", obj.MaxLimit);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Priority", obj.Priority);
                    cmd.Parameters.AddWithValue("@PolicyNo", obj.PolicyNo);
                    cmd.Parameters.AddWithValue("@PayerId", obj.PayerId);
                    cmd.Parameters.AddWithValue("@CertificateNo", obj.CertificateNo);
                    cmd.Parameters.AddWithValue("@DependantNo", obj.DependantNo);
                    cmd.Parameters.AddWithValue("@PolicyDate", obj.PolicyDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", obj.ExpiryDate);
                    cmd.Parameters.AddWithValue("@RuleId", obj.RuleId);
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", obj.SessionId);
                    cmd.Parameters.AddWithValue("@ImageId", obj.ImageId);
                    cmd.Parameters.AddWithValue("@Image", obj.Image);
                   // cmd.Parameters.AddWithValue("@ImageId", obj.ImageId);
                    cmd.Parameters.AddWithValue("@IsDisplayed", obj.IsDisplayed);
                   // cmd.Parameters.AddWithValue("@IsDeleted", obj.IsDeleted);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);

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
                        PlacePo = dt.Rows[i]["PlacePO"].ToString(),
                        Pin = dt.Rows[i]["PIN"].ToString(),
                        State = dt.Rows[i]["State"].ToString(),
                        CountryId =Convert.ToInt32( dt.Rows[i]["CountryId"].ToString()),
                        Phone = dt.Rows[i]["Phone"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Fax = dt.Rows[i]["Fax"].ToString(),
                        ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                        Remarks = dt.Rows[i]["Remarks"].ToString(),
                        DhaNo = dt.Rows[i]["DHANo"].ToString(),
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
