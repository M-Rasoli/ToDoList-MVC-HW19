using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetCategories();
    }
}
