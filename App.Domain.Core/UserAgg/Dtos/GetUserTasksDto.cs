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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsDone { get; set; }
        public string DueDateShamsi { get; set; }
        public DateTime DueDate { get; set; }
    }
}
