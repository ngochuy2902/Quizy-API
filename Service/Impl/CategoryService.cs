using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizy_API.Data;
using Quizy_API.Models;
using Quizy_API.ModelsView;

namespace Quizy_API.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteCategories(int id)
        {
            var category = await GetCategory(id);
            if (category == null)
            {
                return false;
            }
            category.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.Where(c=> c.DeletedAt == null).ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.Where(c => c.Id == id && c.DeletedAt == null).FirstOrDefaultAsync();
        }

        public async Task<Category> PostCategory(CategoryMV categoryMV)
        {
            var c = await FindByName(categoryMV.Name);
            if (c != null)
            {
                return null;
            }
            Category category = new Category
            {
                Name = categoryMV.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> PutCategories(int id, CategoryMV categoryMV)
        {
            var category = await GetCategory(id);
            if (category == null)
            {
                return null;
            }
            category.Name = categoryMV.Name;
            category.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return category;
        }

        private Task<Category> FindByName(string name) => _context.Categories.Where(c => c.Name == name && c.DeletedAt == null).FirstOrDefaultAsync();
    }
}