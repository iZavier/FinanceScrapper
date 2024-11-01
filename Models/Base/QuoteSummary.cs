﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceScrapper.Models.Base
{
    public class QuoteSummary
    {
        [JsonPropertyName("result")]
        public List<Result>? Result { get; set; }

        [JsonPropertyName("error")]
        public object? Error { get; set; }
    }
}
