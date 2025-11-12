using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.UserAgg.Contracts;
using App.EndPoints.Presentation.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class UserController(IUserAppService userAppService, ITodoAppService todoAppService) : Controller
    {
        public IActionResult Index()
        {
            var tasks = todoAppService.GetUserTasks(LoggedInUser.OnlineUSer.Id);
            if (!tasks.IsSuccess)
            {
                ViewBag.Error = tasks.Message;
                return View();
            }
            else
            {
                return View(tasks.Data);
            }
        }
    }
}
