using INN.Models.InnViewModels;
using INN.Services;
using Microsoft.AspNetCore.Mvc;

namespace INN.Controllers;

public class InnController : Controller
{
    private EnteringPassportDataService _enteringPassportDataService;
    private CreateInnService _createInnService;
    private static InnViewModel _inn ;

    public InnController(EnteringPassportDataService enteringPassportDataService,
        CreateInnService createInnService)
    {
        _enteringPassportDataService = enteringPassportDataService;
        _createInnService = createInnService;
    }
    
    [HttpGet]
    public IActionResult EnteringPassportData()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult EnteringPassportData(PassportDataViewModel passportDataViewModel)
    {
       var viewModel =  _enteringPassportDataService.InputData(passportDataViewModel);

       var innViewModel = _createInnService.GetInn(viewModel);

       _inn = innViewModel;

        return RedirectToAction("CheckInn");
    }

    [HttpGet]
    public IActionResult CheckInn()
    {
        return View(_inn);
    }
    
}