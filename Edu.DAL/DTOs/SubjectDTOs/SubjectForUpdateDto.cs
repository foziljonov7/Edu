using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.SubjectDTOs;

public class SubjectForUpdateDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
}
