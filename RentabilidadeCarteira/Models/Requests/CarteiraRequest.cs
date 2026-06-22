namespace RentabilidadeCarteira.Models.Requests
{
    public class CarteiraRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
