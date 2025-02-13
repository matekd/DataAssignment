using Business.Models;

namespace Business.Interfaces;

public interface IStatusTypeService
{
    public Task<bool> CreateStatusTypeAsync(StatusTypeRegistrationForm form);
    public Task<IEnumerable<StatusType>> GetStatusTypesAsync();
    public Task<StatusType?> GetStatusTypeByIdAsync(int id);
    public Task<bool> UpdateStatusTypeAsync(StatusTypeUpdateForm form);
    public Task<bool> DeleteStatusTypeAsync(int id);
}