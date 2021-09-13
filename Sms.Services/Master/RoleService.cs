using Sms.BusinessObjects;
using Sms.BusinessObjects.Master;
using System.Collections.Generic;
using Sms.Repositories.Master;
using System.Threading.Tasks;

namespace Sms.Services.Master
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseBo> DeleteRoleAsync(int roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }

        public async Task<RoleBo> GetRoleDetailAsync(int roleId)
        {
            return await _roleRepository.GetRoleDetailAsync(roleId);
        }

        public async Task<IEnumerable<RoleBo>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();
        }

        public async Task<ResponseBo> InsertRoleAsync(RoleBo role)
        {
            return await _roleRepository.InsertRoleAsync(role);
        }

        public async Task<ResponseBo> UpdateRoleAsync(RoleBo role)
        {
            return await _roleRepository.UpdateRoleAsync(role);
        }
    }
}
