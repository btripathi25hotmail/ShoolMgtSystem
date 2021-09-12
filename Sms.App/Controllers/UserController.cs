using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sms.App.Models.Users;
using Sms.BusinessObjects.User;
using Sms.Repositories.User;

namespace Sms.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _user;

        public UserController(IMapper mapper, IUserRepository user)
        {
            _mapper = mapper;
            _user = user;
        }

        #region HTTPGET Action Methods

        public IActionResult Login()
        {
            SetNames();
            return View();
        }

        public IActionResult Register()
        {
            SetNames();
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("login");
        }

        #endregion

        #region HTTPPOST Action methods
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            SetNames();
            if (ModelState.IsValid)
            {
                var login = _mapper.Map<LoginBo>(loginModel);
                var userDetail = _mapper.Map<LoginDetailModel>(await _user.Validate<LoginDetailBo>(_mapper.Map<LoginBo>(loginModel)));
                if (userDetail != null)
                {
                    var cliams = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Email,userDetail.Email),
                            new Claim(ClaimTypes.Name,userDetail.Name)
                        };
                    var claimIdentity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrinciples = new ClaimsPrincipal(claimIdentity);
                    await HttpContext.SignInAsync(claimPrinciples);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.IsLoginFailed = true;
                    return View();
                }

            }
            return View(loginModel);
        }
        #endregion

        private void SetNames()
        {
            ViewBag.ControllerName = ControllerContext.ActionDescriptor.ControllerName;
            ViewBag.ActionName = ControllerContext.ActionDescriptor.ActionName;
        }
    }
}