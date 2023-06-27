using AngleSharp.Css;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TAF_TMS_C1onl.Models
{
    [Table("Cases")]
    public record Case
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("section_id")]
        public int SectionId { get; set; }

        [Column("title")]
        [JsonPropertyName("title")] public string? Title { get; set; }
    }
}
