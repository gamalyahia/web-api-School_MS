using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"),MaxLength(100)]
        public string Name {get;set;}
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Laptop Laptop { get; set; }

    }
}
