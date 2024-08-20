﻿using ArtsofteClient.Models.Employee;

namespace ArtsofteClient.Models.Department;

public class DepartmentModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public int Floor { get; set; }

    public List<EmployeeModel> Employees { get; set; }
}