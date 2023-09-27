using Dapper;
using Npgsql;
using System.Data;

namespace Vanado_Machines.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _connection;
        public DbService(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("MachineDBConnection"));
        }
        public async Task<int> EditData(string command, object parms)
        {
            int result;
            result = await _connection.ExecuteAsync(command, parms);
            return result;
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            List<T> result = new List<T>();
            result = (await _connection.QueryAsync<T>(command, parms)).ToList();
            return result;
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result = (await _connection.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();
            return result;
        }

        public Task QueryAsync<T1, T2, T3>(string query, Func<object, object, object> value, string splitOn)
        {
            throw new NotImplementedException();
        }
    }
}
