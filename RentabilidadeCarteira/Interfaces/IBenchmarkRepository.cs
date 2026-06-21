using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IBenchmarkRepository
    {
        IReadOnlyList<Benchmark> GetAll();
        Benchmark? GetById(int id);
        Benchmark Add(Benchmark benchmark);
    }
}
