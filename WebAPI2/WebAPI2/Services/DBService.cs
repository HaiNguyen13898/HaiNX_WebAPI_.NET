using Dapper;
using Npgsql;
using System.Data;

namespace WebAPI2.Services
{
    public class DBService : IDbService
    {
        private readonly IDbConnection _db;

        public DBService(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("Studentdb"));
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }

    }
}
