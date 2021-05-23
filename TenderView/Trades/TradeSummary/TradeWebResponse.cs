using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TenderView.Trades.TradeSummary
{
    public class TradeWebResponse
    {
        [JsonInclude] [JsonPropertyName("totalpages")]
        public long totalPages { get; private set; }
        
        [JsonInclude] [JsonPropertyName("currpage")]
        public long currPage { get; private set; }
        
        [JsonInclude] [JsonPropertyName("totalrecords")]
        public long totalRecords { get; private set; }
        
        [JsonInclude] [JsonPropertyName("invdata")]
        public List<Trade> invData { get; private set; }
    }
}