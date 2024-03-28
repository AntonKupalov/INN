using INN.Models.InnViewModels;

namespace INN.Services;

public class EnteringPassportDataService
{
    public PassportDataViewModel InputData(PassportDataViewModel passportDataViewModel)
    {
        var viewModel = new PassportDataViewModel
        {
            Surname = passportDataViewModel.Surname,
            Name = passportDataViewModel.Name,
            LastName = passportDataViewModel.LastName,
            Birthday = passportDataViewModel.Birthday,
            PlaceBirthday = passportDataViewModel.PlaceBirthday,
            City = passportDataViewModel.City

        };

        return viewModel;
    }
}