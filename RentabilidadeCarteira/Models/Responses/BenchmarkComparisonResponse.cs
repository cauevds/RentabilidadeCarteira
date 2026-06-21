namespace RentabilidadeCarteira.Models.Responses
{
    public class BenchmarkComparisonResponse
    {
        public int BenchmarkId { get; set; }
        public string Nome { get; set; } = string.Empty;

        /// <summary>Rentabilidade acumulada do benchmark no período, em percentual.</summary>
        public decimal RentabilidadeAcumulada { get; set; }

        /// <summary>Alpha = rentabilidade acumulada da carteira - rentabilidade acumulada do benchmark.</summary>
        public decimal Alpha { get; set; }
    }
}
