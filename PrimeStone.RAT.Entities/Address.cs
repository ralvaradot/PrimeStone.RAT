using System.ComponentModel.DataAnnotations;

namespace PrimeStone.RAT.Entities
{
    public class Address : ClassBase
    {
        public int AddressId { get; set; }
        [Display(Name ="Calle ")]
        [MaxLength(5)]
        [Required(AllowEmptyStrings = true)]
        public string Calle { get; set; }
        [Display(Name = "Kra. ")]
        [MaxLength(5)]
        [Required(AllowEmptyStrings =true)]
        public string Carrera { get; set; }
        [Display(Name = "Numero  ")]
        [MaxLength(15)]
        [Required(ErrorMessage ="El numero del domicilio es obligatorio")]
        public string Numero { get; set; }
        [Display(Name = "Datos Adicionales ")]
        [MaxLength(50)]
        public string Adicional { get; set; }
        [Display(Name = "Activa ")]
        public bool AddressActive { get; set; }
    }
}
