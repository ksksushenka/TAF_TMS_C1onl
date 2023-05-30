using System.Text.Json.Serialization;

namespace TAF_TMS_C1onl.Models;

public class Group
{
    [JsonPropertyName("id")] public int Id { get; set; }
}