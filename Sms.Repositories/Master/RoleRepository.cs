using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sms.DataSource;
using Sms.BusinessObjects.Master;
using Sms.BusinessObjects;
using Dapper;

namespace Sms.Repositories.Master
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDataOperations _db;

        public RoleRepository(IDataOperations db)
        {
            _db = db;
        }

        public async Task<ResponseBo> InsertRoleAsync(RoleBo role)
        {
            try
            {
                return await _db.InsertAsync(DbCommands.RoleProc, SetInputParameters(DbActions.RoleInsert, role.RoleId, role.RoleName, role.CreatedBy, role.IsActive)) > 0
                ? new ResponseBo { IsSucceeded = true, Message = RoleMessage.InsertMessage }
                : new ResponseBo { IsSucceeded = false, Message = ApplicationMessage.SomethingWentWrong };
            }
            catch (Exception ex)
            {
                return new ResponseBo { IsError = true, Message = ex.Message };
            }
        }

        public async Task<ResponseBo> UpdateRoleAsync(RoleBo role)
        {
            try
            {
                return await _db.UpdateAsync(DbCommands.RoleProc, SetInputParameters(DbActions.RoleUpdate, role.RoleId, role.RoleName, role.CreatedBy, role.IsActive)) > 0
                ? new ResponseBo { IsSucceeded = true, Message = RoleMessage.UpdateMessage }
                : new ResponseBo { IsSucceeded = false, Message = ApplicationMessage.SomethingWentWrong };
            }
            catch (Exception ex)
            {
                return new ResponseBo { IsError = true, Message = ex.Message };
            }
        }

        public async Task<ResponseBo> DeleteRoleAsync(int roleId)
        {
            try
            {
                return await _db.UpdateAsync(DbCommands.RoleProc, SetInputParameters(DbActions.RoleDetail, roleId)) > 0
                ? new ResponseBo { IsSucceeded = true, Message = RoleMessage.DeleteMessage }
                : new ResponseBo { IsSucceeded = false, Message = ApplicationMessage.SomethingWentWrong };
            }
            catch (Exception ex)
            {
                return new ResponseBo { IsError = true, Message = ex.Message };
            }
        }

        public async Task<IEnumerable<RoleBo>> GetRolesAsync()
        {
            try
            {
                return await _db.GetAsync<RoleBo>(DbCommands.RoleProc, SetInputParameters(DbActions.RoleGet));
            }
            catch (Exception ex)
            {
                return new List<RoleBo>();
            }
        }

        public async Task<RoleBo> GetRoleDetailAsync(int roleId)
        {
            try
            {
                return await _db.GetDetailAsync<RoleBo>(DbCommands.RoleProc, SetInputParameters(DbActions.RoleDetail));
            }
            catch (Exception ex)
            {
                return new RoleBo();
            }
        }

        private DynamicParameters SetInputParameters(string sqlAction, int roleId = 0, string roleName = "", string createdBy = "", bool isActive = false)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@actionName", sqlAction);
            parameters.Add("@rId", roleId);
            parameters.Add("@rName", roleName);
            parameters.Add("@cBy", createdBy);
            parameters.Add("@status", isActive);
            return parameters;
        }
    }
}
