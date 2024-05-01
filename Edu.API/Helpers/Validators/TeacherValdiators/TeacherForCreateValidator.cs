using Edu.DAL.DTOs.TeacherDTOs;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Edu.API.Helpers.Validators.TeacherValdiators;

public class TeacherForCreateValidator : AbstractValidator<TeacherForCreateDto>
{
	public TeacherForCreateValidator()
	{
		RuleFor(dto => dto.FirstName)
			.NotNull().WithMessage("Firstname must be not null");

		RuleFor(dto => dto.LastName)
			.NotNull().WithMessage("Lastname must be not null");

		RuleFor(dto => dto.PhoneNumber)
			.NotEmpty().WithMessage("PhoneNumber must be not empty");

		RuleFor(dto => dto.Skills)
			.NotNull().WithMessage("Skills must be not null");

		RuleFor(dto => dto.BirthDate)
			.Must(BeValidDate).WithMessage("BirthDate must be a valid date");

		RuleFor(dto => dto.Address)
			.NotNull().WithMessage("Address must be not null");

		RuleFor(dto => dto.Salary)
			.NotEmpty().WithMessage("Salary must be not empty")
			.GreaterThan(0).WithMessage("Salary must be greater than 0.");
	}

	private bool BeValidDate(DateTimeOffset? nullable)
		=> nullable != default(DateTimeOffset);
}

