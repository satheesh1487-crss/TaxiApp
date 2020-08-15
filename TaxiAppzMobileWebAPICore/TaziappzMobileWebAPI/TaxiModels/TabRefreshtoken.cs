using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_refreshtoken")]
    public partial class TabRefreshtoken
    {
        [Key]
        [Column("reftokenid")]
        public long Reftokenid { get; set; }
        [Column("userid")]
        public long? Userid { get; set; }
        [Column("refreshtoken")]
        [StringLength(500)]
        public string Refreshtoken { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(TabAdmin.TabRefreshtoken))]
        public virtual TabAdmin User { get; set; }
    }
}
