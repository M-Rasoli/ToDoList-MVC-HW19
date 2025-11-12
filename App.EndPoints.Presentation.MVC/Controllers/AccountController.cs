using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.EndPoints.Presentation.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class AccountController(IUserAppService userAppService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            var result = userAppService.Login(model.UserName, model.Password);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            else
            {
                LoggedInUser.OnlineUSer = new OnlineUser()
                {
                    Id = result.Data.Id,
                    Username = result.Data.UserName
                };
                return RedirectToAction("Index","User");
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUserDto model)
        {
            return View();
        }
    }
}
