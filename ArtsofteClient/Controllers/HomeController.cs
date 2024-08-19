using System.Diagnostics;
using ArtsofteClient.API.Employee;
using Microsoft.AspNetCore.Mvc;
using ArtsofteClient.Models;
using ArtsofteClient.Models.Employee;
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


    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }
    
    
    public async Task<IActionResult> UpdateEmployee(int employeeId, int departmentId, int languageId, string name, string surname, int age)
    {
        var requestBody = new UpdateEmployee.RequestBody
        {
            EmployeeId = employeeId,
            DepartmentId = departmentId,
            LanguageId = languageId,
            Name = name,
            Surname = surname,
            Age = age
        };
    
        await _requestSender.SendPostRequest<EmployeeModel>("http://localhost:5000/api/Employee/UpdateEmployee", requestBody);

        return RedirectToAction("Index");
    }
    
    
    public async Task<IActionResult> UpdateEmployeeForm(int employeeId)
    {
        var getOneEmployeeBody = new GetOneEmployee.RequestBody
        {
            EmployeeId = employeeId
        };

        var model = await _requestSender.SendPostRequest<GetOneEmployee>("http://localhost:5000/api/Employee/GetOneEmployeeById", getOneEmployeeBody);
        
        return View(model);
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