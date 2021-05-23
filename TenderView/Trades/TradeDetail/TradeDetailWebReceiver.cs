using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Configuration = AngleSharp.Configuration;

namespace TenderView.Trades.TradeDetail
{
    public static class TradeDetailWebReceiver
    {
        private const string DeliveryAddressString = "Место поставки:";
        private const string PurchaseObjectNameString = "Наименование товара, работ, услуг:";
        private const string PurchaseObjectUnitNameString = "Единицы измерения:";
        private const string PurchaseObjectQuantityString = "Количество:";
        private const string PurchaseObjectPriceForOneString = "Стоимость единицы продукции ( в т.ч. НДС при наличии):";

        private const string InfoBlockSelector =
            "div.informationAboutCustomer__informationPurchase-infoBlock.infoBlock";

        private const string PurchaseObjectSelector = "div.outputResults__oneResult";

        private const string PurchaseObjectNameAndCodeAndTypeSelector =
            "div.outputResults__oneResult-leftPart.leftPart";

        private const string PurchaseObjectUnitNameAndQuantitySelector =
            "div.outputResults__oneResult-centerPart.centerPart";

        private const string PurchaseObjectPriceForOneSelector =
            "div.outputResults__oneResult-rightPart.rightPart";


        public static async Task<TradeDetail> GetAsync(long tradeId)
        {
            var url = ConfigureAndGetUrl(tradeId);
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync(url);
            var tradeDetail = new TradeDetail(ParseDeliveryAddress(document), ParsePurchaseObject(document));

            return tradeDetail;
        }

        private static string ConfigureAndGetUrl(long tradeId)
        {
            var url = ConfigurationManager.AppSettings["GetTradesDetail"];
            if (string.IsNullOrEmpty(url))
                throw new WebException("Configuration string null or empty");

            return url.Replace("%tradeId%", tradeId.ToString());
        }


        private static List<PurchaseObject> ParsePurchaseObject(IDocument document)
        {
            var cells = document.QuerySelectorAll(PurchaseObjectSelector);
            var purchaseObjects = new List<PurchaseObject>();
            foreach (var cell in cells)
            {
                var nameAndCodeAndTypeElement = cell.QuerySelector(PurchaseObjectNameAndCodeAndTypeSelector);
                var unitNameAndQuantityElement = cell.QuerySelector(PurchaseObjectUnitNameAndQuantitySelector);
                var priceForOneElement = cell.QuerySelector(PurchaseObjectPriceForOneSelector);

                var name = ParsePurchaseObjectName(nameAndCodeAndTypeElement);
                var unitName = ParsePurchaseObjectUnitName(unitNameAndQuantityElement);
                var quantity = decimal.Parse(ParsePurchaseObjectQuantity(unitNameAndQuantityElement));
                var priceForOne = decimal.Parse(ParsePurchaseObjectPriceForOne(priceForOneElement));


                name = TrimStartAndEnd(name);
                unitName = TrimStartAndEnd(unitName);

                purchaseObjects.Add(new PurchaseObject(name, unitName, quantity, priceForOne));
            }

            return purchaseObjects;
        }

        private static string TrimStartAndEnd(string text)
        {
            return text.TrimStart().TrimEnd();
        }

        private static string ParseDeliveryAddress(IDocument document)
        {
            var cells = document.QuerySelectorAll(InfoBlockSelector);

            return (from cell in cells
                where cell.Children[0].TextContent == DeliveryAddressString
                select cell.Children[1].TextContent).FirstOrDefault();
        }

        private static string ParsePurchaseObjectName(IElement element)
        {
            return (from child in element.Children
                where child.Children.Length > 0
                where child.Children[0].TextContent.Equals(PurchaseObjectNameString)
                select child.ChildNodes[2].TextContent).FirstOrDefault();
        }

        private static string ParsePurchaseObjectUnitName(IElement element)
        {
            return InnerContentFinder(element, PurchaseObjectUnitNameString);
        }

        private static string ParsePurchaseObjectQuantity(IElement element)
        {
            return InnerContentFinder(element, PurchaseObjectQuantityString);
        }

        private static string ParsePurchaseObjectPriceForOne(IElement element)
        {
            return InnerContentFinder(element, PurchaseObjectPriceForOneString);
        }

        private static string InnerContentFinder(IElement element, string nameString)
        {
            return (from child in element.Children
                where child.Children.Length > 0
                from childParag in child.Children
                where childParag.Children.Length > 0 && childParag.Children[0].TextContent.Equals(nameString)
                select childParag.ChildNodes[2].TextContent).FirstOrDefault();
        }
    }
}