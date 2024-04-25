using Edu.Domain.Models;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.StudentDTOs;

public class StudentForUpdateDto
{
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
}
