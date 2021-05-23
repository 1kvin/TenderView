using System;
using System.Text.Json.Serialization;

namespace TenderView.Trades.TradeDocuments
{
    public class TradeDocument
    {
        [JsonInclude] [JsonPropertyName("Id")]
        public string id { get; private set; }
        [JsonInclude] [JsonPropertyName("UploadDate")]
        public DateTime uploadDate { get; private set; }
        [JsonInclude] [JsonPropertyName("FileName")]
        public string fileName { get; private set; }
        [JsonInclude] [JsonPropertyName("Url")]
        public string url { get; private set; }
        [JsonInclude] [JsonPropertyName("UserFileNameFromOuterSystem")]
        public string userFileNameFromOuterSystem { get; private set; }
        [JsonInclude] [JsonPropertyName("Type")]
        public string type { get; private set; }
    }
}