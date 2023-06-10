using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TAF_TMS_C1onl.Models
{
    public class Milestone
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("start_on")] public int StartOn { get; set; }
    }
}
