using Edu.DAL.DTOs.CourseDTOs;
using Edu.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.StudentDTOs;

public class StudentDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("phone_Number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("birth_date")]
    public DateTimeOffset? BirthDate { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
	public Collection<CourseDto> Courses { get; set; }
}
