using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizy_API.Data;
using Quizy_API.Models;
using Quizy_API.ModelsView;
using Quizy_API.Service;

namespace Quizy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITestService _testService;

        public TestController(ApplicationDbContext context, ITestService testService)
        {
            _context = context;
            _testService = testService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetTests()
        {
            return Ok(await _testService.GetTests());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _testService.GetTest(id);
            if (test == null)
            {
                return NotFound();
            }
            return Ok(test);
        }

        [HttpPost]
        public async Task<ActionResult> PostTest(TestMV testMV)
        {
            var test = await _testService.PostTest(testMV);
            return StatusCode(201, test);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTest(int id, TestMV testMV)
        {
            var test = await _testService.PutTest(id, testMV);
            if (test == null)
            {
                return BadRequest();
            }            
            return Ok(test);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTest(int id)
        {
            var isDeleted = await _testService.DeleteTest(id);
            if (isDeleted == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}