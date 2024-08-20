using ArtsofteClient.Models.Department;
using ArtsofteClient.Models.Employee;
using ArtsofteClient.Models.Language;

namespace ArtsofteClient.ViewModels;

public class UpdateEmployeeViewModel
{
    public EmployeeModel Employee { get; set; }
    public List<LanguageModel> Languages { get; set; }
    public List<DepartmentModel> Departments { get; set; }
}