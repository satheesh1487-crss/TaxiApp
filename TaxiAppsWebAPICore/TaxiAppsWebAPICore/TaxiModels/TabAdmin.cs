using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_admin")]
    public partial class TabAdmin
    {
        public TabAdmin()
        {
            TabAdminDetails = new HashSet<TabAdminDetails>();
            TabRefreshtoken = new HashSet<TabRefreshtoken>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("admin_key")]
        [StringLength(200)]
        public string AdminKey { get; set; }
        [Column("admin_reference")]
        public int? AdminReference { get; set; }
        [Column("area_name")]
        public long? AreaName { get; set; }
        [Column("language")]
        public int? Language { get; set; }
        [Column("firstname")]
        [StringLength(200)]
        public string Firstname { get; set; }
        [Column("lastname")]
        [StringLength(200)]
        public string Lastname { get; set; }
        [Column("registration_code")]
        [StringLength(255)]
        public string RegistrationCode { get; set; }
        [Column("email")]
        [StringLength(191)]
        public string Email { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("phone_number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Column("emergency_number")]
        [StringLength(20)]
        public string EmergencyNumber { get; set; }
        [Column("remember_token")]
        [StringLength(2000)]
        public string RememberToken { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
        [Column("is_active")]
        public int? IsActive { get; set; }
        [Column("role")]
        public long? Role { get; set; }
        [Column("profile_pic")]
        [StringLength(100)]
        public string ProfilePic { get; set; }
        [Column("zone_access")]
        public long? ZoneAccess { get; set; }
        [Column("created_by")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        [Column("deleted_by")]
        [StringLength(200)]
        public string DeletedBy { get; set; }

        [ForeignKey(nameof(AreaName))]
        [InverseProperty(nameof(TabServicelocation.TabAdmin))]
        public virtual TabServicelocation AreaNameNavigation { get; set; }
        [ForeignKey(nameof(Language))]
        [InverseProperty(nameof(TabCommonLanguages.TabAdmin))]
        public virtual TabCommonLanguages LanguageNavigation { get; set; }
        [ForeignKey(nameof(Role))]
        [InverseProperty(nameof(TabRoles.TabAdmin))]
        public virtual TabRoles RoleNavigation { get; set; }
        [ForeignKey(nameof(ZoneAccess))]
        [InverseProperty(nameof(TabTimezone.TabAdmin))]
        public virtual TabTimezone ZoneAccess1 { get; set; }
        [ForeignKey(nameof(ZoneAccess))]
        [InverseProperty(nameof(TabCountry.TabAdmin))]
        public virtual TabCountry ZoneAccessNavigation { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<TabAdminDetails> TabAdminDetails { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TabRefreshtoken> TabRefreshtoken { get; set; }
    }
}
