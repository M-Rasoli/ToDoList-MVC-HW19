using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.TodoListAgg.Dtos;
using App.Domain.Core.TodoListAgg.Entities;
using App.Domain.Core.UserAgg.Dtos;
using App.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace App.Infrastructure.Repositories.TodoListAgg
{
    public class TodoRepository(AppDbContext _context) : ITodoRepository
    {
        public int AddNewTask(AddNewTodoDto task)
        {
            TodoList newTodo = new TodoList()
            {
                Title = task.Title,
                DueDate = task.DueDate,
                DueDateShamsi = task.DueDateShamsi,
                CategoryId = task.CategoryId,
                UserId = task.UserId
            };
            _context.TodoLists.Add(newTodo);
            return _context.SaveChanges();
        }

        public List<GetUserTasksDto> GetUserTasks(int userId, string sortOrder, string searchTerm)
        {
            var result = _context.TodoLists.Where(t => t.UserId == userId)
                .Select(x => new GetUserTasksDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category.Title,
                    IsDone = x.IsDone,
                    DueDate = x.DueDate,
                    DueDateShamsi = x.DueDateShamsi
                });
            if (searchTerm is not null)
            {
                result = result.Where(x => x.Title.Contains(searchTerm)
                                           || x.Category.Contains(searchTerm));
            }
            switch (sortOrder)
            {
                case "title-asc":
                    result = result.OrderBy(x => x.Title);
                    break;
                case "title-desc":
                    result = result.OrderByDescending(x => x.Title);
                    break;
                case "date-asc":
                    result = result.OrderBy(x => x.DueDate);
                    break;
                case "date-desc":
                    result = result.OrderByDescending(x => x.DueDate);
                    break;
                case "is-done-false":
                    result = result.OrderBy(x => x.IsDone);
                    break;
                case "is-done-true":
                    result = result.OrderBy(x => !x.IsDone);
                    break;
                case "_":
                    result = result;
                    break;
                default:
                    result = result;
                    break;
            }
            
            return result.ToList();

        }

        public int ChangeTaskStatus(int taskId)
        {
            var task = _context.TodoLists.FirstOrDefault(t => t.Id == taskId);
            task.IsDone = !task.IsDone;
            return _context.SaveChanges();
        }

        public int DeleteTask(int taskId)
        {
            return _context.TodoLists.Where(t => t.Id == taskId)
                .ExecuteDelete();
        }
    }
}
