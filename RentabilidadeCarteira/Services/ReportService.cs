using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Services
{
    public class ReportService : IReportService
    {
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IBenchmarkRepository _benchmarkRepository;
        private readonly IPerformanceCarteiraRepository _performanceCarteiraRepository;
        private readonly IPerformanceBenchmarkRepository _performanceBenchmarkRepository;

        public ReportService(
       ICarteiraRepository carteiraRepository,
       IBenchmarkRepository benchmarkRepository,
       IPerformanceCarteiraRepository performanceCarteiraRepository,
       IPerformanceBenchmarkRepository performanceBenchmarkRepository)
        {
            _carteiraRepository = carteiraRepository;
            _benchmarkRepository = benchmarkRepository;
            _performanceCarteiraRepository = performanceCarteiraRepository;
            _performanceBenchmarkRepository = performanceBenchmarkRepository;
        }

        public ReportResponse GerarRelatorio(ReportRequest request)
        {
            ValidarPeriodo(request);

            if (request.BenchmarkIds is null || request.BenchmarkIds.Count == 0)
                throw new Exception("Informe ao menos um benchmark.");

            //Buscar carteira
            var carteira = _carteiraRepository.GetById(request.CarteiraId)
                ?? throw new Exception($"Carteira {request.CarteiraId} não encontrada.");

            var competencias = Competencia.Range(request.PeriodoInicio, request.PeriodoFim);

            var carteiraPerformances = _performanceCarteiraRepository.GetByCarteira(request.CarteiraId);

            //Buscar performance da carteira
            var carteiraReturns = ValidarExtrairRentabilidade(
                competencias,
                carteiraPerformances.ToDictionary(p => p.Competencia, p => p.Rentabilidade),
                $"a carteira {carteira.Id}");

            //Consolidar rentabilidade da carteira.
            var carteiraAcumulada = CalculaPerformance.PercentualAcumulado(carteiraReturns);

            //Ler benchmarks, performances, consolidar e calcular alpha.
            var benchmarks = new List<BenchmarkComparisonResponse>();
            foreach (var benchmarkId in request.BenchmarkIds.Distinct())
            {
                var benchmark = _benchmarkRepository.GetById(benchmarkId)
                    ?? throw new Exception($"Benchmark {benchmarkId} não encontrado.");

                var performances = _performanceBenchmarkRepository.GetByBenchmark(benchmarkId);
                var returns = ValidarExtrairRentabilidade(
                    competencias,
                    performances.ToDictionary(p => p.Competencia, p => p.Rentabilidade),
                    $"o benchmark {benchmark.Id} ({benchmark.Nome})");

                var accumulated = CalculaPerformance.PercentualAcumulado(returns);

                benchmarks.Add(new BenchmarkComparisonResponse
                {
                    BenchmarkId = benchmark.Id,
                    Nome = benchmark.Nome,
                    RentabilidadeAcumulada = accumulated,
                    Alpha = CalculaPerformance.Alpha(carteiraAcumulada, accumulated)
                });
            }

            //Monta e retorna relatorio
            return new ReportResponse
            {
                Carteira = new ResumoResponse { Id = carteira.Id, Nome = carteira.Nome },
                PeriodoInicio = request.PeriodoInicio,
                PeriodoFim = request.PeriodoFim,
                RentabilidadeCarteiraAcumulada = carteiraAcumulada,
                Benchmarks = benchmarks
            };
        }

        private static void ValidarPeriodo(ReportRequest request)
        {
            if (!Competencia.IsValid(request.PeriodoInicio) || !Competencia.IsValid(request.PeriodoFim))
                throw new Exception("PeriodoInicio e PeriodoFim devem seguir o formato yyyy-MM.");

            if (Competencia.ToOrdinal(request.PeriodoInicio) > Competencia.ToOrdinal(request.PeriodoFim))
                throw new Exception("PeriodoInicio não pode ser posterior a PeriodoFim.");
        }

        private static List<decimal> ValidarExtrairRentabilidade(
            IReadOnlyList<string> competencias,
            IReadOnlyDictionary<string, decimal> performanceByCompetencia,
            string description)
        {
            var CompetenciaFaltantes = competencias.Where(c => !performanceByCompetencia.ContainsKey(c)).ToList();
            if (CompetenciaFaltantes.Count > 0)
                throw new Exception(
                    $"Dados incompletos para {description}. Competências faltantes: {string.Join(", ", CompetenciaFaltantes)}.");

            return competencias.Select(c => performanceByCompetencia[c]).ToList();
        }
    }
}
