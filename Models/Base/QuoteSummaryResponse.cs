using System.Text.Json.Serialization;

namespace FinanceScrapper.Models.Base
{
    public class QuoteSummaryResponse
    {
        [JsonPropertyName("quoteSummary")]
        public QuoteSummary? QuoteSummary { get; set; }
    }
}
