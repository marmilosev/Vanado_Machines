using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public interface IFailureService
    {
        Task<bool> CreateFailur(Failure failure);
        Task<List<Failure>> GetAllFailures();
        Task<Failure> UpdateFailure(Failure failure);
        Task<bool> DeleteFailure(int key);
    }
}
