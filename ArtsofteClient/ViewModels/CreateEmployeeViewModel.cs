using ArtsofteClient.Models.Department;
using ArtsofteClient.Models.Language;

namespace ArtsofteClient.ViewModels;

public class CreateEmployeeViewModel
{
    public List<LanguageModel> Languages { get; set; }
    public List<DepartmentModel> Departments { get; set; }
}