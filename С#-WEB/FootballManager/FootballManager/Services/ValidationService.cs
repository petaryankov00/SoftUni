using FootballManager.Services.Contracts;
using FootballManager.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FootballManager.Services
{
    public class ValidationService : IValidationService
    {
        public List<ErrorViewModel> ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();

            var results = new List<ErrorViewModel>();

            bool isValid = Validator.TryValidateObject(model, context, errors, true);

            if (isValid)
            {
                return results;
            }

            results = errors
                .Select(x => new ErrorViewModel 
                { 
                    Message = x.ErrorMessage
                })
                .ToList();

            return results;
        }
    }
}
