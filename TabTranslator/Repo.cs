using System;
using System.Text.Json.Serialization;

namespace TabTranslator
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

