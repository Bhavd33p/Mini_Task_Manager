using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
