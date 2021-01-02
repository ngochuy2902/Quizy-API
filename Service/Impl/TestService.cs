using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quizy_API.Data;
using Quizy_API.Models;
using Quizy_API.ModelsView;

namespace Quizy_API.Service.Impl
{
    public class TestService : ITestService
    {
        private readonly ApplicationDbContext _context;

        public TestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return false;
            }
            test.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TestMV> GetTest(int id)
        {
            var test = await _context.Tests
            .Where(t => t.Id == id && t.DeletedAt == null)
            .Include(c => c.Category)
            .Include(q => q.Questions)
            .ThenInclude(o => o.Options) 
            .FirstOrDefaultAsync();

            if (test == null)
            {
                return null;
            }
            
            var testsMV = new TestMV
            {
                ImagePath = test.ImagePath,
                Description = test.Description,
                Title = test.Title,
                CategoryId = test.Category.Id,
                CategoryName = test.Category.Name,
                Questions = test.Questions.Select(q => new QuestionMV
                {
                    Content = q.Content,
                    ImagePath = q.ImagePath,
                    Options = q.Options.Select(o => new OptionMV 
                                                    {
                                                        Answer = o.Answer,
                                                        IsTrue = o.IsTrue
                                                    })
                                                    .ToList()
                })
                .ToList()
            };
            return testsMV;
        }

        public async Task<List<TestMV>> GetTests()
        {
            var tests = await _context.Tests
            .Where(x => x.DeletedAt == null)
            .Include(x => x.Category)
            .Include(x => x.Questions)
            .ThenInclude(x => x.Options)
            .ToListAsync();

            var testsMV = new List<TestMV>();

            foreach (var i in tests)
            {
                testsMV.Add(new TestMV
                {
                    ImagePath = i.ImagePath,
                    Description = i.Description,
                    Title = i.Title,
                    CategoryId = i.Category.Id,
                    CategoryName = i.Category.Name,
                    Questions = i.Questions.Select(q => new QuestionMV
                    {
                        Content = q.Content,
                        ImagePath = q.ImagePath,
                        Options = q.Options.Select(o => new OptionMV { Answer = o.Answer, IsTrue = o.IsTrue }).ToList()
                    }).ToList()
                });
            }

            return testsMV;
        }

        public async Task<TestMV> PostTest(TestMV testMV)
        {

            var questions = new List<Question>();

            questions = testMV.Questions.Select(x => new Question
            {
                Content = x.Content,
                ImagePath = x.ImagePath,
                Options = x.Options.Select(o => new Option { Answer = o.Answer, IsTrue = o.IsTrue }).ToList()
            }).ToList();

            var test = new Test
            {
                Title = testMV.Title,
                Description = testMV.Description,
                ImagePath = testMV.ImagePath,
                CategoryId = testMV.CategoryId,
                Questions = questions
            };

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return await GetTest(test.Id);
        }

        public async Task<TestMV> PutTest(int id, TestMV testMV)
        {
            var test = await _context.Tests.Where(t => t.Id == id && t.DeletedAt == null).FirstOrDefaultAsync();
            if (test == null)
            {
                return null;
            }

            test = await _context.Tests
            .Where(t => t.Id == id && t.DeletedAt == null)
            .Include(c => c.Category)
            .Include(q => q.Questions)
            .ThenInclude(o => o.Options) 
            .FirstOrDefaultAsync();

            var questions = new List<Question>();
            questions = testMV.Questions.Select(q => new Question
            {
                Content = q.Content,
                ImagePath = q.ImagePath,
                Options = q.Options.Select(o => new Option 
                                                {
                                                    Answer = o.Answer,
                                                    IsTrue = o.IsTrue
                                                }).ToList()
            }).ToList();

            test.Title = testMV.Title;
            test.Description = testMV.Description;
            test.CategoryId = testMV.CategoryId;
            test.ImagePath = testMV.ImagePath;
            test.Questions = questions;
            test.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return await GetTest(id);
        }
    }
}