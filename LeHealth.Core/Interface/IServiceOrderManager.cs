﻿using LeHealth.Entity.DataModel;
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
        List<AvailableServiceModel> GetLastConsultation(AvailableServiceModel asm);
        List<ProfileModel> GetProfile(ProfileModel pm);
        List<ItemsByTypeModel> GetProfileItem(ProfileModel pm);
        String InsertService(AvailableServiceModel asm);
        String CancelServiceOrder(AvailableServiceModel asm);
        List<ServiceGroupModel> GetServicesGroups();
        List<AvailableServiceModel> GetServicesOrderByDate(AvailableServiceModel asm);

    }
}
