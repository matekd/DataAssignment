using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository) : IStatusTypeService
{
    public readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task<bool> CreateStatusTypeAsync(StatusTypeRegistrationForm form)
    {
        if (form == null)
            return false;

        try
        {
            // Status is unique and the only attribute
            var entityExists = await _statusTypeRepository.AlreadyExists(x => x.Status == form.Status);
            if (entityExists)
                return false;

            await _statusTypeRepository.BeginTransactionAsync();

            await _statusTypeRepository.CreateAsync(StatusTypeFactory.Create(form));
            await _statusTypeRepository.SaveAsync();

            await _statusTypeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _statusTypeRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
    {
        var entity = await _statusTypeRepository.GetAsync(x => x.Id == id);

        return entity != null ? StatusTypeFactory.Create(entity) : null;
    }

    public async Task<IEnumerable<StatusType>> GetStatusTypesAsync()
    {
        var entities = await _statusTypeRepository.GetAllAsync();

        if (entities == null)
            return [];

        return entities.Select(StatusTypeFactory.Create!);
    }

    public async Task<bool> UpdateStatusTypeAsync(StatusTypeUpdateForm form)
    {
        if (form == null)
            return false;

        try
        {
            // Status is unique and the only attribute
            var entityExists = await _statusTypeRepository.AlreadyExists(x => x.Status == form.Status);
            if (entityExists)
                return false;

            await _statusTypeRepository.BeginTransactionAsync();

            _statusTypeRepository.Update(StatusTypeFactory.Create(form));
            await _statusTypeRepository.SaveAsync();

            await _statusTypeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _statusTypeRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteStatusTypeAsync(int id)
    {
        try
        {
            var entity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return false;

            await _statusTypeRepository.BeginTransactionAsync();

            _statusTypeRepository.Delete(entity);
            await _statusTypeRepository.SaveAsync();

            await _statusTypeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _statusTypeRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
