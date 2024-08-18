using ArtsofteClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class EmployeeTable : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var collection = new List<EmployeeModel>
        {
            new(){Id = 1, Department = "Department 1", Language = "C#", Name = "Alex", Surname = "Pro", Age = 10, Gender = "Male"},
            new(){Id = 2, Department = "Department 2", Language = "PHP", Name = "Bob", Surname = "Noob", Age = 16, Gender = "Female"},
            new(){Id = 3, Department = "Department 3", Language = "Ruby", Name = "Oleg", Surname = "John", Age = 20, Gender = "Trans"},
            new(){Id = 4, Department = "Department 4", Language = "Python", Name = "Hellen", Surname = "Budq", Age = 30, Gender = "Intersex"}
        };
        
        return View("/Pages/Components/EmployeeTableView.cshtml", collection);
    }
}