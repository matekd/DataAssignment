using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _customerRepository.BeginTransactionAsync();

            await _customerRepository.CreateAsync(CustomerFactory.Create(form));
            await _customerRepository.SaveAsync();

            await _customerRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);

        return entity != null ? CustomerFactory.Create(entity) : null;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();

        if (entities == null)
            return [];

        return entities.Select(CustomerFactory.Create!);
    }

    public async Task<bool> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _customerRepository.BeginTransactionAsync();

            _customerRepository.Update(CustomerFactory.Create(form));
            await _customerRepository.SaveAsync();

            await _customerRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        try
        {
            var entity = await _customerRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return false;

            await _customerRepository.BeginTransactionAsync();

            _customerRepository.Delete(entity);
            await _customerRepository.SaveAsync();

            await _customerRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
