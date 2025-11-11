using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public List<GetCategoryDto> GetCategories()
        {
            var categories = categoryRepository.GetCategories();
            return categories;
        }
    }
}
