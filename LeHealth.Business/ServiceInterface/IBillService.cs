using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IBillService
    {

        
        List<ClaimReceiptModel> GetSponsorChequeReceiptDetails(ClaimReceiptModel details);
        List<ClaimReceiptModel> GetClaimReceiptList(ClaimReceiptModel details);
        string CancelClaimReceipt(ClaimReceiptModel details);
        List<ClaimReceiptModel> GetClaimReceipts(ClaimReceiptModel details);
        string CancelClaim(ClaimModelAll details);
        List<ClaimModelAll> GetClaimDetails(ClaimModelAll details);
        List<ClaimModelAll> GetClaim(ClaimModelAll details);

        string InsertUpdateClaim(ClaimModelAll details);
        string UpdateSOPerformingDetails(ServiceOrderModel details);
        string UpdateApprovalNo(TransactionDetailsModel details);
        List<TransactionDetailsModel> GetTransactionDetails(TransactionDetailsModel details);
        List<ToothModel> GetToothNo(ToothModel details);

        string CloseCredit(CreditModelAll details);
        string ApproveCredit(CreditModelAll details);
        List<CreditModel> GetTransactionSummary(CreditModel details);
        List<StaffModel> GetAllStaff(StaffModel details);
        List<ServiceOrderModel> GetTransactionClaimDetails(ServiceOrderModel details);
        string VerifyClaim(ClaimModelAll details);
        List<ClaimModel> GetSponsorshipDetails(ClaimModelAll details);
        List<ClaimModel> GetManageClaimForBilling(ClaimModelAll details);
        string InsertTransactionPayment(TransactionModelAll trans);
        string ActionSettleBill(TransactionModelAll trans);
        List<CreditModel> GetAdvanceBalance(CreditModel details);
        List<CreditModel> GetOutstandingBalance(CreditModel details);
        List<CreditModel> GetCredit(CreditModel details);
        List<CreditModel> GetCreditForPatAcc(CreditModel details);
        List<TransactionModelAll> GetTransaction(TransactionModelAll details);
        string InsertTransactionSOExternal(TransactionModelAll trans);
        string InsertUpdateInvestigation(InvestigationModel inv);
        List<ServiceAutoInitiateModel> GetServicesForAutoInitiate(ServiceAutoInitiateModel details);
        string InsertTransactionSO(TransactionModelAll trans);
        string InsertTransactionLOC(TransactionModelAll trans);
        string DeleteTransactionLoc(TransactionModelAll trans);
        string InsertTransactionTAX(TransactionModelAll trans);
        string DeleteTransactionTax(TransactionModelAll trans);
        string InsertTransLocItem(TransactionModelAll trans);
        string InsertTransactionDet(TransactionModelAll trans);
        string DeleteTransactionDet(TransactionModelAll trans);
        string InsertUpdateTransaction(TransactionModelAll trans);
        string InsertTransCreditItemGroup(TransactionModelAll trans);
        string InsertTransactionLOCExternal(TransactionModelAll trans);
        string DeleteTransactionLocExternal(TransactionModelAll trans);
        string InsertTransactionDetExternal(TransactionModelAll trans);
        string DeleteTransactionDetExternal(TransactionModelAll trans);
        string InsertUpdateTransactionExternal(TransactionModelAll trans);
        string CheckPatientSOHistory(ServiceOrderModel so);
        List<AgentModel> CheckSubAgentStatus(CreditModel details);
        string CheckForClaimGeneration(TransactionModelAll trans);
        string CancelBill(TransactionModelAll trans);
        string IsBilledTransaction(TransactionModelAll trans);
        List<CreditModel> GetManageCreditForBilling(CreditModelAll details);
        string CancelBillSettlement(TransactionModelAll trans);
        List<TransactionModel> GetBillList(TransactionModelAll details);
        List<TransactionModel> GetPendingBill(TransactionModel details);
        List<PaymentModel> GetPaymentList(PaymentModelAll details);
        List<ReceiptModel> GetReceiptList(ReceiptModelAll details);
        string InsertUpdateCredit(CreditModelAll credit);

        List<AgentModel> GetSponsorAgent(AgentModel details);
        List<UnBilledItemModel> GetUnBilledItem(UnBilledItemModel details);
        List<BillItemModel> GetItemForSelectionByGroup(BillItemModel billdetails);
        List<BillItemModel> SearchServiceItem(BillItemModel billdetails);
        List<PackageItemsModel> GetPackageItem(PackageItemsModel inf);
        List<PackageModelAll> GetPackage(PackageModelAll inf);
        List<BillItemModel> GetItemForSelection(BillItemModel billdetails);

        string InsertUpdateCreditItemGroup(CreditItemGroupModel grp);
        List<CreditItemGroupModel> GetCreditItemGroup(CreditItemGroupModel spdetails);

        List<PatientSponsorModel> GetSponsorDetailsByPatient(PatientSponsorModel spons);
        List<PatientBillModel> SearchTodayPatientBill(PatientBillModel patbill);
        string CancelReceipt(ReceiptModelAll rcpt);
        string CancelPayment(PaymentModelAll pymnt);
        string InsertUpdateReceipt(ReceiptModelAll rcpt);
        string InsertUpdatePayment(PaymentModelAll pymnt);
    }
}
