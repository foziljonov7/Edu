namespace Edu.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
