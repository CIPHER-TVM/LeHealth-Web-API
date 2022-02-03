using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationManager locationmanager;

        public LocationService(ILocationManager _locationmanager)
        {
            locationmanager = _locationmanager;
        }

        public LocationModel GetLocationById(int locationId)
        {
            return locationmanager.GetLocationById(locationId);
        }

        public List<LocationModel> GetLocations(int hospitalId)
        {
            return locationmanager.GetLocations(hospitalId);
        }

        public List<LocationType> GetLocationTypes()
        {
            return locationmanager.GetLocationTypes();
        }

        public string Save(LocationModel obj)
        {
            return locationmanager.Save(obj);
        }
    }
}
