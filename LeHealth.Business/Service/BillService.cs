using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;

namespace LeHealth.Service.Service
{
    public class BillService:IBillService
    {
        private  readonly IBillManager billmanager;

        public BillService(IBillManager _billmanager)
        {
            billmanager = _billmanager;
        }
        //

        public List<ClaimReceiptModel> GetSponsorChequeReceiptDetails(ClaimReceiptModel details)
        {
            return billmanager.GetSponsorChequeReceiptDetails(details);
        }
        public List<ClaimReceiptModel> GetClaimReceiptList(ClaimReceiptModel details)
        {
            return billmanager.GetClaimReceiptList(details);
        }
        public string CancelClaimReceipt(ClaimReceiptModel details)
        {

            return billmanager.CancelClaimReceipt(details);
        }
        public List<ClaimReceiptModel> GetClaimReceipts(ClaimReceiptModel details)
        {
            return billmanager.GetClaimReceipts(details);
        }
        public string CancelClaim(ClaimModelAll details)
        {

            return billmanager.CancelClaim(details);
        }
        public List<ClaimModelAll> GetClaimDetails(ClaimModelAll details)
        {
            return billmanager.GetClaimDetails(details);
        }
        public List<ClaimModelAll> GetClaim(ClaimModelAll details)
        {
            return billmanager.GetClaim(details);
        }

        public string InsertUpdateClaim(ClaimModelAll details)
        {

            return billmanager.InsertUpdateClaim(details);
        }
        public string UpdateSOPerformingDetails(ServiceOrderModel details)
        {

            return billmanager.UpdateSOPerformingDetails(details);
        }
        public string UpdateApprovalNo(TransactionDetailsModel details)
        {

            return billmanager.UpdateApprovalNo(details);
        }
        public List<TransactionDetailsModel> GetTransactionDetails(TransactionDetailsModel details)
        {
            return billmanager.GetTransactionDetails(details);
        }
        public string CloseCredit(CreditModelAll details)
        {

            return billmanager.CloseCredit(details);
        }
        public string ApproveCredit(CreditModelAll details)
        {

            return billmanager.ApproveCredit(details);
        }

        public List<CreditModel> GetTransactionSummary(CreditModel details)
        {
            return billmanager.GetTransactionSummary(details);
        }
        public List<StaffModel> GetAllStaff(StaffModel details)
        {
            return billmanager.GetAllStaff(details);
        }
        public List<ToothModel> GetToothNo(ToothModel details)
        {
            return billmanager.GetToothNo(details);
        }
        public List<ServiceOrderModel> GetTransactionClaimDetails(ServiceOrderModel details)
        {
            return billmanager.GetTransactionClaimDetails(details);
        }

        public string VerifyClaim(ClaimModelAll details)
        {

            return billmanager.VerifyClaim(details);
        }
        public List<ClaimModel> GetSponsorshipDetails(ClaimModelAll details)
        {
            return billmanager.GetSponsorshipDetails(details);
        }
        public List<ClaimModel> GetManageClaimForBilling(ClaimModelAll details)
        {
            return billmanager.GetManageClaimForBilling(details);
        }

        public string InsertTransactionPayment(TransactionModelAll inv)
        {

            return billmanager.InsertTransactionPayment(inv);
        }
      public string ActionSettleBill(TransactionModelAll inv)
        {

            return billmanager.ActionSettleBill(inv);
        }
      
        public List<CreditModel> GetAdvanceBalance(CreditModel details)
        {
            return billmanager.GetAdvanceBalance(details);
        }
        public List<CreditModel> GetOutstandingBalance(CreditModel details)
        {
            return billmanager.GetOutstandingBalance(details);
        }
        public List<CreditModel> GetCredit(CreditModel details)
        {
            return billmanager.GetCredit(details);
        }
        public List<CreditModel> GetCreditForPatAcc(CreditModel details)
        {
            return billmanager.GetCreditForPatAcc(details);
        }
        public List<TransactionModelAll> GetTransaction(TransactionModelAll details)
        {
            return billmanager.GetTransaction(details);
        }

        public string InsertTransactionSOExternal(TransactionModelAll inv)
        {

            return billmanager.InsertTransactionSOExternal(inv);
        }
        public string InsertUpdateInvestigation(InvestigationModel inv)
        {

            return billmanager.InsertUpdateInvestigation(inv);
        }

