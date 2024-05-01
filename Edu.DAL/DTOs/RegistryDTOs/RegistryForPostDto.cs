using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.RegistryDTOs;

public class RegistryForPostDto
{
	[JsonPropertyName("debit")]
	public decimal Debit { get; set; }
	[JsonPropertyName("credit")]
	public decimal Credit { get; set; }
}
