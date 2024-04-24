using Edu.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Edu.DAL.DTOs.PaymentDTOs;

public class PaymentDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("student_id")]
    public int StudentId { get; set; }
    [JsonPropertyName("student")]
    public Student Student { get; set; }
    [JsonPropertyName("course_id")]
    public int CourseId { get; set; }
    [JsonPropertyName("course")]
    public Course Course { get; set; }
    [JsonPropertyName("registry_id")]
    public int RegistryId { get; set; }
    [JsonPropertyName("registry")]
    public Registry Registry { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    [JsonPropertyName("payment_date")]
    public DateTimeOffset PaymentDate { get; set; }
}
