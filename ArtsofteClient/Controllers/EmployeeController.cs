using ArtsofteClient.API.Employee;
using ArtsofteClient.Models.Employee;
using ArtsofteClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    private readonly IRequestSender _sender;

    public EmployeeController(ILogger<EmployeeController> logger, IRequestSender sender)
    {
        _logger = logger;
        _sender = sender;
    }


    // [HttpGet]
    // public async Task<IActionResult> UpdateEmployee(int departmentId, int languageId, string name, string surname, int age, Gender gender)
    // {
    //     var requestBody = new GetOneEmployee
    //     {
    //         Id = id
    //     };
    //
    //     var model = await _sender.SendPostRequest<EmployeeModel>($"http://localhost:5000/api/Employee/Update", requestBody);
    //     
    //     return 
    // }

}