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
                TripSettings trips = new TripSettings();
                var listTripSetting = context.TabTripSettings.Where(t => t.IsActive== true).ToList();


                trips.AssignMethod = listTripSetting.FirstOrDefault(t=>t.TripSettingsId==1).TripSettingsAnswer;
                trips.RequestWaitSecond = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 2).TripSettingsAnswer;
                trips.CaptainGetTrips = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 3).TripSettingsAnswer;
                trips.CaptainsRatingLimit = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 4).TripSettingsAnswer;
                trips.CertainMinutes = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 5).TripSettingsAnswer;
                trips.DispatchRequest = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 6).TripSettingsAnswer;
                trips.LocationChangeLimit = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 7).TripSettingsAnswer;
                trips.PickupLocationUnits = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 8).TripSettingsAnswer;
                trips.RequestInKm = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 9).TripSettingsAnswer;
                trips.ScheduleTripsTime = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 10).TripSettingsAnswer;
                trips.RewardPoints = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 11).TripSettingsAnswer;
                trips.TransferTripAmount = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 12).TripSettingsAnswer;
                trips.TripGraceTime = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 13).TripSettingsAnswer;
                
                return trips != null ? trips : null;

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
