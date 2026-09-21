using System.ComponentModel.DataAnnotations;

namespace FirstApiProject.DTOs
{
    public class CreateDepartmentDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
