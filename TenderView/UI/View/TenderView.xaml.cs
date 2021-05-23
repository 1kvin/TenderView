using System.Windows;
using TenderView.UI.ModelView;

namespace TenderView.UI.View
{
    public partial class TenderView : Window
    {
        public TenderView()
        {
            InitializeComponent();
            DataContext = new TradeViewModel();
        }
    }
}