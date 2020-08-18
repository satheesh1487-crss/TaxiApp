using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_user")]
    public partial class TabUser
    {
        public TabUser()
        {
            TabRequest = new HashSet<TabRequest>();
            TabRequestMeta = new HashSet<TabRequestMeta>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("firstname")]
        [StringLength(250)]
        public string Firstname { get; set; }
        [Column("lastname")]
        [StringLength(191)]
        public string Lastname { get; set; }
        [Column("email")]
        [StringLength(191)]
        public string Email { get; set; }
        [Column("phone_number")]
        [StringLength(191)]
        public string PhoneNumber { get; set; }
        [Column("password")]
        [StringLength(191)]
        public string Password { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("address")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column("city")]
        [StringLength(150)]
        public string City { get; set; }
        [Column("state")]
        [StringLength(150)]
        public string State { get; set; }
        [Column("countryid")]
        public long? Countryid { get; set; }
        [Column("timezoneid")]
        public long? Timezoneid { get; set; }
        [Column("currencyid")]
        public long? Currencyid { get; set; }
        [Column("profile_pic")]
        [StringLength(191)]
        public string ProfilePic { get; set; }
        [Column("token")]
        [StringLength(500)]
        public string Token { get; set; }
        [Column("token_expiry", TypeName = "datetime")]
        public DateTime? TokenExpiry { get; set; }
        [Column("device_token")]
        [StringLength(191)]
        public string DeviceToken { get; set; }
        [Column("login_by")]
        [StringLength(191)]
        public string LoginBy { get; set; }
        [Column("login_method")]
        [StringLength(191)]
        public string LoginMethod { get; set; }
        [Column("is_ios_production")]
        public int? IsIosProduction { get; set; }
        [Column("social_unique_id")]
        [StringLength(191)]
        public string SocialUniqueId { get; set; }
        [Column("if_dispatch")]
        public int? IfDispatch { get; set; }
        [Column("corporate_admin_id")]
        public int? CorporateAdminId { get; set; }
        [Column("if_corporate_user")]
        public int? IfCorporateUser { get; set; }
        [Column("corporate_admin_reference")]
        public int? CorporateAdminReference { get; set; }
        [Column("otp_verification_code")]
        [StringLength(191)]
        public string OtpVerificationCode { get; set; }
        [Column("otp_verification_validation_time", TypeName = "datetime")]
        public DateTime? OtpVerificationValidationTime { get; set; }
        [Column("cancellation_continuous_skip")]
        public int? CancellationContinuousSkip { get; set; }
        [Column("cancellation_continuous_skip_notified")]
        public int? CancellationContinuousSkipNotified { get; set; }
        [Column("continuous_cancellation_block")]
        public int? ContinuousCancellationBlock { get; set; }
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public int? IsDelete { get; set; }
        [Column("created_By")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(200)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Countryid))]
        [InverseProperty(nameof(TabCountry.TabUser))]
        public virtual TabCountry Country { get; set; }
        [ForeignKey(nameof(Currencyid))]
        [InverseProperty(nameof(TabCommonCurrency.TabUser))]
        public virtual TabCommonCurrency Currency { get; set; }
        [ForeignKey(nameof(Timezoneid))]
        [InverseProperty(nameof(TabTimezone.TabUser))]
        public virtual TabTimezone Timezone { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TabRequest> TabRequest { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
    }
}
