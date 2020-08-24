using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverWallet
    {
        public long Driverwalletid { get; set; }
        public long? Driverid { get; set; }
        public long? Transactionid { get; set; }
        public long? Currencyid { get; set; }
        public double? Walletamount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Deletedby { get; set; }
        public DateTime? Deletedat { get; set; }

        public virtual TabCommonCurrency Currency { get; set; }
        public virtual TabDrivers Driver { get; set; }
    }
}
