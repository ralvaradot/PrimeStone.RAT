using System.ComponentModel.DataAnnotations;

namespace PrimeStone.RAT.Entities
{
    public class Student : ClassBase
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="El nombre del estudiante es requerido.")]
        public string StudentName { get; set; }
    }
}
