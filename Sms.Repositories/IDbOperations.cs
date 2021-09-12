using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Sms.Repositories
{
    public interface IDbOperations
    {
        Task<bool> Delete<TItem>(string sql, DynamicParameters parameter);
        Task<IEnumerable<TItem>> Get<TItem>(string sql);
        Task<IEnumerable<TItem>> Get<TItem>(string sql, DynamicParameters parameter);
        Task<TItem> GetDetail<TItem>(string sql, DynamicParameters parameter);
        Task<bool> Insert<TItem>(string sql, DynamicParameters parameter);
        Task<bool> Update<TItem>(string sql, DynamicParameters parameter);
    }
}