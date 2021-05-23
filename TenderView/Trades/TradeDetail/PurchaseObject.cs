namespace TenderView.Trades.TradeDetail
{
    public class PurchaseObject
    {
        public PurchaseObject(string name, string unitName, decimal quantity, decimal priceForOne)
        {
            this.name = name;
            this.unitName = unitName;
            this.quantity = quantity;
            this.priceForOne = priceForOne;
        }
        public string name { get; private set; }
        public string unitName { get; private set; }
        public decimal quantity { get; private set; }
        public decimal priceForOne { get; private set; }
    }
}