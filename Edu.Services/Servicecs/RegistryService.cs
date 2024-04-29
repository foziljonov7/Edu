using AutoMapper;
using Edu.DAL.DTOs.RegistryDTOs;
using Edu.Domain.Models;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class RegistryService(IRepository<Registry> repository, IMapper mapper) : IRegistryService
{
	public async Task<RegistryDTO> GetRegistryAsync(int id, CancellationToken cancellationToken = default)
	{
		var registry = await repository.SelectAsync(x => x.Id == id);

		if (registry is null)
			throw new NullReferenceException("Null reference");

		var mapped = mapper.Map<RegistryDTO>(registry);
		return mapped;
	}

	public async Task<IEnumerable<RegistryDTO>> GetRegistrysAsync(CancellationToken cancellationToken = default)
	{
		var registrys = await repository.SelectAllAsync();

		if (registrys is null)
			throw new NullReferenceException("Null reference");

		var mapped = mapper.Map<IEnumerable<RegistryDTO>>(registrys);
		return mapped;
	}
}
