namespace Edu.Dtos
{
    public class UpdateCourseDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public Guid TeacherId { get; set; }
        public int CategoryId { get; set; }
    }
}
