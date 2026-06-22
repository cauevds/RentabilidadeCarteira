using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IPerformanceService
    {
        PerformanceCarteiraResponse RegisterCarteiraPerformance(IReadOnlyList<PerformanceCarteiraRequest> requests);

    }
}
