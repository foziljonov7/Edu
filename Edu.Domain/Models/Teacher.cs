using Edu.Domain.Helpers.Commons;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Teacher : Auditable
{
    [Required, MaxLength(60)]
    public string FirstName { get; set; }
    [Required, MaxLength(60)]
    public string LastName { get; set; }
    [Required]
    public DateTimeOffset? BirthDate { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string[] Skills { get; set; }
    public string Address { get; set; }
    public decimal Salary { get; set; }
    public Collection<Course> Courses { get; set; }
}

