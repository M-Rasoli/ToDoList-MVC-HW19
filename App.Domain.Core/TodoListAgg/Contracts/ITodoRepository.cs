using App.Domain.Core.UserAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TodoListAgg.Contracts
{
    public interface ITodoRepository
    {
       List<GetUserTasksDto> GetUserTasks(int userId);
    }
}
