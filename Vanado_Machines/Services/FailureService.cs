using Dapper;
using System.Data.SqlClient;
using Vanado_Machines.Models;
using Vanado_Machines.Models.Dto;

namespace Vanado_Machines.Services
{
    public class FailureService : IFailureService
    {
        private readonly IDbService _dbService;
        private string _connectionString;

        public FailureService(IDbService dbService)
        {
            _dbService = dbService;
            _connectionString = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=MachineDB;Pooling=true;Integrated Security=true;";
        }
        public async Task<bool> CreateFailure(FailureDto failure)
        {
            var result = await _dbService.EditData(" INSERT INTO public.failure (id, name, priority, start_time, end_time, description, status, machine_id) " +
                "SELECT @Id, @Name, @Priority, @StartTime, @EndTime, @Description, @Status, @MachineId" +
                " FROM public.machine WHERE id = @MachineId;", failure);
            return true;
        }

        public async Task<bool> DeleteFailure(int id)
        {
            var deleteFailure = await _dbService.EditData("DELETE FROM public.failure WHERE id=@Id", new { id });
            return true;
        }

        public async Task<List<Failure>> GetAllFailures()
        {
            var failuresList = await _dbService.GetAll<Failure>("SELECT * FROM public.failure", new { });
            return failuresList;
        }

        public async Task<Failure> GetFailureById(int id)
        {
            var failureById = await _dbService.GetAsync<Failure>("SELECT * FROM public.failure where id = @Id", new { id });
            return failureById;
        }

        public async Task<Failure> UpdateFailure(FailureDto failure)
        {
            try
            {
                const string updateQuery = @"
            UPDATE public.failure
            SET 
                name = @Name,
                priority = @Priority,
                start_time = @StartTime,
                end_time = @EndTime,
                description = @Description,
                status = @Status,
                machine_id = (SELECT id FROM public.machine AS m WHERE m.id = @MachineId)
            WHERE id = @Id
            RETURNING *";

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var updatedFailure = await connection.QuerySingleOrDefaultAsync<Failure>(updateQuery, failure);

                    return updatedFailure;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddFailureToMachine(int failureId, int machineId)
        { 
            var result =
                await _dbService.EditData(
                    "INSERT INTO failure_machine (failure_id, machine_id) VALUES (@FailureId, @MachineId)",
                    new { FailureId = failureId, MachineId = machineId });
            return true;
        }
    }
}
