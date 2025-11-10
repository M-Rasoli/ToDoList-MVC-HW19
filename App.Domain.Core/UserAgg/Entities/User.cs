using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.TodoListAgg.Entities;

namespace App.Domain.Core.UserAgg.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<TodoList> TdoLists { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
