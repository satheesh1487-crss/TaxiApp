using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_uploadfiledetails")]
    public partial class TabUploadfiledetails
    {
        [Key]
        [Column("fileid")]
        public long Fileid { get; set; }
        [Required]
        [Column("filename")]
        [StringLength(300)]
        public string Filename { get; set; }
        [Required]
        [Column("mimetype")]
        [StringLength(100)]
        public string Mimetype { get; set; }
        [Column("size")]
        public long? Size { get; set; }
        [Required]
        [Column("extention")]
        [StringLength(200)]
        public string Extention { get; set; }
        [Column("Created_By")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_By")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_By")]
        [StringLength(200)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
    }
}
