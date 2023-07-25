using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final.web.Controllers
{
    [Authorize(Roles = "Customer,Store,Worker")]
    public class CustomersController : Controller
    {
      
        public IActionResult Index(int Id)
        {
            if (Id == 0)
            {
                ViewBag.Id = 1;
            }
            else
            {
                ViewBag.Id = Id;
            }
          
            return View(ViewBag.Id);
        }

        public IActionResult Section()
        {
         

            return View();
        }
        
       public IActionResult WorkerProfileView()
        {
            return View();
        }

        public IActionResult StoreProfileView()
        {
            return View();
        }

        public IActionResult Shoppingcarts()
        {
            return View();
        }

     
    }
}
