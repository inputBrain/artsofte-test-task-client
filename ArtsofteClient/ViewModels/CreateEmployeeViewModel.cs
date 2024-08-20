using System.ComponentModel.DataAnnotations;
using ArtsofteClient.Models.Department;
using ArtsofteClient.Models.Language;

namespace ArtsofteClient.ViewModels;

public class CreateEmployeeViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(16, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 16 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    [StringLength(16, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 16 characters")]
    public string Surname { get; set; }

    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Language is required")]
    public int LanguageId { get; set; }

    [Required(ErrorMessage = "Department is required")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public int Gender { get; set; }
    
    public List<LanguageModel> Languages { get; set; }
    public List<DepartmentModel> Departments { get; set; }
}