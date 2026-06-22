namespace RentabilidadeCarteira.Models.Requests
{
    public class ReportRequest
    {
        /// <example>1</example>
        public int CarteiraId { get; set; }

        /// <summary>Formato yyyy-MM.</summary>
        /// <example>2026-01</example>
        public string PeriodoInicio { get; set; } = string.Empty;

        /// <summary>Formato yyyy-MM.</summary>
        /// <example>2026-03</example>
        public string PeriodoFim { get; set; } = string.Empty;

        /// <summary>1=CDI, 2=IBOV 3=IPCA.</summary>
        /// <example>1,2,3</example>
        public List<int> BenchmarkIds { get; set; } = new();
    }
}
