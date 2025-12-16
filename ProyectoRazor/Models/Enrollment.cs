using System.ComponentModel.DataAnnotations;

namespace ProyectoRazor.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El estudiante es requerido")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required(ErrorMessage = "El curso es requerido")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required(ErrorMessage = "La calificación es requerida")]
        [StringLength(2, ErrorMessage = "La calificación no puede exceder 2 caracteres")]
        public string Grade { get; set; }
    }
}