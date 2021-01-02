using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizy_API.Authentication;
using Quizy_API.Data;
using Quizy_API.Models;
using Quizy_API.ModelsView;
using Quizy_API.Service;

namespace Quizy_API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(ApplicationDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return Ok(await _categoryService.GetCategory(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostCategory(CategoryMV categoryMV)
        {
            var category = await _categoryService.PostCategory(categoryMV);
            if (category == null)
            {
                return BadRequest();
            }
            return StatusCode(201, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, CategoryMV categoryMV)
        {
            var category = await _categoryService.PutCategories(id, categoryMV);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var isDeleted = await _categoryService.DeleteCategories(id);
            if (isDeleted == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}