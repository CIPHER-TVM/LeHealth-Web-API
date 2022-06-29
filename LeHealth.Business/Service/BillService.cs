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
