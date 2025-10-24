using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ScheduleRequestDto
    {
        [Required]
        public List<TaskScheduleDto> Tasks { get; set; } = new List<TaskScheduleDto>();
    }

    public class TaskScheduleDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Estimated hours must be greater than 0")]
        public double EstimatedHours { get; set; }
        
        [Required]
        public string DueDate { get; set; } = string.Empty;
        
        public List<string> Dependencies { get; set; } = new List<string>();
    }
}
