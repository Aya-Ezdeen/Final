using Microsoft.AspNetCore.Mvc;

namespace Final.web.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }
    }
}
