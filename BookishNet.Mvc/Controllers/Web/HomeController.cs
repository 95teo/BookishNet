using Microsoft.AspNetCore.Mvc;

namespace BookishNet.Mvc.Controllers.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}