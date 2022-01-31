using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface ILocationService
    {
        String Save(LocationModel obj);
        List<LocationModel> GetLocations(int hospitalId);
        LocationModel GetLocationById(int locationId);
        List<LocationType> GetLocationTypes();
    }
}
