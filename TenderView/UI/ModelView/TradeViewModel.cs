using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AsyncAwaitBestPractices.MVVM;
using TenderView.UI.Command;
using TenderView.UI.Model;

namespace TenderView.UI.ModelView
{
    public class TradeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long inputTradeId;
        private TradeModel selectedTrade;
        public IAsyncCommand<long> AddTrade { get; }
        public OpenFileInBrowserCommand OpenFileInBrowser { get; }
        public ObservableCollection<TradeModel> Trades { get; }

        public long InputTradeId
        {
            get => inputTradeId;
            set
            {
                inputTradeId = value;
                OnPropertyChanged(nameof(InputTradeId));
            }
        }

        public TradeModel SelectedTrade
        {
            get => selectedTrade;
            set
            {
                selectedTrade = value;
                OnPropertyChanged(nameof(SelectedTrade));
            }
        }

        public TradeViewModel()
        {
            Trades = new ObservableCollection<TradeModel>();
            AddTrade = new AsyncCommand<long>((id) => AddTradeCommand.ExecuteAsync(Trades, id));
            OpenFileInBrowser = new OpenFileInBrowserCommand();
            InputTradeId = 1763197; //Default trade id
        }
        
        public void NumberValidator(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}