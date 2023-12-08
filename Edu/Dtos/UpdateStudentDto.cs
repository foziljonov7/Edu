namespace Edu.Dtos
{
    public class UpdateStudentDto
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CourseId { get; set; }
    }
}
