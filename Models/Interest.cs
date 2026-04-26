using System.ComponentModel.DataAnnotations;

namespace MYAPI.Models
{
    public class Interest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; }
    }
}
