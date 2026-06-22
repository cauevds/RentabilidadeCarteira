namespace RentabilidadeCarteira.Models.Entities
{
    public class PerformanceCarteira
    {
        public int Id { get; set; }
        public int CarteiraId { get; set; }

        /// <summary>Formato yyyy-MM.</summary>
        public string Competencia { get; set; } = string.Empty;

        /// <summary>Rentabilidade mensal em percentual (ex.: 1.20 = 1,20%).</summary>
        public decimal Rentabilidade { get; set; }
    }
}
