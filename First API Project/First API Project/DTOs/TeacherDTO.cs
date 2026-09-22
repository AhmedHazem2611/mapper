using FirstApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.DTOs
{
    public class TeacherDTO
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
        [EmailAddress]
        [MaxLength(150)]
        public string EmailAddress { get; set; }
        [MaxLength(20)]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
