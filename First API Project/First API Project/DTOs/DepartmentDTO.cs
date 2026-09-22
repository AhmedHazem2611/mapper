using System.ComponentModel.DataAnnotations;

namespace FirstApiProject.DTOs
{
    public class DepartmentDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
