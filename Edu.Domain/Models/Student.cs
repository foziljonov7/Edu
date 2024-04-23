namespace Edu.Domain.Models;

using System;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public string Address { get; set; }
}

