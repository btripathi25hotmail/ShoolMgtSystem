using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Sms.Repositories
{
    public class DbOperations : IDbOperations
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbOperations(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SMSConnectionString");
        }
        public async Task<bool> Insert<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var result = await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);
                return result > 0 ? true : false;
            }
        }

        public async Task<bool> Update<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var result = await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);
                return result > 0 ? true : false;
            }
        }

        public async Task<bool> Delete<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var result = await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);
                return result > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<TItem>> Get<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<TItem>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TItem> GetDetail<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var records = await db.QueryFirstOrDefaultAsync<TItem>(sql, parameter, commandType: CommandType.StoredProcedure);
                return records;
            }
        }

        public async Task<IEnumerable<TItem>> Get<TItem>(string sql)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<TItem>(sql);
            }
        }
    }
}