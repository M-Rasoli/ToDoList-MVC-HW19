using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.Repositories.TodoListAgg
{
    public class TodoRepository(AppDbContext _context) : ITodoRepository
    {
        public List<GetUserTasksDto> GetUserTasks(int userId)
        {
            return _context.TodoLists.Where(t => t.UserId == userId)
                .Select(x => new GetUserTasksDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDone = x.IsDone,
                    DueDate = x.DueDate,
                    DueDateShamsi = x.DueDateShamsi
                }).ToList();
        }
    }
}
