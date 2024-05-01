using Edu.DAL.DTOs.PaymentDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.PaymentValidators;

public class PaymentForCourseValidator : AbstractValidator<PaymentForCourseDto>
{
    public PaymentForCourseValidator()
    {
        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage("StudentId must be not empty");

        RuleFor(dto => dto.CourseId)
            .NotEmpty().WithMessage("CourseId must be not empty");

        RuleFor(dto => dto.RegistryId)
            .NotEmpty().WithMessage("RegistryId must be not empty");

        RuleFor(dto => dto.Amount)
            .NotEmpty().WithMessage("Amount must be not empty")
            .GreaterThan(0).WithMessage("Amount must be greater 0.");
    }
}
