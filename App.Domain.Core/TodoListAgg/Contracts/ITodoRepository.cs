using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.TodoListAgg.Dtos;

namespace App.Domain.Core.TodoListAgg.Contracts
{
    public interface ITodoRepository
    {
       List<GetUserTasksDto> GetUserTasks(int userId, string sortOrder, string searchTerm);
       int AddNewTask(AddNewTodoDto task);
       int ChangeTaskStatus(int taskId);
       int DeleteTask(int taskId);
    }
}
