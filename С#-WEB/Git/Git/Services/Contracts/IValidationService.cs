using Git.ViewModels;

namespace Git.Services.Contracts
{
    public interface IValidationService
    {
        (bool isValid, ErrorViewModel error) ValidateModel(object model);
    }
}
