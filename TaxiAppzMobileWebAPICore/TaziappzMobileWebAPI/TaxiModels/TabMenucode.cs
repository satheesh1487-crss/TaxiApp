using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_menucode")]
    public partial class TabMenucode
    {
        [Key]
        [Column("menuid")]
        public long Menuid { get; set; }
        [Required]
        [Column("menuname")]
        [StringLength(200)]
        public string Menuname { get; set; }
    }
}
