using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTO
{
    public class CreateSubjectDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
