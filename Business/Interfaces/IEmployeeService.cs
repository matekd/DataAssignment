using Business.Models;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeAsync(EmployeeUpdateForm form);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}