using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        Name = form.Name,
        ContactPerson = form.ContactPerson,
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        ContactPerson = entity.ContactPerson,
    };

    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        Id = customer.Id,
        Name = customer.Name,
        ContactPerson = customer.ContactPerson,
    };

    public static CustomerEntity Create(CustomerUpdateForm form) => new()
    {
        Id = form.Id,
        Name = form.Name,
        ContactPerson = form.ContactPerson,
    };
}
