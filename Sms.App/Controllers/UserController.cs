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
using Sms.Services.User;

namespace Sms.App.Controllers
{
    [AutoValidateAntiforgeryToken]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
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

        [HttpGet("User/ForgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Login");
        }

        #endregion

        #region HTTPPOST Action methods

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            SetNames();
            if (ModelState.IsValid)
            {
                var login = _mapper.Map<LoginBo>(loginModel);
                var userDetail = _mapper.Map<LoginDetailModel>(await _userService.ValidateAsync<LoginDetailBo>(_mapper.Map<LoginBo>(loginModel)));
                if (userDetail != null)
                {
                    var cliams = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Email,userDetail.Email),
                            new Claim("username",userDetail.Email),
                            new Claim(ClaimTypes.Name, userDetail.Name)
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