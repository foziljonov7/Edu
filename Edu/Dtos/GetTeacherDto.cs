using Edu.Entities;

namespace Edu.Dtos
{
    public class GetTeacherDto
    {
        public GetTeacherDto(Teacher entity)
        {
            Id = entity.Id;
            Fullname = entity.Fullname;
            Age = entity.Age;
            Skills = entity.Skills;
            PhoneNumber = entity.PhoneNumber;
        }

        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
    }
}
