using FluentValidation;

namespace Employee.Domain.Entities.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.PIS)
            .NotEmpty()
            .WithMessage("O PIS é obrigatório.");

            RuleFor(employee => employee.Description)
            .NotEmpty()
            .WithMessage("A descrição é obrigatória.");
        }
    }
}
