using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.PaymentDTOs;

public class PaymentForCourseDto
{
    [JsonPropertyName("student_id")]
    public int StudentId { get; set; }
    [JsonPropertyName("course_id")]
    public int CourseId { get; set; }
    [JsonPropertyName("registry_id")]
    public int RegistryId { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    [JsonPropertyName("payment_date")]
    public DateTimeOffset PaymentDate { get; set; }
}
