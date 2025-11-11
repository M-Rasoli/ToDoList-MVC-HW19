using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public List<GetCategoryDto> GetCategories()
        {
            return _context.Categories.Select(x => new GetCategoryDto()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
