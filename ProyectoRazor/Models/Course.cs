using System.ComponentModel.DataAnnotations;

namespace ProyectoRazor.Models
{
    public class Course
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El título del curso es requerido")]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Los créditos son requeridos")]
        [Range(1, 12, ErrorMessage = "Los créditos deben estar entre 1 y 12")]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
