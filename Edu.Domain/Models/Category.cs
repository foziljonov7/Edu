using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required, MinLength(3)]
    public string Name { get; set; }
}
