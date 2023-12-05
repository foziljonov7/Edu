using System.ComponentModel.Design;

namespace Edu.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public string Time { get; set; }
        public bool IsActive => StartTime <= DateTime.UtcNow;
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageName { get; set; }
        public Guid TeacherId { get; set; }
        public int CategoryId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Category Category { get; set; }
    }
}
