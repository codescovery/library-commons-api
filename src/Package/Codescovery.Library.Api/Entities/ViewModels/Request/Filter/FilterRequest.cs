using System.Text.Json.Serialization;

namespace Codescovery.Library.Api.Entities.ViewModels.Request.Filter;

public class FilterRequest
{
    [JsonPropertyName("pagination")] public PaginationFilterRequest? Pagination { get; set; }
    [JsonPropertyName("codition")] public ConditionFilterRequest? Condition { get; set; }
}