using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        List<ProffessionModel> GetProfession();
        List<AppTypeModel> GetAppType();
        List<ReligionModel> GetReligion();
        //string SendAddPatientInformation(int patientId);
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();
        List<DepartmentModel> GetDepartments();


    }
}
