using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {
        List<ProffessionModel> GetProfession();
        List<AppTypeModel> GetAppType();
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();
        List<ReligionModel> GetReligion();
        List<DepartmentModel> GetDepartments();
    }
}
