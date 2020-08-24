using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDrivers
    {
        public TabDrivers()
        {
            TabCancellationFeeForDriver = new HashSet<TabCancellationFeeForDriver>();
            TabDriverBonus = new HashSet<TabDriverBonus>();
            TabDriverDocuments = new HashSet<TabDriverDocuments>();
            TabDriverFine = new HashSet<TabDriverFine>();
            TabDriverWallet = new HashSet<TabDriverWallet>();
            TabRequest = new HashSet<TabRequest>();
            TabRequestMeta = new HashSet<TabRequestMeta>();
        }

        public long Driverid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string Driverregno { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long? Countryid { get; set; }
        public string NationalId { get; set; }
        public long? Servicelocid { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public long? Typeid { get; set; }
        public string Carmodel { get; set; }
        public string Carcolor { get; set; }
        public string Carnumber { get; set; }
        public string Carmanufacturer { get; set; }
        public int? Caryear { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? RewardPoint { get; set; }
        public long? Zoneid { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public string DeviceToken { get; set; }
        public string LoginBy { get; set; }
        public string LoginMethod { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? OnlineStatus { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual TabServicelocation Serviceloc { get; set; }
        public virtual TabTypes Type { get; set; }
        public virtual TabZone Zone { get; set; }
        public virtual ICollection<TabCancellationFeeForDriver> TabCancellationFeeForDriver { get; set; }
        public virtual ICollection<TabDriverBonus> TabDriverBonus { get; set; }
        public virtual ICollection<TabDriverDocuments> TabDriverDocuments { get; set; }
        public virtual ICollection<TabDriverFine> TabDriverFine { get; set; }
        public virtual ICollection<TabDriverWallet> TabDriverWallet { get; set; }
        public virtual ICollection<TabRequest> TabRequest { get; set; }
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
    }
}
