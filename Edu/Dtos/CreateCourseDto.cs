namespace Edu.Dtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public Guid TeacherId { get; set; }
        public int CategoryId { get; set; }
    }
}
