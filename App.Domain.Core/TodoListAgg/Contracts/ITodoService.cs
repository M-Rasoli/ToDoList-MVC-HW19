using App.Domain.Core._common.Entities;
using App.Domain.Core.TodoListAgg.Dtos;
using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TodoListAgg.Contracts
{
    public interface ITodoService
    {
        List<GetUserTasksDto> GetUserTasks(int userId);
        int AddNewTask(AddNewTodoDto task);
        int ChangeTaskStatus(int taskId);
    }
}
