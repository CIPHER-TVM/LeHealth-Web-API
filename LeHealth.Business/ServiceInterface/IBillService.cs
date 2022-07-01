using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IBillService
    {
        
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
