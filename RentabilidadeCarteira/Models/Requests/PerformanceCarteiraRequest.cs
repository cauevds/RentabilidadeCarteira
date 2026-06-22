namespace RentabilidadeCarteira.Models.Requests
{
    public class PerformanceCarteiraRequest
    {

        public int CarteiraId { get; set; }

        /// <summary>Formato yyyy-MM.</summary>      
        /// <example>2026-01</example>
        public string Competencia { get; set; } = string.Empty;

        /// <summary>Porcentagem. Ou seja 1 = 1.00%.</summary>
        /// <example>1.27</example>
        public decimal Rentabilidade
        {
            get; set;
        }
    }
}