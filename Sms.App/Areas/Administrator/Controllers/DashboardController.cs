
using Microsoft.AspNetCore.Mvc;

namespace Sms.App.Administrator.Controllers
{
    [Area("Administrator")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}