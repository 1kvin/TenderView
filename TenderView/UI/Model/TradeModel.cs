using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TenderView.Trades.TradeDetail;
using TenderView.Trades.TradeDocuments;
using TenderView.Trades.TradeSummary;

namespace TenderView.UI.Model
{
    public class TradeModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Trade trade;
        private TradeDocument selectedTradeDocument;
        private TradeDetail tradeDetail;
        
        public ObservableCollection<TradeDocument> TradeDocuments  { get; }
        public Trade Trade
        {
            get => trade;
            set
            {
                trade = value;
                OnPropertyChanged(nameof(Trade));
            }
        }
        
        public TradeDetail TradeDetail
        {
            get => tradeDetail;
            set
            {
                tradeDetail = value;
                OnPropertyChanged(nameof(TradeDetail));
            }
        }
        
        public TradeDocument SelectedTradeDocument
        {
            get => selectedTradeDocument;
            set
            {
                selectedTradeDocument = value;
                OnPropertyChanged(nameof(SelectedTradeDocument));
            }
        }

        public TradeModel(Trade trade, List<TradeDocument> documents, TradeDetail tradeDetail)
        {
            Trade = trade;
            TradeDocuments = new ObservableCollection<TradeDocument>(documents);
            TradeDetail = tradeDetail;
        }
        
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}