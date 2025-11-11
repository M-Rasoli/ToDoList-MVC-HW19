using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.TodoListAgg.Entities;

namespace App.Domain.Core.UserAgg.Dtos
{
    public class GetUserTasksDto
    {
        public List<TodoList> UserTasks { get; set; }
    }
}
