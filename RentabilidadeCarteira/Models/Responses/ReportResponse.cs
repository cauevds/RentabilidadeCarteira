namespace RentabilidadeCarteira.Models.Responses
{
    public class ReportResponse
    {
        public ResumoResponse Carteira { get; set; } = new();
        public string PeriodoInicio { get; set; } = string.Empty;
        public string PeriodoFim { get; set; } = string.Empty;
        public decimal RentabilidadeCarteiraAcumulada { get; set; }
        public List<BenchmarkComparisonResponse> Benchmarks { get; set; } = new();
    }   
}
