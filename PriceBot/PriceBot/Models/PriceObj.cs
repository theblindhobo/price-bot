using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PriceBot.Models
{
    public class Source
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("proportion")]
        public string Proportion { get; set; }
    }

    public class PriceObj
    {
        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("gasPrice")]
        public string GasPrice { get; set; }

        [JsonPropertyName("gas")]
        public string Gas { get; set; }

        [JsonPropertyName("estimatedGas")]
        public string EstimatedGas { get; set; }

        [JsonPropertyName("protocolFee")]
        public string ProtocolFee { get; set; }

        [JsonPropertyName("minimumProtocolFee")]
        public string MinimumProtocolFee { get; set; }

        [JsonPropertyName("buyTokenAddress")]
        public string BuyTokenAddress { get; set; }

        [JsonPropertyName("buyAmount")]
        public string BuyAmount { get; set; }

        [JsonPropertyName("sellTokenAddress")]
        public string SellTokenAddress { get; set; }

        [JsonPropertyName("sellAmount")]
        public string SellAmount { get; set; }

        [JsonPropertyName("sources")]
        public List<Source> Sources { get; set; }

        [JsonPropertyName("allowanceTarget")]
        public string AllowanceTarget { get; set; }
    }

}
