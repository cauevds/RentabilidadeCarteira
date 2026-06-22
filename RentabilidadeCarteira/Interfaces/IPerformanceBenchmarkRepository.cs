using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IPerformanceBenchmarkRepository
    {
        IReadOnlyList<PerformanceBenchmark> GetByBenchmark(int benchmarkId);

    }
}
