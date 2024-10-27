using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace quoteType
{
    public class QuoteTypeResponse
    {
        [JsonPropertyName("quoteType")]
        public QuoteType QuoteType { get; set; }
    }

    public class QuoteType
    {
        [JsonPropertyName("result")]
        public Result[] Result { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; } // Use appropriate type if you expect a specific structure
    }

    public class Result
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("quoteType")]
        public string QuoteType { get; set; }

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
        public string GmtOffSetMilliseconds { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("isEsgPopulated")]
        public bool IsEsgPopulated { get; set; }

        [JsonPropertyName("hasSelerityEarnings")]
        public bool HasSelerityEarnings { get; set; }
    }
}
