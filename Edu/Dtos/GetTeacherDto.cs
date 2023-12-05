using Edu.Entities;

namespace Edu.Dtos
{
    public class GetTeacherDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
    }
}
