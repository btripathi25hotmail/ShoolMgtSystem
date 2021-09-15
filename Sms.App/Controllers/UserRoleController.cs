using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sms.App.Models.Master;
using Sms.Services.Master;
using AutoMapper;
using Sms.BusinessObjects.Master;
using Sms.App.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Sms.BusinessObjects;
using System.Linq;

namespace Sms.App.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UserRoleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public UserRoleController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }
        #region HTTPGET IactionResults
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region HTTPPOST JsonResult ActionResults

        [HttpPost]
        public async Task<JsonResult> CreateRole([FromBody] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = User.Claims.FirstOrDefault(claim => claim.Type == "username").Value;
                return Json(await _roleService.InsertRoleAsync(_mapper.Map<RoleBo>(model)));
            }
            return Json(new ResposneModel { IsError = true, Message = ApplicationMessage.ModelStateFailed });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateRole([FromBody] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(await _roleService.UpdateRoleAsync(_mapper.Map<RoleBo>(model)));
            }
            return Json(new ResposneModel { IsError = true, Message = ApplicationMessage.ModelStateFailed });
        }

        #endregion

        #region HTTPGET JsonResult ActionResults

        [HttpGet]
        public async Task<JsonResult> DeleteRole(int id)
        {
            return Json(await _roleService.DeleteRoleAsync(id));
        }

        [HttpGet]
        public async Task<JsonResult> GetRoles()
        {
            return Json(_mapper.Map<IEnumerable<RoleBo>>(await _roleService.GetRolesAsync()));
        }

        [HttpGet]
        public async Task<JsonResult> GetRoleDetail(int id)
        {
            return Json(_mapper.Map<RoleBo>(await _roleService.GetRoleDetailAsync(id)));
        }

        #endregion

    }
}
