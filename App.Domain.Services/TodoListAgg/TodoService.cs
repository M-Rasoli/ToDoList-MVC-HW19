using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;

namespace App.Domain.Services.TodoListAgg
{
    public class TodoService(ITodoRepository todoRepository) : ITodoService
    {
        public Result<List<GetUserTasksDto>> GetUserTasks(int userId)
        {
            var result = todoRepository.GetUserTasks(userId);
            if (result.Count < 0)
            {
                return Result<List<GetUserTasksDto>>.Failure(message:"لیست کار های شما خالی است.");
            }
            else
            {
                return Result<List<GetUserTasksDto>>.Success(message:"لیست کار ها." , result);
            }
        }
    }
}
