using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Employee.Core.DomainObjects
{
    public abstract class Validation
    {
        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public void AddCustomValidationResult(string message)
        {
            var list = new List<ValidationFailure>();
            list.Add(new ValidationFailure("Afd", message));

            ValidationResult = new ValidationResult(list.AsEnumerable());
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
