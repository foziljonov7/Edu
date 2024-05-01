using Edu.DAL.DTOs.PaymentDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetPaymentsAsync(CancellationToken cancellation = default);
    Task<ServiceResponse> GetPaymentAsync(long id, CancellationToken cancellation = default);
    Task<ServiceResponse> PostPaymentForCourse(PaymentForCourseDto dto, CancellationToken cancellationToken = default);
}
