using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Services.TodoListAgg;
using App.EndPoints.Presentation.MVC.Models;
using App.EndPoints.Presentation.MVC.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace App.EndPoints.Presentation.MVC.Controllers
{
    public class TodoController(ITodoAppService todoAppService, ICategoryAppService categoryAppService) : Controller
    {
        public IActionResult Index(string sortOrder ,string searchTerm)
        {
            var tasks = todoAppService.GetUserTasks(LoggedInUser.OnlineUSer.Id , sortOrder, searchTerm);
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
        [HttpPost]
        public IActionResult Add(AddNewTaskModel model)
        {
            model.NewTodo.UserId = LoggedInUser.OnlineUSer.Id;
            model.NewTodo.DueDate = PersianDateToGregorian.ConvertPersianDateToGregorian(model.NewTodo.DueDateShamsi);
            ////var persian = new PersianCalendar();
            ////var parts = model.NewTodo.DueDateShamsi.Split('/');
            ////int year = int.Parse(parts[0]);
            ////int month = int.Parse(parts[1]);
            ////int day = int.Parse(parts[2]);

            ////model.NewTodo.DueDate = persian.ToDateTime(year, month, day, 0, 0, 0, 0);

            var result = todoAppService.AddNewTask(model.NewTodo);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Todo");
            }
            else
            {
                ViewBag.Error = result.Message;
                return RedirectToAction("Index","Todo");
            }
        }

        [HttpPost]
        public IActionResult ChangeTaskStatus(int taskId)
        {
            var result = todoAppService.ChangeTaskStatus(taskId);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Todo");
            }
            else
            {
                ViewBag.Error = result.Message;
                return RedirectToAction("Index", "Todo");
            }
        }
        
        public IActionResult Delete(int taskId)
        {
            var result = todoAppService.DeleteTask(taskId);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Todo");
            }
            else
            {
                ViewBag.Error = result.Message;
                return RedirectToAction("Index", "Todo");
            }
        }
    }
}
