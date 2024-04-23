using Edu.Domain.Models;
using System.Collections.ObjectModel;

namespace Edu.DAL.DTOs.CourseDTOs;

public class CourseForCreateDto
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public DateTimeOffset StartingDate { get; set; }
    public decimal Price { get; set; }
    public Collection<Student> Students { get; set; }
}
