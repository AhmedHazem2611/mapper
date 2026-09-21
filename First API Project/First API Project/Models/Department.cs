using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstApiProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]  
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [JsonIgnore]
        public List<Teacher>? Teachers { get; set; } = new List<Teacher>();


    }
}
