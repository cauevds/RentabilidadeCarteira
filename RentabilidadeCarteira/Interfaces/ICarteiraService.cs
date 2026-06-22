using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Interfaces
{
    public interface ICarteiraService
    {
        IReadOnlyList<CarteiraResponse> GetAll();
        CarteiraResponse? GetById(int id);
        CarteiraResponse Create(CarteiraRequest request);
    }
}
