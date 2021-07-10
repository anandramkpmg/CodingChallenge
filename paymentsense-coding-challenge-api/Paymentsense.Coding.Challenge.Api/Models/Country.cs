using System.Text.Json.Serialization;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Country
    {        
        [JsonPropertyName("name")] public string Name { get; set; }        
        [JsonPropertyName("capital")] public string Capital { get; set; }        
        [JsonPropertyName("flag")] public string Flag { get; set; }
        //Details
        [JsonPropertyName("currencies")] public Currency[] Currencies { get; set; }
        [JsonPropertyName("population")] public int Population { get; set; }
        [JsonPropertyName("timezones")] public string[] Timezones { get; set; }
        [JsonPropertyName("borders")] public string[] Borders { get; set; }
        [JsonPropertyName("languages")] public Language[] Languages { get; set; }
    }

    public class Currency
    {
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
    }

    public class Language
    {
        [JsonPropertyName("iso639_1")] public string Iso6391 { get; set; }
        [JsonPropertyName("iso639_2")] public string Iso6392 { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("nativeName")] public string NativeName { get; set; }
    }
}
