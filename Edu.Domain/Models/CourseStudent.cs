using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edu.Domain.Models;

public class CourseStudent
{
    [Key]
    public long Id { get; set; }
    [ForeignKey("CourseId")]
    public long CourseId { get; set; }
    public Course Course { get; set; }
    [ForeignKey("StudentId")]
    public long StudentId { get; set; }
    public Student Student { get; set; }
}
