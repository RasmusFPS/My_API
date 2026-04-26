using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MYAPI.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string URL { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Link> Links { get; set; } = null!;

    }
}
