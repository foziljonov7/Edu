using AutoMapper;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class PaymentService(IRepository<Payment> repository, IMapper mapper) : IPaymentService
{
    public async Task<PaymentDto> GetPaymentAsync(int id)
    {
        var payment = await repository.SelectAsync(x => x.Id == id);

        if (payment is null)
            throw new NullReferenceException("Null reference");

        var mapped = mapper.Map<PaymentDto>(payment);

        return mapped;
    }

    public async Task<IEnumerable<PaymentDto>> GetPaymentsAsync()
    {
        var payments = await repository.SelectAllAsync();

        if (payments is null)
            throw new NullReferenceException("Null reference");

        var mapped = mapper.Map<IEnumerable<PaymentDto>>(payments);
        return mapped;
    }
}
