using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace FinanceScrapper
{
    class Token
    {
        public static CookieCollection CookieCollectionData { get; set; }
        public static string Crumb { get; set; }

        private static readonly Regex CrumbRegex = new Regex(
            "(?<=\"crumb\": \")(.*)(?=\\\"\\,)",
            RegexOptions.CultureInvariant | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

        public static bool Refresh(string firstUrl = "https://fc.yahoo.com/")
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(firstUrl);
                request.CookieContainer = new CookieContainer();
                request.UserAgent = "Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
                request.Method = "GET";
                request.AllowAutoRedirect = true;

                if (CookieCollectionData?.Count > 0)
                {
                    CookieCollectionData.ToList().ForEach(cookie => request.CookieContainer.Add(cookie));
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var crumbData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(crumbData))
                    {
                        Crumb = crumbData;
                        return true;
                    }
                }
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message); // First time might throw exception
                if (we.Response is HttpWebResponse response)
                {
                    CookieCollectionData = response.Cookies;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
