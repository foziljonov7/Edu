using Edu.DAL.DTOs.SubjectDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.SubjectValidators;

public class SubjectForUpdateValidator : AbstractValidator<SubjectForUpdateDto>
{
    public SubjectForUpdateValidator()
    {
        RuleFor(dto => dto.Name)
            .NotNull().WithMessage("Name must be not null");

        RuleFor(dto => dto.CategoryId)
            .NotEmpty().WithMessage("CategoryId must be not empty");
    }
}
