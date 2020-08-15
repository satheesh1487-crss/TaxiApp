using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tbl_errorlog")]
    public partial class TblErrorlog
    {
        [Key]
        [Column("int")]
        public long Int { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("created_by")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(500)]
        public string FunctionName { get; set; }
    }
}
