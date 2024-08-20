using ArtsofteClient.Models.Employee;

namespace ArtsofteClient.API.Employee;

public class GetAllEmployeeResponse
{
    public List<EmployeeModel> Employees { get; set; }
}