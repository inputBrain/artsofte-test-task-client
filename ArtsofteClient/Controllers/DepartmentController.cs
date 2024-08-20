using ArtsofteClient.API.Department;
using ArtsofteClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.Controllers;

public class DepartmentController : Controller
{
    private const string BaseUrl = "http://localhost:5000/api/Department/";

    private readonly IRequestSender _requestSender;


    public DepartmentController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }


    public async Task<IActionResult> Index()
    {
        var collection = await _requestSender.SendPostRequest<GetAllDepartmentResponse>(BaseUrl + "ListAllDepartment", new object());
        return View(collection);
    }
}