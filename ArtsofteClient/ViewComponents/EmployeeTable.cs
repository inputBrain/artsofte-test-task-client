using ArtsofteClient.API.Employee;
using ArtsofteClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class EmployeeTable : ViewComponent
{
    private readonly IRequestSender _sender;

    public EmployeeTable(IRequestSender sender)
    {
        _sender = sender;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var collection = await _sender.SendPostRequest<GetAllEmployeeResponse>("http://localhost:5000/api/Employee/ListAllEmployees", new object());

        return View("/Pages/Components/EmployeeTableView.cshtml", collection);
    }
}