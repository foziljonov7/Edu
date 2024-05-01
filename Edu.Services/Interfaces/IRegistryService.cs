using Edu.DAL.DTOs.RegistryDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface IRegistryService
{
    Task<ServiceResponse> PostRegistryAsync(RegistryForPostDto dto, CancellationToken cancellation = default);
}
