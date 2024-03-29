﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ITafsilRepository
    {
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<TafsilBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(TafsilBussines item, SqlTransaction tr);
        Task<List<TafsilBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<TafsilBussines> GetAsync(string _connectionString, Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(TafsilBussines item, bool status, SqlTransaction tr);
        Task<string> NextCodeAsync(string _connectionString, HesabType type);
        Task<bool> CheckCodeAsync(string _connectionString, Guid guid, string code);
        Task<bool> CheckNameAsync(string _connectionString, string name);
        Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price, SqlTransaction tr);
        Task<TafsilBussines> GetAsync(string _connectionString, string code);
    }
}
