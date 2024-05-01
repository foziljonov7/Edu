using Edu.DAL.DTOs.CategoryDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.CategoryValidators;

public class CategoryForUpdateValdiator : AbstractValidator<CategoryForUpdateDto>
{
    public CategoryForUpdateValdiator()
    {
        RuleFor(dto => dto.Name)
            .NotNull().WithMessage("Name must be not null");
    }
}
