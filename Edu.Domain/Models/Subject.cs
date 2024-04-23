using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Subject
{
    [Key]
    public int Id { get; set; }
    [Required, MinLength(3), MaxLength(150)]
    public string Name { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
