using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.SubjectDTOs;

public class SubjectDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
}
