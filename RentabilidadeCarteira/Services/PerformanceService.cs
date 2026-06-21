using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IPerformanceCarteiraRepository _performanceRepository;

        public PerformanceService(
       ICarteiraRepository carteiraRepository,
       IPerformanceCarteiraRepository performanceRepository)
        {
            _carteiraRepository = carteiraRepository;
            _performanceRepository = performanceRepository;
        }

        public PerformanceCarteiraResponse RegisterCarteiraPerformance(IReadOnlyList<PerformanceCarteiraRequest> requests)
        {
            if (requests is null || requests.Count == 0)
                throw new Exception("Informe ao menos um registro de rentabilidade.");

            // 1. Validar os itens antes de salvar
            var chavesNoLote = new HashSet<string>();
            foreach (var request in requests)
            {
                if (!Competencia.IsValid(request.Competencia))
                    throw new Exception($"A competência '{request.Competencia}' deve seguir o formato yyyy-MM.");

                if (_carteiraRepository.GetById(request.CarteiraId) is null)
                    throw new Exception($"Carteira {request.CarteiraId} não encontrada.");

                if (_performanceRepository.Exists(request.CarteiraId, request.Competencia))
                    throw new Exception(
                        $"Já existe rentabilidade registrada para a carteira {request.CarteiraId} na competência {request.Competencia}.");

                if (!chavesNoLote.Add($"{request.CarteiraId}|{request.Competencia}"))
                    throw new Exception(
                        $"O lote contém rentabilidade duplicada para a carteira {request.CarteiraId} na competência {request.Competencia}.");
            }

            //Monta e salva as performances
            foreach (var request in requests)
            {
                _performanceRepository.Add(new PerformanceCarteira
                {
                    CarteiraId = request.CarteiraId,
                    Competencia = request.Competencia,
                    Rentabilidade = request.Rentabilidade
                });
            }

            return new PerformanceCarteiraResponse
            {
                Message = $"{requests.Count} rentabilidade(s) registrada(s) com sucesso"
            };
        }
    }
}
