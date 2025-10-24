using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ProjectCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
