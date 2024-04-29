using Edu.DAL.DTOs.PaymentDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetPaymentsAsync();
    Task<PaymentDto> GetPaymentAsync(int id);
    //Task<ServiceResponse> GetPaymentForCourse(PaymentForCourseDto dto, CancellationToken cancellationToken = default);
}
