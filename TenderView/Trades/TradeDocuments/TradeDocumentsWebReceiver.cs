using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text.Json;

namespace TenderView.Trades.TradeDocuments
{
    public static class TradeDocumentsWebReceiver
    {
        public static List<TradeDocument> Get(long tradeId)
        {
            var webRequest = CreateWebRequest(tradeId);
            var response = webRequest.GetResponse();
            var responseString = Utility.WebUtility.ParseResponseToString(response);
            return JsonSerializer.Deserialize<List<TradeDocument>>(responseString);
        }

        private static WebRequest CreateWebRequest(long tradeId)
        {
            var url = ConfigureAndGetUrl(tradeId);
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            return request;
        }

        private static string ConfigureAndGetUrl(long tradeId)
        {
            var url = ConfigurationManager.AppSettings["GetTradesDocuments"];
            if (string.IsNullOrEmpty(url))
                throw new WebException("Configuration string null or empty");

            return url.Replace("%tradeId%", tradeId.ToString());
        }
    }
}