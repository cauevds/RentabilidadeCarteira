namespace RentabilidadeCarteira.Models.Responses
{
    public class CarteiraResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
