using Edu.DAL.DTOs.RegistryDTOs;
using FluentValidation;
using System.Data;

namespace Edu.API.Helpers.Validators.RegistryValidators;

public class RegistryForPostValidator : AbstractValidator<RegistryForPostDto>
{
    public RegistryForPostValidator()
    {
        RuleFor(dto => dto.Debit)
            .NotEmpty().WithMessage("Debit must be not empty")
            .GreaterThan(-1).WithMessage("Debit must be greator -1.");

        RuleFor(dto => dto.Credit)
            .NotEmpty().WithMessage("Credit must be not empty")
            .GreaterThan(-1).WithMessage("Create must be greator -1.");
    }
}
