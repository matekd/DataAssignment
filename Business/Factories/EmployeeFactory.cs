using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static EmployeeRegistrationForm Create() => new();

    public static EmployeeEntity Create(EmployeeRegistrationForm form) => new()
    {
        Name = form.Name,
        Role = form.Role,
    };

    public static Employee Create(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Role = entity.Role,
    };

    public static EmployeeUpdateForm Create(Employee employee) => new()
    {
        Id = employee.Id,
        Name = employee.Name,
        Role = employee.Role,
    };

    public static EmployeeEntity Create(EmployeeUpdateForm form) => new()
    {
        Id = form.Id,
        Name = form.Name,
        Role = form.Role,
    };
}
