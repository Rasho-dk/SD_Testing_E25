using System.Text.Json.Serialization;

namespace MeasureConverterLib.Services;

public class CurrencyInfo
{
    [JsonPropertyName("code")]
    public required string Code { get; set; }
    [JsonPropertyName("value")]

    public double Value { get; init; }
}