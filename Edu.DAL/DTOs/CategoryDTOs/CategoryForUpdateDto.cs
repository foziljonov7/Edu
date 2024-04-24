using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.CategoryDTOs;

public class CategoryForUpdateDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
