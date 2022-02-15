using Git.Services.Contracts;
using Git.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Git.Services
{
    public class ValidationService : IValidationService
    {
        public (bool isValid, ErrorViewModel error) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errors, true);

            if (isValid)
            {
                return (isValid, null);
            }

            var error = new ErrorViewModel();
            var errorsResult = errors.Select(x=>x.ErrorMessage).ToList();
            error.Errors.AddRange(errorsResult);

            return (isValid, error);
        }
    }
}
