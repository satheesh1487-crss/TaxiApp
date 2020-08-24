using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabUser
    {
        public TabUser()
        {
            TabRequest = new HashSet<TabRequest>();
            TabRequestMeta = new HashSet<TabRequestMeta>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long? Countryid { get; set; }
        public long? Timezoneid { get; set; }
        public long? Currencyid { get; set; }
        public string ProfilePic { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public string DeviceToken { get; set; }
        public string LoginBy { get; set; }
        public string LoginMethod { get; set; }
        public int? IsIosProduction { get; set; }
        public string SocialUniqueId { get; set; }
        public int? IfDispatch { get; set; }
        public int? CorporateAdminId { get; set; }
        public int? IfCorporateUser { get; set; }
        public int? CorporateAdminReference { get; set; }
        public string OtpVerificationCode { get; set; }
        public DateTime? OtpVerificationValidationTime { get; set; }
        public int? CancellationContinuousSkip { get; set; }
        public int? CancellationContinuousSkipNotified { get; set; }
        public int? ContinuousCancellationBlock { get; set; }
        public bool? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual TabCommonCurrency Currency { get; set; }
        public virtual TabTimezone Timezone { get; set; }
        public virtual ICollection<TabRequest> TabRequest { get; set; }
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
    }
}
