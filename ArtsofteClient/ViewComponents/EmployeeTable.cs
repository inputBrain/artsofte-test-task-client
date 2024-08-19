using ArtsofteClient.Models.Employee;
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
        var body = new RequestBody()
        {
            Skip = 0,
            Take = 10
        };
        
        var collection = await _sender.SendPostRequest<EmployeeData>("http://localhost:5000/api/Employee/ListAllEmployees", body);

        return View("/Pages/Components/EmployeeTableView.cshtml", collection);
    }


    public class EmployeeData
    {
        public List<EmployeeModel> Employees { get; set; }
    }
    public class RequestBody()
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}