using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IServiceOrderManager
    {
        List<GroupModel> GetItemsGroup(int groupId); 
        List<ItemsByTypeModel> GetPackageItem(int packId);
        List<AvailableServiceModel> GetAvailableService(AvailableServiceModel asm);
        String InsertService(AvailableServiceModel asm);

    }
}
