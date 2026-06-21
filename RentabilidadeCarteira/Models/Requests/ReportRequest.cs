namespace RentabilidadeCarteira.Models.Requests
{
    public class ReportRequest
    {
        public int CarteiraId { get; set; }

        /// <summary>Início do período no formato yyyy-MM.</summary>
        public string PeriodoInicio { get; set; } = string.Empty;

        /// <summary>Fim do período no formato yyyy-MM.</summary>
        public string PeriodoFim { get; set; } = string.Empty;

        public List<int> BenchmarkIds { get; set; } = new();
    }
}
