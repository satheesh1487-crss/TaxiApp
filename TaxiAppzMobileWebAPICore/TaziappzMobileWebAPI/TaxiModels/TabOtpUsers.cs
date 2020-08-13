using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_OTP_users")]
    public partial class TabOtpUsers
    {
        [Key]
        public long Userotpid { get; set; }
        [Column("User_Contact_no")]
        public long UserContactNo { get; set; }
        [Column("User_OTP")]
        public int UserOtp { get; set; }
        [Column("User_OTP_CreatedDate", TypeName = "datetime")]
        public DateTime? UserOtpCreatedDate { get; set; }
        [Column("User_OTP_ExpireDate", TypeName = "datetime")]
        public DateTime? UserOtpExpireDate { get; set; }
        [Column("User_Device_name")]
        [StringLength(200)]
        public string UserDeviceName { get; set; }
        [Column("User_Device_IPAddress")]
        [StringLength(200)]
        public string UserDeviceIpaddress { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("Created_by")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
