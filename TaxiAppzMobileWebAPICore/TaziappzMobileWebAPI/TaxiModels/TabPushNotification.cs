using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_push_notification")]
    public partial class TabPushNotification
    {
        [Key]
        [Column("pushnotificationid")]
        public long Pushnotificationid { get; set; }
        [Required]
        [Column("messagetitle")]
        [StringLength(200)]
        public string Messagetitle { get; set; }
        [Required]
        [Column("messagesubtitle")]
        [StringLength(200)]
        public string Messagesubtitle { get; set; }
        [Column("HasRedirectURL")]
        public bool? HasRedirectUrl { get; set; }
        [StringLength(600)]
        public string MessageDescription { get; set; }
        [Column("Upload_FileName")]
        [StringLength(300)]
        public string UploadFileName { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }
        [Column("Created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Deleted_By")]
        [StringLength(300)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
    }
}
