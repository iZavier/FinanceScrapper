using FinanceScrapper.Common;
using System.Text.Json.Serialization;

namespace FinanceScrapper.Models
{
    public class Earnings
    {
        [JsonPropertyName("maxAge")]
        public int? MaxAge { get; set; }

        [JsonPropertyName("earningsChart")]
        public EarningsChart? EarningsChart { get; set; }

        [JsonPropertyName("financialsChart")]
        public FinancialsChart? FinancialsChart { get; set; }

        [JsonPropertyName("financialCurrency")]
        public string? FinancialCurrency { get; set; }
    }

    public class EarningsChart
    {
        [JsonPropertyName("quarterly")]
        public List<QuarterlyEarnings>? Quarterly { get; set; }

        [JsonPropertyName("currentQuarterEstimate")]
        public ValueFormat? CurrentQuarterEstimate { get; set; }

        [JsonPropertyName("currentQuarterEstimateDate")]
        public string? CurrentQuarterEstimateDate { get; set; }

        [JsonPropertyName("currentQuarterEstimateYear")]
        public int? CurrentQuarterEstimateYear { get; set; }

        [JsonPropertyName("earningsDate")]
        public List<DateFormat>? EarningsDate { get; set; }

        [JsonPropertyName("isEarningsDateEstimate")]
        public bool? IsEarningsDateEstimate { get; set; }
    }

    public class FinancialsChart
    {
        [JsonPropertyName("yearly")]
        public List<YearlyFinancial>? Yearly { get; set; }

        [JsonPropertyName("quarterly")]
        public List<QuarterlyFinancial>? Quarterly { get; set; }
    }

    public class QuarterlyEarnings
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("actual")]
        public ValueFormat? Actual { get; set; }

        [JsonPropertyName("estimate")]
        public ValueFormat? Estimate { get; set; }
    }

    public class YearlyFinancial
    {
        [JsonPropertyName("date")]
        public int? Date { get; set; }

        [JsonPropertyName("revenue")]
        public LongValueFormat? Revenue { get; set; }

        [JsonPropertyName("earnings")]
        public LongValueFormat? Earnings { get; set; }
    }

    public class QuarterlyFinancial
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("revenue")]
        public LongValueFormat? Revenue { get; set; }

        [JsonPropertyName("earnings")]
        public LongValueFormat? Earnings { get; set; }
    }
}
