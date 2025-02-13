using Business.Models;

namespace Business.Interfaces;

public interface IServiceService
{
    public Task<bool> CreateServiceAsync(ServiceRegistrationForm form);
    public Task<IEnumerable<Service>> GetServicesAsync();
    public Task<Service?> GetServiceByIdAsync(int id);
    public Task<bool> UpdateServiceAsync(ServiceUpdateForm form);
    public Task<bool> DeleteServiceAsync(int id);
}
