namespace Edu.Domain.Models;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(60)]
    public string FirstName { get; set; }
    [Required, MaxLength(60)]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public string Address { get; set; }
    public Collection<Course> Courses { get; set; }
}

