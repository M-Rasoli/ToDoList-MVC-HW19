using App.Domain.Core.UserAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
