using FirstApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.DTOs
{
    public class SubjectDTO
    {
        [Key]
        public int Id { get; set; }
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
