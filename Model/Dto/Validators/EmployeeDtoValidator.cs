using System;
using FluentValidation;
namespace EmloyeePortal.Model.Dto.Validators
{
	public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
	{
		public EmployeeDtoValidator()
		{
            RuleFor(x => x.Id).NotEmpty().WithMessage("IEmployee d is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").WithMessage("Name must be between 1 and 100 characters");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past");
            RuleFor(x => x.Designation).NotEmpty();
            RuleFor(x => x.Salary).GreaterThanOrEqualTo(0).WithMessage("Salary must be a non-negative number");
            RuleFor(x => x.Status).NotNull().WithMessage("Status is required");
        }
	
	}
}

