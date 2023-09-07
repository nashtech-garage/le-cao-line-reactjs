﻿namespace Catalog.API.Infrastructure.Services
{
    public interface ISqlQueries
    {
        Task<T> ScalarAsync<T>(string sql, object? paras = null);
        Task<T> QueryFirstAsync<T>(string sql, object? paras = null);
        Task<List<T>> QueryAsync<T>(string sql, object? paras = null);
    }
}