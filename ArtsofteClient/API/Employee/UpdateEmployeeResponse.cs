namespace ArtsofteClient.API.Employee;

public class UpdateEmployeeResponse
{
    public class RequestBody
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
    
        public int LanguageId { get; set; }
        
        public string Name { get; set; }
    
        public string Surname { get; set; }
    
        public int Age { get; set; }
    }
}