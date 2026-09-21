using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApiProject.DTOs
{
    public class CreateStudentDTO
    {
        public string? FullName { get; set; }
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
    }
}
