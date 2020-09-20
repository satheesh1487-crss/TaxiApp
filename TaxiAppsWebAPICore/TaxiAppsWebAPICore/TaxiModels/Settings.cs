using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("settings")]
    public partial class Settings
    {
        [Key]
        [Column("settingid")]
        public long Settingid { get; set; }
        [Required]
        [Column("trip_how_trip_assign")]
        [StringLength(300)]
        public string TripHowTripAssign { get; set; }
        [Required]
        [Column("trip_how_many_seconds")]
        [StringLength(300)]
        public string TripHowManySeconds { get; set; }
        [Required]
        [Column("trip_radius_to_get_captains")]
        [StringLength(300)]
        public string TripRadiusToGetCaptains { get; set; }
        [Required]
        [Column("trip_auto_transfer")]
        [StringLength(300)]
        public string TripAutoTransfer { get; set; }
        [Required]
        [Column("trip_captain_auto_offline")]
        [StringLength(300)]
        public string TripCaptainAutoOffline { get; set; }
        [Required]
        [Column("trip_radius_near_pickup")]
        [StringLength(300)]
        public string TripRadiusNearPickup { get; set; }
        [Required]
        [Column("trip_how_many_trips")]
        [StringLength(300)]
        public string TripHowManyTrips { get; set; }
        [Required]
        [Column("trip_pickup_location")]
        [StringLength(300)]
        public string TripPickupLocation { get; set; }
        [Required]
        [Column("trip_top20_captains")]
        [StringLength(300)]
        public string TripTop20Captains { get; set; }
        [Required]
        [Column("trip_grace_time_waiting")]
        [StringLength(300)]
        public string TripGraceTimeWaiting { get; set; }
        [Required]
        [Column("trip_minimum_time_period")]
        [StringLength(300)]
        public string TripMinimumTimePeriod { get; set; }
        [Required]
        [Column("trip_dispatch_request")]
        [StringLength(300)]
        public string TripDispatchRequest { get; set; }
        [Required]
        [Column("trip_cancel_button_enable")]
        [StringLength(300)]
        public string TripCancelButtonEnable { get; set; }
        [Required]
        [Column("trip_reward_points")]
        [StringLength(300)]
        public string TripRewardPoints { get; set; }
        [Required]
        [Column("wallet_user_wallet_amount")]
        [StringLength(300)]
        public string WalletUserWalletAmount { get; set; }
        [Required]
        [Column("wallet_captain_wallet_amount")]
        [StringLength(300)]
        public string WalletCaptainWalletAmount { get; set; }
        [Required]
        [Column("wallet_maximum_balance")]
        [StringLength(300)]
        public string WalletMaximumBalance { get; set; }
        [Required]
        [Column("wallet_maximum_amount_added")]
        [StringLength(300)]
        public string WalletMaximumAmountAdded { get; set; }
        [Required]
        [Column("installation_google_browser_key")]
        [StringLength(300)]
        public string InstallationGoogleBrowserKey { get; set; }
        [Required]
        [Column("installation_sms_gateway_url")]
        [StringLength(300)]
        public string InstallationSmsGatewayUrl { get; set; }
        [Required]
        [Column("installation_sms_account_sid")]
        [StringLength(300)]
        public string InstallationSmsAccountSid { get; set; }
        [Required]
        [Column("installation_sms_auth_taken")]
        [StringLength(300)]
        public string InstallationSmsAuthTaken { get; set; }
        [Required]
        [Column("installation_sms_auth_number")]
        [StringLength(300)]
        public string InstallationSmsAuthNumber { get; set; }
        [Required]
        [Column("installation_braintree_environment")]
        [StringLength(300)]
        public string InstallationBraintreeEnvironment { get; set; }
        [Required]
        [Column("installation_sandbox")]
        [StringLength(300)]
        public string InstallationSandbox { get; set; }
        [Required]
        [Column("installation_braintree_merchant_id")]
        [StringLength(300)]
        public string InstallationBraintreeMerchantId { get; set; }
        [Required]
        [Column("installation_braintree_public_key")]
        [StringLength(300)]
        public string InstallationBraintreePublicKey { get; set; }
        [Required]
        [Column("installation_braintree_private_key")]
        [StringLength(300)]
        public string InstallationBraintreePrivateKey { get; set; }
        [Required]
        [Column("installation_braintree_master_merchant")]
        [StringLength(300)]
        public string InstallationBraintreeMasterMerchant { get; set; }
        [Required]
        [Column("installation_braintree_default_merchant")]
        [StringLength(300)]
        public string InstallationBraintreeDefaultMerchant { get; set; }
        [Required]
        [Column("installation_payment_gateway_merchant_id")]
        [StringLength(300)]
        public string InstallationPaymentGatewayMerchantId { get; set; }
        [Required]
        [Column("installation_stripe_payment_public_key")]
        [StringLength(300)]
        public string InstallationStripePaymentPublicKey { get; set; }
        [Required]
        [Column("installation_stripe_payment_private_key")]
        [StringLength(300)]
        public string InstallationStripePaymentPrivateKey { get; set; }
        [Required]
        [Column("installation_stripe_payment_master_merchant")]
        [StringLength(300)]
        public string InstallationStripePaymentMasterMerchant { get; set; }
        [Required]
        [Column("installation_stripe_payment_default_merchant")]
        [StringLength(300)]
        public string InstallationStripePaymentDefaultMerchant { get; set; }
        [Required]
        [Column("general_application_name")]
        [StringLength(300)]
        public string GeneralApplicationName { get; set; }
        [Required]
        [Column("general_application_logo")]
        [StringLength(300)]
        public string GeneralApplicationLogo { get; set; }
        [Required]
        [Column("general_head_office_number")]
        [StringLength(300)]
        public string GeneralHeadOfficeNumber { get; set; }
        [Required]
        [Column("general_customer_care_number")]
        [StringLength(300)]
        public string GeneralCustomerCareNumber { get; set; }
        [Required]
        [Column("general_help_email_address")]
        [StringLength(300)]
        public string GeneralHelpEmailAddress { get; set; }
        [Required]
        [Column("general_time_zone")]
        [StringLength(300)]
        public string GeneralTimeZone { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
