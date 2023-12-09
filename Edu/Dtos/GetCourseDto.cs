using Edu.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Edu.Dtos
{
    public class GetCourseDto
    {
        public GetCourseDto(Course entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Price = entity.Price;
            StartTime = entity.StartTime;
            Time = entity.Time;
            IsActive = entity.IsActive;
            Description = entity.Description;
            ImageName = entity.ImageName;
            ImageData = entity.ImageData;
            TeacherId = entity.TeacherId;
            CategoryId = entity.CategoryId;
            Teacher = entity.Teacher;
            Category = entity.Category;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public string Time { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public Guid TeacherId { get; set; }
        public int CategoryId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Category Category { get; set; }
    }
}
