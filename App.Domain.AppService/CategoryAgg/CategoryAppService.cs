using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.AppService.CategoryAgg
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public List<GetCategoryDto> GetCategories()
        {
            return categoryService.GetCategories();
        }
    }
}