        public List<ServiceAutoInitiateModel> GetServicesForAutoInitiate(ServiceAutoInitiateModel details)
        {
            return billmanager.GetServicesForAutoInitiate(details);
        }
        public string InsertTransactionSO(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionSO(trans);
        }
        public string InsertTransactionLOC(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionLOC(trans);
        }
        public string DeleteTransactionLoc(TransactionModelAll trans)
        {

            return billmanager.DeleteTransactionLoc(trans);
        }
        public string InsertTransactionTAX(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionTAX(trans);
        }
        public string DeleteTransactionTax(TransactionModelAll trans)
        {

            return billmanager.DeleteTransactionTax(trans);
        }
        public string InsertTransLocItem(TransactionModelAll trans)
        {

            return billmanager.InsertTransLocItem(trans);
        }
        public string InsertTransactionDet(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionDet(trans);
        }
        public string DeleteTransactionDet(TransactionModelAll trans)
        {

            return billmanager.DeleteTransactionDet(trans);
        }
        public string InsertUpdateTransaction(TransactionModelAll trans)
        {

            return billmanager.InsertUpdateTransaction(trans);
        }
        public string InsertTransCreditItemGroup(TransactionModelAll trans)
        {

            return billmanager.InsertTransCreditItemGroup(trans);
        }
        public string InsertTransactionLOCExternal(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionLOCExternal(trans);
        } 
        public string DeleteTransactionLocExternal(TransactionModelAll trans)
        {

            return billmanager.DeleteTransactionLocExternal(trans);
        }
        public string InsertTransactionDetExternal(TransactionModelAll trans)
        {

            return billmanager.InsertTransactionDetExternal(trans);
        }
        public string DeleteTransactionDetExternal(TransactionModelAll trans)
        {

            return billmanager.DeleteTransactionDetExternal(trans);
        }
        public string InsertUpdateTransactionExternal(TransactionModelAll trans)
        {

            return billmanager.InsertUpdateTransactionExternal(trans);
        }

        public string CheckPatientSOHistory(ServiceOrderModel so)
        {

            return billmanager.CheckPatientSOHistory(so);
        }
        public List<AgentModel> CheckSubAgentStatus(CreditModel details)
        {
            return billmanager.CheckSubAgentStatus(details);
        }

        public string CheckForClaimGeneration(TransactionModelAll trans)
        {

            return billmanager.CheckForClaimGeneration(trans);
        }

        public string CancelBill(TransactionModelAll trans)
        {

            return billmanager.CancelBill(trans);
        }

        public string IsBilledTransaction(TransactionModelAll trans)
        {

            return billmanager.IsBilledTransaction(trans);
        }

        public List<CreditModel> GetManageCreditForBilling(CreditModelAll details)
        {
            return billmanager.GetManageCreditForBilling(details);
        }

        public string CancelBillSettlement(TransactionModelAll trans)
        {

            return billmanager.CancelBillSettlement(trans);
        }

        public List<TransactionModel> GetBillList(TransactionModelAll details)
        {
            return billmanager.GetBillList(details);
        } 
        public List<TransactionModel> GetPendingBill(TransactionModel details)
        {
            return billmanager.GetPendingBill(details);
        } 
        public List<PaymentModel> GetPaymentList(PaymentModelAll details)
        {
            return billmanager.GetPaymentList(details);
        }
        public List<ReceiptModel> GetReceiptList(ReceiptModelAll details)
        {
            return billmanager.GetReceiptList(details);
        }

        public string InsertUpdateCredit(CreditModelAll credit)
        {

            return billmanager.InsertUpdateCredit(credit);
        }

        public List<AgentModel> GetSponsorAgent(AgentModel details)
        {
            return billmanager.GetSponsorAgent(details);
        }
        public List<UnBilledItemModel> GetUnBilledItem(UnBilledItemModel details)
        {
            return billmanager.GetUnBilledItem(details);
        }
        public List<BillItemModel> GetItemForSelectionByGroup(BillItemModel billdetails)
        {
            return billmanager.GetItemForSelectionByGroup(billdetails);
        }
        public List<BillItemModel> SearchServiceItem(BillItemModel billdetails)
        {
            return billmanager.SearchServiceItem(billdetails);
        }
        public List<PackageItemsModel> GetPackageItem(PackageItemsModel inf)
        {
            return billmanager.GetPackageItem(inf);
        }
        public List<PackageModelAll> GetPackage(PackageModelAll inf)
        {
            return billmanager.GetPackage(inf);
        } 
        public List<BillItemModel> GetItemForSelection(BillItemModel billdetails)
        {
            return billmanager.GetItemForSelection(billdetails);
        }
        

        public string InsertUpdateCreditItemGroup(CreditItemGroupModel grp)
        {

            return billmanager.InsertUpdateCreditItemGroup(grp);
        }

        public List<CreditItemGroupModel> GetCreditItemGroup(CreditItemGroupModel spdetails)
        {
            return billmanager.GetCreditItemGroup(spdetails);
        }
        public List<PatientSponsorModel> GetSponsorDetailsByPatient(PatientSponsorModel sponsor)
        {
            return billmanager.GetSponsorDetailsByPatient(sponsor);
        }

        public List<PatientBillModel> SearchTodayPatientBill(PatientBillModel patbill)
        {
            return billmanager.SearchTodayPatientBill(patbill);
        }

        public string CancelReceipt(ReceiptModelAll rcpt)
        {

            return billmanager.CancelReceipt(rcpt);
        }
        public string CancelPayment(PaymentModelAll pymnt)
        {

            return billmanager.CancelPayment(pymnt);
        }
        public string InsertUpdateReceipt(ReceiptModelAll rcpt)
        {
            
            return billmanager.InsertUpdateReceipt(rcpt);
        }
        public string InsertUpdatePayment(PaymentModelAll pymnt)
        {

            return billmanager.InsertUpdatePayment(pymnt);
        }
    }
}
