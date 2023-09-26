using Dapper;
using System.Data.SqlClient;
using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public class FailureService : IFailureService
    {
        private readonly IDbService _dbService;
        private readonly string _connectionString;

        public FailureService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateFailure(Failure failure)
        {
            try
            {
                const string query = @"
                    INSERT INTO public.failure (id, name, priority, starttime, endttime, description, status, machineId)
                    SELECT @Id, @Name, @Priority, @StartTime, @EndTime, @Description, @Status, @MachineId
                    FROM public.machine
                    WHERE id = @MachineId";
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var affectedRows = await connection.ExecuteAsync(query, failure);
                    return affectedRows == 1;
                }
            }catch (Exception ex)
            {
                return false;
            }
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

        public async Task<Failure> UpdateFailure(Failure failure)
        {
            try
            {
                const string updateFailureQuery = @"
                    UPDATE public.failure AS f
                    SET 
                        name = @Name, priority = @Priority, starttime = @StartTime, endtime = @EndTime, description = @Description, status = @Status,
                                machineId = (SELECT id FROM public.machine AS m WHERE m.name = @MachineName)
                    WHERE f.id = @Id";
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var updatedFailure = await connection.QuerySingleOrDefaultAsync<Failure>(updateFailureQuery, failure);
                    return updatedFailure;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
