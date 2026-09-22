using FirstApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApiProject.DTOs
{
    public class StudentDTO
    {
        [Key]
        public int Id { get; set; }
        public string ?FullName { get; set; }
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("ClassRoom")]
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
    }
}
