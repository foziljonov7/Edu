namespace Edu.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
