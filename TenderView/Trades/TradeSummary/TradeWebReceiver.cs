using System.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;

namespace TenderView.Trades.TradeSummary
{
    public static class TradeWebReceiver
    {
        public static TradeWebResponse Get(long tradeId, long page = 1, int itemsPerPage = 10)
        {
            var tradesRequest = new TradeWebRequest(tradeId, page, itemsPerPage);
            var jsonRequest = JsonSerializer.Serialize(tradesRequest);
            var webRequest = CreateWebRequest(jsonRequest);
            var response = webRequest.GetResponse();
            var responseString = Utility.WebUtility.ParseResponseToString(response);
            return JsonSerializer.Deserialize<TradeWebResponse>(responseString);
        }

        private static WebRequest CreateWebRequest(string json)
        {
            var request = WebRequest.Create(GetUrl());
            request.ContentType = "application/json";
            request.Method = "POST";

            using var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);

            return request;
        }

        private static string GetUrl()
        {
            var url = ConfigurationManager.AppSettings["GetTradesURL"];
            if (string.IsNullOrEmpty(url))
                throw new WebException("Configuration string null or empty");
            return url;
        }
    }
}