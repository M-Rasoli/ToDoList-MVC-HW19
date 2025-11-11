using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.TodoListAgg.Dtos;

namespace App.EndPoints.Presentation.MVC.Models
{
    public class AddNewTaskModel
    {
        public AddNewTodoDto NewTodo { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
