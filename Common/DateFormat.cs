using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceScrapper.Common
{
    public class DateFormat
    {
        [JsonPropertyName("raw")]
        public long? Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string? Fmt { get; set; }
    }
}
