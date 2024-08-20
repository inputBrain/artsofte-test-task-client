using System.Text;
using ArtsofteClient.API.Department;
using ArtsofteClient.API.Employee;
using ArtsofteClient.API.Language;
using ArtsofteClient.Models.Employee;
using ArtsofteClient.Services;
using ArtsofteClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.Controllers;

public class EmployeeController : Controller
{
    private const string BaseUrl = "http://localhost:5000/api/";

    private readonly IRequestSender _requestSender;


    public EmployeeController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }
    
    
    public async Task<IActionResult> CreateEmployee(string name, string surname, int age, int departmentId, int languageId, int gender)
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
    
        await _requestSender.SendPostRequest<GetAllEmployeeResponse>(BaseUrl + "Employee/CreateEmployee", requestBody);

        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> CreateEmployeeForm()
    {
        var languages = await _requestSender.SendPostRequest<GetAllLanguageResponse>(BaseUrl + "Language/ListAllLanguage", new object());
        var departments = await _requestSender.SendPostRequest<GetAllDepartmentResponse>(BaseUrl + "Department/ListAllDepartment", new object());
        
        var viewModel = new CreateEmployeeViewModel
        {
            Languages = languages.Languages,
            Departments = departments.Departments
        };
        
        return View(viewModel);
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
    
        await _requestSender.SendPostRequest(BaseUrl + "Employee/UpdateEmployee", requestBody);

        return RedirectToAction("Index", "Home");
    }
    
    
    public async Task<IActionResult> UpdateEmployeeForm(int employeeId)
    {
        var getOneEmployeeBody = new GetOneEmployeeResponse.RequestBody
        {
            EmployeeId = employeeId
        };

        var model = await _requestSender.SendPostRequest<GetOneEmployeeResponse>(BaseUrl + "Employee/GetOneEmployeeById", getOneEmployeeBody);
        var languages = await _requestSender.SendPostRequest<GetAllLanguageResponse>(BaseUrl + "Language/ListAllLanguage", new object());
        var departments = await _requestSender.SendPostRequest<GetAllDepartmentResponse>(BaseUrl + "Department/ListAllDepartment", new object());
        
        var viewModel = new UpdateEmployeeViewModel
        {
            Employee = model.Employee,
            Languages = languages.Languages,
            Departments = departments.Departments
        };
        
        return View(viewModel);
    }
    
    
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var body = new GetOneEmployeeResponse.RequestBody
        {
            EmployeeId = employeeId
        };

        await _requestSender.SendWithBodyAsync(BaseUrl + "Employee/DeleteEmployee", body, HttpMethod.Delete);

        return RedirectToAction("Index", "Home");
    }
}