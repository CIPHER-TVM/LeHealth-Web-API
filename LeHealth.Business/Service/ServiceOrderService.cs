using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderManager serviceorderManager;
        public ServiceOrderService(IServiceOrderManager _serviceorderManager)
        {
            serviceorderManager = _serviceorderManager;
        }
        public List<GroupModel> GetItemsGroup(Int32 groupId)
        {
            return serviceorderManager.GetItemsGroup(groupId);
        }
        public List<ItemsByTypeModel> GetPackageItem(Int32 packId)
        {
            return serviceorderManager.GetPackageItem(packId);
        }
        public List<AvailableServiceModel> GetAvailableService(AvailableServiceModel asm)
        {
            return serviceorderManager.GetAvailableService(asm);
        }
        public List<AvailableServiceModel> GetLastConsultation(AvailableServiceModel asm)
        {
            return serviceorderManager.GetLastConsultation(asm);
        }
        public List<ProfileModel> GetProfile(ProfileModel pm)
        {
            return serviceorderManager.GetProfile(pm);
        }
        public List<ItemsByTypeModel> GetProfileItem(ProfileModel pm)
        {
            return serviceorderManager.GetProfileItem(pm);
        }

        public string InsertService(AvailableServiceModel asm)
        {
            return serviceorderManager.InsertService(asm);
        }
        public string CancelServiceOrder(AvailableServiceModel asm)
        {
            return serviceorderManager.CancelServiceOrder(asm);
        }
        public List<ServiceGroupModel> GetServicesGroups()
        {
            return serviceorderManager.GetServicesGroups();
        }

    }
}
