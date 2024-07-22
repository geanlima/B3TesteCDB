using System.Text.Json.Serialization;

namespace CDBCalculator.Domain.Entities;

public class InvestmentResult
{
    [JsonPropertyName("ValorBruto")]
    public decimal GrossResult { get; set; }

    [JsonPropertyName("ValorLiquido")]
    public decimal NetResult { get; set; }

    [JsonPropertyName("Result")]
    public string Result { get; set; } = string.Empty;
}
