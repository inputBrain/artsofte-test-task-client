using ArtsofteClient.Models.Employee;

namespace ArtsofteClient.API.Employee;

public class GetOneEmployee
{
    public EmployeeModel Employee { get; set; }
    
    public class RequestBody
    {
        public int EmployeeId { get; set; }
    }
}