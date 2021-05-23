using System.Text.Json.Serialization;

namespace TenderView.Trades.TradeSummary
{
    public class TradeWebRequest
    {
        public TradeWebRequest(long id, long page, int itemsPerPage)
        {
            this.id = id;
            this.page = page;
            this.itemsPerPage = itemsPerPage;
        }

        [JsonInclude] 
        [JsonPropertyName("Id")] 
        public long id { get; private set; }

        [JsonInclude]
        [JsonPropertyName("page")]
        public long page { get; private set; }

        [JsonInclude]
        [JsonPropertyName("itemsPerPage")]
        public int itemsPerPage { get; private set; }
    }
}