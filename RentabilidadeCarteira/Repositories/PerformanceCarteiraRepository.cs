using ClosedXML.Excel;
using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class PerformanceCarteiraRepository : IPerformanceCarteiraRepository
    {
        public PerformanceCarteira Add(PerformanceCarteira performance)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int carteiraId, string competencia)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<PerformanceCarteira> GetByCarteira(int carteiraId)
        {
            throw new NotImplementedException();
        }
    }

}
