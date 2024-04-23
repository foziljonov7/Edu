namespace Edu.Domain.Models;

public class Course
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public DateTimeOffset StartingDate { get; set; }
    public decimal Price { get; set; }
}

