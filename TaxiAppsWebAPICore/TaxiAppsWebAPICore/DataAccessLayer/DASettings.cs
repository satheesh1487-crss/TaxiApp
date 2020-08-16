using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DASettings
    {
        public TripSettings GetTripSettings(TaxiAppzDBContext context)
        {
            try
            {
                TripSettings tripSettings = new TripSettings();
                var listTripSetting = context.TabTripSettings.FirstOrDefault(t => t.TripSettingsId == tripSettings.Id);
                if (listTripSetting != null)
                {
                    tripSettings.Id = listTripSetting.TripSettingsId;
                    tripSettings.TripSettingQuestion = listTripSetting.TripSettingsQuestion;
                    tripSettings.TripSettingAnswer = listTripSetting.TripSettingsAnswer;
                }
                return tripSettings != null ? tripSettings : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return null;
            }
        }

        public bool SaveTripSettings(TripSettings tripSettings, TaxiAppzDBContext content, LoggedInUser loggedIn)
        {
            var exist = content.TabTripSettings.FirstOrDefault(t => t.IsActive == false && t.TripSettingsId == tripSettings.Id);
            if (exist == null)
            {
                TabTripSettings tabTripSettings = new TabTripSettings();
                tabTripSettings.TripSettingsId = tripSettings.Id;
                tabTripSettings.TripSettingsQuestion = tripSettings.TripSettingQuestion;
                tabTripSettings.TripSettingsAnswer = tripSettings.TripSettingAnswer;
                tabTripSettings.IsActive = true;
                tabTripSettings.UpdatedAt = tabTripSettings.CreatedAt = Extention.GetDateTime();
                tabTripSettings.UpdatedBy = tabTripSettings.CreatedBy = loggedIn.UserName;
                content.TabTripSettings.Add(tabTripSettings);
                content.SaveChanges();
                return true;
            }
            else
            {
                exist.TripSettingsId = tripSettings.Id;
                exist.TripSettingsQuestion = tripSettings.TripSettingQuestion;
                exist.TripSettingsAnswer = tripSettings.TripSettingAnswer;
                exist.UpdatedAt = Extention.GetDateTime();
                exist.UpdatedBy = loggedIn.UserName;
                content.TabTripSettings.Update(exist);
                content.SaveChanges();
                return true;
            }

        }
    }
}
