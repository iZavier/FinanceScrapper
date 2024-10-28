using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceScrapper.Models
{
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
}
