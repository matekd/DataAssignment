using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory
{
    public static StatusTypeRegistrationForm Create() => new();

    public static StatusTypeEntity Create(StatusTypeRegistrationForm form) => new()
    {
        Status = form.Status,
    };

    public static StatusType Create(StatusTypeEntity entity) => new()
    {
        Id = entity.Id,
        Status = entity.Status,
    };

    public static StatusTypeUpdateForm Create(StatusType statusType) => new()
    {
        Id = statusType.Id,
        Status = statusType.Status,
    };

    public static StatusTypeEntity Create(StatusTypeUpdateForm form) => new()
    {
        Id = form.Id,
        Status = form.Status,
    };
}
