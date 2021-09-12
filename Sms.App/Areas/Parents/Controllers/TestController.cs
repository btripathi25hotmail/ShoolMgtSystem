using Microsoft.AspNetCore.Mvc;

namespace Sms.App.Parents.Controllers
{
    [Area("Products")]
    public class TestController : Controller
    {
        public string Index()
        {
            return "Brajesh";
        }

    }
}