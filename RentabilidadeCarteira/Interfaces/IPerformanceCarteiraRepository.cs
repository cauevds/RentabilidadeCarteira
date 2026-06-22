using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IPerformanceCarteiraRepository
    {
        IReadOnlyList<PerformanceCarteira> GetByCarteira(int carteiraId);
        bool Exists(int carteiraId, string competencia);
        PerformanceCarteira Add(PerformanceCarteira performance);
    }
}
