using Edu.Data;
using Edu.Dtos;
using FluentValidation;

namespace Edu.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Fullname)
                .NotEmpty().WithMessage("Fullname should not be empty")
                .MinimumLength(8).WithMessage("Fullname minimum 8 characters")
                .MaximumLength(120).WithMessage("Fullname maximum 120 characters");
            RuleFor(dto => dto.Age)
                .NotNull().WithMessage("Age cannot not be null");
            RuleFor(dto => dto.PhoneNumber)
                .NotNull().WithMessage("Phone cannot not be null");
            RuleFor(dto => dto.CourseId)
                .NotNull().WithMessage("Category ID must not be null");
        }
    }
}
