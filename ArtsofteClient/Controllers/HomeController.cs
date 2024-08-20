using System.Diagnostics;
using ArtsofteClient.API.Employee;
using Microsoft.AspNetCore.Mvc;
using ArtsofteClient.Models;
using ArtsofteClient.Services;

namespace ArtsofteClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private readonly IRequestSender _requestSender;


    public HomeController(ILogger<HomeController> logger, IRequestSender requestSender)
    {
        _logger = logger;
        _requestSender = requestSender;
    }


    public async Task<IActionResult> Index()
    {
        var collection = await _requestSender.SendPostRequest<GetAllEmployeeResponse>("http://localhost:5000/api/Employee/ListAllEmployees", new object());

        return View(collection);
    }


    public IActionResult Privacy()
    {
        return View();
    }
    
    



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            }
        );
    }
}