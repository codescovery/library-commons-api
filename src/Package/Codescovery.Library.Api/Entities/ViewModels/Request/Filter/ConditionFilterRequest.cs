using System.Text.Json.Serialization;

namespace Codescovery.Library.Api.Entities.ViewModels.Request.Filter;

public class ConditionFilterRequest
{
    [JsonPropertyName("propertyName")] public string? PropertyName { get; set; }
    [JsonPropertyName("operator")] public string? Operator { get; set; }
    [JsonPropertyName("value")] public string? Value { get; set; }
    [JsonPropertyName("ignoreCase")] public bool? IgnoreCase { get; set; }
    [JsonPropertyName("and")] public IEnumerable<ConditionFilterRequest>? And { get; set; }
    [JsonPropertyName("or")] public IEnumerable<ConditionFilterRequest>? Or { get; set; }
}