using FootballManager.ViewModels;
using System.Collections.Generic;

namespace FootballManager.Services.Contracts
{
    public interface IValidationService
    {
        List<ErrorViewModel> ValidateModel(object model);
    }
}
