using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
