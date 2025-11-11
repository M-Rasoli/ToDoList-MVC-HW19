using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._common.Entities;

namespace App.Domain.Core.TodoListAgg.Contracts
{
    public interface ITodoService
    {
        Result<List<GetUserTasksDto>> GetUserTasks(int userId);
    }
}
