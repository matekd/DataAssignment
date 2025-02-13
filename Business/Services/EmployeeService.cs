using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _employeeRepository.BeginTransactionAsync();

            await _employeeRepository.CreateAsync(EmployeeFactory.Create(form));
            await _employeeRepository.SaveAsync();

            await _employeeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        var entity = await _employeeRepository.GetAsync(x => x.Id == id);

        return entity != null ? EmployeeFactory.Create(entity) : null;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var entities = await _employeeRepository.GetAllAsync();

        if (entities == null)
            return [];

        return entities.Select(EmployeeFactory.Create!);
    }

    public async Task<bool> UpdateEmployeeAsync(EmployeeUpdateForm form)
    {
        if (form == null)
            return false;

        try
        {
            await _employeeRepository.BeginTransactionAsync();

            _employeeRepository.Update(EmployeeFactory.Create(form));
            await _employeeRepository.SaveAsync();

            await _employeeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        try
        {
            var entity = await _employeeRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return false;

            await _employeeRepository.BeginTransactionAsync();

            _employeeRepository.Delete(entity);
            await _employeeRepository.SaveAsync();

            await _employeeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
