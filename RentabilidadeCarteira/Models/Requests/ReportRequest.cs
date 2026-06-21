namespace RentabilidadeCarteira.Models.Requests
{
    public class ReportRequest
    {
        public int CarteiraId { get; set; }

        public string PeriodoInicio { get; set; } = string.Empty;

        public string PeriodoFim { get; set; } = string.Empty;

        public List<int> BenchmarkIds { get; set; } = new();
    }
}
