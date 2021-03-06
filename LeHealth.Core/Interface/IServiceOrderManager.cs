using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IServiceOrderManager
    {
        List<GroupModel> GetItemsGroup(GroupModelAll groupId); 
        List<RateModel> GetItemRate(RateModelAll groupId); 
        List<TaxModel> GetItemTax(TaxModelAll groupId); 
        List<ItemModel> GetItem(ItemModelAll groupId); 
        List<ItemsByTypeModel> GetPackageItem(int packId);
        List<AvailableServiceModel> GetAvailableService(AvailableServiceModel asm);
        List<AvailableServiceModel> GetLastConsultation(AvailableServiceModel asm);
        List<ProfileModel> GetProfile(ProfileModel pm);
        List<ItemsByTypeModel> GetProfileItem(ProfileModel pm);
        String InsertService(AvailableServiceModel asm);
        ServiceInsertResponse InsertServiceNew(ServiceInsertInputModel asm);
        String CancelServiceOrder(AvailableServiceModel asm);
        List<ServiceGroupModel> GetServicesGroups(ServiceGroupInput sgi); 
        List<AvailableServiceModel> GetServicesOrderByDate(AvailableServiceModel asm);
        List<AvailableServiceModel> GetServicesOrderLoad(AvailableServiceModel asm);
        List<AvailableServiceModel> GetServicesOrderDetailById(int sid);

    }
}
