using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class GetWalletModel
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

    public class CardListModel
    {
        [JsonProperty("payment")]
        public Payment Payment { get; set; }
    }
    public class Payment
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

    public class AddWalletModel
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

    public class AddCardModel
    {
        [JsonProperty("payment")]
        public Payment Payment { get; set; }
    }
}
