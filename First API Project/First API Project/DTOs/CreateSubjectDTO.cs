using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApiProject.DTOs
{
    public class CreateSubjectDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(1, 100)]
        public int MaxGrade { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
    }
}
