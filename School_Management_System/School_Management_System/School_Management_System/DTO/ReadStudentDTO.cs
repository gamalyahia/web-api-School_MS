using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTO
{
    public class ReadStudentDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        public ICollection<ReadTeacherDTO> Teachers { get; set; }
        public string LaptopModel { get; set; }

       
    }
}
