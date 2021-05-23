using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using TenderView.Trades;
using TenderView.UI.Model;

namespace TenderView.UI.Command
{
    public static class AddTradeCommand
    {
        public static async Task ExecuteAsync(ObservableCollection<TradeModel> tradeCollection, long tradeId)
        {
            try
            {
                tradeCollection.Add(await TradesDataFacade.GetCompleteTrade(tradeId));
            }
            catch 
            {
                MessageBox.Show("Ошибка добавления тендера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}