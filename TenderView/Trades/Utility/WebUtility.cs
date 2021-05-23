using System.IO;
using System.Net;
using System.Text;

namespace TenderView.Trades.Utility
{
    public static class WebUtility
    {
        public static string ParseResponseToString(WebResponse webResponse)
        {
            if (webResponse is not HttpWebResponse response)
                throw new WebException("Cast exception");

            using var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}