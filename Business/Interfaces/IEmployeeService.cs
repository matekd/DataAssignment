using Business.Models;

namespace Business.Interfaces;

public interface IEmployeeService
{
    public Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form);
    public Task<IEnumerable<Employee>> GetEmployeesAsync();
    public Task<Employee?> GetEmployeeByIdAsync(int id);
    public Task<bool> UpdateEmployeeAsync(EmployeeUpdateForm form);
    public Task<bool> DeleteEmployeeAsync(int id);
}
