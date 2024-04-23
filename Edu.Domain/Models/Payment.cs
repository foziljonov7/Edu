using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    [Required]
    public int RegistryId { get; set; }
    public Registry Registry { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
}

