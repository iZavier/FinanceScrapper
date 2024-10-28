using System.Text.Json.Serialization;

namespace FinanceScrapper.Models.Base
{
    public class Result
    {
        [JsonPropertyName("earnings")]
        public Earnings? Earnings { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("quoteType")]
        public QuoteType? QuoteType { get; set; }
    }
}
