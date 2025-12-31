using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTO
{
    public class UpdateStudentDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        public ICollection<int> TeachersIDS { get; set; }
        public string LaptopModel { get; set; }
    }
}
