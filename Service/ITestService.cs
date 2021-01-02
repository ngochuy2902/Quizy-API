using System.Collections.Generic;
using System.Threading.Tasks;
using Quizy_API.Models;
using Quizy_API.ModelsView;

namespace Quizy_API.Service
{
    public interface ITestService
    {
        Task<List<TestMV>> GetTests();
        Task<TestMV> GetTest(int id);
        Task<TestMV> PostTest(TestMV testMV);
        Task<TestMV> PutTest(int id, TestMV testMV);
        Task<bool> DeleteTest(int id);
    }
}