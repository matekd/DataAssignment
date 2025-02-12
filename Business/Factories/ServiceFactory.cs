using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceRegistrationForm Create() => new();

    public static ServiceEntity Create(ServiceRegistrationForm form) => new()
    {
        Name = form.Name,
        Price = form.Price,
    };

    public static Service Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Price = entity.Price,
    };

    public static ServiceUpdateForm Create(Service service) => new()
    {
        Id = service.Id,
        Name = service.Name,
        Price = service.Price,
    };

    public static ServiceEntity Create(ServiceUpdateForm form) => new()
    {
        Id = form.Id,
        Name = form.Name,
        Price = form.Price,
    };
}
