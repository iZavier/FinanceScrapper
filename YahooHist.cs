using System.Text.Json;
using System.Text.Json.Serialization;

namespace History
{
    public class YahooHist
    {
        public ChartData chartData;
        public YahooHist(string json)
        {
            chartData = JsonSerializer.Deserialize<ChartData>(json);
        }

    }

    public class ChartData
    {
        public Chart chart { get; set; }
    }

    public class Chart
    {
        public Result[] result { get; set; }
        public Error? error { get; set; }
    }

    public class Result
    {
        public Meta meta { get; set; }

        [JsonConverter(typeof(UnixTimestampArrayToDateArrayConverter))]
        public DateTime[] timestamp { get; set; }

        public Events? events { get; set; }
        public Indicators indicators { get; set; }
    }

    public class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string fullExchangeName { get; set; }
        public string instrumentType { get; set; }

        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime firstTradeDate { get; set; }
        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime regularMarketTime { get; set; }
        public bool hasPrePostMarketData { get; set; }
        public int gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public double regularMarketPrice { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double regularMarketDayHigh { get; set; }
        public double regularMarketDayLow { get; set; }
        public long regularMarketVolume { get; set; }
        public string longName { get; set; }
        public string shortName { get; set; }
        public double chartPreviousClose { get; set; }
        public int priceHint { get; set; }
        public CurrentTradingPeriod currentTradingPeriod { get; set; }
        public string dataGranularity { get; set; }
        public string? range { get; set; }
        public string[] validRanges { get; set; }
    }

    public class CurrentTradingPeriod
    {
        public TradingPeriod pre { get; set; }
        public TradingPeriod regular { get; set; }
        public TradingPeriod post { get; set; }
    }

    public class TradingPeriod
    {
        public string timezone { get; set; }

        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime end { get; set; }
        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime start { get; set; }
        public int gmtoffset { get; set; }
    }

    public class Events
    {
        [JsonConverter(typeof(UnixTimestampDictionaryConverter<Dividends>))]
        public Dictionary<DateTime, Dividends> dividends { get; set; }
        [JsonConverter(typeof(UnixTimestampDictionaryConverter<Splits>))]
        public Dictionary<DateTime, Splits> splits { get; set; }
    }
    public class Dividends
    {
        public double amount { get; set; }
        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime date { get; set; }
    }

    public class Splits
    {
        [JsonConverter(typeof(UnixTimestampToDateConverter))]
        public DateTime date { get; set; }
        public double numerator { get; set; }
        public double denominator { get; set; }
        public string splitRatio { get; set; }
    }

    public class Indicators
    {
        public Quote[] quote { get; set; }
        public AdjClose[] adjclose { get; set; }
    }

    public class Quote
    {
        public double[] close { get; set; }
        public double[] open { get; set; }
        public long[] volume { get; set; }
        public double[] low { get; set; }
        public double[] high { get; set; }
    }

    public class AdjClose
    {
        public double[] adjclose { get; set; }
    }

    public class Error
    {
        public string? code { get; set; }
        public string? description { get; set; }
    }


    public class UnixTimestampToDateConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long unixTimestamp))
            {
                return UnixEpoch.AddSeconds(unixTimestamp).ToLocalTime();
            }

            throw new JsonException("Invalid Unix timestamp format.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTimestamp = ((DateTimeOffset)value.ToUniversalTime()).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTimestamp);
        }
    }

    public class UnixTimestampArrayToDateArrayConverter : JsonConverter<DateTime[]>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override DateTime[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var timestamps = new List<DateTime>();

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long unixTimestamp))
                    {
                        timestamps.Add(UnixEpoch.AddSeconds(unixTimestamp).ToLocalTime());
                    }
                    else
                    {
                        throw new JsonException("Invalid Unix timestamp in array.");
                    }
                }

                return timestamps.ToArray();
            }

            throw new JsonException("Expected an array of Unix timestamps.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var dateTime in value)
            {
                long unixTimestamp = ((DateTimeOffset)dateTime.ToUniversalTime()).ToUnixTimeSeconds();
                writer.WriteNumberValue(unixTimestamp);
            }
            writer.WriteEndArray();
        }
    }


    public class UnixTimestampDictionaryConverter<TValue> : JsonConverter<Dictionary<DateTime, TValue>>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override Dictionary<DateTime, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected a JSON object for the dictionary.");

            var dictionary = new Dictionary<DateTime, TValue>();

            // Read each property in the object
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                // Read the key (which is a long Unix timestamp as string)
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string keyString = reader.GetString();
                    if (long.TryParse(keyString, out long unixTimestamp))
                    {
                        DateTime dateKey = UnixEpoch.AddSeconds(unixTimestamp).ToLocalTime();

                        // Read the value associated with the key
                        reader.Read();

                        // Deserialize the value part of the dictionary (TValue)
                        TValue value = JsonSerializer.Deserialize<TValue>(ref reader, options);

                        // Add the date and value to the dictionary
                        dictionary.Add(dateKey, value);
                    }
                    else
                    {
                        throw new JsonException($"Invalid Unix timestamp: {keyString}");
                    }
                }
            }

            return dictionary;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<DateTime, TValue> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var kvp in value)
            {
                // Convert DateTime back to Unix timestamp for the key
                long unixTimestamp = ((DateTimeOffset)kvp.Key.ToUniversalTime()).ToUnixTimeSeconds();
                writer.WritePropertyName(unixTimestamp.ToString());

                // Serialize the value part of the dictionary
                JsonSerializer.Serialize(writer, kvp.Value, options);
            }

            writer.WriteEndObject();
        }
    }


}

