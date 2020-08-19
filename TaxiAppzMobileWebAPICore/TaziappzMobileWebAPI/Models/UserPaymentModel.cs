using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserPaymentModel
    {
        [JsonProperty("preferred_payment_type")]
        public int Preferred_Payment_Type { get; set; }
    }
    public class UserAddWalletModel
    {
        [JsonProperty("amount_added")]
        public double? Amount_Added { get; set; }

        [JsonProperty("amount_balance")]
        public double? Amount_Balance { get; set; }

        [JsonProperty("amount_spent")]
        public double? Amount_Spent { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }

    public class UserAddCardModel
    {
        [JsonProperty("card_id")]
        public int Card_Id { get; set; }

        [JsonProperty("last_number")]
        public string Last_Number { get; set; }

        [JsonProperty("card_type")]
        public string Card_Type { get; set; }

        [JsonProperty("is_default")]
        public bool Is_Default { get; set; }
    }
    public class UserDeleteCardModel
    {
        [JsonProperty("payment")]
        public UserPayment Payment { get; set; }
    }
    public class UserPayment
    {

    }
}
