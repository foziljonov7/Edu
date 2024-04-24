using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.CategoryDTOs;

public class CategoryDto
{

    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
