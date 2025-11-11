using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.Core.TodoListAgg.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DueDateShamsi { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
