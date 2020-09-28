using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("set_privilege")]
    public partial class SetPrivilege
    {
        [Key]
        [Column("privilegeid")]
        public long Privilegeid { get; set; }
        [Column("dashboard")]
        public bool? Dashboard { get; set; }
        [Column("dashboard_dash")]
        public bool? DashboardDash { get; set; }
        [Column("admin_mgnt")]
        public bool? AdminMgnt { get; set; }
        [Column("admin_manage_admin")]
        public bool? AdminManageAdmin { get; set; }
        [Column("admin_manage_admin_add")]
        public bool? AdminManageAdminAdd { get; set; }
        [Column("admin_manage_admin_edit")]
        public bool? AdminManageAdminEdit { get; set; }
        [Column("admin_manage_admin_delete")]
        public bool? AdminManageAdminDelete { get; set; }
        [Column("admin_manage_role")]
        public bool? AdminManageRole { get; set; }
        [Column("admin_manage_role_add")]
        public bool? AdminManageRoleAdd { get; set; }
        [Column("admin_manage_role_edit")]
        public bool? AdminManageRoleEdit { get; set; }
        [Column("admin_manage_role_privilege")]
        public bool? AdminManageRolePrivilege { get; set; }
        [Column("user_mgnt")]
        public bool? UserMgnt { get; set; }
        [Column("user_manage_user")]
        public bool? UserManageUser { get; set; }
        [Column("user_manage_user_add")]
        public bool? UserManageUserAdd { get; set; }
        [Column("user_manage_user_edit")]
        public bool? UserManageUserEdit { get; set; }
        [Column("user_manage_user_delete")]
        public bool? UserManageUserDelete { get; set; }
        [Column("user_manage_user_wallet")]
        public bool? UserManageUserWallet { get; set; }
        [Column("user_blocked_user")]
        public bool? UserBlockedUser { get; set; }
        [Column("user_blocked_user_approve")]
        public bool? UserBlockedUserApprove { get; set; }
        [Column("driver_mgnt")]
        public bool? DriverMgnt { get; set; }
        [Column("driver_manage_driver")]
        public bool? DriverManageDriver { get; set; }
        [Column("driver_manage_driver_add")]
        public bool? DriverManageDriverAdd { get; set; }
        [Column("driver_manage_driver_upload")]
        public bool? DriverManageDriverUpload { get; set; }
        [Column("driver_manage_driver_edit")]
        public bool? DriverManageDriverEdit { get; set; }
        [Column("driver_manage_driver_delete")]
        public bool? DriverManageDriverDelete { get; set; }
        [Column("driver_manage_driver_edit_reward")]
        public bool? DriverManageDriverEditReward { get; set; }
        [Column("driver_manage_driver_approve")]
        public bool? DriverManageDriverApprove { get; set; }
        [Column("driver_wallet_payment")]
        public bool? DriverWalletPayment { get; set; }
        [Column("driver_wallet_payment_wallet")]
        public bool? DriverWalletPaymentWallet { get; set; }
        [Column("driver_wallet_payment_add")]
        public bool? DriverWalletPaymentAdd { get; set; }
        [Column("driver_account_payment")]
        public bool? DriverAccountPayment { get; set; }
        [Column("driver_account_payment_add")]
        public bool? DriverAccountPaymentAdd { get; set; }
        [Column("driver_account_payment_transfer")]
        public bool? DriverAccountPaymentTransfer { get; set; }
        [Column("driver_earning_payment")]
        public bool? DriverEarningPayment { get; set; }
        [Column("driver_earning_payment_earning")]
        public bool? DriverEarningPaymentEarning { get; set; }
        [Column("driver_earning_payment_savings")]
        public bool? DriverEarningPaymentSavings { get; set; }
        [Column("driver_earning_payment_cancel")]
        public bool? DriverEarningPaymentCancel { get; set; }
        [Column("driver_fine")]
        public bool? DriverFine { get; set; }
        [Column("driver_fine_add")]
        public bool? DriverFineAdd { get; set; }
        [Column("driver_fine_pay")]
        public bool? DriverFinePay { get; set; }
        [Column("driver_fine_edit")]
        public bool? DriverFineEdit { get; set; }
        [Column("driver_fine_delete")]
        public bool? DriverFineDelete { get; set; }
        [Column("driver_bonus")]
        public bool? DriverBonus { get; set; }
        [Column("driver_bonus_add")]
        public bool? DriverBonusAdd { get; set; }
        [Column("driver_blocked")]
        public bool? DriverBlocked { get; set; }
        [Column("driver_blocked_approve")]
        public bool? DriverBlockedApprove { get; set; }
        [Column("zone_mgnt")]
        public bool? ZoneMgnt { get; set; }
        [Column("zone_manage_zone")]
        public bool? ZoneManageZone { get; set; }
        [Column("zone_manage_zone_add")]
        public bool? ZoneManageZoneAdd { get; set; }
        [Column("zone_manage_zone_map")]
        public bool? ZoneManageZoneMap { get; set; }
        [Column("zone_manage_zone_edit")]
        public bool? ZoneManageZoneEdit { get; set; }
        [Column("zone_manage_zone_delete")]
        public bool? ZoneManageZoneDelete { get; set; }
        [Column("zone_manage_zone_active")]
        public bool? ZoneManageZoneActive { get; set; }
        [Column("zone_manage_zone_inactive")]
        public bool? ZoneManageZoneInactive { get; set; }
        [Column("zone_operation")]
        public bool? ZoneOperation { get; set; }
        [Column("zone_operation_add")]
        public bool? ZoneOperationAdd { get; set; }
        [Column("zone_operation_map")]
        public bool? ZoneOperationMap { get; set; }
        [Column("zone_operation_zone_settings")]
        public bool? ZoneOperationZoneSettings { get; set; }
        [Column("zone_operation_edit")]
        public bool? ZoneOperationEdit { get; set; }
        [Column("zone_operation_delete")]
        public bool? ZoneOperationDelete { get; set; }
        [Column("vehicle_mgnt")]
        public bool? VehicleMgnt { get; set; }
        [Column("vehicle_manage_type")]
        public bool? VehicleManageType { get; set; }
        [Column("vehicle_manage_edit")]
        public bool? VehicleManageEdit { get; set; }
        [Column("vehicle_manage_delete")]
        public bool? VehicleManageDelete { get; set; }
        [Column("vehicle_manage_active")]
        public bool? VehicleManageActive { get; set; }
        [Column("vehicle_manage_inactive")]
        public bool? VehicleManageInactive { get; set; }
        [Column("vehicle_pricing")]
        public bool? VehiclePricing { get; set; }
        [Column("vehicle_pricing_set")]
        public bool? VehiclePricingSet { get; set; }
        [Column("vehicle_pricing_surge")]
        public bool? VehiclePricingSurge { get; set; }
        [Column("vehicle_pricing_default")]
        public bool? VehiclePricingDefault { get; set; }
        [Column("vehicle_pricing_undefault")]
        public bool? VehiclePricingUndefault { get; set; }
        [Column("manage_currency_mgnt")]
        public bool? ManageCurrencyMgnt { get; set; }
        [Column("manage_currency_edit")]
        public bool? ManageCurrencyEdit { get; set; }
        [Column("manage_currency_delete")]
        public bool? ManageCurrencyDelete { get; set; }
        [Column("manage_currency_active")]
        public bool? ManageCurrencyActive { get; set; }
        [Column("manage_currency_inactive")]
        public bool? ManageCurrencyInactive { get; set; }
        [Column("company_mgnt")]
        public bool? CompanyMgnt { get; set; }
        [Column("company_manage")]
        public bool? CompanyManage { get; set; }
        [Column("company_manage_edit")]
        public bool? CompanyManageEdit { get; set; }
        [Column("company_manage_delete")]
        public bool? CompanyManageDelete { get; set; }
        [Column("company_drivers")]
        public bool? CompanyDrivers { get; set; }
        [Column("company_driver_edit")]
        public bool? CompanyDriverEdit { get; set; }
        [Column("company_driver_delete")]
        public bool? CompanyDriverDelete { get; set; }
        [Column("company_transaction")]
        public bool? CompanyTransaction { get; set; }
        [Column("company_transaction_edit")]
        public bool? CompanyTransactionEdit { get; set; }
        [Column("company_transaction_delete")]
        public bool? CompanyTransactionDelete { get; set; }
        [Column("request_mgnt")]
        public bool? RequestMgnt { get; set; }
        [Column("request_manage")]
        public bool? RequestManage { get; set; }
        [Column("request_manage_view")]
        public bool? RequestManageView { get; set; }
        [Column("request_schedule")]
        public bool? RequestSchedule { get; set; }
        [Column("request_schedule_view")]
        public bool? RequestScheduleView { get; set; }
        [Column("request_schedule_cancel")]
        public bool? RequestScheduleCancel { get; set; }
        [Column("transaction_details_mgnt")]
        public bool? TransactionDetailsMgnt { get; set; }
        [Column("transaction_trans_details")]
        public bool? TransactionTransDetails { get; set; }
        [Column("manage_notification_mgnt")]
        public bool? ManageNotificationMgnt { get; set; }
        [Column("manage_notifi_push")]
        public bool? ManageNotifiPush { get; set; }
        [Column("manage_sms_option")]
        public bool? ManageSmsOption { get; set; }
        [Column("manage_sms_edit")]
        public bool? ManageSmsEdit { get; set; }
        [Column("manage_sms_active")]
        public bool? ManageSmsActive { get; set; }
        [Column("manage_sms_inactive")]
        public bool? ManageSmsInactive { get; set; }
        [Column("manage_sms")]
        public bool? ManageSms { get; set; }
        [Column("manage_email")]
        public bool? ManageEmail { get; set; }
        [Column("manage_email_edit")]
        public bool? ManageEmailEdit { get; set; }
        [Column("manage_email_active")]
        public bool? ManageEmailActive { get; set; }
        [Column("manage_email_inactive")]
        public bool? ManageEmailInactive { get; set; }
        [Column("referral_mgnt")]
        public bool? ReferralMgnt { get; set; }
        [Column("referral_manage_option")]
        public bool? ReferralManageOption { get; set; }
        [Column("referral_user")]
        public bool? ReferralUser { get; set; }
        [Column("referral_driver")]
        public bool? ReferralDriver { get; set; }
        [Column("promo_code_mgnt")]
        public bool? PromoCodeMgnt { get; set; }
        [Column("promo_manage_option")]
        public bool? PromoManageOption { get; set; }
        [Column("promo_manage_add")]
        public bool? PromoManageAdd { get; set; }
        [Column("promo_manage_edit")]
        public bool? PromoManageEdit { get; set; }
        [Column("promo_manage_delete")]
        public bool? PromoManageDelete { get; set; }
        [Column("promo_manage_active")]
        public bool? PromoManageActive { get; set; }
        [Column("promo_manage_inactive")]
        public bool? PromoManageInactive { get; set; }
        [Column("promo_manage_dash")]
        public bool? PromoManageDash { get; set; }
        [Column("promo_transaction")]
        public bool? PromoTransaction { get; set; }
        [Column("cancel_mgnt")]
        public bool? CancelMgnt { get; set; }
        [Column("cancel_manage_user")]
        public bool? CancelManageUser { get; set; }
        [Column("cancel_manage_user_add")]
        public bool? CancelManageUserAdd { get; set; }
        [Column("cancel_manage_user_edit")]
        public bool? CancelManageUserEdit { get; set; }
        [Column("cancel_manage_user_compensate")]
        public bool? CancelManageUserCompensate { get; set; }
        [Column("cancel_manage_user_delete")]
        public bool? CancelManageUserDelete { get; set; }
        [Column("cancel_manage_user_active")]
        public bool? CancelManageUserActive { get; set; }
        [Column("cancel_manage_user_inactive")]
        public bool? CancelManageUserInactive { get; set; }
        [Column("cancel_manage_driver")]
        public bool? CancelManageDriver { get; set; }
        [Column("cancel_manage_driver_add")]
        public bool? CancelManageDriverAdd { get; set; }
        [Column("cancel_manage_driver_edit")]
        public bool? CancelManageDriverEdit { get; set; }
        [Column("cancel_manage_driver_compensate")]
        public bool? CancelManageDriverCompensate { get; set; }
        [Column("cancel_manage_driver_delete")]
        public bool? CancelManageDriverDelete { get; set; }
        [Column("cancel_manage_driver_active")]
        public bool? CancelManageDriverActive { get; set; }
        [Column("cancel_manage_driver_inactive")]
        public bool? CancelManageDriverInactive { get; set; }
        [Column("review_mgnt")]
        public bool? ReviewMgnt { get; set; }
        [Column("review_usertodriver")]
        public bool? ReviewUsertodriver { get; set; }
        [Column("review_usertodriver_active")]
        public bool? ReviewUsertodriverActive { get; set; }
        [Column("review_usertodriver_inactive")]
        public bool? ReviewUsertodriverInactive { get; set; }
        [Column("review_drivertouser")]
        public bool? ReviewDrivertouser { get; set; }
        [Column("complaint_mgnt")]
        public bool? ComplaintMgnt { get; set; }
        [Column("complaint_manage_user")]
        public bool? ComplaintManageUser { get; set; }
        [Column("complaint_user_add")]
        public bool? ComplaintUserAdd { get; set; }
        [Column("complaint_user_taken")]
        public bool? ComplaintUserTaken { get; set; }
        [Column("complaint_user_solved")]
        public bool? ComplaintUserSolved { get; set; }
        [Column("complaint_manage_driver")]
        public bool? ComplaintManageDriver { get; set; }
        [Column("complaint_driver_add")]
        public bool? ComplaintDriverAdd { get; set; }
        [Column("complaint_driver_taken")]
        public bool? ComplaintDriverTaken { get; set; }
        [Column("complaint_driver_solved")]
        public bool? ComplaintDriverSolved { get; set; }
        [Column("reports_mgnt")]
        public bool? ReportsMgnt { get; set; }
        [Column("reports_user")]
        public bool? ReportsUser { get; set; }
        [Column("reports_blocked_user")]
        public bool? ReportsBlockedUser { get; set; }
        [Column("reports_driver")]
        public bool? ReportsDriver { get; set; }
        [Column("reports_blocked_driver")]
        public bool? ReportsBlockedDriver { get; set; }
        [Column("reports_finance")]
        public bool? ReportsFinance { get; set; }
        [Column("reports_business")]
        public bool? ReportsBusiness { get; set; }
        [Column("reports_travel")]
        public bool? ReportsTravel { get; set; }
        [Column("reports_rating")]
        public bool? ReportsRating { get; set; }
        [Column("reports_ledger")]
        public bool? ReportsLedger { get; set; }
        [Column("manage_settings_mgnt")]
        public bool? ManageSettingsMgnt { get; set; }
        [Column("manage_settings")]
        public bool? ManageSettings { get; set; }
        [Column("manage_settings_trip")]
        public bool? ManageSettingsTrip { get; set; }
        [Column("manage_settings_wallet")]
        public bool? ManageSettingsWallet { get; set; }
        [Column("manage_settings_installation")]
        public bool? ManageSettingsInstallation { get; set; }
        [Column("manage_settings_general")]
        public bool? ManageSettingsGeneral { get; set; }
        [Column("manage_FAQ_mgnt")]
        public bool? ManageFaqMgnt { get; set; }
        [Column("manage_FAQ")]
        public bool? ManageFaq { get; set; }
        [Column("manage_FAQ_add")]
        public bool? ManageFaqAdd { get; set; }
        [Column("manage_FAQ_edit")]
        public bool? ManageFaqEdit { get; set; }
        [Column("manage_FAQ_delete")]
        public bool? ManageFaqDelete { get; set; }
        [Column("manage_FAQ_active")]
        public bool? ManageFaqActive { get; set; }
        [Column("manage_FAQ_inactive")]
        public bool? ManageFaqInactive { get; set; }
        [Column("manage_map_mgnt")]
        public bool? ManageMapMgnt { get; set; }
        [Column("manage_map")]
        public bool? ManageMap { get; set; }
        [Column("manage_map_view")]
        public bool? ManageMapView { get; set; }
        [Column("manage_heat_map")]
        public bool? ManageHeatMap { get; set; }
        [Column("roleid")]
        public long? Roleid { get; set; }
        [Column("createdby")]
        [StringLength(400)]
        public string Createdby { get; set; }
        [Column("createdat", TypeName = "datetime")]
        public DateTime? Createdat { get; set; }
        [Column("updatedby")]
        [StringLength(400)]
        public string Updatedby { get; set; }
        [Column("updatedat", TypeName = "datetime")]
        public DateTime? Updatedat { get; set; }

        [ForeignKey(nameof(Roleid))]
        [InverseProperty(nameof(TabRoles.SetPrivilege))]
        public virtual TabRoles Role { get; set; }
    }
}
