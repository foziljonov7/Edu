using Edu.Data;
using Edu.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Edu.Validators
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MinimumLength(2).WithMessage("Name minimum 2 characters")
                .MaximumLength(50).WithMessage("Name maximal 50 characters");
            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Price should be greater than 0");
            RuleFor(dto => dto.Time)
                .NotEmpty().WithMessage("Time should not be empty")
                .MinimumLength(5).WithMessage("Time minimum 5 characters")
                .MaximumLength(10).WithMessage("Time maximal 10 characters");
            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description should not be empty")
                .MaximumLength(500).WithMessage("Description maximal 500 characters");
            RuleFor(dto => dto.ImageName)
                .NotNull().WithMessage("Image name cannot be null!");
            RuleFor(dto => dto.TeacherId)
                .NotEmpty().WithMessage("TeacherId must not be empty");
            RuleFor(dto => dto.CategoryId)
                .NotNull().WithMessage("Category ID must not be null")
                .GreaterThan(0).WithMessage("Category ID should be greater than 0");
        }
    }
}
