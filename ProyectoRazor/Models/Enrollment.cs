using System.ComponentModel.DataAnnotations;

namespace ProyectoRazor.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [StringLength(2)]
        public string Grade { get; set; }
    }
}