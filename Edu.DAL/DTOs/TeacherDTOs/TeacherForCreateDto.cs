using Edu.Domain.Models;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.TeacherDTOs;

public class TeacherForCreateDto
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("birth_date")]
    public DateTimeOffset? BirthDate { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("skills")]
    public string[] Skills { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("salary")]
    public decimal Salary { get; set; }
}
