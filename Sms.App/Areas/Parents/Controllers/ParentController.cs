using Microsoft.AspNetCore.Mvc;

namespace Sms.App.Parents.Controllers
{
    [Area("Parents")]
    public class ParentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}