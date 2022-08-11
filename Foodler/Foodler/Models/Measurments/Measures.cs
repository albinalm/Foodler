using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodler.Models.Measurments
{
    public class Measures
    {
        [JsonProperty("us")]
        public MeasureImperial MeasureImperial { get; set; }

        [JsonProperty("metric")]
        public MeasureMetric MeasureMetric { get; set; }
    }
}
