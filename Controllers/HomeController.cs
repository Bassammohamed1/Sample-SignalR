using Microsoft.AspNetCore.Mvc;

namespace SampleSignalR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
