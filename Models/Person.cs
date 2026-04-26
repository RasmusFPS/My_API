using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MYAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Phone_Number {get; set;}
        [JsonIgnore]
        public ICollection<Link> Links { get; set; } = null!;
    }
}
