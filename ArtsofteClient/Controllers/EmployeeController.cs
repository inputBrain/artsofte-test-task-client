using System.Text;
using ArtsofteClient.API.Employee;
using ArtsofteClient.Models.Employee;
using ArtsofteClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.Controllers;

public class EmployeeController : Controller
{
    private const string BaseUrl = "http://localhost:5000/api/Employee/";

    private readonly IRequestSender _requestSender;


    public EmployeeController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }
    
    
    public async Task<IActionResult> CreateEmployee(string name, string surname, int age, int departmentId, int languageId, Gender gender)
    {
        var requestBody = new CreateEmployeeResponse.RequestBody
        {
            Name = name,
            Surname = surname,
            Age = age,
            DepartmentId = departmentId,
            LanguageId = languageId,
            Gender = gender

        };
    
        await _requestSender.SendPostRequest<GetAllEmployeeResponse>(BaseUrl + "CreateEmployee", requestBody);

        return RedirectToAction("Index", "Home");
    }


    public IActionResult CreateEmployeeForm()
    {
        return View();
    }
    
    
    public async Task<IActionResult> UpdateEmployee(int employeeId, int departmentId, int languageId, string name, string surname, int age)
    {
        var requestBody = new UpdateEmployeeResponse.RequestBody
        {
            EmployeeId = employeeId,
            DepartmentId = departmentId,
            LanguageId = languageId,
            Name = name,
            Surname = surname,
            Age = age
        };
    
        await _requestSender.SendPostRequest(BaseUrl + "UpdateEmployee", requestBody);

        return RedirectToAction("Index", "Home");
    }
    
    
    public async Task<IActionResult> UpdateEmployeeForm(int employeeId)
    {
        var getOneEmployeeBody = new GetOneEmployeeResponse.RequestBody
        {
            EmployeeId = employeeId
        };

        var model = await _requestSender.SendPostRequest<GetOneEmployeeResponse>(BaseUrl + "GetOneEmployeeById", getOneEmployeeBody);
        
        return View(model);
    }
    
    
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var body = new GetOneEmployeeResponse.RequestBody
        {
            EmployeeId = employeeId
        };

        await _requestSender.SendWithBodyAsync(BaseUrl + "DeleteEmployee", body, HttpMethod.Delete);

        return RedirectToAction("Index", "Home");
    }
}