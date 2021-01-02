using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizy_API.Models;
using Quizy_API.ModelsView;

namespace Quizy_API.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> PostCategory(CategoryMV categoryMV);
        Task<Category> PutCategories(int id, CategoryMV categoryMV);
        Task<bool> DeleteCategories(int id);
    }
}