using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sms.DataSource
{
    public class DataOperations : IDataOperations
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataOperations(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SMSConnectionString");
        }

        public async Task<int> InsertAsync(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);  
            }
        }

        public async Task<int> UpdateAsync(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure); 
            }
        }

        public async Task<int> DeleteAsync(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure); 
            }
        }

        public async Task<IEnumerable<TItem>> GetAsync<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<TItem>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TItem> GetDetailAsync<TItem>(string sql, DynamicParameters parameter)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<TItem>(sql, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TItem>> GetAsync<TItem>(string sql)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<TItem>(sql);
            }
        }
    }
}
