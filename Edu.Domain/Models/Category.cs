using Edu.Domain.Helpers.Commons;
using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Category : Auditable
{
    [Required, MinLength(3)]
    public string Name { get; set; }
}
