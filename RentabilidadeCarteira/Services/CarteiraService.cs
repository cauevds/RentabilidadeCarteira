using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Services
{
    public class CarteiraService :ICarteiraService
    {

        private readonly ICarteiraRepository _repository;

        public CarteiraService(ICarteiraRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<CarteiraResponse> GetAll()
        {
            return _repository.GetAll().Select(Map).ToList();
        }

        public CarteiraResponse? GetById(int id)
        {
            var carteira = _repository.GetById(id);
            if(carteira == null)
                return null;

            return Map(carteira);
        }

        public CarteiraResponse Create(CarteiraRequest request)
        {
            var carteira = _repository.Add(new Carteira
            {
                Nome = request.Nome,
                Cliente = request.Cliente,
                Status = request.Status
            });

            return Map(carteira);
        }

        private static CarteiraResponse Map(Carteira c)
        {
            return new CarteiraResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Cliente = c.Cliente,
                Status = c.Status
            };
        }

    }
}
