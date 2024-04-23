namespace Edu.Domain.Models;

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public decimal Salary { get; set; }
}

