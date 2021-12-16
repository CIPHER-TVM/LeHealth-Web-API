using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Service.ServiceInterface;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;

namespace LeHealth.Service.Service
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMasterDataManager masterdataManager;
        private readonly IFileUploadService fileUploadService;
        public MasterDataService(IMasterDataManager _masterdataManager, IFileUploadService _fileUploadService)
        {
            masterdataManager = _masterdataManager;
            fileUploadService = _fileUploadService;
        }

        public List<ProffessionModel> GetProfession()
        {
            return masterdataManager.GetProfession();
        }
        public List<AppTypeModel> GetAppType()
        {
            return masterdataManager.GetAppType();
        }
        public string InsertZone(ZoneModel zone)
        {
            return masterdataManager.InsertZone(zone);
        }


        public string UpdateZone(ZoneModel zone)
        {
            return masterdataManager.UpdateZone(zone);
        }
        public string DeleteZone(int zoneId)
        {
            return masterdataManager.DeleteZone(zoneId);
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            return masterdataManager.GetZoneById(zoneId);
        }
        public List<ZoneModel> GetAllZone()
        {
            return masterdataManager.GetAllZone();
        }

        public List<ReligionModel> GetReligion()
        {
            return masterdataManager.GetReligion();
        }

        /// <summary>
        ///Returns  all departments from the hospital as Generic List. Step two in code execution flow
        /// </summary>
        public List<DepartmentModel> GetDepartments()
        {
            return masterdataManager.GetDepartments();
        }

    }
}
