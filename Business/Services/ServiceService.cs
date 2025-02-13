using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    public readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<bool> CreateServiceAsync(ServiceRegistrationForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _serviceRepository.BeginTransactionAsync();

            await _serviceRepository.CreateAsync(ServiceFactory.Create(form));
            await _serviceRepository.SaveAsync();

            await _serviceRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _serviceRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        var entity = await _serviceRepository.GetAsync(x => x.Id == id);

        return entity != null ? ServiceFactory.Create(entity) : null;
    }

    public async Task<IEnumerable<Service>> GetServicesAsync()
    {
        var entities = await _serviceRepository.GetAllAsync();

        if (entities == null)
            return [];

        return entities.Select(ServiceFactory.Create!);
    }

    public async Task<bool> UpdateServiceAsync(ServiceUpdateForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _serviceRepository.BeginTransactionAsync();

            _serviceRepository.Update(ServiceFactory.Create(form));
            await _serviceRepository.SaveAsync();

            await _serviceRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _serviceRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteServiceAsync(int id)
    {
        try
        {
            var entity = await _serviceRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return false;

            await _serviceRepository.BeginTransactionAsync();

            _serviceRepository.Delete(entity);
            await _serviceRepository.SaveAsync();

            await _serviceRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _serviceRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
