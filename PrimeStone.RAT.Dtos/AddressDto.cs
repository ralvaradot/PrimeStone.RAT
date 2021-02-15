namespace PrimeStone.RAT.Dtos
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Calle { get; set; }
        public string Carrera { get; set; }
        public string Numero { get; set; }
        public string Adicional { get; set; }
        public bool AddressActive { get; set; }
    }
}
