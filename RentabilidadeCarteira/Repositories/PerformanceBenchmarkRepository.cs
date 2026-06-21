using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class PerformanceBenchmarkRepository : IPerformanceBenchmarkRepository
    {
        public IReadOnlyList<PerformanceBenchmark> GetByBenchmark(int benchmarkId)
        {
            throw new NotImplementedException();
        }
    }
}
