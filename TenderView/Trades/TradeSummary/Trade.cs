using System;
using System.Text.Json.Serialization;

namespace TenderView.Trades.TradeSummary
{
    public class Trade
    {
        [JsonInclude] 
        [JsonPropertyName("Id")] 
        public long id { get; private set; }

        [JsonInclude]
        [JsonPropertyName("TradeState")]
        public int tradeState { get; private set; }

        [JsonInclude]
        [JsonPropertyName("TradeStateName")]
        public string tradeStateName { get; private set; }

        [JsonInclude]
        [JsonPropertyName("CustomerFullName")]
        public string customerFullName { get; private set; }

        [JsonInclude]
        [JsonPropertyName("TradeName")]
        public string tradeName { get; private set; }

        [JsonInclude]
        [JsonPropertyName("InitialPrice")]
        public decimal initialPrice { get; private set; }

        [JsonInclude]
        [JsonPropertyName("FillingApplicationEndDate")]
        public DateTime fillingApplicationEndDate { get; private set; }

        [JsonInclude]
        [JsonPropertyName("PublicationDate")]
        public DateTime publicationDate { get; private set; }

        [JsonInclude]
        [JsonPropertyName("OrganizationId")]
        public long organizationId { get; private set; }

        [JsonInclude]
        [JsonPropertyName("SourcePlatform")]
        public long sourcePlatform { get; private set; }

        [JsonInclude]
        [JsonPropertyName("SourcePlatformName")]
        public string sourcePlatformName { get; private set; }
    }
}