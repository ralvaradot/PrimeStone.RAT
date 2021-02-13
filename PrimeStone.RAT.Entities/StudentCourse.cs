namespace PrimeStone.RAT.Entities
{
    public  class StudentCourse : ClassBase
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Curso Curso { get; set; }
    }
}
