using Edu.DAL.DTOs.CategoryDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.CategoryValidators;

public class CategoryForCreateValidator : AbstractValidator<CategoryForCreateDto>
{
    public CategoryForCreateValidator()
    {
        RuleFor(dto => dto.Name)
            .NotNull().WithMessage("Name must be not null");
    }
}
