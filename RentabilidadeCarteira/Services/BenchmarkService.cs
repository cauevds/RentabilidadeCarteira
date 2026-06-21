using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Services
{
    public class BenchmarkService : IBenchmarkService
    {

        private readonly IBenchmarkRepository _repository;

        public BenchmarkService(IBenchmarkRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<BenchmarkResponse> GetAll()
        {
            return _repository.GetAll().Select(Map).ToList();
        }

        public BenchmarkResponse GetById(int id)
        {
            var benchmark = _repository.GetById(id);
            if (benchmark == null)
                return null;

            return Map(benchmark);
        }

        public BenchmarkResponse Create(BenchmarkRequest request)
        {
            var benchmark = _repository.Add(new Benchmark
            {
                Nome = request.Nome,
                Codigo = request.Codigo
            });

            return Map(benchmark);
        }

        private static BenchmarkResponse Map(Benchmark b)
        {
            return new BenchmarkResponse
            {
                Id = b.Id,
                Nome = b.Nome,
                Codigo = b.Codigo
            };
        }
    }
}
