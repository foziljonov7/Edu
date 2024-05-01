using Edu.DAL.DTOs.CourseDTOs;
using FluentValidation;

namespace Edu.API.Helpers.Validators.CourseValidators;

public class CourseForUpdateValidator : AbstractValidator<CourseForUpdateDto>
{
	public CourseForUpdateValidator()
	{
		RuleFor(dto => dto.SubjectId)
			.NotEmpty().WithMessage("SubjectId not empty");

		RuleFor(dto => dto.TeacherId)
			.NotEmpty().WithMessage("TeacherId not empty");

		RuleFor(dto => dto.Price)
			.NotEmpty().WithMessage("Price not empty")
			.GreaterThan(0).WithMessage("Price must be greater than 0.");

		RuleFor(dto => dto.StartingDate)
			.Must(BeValidDate).WithMessage("StartingDate must be a valid date");
	}

	private bool BeValidDate(DateTimeOffset date)
		=> date != default(DateTimeOffset);
}
