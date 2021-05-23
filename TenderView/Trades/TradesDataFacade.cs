using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderView.Trades.TradeDetail;
using TenderView.Trades.TradeDocuments;
using TenderView.Trades.TradeSummary;
using TenderView.UI.Model;

namespace TenderView.Trades
{
    public static class TradesDataFacade
    {
        public static async Task<TradeModel> GetCompleteTrade(long tradeId)
        {
            var trade = GetTrade(tradeId);
            var documents = GetDocuments(tradeId);
            var detail = await GetDetail(tradeId);

            return new TradeModel(trade, documents, detail);
        }
        public static TradeSummary.Trade GetTrade(long tradeId)
        {
           return GetTradesResponse(tradeId).invData.First();
        }
        public static TradeWebResponse GetTradesResponse(long tradeId, long page = 1, int itemsPerPage = 10)
        {
            return TradeWebReceiver.Get(tradeId, page, itemsPerPage);
        }
        public static async Task<TradeDetail.TradeDetail> GetDetail(long tradeId)
        {
            return await TradeDetailWebReceiver.GetAsync(tradeId);
        }

        public static List<TradeDocument> GetDocuments(long tradeId)
        {
            return TradeDocumentsWebReceiver.Get(tradeId);
        }
    }
}