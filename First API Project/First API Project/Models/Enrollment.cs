using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
        [Required]
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Grade { get; set; }

    }
}
