using Dapper;
using Npgsql;

namespace Catalog.API.Infrastructure.Services
{
    public class SqlQueries : ISqlQueries
    {
        private readonly string _connectionString;

        public SqlQueries(string connectionString)
        {
            _connectionString = connectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task<List<T>> QueryAsync<T>(string sql, object? paras = null)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            if (paras != null)
                return (await connection.QueryAsync<T>(sql, paras)).ToList();

            return (await connection.QueryAsync<T>(sql)).ToList();
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object? paras = null)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            if (paras != null)
                return await connection.QueryFirstOrDefaultAsync<T>(sql, paras);

            return await connection.QueryFirstOrDefaultAsync<T>(sql);
        }

        public async Task<T> ScalarAsync<T>(string sql, object? paras = null)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            if (paras != null)
                return await connection.ExecuteScalarAsync<T>(sql, paras);

            return await connection.ExecuteScalarAsync<T>(sql);
        }
    }
}