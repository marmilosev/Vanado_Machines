using Vanado_Machines.Models;
using Vanado_Machines.Models.Dto;

namespace Vanado_Machines.Services
{
    public interface IFailureService
    {
        Task<bool> CreateFailure(FailureDto failure);
        Task<List<Failure>> GetAllFailures();
        Task<Failure> GetFailureById(int id);
        Task<List<Failure>> GetFailuresByIds(List<int> failureIds);
        Task<Failure> UpdateFailure(FailureDto failure);
        Task<bool> DeleteFailure(int id);
        Task<bool> AddFailureToMachine(int failureId, int machineId);
        Task<List<Machine>> GetMachinesForFailure(int failureId);
    }
}
