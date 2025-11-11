using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TodoListAgg.Dtos
{
    public class AddNewTodoDto
    {
        public string Title { get; set; }
        public string DueDateShamsi { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
