using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public interface IFailureService
    {
        Task<bool> CreateFailure(Failure failure);
        Task<List<Failure>> GetAllFailures();
        Task<Failure> GetFailureById(int id);
        Task<Failure> UpdateFailure(Failure failure);
        Task<bool> DeleteFailure(int id);
    }
}
