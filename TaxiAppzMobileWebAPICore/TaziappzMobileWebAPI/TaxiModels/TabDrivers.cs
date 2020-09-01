using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_Drivers")]
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
            TabRequestRating = new HashSet<TabRequestRating>();
        }

        [Key]
        public long Driverid { get; set; }
        [Required]
        [StringLength(300)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(15)]
        public string ContactNo { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(500)]
        public string Driverregno { get; set; }
        [StringLength(1000)]
        public string Address { get; set; }
        [StringLength(200)]
        public string City { get; set; }
        [StringLength(200)]
        public string State { get; set; }
        [Column("countryid")]
        public long? Countryid { get; set; }
        [Column("NationalID")]
        [StringLength(100)]
        public string NationalId { get; set; }
        [Column("servicelocid")]
        public long? Servicelocid { get; set; }
        [Column("company")]
        [StringLength(100)]
        public string Company { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("typeid")]
        public long? Typeid { get; set; }
        [Column("carmodel")]
        [StringLength(100)]
        public string Carmodel { get; set; }
        [Column("carcolor")]
        [StringLength(50)]
        public string Carcolor { get; set; }
        [Column("carnumber")]
        [StringLength(20)]
        public string Carnumber { get; set; }
        [Column("carmanufacturer")]
        [StringLength(100)]
        public string Carmanufacturer { get; set; }
        [Column("caryear")]
        public int? Caryear { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("created_by")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
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
        [Column("Reward_point")]
        public long? RewardPoint { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("token")]
        [StringLength(500)]
        public string Token { get; set; }
        [Column("token_expiry", TypeName = "datetime")]
        public DateTime? TokenExpiry { get; set; }
        [Column("device_token")]
        [StringLength(400)]
        public string DeviceToken { get; set; }
        [Column("login_by")]
        [StringLength(200)]
        public string LoginBy { get; set; }
        [Column("login_method")]
        [StringLength(200)]
        public string LoginMethod { get; set; }
        [Column("isApproved")]
        public bool? IsApproved { get; set; }
        [Column("isAvailable")]
        public bool? IsAvailable { get; set; }
        [Column("Online_Status")]
        public bool? OnlineStatus { get; set; }
        public double? Rating { get; set; }
        public long? NoofRating { get; set; }
        [Column("Avg_Rating")]
        public double? AvgRating { get; set; }

        [ForeignKey(nameof(Countryid))]
        [InverseProperty(nameof(TabCountry.TabDrivers))]
        public virtual TabCountry Country { get; set; }
        [ForeignKey(nameof(Servicelocid))]
        [InverseProperty(nameof(TabServicelocation.TabDrivers))]
        public virtual TabServicelocation Serviceloc { get; set; }
        [ForeignKey(nameof(Typeid))]
        [InverseProperty(nameof(TabTypes.TabDrivers))]
        public virtual TabTypes Type { get; set; }
        [ForeignKey(nameof(Zoneid))]
        [InverseProperty(nameof(TabZone.TabDrivers))]
        public virtual TabZone Zone { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabCancellationFeeForDriver> TabCancellationFeeForDriver { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabDriverBonus> TabDriverBonus { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabDriverDocuments> TabDriverDocuments { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabDriverFine> TabDriverFine { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabDriverWallet> TabDriverWallet { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabRequest> TabRequest { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
        [InverseProperty("Driver")]
        public virtual ICollection<TabRequestRating> TabRequestRating { get; set; }
    }
}
