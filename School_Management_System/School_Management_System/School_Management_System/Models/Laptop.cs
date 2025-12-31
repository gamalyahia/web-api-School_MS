using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "model is required"), MaxLength(100)]
        public string model { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
