using Edu.Data;
using Edu.Dtos;
using FluentValidation;

namespace Edu.Validators
{
    public class UpdateTeacherValidator : AbstractValidator<UpdateTeacherDto>
    {
        public UpdateTeacherValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Fullname)
                .NotEmpty().WithMessage("Fullname should not be empty")
                .MinimumLength(5).WithMessage("Fullname minimum 5 characters")
                .MaximumLength(120).WithMessage("Fullname maximal 120 characters");
            RuleFor(dto => dto.Skills)
                .NotEmpty().WithMessage("Skills should bot be empty");
            RuleFor(dto => dto.PhoneNumber)
                .NotNull().WithMessage("Phone cannot not be null");
            RuleFor(dto => dto.Age)
                .GreaterThan(16).WithMessage("It is not possible to be younger than 16 years old");
        }
    }
}
