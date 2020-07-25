using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class DATypes
    {
        public List<VehicleTypeList> listofVehicles(TaxiAppzDBContext context)
        {
            List<VehicleTypeList> vehicleTypeLists = new List<VehicleTypeList>();
            var vechilesTupe = context.TabTypes.ToList();
            foreach (var vechiles in vechilesTupe)
            {
                vehicleTypeLists.Add(new VehicleTypeList()
                {
                  
                });
            }
            return vehicleTypeLists;
        }
    }
}
