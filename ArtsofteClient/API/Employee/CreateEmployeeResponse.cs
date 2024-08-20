using ArtsofteClient.Models.Employee;

namespace ArtsofteClient.API.Employee;

public class CreateEmployeeResponse
{
    public class RequestBody
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public int LanguageId { get; set; }
        
        public Gender Gender { get; set; }
    }
}