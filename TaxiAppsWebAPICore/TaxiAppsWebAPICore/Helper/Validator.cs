using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Helper
{
    public class Validator
    {
        public static void validateZone(ManageZoneAdd manageZone)
        {
            if (manageZone.Zoneid == 0)
            {
                throw new DataValidationException($"Id does not exists");
            }
            if (!string.IsNullOrEmpty(manageZone.ZoneName))
            {
                throw new DataValidationException($"FirstName does not exists");
            }
            if (!string.IsNullOrEmpty(manageZone.Unit))
            {
                throw new DataValidationException($"LastName does not exists");
            }
            if (manageZone.Serviceslocid == 0)
            {
                throw new DataValidationException($"Old_Password does not exists");
            }
        }

        public static void validateZoneAdd(ManageZoneAdd manageZone)
        {
            if (!string.IsNullOrEmpty(manageZone.ZoneName))
            {
                throw new DataValidationException($"FirstName does not exists");
            }
            if (!string.IsNullOrEmpty(manageZone.Unit))
            {
                throw new DataValidationException($"LastName does not exists");
            }
            if (manageZone.Serviceslocid == 0)
            {
                throw new DataValidationException($"Old_Password does not exists");
            }
        }
    }
}
