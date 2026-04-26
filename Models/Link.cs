using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MYAPI.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string URL { get; set; } = string.Empty;
        public int InterestId { get; set; }
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person Person { get; set; } = null!;
        [JsonIgnore]
        public Interest Interest { get; set; }
    }
}
