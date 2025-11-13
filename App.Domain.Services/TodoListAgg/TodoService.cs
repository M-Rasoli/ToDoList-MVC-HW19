using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.TodoListAgg.Dtos;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;

namespace App.Domain.Services.TodoListAgg
{
    public class TodoService(ITodoRepository todoRepository) : ITodoService
    {
        public int AddNewTask(AddNewTodoDto task)
        {
            return todoRepository.AddNewTask(task);
        }

        public List<GetUserTasksDto> GetUserTasks(int userId , string sortOrder, string searchTerm)
        {
            var result = todoRepository.GetUserTasks(userId , sortOrder, searchTerm);
            return result;
        }

        public int ChangeTaskStatus(int taskId)
        {
            return todoRepository.ChangeTaskStatus(taskId);
        }

        public int DeleteTask(int taskId)
        {
            return todoRepository.DeleteTask(taskId);
        }
    }
}
