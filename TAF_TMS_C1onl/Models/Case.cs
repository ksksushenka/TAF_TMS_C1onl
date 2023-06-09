using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TAF_TMS_C1onl.Models
{
    public class Case
    {
        [JsonPropertyName("section_id")] public int SectionId { get; set; } 
        [JsonPropertyName("title")] public string Title { get; set; } 
    }
}
