using System.ComponentModel.DataAnnotations;

namespace TaskManagement_01.Models
{
    public class updateTaskDto
    {
        [Key]
        public int TaskId { get; set; } // Primary key

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Priority { get; set; }

        [MaxLength(255)]
        public string Assignee { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
