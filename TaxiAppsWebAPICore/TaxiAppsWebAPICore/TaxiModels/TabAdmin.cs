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
        [StringLength(150)]
        public string AreaName { get; set; }
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
        [StringLength(600)]
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

        [ForeignKey(nameof(Language))]
        [InverseProperty(nameof(TabCommonLanguages.TabAdmin))]
        public virtual TabCommonLanguages LanguageNavigation { get; set; }
        [ForeignKey(nameof(Role))]
        [InverseProperty(nameof(TabRoles.TabAdmin))]
        public virtual TabRoles RoleNavigation { get; set; }
        [ForeignKey(nameof(ZoneAccess))]
        [InverseProperty(nameof(TabCountry.TabAdmin))]
        public virtual TabCountry ZoneAccessNavigation { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<TabAdminDetails> TabAdminDetails { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TabRefreshtoken> TabRefreshtoken { get; set; }
    }
}
