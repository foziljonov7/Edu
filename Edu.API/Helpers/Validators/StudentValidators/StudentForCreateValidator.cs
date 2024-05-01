using Edu.DAL.DTOs.StudentDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.StudentValidators;

public class StudentForCreateValidator : AbstractValidator<StudentForCreateDto>
{
    public StudentForCreateValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotNull().WithMessage("Firstname must be not null");

        RuleFor(dto => dto.LastName)
            .NotNull().WithMessage("Lastname must be not null");

        RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber must be not empty");

        RuleFor(dto => dto.Address)
            .NotNull().WithMessage("Address must be not null");

        RuleFor(dto => dto.BirthDate)
            .Must(BeValidDate).WithMessage("Birthdate must be a valid date");
    }

    private bool BeValidDate(DateTimeOffset? date)
        => date != default(DateTimeOffset);
}
