using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTO
{
    public class ReadTeacherDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        public string? phone { get; set; }
        public string SubjectName{ get; set; }
    }
}
