using AutoMapper;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class PaymentService(IRepository<Payment> repository, IMapper mapper) : IPaymentService
{
    public Task<PaymentDto> GetPaymentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> GetPaymentForCourse(PaymentForCourseDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PaymentDto>> GetPaymentsAsync()
    {
        throw new NotImplementedException();
    }
}
