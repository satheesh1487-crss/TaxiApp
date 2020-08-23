using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Models;

namespace TaziappzMobileWebAPI.Helper
{
    public static class Validator
    {
        public static void validateProfile(ProfileModel profileModel)
        {
            if (profileModel.Id == 0) {
                throw new DataValidationException($"Id does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.FirstName))
            {
                throw new DataValidationException($"FirstName does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.LastName))
            {
                throw new DataValidationException($"LastName does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.Profile_Pic))
            {
                throw new DataValidationException($"Profile_Pic does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.Old_Password))
            {
                throw new DataValidationException($"Old_Password does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.New_Password))
            {
                throw new DataValidationException($"New_Password does not exists");
            }
            if (!string.IsNullOrEmpty(profileModel.Phone_Number))
            {
                throw new DataValidationException($"Phone_Number does not exists");
            }
        }

        public static void validateDriverProfile(GeneralModel generalModel)
        {
            if (generalModel.Id == 0)
            {
                throw new DataValidationException($"Id does not exists");
            }
        }
        

        public static void validateZoneSos(UserZoneSOSModel userZoneSOSModel)
        {
            if (!string.IsNullOrEmpty(userZoneSOSModel.Longitude))
            {
                throw new DataValidationException($"Longitude does not exists");
            }

            if (!string.IsNullOrEmpty(userZoneSOSModel.Latitude))
            {
                throw new DataValidationException($"Latitude does not exists");
            }
        }

        public static void validateFAQList(UserFAQListModel userFAQListModel)
        {
            if (!string.IsNullOrEmpty(userFAQListModel.Longitude))
            {
                throw new DataValidationException($"Longitude does not exists");
            }

            if (!string.IsNullOrEmpty(userFAQListModel.Latitude))
            {
                throw new DataValidationException($"Latitude does not exists");
            }

            if (userFAQListModel.Type == 0)
            {
                throw new DataValidationException($"Type does not exists");
            }
        }
    }
}
