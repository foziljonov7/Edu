using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.RegistryDTOs;

public class RegistryDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("debit")]
    public decimal Debit { get; set; }
    [JsonPropertyName("credit")]
    public decimal Credit { get; set; }
}
