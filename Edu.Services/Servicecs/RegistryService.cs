using AutoMapper;
using Edu.DAL.DbContexts;
using Edu.DAL.DTOs.RegistryDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class RegistryService(IRepository<Registry> repository, IMapper mapper) : IRegistryService
{
	public async Task<ServiceResponse> PostRegistryAsync(RegistryForPostDto dto, CancellationToken cancellation = default)
	{
		var mapped = mapper.Map<Registry>(dto);
		await repository.CreatedAsync(mapped);
		await repository.SaveAsync(cancellation);

		return new ServiceResponse(true, "Success", mapped);
	}
}
