using Edu.Domain.Helpers.Commons;
using System.ComponentModel.DataAnnotations;

namespace Edu.Domain.Models;

public class Registry : Auditable
{
    [Key]
    public int Id { get; set; }
    [Required]
    public decimal Debit { get; set; }
    [Required]
    public decimal Credit { get; set; }
}
