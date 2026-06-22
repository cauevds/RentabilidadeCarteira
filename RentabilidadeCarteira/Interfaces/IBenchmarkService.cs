using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IBenchmarkService
    {
        IReadOnlyList<BenchmarkResponse> GetAll();
        BenchmarkResponse GetById(int id);

        BenchmarkResponse Create(BenchmarkRequest request);
    }
}
