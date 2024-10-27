using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace quoteSummary
{
    public class QuoteSummaryResponse
    {
        [JsonPropertyName("quoteSummary")]
        public QuoteSummary? QuoteSummary { get; set; }
    }

    public class QuoteSummary
    {
        [JsonPropertyName("result")]
        public List<Result>? Result { get; set; }

        [JsonPropertyName("error")]
        public object? Error { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("earnings")]
        public Earnings? Earnings { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("quoteType")]
        public QuoteType? QuoteType { get; set; }
    }

    public class QuoteType
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("quoteType")]
        public string quoteType { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("longName")]
        public string LongName { get; set; }

        [JsonPropertyName("messageBoardId")]
        public string MessageBoardId { get; set; }

        [JsonPropertyName("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonPropertyName("exchangeTimezoneShortName")]
        public string ExchangeTimezoneShortName { get; set; }

        [JsonPropertyName("gmtOffSetMilliseconds")]
        public int GmtOffSetMilliseconds { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("isEsgPopulated")]
        public bool IsEsgPopulated { get; set; }

        [JsonPropertyName("hasSelerityEarnings")]
        public bool HasSelerityEarnings { get; set; }
    }

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
        public List<EarningsDate>? EarningsDate { get; set; }

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
        public RevenueEarnings? Revenue { get; set; }

        [JsonPropertyName("earnings")]
        public RevenueEarnings? Earnings { get; set; }
    }

    public class QuarterlyFinancial
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("revenue")]
        public RevenueEarnings? Revenue { get; set; }

        [JsonPropertyName("earnings")]
        public RevenueEarnings? Earnings { get; set; }
    }

    public class EarningsDate
    {
        [JsonPropertyName("raw")]
        public long? Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string? Fmt { get; set; }
    }

    public class ValueFormat
    {
        [JsonPropertyName("raw")]
        public double? Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string? Fmt { get; set; }
    }

    public class RevenueEarnings
    {
        [JsonPropertyName("raw")]
        public long? Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string? Fmt { get; set; }

        [JsonPropertyName("longFmt")]
        public string?   LongFmt { get; set; }
    }

    public class Price
    {
        [JsonPropertyName("maxAge")]
        public int? MaxAge { get; set; }

        [JsonPropertyName("preMarketChange")]
        public ValueFormat? PreMarketChange { get; set; }

        [JsonPropertyName("preMarketPrice")]
        public ValueFormat? PreMarketPrice { get; set; }

        [JsonPropertyName("preMarketSource")]
        public string? PreMarketSource { get; set; }

        [JsonPropertyName("postMarketChangePercent")]
        public ValueFormat? PostMarketChangePercent { get; set; }

        [JsonPropertyName("postMarketChange")]
        public ValueFormat? PostMarketChange { get; set; }

        [JsonPropertyName("postMarketTime")]
        public long? PostMarketTime { get; set; }

        [JsonPropertyName("postMarketPrice")]
        public ValueFormat? PostMarketPrice { get; set; }

        [JsonPropertyName("postMarketSource")]
        public string? PostMarketSource { get; set; }

        [JsonPropertyName("regularMarketChangePercent")]
        public ValueFormat? RegularMarketChangePercent { get; set; }

        [JsonPropertyName("regularMarketChange")]
        public ValueFormat? RegularMarketChange { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public long? RegularMarketTime { get; set; }

        [JsonPropertyName("priceHint")]
        public ValueFormat? PriceHint { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public ValueFormat? RegularMarketPrice { get; set; }

        [JsonPropertyName("regularMarketDayHigh")]
        public ValueFormat? RegularMarketDayHigh { get; set; }

        [JsonPropertyName("regularMarketDayLow")]
        public ValueFormat? RegularMarketDayLow { get; set; }

        [JsonPropertyName("regularMarketVolume")]   
        public RevenueEarnings? RegularMarketVolume { get; set; }

        [JsonPropertyName("averageDailyVolume10Day")]
        public ValueFormat? AverageDailyVolume10Day { get; set; }

        [JsonPropertyName("averageDailyVolume3Month")]
        public ValueFormat? AverageDailyVolume3Month { get; set; }

        [JsonPropertyName("regularMarketPreviousClose")]
        public ValueFormat? RegularMarketPreviousClose { get; set; }

        [JsonPropertyName("regularMarketSource")]
        public string? RegularMarketSource { get; set; }

        [JsonPropertyName("regularMarketOpen")]
        public ValueFormat? RegularMarketOpen { get; set; }

        [JsonPropertyName("strikePrice")]
        public ValueFormat? StrikePrice { get; set; }

        [JsonPropertyName("openInterest")]
        public ValueFormat? OpenInterest { get; set; }

        [JsonPropertyName("exchange")]
        public string? Exchange { get; set; }

        [JsonPropertyName("exchangeName")]
        public string? ExchangeName { get; set; }

        [JsonPropertyName("exchangeDataDelayedBy")]
        public int? ExchangeDataDelayedBy { get; set; }

        [JsonPropertyName("marketState")]
        public string? MarketState { get; set; }

        [JsonPropertyName("quoteType")]
        public string? QuoteType { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("underlyingSymbol")]
        public object? UnderlyingSymbol { get; set; }

        [JsonPropertyName("shortName")]
        public string? ShortName { get; set; }

        [JsonPropertyName("longName")]
        public string? LongName { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("quoteSourceName")]
        public string? QuoteSourceName { get; set; }

        [JsonPropertyName("currencySymbol")]
        public string? CurrencySymbol { get; set; }

        [JsonPropertyName("fromCurrency")]
        public string? FromCurrency { get; set; }

        [JsonPropertyName("toCurrency")]
        public object? ToCurrency { get; set; }

        [JsonPropertyName("lastMarket")]
        public object? LastMarket { get; set; }

        [JsonPropertyName("volume24Hr")]
        public object? Volume24Hr { get; set; }

        [JsonPropertyName("volumeAllCurrencies")]
        public object? VolumeAllCurrencies { get; set; }

        [JsonPropertyName("circulatingSupply")]
        public object? CirculatingSupply { get; set; }

        [JsonPropertyName("marketCap")]
        public RevenueEarnings? MarketCap { get; set; }
    }
}
