using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"),MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        public string? phone { get; set; }
        public ICollection<Student> Students{ get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
