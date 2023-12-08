using Edu.Entities;

namespace Edu.Dtos
{
    public class GetStudentDto
    {
        public GetStudentDto(Student entity)
        {
            Id = entity.Id;
            Fullname = entity.Fullname;
            Age = entity.Age;
            PhoneNumber = entity.PhoneNumber;
            CourseId = entity.CourseId;
        }

        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CourseId { get; set; }
    }
}
