﻿using AutoMapper;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.DAL.DTOs.RegistryDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class PaymentService(
    IRepository<Payment> repository,
    IMapper mapper,
    IRegistryService registryService) : IPaymentService
{
    public async Task<ServiceResponse> GetPaymentAsync(long id, CancellationToken cancellation = default)
    {
        var payment = await repository.SelectAsync(x => x.Id == id);

        if (payment is null)
            return new ServiceResponse(false, "payment is null", null);

        var mapped = mapper.Map<PaymentDto>(payment);

        return new ServiceResponse(true, "Success", mapped);
    }

    public async Task<ServiceResponse> PostPaymentForCourse(PaymentForCourseDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var reg = new RegistryForPostDto
            {
                Credit = dto.Amount,
                Debit = 0
            };

            var registry = await registryService.PostRegistryAsync(reg);
            var mapped = mapper.Map<Payment>(dto);
            mapped.RegistryId = (registry.Data as Registry).Id;

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Success", mapped);
        }
        catch(Exception ex)
        {
            return new ServiceResponse(false, "an error occurred during payment: " + ex.Message, null);
        }
    }

    public async Task<IEnumerable<PaymentDto>> GetPaymentsAsync(CancellationToken cancellation = default)
    {
        var payments = await repository.SelectAllAsync();

        var mapped = mapper.Map<IEnumerable<PaymentDto>>(payments);

        return mapped;
    }
}
