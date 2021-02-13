namespace PrimeStone.RAT.Entities
{
    public class StudentAddress
    {
        public int StudentId { get; set; }
        public int AddressId { get; set; }
        public Student  Student { get; set; }
        public Address Address { get; set; }
    }
}
