using FirstApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstApiProject.DTOs
{
    public class CreateClassroomDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, 12)]
        public int GradeLevel { get; set; }
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
    }
}
