using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizy_API.Data;
using Quizy_API.Models;

namespace Quizy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {
            return await _context.Tests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var Test = await _context.Tests.FindAsync(id);
            if (Test == null)
            {
                return NotFound();
            }
            return Test;
        }

        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test Test)
        {
            _context.Tests.Add(Test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get Test", new {id = Test.Id}, Test);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Test>> PutTest(int id, Test Test)
        {
            if (id != Test.Id)
            {
                return BadRequest();
            }
            _context.Entry(Test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Test);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Test>> DeleteTest(int id)
        {
            var Test = await _context.Tests.FindAsync(id);
            if (Test == null)
            {
                return NotFound();
            }

            Test.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Test;
        }

        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }
    }
}