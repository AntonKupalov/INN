using INN.Models;
using INN.Models.InnViewModels;

namespace INN.Services;

public class CreateInnService
{
    private Random _random = new Random();
    public InnViewModel GetInn(PassportDataViewModel viewModel)
    {
        var innViewModel = new InnViewModel
        {
            Name = viewModel.Name,
            SurName = viewModel.Surname,
            LastName = viewModel.LastName,
            Birthday = viewModel.Birthday,
            PlaceBirthday = viewModel.PlaceBirthday,
            InnNumber = CreateInn(viewModel)
        };
        
        return innViewModel;
    }

    private string CreateInn(PassportDataViewModel viewModel)
    {
       
        var regionCode =  GetRegionCode(viewModel.City);
        var taxOfficeNumber = GetTaxOfficeNumber(viewModel.City);
        var numberUnique = GetNumberUnique(); 
        var inn = regionCode+ taxOfficeNumber + numberUnique;
        return inn;
    }

    private string GetTaxOfficeNumber(string viewModelCity)
    {
        var taxOfficeNumbers = TaxOfficeNumber.TaxOfficeNumbers;
        return SearchData(taxOfficeNumbers, viewModelCity);
    }

    private string GetNumberUnique()
    {
        return _random.Next(000000,999999).ToString(); 
    }

    private string GetRegionCode(string viewModelCity)
    {
        var regionCodes = RegionCode.RegionCodes;
        return SearchData(regionCodes,viewModelCity);
    }

    private string SearchData(Dictionary<string,int> data,string dataForSearch)
    {
        var foundData  = "";
        foreach (var region in data)
        {
            if (region.Key == dataForSearch)
            {
                foundData = region.Value.ToString();
            }
        }

        return foundData;
    }
    
}