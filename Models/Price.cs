using FinanceScrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceScrapper.Models
{
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
        public LongValueFormat? RegularMarketVolume { get; set; }

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
        public LongValueFormat? MarketCap { get; set; }
    }
}
