using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class TripSettings
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tripSettingQuestion")]
        public string TripSettingQuestion { get; set; }

        [JsonProperty("TripSettingAnswer")]
        public string TripSettingAnswer { get; set; }

        [JsonProperty("assignMethod")]
        public string AssignMethod { get; set; }

        [JsonProperty("requestWaitSecond")]
        public string RequestWaitSecond { get; set; }

        [JsonProperty("requestInKm")]
        public string RequestInKm { get; set; }

        [JsonProperty("transferTripAmount")]
        public string TransferTripAmount { get; set; }

        [JsonProperty("pickupLocationUnits")]
        public string PickupLocationUnits { get; set; }

        [JsonProperty("captainGetTrips")]
        public string CaptainGetTrips { get; set; }

        [JsonProperty("locationChangeLimit")]
        public string LocationChangeLimit { get; set; }

        [JsonProperty("captainsRatingLimit")]
        public string CaptainsRatingLimit { get; set; }

        [JsonProperty("tripGraceTime")]
        public string TripGraceTime { get; set; }

        [JsonProperty("scheduleTripsTime")]
        public string ScheduleTripsTime { get; set; }

        [JsonProperty("dispatchRequest")]
        public string DispatchRequest { get; set; }

        [JsonProperty("CertainMinutes")]
        public string CertainMinutes { get; set; }

        [JsonProperty("rewardPoints")]
        public string RewardPoints { get; set; }
    }

    public class SettingsModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("trip_how_trip_assign")]
        public string trip_how_trip_assign { get; set; }

        [JsonProperty("trip_how_many_seconds")]
        public string trip_how_many_seconds { get; set; }

        [JsonProperty("trip_radius_to_get_captains")]
        public string trip_radius_to_get_captains { get; set; }

        [JsonProperty("trip_auto_transfer")]
        public string trip_auto_transfer { get; set; }

        [JsonProperty("trip_captain_auto_offline")]
        public string trip_captain_auto_offline { get; set; }

        [JsonProperty("trip_radius_near_pickup")]
        public string trip_radius_near_pickup { get; set; }

        [JsonProperty("trip_how_many_trips")]
        public string trip_how_many_trips { get; set; }

        [JsonProperty("trip_pickup_location")]
        public string trip_pickup_location { get; set; }

        [JsonProperty("trip_top20_captains")]
        public string trip_top20_captains { get; set; }

        [JsonProperty("trip_grace_time_waiting")]
        public string trip_grace_time_waiting { get; set; }

        [JsonProperty("trip_minimum_time_period")]
        public string trip_minimum_time_period { get; set; }

        [JsonProperty("trip_dispatch_request")]
        public string trip_dispatch_request { get; set; }

        [JsonProperty("trip_cancel_button_enable")]
        public string trip_cancel_button_enable { get; set; }

        [JsonProperty("trip_reward_points")]
        public string trip_reward_points { get; set; }

        [JsonProperty("wallet_user_wallet_amount")]
        public string wallet_user_wallet_amount { get; set; }

        [JsonProperty("wallet_captain_wallet_amount")]
        public string wallet_captain_wallet_amount { get; set; }

        [JsonProperty("wallet_maximum_balance")]
        public string wallet_maximum_balance { get; set; }

        [JsonProperty("wallet_maximum_amount_added")]
        public string wallet_maximum_amount_added { get; set; }

        [JsonProperty("installation_google_browser_key")]
        public string installation_google_browser_key { get; set; }

        [JsonProperty("installation_sms_gateway_url")]
        public string installation_sms_gateway_url { get; set; }

        [JsonProperty("installation_sms_account_sid")]
        public string installation_sms_account_sid { get; set; }

        [JsonProperty("installation_sms_auth_taken")]
        public string installation_sms_auth_taken { get; set; }

        [JsonProperty("installation_sms_auth_number")]
        public string installation_sms_auth_number { get; set; }

        [JsonProperty("installation_braintree_environment")]
        public string installation_braintree_environment { get; set; }

        [JsonProperty("installation_sandbox")]
        public string installation_sandbox { get; set; }

        [JsonProperty("installation_braintree_merchant_id")]
        public string installation_braintree_merchant_id { get; set; }

        [JsonProperty("installation_braintree_public_key")]
        public string installation_braintree_public_key { get; set; }

        [JsonProperty("installation_braintree_private_key")]
        public string installation_braintree_private_key { get; set; }

        [JsonProperty("installation_braintree_master_merchant")]
        public string installation_braintree_master_merchant { get; set; }

        [JsonProperty("installation_braintree_default_merchant")]
        public string installation_braintree_default_merchant { get; set; }

        [JsonProperty("installation_payment_gateway_merchant_id")]
        public string installation_payment_gateway_merchant_id { get; set; }

        [JsonProperty("installation_stripe_payment_public_key")]
        public string installation_stripe_payment_public_key { get; set; }

        [JsonProperty("installation_stripe_payment_private_key")]
        public string installation_stripe_payment_private_key { get; set; }

        [JsonProperty("installation_stripe_payment_master_merchant")]
        public string installation_stripe_payment_master_merchant { get; set; }

        [JsonProperty("installation_stripe_payment_default_merchant")]
        public string installation_stripe_payment_default_merchant { get; set; }

        [JsonProperty("general_application_name")]
        public string general_application_name { get; set; }

        [JsonProperty("general_application_logo")]
        public string general_application_logo { get; set; }

        [JsonProperty("general_head_office_number")]
        public string general_head_office_number { get; set; }

        [JsonProperty("general_customer_care_number")]
        public string general_customer_care_number { get; set; }

        [JsonProperty("general_help_email_address")]
        public string general_help_email_address { get; set; }

        [JsonProperty("general_time_zone")]
        public string general_time_zone { get; set; }

        [JsonProperty("isActive")]
        public bool ?isActive { get; set; }
    }
}
