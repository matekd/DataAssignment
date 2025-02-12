using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();

    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        Name = form.Name,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,

        CustomerId = form.CustomerId,
        EmployeeId = form.EmployeeId,
        ServiceId = form.ServiceId,
        StatusId = form.StatusId,
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,

        CustomerId = entity.CustomerId,
        CustomerName = entity.Customer.Name,
        EmployeeId = entity.EmployeeId,
        EmployeeName = entity.Employee.Name,
        ServiceId = entity.ServiceId,
        ServiceName = entity.Service.Name,
        StatusId = entity.StatusId,
        Status = entity.Status.Status,
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        Name = project.Name,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,

        CustomerId = project.CustomerId,
        EmployeeId = project.EmployeeId,
        ServiceId = project.ServiceId,
        StatusId = project.StatusId,
    };

    public static ProjectEntity Create(ProjectUpdateForm form) => new()
    {
        Id = form.Id,
        Name = form.Name,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,

        CustomerId = form.CustomerId,
        EmployeeId = form.EmployeeId,
        ServiceId = form.ServiceId,
        StatusId = form.StatusId,
    };
}
