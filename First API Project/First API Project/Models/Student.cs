using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
        [ForeignKey("ClassRoom")]
        public int ClassRoomId { get; set; }
        [JsonIgnore]
        public Classroom? Classroom { get; set; }
        [JsonIgnore]
        public List<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
    }
}
