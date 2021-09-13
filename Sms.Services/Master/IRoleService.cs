using Sms.BusinessObjects;
using Sms.BusinessObjects.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sms.Services.Master
{
    public interface IRoleService
    {
        Task<ResponseBo> DeleteRoleAsync(int roleId);
        Task<RoleBo> GetRoleDetailAsync(int roleId);
        Task<IEnumerable<RoleBo>> GetRolesAsync();
        Task<ResponseBo> InsertRoleAsync(RoleBo role);
        Task<ResponseBo> UpdateRoleAsync(RoleBo role);
    }
}
