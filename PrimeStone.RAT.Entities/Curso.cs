using System.ComponentModel.DataAnnotations;

namespace PrimeStone.RAT.Entities
{
    public class Curso : ClassBase
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del curso es requerido.")]
        public string CourseName { get; set; }
    }
}
