namespace RentabilidadeCarteira.Models.Requests
{
    public class PerformanceCarteiraRequest
    {

        public int CarteiraId { get; set; }

        public string Competencia { get; set; } = string.Empty;
     
        public decimal Rentabilidade
        {
            get; set;
        }
    }
}