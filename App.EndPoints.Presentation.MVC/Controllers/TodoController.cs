using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Services.TodoListAgg;
using App.EndPoints.Presentation.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class TodoController(ITodoAppService todoAppService, ICategoryAppService categoryAppService) : Controller
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
        [HttpGet]
        public IActionResult Add()
        {
            AddNewTaskModel task = new AddNewTaskModel()
            {
                Categories = categoryAppService.GetCategories(),
            };
            return View(task);
        }
    }
}
