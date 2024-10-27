using History;
using quoteSummary;
using quoteType;
using System.Net;
using System.Text;
using System.Text.Json;

namespace FinanceScrapper
{
    public class YahooFinance
    {
        private CookieCollection _cookies;
        private string crumb;

        public void Initialise()
        {
            Token.Refresh();
            Token.Refresh("https://query2.finance.yahoo.com/v1/test/getcrumb");
            if (Token.CookieCollectionData != null)
            {
                _cookies = Token.CookieCollectionData;
            }
            if (Token.Crumb != null)
            {
                crumb = Token.Crumb;
            }
        }

        private string readWebPage(string url)
        {
            string data = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
                request.CookieContainer = new CookieContainer();
                if (_cookies != null)
                {
                    _cookies.ToList().ForEach(cookie => request.CookieContainer.Add(cookie));

                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read webpage " + url + " Error: " + ex.ToString());
            }
            return data;
        }


        public YahooHist? GetAllHistoricalYahooData(string ticker)
        {
            long unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string res = readWebPage("https://query1.finance.yahoo.com/v8/finance/chart/"+ticker+ "?events=capitalGain|div|split&formatted=true&includeAdjustedClose=true&interval=1d&period1=0&period2=" + unixTimestamp+"&symbol="+ticker+"&userYfid=true&lang=en-GB&region=GB");
            YahooHist yh = new YahooHist(res);
            if (validateDeserialiseData(yh))
            {
                return yh;
            }
            return null;
        }

        public YahooHist? GetHistoricalYahooDataBetweenDates(string ticker, DateTime startDate, DateTime? endDate)
        {
            long startDateunix = ((DateTimeOffset)startDate).ToUnixTimeSeconds();
            long endDateunix = endDate != null ? ((DateTimeOffset)endDate).ToUnixTimeSeconds() : DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string res = readWebPage("https://query1.finance.yahoo.com/v8/finance/chart/" + ticker + "?events=capitalGain|div|split&formatted=true&includeAdjustedClose=true&interval=1d&period1=" + startDateunix+"&period2="+endDateunix+"&symbol=" + ticker + "&userYfid=true&lang=en-GB&region=GB");
            YahooHist yh = new YahooHist(res);
            if (validateDeserialiseData(yh))
            {
                return yh;
            }

            return null;
        }

        public QuoteTypeResponse GetQuoteType(string ticker)
        {
            string res = readWebPage("https://query2.finance.yahoo.com/v1/finance/quoteType/?symbol="+ticker+"&lang=en-GB&region=GB");
            QuoteTypeResponse summary = JsonSerializer.Deserialize<QuoteTypeResponse>(res);

            return summary;
        }

        public QuoteSummaryResponse GetQuoteSummary(string ticker, string[] modules)
        {
            string res = readWebPage("https://query2.finance.yahoo.com/v10/finance/quoteSummary/"+ticker+"?modules="+string.Join(",",modules)+"&crumb="+crumb);
            QuoteSummaryResponse summary = JsonSerializer.Deserialize<QuoteSummaryResponse>(res);

            return summary;
        }


        private bool validateDeserialiseData(YahooHist yh) { 


            Chart chart = yh.chartData.chart;
            if (chart.error == null)
            {
                return true;
            } 
            if (chart.error.code == "Not Found")
            {
                return false;
                // Add Logging
            }
            if (chart.error.code == "Bad Request")
            {
                return false;
                // Add Logging
            }
            return false;

        }

     


    }
}