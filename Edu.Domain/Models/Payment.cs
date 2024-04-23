namespace Edu.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int RegistryId { get; set; }
    public Registry Registry { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
}

