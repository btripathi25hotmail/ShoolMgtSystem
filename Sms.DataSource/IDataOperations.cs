using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sms.DataSource
{
    public interface IDataOperations
    {
        Task<int> DeleteAsync(string sql, DynamicParameters parameter);
        Task<IEnumerable<TItem>> GetAsync<TItem>(string sql);
        Task<IEnumerable<TItem>> GetAsync<TItem>(string sql, DynamicParameters parameter);
        Task<TItem> GetDetailAsync<TItem>(string sql, DynamicParameters parameter);
        Task<int> InsertAsync(string sql, DynamicParameters parameter);
        Task<int> UpdateAsync(string sql, DynamicParameters parameter);
    }
}