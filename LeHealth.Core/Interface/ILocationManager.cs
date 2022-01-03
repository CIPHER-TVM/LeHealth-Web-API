using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ILocationManager
    {
        string Save(LocationModel obj);
        List<LocationModel> GetLocations(int hospitalId);
        LocationModel GetLocationById(int locationId);
        List<LocationType> GetLocationTypes();
    }
}
