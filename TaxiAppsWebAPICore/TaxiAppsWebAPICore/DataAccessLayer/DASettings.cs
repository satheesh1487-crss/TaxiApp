using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
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
                var listTripSetting = context.TabTripSettings.Where(t => t.IsActive == true).ToList();


                trips.AssignMethod = listTripSetting.FirstOrDefault(t => t.TripSettingsId == 1).TripSettingsAnswer;
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

        public SettingsModel GetbySettingsId(TaxiAppzDBContext context)
        {
            try
            {
                SettingsModel settingsModel = new SettingsModel();
                var listSetting = context.Settings.FirstOrDefault(t => t.IsActive == true);
                if (listSetting != null)
                {
                    settingsModel.Id = listSetting.Settingid;
                    settingsModel.trip_how_trip_assign = listSetting.TripHowTripAssign;
                    settingsModel.trip_how_many_seconds = listSetting.TripHowManySeconds;
                    settingsModel.trip_radius_to_get_captains = listSetting.TripRadiusToGetCaptains;
                    settingsModel.trip_auto_transfer = listSetting.TripAutoTransfer;
                    settingsModel.trip_captain_auto_offline = listSetting.TripCaptainAutoOffline;
                    settingsModel.trip_radius_near_pickup = listSetting.TripRadiusNearPickup;
                    settingsModel.trip_how_many_trips = listSetting.TripHowManyTrips;
                    settingsModel.trip_pickup_location = listSetting.TripPickupLocation;
                    settingsModel.trip_top20_captains = listSetting.TripTop20Captains;
                    settingsModel.trip_grace_time_waiting = listSetting.TripGraceTimeWaiting;
                    settingsModel.trip_minimum_time_period = listSetting.TripMinimumTimePeriod;
                    settingsModel.trip_dispatch_request = listSetting.TripDispatchRequest;
                    settingsModel.trip_cancel_button_enable = listSetting.TripCancelButtonEnable;
                    settingsModel.trip_reward_points = listSetting.TripRewardPoints;
                    settingsModel.wallet_user_wallet_amount = listSetting.WalletUserWalletAmount;
                    settingsModel.wallet_captain_wallet_amount = listSetting.WalletCaptainWalletAmount;
                    settingsModel.wallet_maximum_balance = listSetting.WalletMaximumBalance;
                    settingsModel.wallet_maximum_amount_added = listSetting.WalletMaximumAmountAdded;
                    settingsModel.installation_google_browser_key = listSetting.InstallationGoogleBrowserKey;
                    settingsModel.installation_sms_gateway_url = listSetting.InstallationSmsGatewayUrl;
                    settingsModel.installation_sms_account_sid = listSetting.InstallationSmsAccountSid;
                    settingsModel.installation_sms_auth_number = listSetting.InstallationSmsAuthNumber;
                    settingsModel.installation_sms_auth_taken = listSetting.InstallationSmsAuthTaken;
                    settingsModel.installation_braintree_environment = listSetting.InstallationBraintreeEnvironment;
                    settingsModel.installation_sandbox = listSetting.InstallationSandbox;
                    settingsModel.installation_braintree_merchant_id = listSetting.InstallationBraintreeMerchantId;
                    settingsModel.installation_braintree_private_key = listSetting.InstallationBraintreePrivateKey;
                    settingsModel.installation_braintree_public_key = listSetting.InstallationBraintreePublicKey;
                    settingsModel.installation_braintree_master_merchant = listSetting.InstallationBraintreeMasterMerchant;
                    settingsModel.installation_braintree_default_merchant = listSetting.InstallationBraintreeDefaultMerchant;
                    settingsModel.installation_payment_gateway_merchant_id = listSetting.InstallationPaymentGatewayMerchantId;
                    settingsModel.installation_stripe_payment_private_key = listSetting.InstallationStripePaymentPrivateKey;
                    settingsModel.installation_stripe_payment_public_key = listSetting.InstallationStripePaymentPublicKey;
                    settingsModel.installation_stripe_payment_default_merchant = listSetting.InstallationStripePaymentDefaultMerchant;
                    settingsModel.installation_stripe_payment_master_merchant = listSetting.InstallationStripePaymentMasterMerchant;
                    settingsModel.general_application_logo = listSetting.GeneralApplicationLogo;
                    settingsModel.general_application_name = listSetting.GeneralApplicationName;
                    settingsModel.general_customer_care_number = listSetting.GeneralCustomerCareNumber;
                    settingsModel.general_head_office_number = listSetting.GeneralHeadOfficeNumber;
                    settingsModel.general_help_email_address = listSetting.GeneralHelpEmailAddress;
                    settingsModel.general_time_zone = listSetting.GeneralTimeZone;
                    settingsModel.isActive = listSetting.IsActive;
                }

                return settingsModel != null ? settingsModel : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return null;
            }
        }

        public bool SaveSettings(TaxiAppzDBContext context, SettingsModel settingsModel, LoggedInUser loggedInUser)
        {
            var settingsExists = context.Settings.FirstOrDefault(t => t.IsActive == true);
            if (settingsExists == null)
            {
                Settings settings = settinginfo(settingsModel, loggedInUser);
                context.Settings.Add(settings);
                context.SaveChanges();
                return true;
            }
            else
            {
                settingsExists.IsActive = false;
                settingsExists.UpdatedBy = loggedInUser.Email;
                settingsExists.UpdatedAt = DateTime.Now;
                Settings settings = settinginfo(settingsModel, loggedInUser);
                context.Settings.Add(settings);
                context.SaveChanges();
                return true;
            }
        }

        private static Settings settinginfo(SettingsModel settingsModel, LoggedInUser loggedInUser)
        {
            Settings settings = new Settings();            
            settings.TripHowTripAssign = settingsModel.trip_how_trip_assign;
            settings.TripHowManySeconds = settingsModel.trip_how_many_seconds;
            settings.TripRadiusToGetCaptains = settingsModel.trip_radius_to_get_captains;
            settings.TripAutoTransfer = settingsModel.trip_auto_transfer;
            settings.TripCaptainAutoOffline = settingsModel.trip_captain_auto_offline;
            settings.TripRadiusNearPickup = settingsModel.trip_radius_near_pickup;
            settings.TripHowManyTrips = settingsModel.trip_how_many_trips;
            settings.TripPickupLocation = settingsModel.trip_pickup_location;
            settings.TripTop20Captains = settingsModel.trip_top20_captains;
            settings.TripGraceTimeWaiting = settingsModel.trip_grace_time_waiting;
            settings.TripMinimumTimePeriod = settingsModel.trip_minimum_time_period;
            settings.TripDispatchRequest = settingsModel.trip_dispatch_request;
            settings.TripCancelButtonEnable = settingsModel.trip_cancel_button_enable;
            settings.TripRewardPoints = settingsModel.trip_reward_points;
            settings.WalletUserWalletAmount = settingsModel.wallet_user_wallet_amount;
            settings.WalletCaptainWalletAmount = settingsModel.wallet_captain_wallet_amount;
            settings.WalletMaximumBalance = settingsModel.wallet_maximum_balance;
            settings.WalletMaximumAmountAdded = settingsModel.wallet_maximum_amount_added;
            settings.InstallationGoogleBrowserKey = settingsModel.installation_google_browser_key;
            settings.InstallationSmsGatewayUrl = settingsModel.installation_sms_gateway_url;
            settings.InstallationSmsAccountSid = settingsModel.installation_sms_account_sid;
            settings.InstallationSmsAuthNumber = settingsModel.installation_sms_auth_number;
            settings.InstallationSmsAuthTaken = settingsModel.installation_sms_auth_taken;
            settings.InstallationBraintreeEnvironment = settingsModel.installation_braintree_environment;
            settings.InstallationSandbox = settingsModel.installation_sandbox;
            settings.InstallationBraintreeMerchantId = settingsModel.installation_braintree_merchant_id;
            settings.InstallationBraintreePrivateKey = settingsModel.installation_braintree_private_key;
            settings.InstallationBraintreePublicKey = settingsModel.installation_braintree_public_key;
            settings.InstallationBraintreeMasterMerchant = settingsModel.installation_braintree_master_merchant;
            settings.InstallationBraintreeDefaultMerchant = settingsModel.installation_braintree_default_merchant;
            settings.InstallationPaymentGatewayMerchantId = settingsModel.installation_payment_gateway_merchant_id;
            settings.InstallationStripePaymentPrivateKey = settingsModel.installation_stripe_payment_private_key;
            settings.InstallationStripePaymentPublicKey = settingsModel.installation_stripe_payment_public_key;
            settings.InstallationStripePaymentDefaultMerchant = settingsModel.installation_stripe_payment_default_merchant;
            settings.InstallationStripePaymentMasterMerchant = settingsModel.installation_stripe_payment_master_merchant;
            settings.GeneralApplicationLogo = settingsModel.general_application_logo;
            settings.GeneralApplicationName = settingsModel.general_application_name;
            settings.GeneralCustomerCareNumber = settingsModel.general_customer_care_number;
            settings.GeneralHeadOfficeNumber = settingsModel.general_head_office_number;
            settings.GeneralHelpEmailAddress = settingsModel.general_help_email_address;
            settings.GeneralTimeZone = settingsModel.general_time_zone;
            settings.IsActive = settingsModel.isActive;

            settings.CreatedAt = DateTime.UtcNow;
            settings.UpdatedAt = DateTime.UtcNow;
            settings.UpdatedBy = settings.CreatedBy = loggedInUser.Email;
            return settings;
        }
    }
}
