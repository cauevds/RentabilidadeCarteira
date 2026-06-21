namespace RentabilidadeCarteira.Models.Entities
{
    public class PerformanceBenchmark
    {
        public int Id { get; set; }
        public int BenchmarkId { get; set; }

        /// <summary>Formato yyyy-MM.</summary>
        public string Competencia { get; set; } = string.Empty;

        /// <summary>Rentabilidade mensal em percentual (ex.: 1.00 = 1,00%).</summary>
        public decimal Rentabilidade { get; set; }
    }
}
