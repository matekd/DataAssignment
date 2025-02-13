using Business.Models;

namespace Business.Interfaces;

public interface ICustomerService
{
    public Task<bool> CreateCustomerAsync(CustomerRegistrationForm form);
    public Task<IEnumerable<Customer>> GetCustomersAsync();
    public Task<Customer?> GetCustomerByIdAsync(int id);
    public Task<bool> UpdateCustomerAsync(CustomerUpdateForm form);
    public Task<bool> DeleteCustomerAsync(int id);
}