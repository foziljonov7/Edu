using Edu.DAL.DTOs.RegistryDTOs;

namespace Edu.Services.Interfaces;

public interface IRegistryService
{
    Task<IEnumerable<RegistryDTO>> GetRegistrysAsync(CancellationToken cancellationToken = default);
    Task<RegistryDTO> GetRegistryAsync(int id, CancellationToken cancellationToken = default);
}
