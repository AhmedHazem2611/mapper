using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.Models
{
    public class Subject
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
        [JsonIgnore]
        public Teacher? Teacher { get; set; }
        [JsonIgnore]
        public List<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
    }
}
