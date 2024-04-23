using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    [Required]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public DateTimeOffset StartingDate { get; set; }
    [Required]
    public decimal Price { get; set; }
    public Collection<Student> Students { get; set; }
}

