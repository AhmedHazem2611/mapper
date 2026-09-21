using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace FirstApiProject.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1,12)]
        public int GradeLevel { get; set; }
        [Required]
        [Range(1,100)]
        public int Capacity { get; set; }
        [JsonIgnore]
        public List<Student>? Students { get; set; } = new List<Student>();
    }
}
