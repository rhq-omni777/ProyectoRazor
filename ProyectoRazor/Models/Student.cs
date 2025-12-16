using System.ComponentModel.DataAnnotations;

namespace ProyectoRazor.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "La fecha de inscripción es requerida")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
