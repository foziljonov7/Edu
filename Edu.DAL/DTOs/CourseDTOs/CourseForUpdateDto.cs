using Edu.Domain.Models;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.CourseDTOs;

public class CourseForUpdateDto
{
    [JsonPropertyName("subject_id")]
    public int SubjectId { get; set; }
    [JsonPropertyName("teacher_id")]
    public int TeacherId { get; set; }
    [JsonPropertyName("starting_date")]
    public DateTimeOffset StartingDate { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}
