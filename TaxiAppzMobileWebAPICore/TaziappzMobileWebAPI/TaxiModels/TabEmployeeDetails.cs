using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_employee_details")]
    public partial class TabEmployeeDetails
    {
        [Key]
        [Column("empid")]
        public int Empid { get; set; }
        [Column("emp_firstname")]
        [StringLength(400)]
        public string EmpFirstname { get; set; }
        [Column("emp_lastname")]
        [StringLength(400)]
        public string EmpLastname { get; set; }
        [Column("emp_emailid")]
        [StringLength(100)]
        public string EmpEmailid { get; set; }
        [Column("emp_contactno")]
        public long? EmpContactno { get; set; }
        [Column("emp_dob", TypeName = "datetime")]
        public DateTime? EmpDob { get; set; }
        [Column("emp_age")]
        public int? EmpAge { get; set; }
        [Column("emp_isactive")]
        public bool? EmpIsactive { get; set; }
        [Column("emp_createdby")]
        [StringLength(100)]
        public string EmpCreatedby { get; set; }
        [Column("emp_createddate", TypeName = "datetime")]
        public DateTime? EmpCreateddate { get; set; }
        [Column("emp_updatedby")]
        [StringLength(100)]
        public string EmpUpdatedby { get; set; }
        [Column("emp_updatedate", TypeName = "datetime")]
        public DateTime? EmpUpdatedate { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
