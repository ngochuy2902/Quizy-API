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
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var Question = await _context.Questions.FindAsync(id);
            if (Question == null)
            {
                return NotFound();
            }
            return Question;
        }

        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question Question)
        {
            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get Question", new {id = Question.Id}, Question);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Question>> PutQuestion(int id, Question Question)
        {
            if (id != Question.Id)
            {
                return BadRequest();
            }
            _context.Entry(Question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Question);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            var Question = await _context.Questions.FindAsync(id);
            if (Question == null)
            {
                return NotFound();
            }

            Question.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Question;
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
