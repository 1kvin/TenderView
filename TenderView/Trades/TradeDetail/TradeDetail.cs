using System.Collections.Generic;

namespace TenderView.Trades.TradeDetail
{
    public class TradeDetail
    {
        public TradeDetail(string deliveryAddress, List<PurchaseObject> purchaseObjects)
        {
            this.deliveryAddress = deliveryAddress;
            this.purchaseObjects = purchaseObjects;
        }
        public string deliveryAddress { get; private set; }
        public List<PurchaseObject> purchaseObjects { get; private set; }
    }
}