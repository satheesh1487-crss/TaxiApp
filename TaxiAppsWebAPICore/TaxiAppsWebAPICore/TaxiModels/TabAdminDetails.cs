using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_admin_details")]
    public partial class TabAdminDetails
    {
        [Key]
        [Column("admindtlsid")]
        public long Admindtlsid { get; set; }
        [Column("admin_id")]
        public long? AdminId { get; set; }
        [Column("address")]
        [StringLength(300)]
        public string Address { get; set; }
        [Column("city")]
        [StringLength(200)]
        public string City { get; set; }
        [Column("Country_id")]
        public long? CountryId { get; set; }
        [Column("postalCode")]
        public long? PostalCode { get; set; }
        [Column("timezone")]
        [StringLength(200)]
        public string Timezone { get; set; }
        [Column("document_name")]
        [StringLength(100)]
        public string DocumentName { get; set; }
        [Column("document")]
        [StringLength(200)]
        public string Document { get; set; }
        [Column("driver_document_count")]
        public int? DriverDocumentCount { get; set; }
        [Column("last_login_ip_address")]
        [StringLength(100)]
        public string LastLoginIpAddress { get; set; }
        [Column("block")]
        public int? Block { get; set; }
        [Column("login_attempt")]
        public long? LoginAttempt { get; set; }
        [Column("isActive")]
        public int? IsActive { get; set; }
        [Column("created_by")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
        [Column("updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        [Column("deleted_by")]
        [StringLength(200)]
        public string DeletedBy { get; set; }

        [ForeignKey(nameof(AdminId))]
        [InverseProperty(nameof(TabAdmin.TabAdminDetails))]
        public virtual TabAdmin Admin { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(TabCountry.TabAdminDetails))]
        public virtual TabCountry Country { get; set; }
    }
}
