using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
