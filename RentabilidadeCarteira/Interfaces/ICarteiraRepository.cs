using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Interfaces
{
    public interface ICarteiraRepository
    {
        IReadOnlyList<Carteira> GetAll();
        Carteira? GetById(int id);
        Carteira Add(Carteira carteira);
    }
}
