namespace Edu.Domain.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
